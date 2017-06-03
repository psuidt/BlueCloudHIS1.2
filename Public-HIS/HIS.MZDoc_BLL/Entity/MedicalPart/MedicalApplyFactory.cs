using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.MZDoc_BLL;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 医技申请构造工厂
    /// </summary>
    public class MedicalApplyFactory
    {        
        /// <summary>
        /// 构造医技申请对象实例
        /// </summary>
        /// <param name="medicalApplyType">医技申请类型</param>
        /// <returns></returns>
        public static BaseMedical CreateMedicalApplyObject(HIS.MZDoc_BLL.Public.MedicalApplyType medicalApplyType)
        {
            switch (medicalApplyType)
            {
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技化验申请:
                    return new HIS.MZDoc_BLL.MedicalAssay();
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技检查申请:
                    return new HIS.MZDoc_BLL.MedicalExamine();
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技治疗申请:
                    return new HIS.MZDoc_BLL.MedicalTreat();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 构造医技申请对象实例
        /// </summary>
        /// <param name="medicalApplyType">医技申请类型</param>
        /// <param name="row">医技申请数据行</param>
        /// <returns></returns>
        public static BaseMedical CreateMedicalApplyObject(HIS.MZDoc_BLL.Public.MedicalApplyType medicalApplyType, DataRow row)
        {
            switch (medicalApplyType)
            {
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技化验申请:
                    return (HIS.MZDoc_BLL.MedicalAssay)Public.Function.DataRowToObject<HIS.MZDoc_BLL.MedicalAssay>(row);
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技检查申请:
                    return (HIS.MZDoc_BLL.MedicalExamine)Public.Function.DataRowToObject<HIS.MZDoc_BLL.MedicalExamine>(row);
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技治疗申请:
                    return (HIS.MZDoc_BLL.MedicalTreat)Public.Function.DataRowToObject<HIS.MZDoc_BLL.MedicalTreat>(row);
                default:
                    return null;
            }
        }

        /// <summary>
        /// 构造医技申请对象实例
        /// </summary>
        /// <param name="medicalApplyType">医技申请类型</param>
        /// <param name="rows">医技申请数据行</param>
        /// <returns></returns>
        public static IList CreateMedicalApplyObject(HIS.MZDoc_BLL.Public.MedicalApplyType medicalApplyType, DataRow[] rows)
        {
            switch (medicalApplyType)
            {
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技化验申请:
                    return (IList)Public.Function.DataRowsToList<MedicalAssay>(rows);
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技检查申请:
                    return (IList)Public.Function.DataRowsToList<MedicalExamine>(rows);
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技治疗申请:
                    return (IList)Public.Function.DataRowsToList<MedicalTreat>(rows);
                default:
                    return null;
            }
        }

        /// <summary>
        /// 构造医技申请对象实例
        /// </summary>
        /// <param name="medicalApplyType">医技申请类型</param>
        /// <param name="table">医技申请数据表</param>
        /// <returns></returns>
        public static IList CreateMedicalApplyObject(HIS.MZDoc_BLL.Public.MedicalApplyType medicalApplyType, DataTable table)
        {
            switch (medicalApplyType)
            {
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技化验申请:
                    return (IList)Public.Function.DataTableToList<MedicalAssay>(table);
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技检查申请:
                    return (IList)Public.Function.DataTableToList<MedicalExamine>(table);
                case HIS.MZDoc_BLL.Public.MedicalApplyType.医技治疗申请:
                    return (IList)Public.Function.DataTableToList<MedicalTreat>(table);
                default:
                    return null;
            }
        }
    }
}
