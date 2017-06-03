using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
   public  class zy_doc_orderrecord_son : ZY_DOC_ORDERRECORD
    {
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
        private string _ExeNurse;
        /// <summary>
        /// 执行护士名称
        /// </summary>
        public string ExeNurse
        {
            get { return _ExeNurse; }
            set { _ExeNurse = value; }
        }

        private string _OrderDocName;
        /// <summary>
        /// 下嘱医生名字
        /// </summary>
        public string OrderDocName
        {
            get { return _OrderDocName; }
            set { _OrderDocName = value; }
        }
        private string _EOrderDocName;
        /// <summary>
        /// 停嘱医生名字
        /// </summary>
        public string EOrderDocName
        {
            get { return _EOrderDocName; }
            set { _EOrderDocName = value; }
        }
        private DateTime _BeginTime;
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime BeginTime
        {
            get { return _BeginTime; }
            set { _BeginTime = value; }
        }

        private string _Usage;
        /// <summary>
        /// 用法
        /// </summary>
        public string Usage
        {
            get { return _Usage; }
            set { _Usage = value; }
        }
        private string _Frency;
        /// <summary>
        /// 频次
        /// </summary>
        public string Frency
        {
            get { return _Frency; }
            set { _Frency = value; }
        }
        private int _First;
        /// <summary>
        /// 首次　
        /// </summary>
        public int First
        {
            get { return _First; }
            set { _First = value; }
        }
        private int _Last;
        /// <summary>
        /// 末次　
        /// </summary>
        public int Last
        {
            get { return _Last; }
            set { _Last = value; }
        }

        private int _PresNum;
        /// <summary>
        /// 付数
        /// </summary>
        public int PresNum
        {
            get { return _PresNum; }
            set { _PresNum = value; }
        }

       
        public void LoadData()//?
        {
            this.DeptName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(base.EXEC_DEPT.ToString());
            // this.DocName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(base.PresDocCode);
            this.ExecDept = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(base.EXEC_DEPT.ToString());
            this.ExeNurse = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(base.TRANS_NURSE.ToString());
            this.OrderDocName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(base.ORDER_DOC.ToString());
            this.EOrderDocName = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(base.EORDER_DOC.ToString());

        }


    }
}
