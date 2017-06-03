using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.Model;

namespace HIS.YP_BLL
{
   
    /// <summary>
    /// 账目查询对象
    /// </summary>
    public abstract class AccountQuery:HIS.SYSTEM.Core.BaseBLL
    {
        /// <summary>
        /// 查询最后一次月结历史信息
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>月结历史信息</returns>
        abstract public YP_AccountHis GetLastAccountHis(int deptId);

        /// <summary>
        /// 获取指定药剂科室在指定时间点对应会计年份和月份
        /// </summary>
        /// <param name="regTime">指定时间</param>
        /// <param name="accountYear">会计年份</param>
        /// <param name="accountMonth">会计月份</param>
        /// <param name="deptId">药剂科室ID</param>
        abstract public void GetAccountTime(DateTime regTime, ref int accountYear, ref int accountMonth, int deptId);

        /// <summary>
        /// 查询药品明细分类账
        /// </summary>
        /// <param name="AccountYear">会计年</param>
        /// <param name="AccountMonth">会计余额</param>
        /// <param name="MakerDicID">药品厂家典ID</param>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>药品明细分类账信息</returns>
        abstract public DataTable QueryOrderAccount(int AccountYear, int AccountMonth, int MakerDicID, int deptId);

        /// <summary>
        /// 获取药品台帐金额信息（月结使用）
        /// </summary>
        /// <param name="drugType">药品类型</param>
        /// <param name="actYear">会计年</param>
        /// <param name="actMonth">会计月</param>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <returns>药品台帐金额信息</returns>
        abstract public DataTable GetOrderAccount(int drugType, int actYear, int actMonth, int deptId);

        /// <summary>
        /// 获取药品月结历史信息
        /// </summary>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>药品月结历史记录表</returns>
        abstract public DataTable GetActHisList(int deptId);

        /// <summary>
        /// 查询进销存帐
        /// </summary>
        /// <param name="drugType">药品类型</param>
        /// <param name="accountYear">会计年</param>
        /// <param name="accountMonth">会计月</param>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>进销存帐信息</returns>
        public DataTable QueryDrugIOS(string drugType, int accountYear, int accountMonth, int deptId)
        {
            try
            {
                int drugTypeId = 0;
                switch (drugType)
                {
                    case "西药":
                        drugTypeId = 1;
                        break;
                    case "中药":
                        drugTypeId = 3;
                        break;
                    case "中成药":
                        drugTypeId = 2;
                        break;
                    case "医用物资":
                        drugTypeId = 4;
                        break;
                    default:
                        break;
                }
                decimal beginFee = 0;
                decimal totalInFee = 0;
                decimal totalOutFee = 0;
                DataTable resultDt = new DataTable();
                resultDt.Columns.Add("InProject");
                resultDt.Columns.Add("InFee");
                resultDt.Columns.Add("OutProject");
                resultDt.Columns.Add("OutFee");
                DataRow dRow = resultDt.NewRow();
                dRow["InProject"] = "期初";
                //查询期初余额
                beginFee = QueryTotalBeginFee(drugTypeId, accountYear, accountMonth, deptId);
                totalInFee = beginFee;
                dRow["InFee"] = beginFee.ToString("0.00");
                dRow["OutProject"] = "";
                dRow["OutFee"] = "";
                resultDt.Rows.Add(dRow);
                //查询进库金额
                DataTable inFeeDt = QueryAllInFee(drugTypeId, accountYear, accountMonth, deptId);
                //查询出库金额
                DataTable outFeeDt = QueryAllOutFee(drugTypeId, accountYear, accountMonth, deptId);
                //将出库金额表和入库金额表合成一张统计表
                if (inFeeDt.Rows.Count >= outFeeDt.Rows.Count)
                {
                    for (int index = 0; index < inFeeDt.Rows.Count; index++)
                    {
                        dRow = resultDt.NewRow();
                        dRow["InProject"] = inFeeDt.Rows[index]["项目"];
                        dRow["InFee"] = inFeeDt.Rows[index]["金额"];
                        if (index < outFeeDt.Rows.Count)
                        {
                            dRow["OutProject"] = outFeeDt.Rows[index]["项目"];
                            dRow["OutFee"] = outFeeDt.Rows[index]["金额"];
                        }
                        else
                        {
                            dRow["OutProject"] = "";
                            dRow["OutFee"] = "";
                        }
                        resultDt.Rows.Add(dRow);
                    }
                }
                else
                {
                    for (int index = 0; index < outFeeDt.Rows.Count; index++)
                    {
                        dRow = resultDt.NewRow();
                        dRow["OutProject"] = outFeeDt.Rows[index]["项目"];
                        dRow["OutFee"] = outFeeDt.Rows[index]["金额"];
                        if (index < inFeeDt.Rows.Count)
                        {
                            dRow["InProject"] = inFeeDt.Rows[index]["项目"];
                            dRow["InFee"] = inFeeDt.Rows[index]["金额"];
                        }
                        else
                        {
                            dRow["InProject"] = "";
                            dRow["InFee"] = "";
                        }
                        resultDt.Rows.Add(dRow);
                    }
                }
                //计算入库金额合计
                for (int index = 0; index < inFeeDt.Rows.Count; index++)
                {
                    totalInFee += Convert.ToDecimal(inFeeDt.Rows[index]["金额"]);
                }
                //计算出库金额合计
                for (int index = 0; index < outFeeDt.Rows.Count; index++)
                {
                    totalOutFee += Convert.ToDecimal(outFeeDt.Rows[index]["金额"]);
                }
                dRow = resultDt.NewRow();
                dRow["InProject"] = "合计";
                dRow["InFee"] = Decimal.Round(totalInFee, 2);
                dRow["OutProject"] = "合计";
                dRow["OutFee"] = Decimal.Round(totalOutFee, 2);
                resultDt.Rows.Add(dRow);
                return resultDt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 查询指定类型药品期初金额
        /// </summary>
        /// <param name="drugTypeId">药品类型ID</param>
        /// <param name="accountYear">会计年</param>
        /// <param name="accountMonth">会计月</param>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>药品期初金额汇总</returns>
        abstract protected decimal QueryTotalBeginFee(int drugTypeId, int accountYear, int accountMonth, int deptId);
        /// <summary>
        /// 查询指定类型药品期末金额
        /// </summary>
        /// <param name="drugTypeId">药品类型ID（0表示全部类型药品）</param>
        /// <param name="accountYear">会计年</param>
        /// <param name="accountMonth">会计月</param>
        /// <param name="deptId">药剂科室ID</param>
        /// <param name="outFeeDt">药品期末金额汇总</param>
        abstract protected void QueryTotalEndFee(int drugTypeId, int accountYear, int accountMonth, int deptId, DataTable outFeeDt);

        /// <summary>
        /// 查询指定类型药品借方金额
        /// </summary>
        /// <param name="drugTypeId">药品类型ID（0表示全部类型药品）</param>
        /// <param name="accountYear">会计年</param>
        /// <param name="accountMonth">会计月</param>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>药品借方金额汇总</returns>
        abstract public DataTable QueryAllInFee(int drugTypeId, int accountYear, int accountMonth, int deptId);

        /// <summary>
        /// 查询指定类型药品贷方金额
        /// </summary>
        /// <param name="drugTypeId">药品类型ID(0表示全部类型药品)</param>
        /// <param name="accountYear">会计年</param>
        /// <param name="accountMonth">会计月</param>
        /// <param name="deptId">药剂科室ID</param>
        /// <returns>药品贷方金额汇总</returns>
        abstract public DataTable QueryAllOutFee(int drugTypeId, int accountYear, int accountMonth, int deptId);

        /// <summary>
        /// 获取月结次数
        /// </summary>
        /// <param name="deptId">药剂科室ＩＤ</param>
        /// <returns>月结次数</returns>
        abstract public int GetActTimes(int deptId);
    }
 




}
