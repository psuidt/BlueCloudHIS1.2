using System;

namespace HIS.MZ_BLL.Print
{
	/// <summary>
	/// IInvoice 的摘要说明。
	/// </summary>
	public interface IInvoice
	{
		/// <summary>
		/// 发票号
		/// </summary>
		string InvoiceNo{ get; set;}
		/// <summary>
		/// 病人姓名
		/// </summary>
		string PatientName{ get; set;}
		/// <summary>
		/// 科室
		/// </summary>
		string DepartmentName{ get; set;}
		/// <summary>
		/// 年
		/// </summary>
		int Year{ get; set;}
		/// <summary>
		/// 月
		/// </summary>
		int Month{ get; set;}
		/// <summary>
		/// 日
		/// </summary>
		int Day{ get; set;}
		/// <summary>
		/// 收款员
		/// </summary>
		string Payee{ get ; set ;}
		/// <summary>
		/// 合计金额(小写)
		/// </summary>
		decimal TotalMoneyNum{ get; set; }
		/// <summary>
		/// 合计金额(大写)
		/// </summary>
		string TotalMoneyCN{ get ; set;}
        /// <summary>
        /// 其他信息
        /// </summary>
        string OtherInfo
        {
            get;
            set;
        }
		/// <summary>
		/// 打印
		/// </summary>
		void Print();
        /// <summary>
        /// 预览
        /// </summary>
        void Preview();
	}
}
