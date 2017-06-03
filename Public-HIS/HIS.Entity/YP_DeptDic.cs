using System;
namespace HIS.Model
{
	/// <summary>
	///药剂科室
	/// </summary>
	public class YP_DeptDic
	{
		public YP_DeptDic()
		{}
		#region Model
		private int _deptdicid;
		private string _deptname;
		private string _depttype1;
		private string _depttype2;
		private int _use_flag;
		private int _deptid;
		/// <summary>
		/// 药剂科室ＩＤ
		/// </summary>
		public int DeptDicID
		{
			set
            {
                _deptdicid=value;
            }
			get
            {
                return _deptdicid;
            }
		}
		/// <summary>
		/// 科室名称
		/// </summary>
		public string DeptName
		{
			set
            { 
                _deptname=value;
            }
			get
            {
                return _deptname;
            }
		}
		/// <summary>
		/// 科室类型１
		/// </summary>
		public string DeptType1
		{
			set
            {
                _depttype1=value;
            }
			get
            {
                return _depttype1;
            }
		}
		/// <summary>
		/// 科室类型２
		/// </summary>
		public string DeptType2
		{
			set
            {
                _depttype2=value;
            }
			get
            {
                return _depttype2;
            }
		}
		/// <summary>
		/// 使用标识
		/// </summary>
		public int Use_Flag
		{
			set
            {
                _use_flag=value;
            }
			get
            {
                return _use_flag;
            }
		}
		/// <summary>
		/// 部门ＩＤ
		/// </summary>
		public int DeptID
		{
			set
            {
                _deptid=value;
            }
			get
            {
                return _deptid;
            }
		}
		#endregion Model

	}
}

