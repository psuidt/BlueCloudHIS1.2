using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    public class HIS_Report
    {
        #region Model
        private int _reportid;
        private string _reportname;
        private string _reportpath;
        private string _buildempname;
        private string _buildempcode;
        private DateTime _builddatetime;
        /// <summary>
        /// 
        /// </summary>
        public int ReportID
        {
            set { _reportid = value; }
            get { return _reportid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReportName
        {
            set { _reportname = value; }
            get { return _reportname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReportPath
        {
            set { _reportpath = value; }
            get { return _reportpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuildEmpName
        {
            set { _buildempname = value; }
            get { return _buildempname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuildEmpCode
        {
            set { _buildempcode = value; }
            get { return _buildempcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BuildDateTime
        {
            set { _builddatetime = value; }
            get { return _builddatetime; }
        }
        #endregion Model

    }
}
