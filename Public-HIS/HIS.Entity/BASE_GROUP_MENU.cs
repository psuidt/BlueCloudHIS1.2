using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    public class BASE_GROUP_MENU
    {
        //ID, GROUP_ID, MODULE_ID, MENU_ID
        public BASE_GROUP_MENU()
        {
        }

        private int _id;
        private int _group_id;
        private int _module_id;
        private int _menu_id;
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

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

        public int MODULE_ID
        {
            get
            {
                return _module_id;
            }
            set
            {
                _module_id = value;
            }
        }

        public int MENU_ID
        {
            get
            {
                return _menu_id;
            }
            set
            {
                _menu_id = value;
            }
        }
    }
}
