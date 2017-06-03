using System;
namespace HIS.Model
{
    public class BASE_REPORT
    {
        private int _report_id;
        /// <summary>
        ///
        /// </summary>
        public int REPORT_ID
        {
            get { return _report_id; }
            set { _report_id = value; }

        }
        private string _name;
        /// <summary>
        ///
        /// </summary>
        public string NAME
        {
            get { return _name; }
            set { _name = value; }

        }
        private string _procedures;
        /// <summary>
        ///
        /// </summary>
        public string PROCEDURES
        {
            get { return _procedures; }
            set { _procedures = value; }

        }
        private string _remark;
        /// <summary>
        ///
        /// </summary>
        public string REMARK
        {
            get { return _remark; }
            set { _remark = value; }

        }
        private int _reportmaster_id;
        /// <summary>
        ///
        /// </summary>
        public int REPORTMASTER_ID
        {
            get { return _reportmaster_id; }
            set { _reportmaster_id = value; }

        }

        private int _delete_flag;
        /// <summary>
        ///
        /// </summary>
        public int DELETE_FLAG
        {
            get { return _delete_flag; }
            set { _delete_flag = value; }

        }

    }
}
