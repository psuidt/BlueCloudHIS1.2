using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using HIS.Model;
using HIS.BLL;
using HIS.MSAccess;

namespace HIS_DJSFManager.类
{
    /// <summary>
    /// 普通结算扩展类,实现多张处方打印一张
    /// </summary>
    public class GeneralChargeEx : GeneralCharge
    {
        
        /// <summary>
        /// 门诊结算对象，该对象实现多张处方一次结算的功能
        /// </summary>
        /// <param name="Patient">要结算的病人对象</param>
        /// <param name="OperatorId">操作员</param>
        public GeneralChargeEx( OutPatient Patient , int OperatorId ,ChargeType _ChargeType)
            : base( Patient, OperatorId ,_ChargeType)
        {
        }
        /// <summary>
        /// 预算
        /// </summary>
        /// <param name="prescriptions">要预算的处方</param>
        /// <returns>预算信息,供正式结算用</returns>
        public override ChargeInfo[] Budget( Prescription[] prescriptions )
        {
            //单张处方明细转化为大项目明细合并后累加在取舍。

            //保存每张处方的大项目明细
            List<List<Item>> lstStatItems = new List<List<Item>>( ); 
            //本次结算总金额(等于每张处方舍入后的金额的合计)
            decimal chargeTotalCost = 0;
            #region 合并大类并计算舍入金额
            try
            {
                for ( int i = 0 ; i < prescriptions.Length ; i++ )
                {
                    List<Item> lstTemp = new List<Item>( );   
                    lstTemp = MergePrescriptionByStatItemCode(ref prescriptions[i]);
                    chargeTotalCost = chargeTotalCost + prescriptions[i].Total_Fee;
                    lstStatItems.Add( lstTemp );
                }
            }
            catch(Exception err)
            {
                throw new Exception( "合并项目发生错误！" );
            }
            #endregion
            //保存合并后的所有大项目明细，类型MZ_CostOrder
            Hashtable htCostOrder = new Hashtable(); 
            #region 合并所有结算明细(不需要再舍入)
            try
            {
                foreach ( List<Item> lstTemp in lstStatItems )
                {
                    foreach ( object obj in lstTemp )
                    {
                        if ( htCostOrder.ContainsKey( ( (Item)obj ).Text.Trim( ) ) )
                        {
                            Item item = (Item)obj;
                            MZ_CostOrder mz_costorder = (MZ_CostOrder)htCostOrder[item.Text.Trim( )];
                            mz_costorder.Total_Fee = mz_costorder.Total_Fee + Convert.ToDecimal( item.Value );
                        }
                        else
                        {
                            MZ_CostOrder mz_costorder = new HIS.Model.MZ_CostOrder( );
                            mz_costorder.ItemType = ( (Item)obj ).Text.Trim( );
                            mz_costorder.Total_Fee = Convert.ToDecimal( ( (Item)obj ).Value );
                            htCostOrder.Add( mz_costorder.ItemType , mz_costorder );
                        }
                    }
                }
            }
            catch ( Exception err )
            {
                throw new Exception( "合并明细大类发生错误！" );
            }
            #endregion
            int costmasterid = MSAccessDb.GetMaxID( "MZ_COSTMASTER" , Tables.mz_costmaster.COSTMASTERID );
            #region 数据库操作,得到结算号
            try
            {
                MSAccessDb.BeginTrans();

                #region 赋值结算头表并保存
                HIS.Model.MZ_CostMaster mz_costmaster = new HIS.Model.MZ_CostMaster( );
                mz_costmaster.PatID = Patient.PatID;
                mz_costmaster.PatListID = Patient.PatListID;
                mz_costmaster.PresMasterID = 0;
                mz_costmaster.TicketNum = "";
                mz_costmaster.TicketCode = "";
                mz_costmaster.ChargeCode = OperatorId.ToString( );
                mz_costmaster.ChargeName = DataReader.GetEmployeeNameById( OperatorId );
                mz_costmaster.Total_Fee = chargeTotalCost;//结算表的总金额
                mz_costmaster.Self_Fee = 0;
                mz_costmaster.Village_Fee = 0;
                mz_costmaster.Favor_Fee = 0;
                mz_costmaster.Pos_Fee = 0;
                mz_costmaster.Money_Fee = 0;
                mz_costmaster.Ticket_Flag = 0;
                mz_costmaster.Record_Flag = 9;//预结算记录状态置为9
                mz_costmaster.OldID = 0;
                mz_costmaster.AccountID = 0;
                mz_costmaster.Hang_Flag = (int)OPDOperationType.门诊收费;
                mz_costmaster.Hurried_Flag = Patient.IsEmergency ? 1 : 0;
                mz_costmaster.CostMasterID = costmasterid;
                
                MSAccessDb.InsertRecord( mz_costmaster , Tables.mz_costorder.COSTORDERID );
                #endregion
                
                #region 更新处方表的结算号和总金额，舍入金额
                for ( int prescCount = 0 ; prescCount < prescriptions.Length ; prescCount++ )
                {
                    string strWhere = Tables.mz_presmaster.PRESMASTERID + " = " + prescriptions[prescCount].PrescriptionID;
                    MZ_PresMaster mz_presmaster = (MZ_PresMaster)MSAccessDb.GetModel( "MZ_PRESMASTER" , strWhere , typeof( MZ_PresMaster ) );
                    if ( mz_presmaster.Charge_Flag == 1 )
                        throw new Exception( "处方已被别的收费员收费，请确认！" );
                    //更新处方表的结算号和总金额，舍入金额
                    //BindEntity<MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( strWhere ,
                    //                      Tables.mz_presmaster.COSTMASTERID + " = " + mz_costmaster.CostMasterID ,
                    //                      Tables.mz_presmaster.TOTAL_FEE + " = " + prescriptions[prescCount].Total_Fee ,
                    //                      Tables.mz_presmaster.ROUNGINGMONEY + " = " + prescriptions[prescCount].RoundingMoney );
                    MSAccessDb.UpdateRecord( new string[]{Tables.mz_presmaster.COSTMASTERID + " = " + mz_costmaster.CostMasterID ,
                                                          Tables.mz_presmaster.TOTAL_FEE + " = " + prescriptions[prescCount].Total_Fee ,
                                                          Tables.mz_presmaster.ROUNGINGMONEY + " = " + prescriptions[prescCount].RoundingMoney} ,
                        strWhere , typeof( MZ_PresMaster ) );
                }
                #endregion

                #region 保存结算明细到数据库(按大项目保存)
                int costorderid = MSAccessDb.GetMaxID( "MZ_COSTORDER" , Tables.mz_costorder.COSTORDERID );
                foreach ( object obj in htCostOrder )
                {
                    HIS.Model.MZ_CostOrder mz_costorder = (HIS.Model.MZ_CostOrder)( (System.Collections.DictionaryEntry)obj ).Value;
                    mz_costorder.CostID = mz_costmaster.CostMasterID;
                    mz_costorder.CostOrderID = costorderid;
                    //保存到数据库
                    //mz_costorder.CostOrderID = BindEntity<MZ_CostOrder>.CreateInstanceDAL( oleDb ).Add( mz_costorder );
                    MSAccessDb.InsertRecord( mz_costorder , Tables.mz_costorder.COSTORDERID );
                    costorderid++;
                }
                #endregion

                MSAccessDb.CommitTrans( );
            }
            
            catch ( Exception err )
            {
                MSAccessDb.RollbackTrans( );
                throw new Exception( "保存预算结果到数据库发生错误！" );
            }
            #endregion
            //回填处方的结算号
            for ( int prescCount = 0 ; prescCount < prescriptions.Length ; prescCount++ )
                prescriptions[prescCount].ChargeID = costmasterid;

            #region 返回预算结果
            try
            {
                Hashtable htInvoiceItem = new Hashtable( );
                foreach ( object obj in htCostOrder )
                {
                    HIS.Model.MZ_CostOrder mz_costorder = (HIS.Model.MZ_CostOrder)( (System.Collections.DictionaryEntry)obj ).Value;
                    InvoiceItem invoice = GetInvoiceByStatCode( mz_costorder.ItemType.Trim( ) );
                    invoice.Cost = mz_costorder.Total_Fee;
                    if ( htInvoiceItem.ContainsKey( invoice.ItemCode.Trim( ) ) )
                    {
                        InvoiceItem _invoice = (InvoiceItem)htInvoiceItem[invoice.ItemCode] ;
                        _invoice.Cost = _invoice.Cost + invoice.Cost;
                        htInvoiceItem.Remove( invoice.ItemCode );
                        htInvoiceItem.Add( _invoice.ItemCode , _invoice );
                    }
                    else
                    {
                        htInvoiceItem.Add( invoice.ItemCode , invoice );
                    }
                }
                List<InvoiceItem> chargeItems = new List<InvoiceItem>( );
                foreach ( object item in htInvoiceItem )
                    chargeItems.Add( (InvoiceItem)( (DictionaryEntry)item ).Value );

                ChargeInfo chargeInfos = new ChargeInfo( );
                chargeInfos.Items = chargeItems.ToArray( );
                chargeInfos.ChargeID = costmasterid;
                chargeInfos.TotalFee = chargeTotalCost;

                ChargeInfo[] chargeInfo = new ChargeInfo[1];
                chargeInfo[0].TotalFee = chargeTotalCost;
                chargeInfo[0] = chargeInfos;
                //计算本次的优惠金额
                chargeInfo[0].FavorFee = GetFavorCost( Patient.MediType , chargeInfo[0] , prescriptions );
                return chargeInfo;
            }
            catch(Exception err)
            {
                throw new Exception( "返回预算结果发生错误！" );
            }
            #endregion
        }
        /// <summary>
        /// 正式结算
        /// </summary>
        /// <param name="BudgetaryChargeInfos">预算信息</param>
        /// <param name="prescriptions">要结算的处方，该处方对象经过预算方法处理</param>
        /// <returns>true:结算成功，false：结算失败</returns>
        public override bool Charge( ChargeInfo[] BudgetaryChargeInfos , Prescription[] prescriptions , out BaseInvoice[] ChargeInvoicies )
        {

            MSAccessDb.BeginTrans( );
            
            try
            {
                for ( int chargeCount = 0 ; chargeCount < BudgetaryChargeInfos.Length ; chargeCount++ )
                {
                    //if ( BindEntity<MZ_CostMaster>.CreateInstanceDAL( oleDb ).Exists( BudgetaryChargeInfos[chargeCount].ChargeID ) )
                    if ( MSAccessDb.Exists( "MZ_COSTMASTER",Tables.mz_costmaster.COSTMASTERID + "=" + BudgetaryChargeInfos[chargeCount].ChargeID) )
                    {
                        
                        HIS.Model.MZ_CostMaster chargeBill = new HIS.Model.MZ_CostMaster( );
                        //chargeBill = BindEntity<MZ_CostMaster>.CreateInstanceDAL( oleDb ).GetModel( BudgetaryChargeInfos[chargeCount].ChargeID );
                        chargeBill = (MZ_CostMaster)MSAccessDb.GetModel( "MZ_COSTMASTER" , Tables.mz_costmaster.COSTMASTERID + "=" + BudgetaryChargeInfos[chargeCount].ChargeID , typeof( MZ_CostMaster ) );
                        chargeBill.Self_Fee = BudgetaryChargeInfos[chargeCount].SelfFee;
                        chargeBill.Village_Fee = BudgetaryChargeInfos[chargeCount].VillageFee;
                        chargeBill.Favor_Fee = BudgetaryChargeInfos[chargeCount].FavorFee;
                        chargeBill.Pos_Fee = BudgetaryChargeInfos[chargeCount].PosFee;
                        chargeBill.Money_Fee = BudgetaryChargeInfos[chargeCount].CashFee;
                        chargeBill.Self_Tally = BudgetaryChargeInfos[chargeCount].SelfTally;
                        chargeBill.Ticket_Flag = 0;
                        chargeBill.CostDate = DateTime.Now;
                        chargeBill.Record_Flag = 0;
                        string perfCode = "";
                        chargeBill.TicketNum = InvoiceManager.GetBillNumber( OPDBillKind.门诊收费发票 , OperatorId , false , out perfCode );
                        chargeBill.TicketCode = perfCode;//BudgetaryChargeInfos[chargeCount].InvoiceNO;

                        BudgetaryChargeInfos[chargeCount].InvoiceSerialNO = Convert.ToInt32( chargeBill.TicketNum );
                        BudgetaryChargeInfos[chargeCount].InvoiceNO = chargeBill.TicketNum;
                        BudgetaryChargeInfos[chargeCount].PerfChar = perfCode;
                        BudgetaryChargeInfos[chargeCount].ChargeDate = chargeBill.CostDate;

                        MSAccessDb.UpdateRecord( chargeBill );

                        //更新处方表收费标识
                        //List<MZ_PresMaster> lstPresMaster = BindEntity<MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetListArray( HIS.BLL.Tables.mz_presmaster.COSTMASTERID + " = " + BudgetaryChargeInfos[chargeCount].ChargeID );
                        List<MZ_PresMaster> lstPresMaster = MSAccessDb.GetListArray<MZ_PresMaster>(  "MZ_PRESMASTER", Tables.mz_presmaster.COSTMASTERID + " = " + BudgetaryChargeInfos[chargeCount].ChargeID );
                        if ( lstPresMaster.Count == 0 )
                        {
                            throw new Exception( "没有找到要结算的处方，请确认是否已被人收费" );
                        }
                        foreach ( MZ_PresMaster mz_presmaster in lstPresMaster )
                        {
                            if ( mz_presmaster.Charge_Flag == 0 )
                            {
                                mz_presmaster.Charge_Flag = 1;
                                mz_presmaster.TicketCode = perfCode;
                                mz_presmaster.TicketNum = chargeBill.TicketNum;
                                mz_presmaster.ChargeCode = OperatorId.ToString( );
                                //BindEntity<MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( mz_presmaster );
                                MSAccessDb.UpdateRecord( mz_presmaster );
                            }
                            else
                            {
                                throw new Exception( "该处方已被其他收费员收费！" );
                            }
                        }
                    }
                    else
                    {
                        throw new Exception( "没有找到结算号的记录！" );
                    }
                }
                MSAccessDb.CommitTrans( );
            }
            catch ( Exception err )
            {
                MSAccessDb.RollbackTrans( );
                throw new Exception( "正式结算发生错误！" );
            }
            //发票对象
            try
            {
                ChargeInvoicies = new Invoice[BudgetaryChargeInfos.Length];
                for ( int i = 0 ; i < BudgetaryChargeInfos.Length ; i++ )
                {
                    ChargeInvoicies[i] = new Invoice(BudgetaryChargeInfos[i].PerfChar, BudgetaryChargeInfos[i].InvoiceNO , OPDBillKind.门诊收费发票 );
                }
            }
            catch(Exception err)
            {
                
                throw new Exception( "收费成功，但生成发票对象失败！" );
            }
            return true;
        }
        /// <summary>
        /// 取消预结算
        /// </summary>
        /// <returns></returns>
        /// <remarks>取消预算后不会再做正式结算，并且删除掉预算信息</remarks>
        public override bool AbortBudget()
        {
            return true;
        }
    }
}
