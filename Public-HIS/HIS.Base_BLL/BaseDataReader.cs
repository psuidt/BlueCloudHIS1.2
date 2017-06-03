using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.Core;
using HIS;
using HIS.BLL;
using HIS.Model;
using System.Reflection;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem.Core;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem;
namespace HIS.Base_BLL
{
    /// <summary>
    /// 基本数据读取对象
    /// </summary>
    public class BaseDataReader : HIS.SYSTEM.Core.BaseBLL
    {
        /// <summary>
        /// HIS_Report表数据
        /// </summary>
        public static DataTable HIS_Report
        {
            get
            {
                return BindEntity<Model.HIS_Report>.CreateInstanceDAL( oleDb ).GetList( "" );
            }
        }
        /// <summary>
        /// 系统模块
        /// </summary>
        public static DataTable Base_Module
        {
            get
            {
                return BindEntity<object>.CreateInstanceDAL( oleDb , BLL.Tables.BASE_MODULE ).GetList( "" );
            }
        }
        /// <summary>
        /// 系统菜单
        /// </summary>
        public static DataTable Base_Menu
        {
            get
            {
                //return GetDataTable( "select * from base_menu order by p_menu_id,sort_id" );

                return BindEntity<object>.CreateInstanceDAL( oleDb , BLL.Tables.BASE_MENU ).GetList( " 1=1 " + oleDb.OrderBy( BLL.Tables.base_menu.P_MENU_ID , BLL.Tables.base_menu.SORT_ID ) );
            }
        }
        /// <summary>
        /// 系统用户组
        /// </summary>
        public static DataTable Base_Group
        {
            get
            {
                //return GetDataTable( "select * from base_group order by group_id" );
                return BindEntity<object>.CreateInstanceDAL( oleDb , BLL.Tables.BASE_GROUP ).GetList( "1=1" + oleDb.OrderBy(BLL.Tables.base_group.GROUP_ID) );
            }
        }
        /// <summary>
        /// 用户组菜单
        /// </summary>
        public static DataTable Base_Group_Menu
        {
            get
            {
                //return GetDataTable( "select * from base_group_menu " );
                return BindEntity<object>.CreateInstanceDAL(oleDb,BLL.Tables.BASE_GROUP_MENU).GetList("");
            }
        }
        /// <summary>
        /// 科室类型
        /// </summary>
        public static DataTable Base_Dept_Type
        {
            get
            {
                //return GetDataTable( "select CODE, NAME  from BASE_DEPT_TYPE order by CODE;" );
                return BindEntity<object>.CreateInstanceDAL( oleDb , BLL.Tables.BASE_DEPT_TYPE ).GetList( "1=1 " + oleDb.OrderBy( BLL.Tables.base_dept_type.CODE ) );

            }
        }
        /// <summary>
        /// 基本医疗服务项目
        /// </summary>
        public static DataTable Base_Service_Items
        {
            get
            {
                HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL( );
                base_dal.OleDB = oleDb;
                return base_dal.get_Base_Service_Items( );                
            }
        }
        /// <summary>
        /// 基本科室表
        /// </summary>
        public static DataTable Base_Dept_Property
        {
            get
            {
                //return GetDataTable( "select  DEPT_ID,NAME,TYPE_CODE,MZ_FLAG,ZY_FLAG,JZ_FLAG,YJ_FLAG from BASE_DEPT_PROPERTY where deleted=0" );
                return BindEntity<Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb ).GetList( BLL.Tables.base_dept_property.DELETED + oleDb.EuqalTo( ) + "0" ,
                                                                                        BLL.Tables.base_dept_property.DEPT_ID ,
                                                                                        BLL.Tables.base_dept_property.NAME ,
                                                                                        BLL.Tables.base_dept_property.PY_CODE,
                                                                                        BLL.Tables.base_dept_property.WB_CODE,
                                                                                        BLL.Tables.base_dept_property.TYPE_CODE ,
                                                                                        BLL.Tables.base_dept_property.MZ_FLAG ,
                                                                                        BLL.Tables.base_dept_property.ZY_FLAG ,
                                                                                        BLL.Tables.base_dept_property.JZ_FLAG ,
                                                                                                                                                BLL.Tables.base_dept_property.YJ_FLAG );
            }
        }
        /// <summary>
        /// 基本统计项目
        /// </summary>
        public static DataTable Base_Stat_Item
        {
            get
            {
                //return GetDataTable( "select * from base_stat_item" );
                return BindEntity<object>.CreateInstanceDAL( oleDb , BLL.Tables.BASE_STAT_ITEM ).GetList( " 1=1 order by int(code)" );
            }
        }
        /// <summary>
        /// 医生职称(国标)
        /// 返回列名称type_id,type_name
        /// </summary>
        public static DataTable Base_Doctor_Type
        {
            get
            {
                //return GetDataTable( "select type_id,type_name from base_doctor_type" );
                //return BindEntity<object>.CreateInstanceDAL( oleDb , BLL.Tables.BASE_DOCTOR_TYPE ).GetList( "" );
                //select sub_code,sub_item_name from gb_sub_item where code = '006' and sub_code between '231' and '235'
                return BindEntity<object>.CreateInstanceDAL( oleDb, BLL.Tables.GB_SUB_ITEM ).GetList( BLL.Tables.gb_sub_item.CODE + oleDb.EuqalTo() + "'006'" + oleDb.And() + BLL.Tables.gb_sub_item.SUB_CODE + oleDb.Between() + "'231'" + oleDb.And() + "'235'",
                    oleDb.FiledNameBM( BLL.Tables.gb_sub_item.SUB_CODE,"type_id" ),
                    oleDb.FiledNameBM( BLL.Tables.gb_sub_item.SUB_ITEM_NAME ,"type_name" ) );

            }
        }
        /// <summary>
        /// 国标项目名称
        /// </summary>
        public static DataTable GB_ITEM_NAME
        {
            get
            {
                //return GetDataTable( "select * from GB_ITEM_NAME" );
                return BindEntity<object>.CreateInstanceDAL( oleDb , BLL.Tables.GB_ITEM_NAME ).GetList( "" );
            }
        }
        /// <summary>
        /// 国标项目内容
        /// </summary>
        public static DataTable GB_SUB_ITEM
        {
            get
            {
                //return GetDataTable( "select * from GB_SUB_ITEM" );
                return BindEntity<object>.CreateInstanceDAL( oleDb , BLL.Tables.GB_SUB_ITEM ).GetList( "" );
            }
        }
        /// <summary>
        /// 扩展分类：门诊发票项目
        /// </summary>
        public static DataTable Base_Mzfp
        {
            get
            {
                //return GetDataTable( "select * from base_stat_mzfp" );
                return BindEntity<object>.CreateInstanceDAL(oleDb, BLL.Tables.BASE_STAT_MZFP).GetList(" VALID_FLAG=1 ");
            }
        }
        /// <summary>
        /// 扩展分类：住院发票项目
        /// </summary>
        public static DataTable Base_Zyfp
        {
            get
            {
                //return GetDataTable(  "select * from Base_stat_Zyfp" );
                return BindEntity<object>.CreateInstanceDAL(oleDb, BLL.Tables.BASE_STAT_ZYFP).GetList("  VALID_FLAG=1 ");
            }
        }
        /// <summary>
        /// 扩展分类：门诊会计
        /// </summary>
        public static DataTable Base_Mzkj
        {
            get
            {
                //return GetDataTable( "select * from Base_stat_Mzkj" );
                return BindEntity<object>.CreateInstanceDAL(oleDb, BLL.Tables.BASE_STAT_MZKJ).GetList("  VALID_FLAG=1 ");
            }
        }
        /// <summary>
        /// 扩展分类：住院会计
        /// </summary>
        public static DataTable Base_Zykj
        {
            get
            {
                //return GetDataTable( "select * from Base_stat_Zykj" );
                return BindEntity<object>.CreateInstanceDAL(oleDb, BLL.Tables.BASE_STAT_ZYKJ).GetList("  VALID_FLAG=1 ");
            }
        }
        /// <summary>
        /// 扩展分类：门诊医保
        /// </summary>
        public static DataTable Base_Mzyb
        {
            get
            {
                //return GetDataTable( "select * from Base_stat_Mzyb" );
                return BindEntity<object>.CreateInstanceDAL(oleDb, BLL.Tables.BASE_STAT_MZYB).GetList("  VALID_FLAG=1 ");
            }
        }
        /// <summary>
        /// 扩展分类： 住院医保
        /// </summary>
        public static DataTable Base_Zyyb
        {
            get
            {
                //return GetDataTable( "select * from Base_stat_Zyyb" );
                return BindEntity<object>.CreateInstanceDAL(oleDb, BLL.Tables.BASE_STAT_ZYYB).GetList("  VALID_FLAG=1 ");
            }
        }
        /// <summary>
        /// 扩展分类：经管核算
        /// </summary>
        public static DataTable Base_Hs
        {
            get
            {
                //return GetDataTable( "select * from Base_stat_Hs" );
                return BindEntity<object>.CreateInstanceDAL(oleDb, BLL.Tables.BASE_STAT_HS).GetList("  VALID_FLAG=1 ");
            }
        }
        /// <summary>
        /// 扩展分类：病案
        /// </summary>
        public static DataTable Base_Ba
        {
            get
            {
                //return GetDataTable( "select * from Base_stat_Ba" );
                return BindEntity<object>.CreateInstanceDAL(oleDb, BLL.Tables.BASE_STAT_BA).GetList("  VALID_FLAG=1 ");
            }
        }
        /// <summary>
        /// 获取指定SQL数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable( string strSql )
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL( );
            base_dal.OleDB = oleDb;

            return base_dal.GetDataTable( strSql );
        }
        /// <summary>
        /// 读取医院药品列表
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_HIS_DrugList()
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL();
            base_dal.OleDB = oleDb;

            return base_dal.Get_HIS_DrugList(  );
        }
        /// <summary>
        /// 读取医院服务项目列表
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_HIS_ItemList()
        {
            //HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL();
            //base_dal.OleDB = oleDb;

            //return base_dal.Get_HIS_ItemList();
            return BindEntity<object>.CreateInstanceDAL( oleDb , Views.VI_BASE_HOSPITAL_ITEMS ).GetList( "" ,
                Tables.base_service_items.ITEM_ID ,
                Tables.base_service_items.STD_CODE ,
                Tables.base_service_items.ITEM_NAME ,
                Tables.base_service_items.ITEM_UNIT ,
                Tables.base_service_items.PRICE ,
                Tables.base_service_items.PY_CODE ,
                Tables.base_service_items.WB_CODE );
        }
        /// <summary>
        /// 获取农合药品目录
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Ncms_DrugList()
        {
            return BindEntity<Model.NCMS_DRUG_CATALOG>.CreateInstanceDAL( oleDb ).GetList( "",
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_CODE,
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_NAME,
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_ALIAS,
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_TYPE,
                HIS.BLL.Tables.ncms_drug_catalog.DRUG_FORM,
                HIS.BLL.Tables.ncms_drug_catalog.LIMIT_PRICE,
                HIS.BLL.Tables.ncms_drug_catalog.LIMIT_DESC,
                HIS.BLL.Tables.ncms_drug_catalog.USE_LEVEL
               );
        }
        /// <summary>
        /// 获取农合医疗服务项目
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Ncms_TherapyList()
        {
            return BindEntity<Model.NCMS_THERAPY_CATALOG>.CreateInstanceDAL( oleDb ).GetList( "",
                HIS.BLL.Tables.ncms_therapy_catalog.ITEM_CODE,
                HIS.BLL.Tables.ncms_therapy_catalog.ITEM_NAME,
                HIS.BLL.Tables.ncms_therapy_catalog.UNIT,
                HIS.BLL.Tables.ncms_therapy_catalog.PRICE1,
                HIS.BLL.Tables.ncms_therapy_catalog.PRICE2,
                HIS.BLL.Tables.ncms_therapy_catalog.PRICE3,
                HIS.BLL.Tables.ncms_therapy_catalog.SPECS,
                HIS.BLL.Tables.ncms_therapy_catalog.ITEM_CONTENT,
                HIS.BLL.Tables.ncms_therapy_catalog.EXCLUDE_CONTENT
               );
        }
        /// <summary>
        /// 获取国标科室分类列表
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Standard_DeptList()
        {
            return BindEntity<object>.CreateInstanceDAL( oleDb, HIS.BLL.Tables.GB_SUB_ITEM ).GetList( BLL.Tables.gb_sub_item.CODE + oleDb.EuqalTo() + "'007'",
                BLL.Tables.gb_sub_item.SUB_CODE,
                BLL.Tables.gb_sub_item.SUB_ITEM_NAME );
        }
        /// <summary>
        /// 获取匹配关心
        /// </summary>
        /// <param name="IsNew">是否是新增的匹配关系,true:是 false:下载的</param>
        /// <param name="itemType">项目类型1-全部(不用);2-药品;3-项目</param>
        /// <returns></returns>
        public static DataTable Get_Ncms_MatchInfo(bool IsNew,string itemType)
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL();
            base_dal.OleDB = oleDb;

            if ( IsNew )
            {
                if ( itemType == "2" )
                {
                    return base_dal.Get_Ncms_Drug_Match_TempList();
                }
                else
                {
                    return base_dal.Get_Ncms_Therapy_Match_TempList();
                }
            }
            else
            {
                if ( itemType == "2" )
                {
                    return base_dal.Get_Ncms_Drug_MatchList();
                }
                else
                {
                    return base_dal.Get_Ncms_Therapy_MatchList();
                }
            }
            
        }
        /// <summary>
        /// 获取农合医疗机构信息
        /// </summary>
        /// <returns></returns>
        public static HospitalInfo Get_Ncms_HisInfo()
        {
            HisData hisData = new HisData();
            hisData.uploadorg = "400866951";
            hisData.uploadTime = DateTime.Now.ToString( "yyyy-MM-dd" );

            DataClass dataClass = new DataClass();
            DataType dataType = new DataType();
            dataType.dataTypeName = "";
            dataType.dataTypeValue = "1";
            JoinArea joinArea = new JoinArea();
            joinArea.code = "430121";
            joinArea.name = "长沙县";

            hisData.joinArea = joinArea;
            hisData.dataClass = dataClass;
            hisData.dataType = dataType;
            try
            {
                HospitalInfo hospitalInfo = NccmInterfaces.DownLoadHospitalInfo( hisData );
                if ( hospitalInfo != null )
                    return hospitalInfo;
                else
                    throw new Exception( "Invoke Successful but result is null" );
            }
            catch ( Exception err )
            {
                throw new Exception( err.Message );
            }
        }
        /// <summary>
        /// 获取药品词典
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_DrugDiciton()
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL();
            base_dal.OleDB = oleDb;

            return base_dal.Get_HIS_DrugDicition();
        }
        /// <summary>
        /// 获取医保类型
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Insur_Type()
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL();
            base_dal.OleDB = oleDb;
            return base_dal.Get_Insur_Type( );
        }
        /// <summary>
        /// 获取本院医疗服务项目(包括组合项目),字段参见Views.vi_base_hospital_items
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Hospital_Service_Items()
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL( );
            base_dal.OleDB = oleDb;
            return base_dal.Get_Hospital_Service_Items( );
        }
        /// <summary>
        /// 获取组合项目明细
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Complex_Detail()
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL( );
            base_dal.OleDB = oleDb;
            return base_dal.Get_Complex_Item_Detail( );
        }
        /// <summary>
        /// 获取医院的服务项目的执行科室(包括组合项目)
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Hsitem_ExecDept()
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL( );
            base_dal.OleDB = oleDb;
            return base_dal.Get_Hsitem_ExecDept( );
        }
        /// <summary>
        /// 获取医院还未使用的基本服务项目
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_BaseServiceItemWhereNotInUseByHospital()
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL( );
            base_dal.OleDB = oleDb;
            return base_dal.Get_Hospital_Service_Items( );
        }
        /// <summary>
        /// 获取模板列表
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_TemplateList()
        {
            return BindEntity<Model.BASE_TEMPLATE_ITEM>.CreateInstanceDAL( oleDb ).GetList( "" );
        }
        /// <summary>
        /// 获取模板明细列表
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_TemplateDetailList()
        {
            return BindEntity<Model.BASE_TEMPLATE_DETAIL>.CreateInstanceDAL( oleDb ).GetList( "" );
        }
        /// <summary>
        /// 获取划价选项卡列表
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_ShowCardList()
        {
            return BindEntity<object>.CreateInstanceDAL( oleDb , Views.VI_MZ_SHOWCARD ).GetList( "" );
        }
        /// <summary>
        /// 返回需要维护的基础表的列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVindicateTableList()
        {
            return BindEntity<BASE_VINDICATE_TABLE>.CreateInstanceDAL( oleDb ).GetList( "" );
        }
        /// <summary>
        /// 返回基础表字段维护列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVindicateTableFieldList(string strWhere)
        {
            return BindEntity<BASE_TABLE_CONFIG>.CreateInstanceDAL( oleDb ).GetList( strWhere );
        }
        /// <summary>
        /// 返回指定表的数据
        /// </summary>
        /// <param name="TableName">指定的表名称</param>
        /// <param name="strWhere">where 条件</param>
        /// <returns></returns>
        public static DataTable GetBaseTableData(string TableName,string strWhere)
        {
            return BindEntity<object>.CreateInstanceDAL( oleDb, TableName ).GetList( strWhere );
                     
        }
        /// <summary>
        /// 返回指定表数据表，列为指定列
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Fields">要返回的列名</param>
        /// <param name="strWhere">where条件</param>
        /// <returns></returns>
        public static DataTable GetBaseTableData( string TableName, string[] Fields, string strWhere )
        {
            

            string sql = "";
            if ( Fields != null )
            {
                sql = oleDb.Table( TableName, "", strWhere, Fields );
                return oleDb.GetDataTable( sql );
            }
            else
                return BindEntity<object>.CreateInstanceDAL( oleDb, TableName ).GetList( strWhere );

           
            
        }
        /// <summary>
        /// 获得医嘱项目列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetOrderList()
        {
            string sql = @"select a.*,
                            b.item_name as service_item_name,b.price as service_item_price,b.item_unit as service_item_unit,
                            c.name as medical_class_name,d.name as order_type_name  from
                            base_order_items a 
                            left join (select item_id,item_name,price,item_unit,(case when complex_id=0 then 0 else 1 end ) as tc_flag from VI_BASE_HOSPITAL_ITEMS where workid="+HIS.SYSTEM.Core.EntityConfig.WorkID+@") b on a.item_id = b.item_id and a.tc_flag = b.tc_flag
                            left join (select id,name from base_medical_class) c on a.medical_class = c.id 
                            left join (select id,name from base_order_type) d  on a.order_type = d.id" + @"
                            where a.workid="+HIS.SYSTEM.Core.EntityConfig.WorkID;
            return oleDb.GetDataTable(sql);
        }
        /// <summary>
        /// 获取用法列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUsageDictionList()
        {
            return BindEntity<Base_UsageDiction>.CreateInstanceDAL( oleDb ).GetList( "" );
        }
        /// <summary>
        /// 获取用法费用联动数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUsageFee()
        {
            return BindEntity<object>.CreateInstanceDAL( oleDb , "BASE_USEAGE_FEE" ).GetList( "" );
        }
        /// <summary>
        /// 得到药剂科室列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDrugRoomList()
        {
            return BindEntity<YP_DeptDic>.CreateInstanceDAL( oleDb ).GetList("");
        }

        public static DataTable GetOrderType()
        {
            return BindEntity<BASE_ORDER_TYPE>.CreateInstanceDAL( oleDb ).GetList( "" );
        }

        public static DataTable Get_PresDoc_EditItem()
        {
            string strSql = @"SELECT CODE,ITEM_NAME,(CASE WHEN ALLOW_EDIT IS NULL THEN 0 ELSE ALLOW_EDIT END) AS ALLOW_EDIT,(CASE WHEN WORKID IS NULL THEN 0 ELSE WORKID END) AS WORKID FROM
                            (
                            SELECT A.CODE,A.ITEM_NAME,B.ALLOW_EDIT,B.WORKID 
                            FROM BASE_STAT_ITEM A LEFT JOIN (SELECT * FROM MZ_DOCPRES_EDITITEM WHERE WORKID = " + HIS.SYSTEM.Core.EntityConfig.WorkID.ToString() + @") B ON A.CODE = B.STATITEM_CODE
                            ) aa where code not in ('00','01','02','03')";

            return oleDb.GetDataTable( strSql );
        }

        public static DataTable GetBaseServiceItems()
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL();
            base_dal.OleDB = oleDb;
            return base_dal.GetBaseServiceItems();
        }
        public static DataTable GetRegisterTypeAndServiceItemRelation()
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL();
            base_dal.OleDB = oleDb;
            return base_dal.GetRegisterTypeAndServiceItemRelation();
        }
        public static DataTable GetRegisterTypeList()
        {
            HIS.DAL.BASE_DAL base_dal = new HIS.DAL.BASE_DAL();
            base_dal.OleDB = oleDb;
            return base_dal.GetRegisterTypeList();
        }
    }
}
