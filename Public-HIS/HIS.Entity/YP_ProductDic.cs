using System;
namespace HIS.Model
{
	/// <summary>
	/// 实体类YP_ProductDic 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class YP_ProductDic
	{
		public YP_ProductDic()
		{}
		#region Model
		private int _productid;
		private string _address;
		private string _productname;
		private string _pym;
		private string _wmb;
		private string _linkname;
		private string _linkphone;
		private int _del_flag;
		/// <summary>
		/// 厂家标识
		/// </summary>
		public int ProductID
		{
			set
            { 
                _productid=value;
            }
			get
            {
                return _productid;
            }
		}
		/// <summary>
		/// 生产商地址
		/// </summary>
		public string Address
		{
			set
            {
                _address=value;
            }
			get
            {
                return _address;
            }
		}
		/// <summary>
		/// 生产商名字
		/// </summary>
		public string ProductName
		{
			set
            { 
                _productname=value;
            }
			get
            {
                return _productname;
            }
		}
		/// <summary>
		/// 拼音码
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
		/// 五笔码
		/// </summary>
		public string WMB
		{
			set
            {
                _wmb=value;
            }
			get
            {
                return _wmb;
            }
		}
		/// <summary>
		/// 联系人姓名
		/// </summary>
		public string LinkName
		{
			set
            {
                _linkname=value;
            }
			get
            {
                return _linkname;
            }
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string LinkPhone
		{
			set
            {
                _linkphone=value;
            }
			get
            {
                return _linkphone;
            }
		}
		/// <summary>
		/// 删除标识
		/// </summary>
		public int Del_Flag
		{
			set
            { 
                _del_flag=value;
            }
			get
            {
                return _del_flag;
            }
		}
		#endregion Model

	}
}

