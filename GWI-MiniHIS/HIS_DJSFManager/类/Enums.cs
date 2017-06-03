using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_DJSFManager.类
{
    /// <summary>
    /// 处方状态 
    /// </summary>
    public enum PresStatus
    {
        /// <summary>
        /// 
        /// </summary>
        全部 = 0 ,
        /// <summary>
        /// 
        /// </summary>
        未收费 = 1 ,
        /// <summary>
        /// 
        /// </summary>
        已收费未发药 = 2 ,
        /// <summary>
        /// 
        /// </summary>
        已收费已发药 = 3 ,
        /// <summary>
        /// 
        /// </summary>
        已收费已退药 = 4
    }
    /// <summary>
    /// 处方类型
    /// </summary>
    public enum PrescriptionType
    {
        /// <summary>
        /// 
        /// </summary>
        西药 = 1 ,
        /// <summary>
        /// 
        /// </summary>
        中成药 = 2 ,
        /// <summary>
        /// 
        /// </summary>
        中草药 = 3 ,
        /// <summary>
        /// 
        /// </summary>
        治疗项目 = -1 ,
        /// <summary>
        /// 
        /// </summary>
        全部药品 = 4 ,
        /// <summary>
        /// 
        /// </summary>
        全部 = 0
    }
    /// <summary>
    /// 报表类型
    /// </summary>
    public enum ReportType
    {
        /// <summary>
        /// 
        /// </summary>
        门诊收入月报表 = 0 ,
        /// <summary>
        /// 
        /// </summary>
        医生科室收入月报表 = 1
    }
    /// <summary>
    /// 统计类型
    /// </summary>
    public enum StatType
    {
        /// <summary>
        /// 
        /// </summary>
        门诊发票分类 = 0 ,
        /// <summary>
        /// 
        /// </summary>
        经管核算分类 = 1
    }
    /// <summary>
    /// 统计时间类型
    /// </summary>
    public enum StatDateType
    {
        /// <summary>
        /// 
        /// </summary>
        统计日 = 0 ,
        /// <summary>
        /// 
        /// </summary>
        自然时间 = 1 ,
        /// <summary>
        /// 
        /// </summary>
        交账时间 = 2 ,
        /// <summary>
        /// 
        /// </summary>
        自定义时间 = 3
    }
    /// <summary>
    /// 医保类型
    /// </summary>
    public enum InsurType
    {
        /// <summary>
        /// 
        /// </summary>
        新农合
    }

    /// <summary>
    /// 门诊票据种类
    /// </summary>
    public enum OPDBillKind
    {
        /// <summary>
        /// 
        /// </summary>
        门诊收费发票 = 0 ,
        /// <summary>
        /// 
        /// </summary>
        门诊挂号发票 = 1,
        /// <summary>
        /// 
        /// </summary>
        所有发票 = 9
    }

    public enum OPDOperationType
    {
        门诊挂号 = 0,
        门诊收费 = 1
    }
    /// <summary>
    /// 结算方式
    /// </summary>
    public enum ChargeType
    {
        一张处方一次结算 = 0,
        多张处方一次结算 = 1
    }
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PayType
    {
        现金 = 0,
        POS机 = 1,
        医保刷卡 = 2,
        新农合记账 = 3
    }

    public enum SearchPatientType
    {
        门诊号= 0,
        诊疗卡号 = 1
    }
}
