using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Interface;

namespace HIS.MZ_BLL
{
    ///// <summary> 
    ///// 门诊处方结构
    ///// </summary>
    //public struct Prescription 
    //{
    //    /// <summary>
    //    /// 医保农合病人ID
    //    /// </summary>
    //    public decimal PatientID;
    //    /// <summary>
    //    /// 病人姓名
    //    /// </summary>
    //    public string PatientName;
    //    /// <summary>
    //    /// 就诊ID
    //    /// </summary>
    //    public int RegisterID;
    //    /// <summary>
    //    /// 处方ID
    //    /// </summary>
    //    public int PrescriptionID;
    //    /// <summary>
    //    /// 处方类型
    //    /// </summary>
    //    public string PrescType;
    //    /// <summary>
    //    /// 处方医生ID
    //    /// </summary>
    //    public string PresDocCode;
    //    /// <summary>
    //    /// 处方医生科室
    //    /// </summary>
    //    public string PresDeptCode;
    //    /// <summary>
    //    /// 执行人代码
    //    /// </summary>
    //    public string ExecDocCode;
    //    /// <summary>
    //    /// 执行科室代码
    //    /// </summary>
    //    public string ExecDeptCode;
    //    /// <summary>
    //    /// 划价人代码
    //    /// </summary>
    //    public string PresCostCode;
    //    /// <summary>
    //    /// 收费人代码
    //    /// </summary>
    //    public string ChargeCode;
    //    /// <summary>
    //    /// 总费用
    //    /// </summary>
    //    public decimal Total_Fee;
    //    /// <summary>
    //    /// 结算ID
    //    /// </summary>
    //    public int ChargeID;
    //    /// <summary>
    //    /// 退处方ID
    //    /// </summary>
    //    public int OldPresID;
    //    /// <summary>
    //    /// 发票流水号
    //    /// </summary>
    //    public string TicketNum;
    //    /// <summary>
    //    /// 发票号
    //    /// </summary>
    //    public string TicketCode;
    //    /// <summary>
    //    /// 记录状态
    //    /// </summary>
    //    public int Record_Flag;
    //    /// <summary>
    //    /// 收费标识
    //    /// </summary>
    //    public int Charge_Flag;
    //    /// <summary>
    //    /// 发药标识
    //    /// </summary>
    //    public int Drug_Flag;
    //    /// <summary>
    //    /// 明细
    //    /// </summary>
    //    public PrescriptionDetail[] PresDetails;
    //    /// <summary>
    //    /// 处方日期
    //    /// </summary>
    //    public DateTime PresDate;
    //    /// <summary>
    //    /// 本张处方的可报销或可补偿金额
    //    /// </summary>
    //    public decimal RedeemCost;
    //    /// <summary>
    //    /// 修改标志
    //    /// </summary>
    //    public bool Modified;
    //    /// <summary>
    //    /// 本张处方舍入金额
    //    /// </summary>
    //    public decimal RoundingMoney;
    //    /// <summary>
    //    /// 处方就诊号
    //    /// </summary>
    //    public string VisitNo;
    //    /// <summary>
    //    /// 医生处方ID
    //    /// </summary>
    //    public int DocPresId;
    //    /// <summary>
    //    /// 标志是否被选中
    //    /// </summary>
    //    public bool Selected;
    //}
    ///// <summary>
    ///// 处方明细结构
    ///// </summary>
    //public struct PrescriptionDetail : IPresDetail
    //{
    //    /// <summary>
    //    /// 处方头ID
    //    /// </summary>
    //    public int PresctionId;
    //    /// <summary>
    //    /// 明细ID
    //    /// </summary>
    //    public int DetailId;
    //    /// <summary>
    //    /// 项目药品内码
    //    /// </summary>
    //    public int ItemId;
    //    /// <summary>
    //    /// 组合项目ID
    //    /// </summary>
    //    public int ComplexId;
    //    /// <summary>
    //    /// 类型
    //    /// </summary>
    //    public string ItemType;
    //    /// <summary>
    //    /// 统计项目代码
    //    /// </summary>
    //    public string BigitemCode;
    //    /// <summary>
    //    /// 名称
    //    /// </summary>
    //    public string Itemname;
    //    /// <summary>
    //    /// 规格
    //    /// </summary>
    //    public string Standard;
    //    /// <summary>
    //    /// 单位
    //    /// </summary>
    //    public string Unit;
    //    /// <summary>
    //    /// 划价系数
    //    /// </summary>
    //    public decimal RelationNum;
    //    /// <summary>
    //    /// 批发价
    //    /// </summary>
    //    public decimal Buy_price;
    //    /// <summary>
    //    /// 零售价
    //    /// </summary>
    //    public decimal Sell_price;
    //    /// <summary>
    //    /// 数量
    //    /// </summary>
    //    public decimal Amount;
    //    /// <summary>
    //    /// 处方贴数
    //    /// </summary>
    //    public int PresAmount;
    //    /// <summary>
    //    /// 合计金额
    //    /// </summary>
    //    public decimal Tolal_Fee;
    //    /// <summary>
    //    /// 排序号
    //    /// </summary>
    //    public int Order_Flag;
    //    /// <summary>
    //    /// 上传ID
    //    /// </summary>
    //    public int PassId;
    //    /// <summary>
    //    /// 补偿金额
    //    /// </summary>
    //    public decimal Comp_Money;
    //    /// <summary>
    //    /// 修改标识
    //    /// </summary>
    //    public bool Modified;
    //    /// <summary>
    //    /// 发药标志
    //    /// </summary>
    //    public int Drug_Flag;
    //    /// <summary>
    //    /// 医生站处方明细ID
    //    /// </summary>
    //    public int DocPrescDetailId;

    //    #region IPresDetail 成员

    //    public string BigItemCode
    //    {
    //        get
    //        {
    //            return BigitemCode;
    //        }
    //        set
    //        {
    //            BigitemCode = value;
    //        }
    //    }

    //    public decimal Money
    //    {
    //        get
    //        {
    //            return Tolal_Fee;
    //        }
    //        set
    //        {
    //            Tolal_Fee = value;
    //        }
    //    }

    //    #endregion
    //}
    /// <summary>
    /// 结算信息
    /// </summary>
    public struct ChargeInfo
    {
        /// <summary>
        /// 结算号
        /// </summary>
        public int ChargeID;
        /// <summary>
        /// 所结算的处方的处方号
        /// </summary>
        public int PrescriptionID;
        /// <summary>
        /// 发票流水号
        /// </summary>
        public int InvoiceSerialNO;
        /// <summary>
        /// 发票号(在不管理发票情况下，可能是用户前台输入)
        /// </summary>
        public string InvoiceNO;
        /// <summary>
        /// 发票前缀
        /// </summary>
        public string PerfChar;
        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime ChargeDate;
        /// <summary>
        /// 总金额（自付+记账+优惠）
        /// </summary>
        public decimal TotalFee;
        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal SelfFee;
        /// <summary>
        /// 医保、农合支付金额(统称 记账金额)
        /// </summary>
        public decimal VillageFee;
        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal FavorFee;
        /// <summary>
        /// POS金额
        /// </summary>
        public decimal PosFee;
        /// <summary>
        /// 现金金额
        /// </summary>
        public decimal CashFee;
        /// <summary>
        /// 个人记账（属于个人自付里的一部分）
        /// </summary>
        public decimal SelfTally;
        /// <summary>
        /// 结算项目(发票项目)
        /// </summary>
        public InvoiceItem[] Items;
        /// <summary>
        /// 补偿明细
        /// </summary>
        public System.Data.DataTable compData;
    }
    /// <summary>
    /// 发票项目
    /// </summary>
    public struct InvoiceItem
    {
        /// <summary>
        /// 发票项目代码
        /// </summary>
        public string ItemCode;
        /// <summary>
        /// 发票项目名称
        /// </summary>
        public string ItemName;
        /// <summary>
        /// 项目金额
        /// </summary>
        public decimal Cost;
        /// <summary>
        /// 项目明细名称
        /// </summary>
        public string Item_Name;

        /// <summary>
        /// 项目明细费用
        /// </summary>
        public string  Tolal_Fee;
    }
    /// <summary>
    /// 医保、农合结算返回信息
    /// </summary>
    public struct InsurChargeInfo
    {
        /// <summary>
        ///  结算内荣
        /// </summary>
        public HIS.SYSTEM.PubicBaseClasses.ItemEx[] Items;
        /// <summary>
        /// 自付部分
        /// </summary>
        public decimal SelfCost;
        /// <summary>
        /// 非自付部分(非自付部分具体内容保存在Items属性里)
        /// </summary>
        public decimal UnSelfCost;
    }
    /// <summary>
    /// 医保病人的信息
    /// </summary>
    public struct InsurPatientInfo
    {
        /// <summary>
        /// 门诊登记流水号
        /// </summary>
        public string Mz_Id;
        /// <summary>
        ///  地区编码 
        /// </summary>
        public string Area_Id;
        /// <summary>
        /// 个人编码 
        /// </summary>
        public string Person_Code;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name;
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex;
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard;
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDate;
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age;
        /// <summary>
        /// 家庭编码
        /// </summary>
        public string Family_Code;
        /// <summary>
        /// 医疗证号
        /// </summary>
        public string Medcard_Id;
        /// <summary>
        /// 就诊类型
        /// </summary>
        public string Visit_Type;

        /// <summary>
        /// 就诊时间
        /// </summary>
        public DateTime Visit_Date;
        /// <summary>
        /// 就医机构代码
        /// </summary>
        public string Medorg_Code;
        /// <summary>
        /// 就医机构级别
        /// </summary>
        public string Medorg_Level;
        /// <summary>
        /// 接诊科室
        /// </summary>
        public string Accet_Dept;
        /// <summary>
        /// 接诊医生
        /// </summary>
        public string Doctor;
        /// <summary>
        /// 医生职务
        /// </summary>
        public string Doctor_Title;
        /// <summary>
        /// 就诊时情况
        /// </summary>
        public string Adm_State;
        /// <summary>
        /// 疾病代码
        /// </summary>
        public string Disease_Code;
        /// <summary>
        /// 疾病名称
        /// </summary>
        public string Disease_Name;
        /// <summary>
        /// 转往医院代码
        /// </summary>
        public string Trans_Orgcode;
        /// <summary>
        /// 转往医院级别
        /// </summary>
        public string Trans_Orglevel;
        /// <summary>
        /// 地区编码
        /// </summary>
        public string AreaCode;
    }

    public class PatientType
    {
        public string Code ;
        public string Name ;
    }

    /// <summary>
    /// 账单的票据信息
    /// </summary>
    public struct AccountBillInfo
    {
        /// <summary>
        /// 收费员
        /// </summary>
        public string ChargeName;
        /// <summary>
        /// 开始号码
        /// </summary>
        public string StartNumber;
        /// <summary>
        /// 结束号码
        /// </summary>
        public string EndNumber;
        /// <summary>
        /// 张数
        /// </summary>
        public int Count;
        /// <summary>
        /// 退费数
        /// </summary>
        public int RefundCount;
        /// <summary>
        /// 退费金额
        /// </summary>
        public decimal RefundMoney;
        /// <summary>
        /// 作废的无效票
        /// </summary>
        public string[] Useless;
        /// <summary>
        /// 发票清单
        /// </summary>
        public Invoice[] InvoiceList;
        /// <summary>
        /// 退费发票列表
        /// </summary>
        public Invoice[] RefundInvoice;
    }
    /// <summary>
    /// 金额组成类
    /// </summary>
    public struct FundPart
    {
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal TotalMoney;
        /// <summary>
        /// 金额组成明细
        /// </summary>
        public FundInfo[] Details;
    }
    /// <summary>
    /// 金额信息
    /// </summary>
    public struct FundInfo
    {
        /// <summary>
        /// 支付方式代码
        /// </summary>
        public string PayCode;
        /// <summary>
        /// 支付方式名称
        /// </summary>
        public string PayName;
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money;
        /// <summary>
        /// 票据张数
        /// </summary>
        public int BillCount;
    }
    
}
