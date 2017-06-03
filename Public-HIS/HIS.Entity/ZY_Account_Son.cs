using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    public class ZY_Account_Son : ZY_Account
    {
        private string _accountName;
        /// <summary>
        /// 交款员
        /// </summary>
        public string AccountName
        {
            get
            {
                return _accountName;
            }
            set
            {
                _accountName = value;
            }
        }
    }
}
