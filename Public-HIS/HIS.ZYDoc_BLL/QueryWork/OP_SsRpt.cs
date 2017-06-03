using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using HIS.SYSTEM.Core;
using HIS.BLL;

namespace HIS.ZYDoc_BLL.QueryWork
{
    public class OP_SsRpt:BaseBLL
    {
        /// <summary>
        /// 获得手术申请
        /// </summary>
        /// <param name="sign">0=未安排 1=已安排 2=已完成 3＝已取消</param>
        /// <returns></returns>
        public static DataTable GetSsTable(int sign,DateTime ? Bdate,DateTime ? Edate)
        {
            string strWhere = "";           
            if (sign == 0)
            {
                strWhere = Tables.ss_apply.ARRANGE_FLAG + oleDb.EuqalTo() + 0 + oleDb.And() + Tables.ss_apply.DELETE_FLAG + oleDb.EuqalTo() + 0;                                
            }
            if (sign == 1)
            {
                strWhere =@" apply_id  in ( select apply_id from ss_arrange where finish_flag=0) 
                           and arrange_flag=1 and workid="+HIS.SYSTEM.Core.EntityConfig.WorkID+" ";              
            }
            if (sign == 2)
            {
                strWhere = @" apply_id  in ( select apply_id from ss_arrange where finish_flag=1) 
                           and arrange_flag=1 and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + " ";                
            }
            if (sign == 3)
            {
                strWhere = Tables.ss_apply.DELETE_FLAG + oleDb.EuqalTo() + 1+oleDb.And()+Tables.ss_apply.ARRANGE_FLAG+oleDb.EuqalTo()+0;               
            }
            strWhere += oleDb.And()+ Tables.ss_apply.APPLY_DATE + oleDb.GreaterThanAndEqualTo() + "'" + Bdate.Value.Date + "'" + oleDb.And() +
                Tables.ss_apply.APPLY_DATE + oleDb.LessThanAndEqualTo() + "'" + Edate.Value.Date.AddDays(1)+ "'";
            List<HIS.Model.SS_APPLY> listss = BindEntity<HIS.Model.SS_APPLY>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            DataTable ss = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(listss);
            DataColumn column = new DataColumn();
            column.ColumnName = "cureno";
            column.DataType = System.Type.GetType("System.String");
            ss.Columns.Add(column);

             column = new DataColumn();
            column.ColumnName = "patsex";
            column.DataType = System.Type.GetType("System.String");
            ss.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "patname";
            column.DataType = System.Type.GetType("System.String");
            ss.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "operadocname";
            column.DataType = System.Type.GetType("System.String");
            ss.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "applydocname";
            column.DataType = System.Type.GetType("System.String");
            ss.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "ssty";
            column.DataType = System.Type.GetType("System.String");
            ss.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "mzty";
            column.DataType = System.Type.GetType("System.String");
            ss.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "sq_diag";
            column.DataType = System.Type.GetType("System.String");
            ss.Columns.Add(column);

            for (int i = 0; i < listss.Count; i++)
            {
                ss.Rows[i]["cureno"] = listss[i].Zy_Patlist.CureNo;
                ss.Rows[i]["patname"] = listss[i].Zy_Patlist.PatientInfo.PatName;
                ss.Rows[i]["operadocname"] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(listss[i].OPERA_DOC.ToString());
                ss.Rows[i]["applydocname"] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(listss[i].APPLY_DOC.ToString());
                ss.Rows[i]["sq_diag"] = listss[i].Zy_Patlist.DiseaseName;
                ss.Rows[i]["patsex"] = listss[i].Zy_Patlist.PatientInfo.PatSex;
                if (listss[i].OPERA_CONSENT.ToString() == "1")
                {
                    ss.Rows[i]["ssty"] = "是";
                }
                else
                {
                    ss.Rows[i]["ssty"] = "否";
                }
                if (listss[i].ANESTH_CONSENT.ToString() == "1")
                {
                    ss.Rows[i]["mzty"] = "是";
                }
                else
                {
                    ss.Rows[i]["mzty"] = "否";
                }
            }
            return ss;
        }


    }
}
