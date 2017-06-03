using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;

namespace HIS.SS_BLL
{
   public  class SsReport: BaseBLL
    {
       static DataTable ItemName = new DataTable();
       static DataTable data = new DataTable();
       public static DataTable GetReport(int deptid, DateTime? Btime, DateTime? Etime, string type)
       {
           string strsql = "";
           string strwhere = "";          
           #region
           if (type == "发票项目")
           {
               ItemName = BindEntity<HIS.Model.BASE_STAT_ZYFP>.CreateInstanceDAL(oleDb).GetList("", Tables.base_stat_zyfp.ITEM_NAME);
               strwhere = " select a.code,b.item_name as itemname from base_stat_item as a , base_stat_zyfp as b where   a.zyfp_code = b.code ";
           }
           if (type == "会计项目")
           {
               ItemName = BindEntity<HIS.Model.BASE_STAT_ZYKJ>.CreateInstanceDAL(oleDb).GetList("", Tables.base_stat_zykj.ITEM_NAME);
               strwhere = " select a.code,b.item_name as itemname from base_stat_item as a , base_stat_zykj as b where   a.zykj_code = b.code";
           }
           if (type == "核算项目")
           {
               ItemName = BindEntity<HIS.Model.BASE_STAT_HS>.CreateInstanceDAL(oleDb).GetList("", Tables.base_stat_hs.ITEM_NAME);
               strwhere = " select a.code,b.item_name as itemname from base_stat_item as a , base_stat_hs as b where   a.hs_code = b.code";
           }
           if (type == "大项目")
           {
               ItemName = BindEntity<HIS.Model.BASE_STAT_ITEM>.CreateInstanceDAL(oleDb).GetList("", Tables.base_stat_item.ITEM_NAME);
               strwhere = " select a.code,a.item_name as itemname from base_stat_item as a";
           }

           strsql = @" select patname,deptname,'' as oper_name,sum(tolal_fee) as money, itemname,patlistid from 
                     (
                      select itemtype,
                      (select itemname from (  select a.code,b.item_name as itemname from base_stat_item as a , base_stat_zyfp as b where   a.zyfp_code = b.code ) aa  where   aa.code = itemtype ) as itemname ,
                       patname as patname,a.patlistid as patlistid,b.currdeptcode as deptname, tolal_fee 
                    from
                     zy_presorder a  
                     left outer join  zy_patlist b on a.patlistid=b.patlistid   
                     left outer join patientinfo c on  b.patid=c.patid  
                     
                     where a.charge_flag=1  and date(a.presdate)>='"+Btime.Value+@"'and date(a.presdate)<='"+Etime.Value+@"'  and a.presdeptcode='"+deptid.ToString()+@"'  and order_id=0 
                      )d group by patlistid,patname,deptname,d.itemname";
           #endregion
           CreateColumn();
           DataTable dt = oleDb.GetDataTable(strsql);
           DataRow row;
           int j;
           decimal sum;
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               dt.Rows[i]["deptname"] = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(dt.Rows[i]["deptname"].ToString());
               row = data.NewRow();
               sum = 0;
               for (int col = 0; col < 3; col++)
               {
                   row[col] = dt.Rows[i][col];
               }
               for (int k = 5; k < data.Columns.Count; k++)
               {
                   if (dt.Rows[i]["itemname"].ToString().Trim() == data.Columns[k].ColumnName.ToString().Trim())
                   {
                       row[data.Columns[k].ColumnName] = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[i]["money"]).ToString("0.00"));
                       sum = sum + Convert.ToDecimal(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dt.Rows[i]["money"].ToString(), "0"));
                       break;
                   }
               }
               for (j = i + 1; j < dt.Rows.Count; j++)
               {
                   if (dt.Rows[j]["patlistid"].ToString().Trim() == dt.Rows[i]["patlistid"].ToString().Trim()) // 如果是同一个病人
                   {
                       for (int k = 5; k < data.Columns.Count; k++)
                       {
                           if (dt.Rows[j]["itemname"].ToString().Trim() == data.Columns[k].ColumnName.ToString().Trim())
                           {
                               row[data.Columns[k].ColumnName] = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[j]["money"]).ToString("0.00"));
                               sum = sum + Convert.ToDecimal(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(dt.Rows[j]["money"].ToString(), "0"));
                               break;
                           }
                       }
                   }
                   else
                   {
                       break;
                   }
               }
               i = j - 1;
               row["总费用"] = Convert.ToDecimal(sum.ToString("0.00"));              
               data.Rows.Add(row);
           }
           row = data.NewRow();
           row[0] = "病人总计：";
           row[1] = data.Rows.Count + "人";
           row[2] = "费用总计:";
           for (int col = 3; col < data.Columns.Count; col++)
           {
               decimal fee = 0;
               for (int i = 0; i < data.Rows.Count; i++)
               {
                   fee = fee + Convert.ToDecimal(HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(data.Rows[i][col], "0"));
               }
               row[col] = fee;
           }
           data.Rows.Add(row);
           return data;
       }
      

        #region  动态创建列
        /// <summary>
        /// 动态创建列
        /// </summary>
        private static void CreateColumn()
        {
            data.Rows.Clear();
            data.Columns.Clear();
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "病人姓名";
            data.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "病人科室";
            data.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "手术名称";
            data.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "总费用";
            data.Columns.Add(column);

            for (int i = 0; i < ItemName.Rows.Count; i++)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = ItemName.Rows[i]["ITEM_NAME"].ToString();
                data.Columns.Add(column);
            }
        }
        #endregion
    }
}
