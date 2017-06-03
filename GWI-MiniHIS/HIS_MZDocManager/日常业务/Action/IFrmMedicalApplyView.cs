using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_MZDocManager.Action
{
    public interface IFrmMedicalApplyView
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
        /// 当前病人
        /// </summary>
        HIS.MZDoc_BLL.Patient CurrentPatient { get; set; }
        /// <summary>
        /// 当前医技申请类型
        /// </summary>
        HIS.MZDoc_BLL.Public.MedicalApplyType CurrentApplyType { get; }
        /// <summary>
        ///医技申请科室
        /// </summary>
        DataTable MecicalDept { set; }
        /// <summary>
        ///当前医技申请科室
        /// </summary>
        int CurrentMecicalDept { get; }
        /// <summary>
        ///医技申请类型
        /// </summary>
        DataTable MecicalClass { set; }
        /// <summary>
        ///当前医技申请类型
        /// </summary>
        int CurrentMecicalClass { get; }
        /// <summary>
        ///医技项目
        /// </summary>
        List<HIS.MZDoc_BLL.Medical_Order_Item> MecicalItem { set; }
        /// <summary>
        ///当前选中医技项目列表
        /// </summary>
        List<HIS.MZDoc_BLL.Medical_Order_Item> CurrentMecicalItems { get; }
        /// <summary>
        ///已选项目列表
        /// </summary>
        DataTable SelecedMecicalItems { get; set; }
        /// <summary>
        ///当前申请项目
        /// </summary>
        HIS.MZDoc_BLL.BaseMedical CurrentMedicalApply { get; set; }
        /// <summary>
        ///医技申请Grid当前行号
        /// </summary>
        int ApplyRowIndex { get; set; }
        /// <summary>
        /// 状态栏金额提示值
        /// </summary>
        string ItemMoneyStatus { set; }
        /// <summary>
        ///单元格颜色
        /// </summary>
        HIS.MZDoc_BLL.Public.PresColor ApplyCellColor { set; }
        /// <summary>
        /// 申请信息只读状态
        /// </summary>
        bool ApplyInfoReadOnly { set; }
        /// <summary>
        ///当前医技类型名称
        /// </summary>
        string CurrentMecicalClassName { get; }
        /// <summary>
        ///当前医技打印参数列表
        /// </summary>
        List<FormSite.PrintParameter> CurrentApplyPrintParameter { get; }
        /// <summary>
        /// 医技申请列表
        /// </summary>
        DataTable MedicalApplyList { get; set; }
        /// <summary>
        /// 医技申请列表中的选中行
        /// </summary>
        int MedicalApplyListRowIndex { get; }
        /// <summary>
        ///初始化
        /// </summary>
        void InitializeApply(DataSet _dataSet);
    }
}
