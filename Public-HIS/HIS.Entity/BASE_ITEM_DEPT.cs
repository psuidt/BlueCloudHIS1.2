using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类BASE_ITEM_DEPT 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class BASE_ITEM_DEPT
	{
		public BASE_ITEM_DEPT()
		{}
		#region Model
		private int _item_id;
		private int _dept_id;
		private int _default_flag;
        private int _complex_id;
		/// <summary>
		/// 
		/// </summary>
		public int ITEM_ID
		{
			set{ _item_id=value;}
			get{return _item_id;}
		}
        public int COMPLEX_ID
        {
            get
            {
                return _complex_id;
            }
            set
            {
                _complex_id = value;
            }
        }
		/// <summary>
		/// 
		/// </summary>
		public int DEPT_ID
		{
			set{ _dept_id=value;}
			get{return _dept_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DEFAULT_FLAG
		{
			set{ _default_flag=value;}
			get{return _default_flag;}
		}
		#endregion Model

	}
}

