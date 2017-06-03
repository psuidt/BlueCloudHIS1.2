using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace HIS_EMRManager.Public
{
    /// <summary>
    /// 外部接口
    /// </summary>
    public class ExternalInterFace
    {
        /// <summary>
        /// 获得病人的病程记录列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static DataTable GetDiseaseCourseRecord(EMRRecordInfo info)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", Type.GetType("System.String"));
            table.Columns.Add("Value", Type.GetType("System.String"));
            DataTable tmpTable = HIS.EMR_BLL.OP_EmrRecord.GetDiseaseCourseRecord(info.Patid, info.PatListid, Public.PublicStaticFunction.GetEMRTypeCode(info.RecordType));
            if (tmpTable != null)
            {

                foreach (DataRow row in tmpTable.Rows)
                {
                    DataRow newRow = table.NewRow();
                    newRow["Name"] = row["RECORDCREATEDATE"];
                    newRow["Value"] = row["RECORDID"];
                    table.Rows.Add(newRow);
                }
            }
            return table;
        }

        public static Control GetEMRRecord(EMRRecordInfo info,string recordTag)
        {
            PublicStaticFunction.CurrentEmployeeId = info.CreateEmpId;
            PublicStaticFunction.CurrentDeptId = info.CreateDeptId;
            return new EMRControlPanel(info,Convert.ToInt32(recordTag));
        }

        /// <summary>
        /// 获得病历记录
        /// </summary>
        /// <param name="info">病历信息</param>
        /// <returns></returns>
        public static Control GetEMRRecord(EMRRecordInfo info)
        {
            PublicStaticFunction.CurrentEmployeeId = info.CreateEmpId;
            PublicStaticFunction.CurrentDeptId = info.CreateDeptId;
            return new EMRControlPanel(info);
        }

        /// <summary>
        /// 添加病历记录
        /// </summary>
        /// <param name="info">病历信息</param>
        /// <returns></returns>
        public static Control AddEMRRecord(EMRRecordInfo info)
        {
            PublicStaticFunction.CurrentEmployeeId = info.CreateEmpId;
            PublicStaticFunction.CurrentDeptId = info.CreateDeptId;
            return new EMRControlPanel(info,true);
        }
    }
}
