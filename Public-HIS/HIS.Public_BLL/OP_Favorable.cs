using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;

namespace HIS.Public_BLL
{
    public class OP_Favorable:BaseBLL
    {
        public static DataTable GetPatientTypeData()
        {
            string sqlstr = @" select PATTYPECODE, NAME, FAVORABLE_SCALE, (
                                case 
                                FAVORABLE_TYPE
                                when 0 then '无优惠'
                                when 1 then '全局优惠'
                                when 2 then '项目分类'
                                when 3 then '项目明细'
                                end 
                                ) FAVORABLE_TYPE
                                , MZ_FLAG, ZY_FLAG, 
                                    MEDSAFECODE, DEL_FLAG
                                  from {BASE_PATIENTTYPE_COST}";
           return  oleDb.GetDataTable(sqlstr);
        }

        public static DataTable GetItemFavorData(string PATTYPECODE)
        {
            string sqlstr = @" select a.PATTYPECODE, a.ITEMCODE,
                                     (case 
                                     when b.item_name is null then c.item_name
                                     else b.item_name
                                     end) itemname
                                    ,a.ITEMTYPE_FLAG
                                    , (
                                     case a.ITEMTYPE_FLAG
                                     when 1 then '门诊发票'
                                     when 2 then '住院发票'
                                     end
                                     )
                                     FPTYPENAME
                                ,a.FAVORABLE_SCALE 
                              from {BASE_ITEM_FAVORABLE as a}
                              left join
                              {BASE_STAT_MZFP as b}
                              on a.itemcode=b.code and a.ITEMTYPE_FLAG=1
                              left join
                              {BASE_STAT_ZYFP as c}
                              on a.itemcode = c.code and a.ITEMTYPE_FLAG=2

                                where a.PATTYPECODE ='" + PATTYPECODE + "'";
            return oleDb.GetDataTable(sqlstr);
        }

        public static DataTable GetItemMXFavorData(string PATTYPECODE)
        {
            string sqlstr=@"select PATTYPECODE, a.ITEMID
                                ,'' as itemname
                                , a.ITEMTYPE                                    
                                ,(
                                case a.ITEMTYPE
                                when 0 then '基本项目'
                                when 1 then '组合项目'
                                when 2 then '药品'
                                end
                                )
                                itemtypename                             
                                , a.FAVORABLE_SCALE                                    
                                  from  {BASE_ITEMMX_FAVORABLE as a}
                                where a.PATTYPECODE='" + PATTYPECODE + "'";
            return oleDb.GetDataTable(sqlstr);
        }

        public static DataTable GetItemMXFavorItemName(DataTable dt,DataTable dtBaseItem,DataTable dtGroupItem,DataTable dtDrug)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ITEMTYPE"].ToString() == "0")
                {
                    for (int j = 0; j < dtBaseItem.Rows.Count; j++)
                    {
                        if (dtBaseItem.Rows[j]["itemid"].ToString().Trim() == dt.Rows[i]["ITEMID"].ToString().Trim())
                        {
                            dt.Rows[i]["itemname"] = dtBaseItem.Rows[j]["itemname"];
                            break;
                        }
                    }
                }
                else if (dt.Rows[i]["ITEMTYPE"].ToString() == "1")
                {
                    for (int j = 0; j < dtGroupItem.Rows.Count; j++)
                    {
                        if (dtGroupItem.Rows[j]["itemid"].ToString().Trim() == dt.Rows[i]["ITEMID"].ToString().Trim())
                        {
                            dt.Rows[i]["itemname"] = dtGroupItem.Rows[j]["itemname"];
                            break;
                        }
                    }
                }
                else if (dt.Rows[i]["ITEMTYPE"].ToString() == "2")
                {
                    for (int j = 0; j < dtDrug.Rows.Count; j++)
                    {
                        if (dtDrug.Rows[j]["itemid"].ToString().Trim() == dt.Rows[i]["ITEMID"].ToString().Trim())
                        {
                            dt.Rows[i]["itemname"] = dtDrug.Rows[j]["itemname"];
                            break;
                        }
                    }
                }
            }
            return dt;
        }

        public static DataTable GetBasePatTypeData()
        {
            string sqlstr = @"select CODE, NAME
                            from {BASE_PATIENTTYPE} order by code";
            return oleDb.GetDataTable(sqlstr);
        }

        public static DataTable GetItemFPData(int type)
        {
            string sqlstr;
            if (type == 0)
                sqlstr = @"select CODE, ITEM_NAME
                     from {BASE_STAT_MZFP}";
            else
                sqlstr = @"select CODE, ITEM_NAME
                     from {BASE_STAT_ZYFP}";
            return oleDb.GetDataTable(sqlstr);
        }

        public static DataTable GetItemMXData(int type)
        {
            string sqlstr;
            if (type == 0)
                sqlstr = @"select  ITEMID , ITEMNAME ,PY_CODE,WB_CODE
                        from {VI_ITEM_PROJECT } where prestype='4'";
            else if (type == 1)
                sqlstr = @"select  ITEMID , ITEMNAME ,PY_CODE,WB_CODE
                        from {VI_ITEM_PROJECT} where prestype='5'";
            else
                sqlstr = @"select ITEMID, ITEMNAME,PY_CODE,WB_CODE  from {VI_ITEM_DRUG}";
            return oleDb.GetDataTable(sqlstr);

        }

        public static void SavePatientType(
            string PATTYPECODE,
            string NAME,
            decimal FAVORABLE_SCALE,
            int FAVORABLE_TYPE,
            int MZ_FLAG,
            int ZY_FLAG,
            string MEDSAFECODE,
            int DEL_FLAG)
        {
            string strWhere = Tables.base_patienttype_cost.PATTYPECODE + oleDb.EuqalTo() + "'" + PATTYPECODE + "'";
                                //+ oleDb.And() + Tables.base_patienttype_cost.MZ_FLAG + oleDb.EuqalTo() + MZ_FLAG
                                //+ oleDb.And() + Tables.base_patienttype_cost.ZY_FLAG + oleDb.EuqalTo() + ZY_FLAG;
            if (BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_PATIENTTYPE_COST).Exists(strWhere))
            {
                string[] fieldvalueAndname=new string[8];
                fieldvalueAndname[0] = "PATTYPECODE='" + PATTYPECODE + "'";
                fieldvalueAndname[1] = "NAME='" + NAME + "'";
                fieldvalueAndname[2] = "FAVORABLE_SCALE=" + FAVORABLE_SCALE + "";
                fieldvalueAndname[3] = "FAVORABLE_TYPE=" + FAVORABLE_TYPE + "";
                fieldvalueAndname[4] = "MZ_FLAG=" + MZ_FLAG + "";
                fieldvalueAndname[5] = "ZY_FLAG=" + ZY_FLAG + "";
                fieldvalueAndname[6] = "MEDSAFECODE='" + MEDSAFECODE + "'";
                fieldvalueAndname[7] = "DEL_FLAG=" + DEL_FLAG + "";
                BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_PATIENTTYPE_COST).Update(strWhere, fieldvalueAndname);
            }
            else
            {
                string[] filednames = new string[] { "PATTYPECODE", "NAME", "FAVORABLE_SCALE", "FAVORABLE_TYPE", "MZ_FLAG", "ZY_FLAG", "MEDSAFECODE", "DEL_FLAG" };
                string[] filedvalues =new string[8];
                filedvalues[0] = PATTYPECODE;
                filedvalues[1] = NAME;
                filedvalues[2]=FAVORABLE_SCALE.ToString();
                filedvalues[3]=FAVORABLE_TYPE.ToString();
                filedvalues[4]=MZ_FLAG.ToString();
                filedvalues[5]=ZY_FLAG.ToString();
                filedvalues[6]=MEDSAFECODE.ToString();
                filedvalues[7]=DEL_FLAG.ToString();
                bool[] b=new bool[]{true,true,false,false,false,false,true,false};
                BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_PATIENTTYPE_COST).Add(filednames, filedvalues, b);
            }
        }

        public static void SaveItemFavor(
            string PATTYPECODE,
            string ITEMCODE,
            int ITEMTYPE_FLAG,
            decimal FAVORABLE_SCALE)
        {
            string strWhere = Tables.base_item_favorable.ITEMCODE + oleDb.EuqalTo() + "'" + ITEMCODE + "'" 
                +oleDb.And()+Tables.base_item_favorable.ITEMTYPE_FLAG+oleDb.EuqalTo()+ITEMTYPE_FLAG;
            if (BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_ITEM_FAVORABLE).Exists(strWhere))
            {
                string[] fieldvalueAndname = new string[4];
                fieldvalueAndname[0] = "PATTYPECODE='" + PATTYPECODE + "'";
                fieldvalueAndname[1] = "ITEMCODE='" + ITEMCODE + "'";
                fieldvalueAndname[2] = "ITEMTYPE_FLAG=" + ITEMTYPE_FLAG + "";
                fieldvalueAndname[3] = "FAVORABLE_SCALE=" + FAVORABLE_SCALE + "";
                BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_ITEM_FAVORABLE).Update(strWhere, fieldvalueAndname);
            }
            else
            {
                string[] filednames = new string[] { "PATTYPECODE", "ITEMCODE", "ITEMTYPE_FLAG", "FAVORABLE_SCALE" };
                string[] filedvalues = new string[4];
                filedvalues[0] = PATTYPECODE;
                filedvalues[1] = ITEMCODE;
                filedvalues[2] = ITEMTYPE_FLAG.ToString();
                filedvalues[3] = FAVORABLE_SCALE.ToString();
                bool[] b = new bool[] { true, true, false, false };
                BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_ITEM_FAVORABLE).Add(filednames, filedvalues, b);
            }
        }

        public static void SaveItemMXFavor(
            string PATTYPECODE
            ,string ITEMID
            ,int ITEMTYPE
            ,decimal FAVORABLE_SCALE)
        {
            string strWhere = Tables.base_itemmx_favorable.ITEMID + oleDb.EuqalTo() + "'" + ITEMID + "'"
                + oleDb.And() + Tables.base_itemmx_favorable.ITEMTYPE + oleDb.EuqalTo() + ITEMTYPE;
            if (BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_ITEMMX_FAVORABLE).Exists(strWhere))
            {
                string[] fieldvalueAndname = new string[4];
                fieldvalueAndname[0] = "PATTYPECODE='" + PATTYPECODE + "'";
                fieldvalueAndname[1] = "ITEMID='" + ITEMID + "'";
                fieldvalueAndname[2] = "ITEMTYPE=" + ITEMTYPE + "";
                fieldvalueAndname[3] = "FAVORABLE_SCALE=" + FAVORABLE_SCALE + "";
                BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_ITEMMX_FAVORABLE).Update(strWhere, fieldvalueAndname);
            }
            else
            {
                string[] filednames = new string[] { "PATTYPECODE", "ITEMID", "ITEMTYPE", "FAVORABLE_SCALE" };
                string[] filedvalues = new string[4];
                filedvalues[0] = PATTYPECODE;
                filedvalues[1] = ITEMID;
                filedvalues[2] = ITEMTYPE.ToString();
                filedvalues[3] = FAVORABLE_SCALE.ToString();
                bool[] b = new bool[] { true, true, false, false };
                BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_ITEMMX_FAVORABLE).Add(filednames, filedvalues, b);
            }
        }


        public static void DelPatinetType(string PATTYPECODE)
        {
            string strWhere = Tables.base_patienttype_cost.PATTYPECODE + oleDb.EuqalTo() + "'" + PATTYPECODE + "'";
            BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_PATIENTTYPE_COST).Delete(strWhere);
        }

        public static void DelItemFavor(string ITEMCODE, int ITEMTYPE_FLAG)
        {
            string strWhere = Tables.base_item_favorable.ITEMCODE + oleDb.EuqalTo() + "'" + ITEMCODE + "'"
                + oleDb.And() + Tables.base_item_favorable.ITEMTYPE_FLAG + oleDb.EuqalTo() + ITEMTYPE_FLAG;
            BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_ITEM_FAVORABLE).Delete(strWhere);
        }

        public static void DelItemMXFavor(string ITEMID, int ITEMTYPE)
        {
            string strWhere = Tables.base_itemmx_favorable.ITEMID + oleDb.EuqalTo() + "'" + ITEMID + "'"
                + oleDb.And() + Tables.base_itemmx_favorable.ITEMTYPE + oleDb.EuqalTo() + ITEMTYPE;
            BindEntity<object>.CreateInstanceDAL(oleDb, Tables.BASE_ITEMMX_FAVORABLE).Delete(strWhere);
        }
    }
}
