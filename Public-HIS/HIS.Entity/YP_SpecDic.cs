using System;

namespace HIS.Model
{
	/// <summary>
	/// 实体类YP_SpecDic 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class YP_SpecDic
	{
		public YP_SpecDic()
		{}
		#region Model
		private int _specdicid;
		private string _chemname;
		private string _name;
		private string _nameremark;
		private string _latinname;
		private decimal _dosenum;
		private int _doseunitid;
		private int _unitid;
		private YP_UnitDic _doseunit;
        private YP_UnitDic _unit;
		private int _packnum;
		private int _packunitid;
        private YP_UnitDic _packunit;
		private decimal _usenum;
		private string _curedisease;
		private string _spec;
		private string _remark;
		private int _pharmacology;
		private int _recipelvl;
		private DateTime _regtime;
		private int _useway;
		private int _del_flag;
		private string _gbcode;
		private int _typedicid;
		private int _ctypedicid;
		private int _dosedicid;
		private YP_TypeDic _typedic;
		private YP_DoseDic _dosedic;
		/// <summary>
		/// 规格标识ID
		/// </summary>
		public int SpecDicID
		{
			set
            { 
                _specdicid=value;
            }
			get
            {
                return _specdicid;
            }
		}
		/// <summary>
		/// 化学名称
		/// </summary>
		public string ChemName
		{
			set
            { 
                _chemname=value;
            }
			get
            {
                return _chemname;
            }
		}
		/// <summary>
		/// 商品名称
		/// </summary>
		public string Name
		{
			set
            {
                _name=value;
            }
			get
            {
                return _name;
            }
		}
		/// <summary>
		/// 商品名备注
		/// </summary>
		public string NameRemark
		{
			set
            { 
                _nameremark=value;
            }
			get
            {
                return _nameremark;
            }
		}
		/// <summary>
		/// 拉丁名称
		/// </summary>
		public string LatinName
		{
			set
            { 
                _latinname=value;
            }
			get
            {
                return _latinname;
            }
		}
		/// <summary>
		/// 含量系数
		/// </summary>
		public decimal DoseNum
		{
			set
            { 
                _dosenum=value;
            }
			get
            {
                return _dosenum;
            }
		}
		/// <summary>
		/// 
		/// </summary>
		public int DoseUnit
		{
			set{ _doseunitid=value;}
			get{return _doseunitid;}
		}
		/// <summary>
		/// 含量单位
		/// </summary>
        public YP_UnitDic DoseUnitEntity
		{
			set
            { 
                _doseunit=value;
            }
			get
            {
                return _doseunit;
            }
		}
		/// <summary>
		/// 
		/// </summary>
		public int Unit
		{
			set{ _unitid=value;}
			get{return _unitid;}
		}
		/// <summary>
		/// 最小单位
		/// </summary>
        public YP_UnitDic UnitEntity
		{
			set
            { 
                _unit=value;
            }
			get
            {
                return _unit;
            }
		}
		/// <summary>
		/// 包装数量
		/// </summary>
		public int PackNum
		{
			set
            {
                _packnum=value;
            }
			get
            {
                return _packnum;
            }
		}
		/// <summary>
		/// 
		/// </summary>
		public int PackUnit
		{
			set{ _packunitid=value;}
			get{return _packunitid;}
		}
		/// <summary>
		/// 包装单位
		/// </summary>
        public YP_UnitDic PackUnitEntity
		{
			set
            {
                _packunit=value;
            }
			get
            {
                return _packunit;
            }
		}
		/// <summary>
		/// 使用限量
		/// </summary>
		public decimal UseNum
		{
			set
            {
                _usenum=value;
            }
			get
            {
                return _usenum;
            }
		}
		/// <summary>
		/// 主治病症
		/// </summary>
		public string CureDisease
		{
			set
            {
                _curedisease=value;
            }
			get
            {
                return _curedisease;
            }
		}
		/// <summary>
		/// 规格名称
		/// </summary>
		public string Spec
		{
			set
            {
                _spec=value;
            }
			get
            {
                return _spec;
            }
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set
            {
                _remark=value;
            }
			get
            {
                return _remark;
            }
		}
		/// <summary>
		/// 药理分类
		/// </summary>
		public int Pharmacology
		{
			set
            { 
                _pharmacology=value;
            }
			get
            {
                return _pharmacology;
            }
		}
		/// <summary>
		/// 处方级别
		/// </summary>
		public int RecipeLvl
		{
			set
            {
                _recipelvl=value;
            }
			get
            {
                return _recipelvl;
            }
		}
		/// <summary>
		/// 登记时间
		/// </summary>
		public DateTime RegTime
		{
			set
            {
                _regtime=value;
            }
			get
            {
                return _regtime;
            }
		}
		/// <summary>
		/// 使用方法
		/// </summary>
		public int UseWay
		{
			set
            { 
                _useway=value;
            }
			get
            {
                return _useway;
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
		/// <summary>
		/// 国家编码
		/// </summary>
		public string GBCode
		{
			set
            {
                _gbcode=value;
            }
			get
            {
                return _gbcode;
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
		/// 药品类型
		/// </summary>
        public YP_TypeDic TypeDicEntity
		{
			set
            {
                _typedic=value;
            }
			get
            {
                return _typedic;
            }
		}
		/// <summary>
		/// 
		/// </summary>
		public int CTypeDIc
		{
			set{ _ctypedicid=value;}
			get{return _ctypedicid;}
		}
		/// <summary>
		/// 
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
		/// 药品剂型
		/// </summary>
        public YP_DoseDic DoseDicEntity
		{
			set
            { 
                _dosedic=value;
            }
			get
            {
                return _dosedic;
            }
		}
		#endregion Model

	}
}

