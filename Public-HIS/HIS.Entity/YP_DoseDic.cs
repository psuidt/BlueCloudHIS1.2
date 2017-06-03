using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类YP_DoseDic 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class YP_DoseDic
	{
        /// <summary>
        /// 构造函数
        /// </summary>
		public YP_DoseDic()
		{}
		#region Model
		private int _dosedicid;
		private int _typedicid;
        private YP_TypeDic _typedic;
		private string _dosename;
		private string _pym;
		private string _wbm;
		/// <summary>
		/// 剂型典标识ID
		/// </summary>
		public int DoseDicID
		{
			set
            {
                _dosedicid=value;
            }
			get
            {
                return _dosedicid;
            }
		}
		/// <summary>
		/// 剂型对应类型
		/// </summary>
        public YP_TypeDic TypeDic
		{
            set 
            {
                _typedic = value; 
            }
            get 
            { 
                return _typedic; 
            }
		}
		/// <summary>
		/// 
		/// </summary>
		public int TypeDicID
		{
			set{ _typedicid=value;}
			get{return _typedicid;}
		}
		/// <summary>
		/// 剂型名称
		/// </summary>
		public string DoseName
		{
			set
            { 
                _dosename=value;
            }
			get
            {
                return _dosename;
            }
		}
		/// <summary>
		/// 剂型拼音码
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
		/// 剂型五笔码
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

