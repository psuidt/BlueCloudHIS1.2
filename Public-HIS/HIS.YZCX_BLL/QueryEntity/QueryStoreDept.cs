using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Model;

namespace HIS.YZCX_BLL
{
    public class QueryStoreDept
    {
        public QueryStoreDept()
        { }
        private YP_DeptDic _deptDic;
        private DataTable _storeDt;
        public DataTable StoreDt
        {
            set
            {
                _storeDt = value;
            }
            get
            {
                return _storeDt;
            }
        }
        public YP_DeptDic DeptDic
        {
            set
            {
                _deptDic = value;
            }
            get
            {
                return _deptDic;
            }
        }
    }
}
