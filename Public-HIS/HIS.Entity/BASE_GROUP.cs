using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    public class BASE_GROUP
    {
        //GROUP_ID, NAME, DELETE_FLAG, ADMINISTRATORS, EVERYONE, MEMO, PROPERTY
        public BASE_GROUP()
        {
        }
        private int _group_id;
        private string _name;
        private int _delete_flag;
        private int _administraors;
        private int _everyone;
        private string _memo;
        private string _property;

        public int GROUP_ID
        {
            get
            {
                return _group_id;
            }
            set
            {
                _group_id = value;
            }
        }
        public string NAME
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
        public int DELETE_FLAG
        {
            get
            {
                return _delete_flag;
            }
            set
            {
                _delete_flag = value;
            }
        }
        public int ADMINISTRATORS
        {
            get
            {
                return _administraors;
            }
            set
            {
                _administraors = value;
            }
        }
        public int EVERYONE
        {
            get
            {
                return _everyone;
            }
            set
            {
                _everyone = value;
            }
        }
        public string MEMO
        {
            get
            {
                return _memo;
            }
            set
            {
                _memo = value;
            }
        }
        public string PROPERTY
        {
            get
            {
                return _property;
            }
            set
            {
                _property = value;
            }
        }

    }
}
