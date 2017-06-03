using System;
namespace HIS.Model
{
    /// <summary>
    /// 药房统领记录
    /// </summary>
	public class YP_DispDeptHis:BillMaster
	{
        private string _billType;
        public string BillType
        {
            get
            {
                return _billType;
            }
            set
            {
                _billType = value;
            }
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
                _id = value ;
            }

		}
		private int _dispdept;
		/// <summary>
		///
		/// </summary>
		public int DispDept
		{
			get
            {
                return _dispdept;
            }
			set
            {
                _dispdept = value ;
            }

		}
		private decimal _totalfee;
		/// <summary>
		///
		/// </summary>
		public decimal TotalFee
		{
			get
            {
                return _totalfee;
            }
			set
            {
                _totalfee = value ;
            }

		}
		private int _deptid;
		/// <summary>
		///
		/// </summary>
		public int DeptId
		{
			get
            {
                return _deptid;
            }
			set
            {
                _deptid = value ;
            }

		}
		private DateTime _optime;
		/// <summary>
		///
		/// </summary>
		public DateTime OpTime
		{
			get
            {
                return _optime;
            }
			set
            {
                _optime = value ;
            }

		}
		private int _opman;
		/// <summary>
		///
		/// </summary>
		public int OpMan
		{
			get
            {
                return _opman;
            }
			set
            {
                _opman = value ;
            }
		}

        /// <summary>
        /// 
        /// </summary>
        private string _patientNames;
        public string PatientNames
        {
            get
            {
                return _patientNames;
            }
            set
            {
                _patientNames = value;
            }
        }
	}
}
