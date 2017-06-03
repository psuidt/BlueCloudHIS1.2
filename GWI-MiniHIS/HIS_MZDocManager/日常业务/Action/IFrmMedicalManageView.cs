using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GWMHIS.BussinessLogicLayer.Classes;
using System.Windows.Forms;

namespace HIS_MZDocManager.Action
{
    public interface IFrmMedicalManageView : IBasePresView
    {
        /// <summary>
        /// 当前病人
        /// </summary>
        HIS.MZDoc_BLL.Patient CurrentPatient { get; set; }
        /// <summary>
        /// 状态栏金额提示值
        /// </summary>
        string ItemMoneyStatus { set; }
        /// <summary>
        /// 当前病人就诊的诊断
        /// </summary>
        string CurrentPatientDiagnosis { get; set; }
        /// <summary>
        ///右键菜单只读状态
        /// </summary>
        bool MenuEnabled { set; }

        Control EMRControl { set; }
    }
}
