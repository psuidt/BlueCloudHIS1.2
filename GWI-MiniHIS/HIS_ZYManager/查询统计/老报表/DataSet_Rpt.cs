using System;
using System.Data;
using System.Collections.Generic;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS;

namespace HIS_ZYManager
{
    
    
    public partial class DataSet_Rpt 
    {
        public void DeptCostTotal_Rpt_AddCol(HIS.ZY_BLL.CostItemType cit)
        {
            DataTable dt = null;

            HIS.ZY_BLL.ExecDeptAndUserReport edau = new HIS.ZY_BLL.ExecDeptAndUserReport(); 
            edau.costItemType = cit;
            dt = edau.GetAddCol;

            DataColumn dc = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dc = new DataColumn(dt.Rows[i][0].ToString(), typeof(string), null, MappingType.Element);
                DeptCostTotal_Rpt.Columns.Add(dc);
            }
        }

        public void PatCostTotal_Rpt_AddCol(HIS.ZY_BLL.CostItemType cit)
        {
            DataTable dt = null;

            HIS.ZY_BLL.PatDeptAndPatientReport pdapr = new HIS.ZY_BLL.PatDeptAndPatientReport();
            pdapr.costItemType = cit;
            dt = pdapr.GetAddCol;

            DataColumn dc = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dc = new DataColumn(dt.Rows[i][0].ToString(), typeof(string), null, MappingType.Element);
                PatCostTotal_Rpt.Columns.Add(dc);
            }
        }
       
        /// <summary>
        /// 执行科室医生收入统计
        /// </summary>
        /// <param name="type">0按执行科室统计1按开发科室统计</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <param name="cis">统计方式</param>
        /// <param name="cit">统计类型</param>
        public void BindDeptItemData(int type,DateTime Bdate, DateTime Edate, HIS.ZY_BLL.CostItemStyle cis, HIS.ZY_BLL.CostItemType cit)
        {
            try
            {

                HIS.ZY_BLL.ReportStat reportData = null;
                if (type == 0)
                    reportData = new HIS.ZY_BLL.ExecDeptAndUserReport();
                else if (type == 1)
                    reportData = new HIS.ZY_BLL.PresDeptAndDocReport();
                else if (type == 2)
                    reportData = new HIS.ZY_BLL.PresDocReport();

                reportData.Bdate = Bdate;
                reportData.Edate = Edate;
                reportData.costItemType = cit;
                reportData.costItemStyle = cis;

                DataTable[] dt = reportData.GetReportData();

                DataTable dtFee = dt[0];//得到所有费用
                DataTable dtDept = dt[1];//得到统计的科室
                decimal SumDec = 0;
                for (int i = 0; i < dtDept.Rows.Count; i++)//循环所有科室
                {
                    DataRow dr = DeptCostTotal_Rpt.NewRow();

                   

                    decimal dec = 0;

                    if (type != 2)
                    {
                        dr[0] = BaseData.GetDeptName(dtDept.Rows[i][0].ToString());
                        dr[1] = BaseData.GetUserName(dtDept.Rows[i][1].ToString());// add
                        for (int m = 3; m < DeptCostTotal_Rpt.Columns.Count; m++)//循环费用列
                        {
                            for (int j = 0; j < dtFee.Rows.Count; j++)//循环所有费用
                            {
                                if (dtDept.Rows[i][0].ToString() == dtFee.Rows[j]["CURRDEPTCODE"].ToString() && dtDept.Rows[i][1].ToString() == dtFee.Rows[j]["CHARGECODE"].ToString())
                                {
                                    if (dtFee.Rows[j]["itemname"].ToString() == DeptCostTotal_Rpt.Columns[m].ColumnName)
                                    {
                                        dec += Convert.ToDecimal(dtFee.Rows[j]["TOLAL_FEE"]);
                                        dr[m] = Convert.ToDecimal(dtFee.Rows[j]["TOLAL_FEE"]).ToString("0.00");
                                        continue;//找到对应费用项目退出循环
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        dr[0] = "";//BaseData.GetDeptName(dtDept.Rows[i][0].ToString());
                        dr[1] = BaseData.GetUserName(dtDept.Rows[i][0].ToString());// add
                        for (int m = 3; m < DeptCostTotal_Rpt.Columns.Count; m++)//循环费用列
                        {
                            for (int j = 0; j < dtFee.Rows.Count; j++)//循环所有费用
                            {
                                if (dtDept.Rows[i][0].ToString() == dtFee.Rows[j]["CHARGECODE"].ToString())
                                {
                                    if (dtFee.Rows[j]["itemname"].ToString() == DeptCostTotal_Rpt.Columns[m].ColumnName)
                                    {
                                        dec += Convert.ToDecimal(dtFee.Rows[j]["TOLAL_FEE"]);
                                        dr[m] = Convert.ToDecimal(dtFee.Rows[j]["TOLAL_FEE"]).ToString("0.00");
                                        continue;//找到对应费用项目退出循环
                                    }
                                }
                            }
                        }
                    }

                    SumDec += dec;
                    dr[2] = dec.ToString("0.00");

                    DeptCostTotal_Rpt.Rows.Add(dr);
                }


                //添加合计
                if (dtDept.Rows.Count > 0)
                {
                    DataRow dr = DeptCostTotal_Rpt.NewRow();
                    dr[0] = "";
                    dr[1] = "合计";
                    dr[2] = SumDec.ToString("0.00");//合计全部
                    for (int m = 3; m < DeptCostTotal_Rpt.Columns.Count; m++)
                    {
                        decimal dec = 0;
                        for (int n = 0; n < DeptCostTotal_Rpt.Rows.Count; n++)
                        {
                            dec += Convert.ToDecimal(DeptCostTotal_Rpt.Rows[n][m] == DBNull.Value ? 0 : DeptCostTotal_Rpt.Rows[n][m]);
                        }
                        dr[m] = dec.ToString("0.00");//合计每个项目
                    }
                    DeptCostTotal_Rpt.Rows.Add(dr);
                }

            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 绑定统计数据
        /// </summary>
        /// <param name="IsIn">在院true</param>
        /// <param name="CureDeptCode">科室代码</param>
        /// <param name="Bdate">开始日期</param>
        /// <param name="Edate">结束日期</param>
        /// <param name="cis">统计方式</param>
        /// <param name="cit">统计类型</param>
        public void BindPatItemData(bool IsIn, string CureDeptCode, DateTime? Bdate, DateTime? Edate, HIS.ZY_BLL.CostItemStyle cis, HIS.ZY_BLL.CostItemType cit)
        {  
            try
            {
                HIS.ZY_BLL.PatDeptAndPatientReport reportData = new HIS.ZY_BLL.PatDeptAndPatientReport();
                reportData.Bdate = Bdate;
                reportData.Edate = Edate;
                reportData.costItemType = cit;
                reportData.costItemStyle = cis;
                reportData.IsInHis = IsIn;
                reportData.CureDeptCode = CureDeptCode;

                DataTable[] dt = reportData.GetReportData();
                    
                DataTable dtFee = dt[0];
                DataTable dtDept = dt[1];
                
                
                decimal SumDec = 0;
                for (int i = 0; i < dtDept.Rows.Count; i++)//循环所有科室
                {
                    DataRow dr = PatCostTotal_Rpt.NewRow();
                    dr[0] = BaseData.GetDeptName(dtDept.Rows[i][0].ToString());
                    dr[1] = "";
                    dr[2] = BaseData.GetPatName(Convert.ToInt32(dtDept.Rows[i][1]));
                    decimal dec = 0;
                    for (int m = 4; m < PatCostTotal_Rpt.Columns.Count; m++)//循环费用列
                    {
                        for (int j = 0; j < dtFee.Rows.Count; j++)//循环所有费用
                        {
                            if (dtDept.Rows[i][0].ToString() == dtFee.Rows[j][0].ToString() && dtDept.Rows[i][1].ToString() == dtFee.Rows[j][1].ToString())
                            {
                                if (dtFee.Rows[j]["itemname"].ToString() == PatCostTotal_Rpt.Columns[m].ColumnName)
                                {
                                    dec += Convert.ToDecimal(dtFee.Rows[j]["TOLAL_FEE"]);
                                    dr[m] = Convert.ToDecimal(dtFee.Rows[j]["TOLAL_FEE"]).ToString("0.00");
                                    continue;//找到对应费用项目退出循环
                                }
                            }
                        }

                    }
                    SumDec += dec;
                    dr[3] = dec.ToString("0.00");
                    PatCostTotal_Rpt.Rows.Add(dr);
                }
                //添加合计
                if (dtDept.Rows.Count > 0)
                {
                    DataRow dr = PatCostTotal_Rpt.NewRow();
                    dr[0] = "合计";
                    dr[1] = "";
                    dr[2] = "";
                    dr[3] = SumDec.ToString("0.00");//合计全部
                    for (int m = 4; m < PatCostTotal_Rpt.Columns.Count; m++)
                    {
                        decimal dec = 0;
                        for (int n = 0; n < PatCostTotal_Rpt.Rows.Count; n++)
                        {
                            dec += Convert.ToDecimal(PatCostTotal_Rpt.Rows[n][m] == DBNull.Value ? 0 : PatCostTotal_Rpt.Rows[n][m]);
                        }
                        dr[m] = dec.ToString("0.00");//合计每个项目
                    }
                    PatCostTotal_Rpt.Rows.Add(dr);
                }
                
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
