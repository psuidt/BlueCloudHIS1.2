using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL.ObjectModel.BaseData;
using HIS.ZY_BLL.Dao.Report;
using HIS.ZY_BLL.Dao;

namespace HIS.ZY_BLL.Report
{
    public class PatientNum : BaseBLL
    {
        /// <summary>
        /// 统计报表(NAME,DATE,NUM)
        /// </summary>
        /// <param name="ViewType">0-按医生 1-按科室</param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DataSet GetRegisterReport(int ViewType, DateTime beginDate, DateTime endDate)
        {
            DataTable tbReg = GetRegisterData(beginDate, endDate);

            DataTable tbResultByName = new DataTable();
            tbResultByName.TableName = "TB_A";
            tbResultByName.Columns.Add("CODE", Type.GetType("System.String"));
            tbResultByName.Columns.Add("NAME", Type.GetType("System.String"));
            tbResultByName.Columns.Add("NUM", Type.GetType("System.Int32"));
            tbResultByName.Columns.Add("MONEY", Type.GetType("System.Decimal"));

            DataTable tbResultByDate = new DataTable();
            tbResultByDate.TableName = "TB_B";
            tbResultByDate.Columns.Add("DATE", Type.GetType("System.String"));
            tbResultByDate.Columns.Add("NUM", Type.GetType("System.Int32"));

            string fileName = "";
            if (ViewType == 0)
                fileName = "PRESDOCCODE";
            else
                fileName = "PRESDEPTCODE";

            for (int i = 0; i < tbReg.Rows.Count; i++)
            {
                string code = tbReg.Rows[i][fileName].ToString().Trim();
                DataRow[] drs = tbResultByName.Select("CODE='" + code + "'");
                if (drs.Length == 0)
                {
                    DataRow dr = tbResultByName.NewRow();
                    dr["CODE"] = code;
                    if (ViewType == 0)
                        dr["NAME"] = code == "" ? "未指定" : BaseNameFactory.GetName(baseNameType.用户名称, code);//HIS.MZ_BLL.BaseDataController.GetName(BaseDataCatalog.人员列表, Convert.ToInt32(code));//  PublicDataReader.GetEmployeeNameById(Convert.ToInt32(code));
                    else
                        dr["NAME"] = code == "" ? "未指定" : BaseNameFactory.GetName(baseNameType.科室名称, code);//HIS.MZ_BLL.BaseDataController.GetName(BaseDataCatalog.科室列表, Convert.ToInt32(code)); //PublicDataReader.GetDeptNameById(Convert.ToInt32(code));

                    dr["NUM"] = tbReg.Rows[i]["REGNUM"];
                    //dr["MONEY"] = tbReg.Rows[i]["MONEY"];
                    tbResultByName.Rows.Add(dr);
                }
                else
                {
                    drs[0]["NUM"] = Convert.ToInt32(tbReg.Rows[i]["REGNUM"]) + (Convert.IsDBNull(drs[0]["NUM"]) ? 0 : Convert.ToInt32(drs[0]["NUM"]));
                    //drs[0]["MONEY"] = Convert.ToInt32( tbReg.Rows[i]["REGNUM"] ) + ( Convert.IsDBNull( drs[0]["MONEY"] ) ? 0 : Convert.ToDecimal( drs[0]["MONEY"] ) );
                }
                //日期
                drs = tbResultByDate.Select("DATE='" + Convert.ToDateTime(tbReg.Rows[i]["PRESDATE"]).ToString("yyyy-MM-dd") + "'");
                if (drs.Length == 0)
                {
                    DataRow dr = tbResultByDate.NewRow();
                    dr["DATE"] = Convert.ToDateTime(tbReg.Rows[i]["PRESDATE"]).ToString("yyyy-MM-dd");
                    dr["NUM"] = tbReg.Rows[i]["REGNUM"];
                    tbResultByDate.Rows.Add(dr);
                }
                else
                {
                    int num = Convert.IsDBNull(drs[0]["NUM"]) ? 0 : Convert.ToInt32(drs[0]["NUM"]);
                    int num1 = Convert.IsDBNull(tbReg.Rows[i]["REGNUM"]) ? 0 : Convert.ToInt32(tbReg.Rows[i]["REGNUM"]);
                    num = num + num1;
                    drs[0]["NUM"] = num;
                }
            }

            DataSet dsResult = new DataSet();
            dsResult.Tables.Add(tbResultByName);
            dsResult.Tables.Add(tbResultByDate);

            return dsResult;
        }
        /// <summary>
        /// 住院入院人次统计信息
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns></returns>
        private static DataTable GetRegisterData(DateTime dateBegin, DateTime dateEnd)
        {
            Ireport repD = DaoFactory.GetObject<Ireport>(typeof(ReportDao));
            repD.oleDb = oleDb;
            return repD.GetRegisterPatientData(dateBegin, dateEnd);
        }


        
    }
}
