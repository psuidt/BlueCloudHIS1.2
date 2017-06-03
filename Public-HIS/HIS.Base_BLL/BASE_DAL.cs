using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
namespace HIS.DAL
{
    public class BASE_DAL
    {
        public HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase OleDB = null;

        public BASE_DAL()
        {
        }
        /// <summary>
        /// 获取指定SQL的表数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public  DataTable GetDataTable( string strSql )
        {
            return OleDB.GetDataTable( strSql );
            
        }
        /// <summary>
        /// 得到基本医疗服务项目
        /// </summary>
        /// <returns></returns>
        public  System.Data.DataTable get_Base_Service_Items()
        {
            //return GetDataTable( "select a.*,b.item_name as statitem_name from base_service_items a left join base_stat_item b on a.statitem_code =b.code order by item_id" );
            string tb = OleDB.TableNameBM( Tables.BASE_SERVICE_ITEMS, "a" ) + OleDB.LeftJoin() + OleDB.TableNameBM( Tables.BASE_STAT_ITEM, "b" ) +
                      OleDB.ON( "a." + Tables.base_service_items.STATITEM_CODE, "b." + Tables.base_stat_item.CODE );
            string strsql = OleDB.Table( tb, "", "",
                                      Tables.base_service_items.ITEM_ID,
                                      Tables.base_service_items.ITEM_CODE,
                                      OleDB.FiledNameBM( "a." + Tables.base_service_items.ITEM_NAME,"ITEM_NAME"),
                                      Tables.base_service_items.ITEM_UNIT,
                                      Tables.base_service_items.PRICE,
                                      OleDB.FiledNameBM( "a." + Tables.base_service_items.PY_CODE,"PY_CODE"),
                                      Tables.base_service_items.STATITEM_CODE,
                                      Tables.base_service_items.STD_CODE,
                                      Tables.base_service_items.VALID_FLAG,
                                      OleDB.FiledNameBM( "a." + Tables.base_service_items.WB_CODE,"WB_CODE"),
                                     OleDB.FiledNameBM( "b." + Tables.base_stat_item.ITEM_NAME, "statitem_name" ) );
            strsql += OleDB.OrderBy() + Tables.base_service_items.ITEM_ID;
            return GetDataTable( strsql );
        }
        /// <summary>
        /// 读取人员隶属组
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public DataTable get_Employee_GetGroups( int employeeId )
        {
            string strWhere_1 = Tables.base_user.EMPLOYEE_ID + OleDB.EuqalTo( ) + employeeId.ToString( );
            string childtable_1 = OleDB.ChildTable( Tables.BASE_USER , "" , strWhere_1 , Tables.base_user.USER_ID );
            string strWhere_2 = Tables.base_group_user.USER_ID + OleDB.In( ) + childtable_1;
            string childtable_2 = OleDB.ChildTable( Tables.BASE_GROUP_USER , "" , strWhere_2 , Tables.base_group_user.GROUP_ID );
            string strWhere_3 = Tables.base_group.GROUP_ID + OleDB.In( ) + childtable_2;
            string strsql = OleDB.Table( Tables.BASE_GROUP , "" , strWhere_3 , Tables.base_group.GROUP_ID , Tables.base_group.NAME );

            //string sql = "select group_id,name from base_group where group_id in ( select group_id from base_group_user where user_id in (select user_id from base_user where employee_id=" + employeeId + "))";
            return GetDataTable( strsql );
        }
        /// <summary>
        /// 获取医院药品列表清单
        /// </summary>
        /// <returns></returns>
        public DataTable Get_HIS_DrugList()
        {
            string childtable_1=OleDB.ChildTable( OleDB.TableNameBM( Views.VI_DRUG_YK,""),"","",
                                                                            Views.vi_drug_yk.MAKERDICID ,
                                                                            Views.vi_drug_yk.NAME ,
                                                                            "chemname",
                                                                            Views .vi_drug_yk.TYPEDICID,
                                                                             Views.vi_drug_yk.SPEC,
                                                                            Views.vi_drug_yk.UNITNAME ,
                                                                             Views.vi_drug_yk.DOSEDICID ,
			                                                                 Views.vi_drug_yk.PACKUNIT,
                                                                             Views.vi_drug_yk.PACKNUM,
                                                                             Views.vi_drug_yk.RETAILPRICE ,
			                                                                Views.vi_drug_yk.PRODUCTNAME);

            string childtable_2 = OleDB.ChildTable( OleDB.TableNameBM( Views.VI_DRUG_YF ,"") , "" , "" ,
                                                                            Views.vi_drug_yf.MAKERDICID ,
                                                                            Views.vi_drug_yf.NAME ,
                                                                            "chemname",
                                                                            Views.vi_drug_yf.TYPEDICID ,
                                                                             Views.vi_drug_yf.SPEC ,
                                                                            Views.vi_drug_yf.UNITNAME ,
                                                                             Views.vi_drug_yf.DOSEDICID ,
                                                                             Views.vi_drug_yf.PACKUNIT ,
                                                                             Views.vi_drug_yf.PACKNUM ,
                                                                             Views.vi_drug_yf.RETAILPRICE ,
                                                                            Views.vi_drug_yf.PRODUCTNAME );
            string subTable = "(" + childtable_1+ OleDB.UnionAll() + childtable_2 + ")";

            string cast = OleDB.DBConvert( Tables.ncms_match_catalog_temp.HOSPITAL_CODE, "INTEGER" );
            string strWhere = OleDB.ChildTable( Tables.NCMS_MATCH_CATALOG_TEMP, "", Tables.ncms_match_catalog_temp.TYPE + OleDB.EuqalTo() + "'1'", OleDB.FiledNameBM( cast, "his_code" ) );
            string strWhere_1 = Views.vi_drug_yk.MAKERDICID + " NOT IN " + strWhere;

            string strsql = OleDB.Table( subTable, "A", strWhere_1,
            OleDB.FiledNameBM( OleDB.Distinct( Views.vi_drug_yk.MAKERDICID ) , "code" ) ,
            Views.vi_drug_yk.NAME ,"chemname",
            OleDB.FiledNameBM( Views.vi_drug_yk.TYPEDICID , "type" ),
            Views.vi_drug_yk.SPEC ,
            OleDB.FiledNameBM( Views.vi_drug_yk.UNITNAME , "unit" ) ,
            OleDB.FiledNameBM( Views.vi_drug_yk.RETAILPRICE , "price" ) ,
            OleDB.FiledNameBM( Views.vi_drug_yk.DOSEDICID , "model" ),
            OleDB.FiledNameBM( Views.vi_drug_yk.PRODUCTNAME , "factory" ) ) ;

            return OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 获取医院项目列表
        /// </summary>
        /// <returns></returns>
        public DataTable Get_HIS_ItemList()
        {
            string cast = OleDB.DBConvert( Tables.ncms_match_catalog_temp.HOSPITAL_CODE, "INTEGER" );
            string strWhere = OleDB.ChildTable( Tables.NCMS_MATCH_CATALOG_TEMP, "", Tables.ncms_match_catalog_temp.TYPE + OleDB.EuqalTo() + "'2'", OleDB.FiledNameBM(cast,"his_code") );
            string strWhere_1 = Tables.base_service_items.ITEM_ID + " NOT IN " + strWhere;

            return HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_SERVICE_ITEMS>.CreateInstanceDAL( OleDB ).GetList( strWhere_1, Tables.base_service_items.ITEM_ID,
                Tables.base_service_items.STD_CODE,
                Tables.base_service_items.ITEM_NAME,
                Tables.base_service_items.ITEM_UNIT,
                Tables.base_service_items.PRICE,
                Tables.base_service_items.PY_CODE,
                Tables.base_service_items.WB_CODE );
        }
        /// <summary>
        /// 读取匹配关系（下载的）
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Ncms_Drug_MatchList()
        {
            string table_a = OleDB.ChildTable( HIS.BLL.Tables.NCMS_MATCH_CATALOG, "a", HIS.BLL.Tables.ncms_match_catalog.TYPE + OleDB.EuqalTo() + "'1'",
                        HIS.BLL.Tables.ncms_match_catalog.NCMS_CODE,
                        HIS.BLL.Tables.ncms_match_catalog.HOSPITAL_CODE,
                        HIS.BLL.Tables.ncms_match_catalog.STATUS,
                        HIS.BLL.Tables.ncms_match_catalog.TYPE,
                        HIS.BLL.Tables.ncms_match_catalog.UPLOAD_TIME,
                        HIS.BLL.Tables.ncms_match_catalog.UPLOADER,
                        HIS.BLL.Tables.ncms_match_catalog.APPROVE_STATUS );


            string table_b = OleDB.ChildTable( HIS.BLL.Tables.NCMS_DRUG_CATALOG, "b", "",
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_CODE,
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_ALIAS,
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_NAME,
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_FORM);

            string cast_2 = OleDB.DBConvert( HIS.BLL.Views.vi_item_drug.ITEMID, "char(10)" );
            string table_c = OleDB.ChildTable( HIS.BLL.Views.VI_ITEM_DRUG, "c", "",
                        OleDB.FiledNameBM( cast_2, HIS.BLL.Views.vi_item_drug.ITEMID ),
                         HIS.BLL.Views.vi_item_drug.ITEMNAME,
                         HIS.BLL.Views.vi_item_drug.STANDARD,
                         OleDB.FiledNameBM( HIS.BLL.Views.vi_item_drug.PACKUNIT,"ITEM_UNIT"),
                         OleDB.FiledNameBM( HIS.BLL.Views.vi_item_drug.SELL_PRICE,"PRICE" ),
                         HIS.BLL.Views.vi_item_drug.ADDRESS );

            string strWhere = "a.ncms_code" + OleDB.EuqalTo() + "b.drug_code" + OleDB.And() + "a.hospital_code" + OleDB.EuqalTo() + "c.itemid";
            string table = OleDB.Table( OleDB.TableName( table_a, table_b, table_c ), "", strWhere, "*" );

            return OleDB.GetDataTable( table );
        }
        /// <summary>
        /// 读取项目匹配关系（下载的）
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Ncms_Therapy_MatchList()
        {
            string table_a = OleDB.ChildTable( HIS.BLL.Tables.NCMS_MATCH_CATALOG, "a", HIS.BLL.Tables.ncms_match_catalog.TYPE + OleDB.EuqalTo() + "'2'",
                        HIS.BLL.Tables.ncms_match_catalog.NCMS_CODE,
                        HIS.BLL.Tables.ncms_match_catalog.HOSPITAL_CODE,
                        HIS.BLL.Tables.ncms_match_catalog.STATUS,
                        HIS.BLL.Tables.ncms_match_catalog.TYPE,
                        HIS.BLL.Tables.ncms_match_catalog.UPLOAD_TIME,
                        HIS.BLL.Tables.ncms_match_catalog.UPLOADER,
                        HIS.BLL.Tables.ncms_match_catalog.APPROVE_STATUS );


            string table_b = OleDB.ChildTable( HIS.BLL.Tables.NCMS_THERAPY_CATALOG, "b", "",
                HIS.BLL.Tables.ncms_therapy_catalog.ITEM_CODE,
                HIS.BLL.Tables.ncms_therapy_catalog.ITEM_NAME,
                HIS.BLL.Tables.ncms_therapy_catalog.UNIT
                );

            string cast_2 = OleDB.DBConvert( HIS.BLL.Tables.base_service_items.ITEM_ID, "char(10)" );
            string table_c = OleDB.ChildTable( HIS.BLL.Tables.BASE_SERVICE_ITEMS, "c", "",
                        OleDB.FiledNameBM( cast_2, "ITEMID" ),
                        OleDB.FiledNameBM( HIS.BLL.Tables.base_service_items.ITEM_NAME, "ITEMNAME" ),
                         HIS.BLL.Tables.base_service_items.ITEM_UNIT,
                         HIS.BLL.Tables.base_service_items.PRICE
                          );

            string strWhere = "a.ncms_code" + OleDB.EuqalTo() + "b.item_code" + OleDB.And() + "a.hospital_code" + OleDB.EuqalTo() + "c.ITEMID";
            string table = OleDB.Table( OleDB.TableName( table_a, table_b, table_c ), "", strWhere, "*" );

            return OleDB.GetDataTable( table );
        }
        /// <summary>
        /// 获取本地新增的匹配关系（未上传）
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Ncms_Drug_Match_TempList()
        {
            string table_a = OleDB.ChildTable( HIS.BLL.Tables.NCMS_MATCH_CATALOG_TEMP, "a", HIS.BLL.Tables.ncms_match_catalog_temp.TYPE + OleDB.EuqalTo() + "'1'",
                        HIS.BLL.Tables.ncms_match_catalog_temp.NCMS_CODE,
                        HIS.BLL.Tables.ncms_match_catalog_temp.HOSPITAL_CODE,
                        HIS.BLL.Tables.ncms_match_catalog_temp.STATUS,
                        HIS.BLL.Tables.ncms_match_catalog_temp.COMP_RATE,
                        HIS.BLL.Tables.ncms_match_catalog_temp.TYPE );


            string table_b = OleDB.ChildTable( HIS.BLL.Tables.NCMS_DRUG_CATALOG, "b", "",
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_CODE,
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_ALIAS,
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_NAME,
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_FORM );

            
            string cast_2 = OleDB.DBConvert( HIS.BLL.Views.vi_drug_dic.MAKERDICID, "char(10)" );

            string table_c = OleDB.ChildTable( HIS.BLL.Views.VI_DRUG_DIC, "c", "",
                        OleDB.Distinct( OleDB.FiledNameBM( cast_2, "ITEMID" ) ),
                        OleDB.FiledNameBM( HIS.BLL.Views.vi_drug_dic.NAME,  "ITEMNAME"),
                        OleDB.FiledNameBM( HIS.BLL.Views.vi_drug_dic.SPEC,  "STANDARD"),
                        OleDB.FiledNameBM( HIS.BLL.Views.vi_drug_dic.PACKUNIT, "ITEM_UNIT" ),
                        OleDB.FiledNameBM( HIS.BLL.Views.vi_drug_dic.RETAILPRICE, "PRICE" ),
                        OleDB.FiledNameBM( HIS.BLL.Views.vi_drug_dic.PRODUCTNAME, "ADDRESS" ));

            string strWhere = "a.ncms_code" + OleDB.EuqalTo() + "b.drug_code" + OleDB.And() + "a.hospital_code" + OleDB.EuqalTo() + "c.itemid";
            string table = OleDB.Table( OleDB.TableName( table_a, table_b, table_c ), "", strWhere, "a.*","b.*","c.*" );

            return OleDB.GetDataTable( table );
        }
        /// <summary>
        /// 获取本地新增的匹配关系（未上传）
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Ncms_Therapy_Match_TempList()
        {
            //ncms_match_catalog_temp.TYPE 是新农合项目类型定义。（1-药品 2-项目）
            string table_a = OleDB.ChildTable( HIS.BLL.Tables.NCMS_MATCH_CATALOG_TEMP, "a", HIS.BLL.Tables.ncms_match_catalog_temp.TYPE + OleDB.EuqalTo() + "'2'",
                        HIS.BLL.Tables.ncms_match_catalog_temp.NCMS_CODE,
                        HIS.BLL.Tables.ncms_match_catalog_temp.HOSPITAL_CODE,
                        HIS.BLL.Tables.ncms_match_catalog_temp.STATUS,
                        HIS.BLL.Tables.ncms_match_catalog_temp.COMP_RATE,
                        HIS.BLL.Tables.ncms_match_catalog_temp.TYPE );


            string table_b = OleDB.ChildTable( HIS.BLL.Tables.NCMS_THERAPY_CATALOG, "b", "",
                HIS.BLL.Tables.ncms_therapy_catalog.ITEM_CODE,
                HIS.BLL.Tables.ncms_therapy_catalog.ITEM_NAME,
                HIS.BLL.Tables.ncms_therapy_catalog.UNIT
                );

            string cast_2 = OleDB.DBConvert( HIS.BLL.Tables.base_service_items.ITEM_ID, "char(10)" );
            string table_c = OleDB.ChildTable( HIS.BLL.Tables.BASE_SERVICE_ITEMS, "c", "",
                        OleDB.FiledNameBM( cast_2, "ITEMID" ),
                        OleDB.FiledNameBM( HIS.BLL.Tables.base_service_items.ITEM_NAME, "ITEMNAME" ),
                         HIS.BLL.Tables.base_service_items.ITEM_UNIT,
                         HIS.BLL.Tables.base_service_items.PRICE
                          );

            string strWhere = "a.ncms_code" + OleDB.EuqalTo() + "b.item_code" + OleDB.And() + "a.hospital_code" + OleDB.EuqalTo() + "c.ITEMID";
            string table = OleDB.Table( OleDB.TableName( table_a, table_b, table_c ), "", strWhere, "a.*","b.*","c.*" );

            return OleDB.GetDataTable( table );
        }
        /// <summary>
        /// 获取药品词典
        /// </summary>
        /// <returns></returns>
        public DataTable Get_HIS_DrugDicition()
        {
            return OleDB.GetDataTable( OleDB.Table( BLL.Views.VI_DRUG_DIC, "", "", "*" ) );
        }
        /// <summary>
        /// 获取医保类型
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Insur_Type()
        {
            return HIS.SYSTEM.Core.BindEntity<Model.YP_MedicareDic>.CreateInstanceDAL( OleDB ).GetList( "" , Tables.yp_medicaredic.MEDICARENAME );

        }
        /// <summary>
        /// 获取本院医疗服务项目(包括组合项目)
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Hospital_Service_Items()
        {
            string strSql = @"select ITEM_ID,STD_CODE,a.ITEM_NAME,a.PY_CODE,a.WB_CODE,ITEM_UNIT,PRICE,NCMS_COMP_RATE,INSUR_TYPE,VALID_FLAG,STATITEM_CODE,COMPLEX_ID,b.Item_name Statitem_Name 
                                     from  {VI_BASE_HOSPITAL_ITEMS as a}
                                     left join {base_stat_item as b} on a.statitem_code=b.code";
            return OleDB.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取组合项目明细
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Complex_Item_Detail()
        {
            //return BindEntity<Model.BASE_COMPLEX_DETAIL>.CreateInstanceDAL( OleDB ).GetList( "" );
            //select b.item_id,b.item_name,b.price,a.num from base_complex_detail a,base_service_items b where a.service_item_id= b.item_id
            string strWhere_1 = "a.service_item_id" + OleDB.EuqalTo( ) + "b.item_id" + OleDB.And() + "b.valid_flag=1";
            string table_1 = OleDB.TableNameBM( Tables.BASE_COMPLEX_DETAIL,"a");
            string table_2 = OleDB.TableNameBM( Tables.BASE_SERVICE_ITEMS,"b");

            string strsql = OleDB.Table( table_1 +","+ table_2 , "" , strWhere_1 , "a.complex_id" ,
                                                                                "b.item_id",
                                                                                "b.item_name" ,
                                                                                "b.price" ,
                                                                                "a.num" );
            return OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 获取医院的服务项目的执行科室
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Hsitem_ExecDept()
        {
            //select * from vi_base_hospital_items a,base_item_dept b where a.item_id=b.item_id and a.complex_id=b.complex_id 
            string strWhere = "a.item_id=b.item_id " + OleDB.And() + " a.complex_id=b.complex_id" + OleDB.And() + "b.dept_id=c.dept_id";
            string table_1 = OleDB.TableNameBM( Views.VI_BASE_HOSPITAL_ITEMS , "a" );
            string table_2 = OleDB.TableNameBM( Tables.BASE_ITEM_DEPT , "b" );
            string table_3 = OleDB.TableNameBM( Tables.BASE_DEPT_PROPERTY,"c");
            string strsql = OleDB.Table( table_1 + "," + table_2 + "," + table_3 , "" , strWhere ,
                                            "a." + Views.vi_base_hospital_items.ITEM_ID,
                                            "a." + Views.vi_base_hospital_items.COMPLEX_ID,
                                            "b."+Tables.base_dept_property.DEPT_ID ,
                                            OleDB.FiledNameBM( Tables.base_dept_property.NAME , "DEPT_NAME"),
                                            "b." + Tables.base_item_dept.DEFAULT_FLAG );

            return OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 获取医院还未使用的基本服务项目
        /// </summary>
        /// <returns></returns>
        public DataTable Get_BaseServiceItemWhereNotInUseByHospital()
        {
            string tb = OleDB.TableNameBM( Tables.BASE_SERVICE_ITEMS , "a" ) + OleDB.LeftJoin( ) + OleDB.TableNameBM( Tables.BASE_STAT_ITEM , "b" ) +
          OleDB.ON( "a." + Tables.base_service_items.STATITEM_CODE , "b." + Tables.base_stat_item.CODE );

            string tb2 = OleDB.Table( Tables.BASE_HOSPITAL_ITEMS , "" , Tables.base_hospital_items.COMPLEX_ID + OleDB.NotEqualTo( ) + "0" ,Tables.base_hospital_items.ITEM_ID);

            string strWhere = Tables.base_service_items.ITEM_ID + OleDB.Not() + " " + OleDB.In() + "(" + tb2  + ")";

            string strsql = OleDB.Table( tb , "" , "" ,
                                      Tables.base_service_items.ITEM_ID ,
                                      Tables.base_service_items.ITEM_CODE ,
                                      OleDB.FiledNameBM( "a." + Tables.base_service_items.ITEM_NAME , "ITEM_NAME" ) ,
                                      Tables.base_service_items.ITEM_UNIT ,
                                      Tables.base_service_items.PRICE ,
                                      OleDB.FiledNameBM( "a." + Tables.base_service_items.PY_CODE , "PY_CODE" ) ,
                                      Tables.base_service_items.STATITEM_CODE ,
                                      Tables.base_service_items.STD_CODE ,
                                      Tables.base_service_items.VALID_FLAG ,
                                      OleDB.FiledNameBM( "a." + Tables.base_service_items.WB_CODE , "WB_CODE" ) ,
                                     OleDB.FiledNameBM( "b." + Tables.base_stat_item.ITEM_NAME , "statitem_name" ) );
            strsql += OleDB.OrderBy( ) + Tables.base_service_items.ITEM_ID;
            return GetDataTable( strsql );
        }

        public DataTable Get_MZJG_Parameters()
        {
            return BindEntity<Model.MZ_CONFIG>.CreateInstanceDAL( OleDB ).GetList("");
        }

        public DataTable Get_ZYJG_parameters()
        {
            return BindEntity<object>.CreateInstanceDAL( OleDB, Tables.ZY_CONFIG ).GetList( "" );
        }

        public DataTable Get_MZYS_Parameters()
        {
            return BindEntity<Model.MZ_DOC_CONFIG>.CreateInstanceDAL( OleDB ).GetList( "" );
        }

        public DataTable Get_ZYYS_Parameters()
        {
            //return BindEntity<Model.ZY_Doc_Config>.CreateInstanceDAL( OleDB ).GetList( "" );
            return BindEntity<object>.CreateInstanceDAL(OleDB, "zy_doc_config").GetList("");
        }

        public DataTable Get_ZYHS_Parameters()
        {
            return BindEntity<object>.CreateInstanceDAL( OleDB, "ZY_NURSE_CONFIG" ).GetList( "" );
            //return OleDB.GetDataTable("select * from ZY_NURSE_CONFIG");
        }

        public DataTable Get_YPGL_Parameters()
        {
            return BindEntity<Model.YP_CONFIG>.CreateInstanceDAL( OleDB ).GetList( "" );
        }

        /// <summary>
        /// 得到基本医疗服务项目
        /// </summary>
        /// <returns></returns>
        /// <remarks>来自于收费模块的副本代码</remarks>
        public DataTable GetBaseServiceItems()
        {

            string tb = OleDB.TableNameBM( Tables.BASE_SERVICE_ITEMS, "a" ) + OleDB.LeftJoin() + OleDB.TableNameBM( Tables.BASE_STAT_ITEM, "b" ) +
                      OleDB.ON( "a." + Tables.base_service_items.STATITEM_CODE, "b." + Tables.base_stat_item.CODE );
            string strsql = OleDB.Table( tb, "", "",
                                      Tables.base_service_items.ITEM_ID,
                                      Tables.base_service_items.ITEM_CODE,
                                      OleDB.FiledNameBM( "a." + Tables.base_service_items.ITEM_NAME, "ITEM_NAME" ),
                                      Tables.base_service_items.ITEM_UNIT,
                                      Tables.base_service_items.PRICE,
                                      OleDB.FiledNameBM( "a." + Tables.base_service_items.PY_CODE, "PY_CODE" ),
                                      Tables.base_service_items.STATITEM_CODE,
                                      Tables.base_service_items.STD_CODE,
                                      Tables.base_service_items.VALID_FLAG,
                                      OleDB.FiledNameBM( "a." + Tables.base_service_items.WB_CODE, "WB_CODE" ),
                                     OleDB.FiledNameBM( "b." + Tables.base_stat_item.ITEM_NAME, "statitem_name" ) );
            strsql += OleDB.OrderBy() + Tables.base_service_items.ITEM_ID;
            return OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 获取挂号类型与收费项目对应关系表
        /// </summary>
        /// <returns></returns>
        public DataTable GetRegisterTypeAndServiceItemRelation()
        {
            string strWhere_3 = "A." + Tables.mz_reg_type.TYPE_CODE + OleDB.EuqalTo() + "B." + Tables.mz_reg_item_fee.TYPE_CODE + OleDB.And() +
                             "B." + Tables.mz_reg_item_fee.ITEM_ID + OleDB.EuqalTo() + "C." + Tables.base_service_items.ITEM_ID + OleDB.And() + Tables.mz_reg_item_fee.APPEND + OleDB.EuqalTo() + "0";

            string tb = OleDB.TableName( OleDB.TableNameBM( Tables.MZ_REG_TYPE, "A" ), OleDB.TableNameBM( Tables.MZ_REG_ITEM_FEE, "B" ), OleDB.TableNameBM( Tables.BASE_SERVICE_ITEMS, "C" ) );
            string strsql = OleDB.Table( tb, "", strWhere_3,
                       "A." + Tables.mz_reg_type.TYPE_CODE,
                        "C." + Tables.base_service_items.ITEM_ID,
                        "C." + Tables.base_service_items.ITEM_NAME,
                        "C." + Tables.base_service_items.PRICE
                        );
            return OleDB.GetDataTable( strsql );
        }
        /// <summary>
        /// 获取挂号类型(TYPE_CODE,TYPE_NAME,PY_CODE,WB_CODE,PRICE)
        /// </summary>
        /// <returns></returns>
        public DataTable GetRegisterTypeList()
        {
            string _gs_1_2 = OleDB.Sum( "C." + Tables.base_service_items.PRICE, "" );
            string strWhere_3 = "A." + Tables.mz_reg_type.TYPE_CODE + OleDB.EuqalTo() + "B." + Tables.mz_reg_item_fee.TYPE_CODE + OleDB.And() +
                             "B." + Tables.mz_reg_item_fee.ITEM_ID + OleDB.EuqalTo() + "C." + Tables.base_service_items.ITEM_ID;
            string tb = OleDB.TableName( OleDB.TableNameBM( Tables.MZ_REG_TYPE, "A" ), OleDB.TableNameBM( Tables.MZ_REG_ITEM_FEE, "B" ), OleDB.TableNameBM( Tables.BASE_SERVICE_ITEMS, "C" ) );
            string strsql = OleDB.Table( tb, "", strWhere_3,
                       "A." + Tables.mz_reg_type.TYPE_CODE,
                       "A." + Tables.mz_reg_type.TYPE_NAME,
                       "A." + Tables.mz_reg_type.PY_CODE,
                       "A." + Tables.mz_reg_type.WB_CODE,
                       "A." + Tables.mz_reg_type.VALID_FLAG,
                       OleDB.FiledNameBM( _gs_1_2, "PRICE" ) );
            strsql += OleDB.GroupBy( "A." + Tables.mz_reg_type.TYPE_CODE, "A." + Tables.mz_reg_type.TYPE_NAME, "A." + Tables.mz_reg_type.PY_CODE, "A." + Tables.mz_reg_type.WB_CODE, "A." + Tables.mz_reg_type.VALID_FLAG );
            return OleDB.GetDataTable( strsql );
        }
    }
}
