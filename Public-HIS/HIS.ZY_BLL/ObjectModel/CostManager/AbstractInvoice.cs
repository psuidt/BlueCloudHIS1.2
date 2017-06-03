using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.ZY_BLL.DataModel;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL.Dao;
using HIS.ZY_BLL.Dao.Invoice;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS.ZY_BLL.ObjectModel.CostManager
{
    public class AbstractInvoice : IbaseDao
    {
        public ZY_CostMaster zyCM = null;
        public ZY_PatList zyPL = null;

        #region 属性
        private string _发票流水号;
        private string _发票号;
        private string _住院号;
        private string _科室;

        private string _年;
        private string _月;
        private string _日;

        private string _床位号;
        private string _病人姓名;
        private DateTime _入院日期;
        private DateTime _出院日期;

        private int _住院天数;
        private string _总费用;
        private string _预交金;
        private string _补收;
        private string _应退;
        private string _欠费;
        private string _收费员;
        private DataTable _发票项目费用;


        public string 发票流水号
        {
            get
            {
                return _发票流水号;
            }
            set
            {
                _发票流水号 = value;
            }
        }
        public string 发票号
        {
            get
            {
                return _发票号;
            }
            set
            {
                _发票号 = value;
            }
        }
        public string 住院号
        {
            get
            {
                return _住院号;
            }
            set
            {
                _住院号 = value;
            }
        }
        public string 科室
        {
            get
            {
                return _科室;
            }
            set
            {
                _科室 = value;
            }
        }
        public string 年
        {
            set { _年 = value; }
            get { return _年; }
        }
        public string 月
        {
            set { _月 = value; }
            get { return _月; }
        }
        public string 日
        {
            set { _日 = value; }
            get { return _日; }
        }
        public string 床位号
        {
            get
            {
                return _床位号;
            }
            set
            {
                _床位号 = value;
            }
        }
        public string 病人姓名
        {
            get
            {
                return _病人姓名;
            }
            set
            {
                _病人姓名 = value;
            }
        }
        public DateTime 入院日期
        {
            get
            {
                return _入院日期;
            }
            set
            {
                _入院日期 = value;
            }
        }
        public DateTime 出院日期
        {
            get
            {
                return _出院日期;
            }
            set
            {
                _出院日期 = value;
            }
        }
        public int 住院天数
        {
            get
            {
                return _住院天数;
            }
            set
            {
                _住院天数 = value;
            }
        }
        public string 总费用
        {
            get
            {
                return _总费用;
            }
            set
            {
                _总费用 = value;
            }
        }
        public string 预交金
        {
            get
            {
                return _预交金;
            }
            set
            {
                _预交金 = value;
            }
        }
        public string 补收
        {
            get
            {
                return _补收;
            }
            set
            {
                _补收 = value;
            }
        }
        public string 应退
        {
            get
            {
                return _应退;
            }
            set
            {
                _应退 = value;
            }
        }
        public string 欠费
        {
            get
            {
                return _欠费;
            }
            set
            {
                _欠费 = value;
            }
        }
        public string 收费员
        {
            get
            {
                return _收费员;
            }
            set
            {
                _收费员 = value;
            }
        }
        public DataTable 发票项目费用
        {
            get
            {
                return _发票项目费用;
            }
            set
            {
                _发票项目费用 = value;
            }
        }
        #endregion

        /// <summary>
        /// 根据结算ID得到发票内容
        /// </summary>
        /// <param name="invoice">发票内容</param>
        /// <param name="CostMasterID">结算ID</param>
        protected void GetInvoiceInfo(AbstractInvoice invoice, int CostMasterID)
        {
            

            zyCM = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetModel(CostMasterID);
            zyPL = BindEntity<ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(zyCM.PatListID);

            invoice.病人姓名 = zyPL.patientInfo.PatName;
            invoice.发票号 = zyCM.TicketCode;
            invoice.住院号 = zyPL.CureNo;
            invoice.科室 = zyPL.CurrDeptCode.Trim() == "" ? BaseNameFactory.GetName(baseNameType.科室名称, zyPL.CureDeptCode) : BaseNameFactory.GetName(baseNameType.科室名称, zyPL.CurrDeptCode);// HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(zyPL.CureDeptCode);
            invoice.床位号 = zyPL.BedCode;

            invoice.入院日期 = zyPL.CureDate;
            invoice.出院日期 = zyPL.OutDate;
            invoice.住院天数 = zyPL.ReaLiveNum;

            DateTime PrintDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            invoice.年 = PrintDate.Date.Year.ToString();
            invoice.月 = PrintDate.Date.Month.ToString();
            invoice.日 = PrintDate.Date.Day.ToString();


            if (zyCM.Ticket_Flag == 1)
            {
                invoice.总费用 = zyCM.Total_Fee.ToString("0.00");
            }
            else if (zyCM.Ticket_Flag == 2)
            {
                invoice.总费用 = zyCM.Self_Fee.ToString("0.00");
            }
            else
            {
                invoice.总费用 = zyCM.Total_Fee.ToString("0.00");
            }

            invoice.预交金 = zyCM.Deptosit_Fee.ToString();
            if (zyCM.Ntype == 1)
            {
                invoice.补收 = "0";
                invoice.应退 = "0";
                invoice.欠费 = "0";
                //zyT.出院日期 = null;
            }
            else if (zyCM.Ntype == 2)
            {
                if (zyCM.Reality_Fee <= 0)
                {
                    invoice.应退 = Convert.ToString(0 - zyCM.Reality_Fee);
                    invoice.补收 = "0";
                }
                else
                {
                    invoice.补收 = zyCM.Reality_Fee.ToString();
                    invoice.应退 = "0";
                }
                invoice.欠费 = "0";
            }
            else if (zyCM.Ntype == 3)
            {
                invoice.补收 = zyCM.Reality_Fee.ToString();
                invoice.应退 = "0";
                invoice.欠费 = Convert.ToString(zyCM.Self_Fee - zyCM.Deptosit_Fee - zyCM.Reality_Fee);
            }
            invoice.收费员 = BaseNameFactory.GetName(baseNameType.用户名称, zyCM.ChargeCode);//HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(zyCM.ChargeCode);
            invoice.发票流水号 = zyCM.TicketNum;


            Iinvoice itD = DaoFactory.GetObject<Iinvoice>(typeof(InvoiceDao));
            itD.oleDb = oleDb;
            invoice.发票项目费用 = itD.GetInvoiceInfo(CostMasterID);

        }

        /// <summary>
        /// 得到发票数据
        /// </summary>
        /// <param name="Bdate">结算开始时间</param>
        /// <param name="Edate">结算结束时间</param>
        /// <returns></returns>
        public DataTable GetTicketData(DateTime Bdate, DateTime Edate)
        {
            try
            {
                DataTable dt = null;

                //List<ZY_CostMaster_Son> zyCostMSL = new List<ZY_CostMaster_Son>();
                List<ZY_CostMaster> zyCostML = null;

                string str = "date(COSTDATE) >='" + Bdate.Date + "' and date(COSTDATE) <='" + Edate.Date + "' order by COSTDATE";
                zyCostML = BindEntity<ZY_CostMaster>.CreateInstanceDAL(oleDb).GetListArray(str);

                if (zyCostML != null)
                {
                    DataTable dtPatType = BindEntity<object>.CreateInstanceDAL(oleDb, "BASE_PATIENTTYPE").GetList("");


                    for (int i = 0; i < zyCostML.Count; i++)
                    {

                        zyCostML[i].LoadData();
                        DataRow[] drs = dtPatType.Select("code = '" + zyCostML[i].PatType + "'");
                        if (drs.Length != 0)
                            zyCostML[i].PatType = drs[0]["name"].ToString();
                    }

                    ZY_CostMaster zyCostMS = new ZY_CostMaster(oleDb);

                    zyCostMS.TicketCode = "合计";
                    zyCostMS.Total_Fee = zyCostML.Sum(x => x.Total_Fee);
                    zyCostMS.Deptosit_Fee = zyCostML.Sum(x => x.Deptosit_Fee);
                    zyCostMS.Self_Fee = zyCostML.Sum(x => x.Self_Fee);
                    zyCostMS.Village_Fee = zyCostML.Sum(x => x.Village_Fee);
                    zyCostMS.Favor_Fee = zyCostML.Sum(x => x.Favor_Fee);
                    zyCostMS.Money_Fee = zyCostML.Sum(x => x.Money_Fee);
                    zyCostMS.Pos_Fee = zyCostML.Sum(x => x.Pos_Fee);
                    zyCostML.Add(zyCostMS);

                    dt = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(zyCostML);
                }
                return dt;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        #region IbaseDao 成员
        private HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _oleDb;
        public HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb
        {
            get
            {
                return _oleDb;
            }
            set
            {
                _oleDb = value;
            }
        }

        public AbstractInvoice()
        {
            _oleDb = BaseBLL.oleDb;
        }

        public AbstractInvoice(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
        {
            _oleDb = _OleDb;
        }
        #endregion
    }
}
