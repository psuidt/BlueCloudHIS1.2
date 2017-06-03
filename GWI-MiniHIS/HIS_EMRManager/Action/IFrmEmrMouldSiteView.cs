using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_EMRManager
{
    /// <summary>
    /// 病历模板设置界面接口
    /// </summary>
    internal interface IFrmEmrMouldSiteView
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        User currentUser { get; }
        /// <summary>
        /// 当前科室
        /// </summary>
        Deptment currentDept { get; }
        /// <summary>
        /// 当前模板级别
        /// </summary>
        int CurrentMouldLevel { get; }
        /// <summary>
        /// 当前元素模板级别
        /// </summary>
        int CurrentElementMouldLevel { get; }
        /// <summary>
        /// 主要元素
        /// </summary>
        DataTable ChiefElement { get; set; }
        /// <summary>
        /// 元素列表
        /// </summary>
        DataTable ElementList { set; }
        /// <summary>
        /// 模板列表
        /// </summary>
        DataTable MouldList { set; }
        /// <summary>
        /// 元素模板列表
        /// </summary>
        DataTable ElementMouldList { set; }
        /// <summary>
        /// 当前主要元素
        /// </summary>
        HIS.EMR_BLL.EmrElement CurrentChiefElement { get; }
        /// <summary>
        /// 当前模板
        /// </summary>
        HIS.EMR_BLL.EmrMould CurrentMould { get; set; }
        /// <summary>
        /// 当前元素
        /// </summary>
        HIS.EMR_BLL.EmrElement CurrentElement { get; }
        /// <summary>
        /// 当前元素模板
        /// </summary>
        HIS.EMR_BLL.EmrElementMould CurrentElementMould { get; }
    }
}
