using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MZ_BLL;
using System.Data;

namespace HIS_MZManager.HJSF
{
    public interface IFrmBudgeBalance
    {
        /// <summary>
        /// 窗体行为：0 - 门诊收费 1 - 门诊划价 2 - 药房划价
        /// </summary>
        int FormAction
        {
            get;
        }
        /// <summary>
        /// 当前用户的EMPLOYEEID
        /// </summary>
        int CurrentEmployeeId
        {
            get;
        
        }
        /// <summary>
        /// 当前登陆科室
        /// </summary>
        int CurrentLoginDeptId
        {
            get;
      
        }
        /// <summary>
        /// 病人对象
        /// </summary>
        GWI.HIS.Windows.Controls.IOutPatient Patient
        {
            get;
            set;
        }
        /// <summary>
        /// 处方医生ID
        /// </summary>
        int PrescDoctorId
        {
            get;
            set;
        }
        /// <summary>
        /// 医生科室ID
        /// </summary>
        int DoctorDeptId
        {
            get;
            set;
        }
        /// <summary>
        /// 发票前缀字母
        /// </summary>
        string InvoicePerfChar
        {
            get;
            set;
        }
        /// <summary>
        /// 当前发票号
        /// </summary>
        string CurrentInvoiceNo
        {
            get;
            set;
        }
        /// <summary>
        /// 所有处方总金额
        /// </summary>
        decimal AllPrescriptionTotalFee
        {
            get;
            set;
        }
        /// <summary>
        /// 处方数据
        /// </summary>
        DataTable Prescriptions
        {
            get;
            set;
        }
        /// <summary>
        /// 从网格获得处方表结构
        /// </summary>
        /// <returns></returns>
        DataTable GetPrescDataStruct();
    }


    public interface IFrmOutPatient
    {
        /// <summary>
        /// 窗体行为(0-新增病人 1-修改病人信息 2-查找病人)
        /// </summary>
        int FormAction
        {
            get;
            set;
        }
        /// <summary>
        /// 病人对象
        /// </summary>
        GWI.HIS.Windows.Controls.IOutPatient Patient
        {
            get;
            set;
        }
        /// <summary>
        /// 查询结果列表
        /// </summary>
        DataTable SearchResultList
        {
            get;
            set;
        }
        int SelectedPatientId
        {
            get;

        }
    }
}
