using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    public class YP_Dept_Yptype
    {
        public YP_Dept_Yptype()
        {}
        #region
        private int _id;
        private int _deptdicid;
        private int _deptid;
        private int _typedicid;

        /// <summary>
        /// 部门管理药品类型表主ID
        /// </summary>
        public int Id
        {
            set
            {
                _id = value;
            }
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// 药剂科室典ID
        /// </summary>
        public int DeptDicId
        {
            set 
            {
                _deptdicid = value;
            }
            get
            {
                return _deptdicid;
            }
        }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int DeptId
        {
            set 
            {
                _deptid = value;
            }
            get
            {
                return _deptid;
            }
        }

        /// <summary>
        /// 药品类型典ID
        /// </summary>
        public int TypeDicId
        {
            set 
            {
                _typedicid = value;
            }
            get
            {
                return _typedicid;
            }
        }

        #endregion
    }
}
