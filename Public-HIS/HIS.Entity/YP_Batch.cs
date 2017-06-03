using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class YP_Batch
    {
        /// <summary>
        /// 
        /// </summary>
        public YP_Batch()
        { 
        }

        private int _id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
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
        private int _makerdicid;

        /// <summary>
        /// 
        /// </summary>
        public int Makerdicid
        {
            get 
            {
                return _makerdicid; 
            }
            set
            { 
                _makerdicid = value;
            }
        }
        private DateTime _instoretime;

        /// <summary>
        /// 
        /// </summary>
        public DateTime Instoretime
        {
            get 
            {
                return _instoretime; 
            }
            set 
            {
                _instoretime = value;
            }
        }
        private int _deptid;

        /// <summary>
        /// 
        /// </summary>
        public int Deptid
        {
            get
            {
                return _deptid;
            }
            set 
            {
                _deptid = value; 
            }
        }
        private decimal _currentnum;

        /// <summary>
        /// 
        /// </summary>
        public decimal Currentnum
        {
            get
            {
                return _currentnum;
            }
            set 
            {
                _currentnum = value; 
            }
        }
        private int _unit;

        /// <summary>
        /// 
        /// </summary>
        public int Unit
        {
            get 
            {
                return _unit; 
            }
            set
            {
                _unit = value;
            }
        }
        private int _unitnum;

        /// <summary>
        /// 
        /// </summary>
        public int Unitnum
        {
            get 
            {
                return _unitnum;
            }
            set 
            {
                _unitnum = value; 
            }
        }
        private string _batchnum;

        /// <summary>
        /// 
        /// </summary>
        public string Batchnum
        {
            get 
            {
                return _batchnum;
            }
            set
            {
                _batchnum = value; 
            }
        }
        private DateTime _validitydate;

        /// <summary>
        /// 
        /// </summary>
        public DateTime ValidityDate
        {
            get
            {
                return _validitydate;
            }
            set 
            {
                _validitydate = value;
            }
        }
        private short _del_flag;

        /// <summary>
        /// 
        /// </summary>
        public short Del_flag
        {
            get 
            {
                return _del_flag;
            }
            set 
            { 
                _del_flag = value;
            }
        }
    }
}
