using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_MZDocManager.Action
{
    public interface IFrmPreMouldView : IBasePresView
    {
        /// <summary>
        /// 当前模板级别
        /// </summary>
        int MouldLevel { get; }
        /// <summary>
        /// 模板列表
        /// </summary>
        DataTable MouldList { set; }
        /// <summary>
        /// 当前模板
        /// </summary>
        HIS.MZDoc_BLL.PresMouldHead CurrentMould { get; }
        /// <summary>
        /// 当前模板树的选中节点Tag
        /// </summary>
        int SelectNodeTag { get; set; }
        /// <summary>
        /// 是否选定处方
        /// </summary>
        bool CheckPres { get; }
    }
}
