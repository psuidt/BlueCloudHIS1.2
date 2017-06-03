using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS;
using HIS.SYSTEM.Core;
using HIS.BLL;
using System.Collections;
using System.Data;
using HIS.Interface.Structs;
namespace HIS.MZ_BLL
{
    /// <summary>
    /// 门诊发票
    /// </summary>
    public class Invoice : BaseInvoice
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Invoice()
        {
        }
        /// <summary>
        /// 发票号
        /// </summary>
        /// <param name="InvoiceNo">发票号</param>
        public Invoice( string PerfChar, string InvoiceNo ,OPDBillKind kind )
        {
            
            HIS.Model.MZ_CostMaster m_mz_costmaster = new HIS.Model.MZ_CostMaster( );
            HIS.DAL.MZ_DAL mz_dal = new HIS.DAL.MZ_DAL( );
            mz_dal._OleDB = oleDb;
            try
            {
                string condiction = "TicketNum='" + InvoiceNo + "' and record_flag in (0,1)";
                //if ( PerfChar.Trim( ) != "" )
                condiction += " and TicketCode ='" + PerfChar + "'";

                if ( kind == OPDBillKind.门诊挂号发票 )
                    condiction += " and hang_flag=" + (int)OPDOperationType.门诊挂号;
                if ( kind == OPDBillKind.门诊收费发票 )
                    condiction += " and hang_flag=" + (int)OPDOperationType.门诊收费;

                m_mz_costmaster = BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL(oleDb).GetModel( condiction );
                _perfchar = PerfChar;
                _billKind = kind;
                _chargeId = m_mz_costmaster.CostMasterID;
                _invoiceNo = InvoiceNo;
                _perfChar = m_mz_costmaster.TicketCode;
                Model.MZ_CostMaster mz_costmaster = BindEntity<Model.MZ_CostMaster>.CreateInstanceDAL( oleDb ).GetModel( m_mz_costmaster.CostMasterID );
                Model.MZ_PatList mz_patlist = BindEntity<Model.MZ_PatList>.CreateInstanceDAL( oleDb ).GetModel( mz_costmaster.PatListID );
                _patientName = mz_patlist == null ? "" : mz_patlist.PatName;
                _totalPay = m_mz_costmaster.Total_Fee;
                _posPay = m_mz_costmaster.Pos_Fee;
                _favorPay = m_mz_costmaster.Favor_Fee;
                _villagePay = m_mz_costmaster.Village_Fee;
                _selfTally = m_mz_costmaster.Self_Tally;
                _chargeUser = m_mz_costmaster.ChargeName;
                _chargeUserId = m_mz_costmaster.ChargeCode;
                _chargeDate = m_mz_costmaster.CostDate;
                _record_flag = m_mz_costmaster.Record_Flag;
                _cashPay = _totalPay - _posPay - _villagePay - _favorPay - _selfTally ;//m_mz_costmaster.Money_Fee;
                //发票内容
                System.Data.DataTable tb = mz_dal.GetInvoiceDetail( mz_costmaster.CostMasterID );
                //Hashtable htInvoiceItems = new Hashtable();
                //for (int i = 0; i < tb.Rows.Count; i++)
                //{
                //    InvoiceItem item = new InvoiceItem();
                //    item.ItemName = tb.Rows[i]["Item_Name"].ToString().Trim();
                //    item.Cost = Convert.ToDecimal(tb.Rows[i]["Total_fee"]);
                //    item.Item_Name = tb.Rows[i]["ItemName"].ToString().Trim();
                //    item.Tolal_Fee = Convert.ToDecimal(tb.Rows[i]["Fee"]);

                //    if (htInvoiceItems.ContainsKey(item.ItemName))
                //    {
                //        InvoiceItem item1 = (InvoiceItem)htInvoiceItems[item.ItemName];
                //        if (tb.Rows[i]["itemtype"].ToString() == "01" || tb.Rows[i]["itemtype"].ToString() == "02" || tb.Rows[i]["itemtype"].ToString() == "03")
                //        {                            
                //            item1.Cost = item1.Cost + item.Cost;
                //            htInvoiceItems.Remove(item.ItemName);
                //        }
                //        htInvoiceItems.Add(item1.ItemName, item1);
                //    }
                //    else
                //    {
                //        htInvoiceItems.Add(item.ItemName, item);
                //    }
                //}

                _items = new InvoiceItem[tb.Rows.Count];
               // int invoiceCount = 0;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    _items[i].ItemName = tb.Rows[i]["Item_Name"].ToString().Trim();
                    _items[i].Cost = Convert.ToDecimal(tb.Rows[i]["Total_fee"]);
                    
                        _items[i].Item_Name = tb.Rows[i]["ItemName"].ToString().Trim();
                        if (_items[i].Item_Name.Trim() == "")
                        {
                            _items[i].Tolal_Fee = "";
                        }
                        else
                        {
                            _items[i].Tolal_Fee = tb.Rows[i]["Fee"].ToString();
                        }
                  
                }
                //foreach (object obj in htInvoiceItems)
                //{
                //    _items[invoiceCount].ItemName = ((InvoiceItem)((DictionaryEntry)obj).Value).ItemName;
                //    _items[invoiceCount].Cost = ((InvoiceItem)((DictionaryEntry)obj).Value).Cost;
                //    _items[invoiceCount].ItemName = ((InvoiceItem)((DictionaryEntry)obj).Value).Item_Name;
                //    _items[invoiceCount].Tolal_Fee = ((InvoiceItem)((DictionaryEntry)obj).Value).Tolal_Fee;

                //    invoiceCount++;
                //}
                //处方信息
                #region ...
                //定义统计大类容器
                Hashtable htStatItems = new Hashtable( );
                List<HIS.Model.MZ_PresMaster> lst_mz_presmaster = new List<HIS.Model.MZ_PresMaster>( );
                lst_mz_presmaster = BindEntity<Model.MZ_PresMaster>.CreateInstanceDAL( oleDb ).GetListArray( Tables.mz_presmaster.COSTMASTERID + oleDb.EuqalTo() + _chargeId );
                _prescription = new Prescription[lst_mz_presmaster.Count];
                int index = 0;
                foreach ( Model.MZ_PresMaster model_mz_presmaster in lst_mz_presmaster )
                {
                    _prescription[index] = new Prescription( );
                    _prescription[index].Charge_Flag = model_mz_presmaster.Charge_Flag;
                    _prescription[index].ChargeCode = model_mz_presmaster.ChargeCode;
                    _prescription[index].ChargeID = model_mz_presmaster.CostMasterID;
                    _prescription[index].Drug_Flag = model_mz_presmaster.Drug_Flag;
                    _prescription[index].ExecDeptCode = model_mz_presmaster.ExecDeptCode;
                    _prescription[index].ExecDocCode = model_mz_presmaster.ExecDocCode;
                    _prescription[index].OldPresID = model_mz_presmaster.OldID;
                    _prescription[index].PresCostCode = model_mz_presmaster.PresCostCode;
                    _prescription[index].PrescriptionID = model_mz_presmaster.PresMasterID;
                    _prescription[index].PrescType = model_mz_presmaster.PresType;
                    _prescription[index].PresDeptCode = model_mz_presmaster.PresDocCode;
                    _prescription[index].PresDocCode = model_mz_presmaster.PresDocCode;
                    _prescription[index].Record_Flag = model_mz_presmaster.Record_Flag;
                    _prescription[index].TicketCode = model_mz_presmaster.TicketCode;
                    _prescription[index].TicketNum = model_mz_presmaster.TicketNum;
                    _prescription[index].Total_Fee = model_mz_presmaster.Total_Fee;
                    _prescription[index].Drug_Flag = model_mz_presmaster.Drug_Flag;
                    _prescription[index].DocPresId = model_mz_presmaster.DocPresId;
                    List<HIS.Model.MZ_PresOrder> orders = BindEntity<Model.MZ_PresOrder>.CreateInstanceDAL( oleDb ).GetListArray( "PresmasterID=" + _prescription[index].PrescriptionID );
                    PrescriptionDetail[] details = new PrescriptionDetail[orders.Count];
                    for ( int j = 0 ; j < orders.Count ; j++ )
                    {
                        #region 明细
                        details[j] = new PrescriptionDetail();
                        details[j].Amount = orders[j].Amount;
                        details[j].BigitemCode = orders[j].BigItemCode;
                        details[j].Buy_price = orders[j].Buy_Price;
                        details[j].ComplexId = orders[j].CaseID;
                        details[j].DetailId = orders[j].PresOrderID;
                        details[j].ItemId = orders[j].ItemID;
                        details[j].Itemname = orders[j].ItemName;
                        details[j].ItemType = orders[j].ItemType;
                        details[j].Order_Flag = orders[j].Order_Flag;
                        details[j].PassId = orders[j].PassID;
                        details[j].PresAmount = orders[j].PresAmount;
                        details[j].PresctionId = orders[j].PresMasterID;
                        details[j].RelationNum = orders[j].RelationNum;
                        details[j].Sell_price = orders[j].Sell_Price;
                        details[j].Standard = orders[j].Standard;
                        details[j].Tolal_Fee = orders[j].Tolal_Fee;
                        details[j].Unit = orders[j].Unit;
                        details[j].Comp_Money = orders[j].Comp_Money;
                        #endregion

                        #region 生成大项目列表
                        if ( htStatItems.ContainsKey( orders[j].BigItemCode.Trim() ) )
                        {
                            InvoiceItem item = (InvoiceItem)htStatItems[orders[j].BigItemCode.Trim( )];
                            item.Cost += orders[j].Tolal_Fee;
                            htStatItems.Remove( orders[j].BigItemCode.Trim( ) );
                            htStatItems.Add( item.ItemCode , item );
                        }
                        else
                        {
                            InvoiceItem item = new InvoiceItem( );
                            item.ItemCode = orders[j].BigItemCode.Trim();
                            //item.ItemName = GetStatItemNameByStatCode( item.ItemCode );
                            item.ItemName = BaseDataController.GetName( BaseDataCatalog.基本分类科目, item.ItemCode );
                            item.Cost = orders[j].Tolal_Fee;
                            htStatItems.Add( item.ItemCode , item );
                        }
                        #endregion
                    }
                    _prescription[index].PresDetails = details;
                    index++;
                }
                #endregion
                _statitems = new InvoiceItem[htStatItems.Count];
                index = 0;
                foreach ( object obj in htStatItems.Values )
                {
                    _statitems[index] = (InvoiceItem)obj;
                    index++;
                }
                paytype = "";
                if ( _cashPay > 0 )
                {
                    paytype += " 现金 ";
                }
                if ( _posPay > 0 )
                {
                    paytype += " POS ";
                }
                if ( _villagePay > 0 )
                {
                    paytype += " 农合医保记账 ";
                }
                if ( _selfTally > 0 )
                {
                    paytype += " 单位记账 ";
                }
            }
            catch(Exception err)
            {
                ErrorWriter.WriteLog( err.Message );
                throw new Exception( "读取发票信息错误！" );
            }
        }
        /// <summary>
        /// 结算ID
        /// </summary>
        private int _chargeId;
        /// <summary>
        /// 发票号
        /// </summary>
        private string _invoiceNo;
        /// <summary>
        /// 发票前缀字母
        /// </summary>
        private string _perfChar;
        /// <summary>
        /// 发票流水号
        /// </summary>
        private string _invoiceSerailNo;
        /// <summary>
        /// 病人姓名
        /// </summary>
        private string _patientName;
        /// <summary>
        /// 总金额
        /// </summary>
        private decimal _totalPay;
        /// <summary>
        /// POS金额
        /// </summary>
        private decimal _posPay;
        /// <summary>
        /// 现金金额
        /// </summary>
        private decimal _cashPay;
        /// <summary>
        /// 优惠金额
        /// </summary>
        private decimal _favorPay;
        /// <summary>
        /// 记账（农合、医保金额）
        /// </summary>
        private decimal _villagePay;
        /// <summary>
        /// 个人记账（属于个人支付的一部分）
        /// </summary>
        private decimal _selfTally;
        /// <summary>
        /// 发票项目
        /// </summary>
        private InvoiceItem[] _items;
        /// <summary>
        /// 
        /// </summary>
        private string _chargeUser;
        /// <summary>
        /// 
        /// </summary>
        private string _chargeUserId;
        /// <summary>
        /// 
        /// </summary>
        private DateTime _chargeDate;
        /// <summary>
        /// 对应的处方
        /// </summary>
        private Prescription[] _prescription;
        /// <summary>
        /// 支付方式
        /// </summary>
        private string paytype;
        /// <summary>
        /// 统计分类
        /// </summary>
        private InvoiceItem[] _statitems;
        /// <summary>
        /// 记录状态
        /// </summary>
        private int _record_flag;
        /// <summary>
        /// 发票号前缀字符
        /// </summary>
        private string _perfchar;
        /// <summary>
        /// 发票类型
        /// </summary>
        private OPDBillKind _billKind;
        /// <summary>
        /// 发票类型
        /// </summary>
        public OPDBillKind BillKind
        {
            get
            {
                return _billKind;
            }
            set
            {
                _billKind = value;
            }
        }
        
        /// <summary>
        /// 记录状态
        /// </summary>
        public int RecordFlag
        {
            get
            {
                return _record_flag;
            }
            set
            {
                _record_flag = value;
            }
        }
        /// <summary>
        /// 结算号
        /// </summary>
        public int ChargeID
        {
            get
            {
                return _chargeId;
            }
            set
            {
                _chargeId = value;
            }
        }
        /// <summary>
        /// 发票号
        /// </summary>
        public string InvoiceNo
        {
            get
            {
                return _invoiceNo;
            }
            set
            {
                _invoiceNo = value;
            }
        }
        /// <summary>
        /// 发票流水号
        /// </summary>
        public string InvoiceSerailNo
        {
            get
            {
                return _invoiceSerailNo;
            }
            set
            {
                _invoiceSerailNo = value;
            }
        }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName
        {
            get
            {
                return _patientName;
            }
            set
            {
                _patientName = value;
            }
        }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalPay
        {
            get
            {
                return _totalPay;
            }
            set
            {
                _totalPay = value;
            }
        }
        /// <summary>
        /// POS金额
        /// </summary>
        public decimal PosPay
        {
            get
            {
                return _posPay;
            }
            set
            {
                _posPay = value;
            }
        }
        /// <summary>
        /// 现金金额
        /// </summary>
        public decimal CashPay
        {
            get
            {
                return _cashPay;
            }
            set
            {
                _cashPay = value;
            }
        }
        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal FavorPay
        {
            get
            {
                return _favorPay;
            }
            set
            {
                _favorPay = value;
            }
        }
        /// <summary>
        /// 记账（农合、医保金额）
        /// </summary>
        public decimal VillagePay
        {
            get
            {
                return _villagePay;
            }
            set
            {
                _villagePay = value;
            }
        }
        /// <summary>
        /// 个人记账（属于个人自付的一部分）
        /// </summary>
        public decimal SelfTally
        {
            get
            {
                return _selfTally;
            }
            set
            {
                _selfTally = value;
            }
        }
        /// <summary>
        /// 发票项目
        /// </summary>
        public InvoiceItem[] Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }
        /// <summary>
        /// 收费员
        /// </summary>
        public string ChargeUser
        {
            get
            {
                return _chargeUser;
            }
            set
            {
                _chargeUser = value;
            }
        }
        /// <summary>
        /// 收费员ID
        /// </summary>
        public string ChargeUserId
        {
            get
            {
                return _chargeUserId;
            }
            set
            {
                _chargeUserId = value;
            }
        }
        /// <summary>
        /// 收费日期
        /// </summary>
        public DateTime ChargeDate
        {
            get
            {
                return _chargeDate;
            }
            set
            {
                _chargeDate = value;
            }
        }
        /// <summary>
        /// 处方
        /// </summary>
        public Prescription[] Prescription
        {
            get
            {
                return _prescription;
            }
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayType
        {
            get
            {
                return paytype;
            }
            set
            {
                paytype = value;
            }
        }
        /// <summary>
        /// 统计大类
        /// </summary>
        public InvoiceItem[] StatItems
        {
            get
            {
                return _statitems;
            }
            set
            {
                _statitems = value;
            }
        }
        /// <summary>
        /// 发票前缀
        /// </summary>
        public string PerfChar
        {
            get
            {
                return _perfChar;
            }
            set
            {
                _perfChar = value;
            }
        }
        ///// <summary>
        ///// 根据统计代码获取统计项目名
        ///// </summary>
        ///// <param name="statitem_code"></param>
        ///// <returns></returns>
        //private string GetStatItemNameByStatCode(string statitem_code)
        //{
        //    DataRow[] drs = PublicDataReader.StatItemList.Select( "STAT_CODE='" + statitem_code + "'" );
        //    if ( drs.Length == 0 )
        //        return "";
        //    else
        //        return drs[0]["STAT_NAME"].ToString( ).Trim( );
        //}
    }
}
