using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace HIS.Interface.Structs
{
    /// <summary> 
    /// 门诊处方结构
    /// </summary>
    public class Prescription
    {
        /// <summary>
        /// 开方医生名称
        /// </summary>
        public string exeDocName;
        /// <summary>
        /// 开方科室名称
        /// </summary>
        public string presDeptName;
        /// <summary>
        /// 处方贴数
        /// </summary>
        public string presAmount;
        /// <summary>
        /// 医保农合病人ID
        /// </summary>
        public decimal PatientID;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName;
        /// <summary>
        /// 就诊ID
        /// </summary>
        public int RegisterID;
        /// <summary>
        /// 处方ID
        /// </summary>
        public int PrescriptionID;
        /// <summary>
        /// 处方类型
        /// </summary>
        public string PrescType;
        /// <summary>
        /// 处方医生ID
        /// </summary>
        public string PresDocCode;
        /// <summary>
        /// 处方医生科室
        /// </summary>
        public string PresDeptCode;
        /// <summary>
        /// 执行人代码
        /// </summary>
        public string ExecDocCode;
        /// <summary>
        /// 执行科室代码
        /// </summary>
        public string ExecDeptCode;
        /// <summary>
        /// 划价人代码
        /// </summary>
        public string PresCostCode;
        /// <summary>
        /// 收费人代码
        /// </summary>
        public string ChargeCode;
        /// <summary>
        /// 总费用
        /// </summary>
        public decimal Total_Fee;
        /// <summary>
        /// 结算ID
        /// </summary>
        public int ChargeID;
        /// <summary>
        /// 退处方ID
        /// </summary>
        public int OldPresID;
        /// <summary>
        /// 发票流水号
        /// </summary>
        public string TicketNum;
        /// <summary>
        /// 发票号
        /// </summary>
        public string TicketCode;
        /// <summary>
        /// 记录状态
        /// </summary>
        public int Record_Flag;
        /// <summary>
        /// 收费标识
        /// </summary>
        public int Charge_Flag;
        /// <summary>
        /// 发药标识
        /// </summary>
        public int Drug_Flag;
        /// <summary>
        /// 
        /// </summary>
        public PrescriptionDetail[] PresDetails;
        /// <summary>
        /// 处方日期
        /// </summary>
        public DateTime PresDate;
        /// <summary>
        /// 本张处方的可报销或可补偿金额
        /// </summary>
        public decimal RedeemCost;
        /// <summary>
        /// 修改标志
        /// </summary>
        public bool Modified;
        /// <summary>
        /// 本张处方舍入金额
        /// </summary>
        public decimal RoundingMoney;
        /// <summary>
        /// 处方就诊号
        /// </summary>
        public string VisitNo;
        /// <summary>
        /// 医生处方ID
        /// </summary>
        public int DocPresId;
        /// <summary>
        /// 标志是否被选中
        /// </summary>
        public bool Selected;

    }
    /// <summary>
    /// 处方明细结构
    /// </summary>
    public class PrescriptionDetail : IPresDetail
    {
        /// <summary>
        /// 处方头ID *
        /// </summary>
        public int PresctionId;
        /// <summary>
        /// 明细ID *
        /// </summary>
        public int DetailId;
        /// <summary>
        /// 项目药品内码 *
        /// </summary>
        public int ItemId;
        /// <summary>
        /// 组合项目ID
        /// </summary>
        public int ComplexId;
        /// <summary>
        /// 类型
        /// </summary>
        public string ItemType;
        /// <summary>
        /// 统计项目代码 *
        /// </summary>
        public string BigitemCode;
        /// <summary>
        /// 名称
        /// </summary>
        public string Itemname;
        /// <summary>
        /// 规格
        /// </summary>
        public string Standard;
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit;
        /// <summary>
        /// 划价系数 *
        /// </summary>
        public decimal RelationNum;
        /// <summary>
        /// 批发价 *
        /// </summary>
        public decimal Buy_price;
        /// <summary>
        /// 零售价 *
        /// </summary>
        public decimal Sell_price;
        /// <summary>
        /// 数量 *
        /// </summary>
        public decimal Amount;
        /// <summary>
        /// 处方贴数 *
        /// </summary>
        public int PresAmount;
        /// <summary>
        /// 合计金额 *
        /// </summary>
        public decimal Tolal_Fee;
        /// <summary>
        /// 排序号
        /// </summary>
        public int Order_Flag;
        /// <summary>
        /// 上传ID
        /// </summary>
        public int PassId;
        /// <summary>
        /// 补偿金额
        /// </summary>
        public decimal Comp_Money;
        /// <summary>
        /// 修改标识
        /// </summary>
        public bool Modified;
        /// <summary>
        /// 药品标志
        /// </summary>
        public int Drug_Flag;
        /// <summary>
        /// 医生站处方明细ID
        /// </summary>
        public int DocPrescDetailId;

        #region IPresDetail 成员

        public string BigItemCode
        {
            get
            {
                return BigitemCode;
            }
            set
            {
                BigitemCode = value;
            }
        }

        public decimal Money
        {
            get
            {
                return Tolal_Fee;
            }
            set
            {
                Tolal_Fee = value;
            }
        }

        #endregion
    }

    public struct FY_MZ_Patient
    {
        /// <summary>
        /// 前缀
        /// </summary>
        public string PerfChar;
        /// <summary>
        /// 病人发票号
        /// </summary>
        public string InvoiceNum;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatName;
        /// <summary>
        /// 病人年龄
        /// </summary>
        public string PatAge;
        /// <summary>
        /// 病人性别
        /// </summary>
        public string PatSex;
        /// <summary>
        /// 发药科室ID
        /// </summary>
        public int ExecDeptId;
    }

    public struct PrintInfo
    {
        /// <summary>
        /// 打印的模板文件名称
        /// </summary>
        public string PrintFileName;
        /// <summary>
        /// 打印参数
        /// </summary>
        public Hashtable PrintParameters;
        /// <summary>
        /// 打印数据
        /// </summary>
        public DataTable PrintData;
    }
}
