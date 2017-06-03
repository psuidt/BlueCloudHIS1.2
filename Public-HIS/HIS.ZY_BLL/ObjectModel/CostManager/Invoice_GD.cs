using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.Dao;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.ZY_BLL.ObjectModel.CostManager;
using HIS.ZY_BLL.DataModel;

namespace HIS.ZY_BLL.ObjectModel.CostManager
{
    public class Invoice_GD :AbstractInvoice, IbaseDao, ICloneable
    {
        #region 自定义属性
        private string _结算方式;
        private string _拾万;
        private string _万;
        private string _仟;
        private string _佰;
        private string _拾;
        private string _元;
        private string _角;
        private string _分;

        private string _记账金额;
        private string _单位金额;
        private string _自付金额;
        private string _优惠金额;



        private string _CT;
        private string _MRI;
        private string _B超;
        private string _X光;
        private string _心脑电图;
        private string _输血费;
        private string _输养费;
        private string _自费西药;



        public string 结算方式
        {
            set { _结算方式 = value; }
            get { return _结算方式; }
        }

        public string 拾万
        {
            set { _拾万 = value; }
            get { return _拾万; }
        }
        public string 万
        {
            set { _万 = value; }
            get { return _万; }
        }
        public string 仟
        {
            set { _仟 = value; }
            get { return _仟; }
        }
        public string 佰
        {
            set { _佰 = value; }
            get { return _佰; }
        }
        public string 拾
        {
            set { _拾 = value; }
            get { return _拾; }
        }
        public string 元
        {
            set { _元 = value; }
            get { return _元; }
        }
        public string 角
        {
            set { _角 = value; }
            get { return _角; }
        }
        public string 分
        {
            set { _分 = value; }
            get { return _分; }
        }

        public string 记账金额
        {
            set { _记账金额 = value; }
            get { return _记账金额; }
        }
        public string 自付金额
        {
            set { _自付金额 = value; }
            get { return _自付金额; }
        }
        public string 单位金额
        {
            set { _单位金额 = value; }
            get { return _单位金额; }
        }
        public string 优惠金额
        {
            set { _优惠金额 = value; }
            get { return _优惠金额; }
        }

        public string CT
        {
            set { _CT = value; }
            get { return _CT; }
        }
        public string MRI
        {
            set { _MRI = value; }
            get { return _MRI; }
        }
        public string B超
        {
            set { _B超 = value; }
            get { return _B超; }
        }

        public string X光
        {
            set { _X光 = value; }
            get { return _X光; }
        }
        public string 心脑电图
        {
            set { _心脑电图 = value; }
            get { return _心脑电图; }
        }
        public string 输血费
        {
            set { _输血费 = value; }
            get { return _输血费; }
        }
        public string 输养费
        {
            set { _输养费 = value; }
            get { return _输养费; }
        }
        public string 自费西药
        {
            set { _自费西药 = value; }
            get { return _自费西药; }
        }
        #endregion

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

        #endregion

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public Invoice_GD()
        {
            _oleDb = BaseBLL.oleDb;
        }

        public Invoice_GD(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
        {
            _oleDb = _OleDb;
        }

        /// <summary>
        /// 数字转大写
        /// </summary>
        /// <param name="x">数字</param>
        /// <returns></returns>
        private string NumToChar(char x)
        {
            string chnNames = "零壹贰叁肆伍陆柒捌玖";
            string numNames = "0123456789";
            return chnNames[numNames.IndexOf(x)].ToString();
        }

        /// <summary>
        /// 得到住院发票数据
        /// </summary>
        /// <param name="CostMasterID">结算ID</param>
        /// <returns>发票实体对象</returns>
        public  Invoice_GD GetInvoiceInfo(int CostMasterID)
        {
            Invoice_GD invoice = new Invoice_GD(); ;
           
            try
            {
                GetInvoiceInfo(invoice, CostMasterID);
                //结算方式
                if (zyCM.Money_Fee != 0)
                {
                    invoice.结算方式 = "现金";
                }
                if (zyCM.Pos_Fee != 0)
                {
                    if (invoice.结算方式 != null)
                    {
                        invoice.结算方式 += "|POS";
                    }
                    else
                    {
                        invoice.结算方式 = "POS";
                    }
                }

                if (zyCM.PatType == "01")
                {
                    invoice.结算方式 += "|自费";
                }
                else if (zyCM.PatType == "02")
                {
                    invoice.结算方式 += "|农合";
                }
                else if (zyCM.PatType == "03")
                {
                    invoice.结算方式 += "|居民医保";
                }
                else if (zyCM.PatType == "04")
                {
                    invoice.结算方式 += "|职工医保";
                }
                else if (zyCM.PatType == "05")
                {
                    invoice.结算方式 += "|公费";
                }
                else if (zyCM.PatType == "06")
                {
                    invoice.结算方式 += "|其他";
                }

                if (zyCM.WorkUnit_Fee > 0)
                {
                    invoice.结算方式 += "|单位记账";
                }

                //
                char[] ch = zyCM.Total_Fee.ToString("0.00").ToCharArray();
                invoice.拾万 = ch.Length >= 9 ? NumToChar(ch[ch.Length - 9]) : "零";
                invoice.万 = ch.Length >= 8 ? NumToChar(ch[ch.Length - 8]) : "零";
                invoice.仟 = ch.Length >= 7 ? NumToChar(ch[ch.Length - 7]) : "零";
                invoice.佰 = ch.Length >= 6 ? NumToChar(ch[ch.Length - 6]) : "零";
                invoice.拾 = ch.Length >= 5 ? NumToChar(ch[ch.Length - 5]) : "零";
                invoice.元 = ch.Length >= 4 ? NumToChar(ch[ch.Length - 4]) : "零";
                invoice.角 = NumToChar(ch[ch.Length - 2]);
                invoice.分 = NumToChar(ch[ch.Length - 1]);

                invoice.记账金额 = (zyCM.Village_Fee - zyCM.WorkUnit_Fee).ToString("0.00");
                invoice.优惠金额 = zyCM.Favor_Fee.ToString("0.00");
                invoice.自付金额 = zyCM.Self_Fee.ToString("0.00");
                invoice.单位金额 = zyCM.WorkUnit_Fee.ToString("0.00");

                invoice.自费西药 = zyCM.SelfDrug_Fee.ToString("0.00");//add zenghao 091011
          

                string strWhere = "costid" + oleDb.EuqalTo() + zyCM.CostMasterID
                    + oleDb.And() + "BIGITEMCODE" + oleDb.In(OP_ZYConfigSetting.GetConfigText("007", 0));
                invoice.CT = HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).GetSum("TOTAL_FEE", strWhere), "").ToString();
                strWhere = "costid" + oleDb.EuqalTo() + zyCM.CostMasterID
                   + oleDb.And() + "BIGITEMCODE" + oleDb.In(OP_ZYConfigSetting.GetConfigText("007", 1));
                invoice.MRI = HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).GetSum("TOTAL_FEE", strWhere), "").ToString();



                strWhere = "costid" + oleDb.EuqalTo() + zyCM.CostMasterID
                   + oleDb.And() + "BIGITEMCODE" + oleDb.In(OP_ZYConfigSetting.GetConfigText("007", 2));
                invoice.B超 = HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).GetSum("TOTAL_FEE", strWhere), "").ToString();


                strWhere = "costid" + oleDb.EuqalTo() + zyCM.CostMasterID
                   + oleDb.And() + "BIGITEMCODE" + oleDb.In(OP_ZYConfigSetting.GetConfigText("007", 3));
                invoice.X光 = HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).GetSum("TOTAL_FEE", strWhere), "").ToString();


                strWhere = "costid" + oleDb.EuqalTo() + zyCM.CostMasterID
                   + oleDb.And() + "BIGITEMCODE" + oleDb.In(OP_ZYConfigSetting.GetConfigText("007", 4));
                invoice.心脑电图 = HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).GetSum("TOTAL_FEE", strWhere), "").ToString();
                strWhere = "costid" + oleDb.EuqalTo() + zyCM.CostMasterID
                   + oleDb.And() + "BIGITEMCODE" + oleDb.In(OP_ZYConfigSetting.GetConfigText("007", 5));
                invoice.输血费 = HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).GetSum("TOTAL_FEE", strWhere), "").ToString();
                strWhere = "costid" + oleDb.EuqalTo() + zyCM.CostMasterID
                   + oleDb.And() + "BIGITEMCODE" + oleDb.In(OP_ZYConfigSetting.GetConfigText("007", 6));
                invoice.输养费 = HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(BindEntity<ZY_CostOrder>.CreateInstanceDAL(oleDb).GetSum("TOTAL_FEE", strWhere), "").ToString();

                return invoice;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
