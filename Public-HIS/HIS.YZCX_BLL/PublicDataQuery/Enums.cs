using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.YZCX_BLL
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
    /// 统计类型
    /// </summary>
    public enum StatClassType
    {
        /// <summary>
        /// 
        /// </summary>
        门诊发票分类 = 0 ,
        /// <summary>
        /// 
        /// </summary>
        经管核算分类 = 1 ,
        /// <summary>
        /// 
        /// </summary>
        统计大项目类 = 2,
        /// <summary>
        /// 
        /// </summary>
        收费支付类型 = 3,
        /// <summary>
        /// 
        /// </summary>
        门诊会计分类 = 4
    }
    /// <summary>
    /// 统计对象类型
    /// </summary>
    public enum StatObjctType
    {
        医生 = 0,
        科室 = 1,
        收费员 = 2,
        病人类型 =3
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

    public enum SearchPatientType
    {
        门诊号= 0,
        诊疗卡号 = 1
    }
    /// <summary>
    /// 报表样式
    /// </summary>
    public enum ReportStyle
    {
        /// <summary>
        /// 
        /// </summary>
        科目为标题列,
        /// <summary>
        /// 
        /// </summary>
        科目为明细行
    }

    public enum Total_Type
    {
        开方医生,
        主管医生,
        病人科室,
        执行科室
    }

    public enum Item_Type
    {
        发票项目 = 0,
        会计项目 = 1,
        核算项目 = 2
    }

    public enum SearchType
    {
        门诊 = 0,
        住院 = 1,
        全院 = 2
    }

}
