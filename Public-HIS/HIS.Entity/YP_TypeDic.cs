using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类YP_TypeDic 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class YP_TypeDic
	{
		public YP_TypeDic()
		{}
		#region Model
		private int _typedicid;
		private string _typename;
		private string _pym;
		private string _wbm;
		/// <summary>
		/// 类型标识ID
		/// </summary>
		public int TypeDicID
		{
			set
            { 
                _typedicid=value;
            }
			get
            {
                return _typedicid;
            }
		}
		/// <summary>
		/// 类型名称
		/// </summary>
		public string TypeName
		{
			set
            {
                _typename=value;
            }
			get
            {
                return _typename;
            }
		}
		/// <summary>
		/// 类型拼音码
		/// </summary>
		public string PYM
		{
			set
            {
                _pym=value;
            }
			get
            {
                return _pym;
            }
		}
		/// <summary>
		/// 类型五笔码
		/// </summary>
		public string WBM
		{
			set
            {
                _wbm=value;
            }
			get
            {
                return _wbm;
            }
		}
		#endregion Model

	}
}

