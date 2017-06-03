using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_MZDocManager.Action
{
    public interface IBasePresView
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
        /// Grid当前行号
        /// </summary>
        int RowIndex { get; set; }
        /// <summary>
        /// Grid数据源
        /// </summary>
        DataTable BindPresDataSource { get; set; }
        /// <summary>
        /// 单元格颜色
        /// </summary>
        HIS.MZDoc_BLL.Public.PresColor CellColor { set; }
        /// <summary>
        /// 处方列序号
        /// </summary>
        HIS.MZDoc_BLL.Public.PresColumnIndex ColumnIndex { get; }
        /// <summary>
        /// 单元格只读状态
        /// </summary>
        HIS.MZDoc_BLL.Public.PresCellReadOnly CellReadOnly { set; }
        /// <summary>
        /// 分组开始行的索引
        /// </summary>
        int GroupStartRowIndex { get; set; }
        /// <summary>
        /// 当前绘制行号
        /// </summary>
        int PaintRowIndex { get; set; }
        /// <summary>
        /// 单元格矩形
        /// </summary>
        System.Drawing.Rectangle GridCellBounds { get; }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="_dataSet">基础数据集</param>
        void Initialize(DataSet _dataSet);
        /// <summary>
        ///刷新处方
        /// </summary>
        void RefreshPres();
        /// <summary>
        /// 药房科室数据
        /// </summary>
        DataTable DrugDeptDic { set; }
        /// <summary>
        /// 当前选择的药房科室Id
        /// </summary>
        string SelectedDrugDeptId { get; }
    }
}
