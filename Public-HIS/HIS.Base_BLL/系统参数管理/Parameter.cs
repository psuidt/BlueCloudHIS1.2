using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    public class Parameter : ICloneable
    {
        private string _name;
        private string _notes;
        private object _value;
        private string _code;
        private int _deptId;

        public int DeptId
        {
            get
            {
                return _deptId;
            }
            set
            {
                _deptId = value;
            }
        }
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }
        }



        #region ICloneable 成员

        public object Clone()
        {
            Parameter p = new Parameter();
            p.Name = _name;
            p.Notes = _notes;
            p.Value = _value;
            p.Code = _code;
            p.DeptId = _deptId;

            return p;
        }

        #endregion
    }
}
