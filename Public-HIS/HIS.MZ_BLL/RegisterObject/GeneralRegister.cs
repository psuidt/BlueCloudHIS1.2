using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Collections;
using HIS.BLL;
using HIS.MZ_BLL.Exceptions;
namespace HIS.MZ_BLL.RegisterObject
{
    /// <summary>
    /// 普通挂号对象
    /// </summary>
    public class GeneralRegister: BaseRegister
    {
        public GeneralRegister()
        {
        }
        /// <summary>
        /// 挂号的预处理
        /// </summary>
        /// <param name="Patient"></param>
        /// <returns></returns>
        public override ChargeInfo Budget( RegPatient Patient )
        {
            //保存就诊记录
            Model.MZ_PatList mz_patlist = SavePatList( Patient );
            Patient.PatListID = mz_patlist.PatListID;

            //查找所需费用项目
            List<Model.MZ_REG_ITEM_FEE> listRegFee = BindEntity<Model.MZ_REG_ITEM_FEE>.CreateInstanceDAL( oleDb ).GetListArray( BLL.Tables.mz_reg_item_fee.TYPE_CODE + "='" + Patient.RegTypeCode.Trim() + "'" );
            //写入处方表
            Model.MZ_PresMaster mz_presmaster = SavePresMaster( Patient );

            Hashtable htCostOrder = new Hashtable();            
            Model.MZ_CostOrder mz_costorder = null;
            foreach ( Model.MZ_REG_ITEM_FEE mz_reg_item_fee in listRegFee )
            {
                Model.BASE_SERVICE_ITEMS base_service_item = BindEntity<Model.BASE_SERVICE_ITEMS>.CreateInstanceDAL( oleDb ).GetModel( mz_reg_item_fee.ITEM_ID );
                if ( base_service_item == null )
                    throw new OperatorException( "找不到项目编号为"+mz_reg_item_fee.ITEM_ID.ToString() + "的项目" );
                //保存明细
                Model.MZ_PresOrder mz_presorder = SavePresOrder( Patient, mz_presmaster, base_service_item );

                mz_presmaster.Total_Fee += mz_presorder.Tolal_Fee;
                if ( htCostOrder.Contains( base_service_item.STATITEM_CODE ) )
                {
                    ( (Model.MZ_CostOrder)htCostOrder[base_service_item.STATITEM_CODE] ).Total_Fee += mz_presorder.Tolal_Fee;
                }
                else
                {
                    mz_costorder = new HIS.Model.MZ_CostOrder();
                    mz_costorder.ItemType = base_service_item.STATITEM_CODE;
                    mz_costorder.Total_Fee = mz_presorder.Tolal_Fee;
                    htCostOrder.Add( base_service_item.STATITEM_CODE, mz_costorder );
                }
            }
            //写结算记录
            Model.MZ_CostMaster mz_costmaster = SaveCostMaster( Patient, mz_presmaster );
                                         
            InvoiceItem[] invoiceItems = new InvoiceItem[htCostOrder.Count];
            int count = 0;
            foreach ( object  item in htCostOrder )
            {
                mz_costorder = (Model.MZ_CostOrder)((DictionaryEntry)item).Value;
                mz_costorder.CostID = mz_costmaster.CostMasterID;
                BindEntity<Model.MZ_CostOrder>.CreateInstanceDAL( oleDb ).Add( mz_costorder );
                Model.BASE_STAT_ITEM base_stat_item = BindEntity<Model.BASE_STAT_ITEM>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_stat_item.CODE + "='" + mz_costorder.ItemType.Trim() + "'" );
                Model.BASE_STAT_MZFP base_stat_mzfp = BindEntity<Model.BASE_STAT_MZFP>.CreateInstanceDAL( oleDb ).GetModel( BLL.Tables.base_stat_mzfp.CODE + "='" + base_stat_item.MZFP_CODE.Trim() + "'" );

                invoiceItems[count].ItemName = base_stat_mzfp.ITEM_NAME;
                invoiceItems[count].ItemCode = base_stat_mzfp.CODE;
                invoiceItems[count].Cost = mz_costorder.Total_Fee;
                count++;
            }
            //回写处方的总金额和结算号
            BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( BLL.Tables.mz_presmaster.PRESMASTERID + "=" + mz_presmaster.PresMasterID, 
                                                                               BLL.Tables.mz_presmaster.TOTAL_FEE + "=" + mz_presmaster.Total_Fee ,
                                                                               BLL.Tables.mz_presmaster.COSTMASTERID + "=" + mz_costmaster.CostMasterID);

            ChargeInfo regInfo = new ChargeInfo();
            regInfo.ChargeID = mz_costmaster.CostMasterID;
            regInfo.ChargeDate = mz_costmaster.CostDate;
            regInfo.TotalFee = mz_costmaster.Total_Fee;
            regInfo.PrescriptionID = mz_presmaster.PresMasterID;
            regInfo.Items = invoiceItems;

            return regInfo;
        }
        /// <summary>
        /// 挂号正式结算
        /// </summary>
        /// <param name="Patient"></param>
        /// <param name="budgetInfo"></param>
        /// <returns></returns>
        public override bool Register( RegPatient Patient, ChargeInfo budgetInfo )
        {
            try
            {

                //更新病人门诊号
                BindEntity<Model.MZ_PatList>.CreateInstanceDAL( oleDb ).Update( Tables.mz_patlist.PATLISTID + "=" + Patient.PatListID ,
                                                                                Tables.mz_patlist.VISITNO + "='" + Patient.VisitNo + "'" );
                OPDBillKind invoiceType = OPDBillKind.门诊挂号发票;
                if ( Convert.ToInt32( OPDParamter.Parameters["012"] ) == 1 )
                    invoiceType = OPDBillKind.门诊收费发票;

                string perfChar = "";
                string invoiceNo = InvoiceManager.GetBillNumber( invoiceType , OperatorId , false ,out perfChar);

                Model.MZ_PresMaster mz_presmaster = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( budgetInfo.PrescriptionID );
                mz_presmaster.Record_Flag = 0; //改为正常状态
                mz_presmaster.Charge_Flag = 1; //置为收费状态
                mz_presmaster.TicketNum = invoiceNo;
                mz_presmaster.TicketCode = perfChar;//前缀
                mz_presmaster.ChargeCode = OperatorId.ToString( );
                BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( mz_presmaster );

                Model.MZ_CostMaster mz_costmaster = BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).GetModel( budgetInfo.ChargeID );
                mz_costmaster.Record_Flag = 0;
                mz_costmaster.ChargeCode = OperatorId.ToString( );
                mz_costmaster.ChargeName = OperatorName;
                mz_costmaster.TicketNum = invoiceNo;
                mz_costmaster.TicketCode = perfChar;//发票前缀
                mz_costmaster.Favor_Fee = budgetInfo.FavorFee;
                mz_costmaster.Money_Fee = budgetInfo.CashFee;
                mz_costmaster.Pos_Fee = budgetInfo.PosFee;
                mz_costmaster.Self_Fee = budgetInfo.SelfFee;
                mz_costmaster.Village_Fee = budgetInfo.VillageFee;
                BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).Update( mz_costmaster );

                return true;
            }
            catch ( OperatorException operr )
            {
                throw operr;
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 取消挂号
        /// </summary>
        /// <param name="RegInvoiceNo">挂号发票号</param>
        /// <returns></returns>
        public override bool CancelRegister( string RegInvoiceNo,string PerfChar )
        {
            try
            {
                //取得原记录
                string strWhere1_1 = Tables.mz_costmaster.TICKETCODE + oleDb.EuqalTo( ) + "'" + PerfChar + "'" + oleDb.And() + Tables.mz_costmaster.TICKETNUM + oleDb.EuqalTo( ) + "'" + RegInvoiceNo + "' " + oleDb.And( ) + Tables.mz_costmaster.RECORD_FLAG + oleDb.EuqalTo( ) + "0";
                Model.MZ_CostMaster mz_costmaster = BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).GetModel( strWhere1_1 );
                string strWhere1_2 = Tables.mz_costorder.COSTID + oleDb.EuqalTo( ) + mz_costmaster.CostMasterID;
                List<Model.MZ_CostOrder> list_mz_costorder = BindEntity<Model.MZ_CostOrder>.CreateInstanceDAL( oleDb ).GetListArray( strWhere1_2 );

                string strWhere2_1 = Tables.mz_presmaster.COSTMASTERID + oleDb.EuqalTo( ) + mz_costmaster.CostMasterID;
                Model.MZ_PresMaster mz_presmaster = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetModel( strWhere2_1 );
                string strWhere2_2 = Tables.mz_presorder.PRESMASTERID + oleDb.EuqalTo( ) + mz_presmaster.PresMasterID;
                List<Model.MZ_PresOrder> list_mz_presorder = BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetListArray( strWhere2_2 );

                //挂号处方头退费
                BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( strWhere2_1 , Tables.mz_presmaster.RECORD_FLAG + oleDb.EuqalTo( ) + "1" );
                //加入冲正的处方头
                mz_presmaster.Record_Flag = 2;
                mz_presmaster.Total_Fee = mz_presmaster.Total_Fee * -1;
                mz_presmaster.PresDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                mz_presmaster.ChargeCode = OperatorId.ToString( );
                mz_presmaster.OldID = mz_presmaster.PresMasterID;
                BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Add( mz_presmaster );
                //加入明细
                foreach ( Model.MZ_PresOrder mz_presorder in list_mz_presorder )
                {
                    mz_presorder.PresMasterID = mz_presmaster.PresMasterID;
                    mz_presorder.Tolal_Fee = mz_presorder.Tolal_Fee * -1;
                    mz_presorder.Amount = mz_presorder.Amount * -1;
                    BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).Add( mz_presorder );
                }
                //原记录置为退费状态
                BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).Update( strWhere1_1 , Tables.mz_costmaster.RECORD_FLAG + oleDb.EuqalTo( ) + "1" );
                //加入冲正记录
                mz_costmaster.Record_Flag = 2;
                mz_costmaster.Total_Fee = mz_costmaster.Total_Fee * -1;
                mz_costmaster.Favor_Fee = mz_costmaster.Favor_Fee * -1;
                mz_costmaster.Money_Fee = mz_costmaster.Money_Fee * -1;
                mz_costmaster.Pos_Fee = mz_costmaster.Pos_Fee * -1;
                mz_costmaster.Self_Fee = mz_costmaster.Self_Fee * -1;
                mz_costmaster.Village_Fee = mz_costmaster.Village_Fee * -1;
                mz_costmaster.AccountID = 0;

                mz_costmaster.PresMasterID = mz_presmaster.PresMasterID;
                mz_costmaster.OldID = mz_costmaster.CostMasterID;
                mz_costmaster.ChargeCode = OperatorId.ToString( );
                mz_costmaster.ChargeName = OperatorName;
                BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).Add( mz_costmaster );
                //明细
                foreach ( Model.MZ_CostOrder mz_costorder in list_mz_costorder )
                {
                    mz_costorder.CostID = mz_costmaster.CostMasterID;
                    mz_costorder.Total_Fee = mz_costorder.Total_Fee * -1;
                    BindEntity<Model.MZ_CostOrder>.CreateInstanceDAL( oleDb ).Add( mz_costorder );
                }
                //回写处方的结算号
                BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Update( Tables.mz_presmaster.PRESMASTERID + oleDb.EuqalTo( ) + mz_presmaster.PresMasterID ,
                                                                              Tables.mz_presmaster.COSTMASTERID + oleDb.EuqalTo( ) + mz_costmaster.CostMasterID );
                return true;
            }
            catch ( OperatorException operr )
            {
                throw operr;
            }
            catch ( Exception err )
            {
                throw err;
            }
        }


        /// <summary>
        /// 保存结算头表
        /// </summary>
        /// <param name="Patient"></param>
        /// <param name="mz_presmaster"></param>
        /// <returns></returns>
        private Model.MZ_CostMaster SaveCostMaster( RegPatient Patient, Model.MZ_PresMaster mz_presmaster )
        {
            Model.MZ_CostMaster mz_costmaster = new HIS.Model.MZ_CostMaster();
            mz_costmaster.ChargeCode = OperatorId.ToString();
            mz_costmaster.ChargeName = OperatorName;
            mz_costmaster.CostDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            mz_costmaster.Hang_Flag = (int)OPDOperationType.门诊挂号;
            mz_costmaster.PatID = Patient.PatID;
            mz_costmaster.PatListID = Patient.PatListID;
            mz_costmaster.PresMasterID = mz_presmaster.PresMasterID;
            mz_costmaster.Record_Flag = 9;
            mz_costmaster.Total_Fee = mz_presmaster.Total_Fee;
            BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).Add( mz_costmaster );
            return mz_costmaster;
        }
        /// <summary>
        /// 保存处方明细
        /// </summary>
        /// <param name="Patient"></param>
        /// <param name="mz_presmaster"></param>
        /// <param name="base_service_item"></param>
        /// <returns></returns>
        private static Model.MZ_PresOrder SavePresOrder( RegPatient Patient, Model.MZ_PresMaster mz_presmaster, Model.BASE_SERVICE_ITEMS base_service_item )
        {
            Model.MZ_PresOrder mz_presorder = new HIS.Model.MZ_PresOrder();
            mz_presorder.Amount = 1;
            mz_presorder.BigItemCode = base_service_item.STATITEM_CODE;
            mz_presorder.Buy_Price = base_service_item.PRICE;
            mz_presorder.ItemID = base_service_item.ITEM_ID;
            mz_presorder.ItemName = base_service_item.ITEM_NAME;
            mz_presorder.ItemType = "00";
            mz_presorder.PatID = Patient.PatID;
            mz_presorder.PatListID = Patient.PatListID;
            mz_presorder.PresAmount = 1;
            mz_presorder.PresMasterID = mz_presmaster.PresMasterID;
            mz_presorder.RelationNum = 1;
            mz_presorder.Sell_Price = base_service_item.PRICE;
            mz_presorder.Unit = base_service_item.ITEM_UNIT;
            mz_presorder.Tolal_Fee = mz_presorder.Amount * mz_presorder.PresAmount * mz_presorder.Sell_Price;
            BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).Add( mz_presorder );
            return mz_presorder;
        }
        /// <summary>
        /// 保存处方头表
        /// </summary>
        /// <param name="Patient"></param>
        /// <returns></returns>
        private Model.MZ_PresMaster SavePresMaster( RegPatient Patient )
        {
            Model.MZ_PresMaster mz_presmaster = new HIS.Model.MZ_PresMaster();
            mz_presmaster.Charge_Flag = 0;
            mz_presmaster.ExecDeptCode = Patient.RegDeptCode;
            mz_presmaster.ExecDocCode = Patient.RegDoctorCode;
            mz_presmaster.Hand_Flag = (int)OPDOperationType.门诊挂号;
            mz_presmaster.PatID = Patient.PatID;
            mz_presmaster.PatListID = Patient.PatListID;
            mz_presmaster.PresAmount = 1;
            mz_presmaster.PresCostCode = OperatorId.ToString();
            mz_presmaster.PresDate = Patient.RegDate;
            mz_presmaster.PresDeptCode = Patient.RegDeptCode;
            mz_presmaster.PresDocCode = Patient.RegDoctorCode;
            mz_presmaster.PresType = "-1";
            mz_presmaster.Record_Flag = 9; //预算状态为9
            mz_presmaster.PresDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).Add( mz_presmaster );
            return mz_presmaster;
        }
        /// <summary>
        /// 保存病人就诊登记表
        /// </summary>
        /// <param name="Patient"></param>
        /// <returns></returns>
        private static Model.MZ_PatList SavePatList( RegPatient Patient )
        {
            if (Patient.PatID == 0)
            {
                Model.PatientInfo patinfo = new HIS.Model.PatientInfo();
                patinfo.PatName = Patient.PatientName;
                patinfo.PatSex = Patient.Sex;
                patinfo.PatBriDate = Patient.BornDate;
                patinfo.ACCOUNTTYPE = Patient.PatType.Name;
                patinfo.PatGroup = Patient.Folk;
                patinfo.PYM = Patient.PYM;
                patinfo.WBM = Patient.WBM;
                patinfo.LinkAddress = Patient.Address;
                patinfo.LinkTel = Patient.Tel;
                patinfo.PatAddress = Patient.Address;
                patinfo.PatTEL = Patient.Tel;
                patinfo.ALLERGIC = Patient.Allergic;
                BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).Add(patinfo);
                Patient.PatID = patinfo.PatID;
            }

            Model.MZ_PatList mz_patlist = new HIS.Model.MZ_PatList();
            mz_patlist.Age = Patient.Age;
            mz_patlist.CureDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            mz_patlist.MediType = Patient.PatType.Code;
            mz_patlist.PatID = Patient.PatID;
            mz_patlist.PatName = Patient.PatientName;
            mz_patlist.PatSex = Patient.Sex;
            mz_patlist.RegCode = Patient.RegTypeCode;
            mz_patlist.RegName = Patient.RegTypeName;
            mz_patlist.REG_DEPT_CODE = Patient.RegDeptCode; //挂号科室
            mz_patlist.REG_DEPT_NAME = Patient.RegDeptName;
            mz_patlist.REG_DOC_CODE = Patient.RegDoctorCode;//挂号医生
            mz_patlist.REG_DOC_NAME = Patient.RegDoctorName;
            mz_patlist.HpGrade = Patient.AgeUnit;
            BindEntity<Model.MZ_PatList>.CreateInstanceDAL( oleDb ).Add( mz_patlist );
            return mz_patlist;
        }
    }
}
