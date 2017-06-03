using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类MZ_INCOME_DETAIL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class MZ_INCOME_DETAIL
	{
		public MZ_INCOME_DETAIL()
		{}
		#region Model
		private int _id;
		private int _rptid;
		private string _charge_name;
		private string _item_name;
		private decimal _item_fee;
        private int _sort_no;
        private string _dept_name;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int RPTID
		{
			set{ _rptid=value;}
			get{return _rptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CHARGE_NAME
		{
			set{ _charge_name=value;}
			get{return _charge_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_NAME
		{
			set{ _item_name=value;}
			get{return _item_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ITEM_FEE
		{
			set{ _item_fee=value;}
			get{return _item_fee;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int SORT_NO
        {
            set
            {
                _sort_no = value;
            }
            get
            {
                return _sort_no;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DEPT_NAME
        {
            set
            {
                _dept_name = value;
            }
            get
            {
                return _dept_name;
            }
        }
		#endregion Model

	}
}

