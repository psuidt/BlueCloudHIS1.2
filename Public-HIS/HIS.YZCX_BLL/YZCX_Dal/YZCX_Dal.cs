using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;

namespace HIS.DAL
{
    public class YZCX_Dal
    {
        public RelationalDatabase _oleDb;

        #region 药品信息

        public DataTable YK_LoadCheckInfo(string strWhere)
        {
            string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.makerdicid,c.chemname,c.spec,sum(a.checknum) as checknum,a.factnum,sum(a.ckretailfee) as");
            strSql.Append("ckretailfee,a.ftretailfee,e.productname,d.unitname,");
            strSql.Append("(sum(a.ckretailfee)-a.ftretailfee) as difffee from yk_checkorder a");
            strSql.Append(" left outer join yp_makerdic b on a.makerdicid=b.makerdicid and a.workid=b.workid");
            strSql.Append(" left outer join yp_specdic c on c.specdicid=b.specdicid");
            strSql.Append(" left outer join yp_unitdic d on c.packunit=d.unitdicid");
            strSql.Append(" left outer join yp_productdic e on b.productid=e.productid and a.workid=e.workid");
            strSql.Append(" left outer join yk_checkmaster f on f.mastercheckid=a.mastercheckid and f.workid=a.workid");
            strSql.Append(" where a.workid=" + workId + " and " + strWhere);
            strSql.Append(" group by a.makerdicid,d.unitname,e.productname,a.factnum,a.ftretailfee,c.spec,c.chemname");
            return _oleDb.GetDataTable(strSql.ToString());
        }

        public DataTable YF_LoadCheckInfo(string strWhere)
        {
            string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.makerdicid,c.chemname,c.spec,cast((sum(a.checknum)/a.unitnum) as decimal(15,2))as checknum,");
            strSql.Append("cast((sum(a.factnum)/a.unitnum) as decimal(15,2))as factnum,sum(a.ckretailfee) as ckretailfee,a.ftretailfee,");
            strSql.Append("e.productname,d.unitname,(sum(a.ckretailfee)-a.ftretailfee) as difffee from yf_checkorder a");
            strSql.Append(" left outer join yp_makerdic b on a.makerdicid=b.makerdicid and a.workid=b.workid");
            strSql.Append(" left outer join yp_specdic c on c.specdicid=b.specdicid");
            strSql.Append(" left outer join yp_unitdic d on c.packunit=d.unitdicid");
            strSql.Append(" left outer join yp_productdic e on b.productid=e.productid and a.workid=e.workid");
            strSql.Append(" left outer join yf_checkmaster f on f.mastercheckid=a.mastercheckid and f.workid=a.workid");
            strSql.Append(" where a.workid=" + workId + " and " + strWhere);
            strSql.Append(" group by a.makerdicid,d.unitname,e.productname,a.factnum,a.ftretailfee,c.spec,c.chemname,a.unitnum");
            return _oleDb.GetDataTable(strSql.ToString());
        }

        public DataTable LoadCheckBillFee(string strWhere, int makerDicId, int typeDicID)
        {
            string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from");
            strSql.Append("((select sum(lenderfee) as checkinfee, sum(debitfee) as checkoutfee,");
            strSql.Append("yk_account.regtime as audittime,billnum as auditnum,deptid,");
            strSql.Append("(select name as deptname from base_dept_property");
            strSql.Append(" where base_dept_property.dept_id=yk_account.deptid and base_dept_property.workid=yk_account.workid)");
            strSql.Append(" from yk_account left outer join yp_makerdic on yk_account.makerdicid=yp_makerdic.makerdicid");
            strSql.Append(" left outer join yp_specdic on yp_makerdic.specdicid=yp_specdic.specdicid");
            strSql.Append(" where optype='012'");
            if (typeDicID != 0)
            {
                strSql.Append(" and yp_specdic.typedicid=%d1");
            }
            if (makerDicId != 0)
            {
                strSql.Append(" and yk_account.makerdicid=%d2");
            }
            strSql.Append(" group by billnum,yk_account.regtime,deptid,yk_account.workid)union");
            strSql.Append("(select sum(lenderfee) as checkinfee, sum(debitfee) as checkoutfee,");
            strSql.Append("yf_account.regtime as audittime,billnum as auditnum,deptid,");
            strSql.Append("(select name as deptname from base_dept_property where");
            strSql.Append(" base_dept_property.dept_id=yf_account.deptid and base_dept_property.workid=yf_account.workid)");
            strSql.Append(" from yf_account left outer join yp_makerdic on yf_account.makerdicid=yp_makerdic.makerdicid");
            strSql.Append(" left outer join yp_specdic on yp_makerdic.specdicid=yp_specdic.specdicid");
            strSql.Append(" where optype='009'");
            if (typeDicID != 0)
            {
                strSql.Append(" and yp_specdic.typedicid=%d1");
            }
            if (makerDicId != 0)
            {
                strSql.Append(" and yf_account.makerdicid=%d2");
            }
            strSql.Append(" group by billnum,yf_account.regtime,deptid,yf_account.workid)) as a");
            strSql.Replace("%d1", typeDicID.ToString());
            strSql.Replace("%d2", makerDicId.ToString());
            return _oleDb.GetDataTable(strSql.ToString() + " where " + strWhere);
        }

        public DataTable LoadInstoreInfo(string strWhere)
        {
            string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.MAKERDICID,A.RETAILPRICE AS CURRENTPRICE,C.CHEMNAME,C.SPEC,B.PRODUCTID, A.LENDERNUM AS NUM, A.LENDERFEE AS RETAILFEE,A.DEPTID,");
            strSql.Append(" A.REGTIME,C.TYPEDICID,A.WORKID,E.SUPPORTDICID,F.NAME,G.UNITNAME,H.PRODUCTNAME,D.TRADEFEE,D.STOCKFEE,B.RETAILPRICE,I.TYPENAME");
            strSql.Append(" from (select * from YK_ACCOUNT where OPTYPE='010' or OPTYPE='019') AS A");
            strSql.Append(" LEFT OUTER JOIN YP_MAKERDIC B ON A.MAKERDICID=B.MAKERDICID AND A.WORKID=B.WORKID");
            strSql.Append(" LEFT OUTER JOIN YP_SPECDIC C ON B.SPECDICID=C.SPECDICID");
            strSql.Append(" LEFT OUTER JOIN YK_INORDER D ON A.ORDERID=D.INSTORAGEID AND A.WORKID=D.WORKID");
            strSql.Append(" LEFT OUTER JOIN YK_INMASTER E ON D.MASTERINSTORAGEID=E.MASTERINSTORAGEID AND A.WORKID=E.WORKID");
            strSql.Append(" LEFT OUTER JOIN YP_SUPPORTDIC F ON E.SUPPORTDICID=F.SUPPORTDICID");
            strSql.Append(" LEFT OUTER JOIN YP_UNITDIC G ON A.LEASTUNIT=G.UNITDICID");
            strSql.Append(" LEFT OUTER JOIN YP_PRODUCTDIC H ON B.PRODUCTID=H.PRODUCTID");
            strSql.Append(" LEFT OUTER JOIN YP_TYPEDIC I ON C.TYPEDICID=I.TYPEDICID");
            strSql.Append(" WHERE A.WORKID=" + workId + " and " + strWhere);
            return _oleDb.GetDataTable(strSql.ToString());
        }

        public DataTable LoadOutstoreInfo(string strWhere)
        {
            string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.MAKERDICID,A.RETAILPRICE AS CURRENTPRICE,C.CHEMNAME,C.SPEC,B.PRODUCTID, A.DEBITNUM AS NUM, A.DEBITFEE AS RETAILFEE,A.DEPTID,");
            strSql.Append(" A.REGTIME,C.TYPEDICID,A.WORKID,E.OUTDEPTID,F.NAME AS DEPTNAME,G.UNITNAME,H.PRODUCTNAME,D.TRADEFEE,0 AS STOCKFEE,D.TRADEFEE,B.RETAILPRICE,I.TYPENAME");
            strSql.Append(" from (select * from YK_ACCOUNT where OPTYPE='017' or OPTYPE='011' or OPTYPE='018') AS A");
            strSql.Append(" LEFT OUTER JOIN YP_MAKERDIC B ON A.MAKERDICID=B.MAKERDICID AND A.WORKID=B.WORKID");
            strSql.Append(" LEFT OUTER JOIN YP_SPECDIC C ON B.SPECDICID=C.SPECDICID");
            strSql.Append(" LEFT OUTER JOIN YK_OUTORDER D ON A.ORDERID=D.OUTSTORAGEID AND A.WORKID=D.WORKID");
            strSql.Append(" LEFT OUTER JOIN YK_OUTMASTER E ON D.MASTEROUTSTORAGEID=E.MASTEROUTSTORAGEID AND A.WORKID=E.WORKID");
            strSql.Append(" LEFT OUTER JOIN BASE_DEPT_PROPERTY F ON E.OUTDEPTID=F.DEPT_ID");
            strSql.Append(" LEFT OUTER JOIN YP_UNITDIC G ON A.LEASTUNIT=G.UNITDICID");
            strSql.Append(" LEFT OUTER JOIN YP_PRODUCTDIC H ON B.PRODUCTID=H.PRODUCTID AND H.PRODUCTID=B.PRODUCTID");
            strSql.Append(" LEFT OUTER JOIN YP_TYPEDIC I ON C.TYPEDICID=I.TYPEDICID");
            strSql.Append(" WHERE A.WORKID=" + workId + " and " + strWhere);
            return _oleDb.GetDataTable(strSql.ToString());
        }

        public DataTable LoadDispInfo(string strWhere, int isMZZYQY, bool isRefund, int drugType)
        {
            string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            //string strOptype;
            //string num;
            //string fee;
            //if (isRefund)
            //{
            //    strOptype = "'004'";
            //    num = "A.LENDERNUM AS DEBITNUM";
            //    fee = "A.LENDERFEE AS DEBITFEE";
            //}
            //else
            //{
            //    strOptype = "'003'";
            //    num = "A.DEBITNUM";
            //    fee = "A.DEBITFEE";
            //}
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select A.MAKERDICID,C.CHEMNAME,C.SPEC,B.PRODUCTID, "+num+", "+fee+",A.DEPTID,I.NAME AS DEPTNAME,");
            //strSql.Append(" A.REGTIME,C.TYPEDICID,A.WORKID,G.UNITNAME,H.PRODUCTNAME,E.PATIENTNAME,E.INPATIENTID,E.INVOICENUM,D.CUREDEPTID,J.NAME AS CUREDEPTNAME");
            //strSql.Append(" from (select * from YF_ACCOUNT where OPTYPE="+strOptype+" and accounttype=2) AS A");
            //strSql.Append(" LEFT OUTER JOIN YP_MAKERDIC B ON A.MAKERDICID=B.MAKERDICID AND A.WORKID=B.WORKID");
            //strSql.Append(" LEFT OUTER JOIN YP_SPECDIC C ON B.SPECDICID=C.SPECDICID");
            //strSql.Append(" LEFT OUTER JOIN YF_DRORDER D ON A.ORDERID=D.ORDERDRUGOCID AND A.WORKID=D.WORKID");
            //strSql.Append(" LEFT OUTER JOIN YF_DRMASTER E ON D.MASTERDRUGOCID=E.MASTERDRUGOCID AND A.WORKID=E.WORKID");
            //strSql.Append(" LEFT OUTER JOIN YP_UNITDIC G ON A.LEASTUNIT=G.UNITDICID");
            //strSql.Append(" LEFT OUTER JOIN YP_PRODUCTDIC H ON B.PRODUCTID=H.PRODUCTID");
            //strSql.Append(" LEFT OUTER JOIN BASE_DEPT_PROPERTY I ON A.DEPTID=I.DEPT_ID");
            //strSql.Append(" LEFT OUTER JOIN BASE_DEPT_PROPERTY J ON D.CUREDEPTID=J.DEPT_ID");
            //strSql.Append(" WHERE A.WORKID=" + workId + " and " + strWhere);

            string drugTypeStr = "";

            if (drugType == 1)
            {
                drugTypeStr = "'01'";
            }
            else if (drugType == 2)
            {
                drugTypeStr = "'02'";
            }
            else if (drugType == 3)
            {
                drugTypeStr = "'03'";
            }
            else if (drugType == 4)
            {
                drugTypeStr = "'00'";
            }
            else
            {
                drugTypeStr = "'00','01','02','03'";
            }

            string strSql = "select * from (";
            if (isMZZYQY == 1)
            {
                strSql += @"select itemid as MAKERDICID,itemname as CHEMNAME ,standard as SPEC,c.PRODUCTID,PRODUCTNAME,DEBITNUM,DEBITFEE ,aa.deptid,deptname,aa.regtime,typedicid,aa.workid,aa.unitname, patientname,inpatientid,invoicenum,curedeptid,curedeptname from 
                        (
                        select a.itemid,a.itemname,a.standard,a.unit as unitname,a.workid,a.sell_price,sum(a.amount) DEBITNUM,sum(a.tolal_fee) DEBITFEE,b.EXECDEPTCODE as deptid, c.name as deptname ,h.costdate as REGTIME,int(b.prestype) as TYPEDICID,d.patname as PATIENTNAME,'0' as INPATIENTID,1 as INVOICENUM,b.PRESDEPTCODE as CUREDEPTID,e.name as CUREDEPTNAME  from
                         MZ_PRESORDER a 
                         left join MZ_PRESMASTER b on a.PRESMASTERID=b.PRESMASTERID
                         right join mz_costmaster h on h.costmasterid=b.costmasterid
						 left join base_dept_property c on int(b.execdeptcode)=c.dept_id
						 left join PATIENTINFO d on b.patid=d.patid
						 left join base_dept_property e on int(b.presdeptcode)=e.dept_id
                         where a.BIGITEMCODE in ("+drugTypeStr+@")
                         group by a.itemid,a.itemname,a.standard,a.unit,a.workid,a.sell_price, b.execdeptcode,c.name,h.costdate,b.prestype,d.patname,b.presdeptcode,e.name 
                         ) aa 
                         left join YP_MAKERDIC c on aa.itemid=c.MAKERDICID
                         left join YP_PRODUCTDIC d on c.PRODUCTID=d.PRODUCTID";
            }
            else if (isMZZYQY == 2)
            {
                strSql += @"select itemid as MAKERDICID,itemname as CHEMNAME ,standard as SPEC,c.PRODUCTID,PRODUCTNAME,DEBITNUM,DEBITFEE ,aa.deptid,deptname,aa.regtime,typedicid,aa.workid,aa.unitname, patientname,inpatientid,invoicenum,curedeptid,curedeptname from 
                        (
                        select a.itemid,a.itemname,a.standard,a.unit as unitname,a.workid,a.sell_price,sum(a.amount) DEBITNUM,sum(a.tolal_fee) DEBITFEE,a.EXECDEPTCODE as deptid,b.name as deptname,a.costdate as REGTIME ,int(a.prestype) as typedicid,c.patname as PATIENTNAME,c.cureno as INPATIENTID,0 as INVOICENUM,a.PRESDEPTCODE as CUREDEPTID,d.name as CUREDEPTNAME  from
                         ZY_PRESORDER a 
						 left join base_dept_property b on int(a.execdeptcode)=b.dept_id
						 left join patientinfo c on a.patid=c.patid
						 left join base_dept_property d on int(a.presdeptcode)=d.dept_id
                         where a.ITEMTYPE in (" + drugTypeStr + @")
                         group by a.itemid,a.itemname,a.standard,a.unit,a.sell_price,a.workid,a.execdeptcode,b.name,a.costdate,a.prestype,c.patname,c.cureno,a.presdeptcode,d.name 
                         ) aa 
                         left join YP_MAKERDIC c on aa.itemid=c.MAKERDICID 
                         left join YP_PRODUCTDIC d on c.PRODUCTID=d.PRODUCTID";
            }
            else
            {
                strSql += @"select itemid as MAKERDICID
						,itemname as CHEMNAME ,standard as SPEC,c.PRODUCTID,PRODUCTNAME
						,DEBITNUM,DEBITFEE 
						,aa.deptid,deptname
						,aa.regtime regtime
						,typedicid,aa.workid
						,aa.unitname, patientname,inpatientid,invoicenum,curedeptid,curedeptname 
						from 
                        (
                        select a.itemid,a.itemname,a.standard,a.unit as unitname,a.workid,a.sell_price,sum(a.amount) DEBITNUM,sum(a.tolal_fee) DEBITFEE,b.EXECDEPTCODE as deptid, c.name as deptname ,h.costdate as REGTIME,int(b.prestype) as TYPEDICID,d.patname as PATIENTNAME,'0' as INPATIENTID,1 as INVOICENUM,b.PRESDEPTCODE as CUREDEPTID,e.name as CUREDEPTNAME  from
                         MZ_PRESORDER a 
                         left join MZ_PRESMASTER b on a.PRESMASTERID=b.PRESMASTERID
                         right join mz_costmaster h on h.costmasterid=b.costmasterid
						 left join base_dept_property c on int(b.execdeptcode)=c.dept_id
						 left join PATIENTINFO d on b.patid=d.patid
						 left join base_dept_property e on int(b.presdeptcode)=e.dept_id
                         where a.BIGITEMCODE in (" + drugTypeStr + @")
                         group by a.itemid,a.itemname,a.standard,a.unit,a.workid,a.sell_price, b.execdeptcode,c.name,h.costdate,b.prestype,d.patname,b.presdeptcode,e.name 
                         ) aa 
                         left join YP_MAKERDIC c on aa.itemid=c.MAKERDICID
                         left join YP_PRODUCTDIC d on c.PRODUCTID=d.PRODUCTID
						 
						 union all
						
						 select itemid as MAKERDICID
						 ,itemname as CHEMNAME ,standard as SPEC,c.PRODUCTID,PRODUCTNAME
						 ,DEBITNUM,DEBITFEE 
						 ,aa.deptid as deptid,deptname
						 ,aa.regtime
						 ,typedicid,aa.workid
						 ,aa.unitname, patientname,inpatientid,invoicenum,curedeptid,curedeptname 
						 from 
                        (
                        select a.itemid,a.itemname,a.standard,a.unit as unitname,a.workid,a.sell_price,sum(a.amount) DEBITNUM,sum(a.tolal_fee) DEBITFEE,a.EXECDEPTCODE as deptid,b.name as deptname,a.costdate as REGTIME ,int(a.prestype) as typedicid,c.patname as PATIENTNAME,c.cureno as INPATIENTID,0 as INVOICENUM,a.PRESDEPTCODE as CUREDEPTID,d.name as CUREDEPTNAME  from
                         ZY_PRESORDER a 
						 left join base_dept_property b on int(a.execdeptcode)=b.dept_id
						 left join patientinfo c on a.patid=c.patid
						 left join base_dept_property d on int(a.presdeptcode)=d.dept_id
                         where a.ITEMTYPE in (" + drugTypeStr + @")
                         group by a.itemid,a.itemname,a.standard,a.unit,a.sell_price,a.workid,a.execdeptcode,b.name,a.costdate,a.prestype,c.patname,c.cureno,a.presdeptcode,d.name 
                         ) aa 
                         left join YP_MAKERDIC c on aa.itemid=c.MAKERDICID 
                         left join YP_PRODUCTDIC d on c.PRODUCTID=d.PRODUCTID";
            }
            strSql += @") A where A.workid=" + workId + " and " + strWhere;

            return _oleDb.GetDataTable(strSql.ToString());
        }

        #endregion

        #region 门诊信息
        /// <summary>
        /// 按查询条件获取门诊人次
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>门诊人次</returns>
        public int GetMZPopulation(string strWhere)
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from (");
                strSql.Append("select a.visitno from yzcx_mz_cost a");
                strSql.Append(" where a.workid=" + workId+_oleDb.And() + strWhere);
                strSql.Append(" group by a.visitno");
                strSql.Append(") as b");
                object obj = _oleDb.GetDataResult(strSql.ToString());
                if (obj != null)
                {
                    int result;
                    if (Int32.TryParse(obj.ToString(), out result))
                    {
                        return result;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 按查询条件获取门诊总收入
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public decimal GetMZTotalFee(string strWhere)
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select sum(item_fee) from yzcx_mz_cost a");
                strSql.Append(" where a.workid=" + workId + " and " + strWhere);
                object obj = _oleDb.GetDataResult(strSql.ToString());
                if (obj != null)
                {
                    decimal result;
                    if (Decimal.TryParse(obj.ToString(), out result))
                    {
                        return result;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 按指定条件查询门诊已收费并未被退费的处方总张数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetMZPresNum(string strWhere)
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from mz_presmaster a");
                strSql.Append(" where a.workid=" + workId + " and a.record_flag=0 and a.charge_flag=1 and " + strWhere);
                object obj = _oleDb.GetDataResult(strSql.ToString());
                if (obj != null)
                {
                    int result;
                    if (Int32.TryParse(obj.ToString(), out result))
                    {
                        return result;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 获取门诊处方明细信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetMZPresOrder(string strWhere)
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select A.itemname,A.amount*A.presamount/A.relationnum as num,");
                strSql.Append("A.buy_price,A.sell_price,A.unit,A.standard,A.tolal_fee,B.presdate,C.visitno");
                strSql.Append(" from mz_presorder A");
                strSql.Append(" left outer join (select presdate,presmasterid from mz_presmaster)B on A.presmasterid=B.presmasterid");
                strSql.Append(" left outer join (select patlistid,visitno from mz_patlist)C on A.patlistid=C.patlistid");
                strSql.Append(" where A.workid=" + workId + " and " + strWhere);
                return _oleDb.GetDataTable(strSql.ToString());
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 获取门诊经管核算项目列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetMZHSFee(string strWhere)
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select sum(a.item_fee) as totalfee,c.code,c.item_name from yzcx_mz_cost a");
                strSql.Append(" left outer join base_stat_item b on a.itemcode=b.code");
                strSql.Append(" left outer join base_stat_hs c on b.hs_code=c.code");
                strSql.Append(" where a.workid=" + workId + " and " + strWhere);
                strSql.Append(" group by c.code,c.item_name");
                DataTable mz_HSDt = _oleDb.GetDataTable(strSql.ToString());
                for (int index = 0; index < mz_HSDt.Rows.Count; index++)
                {
                    if (mz_HSDt.Rows[index]["CODE"] == DBNull.Value)
                    {
                        mz_HSDt.Rows[index]["CODE"] = "0";
                        mz_HSDt.Rows[index]["ITEM_NAME"] = "未设置经管核算项目";
                    }
                }
                return mz_HSDt;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 按开方医生获取门诊项目金额
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetMZItemFeeByDoc(string strWhere)
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) as num,sum(item_fee) as totalfee,presdoccoe,");
                strSql.Append("(select name from base_employee_property where cast(base_employee_property.employee_id as char(20))=presdoccoe)");
                strSql.Append(" from yzcx_mz_cost");
                strSql.Append(" where workid=" + workId + " and " + strWhere);
                strSql.Append(" group by presdoccoe");
                return _oleDb.GetDataTable(strSql.ToString());
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 按开方科室获取门诊项目金额
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetMZItemFeeByDept(string strWhere)
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) as num,sum(item_fee) as totalfee,presdeptcode,");
                strSql.Append("(select name from base_dept_property where cast(base_dept_property.dept_id as char(20))=presdeptcode)");
                strSql.Append(" from yzcx_mz_cost");
                strSql.Append(" where workid=" + workId + " and " + strWhere);
                strSql.Append(" group by presdeptcode");
                return _oleDb.GetDataTable(strSql.ToString());
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        #endregion

        #region 住院信息

        /// <summary>
        /// 获取住院病人人次
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>病人数量</returns>
        public int GetZYPopulation(string strWhere)
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from zy_patlist ");
                strSql.Append(" where workid=" + workId + " and " + strWhere);
                object obj = _oleDb.GetDataResult(strSql.ToString());
                if (obj != null)
                {
                    int result;
                    if (Int32.TryParse(obj.ToString(), out result))
                    {
                        return result;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 获取当前在院病人数量
        /// </summary>
        /// <returns>在院病人数量</returns>
        public int GetZYCurrentNum()
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from zy_patlist");
                strSql.Append(" where workid=" + workId + " and pattype='2'");
                object obj = _oleDb.GetDataResult(strSql.ToString());
                if (obj != null)
                {
                    int result;
                    if (Int32.TryParse(obj.ToString(), out result))
                    {
                        return result;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public DataTable GetZYHSFee(string strWhere)
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select sum(a.total_fee) as total_fee,b.code,b.item_name from yzcx_zy_cost a");
                strSql.Append(" left outer join base_stat_hs b on a.hscode=b.code");
                strSql.Append(" where a.workid=" + workId + " and " + strWhere);
                strSql.Append(" group by b.code,b.item_name");
                return _oleDb.GetDataTable(strSql.ToString());
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 按查询条件获取住院总收入
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public decimal GetZYTotalFee(string strWhere)
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select sum(a.total_fee) from yzcx_zy_cost a");
                strSql.Append(" where a.workid=" + workId + " and " + strWhere);
                object obj = _oleDb.GetDataResult(strSql.ToString());
                if (obj != null)
                {
                    decimal result;
                    if (Decimal.TryParse(obj.ToString(), out result))
                    {
                        return result;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 获取某时间段内住院总天数
        /// </summary>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public int GetZYTotalLeaveDays(DateTime beginTime, DateTime endTime)
        {
            try
            {
                int totalLeaveDays = 0;
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select patlistid,curedate,outdate,pattype");
                strSql.Append(" from zy_patlist where (curedate <= '"+beginTime.Date.ToString("yyyy-MM-dd")
                    + "' and outdate>='" + beginTime.Date.ToString("yyyy-MM-dd") + "')");
                strSql.Append(" and pattype<>'6'");
                strSql.Append(" union");
                strSql.Append(" select patlistid,curedate,outdate,pattype");
                strSql.Append(" from zy_patlist where (curedate>='" + beginTime.Date.ToString("yyyy-MM-dd")
                    + "' and curedate<='" + endTime.Date.ToString("yyyy-MM-dd") + "')");
                strSql.Append(" and pattype<>'6'");
                DataTable patDt = _oleDb.GetDataTable(strSql.ToString());
                for (int index = 0; index < patDt.Rows.Count; index++)
                {
                    DataRow dtRow = patDt.Rows[index];
                    DateTime cureDate = Convert.ToDateTime(dtRow["CUREDATE"]);
                    DateTime outDate = new DateTime();
                    if (!Convert.IsDBNull(dtRow["OUTDATE"]))
                    {
                        outDate = Convert.ToDateTime(dtRow["OUTDATE"]);
                    }
                    if (cureDate.Date <= beginTime.Date)
                    {
                        if ((outDate.Date <= endTime.Date)
                            && (outDate.Date.ToString("yyyy-MM-dd") != "0001-01-01"))
                        {
                            totalLeaveDays += (outDate.Date - beginTime.Date).Days;
                        }
                        else
                        {
                            totalLeaveDays += (endTime.Date - beginTime.Date).Days;
                        }
                    }
                    else
                    {
                        if ((outDate.Date <= endTime.Date)
                            && (outDate.Date.ToString("yyyy-MM-dd") != "0001-01-01"))
                        {
                            totalLeaveDays += (outDate.Date - cureDate.Date).Days;
                        }
                        else
                        {
                            totalLeaveDays += (endTime.Date - cureDate.Date).Days;
                        }
                    }
                }
                return totalLeaveDays;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public DataTable GetZYOrderFee(string strWhere)
        {
            string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.total_fee,a.itemname,a.amount,a.unit,a.costdate,"
            +"a.bigitemtype,a.hscode,b.item_name as hsname,c.item_name as bigitemname");
            strSql.Append(" from yzcx_zy_cost a");
            strSql.Append(" left outer join base_stat_hs b on a.hscode=b.code");
            strSql.Append(" left outer join base_stat_item c on a.bigitemtype=c.code");
            strSql.Append(" where a.workid=" + workId + " and " + strWhere);
            return _oleDb.GetDataTable(strSql.ToString());
        }

        public DataTable GetZYDeptFee(string strWhere)
        {
            string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(total_fee) as totalfee,presdeptcode,B.name as deptname,c.code as fpcode,C.item_name as codename");
            strSql.Append(" from yzcx_zy_cost A");
            strSql.Append(" left outer join base_dept_property B on cast(A.presdeptcode as integer)=B.dept_id");
            strSql.Append(" left outer join base_stat_zyfp C on A.fpcode=C.code");
            strSql.Append(" where A.workid=" + workId + " and " + strWhere);
            strSql.Append(" group by presdeptcode,name,c.code,item_name");
            return _oleDb.GetDataTable(strSql.ToString());
        }

        public DataTable GetZYDocFee(string strWhere)
        {
            string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(total_fee) as totalfee,presdoccode,B.name as docname,C.code as fpcode,C.item_name as codename");
            strSql.Append(" from yzcx_zy_cost A");
            strSql.Append(" left outer join base_employee_property B on cast(A.presdoccode as integer)=B.employee_id");
            strSql.Append(" left outer join base_stat_zyfp C on A.fpcode=C.code");
            strSql.Append(" where A.workid=" + workId + " and " + strWhere);
            strSql.Append(" group by presdoccode,name,c.code,item_name");
            return _oleDb.GetDataTable(strSql.ToString());
        }

        public DataTable GetZYPatFee(string strWhere)
        {
            string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cureno,patname,B.name as pattypename,sum(total_fee) as totalfee");
            strSql.Append(" from yzcx_zy_cost A left outer join base_patienttype B on A.pattype=B.code");
            strSql.Append(" where A.workid=" + workId + " and " + strWhere);
            strSql.Append(" group by cureno,patname,B.name");
            return _oleDb.GetDataTable(strSql.ToString());
        }

        /// <summary>
        /// 按开方医生获取住院项目金额
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetZYItemFeeByDoc(string strWhere)
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) as num,sum(total_fee) as totalfee,presdoccode,");
                strSql.Append("(select name from base_employee_property where cast(base_employee_property.employee_id as char(20))=presdoccode)");
                strSql.Append(" from yzcx_zy_cost");
                strSql.Append(" where workid=" + workId + " and " + strWhere);
                strSql.Append(" group by presdoccode");
                return _oleDb.GetDataTable(strSql.ToString());
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// 按开方科室获取住院项目金额
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetZYItemFeeByDept(string strWhere)
        {
            try
            {
                string workId = HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) as num,sum(total_fee) as totalfee,presdeptcode,");
                strSql.Append("(select name from base_dept_property where cast(base_dept_property.dept_id as char(20))=presdeptcode)");
                strSql.Append(" from yzcx_zy_cost");
                strSql.Append(" where workid=" + workId + " and " + strWhere);
                strSql.Append(" group by presdeptcode");
                return _oleDb.GetDataTable(strSql.ToString());
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        #endregion
    }
}
