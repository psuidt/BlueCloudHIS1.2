using System;


namespace HIS.Model
{
    public class ZY_DOC_ORDERMODELLIST_E : ZY_DOC_ORDERMODELLIST
    {
        private bool _xd;
        /// <summary>
        /// 是否勾选
        /// </summary>
        public bool XD
        {
            get { return _xd; }
            set { _xd = value; }
        }
        private string _DeptName;
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName
        {
            get { return _DeptName; }
            set { _DeptName = value; }
        }
        private string _ExecDept;
        /// <summary>
        /// 执行科室名称
        /// </summary>
        public string ExecDept
        {
            get { return _ExecDept; }
            set { _ExecDept = value; }
        }

        private int _GroupID;
        /// <summary>
        /// 需要显示的组号
        /// </summary>
        public int  GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }

        
        public void LoadData()//?
        {
            
            this.DeptName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(base.EXEC_DEPT.ToString());
           // this.DocName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(base.PresDocCode);
            this.ExecDept = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(base.EXEC_DEPT.ToString());
            //this.CostName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(base.ChargeCode);
           // this.SmallNum = base.Amount % base.RelationNum;
           // this.BigNum = Convert.ToInt32((base.Amount - this.SmallNum) / base.RelationNum);

           // this.NCMS_CODE = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetNCMS_CODE(this.ItemID, this.PresType.ToString() == "4" ? "2" : "1");

        }
    }
}
