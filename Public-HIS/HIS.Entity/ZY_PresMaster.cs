using System;
namespace HIS.Model
{
	/// <summary>
	/// 处方主表
	/// </summary>
	public class ZY_PresMaster
	{
		public ZY_PresMaster()
		{}
		#region Model
		private int _presmasterid;
		private int _patid;
		private int _patlistid;
		private string _prestype;
		private decimal _total_fee;
		private int _pres_flag;
		private DateTime _presdate;
		private int _del_flag;
		/// <summary>
		/// ID
		/// </summary>
		public int PresMasterID
		{
			set{ _presmasterid=value;}
			get{return _presmasterid;}
		}
		/// <summary>
		/// 病人ID
		/// </summary>
		public int PatID
		{
			set{ _patid=value;}
			get{return _patid;}
		}
		/// <summary>
		/// 住院病人iD
		/// </summary>
		public int PatListID
		{
			set{ _patlistid=value;}
			get{return _patlistid;}
		}
		/// <summary>
		/// 处方类型（西药or项目）
		/// </summary>
		public string PresType
		{
			set{ _prestype=value;}
			get{return _prestype;}
		}
		/// <summary>
		/// 总费用
		/// </summary>
		public decimal Total_Fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
		/// <summary>
        /// 处方类型（临时or长期）
		/// </summary>
		public int Pres_Flag
		{
			set{ _pres_flag=value;}
			get{return _pres_flag;}
		}
		/// <summary>
		/// 处方日期
		/// </summary>
		public DateTime PresDate
		{
			set{ _presdate=value;}
			get{return _presdate;}
		}
		/// <summary>
		/// 是否有效
		/// </summary>
		public int Del_Flag
		{
			set{ _del_flag=value;}
			get{return _del_flag;}
		}
		#endregion Model

	}
}

