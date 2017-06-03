using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_MZDocManager.Action
{
    interface IDataInstall
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        User currentUser { get; }
        /// <summary>
        /// Grid当前数据源
        /// </summary>
        DataTable BindMainData { get; set; }
        /// <summary>
        /// 常用数据项实例
        /// </summary>
        HIS.MZDoc_BLL.IBaseCommon CommonSub { get; set; }
        /// <summary>
        /// Grid当前行号
        /// </summary>
        int RowIndex { get; set; }
        /// <summary>
        /// 界面状态
        /// </summary>
        HIS.MZDoc_BLL.Public.CurrentStatus CurrentStatus { get; set; }
        /// <summary>
        /// Grid只读状态
        /// </summary>
        bool DataGridViewReadOnly { set; }
    }
}
