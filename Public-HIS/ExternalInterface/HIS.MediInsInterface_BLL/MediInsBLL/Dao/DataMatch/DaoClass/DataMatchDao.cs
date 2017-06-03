using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.MediInsInterface_BLL.MediInsBLL.Dao.DataMatch.Daointerface;

namespace HIS.MediInsInterface_BLL.MediInsBLL.Dao.DataMatch.DaoClass
{
    public class DataMatchDao : ICxHndatamatch,INccmdatamatch
    {

        #region IbaseDao 成员

        private HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _oleDb;
        public HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb
        {
            get
            {
                return _oleDb;
            }
            set
            {
                _oleDb = value;
            }
        }

        #endregion

        /// <summary>
        /// 读取医院药品列表
        /// </summary>
        /// <returns></returns>
        public DataTable Get_HIS_DrugList(bool b)
        {
            DataTable dt = null;
            if (b == false)//未匹配
            {
                string strsql = @"select  distinct MAKERDICID  as code,NAME,chemname,TYPEDICID as type,SPEC,UNITNAME as unit,RETAILPRICE as price,DOSEDICID as model,PRODUCTNAME as factory,WB_CODE, PY_CODE
                                 from (
                                (select makerdicid,name,chemname,typedicid,spec,unitname,dosedicid,packunit,packnum,retailprice,productname,WB_CODE, PY_CODE from vi_drug_yk   )  	
                                union all 
                                 (select makerdicid,name,chemname,typedicid,spec,unitname,dosedicid,packunit,packnum,retailprice,productname,WB_CODE, PY_CODE from   vi_drug_yf   ) 
                                  ) A  
                                 where MAKERDICID NOT IN  (select  CAST(HOSP_CODE as INTEGER)  as his_code  from  CXCH_MATCH_CATALOG_TEMP  where   int(MATCH_TYPE) >0 )";

                dt = oleDb.GetDataTable(strsql);
            }
            else//已匹配
            {
                string strsql = @"select  distinct MAKERDICID  as code,NAME,chemname,TYPEDICID as type,SPEC,UNITNAME as unit,RETAILPRICE as price,DOSEDICID as model,PRODUCTNAME as factory,WB_CODE, PY_CODE
                                 from (
                                (select makerdicid,name,chemname,typedicid,spec,unitname,dosedicid,packunit,packnum,retailprice,productname,WB_CODE, PY_CODE from vi_drug_yk   )  	
                                union all 
                                 (select makerdicid,name,chemname,typedicid,spec,unitname,dosedicid,packunit,packnum,retailprice,productname,WB_CODE, PY_CODE from   vi_drug_yf   ) 
                                  ) A  
                                 where MAKERDICID IN  (select  CAST(HOSP_CODE as INTEGER)  as his_code  from  CXCH_MATCH_CATALOG_TEMP  where   int(MATCH_TYPE) >0 )";

                dt = oleDb.GetDataTable(strsql);
            }
            return dt;
        }
        /// <summary>
        /// 读取医院服务项目列表
        /// </summary>
        /// <returns></returns>
        public DataTable Get_HIS_ItemList(bool b)
        {
            DataTable dt = null;
            if (b == false)//未匹配
            {
                string strWhere = "item_id not in ((select  CAST(HOSP_CODE as INTEGER)  as his_code  from  CXCH_MATCH_CATALOG_TEMP  where   int(MATCH_TYPE) =0))";
                dt = BindEntity<object>.CreateInstanceDAL(oleDb, Views.VI_BASE_HOSPITAL_ITEMS).GetList(strWhere,
                Tables.base_service_items.ITEM_ID,
                Tables.base_service_items.STD_CODE,
                Tables.base_service_items.ITEM_NAME,
                Tables.base_service_items.ITEM_UNIT,
                Tables.base_service_items.PRICE,
                Tables.base_service_items.PY_CODE,
                Tables.base_service_items.WB_CODE);
            }
            else//已匹配
            {
                string strWhere = "itemid  in ((select  CAST(HOSP_CODE as INTEGER)  as his_code  from  CXCH_MATCH_CATALOG_TEMP  where   int(MATCH_TYPE) =0)";
                dt = BindEntity<object>.CreateInstanceDAL(oleDb, Views.VI_BASE_HOSPITAL_ITEMS).GetList(strWhere,
                Tables.base_service_items.ITEM_ID,
                Tables.base_service_items.STD_CODE,
                Tables.base_service_items.ITEM_NAME,
                Tables.base_service_items.ITEM_UNIT,
                Tables.base_service_items.PRICE,
                Tables.base_service_items.PY_CODE,
                Tables.base_service_items.WB_CODE);
            }
            return dt;
        }

        /// <summary>
        /// 获取匹配关心
        /// </summary>
        /// <param name="IsNew">是否是新增的匹配关系,true:已上传 false:未上传</param>
        /// <param name="itemType">项目类型1-全部(不用);2-药品;3-项目</param>
        /// <returns></returns>
        public DataTable CxHn_GetMatchInfo(bool IsNew, string itemType)
        {

            if (IsNew)
            {
                if (itemType == "2")
                {
                    return BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_MATCH_CATALOG_TEMP").GetList("MATCH_TYPE in ('1','2','3') ");
                }
                else
                {
                    return BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_MATCH_CATALOG_TEMP").GetList("MATCH_TYPE ='0'");
                }
            }
            else
            {
                if (itemType == "2")
                {
                    return BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_MATCH_CATALOG_TEMP").GetList("MATCH_TYPE in ('1','2','3') and VALID_FLAG='0' ");
                }
                else
                {
                    return BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_MATCH_CATALOG_TEMP").GetList("MATCH_TYPE ='0' and VALID_FLAG='0' ");
                }
            }

        }

        /// <summary>
        /// 获取农合药品目录
        /// </summary>
        /// <returns></returns>
        public DataTable CxHn_GetDrugList(bool b)
        {


            DataTable dt = null;
            if (b==false)//全部
            {
                dt = BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_DRUG_CATALOG").GetList("",
                                                                                        "Medi_code",
                                                                                        "Medi_name",
                                                                                        "Model_name",
                                                                                        "Factory",
                                                                                        "Standard",
                                                                                        "Medi_item_type",
                                                                                        "Medi_item_name",
                                                                                        "Code_wb",
                                                                                        "Code_py",
                                                                                        "STAPLE_FLAG"
                                                                                                    );
            }
            else//未匹配
            {
                string strWhere = "MEDI_CODE not in (select item_code from  CXCH_MATCH_CATALOG_TEMP where int(MATCH_TYPE)>0)";
                dt = BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_DRUG_CATALOG").GetList(strWhere,
                                                                                        "Medi_code",
                                                                                        "Medi_name",
                                                                                        "Model_name",
                                                                                        "Factory",
                                                                                        "Standard",
                                                                                        "Medi_item_type",
                                                                                        "Medi_item_name",
                                                                                        "Code_wb",
                                                                                        "Code_py",
                                                                                        "STAPLE_FLAG"
                                                                                                    );
            }
            return dt;
        }
        /// <summary>
        /// 获取农合医疗服务项目
        /// </summary>
        /// <returns></returns>
        public DataTable CxHn_GetTherapyList(bool b)
        {
            DataTable dt = null;
            if (b==false)//全部
            {
                dt=BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_ITEM_CATALOG").GetList("");
            }
            else//未匹配
            {
                string strWhere="item_code not in (select item_code from  CXCH_MATCH_CATALOG_TEMP where int(MATCH_TYPE)=0)";
                dt=BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_ITEM_CATALOG").GetList(strWhere);
            }
            return dt;
        }
        /// <summary>
        /// 保存药品目录
        /// </summary>
        /// <param name="dt"></param>
        public void CxHn_AddDrugContent(DataTable dt)
        {
            string[] fns = new string[dt.Columns.Count];
            string[] fvs = new string[dt.Columns.Count];
            bool[] isq = new bool[dt.Columns.Count];

            try
            {
                oleDb.BeginTransaction();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        fns[j] = dt.Columns[j].ColumnName;
                        fvs[j] = dt.Rows[i][j].ToString().Replace("'", "");
                        isq[j] = true;
                    }
                    if (!BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_DRUG_CATALOG").Exists(" MEDI_CODE ='" + fvs[0] + "' "))
                        BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_DRUG_CATALOG").Add(fns, fvs, isq);
                }
                oleDb.CommitTransaction();
            }
            catch (Exception err)
            {
                oleDb.RollbackTransaction();
                throw err;
            }

        }
   
        /// <summary>
        /// 保存匹配数据到本地
        /// </summary>
        /// <param name="fvs"></param>
        public void CxHn_AddMatchData(string[] fvs)
        {
            string[] fns = { "HOSP_CODE", "HOSP_NAME", "HOSP_MODEL", "ITEM_CODE", "ITEM_NAME", "MODEL_NAME", "SERIAL_MATCH", "VALID_FLAG", "AUDIT_FLAG", "MATCH_TYPE", "UPLOAD_TIME", "UPLOADER" };
            bool[] Isq = { true, true, true, true, true, true, true, true, true, true, true, true };
            if (!BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_MATCH_CATALOG_TEMP").Exists(" HOSP_CODE='" + fvs[0] + "' and ITEM_CODE='" + fvs[3] + "' and MATCH_TYPE='"+fvs[9]+"'"))
                BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_MATCH_CATALOG_TEMP").Add(fns, fvs, Isq);
            else
                BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_MATCH_CATALOG_TEMP").Update(" HOSP_CODE='" + fvs[0] + "' and ITEM_CODE='" + fvs[3] + "' and MATCH_TYPE='" + fvs[9] + "'",
                    "VALID_FLAG = '" + fvs[7] + "'",
                    "SERIAL_MATCH='" + fvs[6] + "'", 
                    "UPLOAD_TIME='" + fvs[10] + "'", 
                    "UPLOADER='"+fvs[11]+"'"
                    );
        }

        /// <summary>
        /// 更新审核标识
        /// </summary>
        /// <param name="isValid">是否上传</param>
        /// <param name="dt"></param>
        public void CxHn_UpdateMatchData(DataTable dt,bool isValid)
        {
            try
            {
                oleDb.BeginTransaction();
                string strWhere;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string[] fnavs;
                    if (isValid)
                    {
                        fnavs = new string[1];
                        strWhere = " VALID_FLAG='1' and HOSP_CODE='" + dt.Rows[i]["HOSP_CODE"].ToString() + "' and ITEM_CODE='" + dt.Rows[i]["ITEM_CODE"].ToString() + "' and SERIAL_MATCH='" + dt.Rows[i]["SERIAL_MATCH"].ToString() + "' and MATCH_TYPE='" + dt.Rows[i]["MATCH_TYPE"].ToString() + "'";
                        fnavs[0] = "AUDIT_FLAG = '" + dt.Rows[i]["AUDIT_FLAG"].ToString() + "'";
                    }
                    else
                    {
                        fnavs = new string[2];
                        strWhere = " VALID_FLAG=0 and HOSP_CODE='" + dt.Rows[i]["HOSP_CODE"].ToString() + "' and ITEM_CODE='" + dt.Rows[i]["ITEM_CODE"].ToString() + "' and MATCH_TYPE='" + dt.Rows[i]["MATCH_TYPE"].ToString() + "'";
                        fnavs[0] = "VALID_FLAG = '1'";
                        fnavs[1] = "SERIAL_MATCH='" + dt.Rows[i]["SERIAL_MATCH"].ToString() + "'";
                    }
                    BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_MATCH_CATALOG_TEMP").Update(strWhere, fnavs);
                }
                oleDb.CommitTransaction();
            }
            catch (Exception err)
            {
                oleDb.RollbackTransaction();
                throw err;
            }
        }

        /// <summary>
        /// 删除匹配记录
        /// </summary>
        /// <param name="hosp_code"></param>
        /// <param name="item_code"></param>
        /// <param name="serial_match"></param>
        /// <param name="match_type"></param>
        public void CxHn_DeleteMatchData(string hosp_code, string item_code, string serial_match, string match_type)
        {
            string strWhere = "SERIAL_MATCH='" + serial_match + "' and HOSP_CODE='" + hosp_code + "' and ITEM_CODE='" + item_code + "' and MATCH_TYPE='" + match_type + "'";
            BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_MATCH_CATALOG_TEMP").Delete(strWhere);
        }


        #region ICxHndatamatch 成员


        public void CxHn_AddItemContent(DataTable dt)
        {
            string[] fns = new string[dt.Columns.Count];
            string[] fvs = new string[dt.Columns.Count];
            bool[] isq = new bool[dt.Columns.Count];

            try
            {
                //oleDb.BeginTransaction();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        fns[j] = dt.Columns[j].ColumnName;
                        fvs[j] = dt.Rows[i][j].ToString().Replace("'","");
                        isq[j] = true;
                    }
                    if (!BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_ITEM_CATALOG").Exists(" ITEM_CODE ='" + fvs[0] + "' "))
                        BindEntity<object>.CreateInstanceDAL(oleDb, "CXCH_ITEM_CATALOG").Add(fns, fvs, isq);
                }
                //oleDb.CommitTransaction();
            }
            catch (Exception err)
            {
                //oleDb.RollbackTransaction();
                throw err;
            }
        }

        #endregion
    }
}
