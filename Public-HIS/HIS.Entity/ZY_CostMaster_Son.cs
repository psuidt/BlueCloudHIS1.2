using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS.Model
{
    /// <summary>
    /// 结算主表继承类
    /// </summary>
    public class ZY_CostMaster_Son: ZY_CostMaster
    {
        private string _UserName;
        /// <summary>
        /// 结算人
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _CureNo;
        /// <summary>
        /// 住院号
        /// </summary>
        public string CureNo
        {
            get { return _CureNo; }
            set { _CureNo = value; }
        }

        private string _PatName;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatName
        {
            get { return _PatName; }
            set { _PatName = value; }
        }
        private string _DeptName;
        /// <summary>
        /// 病人科室
        /// </summary>       
        public string DeptName
        {
            get { return _DeptName; }
            set { _DeptName = value; }
        }

        private string _CostType;
        /// <summary>
        /// 结算类型名称
        /// </summary>
        public string CostType
        {
            get { return _CostType; }
            set { _CostType = value; }
        }

        
        /// <summary>
        /// 加载上面数据
        /// </summary>
        public void LoadData()
        {
            this.UserName = BaseData.GetUserName(base.ChargeCode);
            this.CureNo = BaseData.GetCureNo(base.PatListID);
            this.PatName = BaseData.GetPatName(base.PatID);
            this.DeptName = BaseData.GetPatDept(base.PatListID);
            if (this.Ntype == 1)
            {
                this.CostType = "中途";
            }
            else if (this.Ntype == 2)
            {
                this.CostType = "出院";
            }
            else
            {
                this.CostType = "欠费";
            }
        }
    }
}
