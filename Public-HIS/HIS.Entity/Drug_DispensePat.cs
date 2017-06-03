using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    public class Drug_DispensePat:ZY_PatList
    {
        private string _curedocname;
        private string _curedeptname;
        private string _age;
        public string CureDocName
        {
            set { _curedocname = value; }
            get { return _curedocname; }
        }
        public string CureDeptName
        {
            set { _curedeptname = value; }
            get { return _curedeptname; }
        }
        public string Age
        {
            set { _age = value; }
            get { return _age; }
        }
    }
}
