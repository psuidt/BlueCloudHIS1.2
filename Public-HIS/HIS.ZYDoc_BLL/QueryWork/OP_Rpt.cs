using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;

namespace HIS.ZYDoc_BLL.QueryWork
{
    /// <summary>
    /// 医生工作量统计
    /// </summary>
    public class OP_Rpt : BaseBLL
    {
        static DataTable data = new DataTable();
        static DataTable ItemName = new DataTable();

        #region 医生工作量统计
        /// <summary>
        /// 医生工作量统计
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="Btime"></param>
        /// <param name="Etime"></param>
        /// <returns></returns>
        public static DataTable QueryDocWork(int userid, DateTime Btime, DateTime Etime)
        {
            string strsql = @"select itemname as item_name, SUM(TOLAL_FEE)  as money from 
             (select patlistid,presdeptcode as currdeptcode,presdoccode as chargecode,itemtype,
              (select itemname from  
             (select a.code,b.item_name as itemname from {base_stat_item as a},{base_stat_zyfp as b} where   a.zyfp_code = b.code ) aa  where   aa.code = itemtype ) itemname ,
             tolal_fee from ( select * from {zy_presorder}   where  "
              + "  date(costdate) >= '" + Btime + "' and  date(costdate) <= '" + Etime + "' and charge_flag = 1 ) as tolal_fee) as d  where d.chargecode='" + userid.ToString() + "' group by d.itemname";
            DataTable dt = oleDb.GetDataTable(strsql);
            return dt;
        }
        #endregion

        #region 病人相关信息统计
        /// <summary>
        /// 病人相关信息统计　
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="Btime"></param>
        /// <param name="Etime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DataTable FeeReport(int userid, DateTime? Btime, DateTime? Etime, string type)
        {
            string strsql = "";
            string strwhere = "";
            string date = " ";
            string  inhodays="";
            if (Btime != null && Etime != null)
            {
                date = "  and date(b.outdate) >= '" + Btime + "' and  date(b.outdate) <= '" + Etime + "'";
                inhodays = "days(b.outdate) - days(b.curedate)";
            }
            else
            {
                string s = " b.pattype ='2' or b.pattype='7'";
                date = " and " + "(" + s + ")";
                inhodays = "days(current timestamp)-days(b.curedate)";
            }
            #region
            if (type == "发票项目")
            {
                ItemName = BindEntity<HIS.Model.BASE_STAT_ZYFP>.CreateInstanceDAL(oleDb).GetList("", Tables.base_stat_zyfp.ITEM_NAME);
                strwhere = " select a.code,b.item_name as itemname from { base_stat_item as a }, {base_stat_zyfp as b } where   a.zyfp_code = b.code ";
            }
            if (type == "会计项目")
            {
                ItemName = BindEntity<HIS.Model.BASE_STAT_ZYKJ>.CreateInstanceDAL(oleDb).GetList("", Tables.base_stat_zykj.ITEM_NAME);
                strwhere = " select a.code,b.item_name as itemname from { base_stat_item as a } , { base_stat_zykj as b } where   a.zykj_code = b.code";
            }
            if (type == "核算项目")
            {
                ItemName = BindEntity<HIS.Model.BASE_STAT_HS>.CreateInstanceDAL(oleDb).GetList("", Tables.base_stat_hs.ITEM_NAME);
                strwhere = " select a.code,b.item_name as itemname from { base_stat_item as a } ,{ base_stat_hs as b } where   a.hs_code = b.code";
            }
            if (type == "大项目")
            {
                ItemName = BindEntity<HIS.Model.BASE_STAT_ITEM>.CreateInstanceDAL(oleDb).GetList("", Tables.base_stat_item.ITEM_NAME);
                strwhere = " select a.code,a.item_name as itemname from { base_stat_item as a } ";
            }
            strsql = @"select patname,curedate,outdate,inhostdays,sum(tolal_fee) as money, itemname,patlistid from 
           (
             select itemtype,
            (select itemname from ( " + strwhere + ") aa  where   aa.code = itemtype ) as itemname , "
            + " patname as patname,a.patlistid as patlistid,curedate as curedate,outdate as outdate,"+inhodays+" as inhostdays,tolal_fee "
            + " from { zy_presorder as a } left outer join "
            + " { zy_patlist as b} on a.patlistid=b.patlistid  "
            + " left outer join { patientinfo as c } on  b.patid=c.patid where a.charge_flag=1  " + date + "   and b.curedoccode='" + userid.ToString() + "')d"
            + " group by patlistid,patname,curedate,outdate,inhostdays,d.itemname";
            #endregion
            CreateColumn();
            DataTable dt = oleDb.GetDataTable(strsql);
            DataRow row;
            int j;
            decimal sum;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = data.NewRow();
                sum = 0;
                for (int col = 0; col < 4; col++)
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
                row["入院时间"] = Convert.ToDateTime(row["入院时间"]).ToShortDateString();
                data.Rows.Add(row);
            }
            row = data.NewRow();
            row[0] = "病人总计：";
            row[1] = data.Rows.Count + "人";
            row[3] = "费用总计:";
            for (int col = 4; col < data.Columns.Count; col++)
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
        #endregion

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
            column.ColumnName = "入院时间";
            data.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = "出院时间";
            data.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "在院天数";
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
