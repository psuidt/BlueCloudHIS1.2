using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类BASE_EMP_DEPT_ROLE 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class BASE_EMP_DEPT_ROLE
	{
		public BASE_EMP_DEPT_ROLE()
		{}
		#region Model
		private int _id;
		private int _employee_id;
		private int _role_id;
		private int _default;
		private int _dept_id;
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
		public int EMPLOYEE_ID
		{
			set{ _employee_id=value;}
			get{return _employee_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ROLE_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DEFAULT
		{
			set{ _default=value;}
			get{return _default;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DEPT_ID
		{
			set{ _dept_id=value;}
			get{return _dept_id;}
		}
		#endregion Model

	}
}

