using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    public class YP_PlanMaster:BillMaster
    {
        private int _deptid;
        /// <summary>
        /// 
        /// </summary>
        public int DeptId
        {
            get { return _deptid; }
            set { _deptid = value; }
        }

        private int _planmasterid;
        /// <summary>
        ///
        /// </summary>
        public int PlanMasterId
        {
            get { return _planmasterid; }
            set { _planmasterid = value; }

        }
        private DateTime _regtime;
        /// <summary>
        ///
        /// </summary>
        public DateTime RegTime
        {
            get { return _regtime; }
            set { _regtime = value; }

        }
        private string _regpeoplename;
        /// <summary>
        ///
        /// </summary>
        public string RegPeopleName
        {
            get { return _regpeoplename; }
            set { _regpeoplename = value; }

        }
        private int _regpeople;
        /// <summary>
        ///
        /// </summary>
        public int RegPeople
        {
            get { return _regpeople; }
            set { _regpeople = value; }

        }
        private decimal _retailfee;
        /// <summary>
        ///
        /// </summary>
        public decimal RetailFee
        {
            get { return _retailfee; }
            set { _retailfee = value; }

        }
        private decimal _tradefee;
        /// <summary>
        ///
        /// </summary>
        public decimal TradeFee
        {
            get { return _tradefee; }
            set { _tradefee = value; }

        }
        private DateTime _lastchangtime;
        /// <summary>
        ///
        /// </summary>
        public DateTime LASTCHANGTIME
        {
            get { return _lastchangtime; }
            set { _lastchangtime = value; }

        }
    }
}
