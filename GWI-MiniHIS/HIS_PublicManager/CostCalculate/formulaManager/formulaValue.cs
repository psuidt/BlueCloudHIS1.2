using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_PublicManager.formulaManager
{
    public class formulaValue
    {
        public int Col;
        public int Row;

        public List<formulaField> filed;
    }

    public class formulaField
    {
        public int Col;
        public int Row;

        public string formu;
    }

    public class formulaResult
    {
        public int Col;
        public int Row;
    }

    public class formulaSysVar
    {
        public int Col;
        public int Row;
        public string name;
        public string value;
    }

    public class SysVar
    {
        private string _name;
        private string _value;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
