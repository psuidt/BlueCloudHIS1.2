using System;
using System.Collections.Generic;
using System.Linq;
using HIS.SYSTEM.Core;
using System.Text;
using System.Data;

namespace HIS.MZ_BLL
{
    public class RegisterInvoice : BaseInvoice
    {
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public RegisterInvoice()
        {
            
        }

        private string _regDeptName;
        private string _docType;
        private string _regNo;
        private decimal _regFee;
        private decimal _zcFee;
        private decimal _checkFee;
        private decimal _clFee;
        private decimal _totalFee;
        private string _chargeUserName;
        private string _patName;
       

        #region 诊病科别
        public string RegDeptName
        {
            get
            {
                return _regDeptName;
            }
            set
            {
                _regDeptName = value;
            }
        }
        #endregion

        #region 医师级别
        public string DocType
        {
            get
            {
                return _docType;
            }
            set
            {
                _docType = value;
            }
        }
        #endregion

        #region 候诊号
        public string RegNo
        {
            get
            {
                return _regNo;
            }
            set
            {
                _regNo = value;
            }
        }
        #endregion

        #region 挂号费
        public decimal RegFee
        {
            get
            {
                return _regFee;
            }
            set
            {
                _regFee = value;
            }
        }
        #endregion

        #region 诊查费
        public decimal ZcFee
        {
            get
            {
                return _zcFee;
            }
            set
            {
                _zcFee = value;
            }
        }
        #endregion

        #region 检查费
        public decimal CheckFee
        {
            get
            {
                return _checkFee;
            }
            set
            {
                _checkFee = value;
            }
        }
        #endregion

        #region 材料费
        public decimal ClFee
        {
            get
            {
                return _clFee;
            }
            set
            {
                _clFee = value;
            }
        }
        #endregion

        #region 总金额
        public decimal TotalFee
        {
            get
            {
                return _totalFee;
            }
            set
            {
                _totalFee = value;
            }
        }
        #endregion

        #region 收款人
        public string ChargeUserName
        {
            get
            {
                return _chargeUserName;
            }
            set
            {
                _chargeUserName = value;
            }
        }
        #endregion

        #region 病人姓名
        public string PatName
        {
            get
            {
                return _patName;
            }
            set
            {
                _patName = value;
            }
        }
        #endregion


        public void FindRegDetail(RegPatient Patient) //挂号明细费用
        {
            //查找所需费用项目           
            string strsql = @"select c.item_name,a.price from  MZ_REG_ITEM_FEE d left outer join BASE_SERVICE_ITEMS a on d.item_id=a.item_id
                                                 left outer join BASE_STAT_ITEM b on a.statitem_code = b.code
                                                 left outer join base_stat_mzfp c on b.mzfp_code=c.code 
                                  where d.type_code= '" + Patient.RegTypeCode + "'";
           DataTable   tbDetail = oleDb.GetDataTable(strsql);
           for (int i = 0; i < tbDetail.Rows.Count; i++)
           {
               if (tbDetail.Rows[i]["item_name"].ToString().Trim() == "挂号费")
               {
                   RegFee = Convert.ToDecimal(tbDetail.Rows[i]["price"]);
               }
               if (tbDetail.Rows[i]["item_name"].ToString().Trim() == "诊查费")
               {
                   ZcFee = Convert.ToDecimal(tbDetail.Rows[i]["price"]);
               }
               if (tbDetail.Rows[i]["item_name"].ToString().Trim() == "检查费")
               {
                   CheckFee = Convert.ToDecimal(tbDetail.Rows[i]["price"]);
               }
               if (tbDetail.Rows[i]["item_name"].ToString().Trim() == "材料费")
               {
                   ClFee = Convert.ToDecimal(tbDetail.Rows[i]["price"]);
               }
           }
        }
    }
}
