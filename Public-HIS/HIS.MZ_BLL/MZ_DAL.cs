using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;

namespace HIS.DAL
{
    public class MZ_DAL 
    { 
        public RelationalDatabase _OleDB = null;
        /// <summary>
        /// 获取发票分配记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetInvoiceRecord()
        {
            string tb = _OleDB.TableNameBM( Tables.MZ_INVOICE, "A" ) + _OleDB.LeftJoin() + _OleDB.TableNameBM( Tables.BASE_EMPLOYEE_PROPERTY, "B" ) +
                _OleDB.ON( "A." + Tables.mz_invoice.EMPLOYEE_ID, "B." + Tables.base_employee_property.EMPLOYEE_ID ) + _OleDB.LeftJoin() +
                _OleDB.TableNameBM( Tables.BASE_EMPLOYEE_PROPERTY, "C" ) +
                _OleDB.ON( "A." + Tables.mz_invoice.ALLOT_USER, "C." + Tables.base_employee_property.EMPLOYEE_ID );
            string[] when = new string[3];
            when[0] = _OleDB.When() + Tables.mz_invoice.INVOICE_TYPE + _OleDB.EuqalTo() + "0" + _OleDB.Then() + "'收费'";
            when[1] = _OleDB.When() + Tables.mz_invoice.INVOICE_TYPE + _OleDB.EuqalTo() + "1" + _OleDB.Then() + "'挂号'";
            when[2] = _OleDB.Else() + "'公共'";
            string case_when1 = _OleDB.CASEWhen( "INVOICE_TYPE", when );
            string[] when1 = new string[4];
            when1[0] = _OleDB.When() + "A." + Tables.mz_invoice.STATUS + _OleDB.EuqalTo() + "0" + _OleDB.Then() + "'正常'";
            when1[1] = _OleDB.When() + "A." + Tables.mz_invoice.STATUS + _OleDB.EuqalTo() + "0" + _OleDB.Then() + "'用完'";
            when1[2] = _OleDB.When() + "A." + Tables.mz_invoice.STATUS + _OleDB.EuqalTo() + "0" + _OleDB.Then() + "'待用'";
            when1[3] = _OleDB.Else() + "'停用'";
            string case_when2 = _OleDB.CASEWhen( "STATUS", when1 );
            string strsql = _OleDB.Table( tb, "", "",
                                    Tables.mz_invoice.ID,
                                    case_when1,
                                    _OleDB.FiledNameBM( "B." + Tables.base_employee_property.NAME, "USERNAME" ),
                                     Tables.mz_invoice.START_NO,
                                      Tables.mz_invoice.END_NO,
                                     Tables.mz_invoice.CURRENT_NO,
                                    case_when2,
                                    Tables.mz_invoice.ALLOT_DATE,
                                    _OleDB.FiledNameBM( "C." + Tables.base_employee_property.NAME, "ALLOT_USER" ) );
            return _OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 根据发票号获取发票信息
        /// </summary>
        /// <param name="costId"></param>
        /// <returns></returns>
        public DataTable GetInvoiceDetail(int costId)
        {
            //20100524.1.01 检验费打印明细

            //string strWhere_1 = "a." + Tables.mz_costorder.ITEMTYPE + _OleDB.EuqalTo() + "c." + Tables.base_stat_item.CODE +
            //    _OleDB.And() + "c." + Tables.base_stat_item.MZFP_CODE + _OleDB.EuqalTo() + "b." + Tables.base_stat_mzfp.CODE +
            //    _OleDB.And() + "a." + Tables.mz_costorder.COSTID + _OleDB.EuqalTo() + costId;
            //string strsql = _OleDB.Table(_OleDB.TableName(_OleDB.TableNameBM(Tables.MZ_COSTORDER, "a"), _OleDB.TableNameBM(Tables.BASE_STAT_MZFP, "b"), _OleDB.TableNameBM(Tables.BASE_STAT_ITEM, "c")), "", strWhere_1,
            //                            "b." + Tables.base_stat_mzfp.ITEM_NAME,
            //                                Tables.mz_costorder.TOTAL_FEE, " ''as itemname", " '' as fee", " '' as itemtype");         
            //            string strsql = @"select * from 
            //                            (
            //                            select  bb.item_name as item_name,
            //                            c.tolal_fee as fee,c.itemname,ee.total_fee from mz_costmaster a left outer join MZ_PRESMASTER b on a.costmasterid=b.costmasterid left outer join mz_presorder c
            //                            on b.presmasterid=c.presmasterid  left outer join mz_costorder ee on ee.costid=a.costmasterid and ee.itemtype=c.bigitemcode
            //							left outer join base_stat_item aa on c.bigitemcode = aa.CODE  
            //							left outer join base_stat_mzfp bb on aa.MZFP_CODE = bb.CODE 
            //                            where a.costmasterid=" + costId + @"  and bb.code='07'
            //                            union all 
            //                             select 
            //                              bb.item_name  as item_name,total_fee  as fee,'' as itemname,total_fee
            //                             from mz_costorder cc
            //							 left outer join base_stat_item aa on cc.itemtype = aa.CODE  
            //							left outer join base_stat_mzfp bb on aa.MZFP_CODE = bb.CODE 
            //                            where cc.costid=" + costId + @"  and bb.code not in ('07')
            //	                        ) aaa order by itemname fetch first 6 rows only ";

            string strsql = @"select  bb.item_name as item_name, 0 as fee,'' as itemname,sum(ee.total_fee) total_fee 
                                 from mz_costmaster a 
                                 left outer join mz_costorder ee on ee.costid=a.costmasterid 
                                 left outer join base_stat_item aa on ee.itemtype = aa.CODE  
                                 left outer join base_stat_mzfp bb on aa.MZFP_CODE = bb.CODE 
                                 where a.costmasterid=" + costId + @"
                                 group by bb.item_name";
            return _OleDB.GetDataTable(strsql);
        }
        /// <summary>
        /// 获取处方头列表
        /// </summary>
        /// <param name="InvoiceNo"></param>
        /// <param name="isSend"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public DataTable GetPresMasterList( string InvoiceNo , bool isSend , int deptId , string presId , string dateString )
        {
//            string sql = @"select * from 
//            (
//                select presmasterid,patlistid,prestype,ticketnum,'' as Address 
//                from mz_presmaster 
//                where drug_flag = " + ( isSend ? "1" : "0" ) + dateString + " and charge_flag=1 and record_flag=0 and EXECDEPTCODE = '" + deptId + @"'
//            ) a
//            left join
//            (select patlistid,patid, patname,patsex from mz_patlist where patname<>'') b on a.patlistid=b.patlistid";
//            sql += " where a.prestype in ('0','1','2','3')";
//            if ( presId != "" )
//            {
//                sql += " and a.presmasterid=" + presId;
//            }
//            return _OleDB.GetDataTable( sql );
            string strWhere_1=Tables.mz_patlist.PATNAME +_OleDB.NotEqualTo()+ "''";
            string childtable_1=_OleDB.ChildTable(Tables.MZ_PATLIST,"b",strWhere_1,
			Tables.mz_patlist.PATLISTID,
			Tables.mz_patlist.PATID,
			 Tables.mz_patlist.PATNAME,
			Tables.mz_patlist.PATSEX,
            Tables.mz_patlist.AGE,
            Tables.mz_patlist.VISITNO);

            string strWhere_3=Tables.mz_presmaster.DRUG_FLAG +_OleDB.EuqalTo()+  (( isSend ? "1" : "0" ) + dateString )  +
            _OleDB.And()+ Tables.mz_presmaster.CHARGE_FLAG +_OleDB.EuqalTo()+ "1" +_OleDB.And()+ Tables.mz_presmaster.RECORD_FLAG +_OleDB.EuqalTo()+ "0" +
            _OleDB.And()+ Tables.mz_presmaster.EXECDEPTCODE +_OleDB.EuqalTo()+ "'"+deptId+"'";
            string childtable_2=_OleDB.ChildTable(Tables.MZ_PRESMASTER,"a",strWhere_3,
			                                    Tables.mz_presmaster.PRESMASTERID,
			                                    Tables.mz_presmaster.PATLISTID,
			                                    Tables.mz_presmaster.PRESTYPE,
			                                    Tables.mz_presmaster.TICKETNUM,
			                                    _OleDB.FiledNameBM("''","Address"));

            string tb=childtable_2+_OleDB.LeftJoin()+childtable_1+_OleDB.ON("a."+Tables.mz_presmaster.PATLISTID,"b."+Tables.mz_patlist.PATLISTID);
            string strWhere_5 = "a." + Tables.mz_presmaster.PRESTYPE + _OleDB.In("'1'", "'2'", "'3'");
            if (presId != "")
            {
                strWhere_5+=_OleDB.And()+"a."+Tables.mz_presmaster.PRESMASTERID+_OleDB.EuqalTo()+presId;
            }

            string strsql=_OleDB.Table(tb,"",strWhere_5,
			"*");
            
            return _OleDB.GetDataTable( strsql);
        }
        /// <summary>
        /// 获取病人处方信息
        /// </summary>
        /// <param name="InvoiceSerialNo">发票序列号</param>
        /// <param name="deptId">科室ID</param>
        /// <returns></returns>
        public DataTable GetPatPresInfo( string InvoiceSerialNo , int deptId )
        {
            /*string sql = @"select * 
                            from
                            (
                                select b.tolal_fee as TOLAL_FEE,a.ticketnum,a.presdoccode,(select name from base_employee_property where employee_id=cast( (case when a.presdoccode='' then '0' else a.presdoccode end) as int)) as presdocname,
                                a.presdeptcode,(select name from base_dept_property where dept_id=cast((case when a.presdeptcode='' then '0' else a.presdeptcode end) as int)) as presdeptname,1 as ISDISPENSE,
                                b.presorderid,b.itemid,b.sell_price,b.buy_price,b.relationnum,b.amount,b.presamount 
                                from mz_presmaster a ,mz_presorder b 
                                where a.execdeptcode='" + deptId + "' and a.presmasterid=b.presmasterid and a.ticketnum='" + InvoiceSerialNo + @"' and a.drug_flag=0 and a.charge_flag=1 and record_flag=0
                            ) a,
                            (
                                select A.MakerDicID,D.ProductName,B.Spec as STANDARD,B.SpecDicID,B.ChemName as ITEMNAME,B.UNIT as UnitId,C.UnitName as Unit
                                 from YP_MakerDic A
                                 left outer join YP_SpecDic B
                                 on A.SpecDicID=B.SpecDicID
                                 left outer join YP_UnitDic C
                                 on B.UNIT=C.UnitDicID
                                 left outer join YP_ProductDic D
                                 on A.ProductID=D.ProductID 
                             ) b where a.itemid=b.MakerDicID";
            return _OleDB.GetDataTable( sql );*/

            string casewhen_1=_OleDB.CASEWhen("", _OleDB.When()+  "a.presdoccode=''" + _OleDB.Then()+  "'0'" ,_OleDB.Else()+ "a.presdoccode");
            string casewhen_2=_OleDB.CASEWhen("", _OleDB.When()+  "a.presdeptcode=''" + _OleDB.Then()+  "'0'" ,_OleDB.Else()+ "a.presdeptcode");
            string childtable_3=_OleDB.ChildTable(_OleDB.TableNameBM(Tables.YP_MAKERDIC,"a")+ "  left outer join yp_specdic b  on a.specdicid=b.specdicid left outer join yp_unitdic c      on b.unit=c.unitdicid      left outer join yp_productdic d      on a.productid=d.productid","b","",
                                                        "a.makerdicid",
                                                        "d.productname" ,
                                                        _OleDB.FiledNameBM( "b.spec" , "standard" ) ,
                                                        "b.specdicid" ,
                                                        _OleDB.FiledNameBM( "b.chemname" , "itemname" ) ,
                                                        _OleDB.FiledNameBM( "b.unit" , "unitid" ) ,
                                                        _OleDB.FiledNameBM( "c.unitname" , "unit" ) );
            string cast_1=_OleDB.DBConvert(casewhen_1,"int");
            string strWhere_2=Tables.base_employee_property.EMPLOYEE_ID +_OleDB.EuqalTo()+ cast_1;
            string childtable_4=_OleDB.ChildTable(Tables.BASE_EMPLOYEE_PROPERTY,"",strWhere_2,
            Tables.base_employee_property.NAME);
            string cast_3=_OleDB.DBConvert(casewhen_2,"int");
            string strWhere_4=Tables.base_dept_property.DEPT_ID +_OleDB.EuqalTo()+ cast_3;
            string childtable_5=_OleDB.ChildTable(Tables.BASE_DEPT_PROPERTY,"",strWhere_4,
                                                                    Tables.base_dept_property.NAME);
            string strWhere_5 = "a.execdeptcode" + _OleDB.EuqalTo() + "'" + deptId + "'" + _OleDB.And() + "a.presmasterid" + _OleDB.EuqalTo() + "b.presmasterid" + _OleDB.And() + "a.ticketnum" + _OleDB.EuqalTo() + "'" + InvoiceSerialNo + "'" + _OleDB.And() + "a.drug_flag" + _OleDB.EuqalTo() + "0" + _OleDB.And() + "a.charge_flag" + _OleDB.EuqalTo() + "1" + _OleDB.And() + Tables.mz_presmaster.RECORD_FLAG + _OleDB.EuqalTo() + "0";

            string childtable_6 = _OleDB.ChildTable(_OleDB.TableName(_OleDB.TableNameBM(Tables.MZ_PRESMASTER, "a"),
                                                                     _OleDB.TableNameBM(Tables.MZ_PRESORDER, "b")), "a", strWhere_5,
                                                    _OleDB.FiledNameBM("b.tolal_fee", "tolal_fee"), 
                                                    "a.ticketnum", "a.presdoccode",
                                                    _OleDB.FiledNameBM(childtable_4, "presdocname"), "a.presdeptcode", _OleDB.FiledNameBM(childtable_5, "presdeptname"),_OleDB.FiledNameBM("1", "isdispense"), "b.presorderid", "b.itemid", "b.sell_price", "b.buy_price", "b.relationnum", "b.amount", "b.presamount");

            string strWhere_6 = "a.itemid" + _OleDB.EuqalTo() + "b.makerdicid";
            string strsql = _OleDB.Table(_OleDB.TableName(childtable_6, childtable_3), "", strWhere_6, "*");
            return _OleDB.GetDataTable( strsql );

        }
        /// <summary>
        /// 获取门诊划价收费的项目选择卡数据源
        /// </summary>
        /// <param name="dataType">数据类型：0-划价 1-收费</param>
        /// <returns></returns>
        public DataTable GetItemSelectedCardDataSource( int dataType )
        {
            if ( dataType == 1 )
            {
                //全部
                return BindEntity<object>.CreateInstanceDAL( _OleDB , Views.VI_MZ_SHOWCARD ).GetList( "1=1 order by " + Views.vi_mz_showcard.ITEM_NAME + "," + Views.vi_mz_showcard.ISDRUG );
            }
            else
            {
                //仅药品
                return BindEntity<object>.CreateInstanceDAL( _OleDB , Views.VI_MZ_SHOWCARD ).GetList( Views.vi_mz_showcard.ISDRUG + _OleDB.EuqalTo( ) + "1" );
            }

            //string strsql = "";
            //if ( dataType == 1 )
            //{
            //    string strWhere_1 = "a." + Tables.base_item_dept.DEPT_ID + _OleDB.EuqalTo( ) + "b." + Tables.base_dept_property.DEPT_ID + _OleDB.And( ) +
            //            "a." + Tables.base_item_dept.DEFAULT_FLAG + _OleDB.EuqalTo( ) + "1";
            //    string childtable_1 = _OleDB.ChildTable( _OleDB.TableName( _OleDB.TableNameBM( Tables.BASE_ITEM_DEPT , "a" ) , _OleDB.TableNameBM( Tables.BASE_DEPT_PROPERTY , "b" ) ) , "bb" , strWhere_1 ,
            //                "a." + Tables.base_item_dept.ITEM_ID ,
            //                "a." + Tables.base_item_dept.DEPT_ID ,
            //                "b." + Tables.base_dept_property.NAME );
            //    string[] when1 = new string[3];
            //    when1[0] = _OleDB.When( ) + Views.vi_item_drug.ITEMTYPE + _OleDB.EuqalTo( ) + "1" + _OleDB.Then( ) + "'01'";
            //    when1[1] = _OleDB.When( ) + Views.vi_item_drug.ITEMTYPE + _OleDB.EuqalTo( ) + "2" + _OleDB.Then( ) + "'02'";
            //    when1[2] = _OleDB.When( ) + Views.vi_item_drug.ITEMTYPE + _OleDB.EuqalTo( ) + "3" + _OleDB.Then( ) + "'03'";
            //    string casewhen_2 = _OleDB.CASEWhen( "" , when1 );
            //    string _gs_1_2 = _OleDB.DBConvert( "bb." + Tables.base_dept_property.DEPT_ID , "char(10)" );

            //    string tb = _OleDB.TableNameBM( Tables.BASE_SERVICE_ITEMS , "aa" ) + _OleDB.LeftJoin( ) + childtable_1 + _OleDB.ON( "aa." + Tables.base_service_items.ITEM_ID , "bb." + Tables.base_service_items.ITEM_ID );
            //    string childtable_3 = _OleDB.ChildTable( tb , "aaa" , "" ,
            //        "aa." + Tables.base_service_items.ITEM_ID ,
            //        _OleDB.FiledNameBM( Tables.base_service_items.STD_CODE , "code" ) ,
            //         Tables.base_service_items.ITEM_NAME ,
            //        Tables.base_service_items.PY_CODE ,
            //        Tables.base_service_items.WB_CODE ,
            //        _OleDB.FiledNameBM( "''" , "standard" ) ,
            //        Tables.base_service_items.ITEM_UNIT ,
            //        _OleDB.FiledNameBM( Tables.base_service_items.ITEM_UNIT , "base_unit" ) ,
            //         Tables.base_service_items.PRICE ,
            //        _OleDB.FiledNameBM( "0" , "complex_id" ) ,
            //        _OleDB.FiledNameBM( "''" , "address" ) ,
            //        _OleDB.FiledNameBM( "0" , "isdrug" ) ,
            //        Tables.base_service_items.STATITEM_CODE ,
            //        _OleDB.FiledNameBM( "1" , "hjxs" ) ,
            //        _OleDB.FiledNameBM( "bb." + Tables.base_dept_property.NAME , "EXEC_DEPT_NAME" ) ,
            //        _OleDB.FiledNameBM( _gs_1_2 , "EXEC_DEPT_CODE" ) ,
            //        _OleDB.FiledNameBM( "1" , " AMOUNT" ) );
            //    string strWhere_4 = Views.vi_item_drug.STORENUM + _OleDB.GreaterThan( ) + "0";
            //    string childtable_4 = _OleDB.Table( childtable_3 , "" , "" ,
            //        Tables.base_service_items.ITEM_ID ,
            //        Tables.base_dept_property.CODE ,
            //        Tables.base_service_items.ITEM_NAME ,
            //        Tables.base_service_items.PY_CODE ,
            //        Tables.base_service_items.WB_CODE ,
            //          "standard" ,
            //        Tables.base_service_items.ITEM_UNIT ,
            //         "base_unit" ,
            //        Tables.base_service_items.PRICE ,
            //        "complex_id" ,
            //        "address" ,
            //        "isdrug" ,
            //        Tables.base_service_items.STATITEM_CODE ,
            //        "hjxs" ,
            //        "EXEC_DEPT_NAME" ,
            //        "EXEC_DEPT_CODE" ,
            //        "AMOUNT" );

            //    string childtable_5 = _OleDB.ChildTable( Views.VI_ITEM_DRUG , "" , strWhere_4 ,
            //       _OleDB.FiledNameBM( Views.vi_item_drug.ITEMID , "item_id" ) ,
            //       _OleDB.FiledNameBM( Views.vi_item_drug.D_CODE , "code" ) ,
            //       _OleDB.FiledNameBM( Views.vi_item_drug.BYNAME , "item_name" ) ,
            //       Views.vi_item_drug.PY_CODE ,
            //       Views.vi_item_drug.WB_CODE ,
            //       Views.vi_item_drug.STANDARD ,
            //       _OleDB.FiledNameBM( Views.vi_item_drug.PACKUNIT , "item_unit" ) ,
            //       _OleDB.FiledNameBM( Views.vi_item_drug.UNIT , "base_unit" ) ,
            //       _OleDB.FiledNameBM( Views.vi_item_drug.SELL_PRICE , "price" ) ,
            //       _OleDB.FiledNameBM( "0" , "complex_id" ) ,
            //       Views.vi_item_drug.ADDRESS ,
            //       _OleDB.FiledNameBM( "1" , "isdrug" ) ,
            //       _OleDB.FiledNameBM( casewhen_2 , "statitem_code" ) ,
            //       _OleDB.FiledNameBM( Views.vi_item_drug.RELATIONNUM , "hjxs" ) ,
            //       _OleDB.FiledNameBM( Views.vi_item_drug.EXECDEPTNAME , "EXEC_DEPT_NAME" ) ,
            //       _OleDB.FiledNameBM( Views.vi_item_drug.EXECDEPTCODE , "EXEC_DEPT_CODE" ) ,
            //       _OleDB.FiledNameBM( Views.vi_item_drug.STORENUM , "amount" ) );
            //    string tb1 = childtable_4 + _OleDB.UnionAll( ) + childtable_5;

            //    string leftJoin = _OleDB.LeftJoin( ) + _OleDB.TableNameBM( Tables.NCMS_MATCH_CATALOG_TEMP , "b" ) + _OleDB.ON( "item_id" , "cast(b.HOSPITAL_CODE as integer)" );

            //    strsql = _OleDB.Table( _OleDB.TableNameBM( tb1 , "a" ) + leftJoin , "" , "" , "*" );
            //}
            //else
            //{
            //    string[] when = new string[3];
            //    when[0] = _OleDB.When( ) + Views.vi_item_drug.ITEMTYPE + _OleDB.EuqalTo( ) + "1" + _OleDB.Then( ) + "'01'";
            //    when[1] = _OleDB.When( ) + Views.vi_item_drug.ITEMTYPE + _OleDB.EuqalTo( ) + "2" + _OleDB.Then( ) + "'02'";
            //    when[2] = _OleDB.When( ) + Views.vi_item_drug.ITEMTYPE + _OleDB.EuqalTo( ) + "3" + _OleDB.Then( ) + "'03'";
            //    string casewhen_1 = _OleDB.CASEWhen( "" , when );
            //    string strWhere_1 = Views.vi_item_drug.STORENUM + _OleDB.GreaterThan( ) + "0";
            //    strsql = _OleDB.Table( Views.VI_ITEM_DRUG , "" , strWhere_1 ,
            //    _OleDB.FiledNameBM( Views.vi_item_drug.ITEMID , "item_id" ) ,
            //    _OleDB.FiledNameBM( Views.vi_item_drug.D_CODE , "code" ) ,
            //    _OleDB.FiledNameBM( Views.vi_item_drug.BYNAME , "item_name" ) ,
            //    Views.vi_item_drug.PY_CODE ,
            //    Views.vi_item_drug.WB_CODE ,
            //    Views.vi_item_drug.STANDARD ,
            //    _OleDB.FiledNameBM( Views.vi_item_drug.PACKUNIT , "item_unit" ) ,
            //    _OleDB.FiledNameBM( Views.vi_item_drug.UNIT , "base_unit" ) ,
            //    _OleDB.FiledNameBM( Views.vi_item_drug.SELL_PRICE , "price" ) ,
            //    _OleDB.FiledNameBM( "0" , "complex_id" ) ,
            //    Views.vi_item_drug.ADDRESS ,
            //    _OleDB.FiledNameBM( "1" , "isdrug" ) ,
            //    _OleDB.FiledNameBM( casewhen_1 , "statitem_code" ) ,
            //    _OleDB.FiledNameBM( Views.vi_item_drug.RELATIONNUM , "hjxs" ) ,
            //    _OleDB.FiledNameBM( Views.vi_item_drug.EXECDEPTNAME , "EXEC_DEPT_NAME" ) ,
            //    _OleDB.FiledNameBM( Views.vi_item_drug.EXECDEPTCODE , "EXEC_DEPT_CODE" ) ,
            //    _OleDB.FiledNameBM( Views.vi_item_drug.STORENUM , "amount" ) );
            //}
            //return _OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 获取门诊科室选择卡数据源  DEPT_ID,NAME,PY_CODE
        /// </summary>
        /// <returns></returns>
        public   DataTable GetDeptSelectedCardDataSource(bool all)
        {
            string in_1_1=_OleDB.In("'001','004'");
            string strWhere_2 = Tables.base_dept_property.DELETED + _OleDB.EuqalTo() + "0";
            if (!all)
                strWhere_2+= _OleDB.And() + Tables.base_dept_property.TYPE_CODE + in_1_1 + _OleDB.And() + Tables.base_dept_property.MZ_FLAG + _OleDB.EuqalTo() + "1";

            string strsql=_OleDB.Table(Tables.BASE_DEPT_PROPERTY,"",strWhere_2,
			                                                                    Tables.base_dept_property.DEPT_ID,
			                                                                    Tables.base_dept_property.NAME,
			                                                                    Tables.base_dept_property.PY_CODE);
            return _OleDB.GetDataTable( strsql );
        }       
        /// <summary>
        /// 根据大项目获取发票项目
        /// </summary>
        public   DataTable GetInvoiceItemByStatItemCode( string StatItemCode )
        {
            string strWhere_1 = "A." + Tables.base_stat_item.MZFP_CODE + _OleDB.EuqalTo() + "B." + Tables.base_stat_mzfp.CODE + _OleDB.And() + "A." + Tables.base_stat_item.CODE + _OleDB.EuqalTo() + "'" + StatItemCode + "'";
            string strsql = _OleDB.Table( _OleDB.TableName( _OleDB.TableNameBM( Tables.BASE_STAT_ITEM, "A" ), _OleDB.TableNameBM( Tables.BASE_STAT_MZFP, "B" ) ), "", strWhere_1,
                                     "B." + Tables.base_stat_mzfp.CODE,
                                      "B." + Tables.base_stat_mzfp.ITEM_NAME );
            return _OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 发票查询
        /// </summary>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <param name="OperatorId"></param>
        /// <returns></returns>
        public DataTable GetChargeInvoiceList( DateTime dateTimeFrom , DateTime dateTimeTo , int OperatorId )
        {
            string strWhere_1 = Tables.mz_costmaster.RECORD_FLAG + _OleDB.EuqalTo() + "2";
            string childtable_1 = _OleDB.ChildTable( Tables.MZ_COSTMASTER, "b", strWhere_1,
            Tables.mz_costmaster.TICKETNUM,
            Tables.mz_costmaster.TOTAL_FEE,
            Tables.mz_costmaster.COSTDATE,
            Tables.mz_costmaster.CHARGENAME,
            Tables.mz_costmaster.HANG_FLAG );
            string childtable_2 = _OleDB.ChildTable( Tables.MZ_PATLIST, "b", "",
                                Tables.mz_patlist.PATLISTID,
                                Tables.mz_patlist.PATNAME ,
                                Tables.mz_patlist.VISITNO,
                                Tables.mz_patlist.MEDITYPE);
            string _gs_1_3 = _OleDB.ABS( "b." + Tables.mz_costmaster.TOTAL_FEE );

            string strWhere_5 = Tables.mz_costmaster.RECORD_FLAG + _OleDB.In( "0", "1" ) + _OleDB.And() + Tables.mz_costmaster.CHARGECODE +
                _OleDB.EuqalTo() + "'" + OperatorId.ToString() + "'" + _OleDB.And() + Tables.mz_costmaster.COSTDATE +
                _OleDB.Between() + "'" + dateTimeFrom.ToString( "yyyy-MM-dd HH:mm:ss" ) + "'  " +
                _OleDB.And() + " '" + dateTimeTo.ToString( "yyyy-MM-dd HH:mm:ss" ) + @"' ";

            string childtable_3 = _OleDB.ChildTable( Tables.MZ_COSTMASTER, "a", strWhere_5,
             Tables.mz_costmaster.TICKETNUM,
             Tables.mz_costmaster.TICKETCODE,
             Tables.mz_costmaster.PATLISTID,
             Tables.mz_costmaster.TOTAL_FEE,
             Tables.mz_costmaster.MONEY_FEE,
             Tables.mz_costmaster.POS_FEE ,
             Tables.mz_costmaster.VILLAGE_FEE,
             Tables.mz_costmaster.FAVOR_FEE,
             Tables.mz_costmaster.SELF_TALLY,
             Tables.mz_costmaster.COSTDATE,
             Tables.mz_costmaster.CHARGENAME,
             Tables.mz_costmaster.HANG_FLAG );
            string tb = childtable_3 + _OleDB.LeftJoin() + childtable_1 + _OleDB.ON( "a." + Tables.mz_costmaster.TICKETNUM, "b." + Tables.mz_costmaster.TICKETNUM + _OleDB.And() + "a." + Tables.mz_costmaster.HANG_FLAG + _OleDB.EuqalTo() + "b." + Tables.mz_costmaster.HANG_FLAG );

            string childtable_4 = _OleDB.ChildTable( tb, "a", "",
                                        "a.*",
                                _OleDB.FiledNameBM( "b." + Tables.mz_costmaster.COSTDATE, "unchargedate" ),
                                _OleDB.FiledNameBM( _gs_1_3, "unchargecost" ),
                                _OleDB.TableNameBM( "b." + Tables.mz_costmaster.CHARGENAME, "unchargeuser" ) );
            string tb1 = childtable_4 + _OleDB.LeftJoin() + childtable_2 + _OleDB.ON( "a." + Tables.mz_costmaster.PATLISTID, "b." + Tables.mz_patlist.PATLISTID );

            string strsql = _OleDB.Table( tb1, "", "",
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.TICKETNUM, "invoiceno" ),
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.TICKETCODE , "perfchar" ) ,
                                                _OleDB.FiledNameBM( "b." + Tables.mz_patlist.PATNAME, "patientname" ),
                                                _OleDB.FiledNameBM( "b." + Tables.mz_patlist.VISITNO , "VISITNO" ) ,
                                                _OleDB.FiledNameBM( "b." + Tables.mz_patlist.MEDITYPE , "MEDITYPE" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.TOTAL_FEE, "cost" ),
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.TOTAL_FEE + "-a.POS_FEE-a.VILLAGE_FEE-a.FAVOR_FEE-a.SELF_TALLY" , "cash" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.POS_FEE , "pos" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.VILLAGE_FEE , "tally" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.FAVOR_FEE , "favor" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.SELF_TALLY , "self_tally" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.COSTDATE, "chargedate" ),
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.CHARGENAME, "chargeuser" ),
                                                "a.unchargedate" ,
                                                "a." + "unchargecost",
                                                "a." + "unchargeuser",
                                                "a.hang_flag");
            return _OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 发票查询
        /// </summary>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <returns></returns>
        public   DataTable GetChargeInvoiceList( DateTime dateTimeFrom , DateTime dateTimeTo )
        {
            string strWhere_1 = Tables.mz_costmaster.RECORD_FLAG + _OleDB.EuqalTo() + "2";
            string childtable_1 = _OleDB.ChildTable( Tables.MZ_COSTMASTER, "b", strWhere_1,
            Tables.mz_costmaster.TICKETNUM,
            Tables.mz_costmaster.TOTAL_FEE,
            Tables.mz_costmaster.COSTDATE,
            Tables.mz_costmaster.CHARGENAME ,
            Tables.mz_costmaster.HANG_FLAG );
            string childtable_2 = _OleDB.ChildTable( Tables.MZ_PATLIST, "b", "",
                                Tables.mz_patlist.PATLISTID,
                                Tables.mz_patlist.PATNAME ,
                                Tables.mz_patlist.VISITNO,
                                Tables.mz_patlist.MEDITYPE);
            string _gs_1_3 = _OleDB.ABS( "b." + Tables.mz_costmaster.TOTAL_FEE );

            string strWhere_5 = Tables.mz_costmaster.RECORD_FLAG + _OleDB.In( "0", "1" ) + _OleDB.And() + Tables.mz_costmaster.COSTDATE +
                _OleDB.Between() + "'" + dateTimeFrom.ToString( "yyyy-MM-dd HH:mm:ss" ) + "' " +
                _OleDB.And() + " '" + dateTimeTo.ToString( "yyyy-MM-dd HH:mm:ss" ) + @"'";

            string childtable_3 = _OleDB.ChildTable( Tables.MZ_COSTMASTER, "a", strWhere_5,
             Tables.mz_costmaster.TICKETNUM,
             Tables.mz_costmaster.TICKETCODE,
             Tables.mz_costmaster.PATLISTID,
             Tables.mz_costmaster.TOTAL_FEE,
             Tables.mz_costmaster.COSTDATE,
             Tables.mz_costmaster.MONEY_FEE ,
             Tables.mz_costmaster.POS_FEE ,
             Tables.mz_costmaster.VILLAGE_FEE ,
             Tables.mz_costmaster.FAVOR_FEE ,
             Tables.mz_costmaster.SELF_TALLY,
             Tables.mz_costmaster.CHARGENAME,
             Tables.mz_costmaster.HANG_FLAG );
            //string tb = childtable_3 + _OleDB.LeftJoin() + childtable_1 + _OleDB.ON( "a." + Tables.mz_costmaster.TICKETNUM, "b." + Tables.mz_costmaster.TICKETNUM );
            string tb = childtable_3 + _OleDB.LeftJoin( ) + childtable_1 + _OleDB.ON( "a." + Tables.mz_costmaster.TICKETNUM , "b." + Tables.mz_costmaster.TICKETNUM + _OleDB.And( ) + "a." + Tables.mz_costmaster.HANG_FLAG + _OleDB.EuqalTo( ) + "b." + Tables.mz_costmaster.HANG_FLAG );

            string childtable_4 = _OleDB.ChildTable( tb, "a", "",
                                        "a.*",
                                _OleDB.FiledNameBM( "b." + Tables.mz_costmaster.COSTDATE, "unchargedate" ),
                                _OleDB.FiledNameBM( _gs_1_3, "unchargecost" ),
                                _OleDB.TableNameBM( "b." + Tables.mz_costmaster.CHARGENAME, "unchargeuser" ) );
            string tb1 = childtable_4 + _OleDB.LeftJoin() + childtable_2 + _OleDB.ON( "a." + Tables.mz_costmaster.PATLISTID, "b." + Tables.mz_patlist.PATLISTID );

            string strsql = _OleDB.Table( tb1, "", "",
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.TICKETNUM, "invoiceno" ),
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.TICKETCODE , "perfchar" ) ,
                                                _OleDB.FiledNameBM( "b." + Tables.mz_patlist.PATNAME, "patientname" ),
                                                _OleDB.FiledNameBM( "b." + Tables.mz_patlist.VISITNO , "VISITNO" ) ,
                                                _OleDB.FiledNameBM( "b." + Tables.mz_patlist.MEDITYPE , "MEDITYPE" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.TOTAL_FEE, "cost" ),
                                                //_OleDB.FiledNameBM( "a." + Tables.mz_costmaster.MONEY_FEE , "cash" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.TOTAL_FEE + "-a.POS_FEE-a.VILLAGE_FEE-a.FAVOR_FEE-a.SELF_TALLY" , "cash" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.POS_FEE , "pos" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.VILLAGE_FEE , "tally" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.FAVOR_FEE , "favor" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.SELF_TALLY , "self_tally" ) ,
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.COSTDATE, "chargedate" ),
                                                _OleDB.FiledNameBM( "a." + Tables.mz_costmaster.CHARGENAME, "chargeuser" ),
                                                "a.unchargedate" , 
                                                "a." + "unchargecost", 
                                                "a." + "unchargeuser" ,
                                                "a.hang_flag" );
            return _OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 获取项目的执行科室
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public DataTable GetItemExecDepartment( int ItemID )
        {

            string strWhere_1 = Tables.base_item_dept.ITEM_ID + _OleDB.EuqalTo() + ItemID;
            string childtable_1 = _OleDB.ChildTable( Tables.BASE_ITEM_DEPT, "", strWhere_1, Tables.base_item_dept.DEPT_ID );
            string strWhere_2 = Tables.base_dept_property.DEPT_ID + _OleDB.In() + childtable_1;
            string strsql = _OleDB.Table( Tables.BASE_DEPT_PROPERTY, "", strWhere_2,
                            Tables.base_dept_property.DEPT_ID,
                            Tables.base_dept_property.NAME,
                            Tables.base_dept_property.PY_CODE );
            DataTable tbExecDept = _OleDB.GetDataTable( strsql );
            if ( tbExecDept.Rows.Count == 0 )
            {
                return GetDeptSelectedCardDataSource( false );
            }
            else
                return tbExecDept;
        }
        /// <summary>
        /// 获取所有项目的执行科室
        /// </summary>
        /// <returns></returns>
        public DataTable GetItemExecDepartment()
        {

            string strWhere_1 = "a.dept_id " + _OleDB.EuqalTo() + " b.dept_id";
            string strsql = _OleDB.Table( _OleDB.TableNameBM( Tables.BASE_ITEM_DEPT, "a" ) + "," + _OleDB.TableNameBM( Tables.BASE_DEPT_PROPERTY, "b" ), "", strWhere_1,
                        Tables.base_item_dept.ITEM_ID,
                        Tables.base_item_dept.COMPLEX_ID,
                        "a.dept_id",
                        "b.name" );
            return _OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 获取指定时间段内具有有效处方的病人列表
        /// </summary>
        /// <returns></returns>
        /// <param name="PresbeginDate"></param>
        /// <param name="PresendDate"></param>
        /// <param name="VisitbeginDate"></param>
        /// <param name="VisitendDate"></param>
        public DataTable GetPatientListByExistsPrescrition(string VisitbeginDate,string VisitendDate, string PresbeginDate,string PresendDate )
        {
            string strWhere_1 = Tables.mz_presmaster.PRESDATE + _OleDB.Between() + "'" + PresbeginDate + "'" + _OleDB.And() + "'" + PresendDate + "'" + _OleDB.And() + Tables.mz_presmaster.COSTMASTERID + _OleDB.EuqalTo() + "0" + _OleDB.And() + Tables.mz_presmaster.HAND_FLAG + _OleDB.EuqalTo() + "1";
            string childtable_1=_OleDB.ChildTable(Tables.MZ_PRESMASTER,"",strWhere_1,Tables.mz_presmaster.PATLISTID);
            string strWhere_2=Tables.mz_patlist.PATLISTID + _OleDB.In() + childtable_1 + _OleDB.And() + Tables.mz_patlist.CUREDATE + _OleDB.Between() + "'"+VisitbeginDate +"'" + _OleDB.And() + "'"+ VisitendDate + "'";
            string strsql=_OleDB.Table(Tables.MZ_PATLIST,"",strWhere_2,"*");
            return _OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 获取医生级别和挂号类型的对应关系
        /// </summary>
        /// <returns></returns>
        public DataTable GetRegisterTypeRelation()
        {
            return BindEntity<HIS.Model.MZ_DOCTYPE_REGTYPE>.CreateInstanceDAL( _OleDB ).GetList( "" );
        }
        /// <summary>
        /// 获取未交账的收费员列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetNotHandInAccountChargeor()
        {
            string strSql = "";
            strSql = _OleDB.Table( HIS.BLL.Tables.MZ_COSTMASTER, "", "accountid=0 and record_flag in (0,1,2)", _OleDB.Distinct( HIS.BLL.Tables.mz_costmaster.CHARGECODE ), HIS.BLL.Tables.mz_costmaster.CHARGENAME );
            return _OleDB.GetDataTable( strSql );
        }
        /// <summary>
        /// 获取病人唯一ID
        /// </summary>
        /// <returns></returns>
        public decimal GetNewPatId()
        {
            object obj = this._OleDB.GetDataResult( "VALUES DECIMAL(CURRENT TIMESTAMP)" );
            if ( Convert.IsDBNull( obj ) )
                throw new Exception( "获取时间戳发生错误" );
            else
                return Convert.ToDecimal( obj );
        }
        /// <summary>
        /// 获取病人挂号列表
        /// </summary>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <param name="OperatorId"></param>
        /// <returns></returns>
        public DataTable GetRegPatientList( DateTime? dateBegin , DateTime? dateEnd , int? OperatorId )
        {
//            string sql = @"select a.patname,a.visitno,b.cardno,d.name as dept_name,a.regname,e.name as emp_name,c.total_fee,a.curedate ,c.record_flag 
//                            from mz_patlist a 
//                            left join mz_patient b on a.patid=b.patid 
//                            left join mz_costmaster c on a.patlistid=c.patlistid
//                            left join base_dept_property d on a.curedeptcode = cast(d.dept_id as char(10))
//                            left join base_employee_property e on a.cureempcode = cast(e.employee_id as char(10))
//                            where c.record_flag in (0,1);";
            string sql = @"select * from (select a.patname,a.visitno,b.medicard as cardno,a.reg_dept_name as reg_dept, 
                                a.regname as reg_type, a.reg_doc_name as reg_doc,c.total_fee as reg_fee, 
                                a.curedate as reg_date, c.record_flag,c.ticketnum as reg_invoiceno,c.ticketcode, 
                                c.chargecode
                              from mz_patlist a
                                left join patientinfo b on a.patid=b.patid and a.workid=b.workid
                                left join mz_costmaster c on a.patlistid=c.patlistid and a.workid=c.workid
                              where c.record_flag in (0,1) and c.hang_flag=0 and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID.ToString( ) + " and c.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID.ToString( ) + ") a";

            string strWhere = "reg_date between '" + dateBegin.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) + "' and '" + dateEnd.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) + "' " ;
            if ( OperatorId != 0 )
                strWhere += " and chargecode='" + OperatorId + "'";
            strWhere += _OleDB.OrderBy( ) + " REG_DATE desc";

            sql = sql + " where " + strWhere;

            return _OleDB.GetDataTable( sql );
            //return BindEntity<object>.CreateInstanceDAL( _OleDB, "VI_REG_PATLIST" ).GetList( strWhere );
        }
        /// <summary>
        /// 根据卡号获取病人基本信息
        /// </summary>
        /// <param name="hisCardNo"></param>
        /// <returns></returns>
        public DataRow GetRegPatientByHisCardNo( string hisCardNo )
        {
            string strSql = _OleDB.Table( Tables.PATIENTINFO, "", Tables.patientinfo.MEDICARD + _OleDB.EuqalTo() + "'" + hisCardNo + "'", "*" );
            return _OleDB.GetDataRow( strSql );
        }
        /// <summary>
        /// 根据发票号获取挂号病人
        /// </summary>
        /// <param name="InvoiceNo"></param>
        /// <returns></returns>
        public DataRow GetRegPatientByInvoiceNo( string PerfChar, string InvoiceNo )
        {
            string strWhere_1 = Tables.mz_costmaster.TICKETCODE + _OleDB.EuqalTo( ) + "'" + PerfChar + "'" + _OleDB.And( ) + Tables.mz_costmaster.TICKETNUM + _OleDB.EuqalTo( ) + "'" + InvoiceNo + "'" + _OleDB.And( ) + Tables.mz_costmaster.RECORD_FLAG + _OleDB.EuqalTo( ) + "0" + _OleDB.And( ) + Tables.mz_costmaster.HANG_FLAG + _OleDB.EuqalTo( ) + "0";
            string childtable_1=_OleDB.ChildTable(Tables.MZ_COSTMASTER,"",strWhere_1,
			Tables.mz_costmaster.PATLISTID);
            string strWhere_2="a.patlistid" +_OleDB.EuqalTo()+ childtable_1;
            string strsql = _OleDB.Table( Tables.MZ_PATLIST , "a" + _OleDB.LeftJoin( ) +  _OleDB.TableNameBM(Tables.PATIENTINFO," b") + _OleDB.ON( "a.patid " , " b.patid" ) , strWhere_2 ,
			"*");
            return _OleDB.GetDataRow( strsql );

          
 
        }
        /// <summary>
        /// 根据诊疗卡号获取病人挂号列表
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public DataTable GetRegPatientListByCardNo( string cardNo )
        {
            //select patlistid,visitno,b.patid,b.patname,b.patsex,CUREDATE,b.pym,b.wbm from patientinfo a,mz_patlist b where a.patid=b.patid
            string strWhere = "a.patid=b.patid" + _OleDB.And( ) + "a.medicard='" + cardNo + "'";
            string tbs = _OleDB.TableName( _OleDB.TableNameBM( Tables.PATIENTINFO , "a" ) , _OleDB.TableNameBM( Tables.MZ_PATLIST , "b" ) );
            string strsql = _OleDB.Table( tbs , "" , strWhere ,
                                                    Tables.mz_patlist.PATLISTID ,
                                                    Tables.mz_patlist.VISITNO ,
                                                    "a." + Tables.patientinfo.PATID ,
                                                    "a." + Tables.mz_patlist.PATNAME ,
                                                    "a." + Tables.patientinfo.PATSEX ,
                                                    Tables.mz_patlist.CUREDATE ,
                                                    "a." + Tables.patientinfo.PYM ,
                                                    "a." + Tables.patientinfo.WBM );
            return _OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 根据就诊号获取病人挂号信息
        /// </summary>
        /// <param name="VisitNo"></param>
        /// <returns></returns>
        public DataRow GetRegisterInfoByVisitNo( string VisitNo )
        {
            string strWhere_1=Tables.mz_patlist.VISITNO +_OleDB.EuqalTo()+ "'" + VisitNo +"'";
            string strsql=_OleDB.Table( _OleDB.TableName( _OleDB.TableNameBM( Tables.MZ_PATLIST,"a") + _OleDB.LeftJoin() + _OleDB.TableNameBM( Tables.PATIENTINFO,"b" ) + _OleDB.ON("a.patid","b.patid")) ,"",strWhere_1,
			                            "b." +Tables.patientinfo.PATADDRESS,
                                        "b." +Tables.patientinfo.PATBRIDATE,
                                        "b." +Tables.patientinfo.PATGROUP,
                                        "b." +Tables.patientinfo.PATJOB,
                                        "b." +Tables.patientinfo.PATNUMBER,
                                        "b." +Tables.patientinfo.PATTEL,
                                        "b." + Tables.patientinfo.MEDICARD ,
                                        "b." + Tables.patientinfo.PATID ,
                                        "a." + Tables.mz_patlist.AGE,
                                        "a." + Tables.mz_patlist.PATSEX ,
                                        "a." + Tables.mz_patlist.PATNAME ,
                                        "a." + Tables.mz_patlist.PYM ,
                                        "a." + Tables.mz_patlist.WBM ,
                                        "a." + Tables.mz_patlist.VISITNO,
                                        "a." + Tables.mz_patlist.PATLISTID ,
                                        "a." + Tables.mz_patlist.MEDITYPE ,
                                        "a." + Tables.mz_patlist.REG_DEPT_CODE ,
                                        "a." + Tables.mz_patlist.REG_DOC_CODE );
            //visitno,patname,patsex,age,pym,wbm,meditype
            return _OleDB.GetDataRow( strsql );
        }
        
        /// <summary>
        /// 获取交账日期列表
        /// </summary>
        /// <param name="OperatorID"></param>
        /// <returns></returns>
        public DataTable GetAccountHandInDate( int OperatorID )
        {
            return HIS.SYSTEM.Core.BindEntity<HIS.Model.MZ_Account>.CreateInstanceDAL( _OleDB ).GetList( "ACCOUNTCODE='" + OperatorID + "' order by ACCOUNTDATE desc" , new string[] { "ACCOUNTID" , "ACCOUNTDATE" } );
        }
        /// <summary>
        /// 获取交账单列表
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public DataTable GetAccountList( DateTime beginDate , DateTime endDate )
        {
            string strSql = "accountdate between '" + beginDate.ToString( "yyyy-MM-dd HH:mm:ss" ) + ".000000' and '" + endDate.ToString( "yyyy-MM-dd HH:mm:ss" ) + ".999999'";
            return HIS.SYSTEM.Core.BindEntity<HIS.Model.MZ_Account>.CreateInstanceDAL( _OleDB ).GetList( strSql );
        }
        

        //===================以下为2010-03-10整理后的代码=======================
        //整理原因：为统一和规范基础数据访问而整理
        #region 基础数据读取部分
        /// <summary>
        /// 获取人员列表 *
        /// </summary>
        /// <returns></returns>
        public DataTable GetEmployeeList()
        {

            return BindEntity<HIS.Model.BASE_EMPLOYEE_PROPERTY>.CreateInstanceDAL( _OleDB ).GetList( "", Tables.base_employee_property.EMPLOYEE_ID,
                                                                                                      Tables.base_employee_property.NAME,
                                                                                                      Tables.base_employee_property.PY_CODE,
                                                                                                      Tables.base_employee_property.WB_CODE );
        }
        /// <summary>
        /// 获取科室 *
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartmentList()
        {
            return BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( _OleDB ).GetList( "", "*" );
        }
        /// <summary>
        /// 获取基本分类与各个分类关系表 *
        /// </summary>
        /// <returns></returns>
        public DataTable GetBaseStatClassAndAllStatClassRelation()
        {
            string sql = @"select a.code as stat_code,a.item_name as stat_name,
                                    b.code as mzfp_code,b.item_name as mzfp_name,
                                    c.code as zyfp_code,c.item_name as zyfp_name,
                                    d.code as hs_code,d.item_name as hs_name,
                                    e.code as ba_code,e.item_name as ba_name,
                                    f.code as mzkj_code,f.item_name as mzkj_name,
                                    g.code as zykj_code,g.item_name as zykj_name,
                                    h.code as mzyb_code,h.item_name as mzyb_name,
                                    i.code as zyyb_code,i.item_name as zyyb_name
                            from base_stat_item a
                                left join base_stat_mzfp b on a.mzfp_code = b.code 
                                left join base_stat_zyfp c on a.zyfp_code = c.code 
                                left join base_stat_hs d on a.hs_code = d.code  
                                left join base_stat_ba e on a.ba_code = e.code  
                                left join base_stat_mzkj f on a.mzkj_code = f.code 
                                left join base_stat_zykj g on a.zykj_code = g.code 
                                left join base_stat_mzyb h on a.mzyb_code = h.code 
                                left join base_stat_zyyb i on a.zyyb_code = i.code";
                            
            //if ( HIS.SYSTEM.Core.EntityConfig.dal_m.Find( x => x.TableName.ToUpper().Trim() == "BASE_STAT_ITEM" ).IsBG == false )
            //{
            //    sql = sql + " where a.workid = " + HIS.SYSTEM.Core.EntityConfig.WorkID.ToString();
            //}
            return _OleDB.GetDataTable( sql );
        }
        /// <summary>
        /// 获取基本统计分类（即大项目）
        /// </summary>
        /// <returns></returns>
        public DataTable GetBaseStatItemList()
        {
            return BindEntity<Model.BASE_STAT_ITEM>.CreateInstanceDAL( _OleDB ).GetList( "","CODE","ITEM_NAME" );
        }
        /// <summary>
        /// 获取门诊发票列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetMzfpItemList()
        {
            return BindEntity<Model.BASE_STAT_MZFP>.CreateInstanceDAL( _OleDB ).GetList( "" );
        }
        /// <summary>
        /// 获取经管核算科目
        /// </summary>
        /// <returns></returns>
        public DataTable GetHsItemList()
        {
            return BindEntity<Model.BASE_STAT_HS>.CreateInstanceDAL( _OleDB ).GetList( "" );
        }
        /// <summary>
        /// 获取病人对象
        /// </summary>
        /// <returns></returns>
        public DataTable GetPatientType()
        {
            return BindEntity<object>.CreateInstanceDAL( _OleDB, Tables.BASE_PATIENTTYPE_COST ).GetList( "del_flag=0 and mz_flag=1" );
        }
        /// <summary>
        /// 得到疾病 ID,  NAME, PY_CODE
        /// </summary>
        /// <returns></returns>
        public DataTable GetDiseaseList()
        {

            return BindEntity<object>.CreateInstanceDAL( _OleDB, Tables.BASE_DISEASE ).GetList( "",
                                                                        Tables.base_disease.NAME,
                                                                        Tables.base_disease.PY_CODE,
                                                                        Tables.base_disease.WB_CODE,
                                                                        Tables.base_disease.CODING );
        }
        /// <summary>
        /// 获取医生详细列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDoctorDetailList()
        {
            string childTable = _OleDB.ChildTable( Tables.GB_SUB_ITEM, "e", Tables.gb_sub_item.CODE + _OleDB.EuqalTo() + "'006'" + _OleDB.And() + Tables.gb_sub_item.SUB_CODE + _OleDB.Between() + "'231'" + _OleDB.And() + "'235'",
                Tables.gb_sub_item.SUB_CODE, Tables.gb_sub_item.SUB_ITEM_NAME );

            string strWhere = "a." + Tables.base_role_doctor.EMPLOYEE_ID + _OleDB.EuqalTo() + "b." + Tables.base_emp_dept_role.EMPLOYEE_ID
                + _OleDB.And() + "a." + Tables.base_role_doctor.EMPLOYEE_ID + _OleDB.EuqalTo() + "c." + Tables.base_employee_property.EMPLOYEE_ID
                + _OleDB.And() + "b." + Tables.base_emp_dept_role.EMPLOYEE_ID + _OleDB.EuqalTo() + "c." + Tables.base_employee_property.EMPLOYEE_ID
                + _OleDB.And() + "b." + Tables.base_emp_dept_role.DEPT_ID + _OleDB.EuqalTo() + "d." + Tables.base_dept_property.DEPT_ID
                + _OleDB.And() + "a." + Tables.base_role_doctor.YS_TYPEID + _OleDB.EuqalTo() + "e." + Tables.gb_sub_item.SUB_CODE 
                + _OleDB.And() + "d." + Tables.base_dept_property.MZ_FLAG + _OleDB.EuqalTo() + "1"  ;

            string strsql = _OleDB.Table( _OleDB.TableName( _OleDB.TableNameBM( Tables.BASE_ROLE_DOCTOR, "a" ),
                                                            _OleDB.TableNameBM( Tables.BASE_EMP_DEPT_ROLE, "b" ),
                                                            _OleDB.TableNameBM( Tables.BASE_EMPLOYEE_PROPERTY, "c" ),
                                                            _OleDB.TableNameBM( Tables.BASE_DEPT_PROPERTY, "d" ),
                                                            childTable ), "", strWhere,
                                                            "a." + Tables.base_role_doctor.EMPLOYEE_ID,
                                                            _OleDB.FiledNameBM( "c." + Tables.base_employee_property.NAME, "emp_name" ),
                                                            "c." + Tables.base_employee_property.PY_CODE,
                                                            "c." + Tables.base_employee_property.WB_CODE,
                                                            "a." + Tables.base_role_doctor.YS_TYPEID,
                                                            _OleDB.FiledNameBM( "e." + Tables.gb_sub_item.SUB_ITEM_NAME, "ys_typename" ),
                                                            "a." + Tables.base_role_doctor.YS_CODE,
                                                            "a." + Tables.base_role_doctor.CF_RIGHT,
                                                            "a." + Tables.base_role_doctor.DM_RIGHT,
                                                            "a." + Tables.base_role_doctor.MZ_RIGHT,
                                                            "b." + Tables.base_emp_dept_role.DEPT_ID,
                                                            _OleDB.FiledNameBM( "d." + Tables.base_dept_property.NAME, "dept_name" ) );

            strsql = strsql + _OleDB.OrderBy( Tables.base_employee_property.EMPLOYEE_ID );
            return _OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 获取名族列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetFolkList()
        {
            return BindEntity<object>.CreateInstanceDAL( _OleDB, Tables.GB_SUB_ITEM ).GetList( Tables.gb_sub_item.CODE + _OleDB.EuqalTo() + "'005'", Tables.gb_sub_item.SUB_CODE, Tables.gb_sub_item.SUB_ITEM_NAME );
        }
        /// <summary>
        /// 获取医生类型定义表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDoctorTypeList()
        {
            return BindEntity<object>.CreateInstanceDAL( _OleDB, Tables.GB_SUB_ITEM ).GetList( Tables.gb_sub_item.CODE + _OleDB.EuqalTo() + "'006'"
                                                                                                + _OleDB.And() + Tables.gb_sub_item.SUB_CODE + _OleDB.Between() + "'231'" + _OleDB.And() + "'235'",
                    _OleDB.FiledNameBM( Tables.gb_sub_item.SUB_CODE, "type_id" ),
                    _OleDB.FiledNameBM( Tables.gb_sub_item.SUB_ITEM_NAME, "type_name" ) );
        }
        /// <summary>
        /// 获取挂号类型(TYPE_CODE,TYPE_NAME,PY_CODE,WB_CODE,PRICE)
        /// </summary>
        /// <returns></returns>
        public DataTable GetRegisterTypeList()
        {
            string _gs_1_2 = _OleDB.Sum( "C." + Tables.base_service_items.PRICE, "" );
            string strWhere_3 = "A." + Tables.mz_reg_type.TYPE_CODE + _OleDB.EuqalTo() + "B." + Tables.mz_reg_item_fee.TYPE_CODE + _OleDB.And() +
                             "B." + Tables.mz_reg_item_fee.ITEM_ID + _OleDB.EuqalTo() + "C." + Tables.base_service_items.ITEM_ID;
            string tb = _OleDB.TableName( _OleDB.TableNameBM( Tables.MZ_REG_TYPE, "A" ), _OleDB.TableNameBM( Tables.MZ_REG_ITEM_FEE, "B" ), _OleDB.TableNameBM( Tables.BASE_SERVICE_ITEMS, "C" ) );
            string strsql = _OleDB.Table( tb, "", strWhere_3,
                       "A." + Tables.mz_reg_type.TYPE_CODE,
                       "A." + Tables.mz_reg_type.TYPE_NAME,
                       "A." + Tables.mz_reg_type.PY_CODE,
                       "A." + Tables.mz_reg_type.WB_CODE,
                       "A." + Tables.mz_reg_type.VALID_FLAG,
                       _OleDB.FiledNameBM( _gs_1_2, "PRICE" ) );
            strsql += _OleDB.GroupBy( "A." + Tables.mz_reg_type.TYPE_CODE, "A." + Tables.mz_reg_type.TYPE_NAME, "A." + Tables.mz_reg_type.PY_CODE, "A." + Tables.mz_reg_type.WB_CODE, "A." + Tables.mz_reg_type.VALID_FLAG );
            return _OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 获取挂号类型与收费项目对应关系表
        /// </summary>
        /// <returns></returns>
        public DataTable GetRegisterTypeAndServiceItemRelation()
        {
            string strWhere_3 = "A." + Tables.mz_reg_type.TYPE_CODE + _OleDB.EuqalTo() + "B." + Tables.mz_reg_item_fee.TYPE_CODE + _OleDB.And() +
                             "B." + Tables.mz_reg_item_fee.ITEM_ID + _OleDB.EuqalTo() + "C." + Tables.base_service_items.ITEM_ID + _OleDB.And() + Tables.mz_reg_item_fee.APPEND + _OleDB.EuqalTo() + "0";

            string tb = _OleDB.TableName( _OleDB.TableNameBM( Tables.MZ_REG_TYPE, "A" ), _OleDB.TableNameBM( Tables.MZ_REG_ITEM_FEE, "B" ), _OleDB.TableNameBM( Tables.BASE_SERVICE_ITEMS, "C" ) );
            string strsql = _OleDB.Table( tb, "", strWhere_3,
                       "A." + Tables.mz_reg_type.TYPE_CODE,
                        "C." + Tables.base_service_items.ITEM_ID,
                        "C." + Tables.base_service_items.ITEM_NAME,
                        "C." + Tables.base_service_items.PRICE
                        );
            return _OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 获取划价模板列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTemplateList()
        {
            return BindEntity<Model.BASE_TEMPLATE_ITEM>.CreateInstanceDAL( _OleDB ).GetList( "VALID_FLAG=1" );
        }
        /// <summary>
        /// 获取划价模板明细列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTemplateDetailList()
        {
            return BindEntity<Model.BASE_TEMPLATE_DETAIL>.CreateInstanceDAL( _OleDB ).GetList( "" );
        }
        /// <summary>
        /// 获取工作单位列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetWorkUnitList()
        {
            return BindEntity<Model.BASE_WORK_UNIT>.CreateInstanceDAL( _OleDB ).GetList( "" );
        }
        /// <summary>
        /// 得到基本医疗服务项目
        /// </summary>
        /// <returns></returns>
        public DataTable GetBaseServiceItems()
        {
            
            string tb = _OleDB.TableNameBM( Tables.BASE_SERVICE_ITEMS, "a" ) + _OleDB.LeftJoin() + _OleDB.TableNameBM( Tables.BASE_STAT_ITEM, "b" ) +
                      _OleDB.ON( "a." + Tables.base_service_items.STATITEM_CODE, "b." + Tables.base_stat_item.CODE );
            string strsql = _OleDB.Table( tb, "", "",
                                      Tables.base_service_items.ITEM_ID,
                                      Tables.base_service_items.ITEM_CODE,
                                      _OleDB.FiledNameBM( "a." + Tables.base_service_items.ITEM_NAME, "ITEM_NAME" ),
                                      Tables.base_service_items.ITEM_UNIT,
                                      Tables.base_service_items.PRICE,
                                      _OleDB.FiledNameBM( "a." + Tables.base_service_items.PY_CODE, "PY_CODE" ),
                                      Tables.base_service_items.STATITEM_CODE,
                                      Tables.base_service_items.STD_CODE,
                                      Tables.base_service_items.VALID_FLAG,
                                      _OleDB.FiledNameBM( "a." + Tables.base_service_items.WB_CODE, "WB_CODE" ),
                                     _OleDB.FiledNameBM( "b." + Tables.base_stat_item.ITEM_NAME, "statitem_name" ) );
            strsql += _OleDB.OrderBy() + Tables.base_service_items.ITEM_ID;
            return _OleDB.GetDataTable( strsql );
        }
        #endregion
        //===================以上为2010-03-10整理后的代码=======================

        //收费员工作量统计
        public DataTable GetChargeReport(DateTime? Btime, DateTime? Etime, HIS.MZ_BLL.StatClassType StatType)
        {
            string field = "";
            if (StatType == HIS.MZ_BLL.StatClassType.门诊发票分类)
                field = "c.mzfp_code";
            else if (StatType == HIS.MZ_BLL.StatClassType.经管核算分类)
                field = "c.hs_code";
            else if (StatType == HIS.MZ_BLL.StatClassType.门诊会计分类)
                field = "c.mzkj_code";
            else if (StatType == HIS.MZ_BLL.StatClassType.统计大项目类)
                field = "c.code";
            string strsql = @"select  a.chargecode as ID," + field + @" as code,count(a.ticketnum) as total_fee from  
                                    (select ticketnum,costmasterid,chargecode,costdate,record_flag,accountid from mz_costmaster) a, 
                                    (select costid,itemtype as bigitemcode,total_fee from mz_costorder) b ,  base_stat_item c   
                                    where a.costmasterid=b.costid and b.bigitemcode=c.code  and a.costdate
                                     between '" + Btime + @"' and '" + Etime + @"' and a.record_flag in (0,1,2)   
                               group by a.chargecode," + field + "";           
            return _OleDB.GetDataTable(strsql);
        }


        public DataTable GetItemFee(int type,string strWhere)
        {
            string strsql = @"";

            if (type == 0)
            {
                strsql = @"select d.name as presdeptname,c.name presdocname,h.patname, b.itemname , e.name as execdeptname , sell_price ,sum(amount) amount , sum(tolal_fee) fee  ,count(1) num 
                                from mz_presmaster a
								left join mz_presorder b on a.PRESMASTERID=b.PRESMASTERID
								left join BASE_EMPLOYEE_PROPERTY c on a.presdoccode=char(c.EMPLOYEE_ID)
								left join BASE_DEPT_PROPERTY d on a.presdeptcode=char(d.dept_id)
								left join BASE_DEPT_PROPERTY e on a.execdeptcode=char(e.dept_id) 
								left join patientinfo h on a.patid=h.patid
								where a.presmasterid = b.presmasterid and a.record_flag in (0,1) and charge_flag =1
                                and b.bigitemcode not in ('00','01','02','03') and "+ strWhere +@"
                                group by  d.name ,c.name,h.patname,e.name ,b.itemname,sell_price";
            }
            else if (type == 1)
            {
                strsql = @"select d.name as presdeptname ,c.name as presdocname,h.patname,a.itemname, e.name as execdeptname ,a.sell_price, sum(amount) amount,sum(tolal_fee) fee, count(1) num
	   							from zy_presorder a
								left join BASE_EMPLOYEE_PROPERTY c on a.presdoccode=char(c.EMPLOYEE_ID)
								left join BASE_DEPT_PROPERTY d on a.presdeptcode=char(d.dept_id)
								left join BASE_DEPT_PROPERTY e on a.execdeptcode=char(e.dept_id) 
								left join patientinfo h on a.patid=h.patid
								where a.charge_flag=1 and a.itemtype not in('00','01','02','03') and "+strWhere+@"
								group by d.name ,c.name,h.patname,a.itemname, e.name ,a.sell_price";
            }

            DataTable dt= _OleDB.GetDataTable(strsql);
            DataRow dr = dt.NewRow();
            dr["presdeptname"] = "合计";
            dr["amount"] = dt.Compute("sum(amount)", "");
            dr["fee"] = dt.Compute("sum(fee)", "");
            dr["num"] = dt.Compute("sum(num)", "");
            dt.Rows.Add(dr);
            return dt;

        }
      
        public DataTable GetSeviceItems()
        {
            return BindEntity<HIS.Model.BASE_SERVICE_ITEMS>.CreateInstanceDAL(_OleDB).GetList("");
        }
    }
}
 