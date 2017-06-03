using System;
using System.Data;
using HIS.BLL;
using HIS.Model;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;

namespace HIS.Base_BLL
{
    internal class BaseDal : BaseBLL
    {
        private static long workId;

        private enum TherapyAndDurgQueryClass
        {
            查询医院所应用的基本医疗服务项目 = 0 ,
            查询医院所应用的组合项目 = 1 ,
            查询医院所应用的基本医疗服务项目和组合项目 = 2 ,
            查询医院所应用的药品项目 = 3 ,
            查询医院所应用的基本医疗服务项目和组合项目以及药品项目 = 4
        }
        /// <summary>
        /// 基本数据访问
        /// </summary>
        /// <param name="dataClass"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(DataEnum dataClass )
        {
            ParameterEx[] parameters = null;
            DataTable dtResult = null;
            string sql = "";
            switch ( dataClass )
            {
                case DataEnum.医院列表:
                    dtResult = oleDb.GetDataTable(  "select * from HIS_WORKERS a,HIS_WORKERSINFO b where a.workid=b.workid and a.workid<>0 ");
                    break;
                case DataEnum.模块列表:
                    dtResult = BindEntity<object>.CreateInstanceDAL( oleDb , Tables.BASE_MODULE , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.菜单列表:
                    dtResult = BindEntity<object>.CreateInstanceDAL( oleDb , Tables.BASE_MENU , workId ).GetList( " 1=1 " + oleDb.OrderBy( BLL.Tables.base_menu.P_MENU_ID , BLL.Tables.base_menu.SORT_ID ),"*" );
                    break;
                case DataEnum.用户组列表:
                    dtResult = BindEntity<BASE_GROUP>.CreateInstanceDAL( oleDb , Tables.BASE_GROUP , workId ).GetList( "" ,"*");
                    break;
                case DataEnum.用户组菜单表:
                    dtResult = BindEntity<BASE_GROUP_MENU>.CreateInstanceDAL( oleDb , Tables.BASE_GROUP_MENU , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.用户信息表:
                    dtResult = BindEntity<BASE_USER>.CreateInstanceDAL( oleDb , Tables.BASE_USER , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.用户及用户组关系表:
                    dtResult = BindEntity<BASE_GROUP_USER>.CreateInstanceDAL( oleDb , Tables.BASE_GROUP_USER , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.科室类型表:
                    dtResult = BindEntity<object>.CreateInstanceDAL( oleDb , Tables.BASE_DEPT_TYPE , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.医院科室表:
                    dtResult = BindEntity<BASE_DEPT_PROPERTY>.CreateInstanceDAL( oleDb , Tables.BASE_DEPT_PROPERTY , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.医院人员信息表:
                    dtResult = BindEntity<BASE_EMPLOYEE_PROPERTY>.CreateInstanceDAL( oleDb , Tables.BASE_EMPLOYEE_PROPERTY , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.医生类型表:
                    dtResult = BindEntity<object>.CreateInstanceDAL( oleDb , Tables.BASE_DOCTOR_TYPE , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.国标名称分类表:
                    dtResult = BindEntity<object>.CreateInstanceDAL( oleDb , Tables.GB_ITEM_NAME , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.国标项目表:
                    dtResult = BindEntity<object>.CreateInstanceDAL( oleDb , Tables.GB_SUB_ITEM , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.基本统计分类表:
                    dtResult = BindEntity<BASE_STAT_ITEM>.CreateInstanceDAL( oleDb , Tables.BASE_STAT_ITEM , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.门诊发票项目表:
                    dtResult = BindEntity<BASE_STAT_MZFP>.CreateInstanceDAL( oleDb , Tables.BASE_STAT_MZFP , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.住院发票项目表:
                    dtResult = BindEntity<BASE_STAT_ZYFP>.CreateInstanceDAL( oleDb , Tables.BASE_STAT_ZYFP , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.门诊会计项目表:
                    dtResult = BindEntity<BASE_STAT_MZKJ>.CreateInstanceDAL( oleDb , Tables.BASE_STAT_MZKJ , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.住院会计项目表:
                    dtResult = BindEntity<BASE_STAT_ZYKJ>.CreateInstanceDAL( oleDb , Tables.BASE_STAT_ZYKJ , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.门诊医保项目表:
                    dtResult = BindEntity<BASE_STAT_MZYB>.CreateInstanceDAL( oleDb , Tables.BASE_STAT_MZYB , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.住院医保项目表:
                    dtResult = BindEntity<BASE_STAT_ZYYB>.CreateInstanceDAL( oleDb , Tables.BASE_STAT_ZYYB , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.医院核算项目表:
                    dtResult = BindEntity<BASE_STAT_HS>.CreateInstanceDAL( oleDb , Tables.BASE_STAT_HS , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.医院病案项目表:
                    dtResult = BindEntity<BASE_STAT_BA>.CreateInstanceDAL( oleDb , Tables.BASE_STAT_BA , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.医保药品类型表:
                    dtResult = BindEntity<YP_MedicareDic>.CreateInstanceDAL( oleDb , Tables.YP_MEDICAREDIC , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.基本医疗服务项目表:
                    dtResult = BindEntity<BASE_SERVICE_ITEMS>.CreateInstanceDAL( oleDb , Tables.BASE_SERVICE_ITEMS , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.组合项目表:
                    dtResult = BindEntity<BASE_COMPLEX_ITEM>.CreateInstanceDAL( oleDb , Tables.BASE_COMPLEX_ITEM , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.组合项目明细表:
                    dtResult = BindEntity<BASE_COMPLEX_DETAIL>.CreateInstanceDAL( oleDb , Tables.BASE_COMPLEX_DETAIL , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.划价模板表:
                    dtResult = BindEntity<BASE_TEMPLATE_ITEM>.CreateInstanceDAL( oleDb , Tables.BASE_TEMPLATE_ITEM , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.划价模板明细表:
                    dtResult = BindEntity<BASE_TEMPLATE_DETAIL>.CreateInstanceDAL( oleDb , Tables.BASE_TEMPLATE_DETAIL , workId ).GetList( "" , "*" );
                    break;                
                case DataEnum.院内基本医疗服务项目表:
                    dtResult = BindEntity<BASE_HOSPITAL_ITEMS>.CreateInstanceDAL( 
                                    oleDb , Tables.BASE_HOSPITAL_ITEMS , workId ).GetList( "COMPLEX_ID=0" , "*" );
                    break;
                case DataEnum.院内组合项目表:
                    dtResult = BindEntity<BASE_HOSPITAL_ITEMS>.CreateInstanceDAL(
                                    oleDb , Tables.BASE_HOSPITAL_ITEMS , workId ).GetList( "COMPLEX_ID<>0" , "*" );
                    break;
                case DataEnum.医嘱项目表:
                    dtResult = BindEntity<Base_Order_Items>.CreateInstanceDAL( oleDb , Tables.BASE_ORDER_ITEMS , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.医嘱类型表:
                    dtResult = BindEntity<BASE_ORDER_TYPE>.CreateInstanceDAL( oleDb , Tables.BASE_ORDER_TYPE , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.用法定义表:
                    dtResult = BindEntity<Base_UsageDiction>.CreateInstanceDAL( oleDb , Tables.BASE_USAGEDICTION , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.用法费用联动表:
                    dtResult = BindEntity<BASE_USEAGE_FEE>.CreateInstanceDAL( oleDb , Tables.BASE_USEAGE_FEE , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.频次定义表:
                    dtResult = BindEntity<Base_Frequency>.CreateInstanceDAL( oleDb , Tables.BASE_FREQUENCY , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.药剂科室表:
                    dtResult = BindEntity<YP_DeptDic>.CreateInstanceDAL( oleDb , Tables.YP_DEPTDIC , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.医生处方修改权限表:
                    //dtResult = BindEntity<object>.CreateInstanceDAL( oleDb , "MZ_DOCPRES_EDITITEM" , workId ).GetList( "" , "*" );
                    dtResult = oleDb.GetDataTable( "select * from  MZ_DOCPRES_EDITITEM" );
                    break;
                case DataEnum.医院人员科室信息表:
                    sql = @"select a.*,b.dept_id from base_employee_property a ,base_emp_dept_role b 
                            where a.employee_id=b.employee_id 
                            and a.workid = b.workid ";
                    dtResult = oleDb.GetDataTable( sql );
                    break;
                case DataEnum.医生列表:
                    dtResult = BindEntity<BASE_ROLE_DOCTOR>.CreateInstanceDAL( oleDb , Tables.BASE_ROLE_DOCTOR , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.门诊经管参数表:
                    dtResult = BindEntity<Model.MZ_CONFIG>.CreateInstanceDAL( oleDb , "MZ_Config" , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.住院经管参数表:
                    dtResult = BindEntity<object>.CreateInstanceDAL( oleDb , Tables.ZY_CONFIG , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.门诊医生参数表:
                    dtResult = BindEntity<Model.MZ_DOC_CONFIG>.CreateInstanceDAL( oleDb , "Mz_Doc_Config" , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.住院医生参数表:
                    dtResult = BindEntity<Model.ZY_DOC_CONFIG>.CreateInstanceDAL( oleDb , "ZY_Doc_Config" , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.住院护士参数表:
                    dtResult = BindEntity<object>.CreateInstanceDAL( oleDb , "ZY_NURSE_CONFIG" , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.药品参数表:
                    dtResult = BindEntity<Model.YP_CONFIG>.CreateInstanceDAL( oleDb , "YP_Config" , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.挂号类别表:
                    string _gs_1_2 = oleDb.Sum( "C." + Tables.base_service_items.PRICE , "" );
                    string strWhere_3 = "A." + Tables.mz_reg_type.TYPE_CODE + oleDb.EuqalTo() + "B." + Tables.mz_reg_item_fee.TYPE_CODE + oleDb.And() +
                                     "B." + Tables.mz_reg_item_fee.ITEM_ID + oleDb.EuqalTo() + "C." + Tables.base_service_items.ITEM_ID;
                    string tb = oleDb.TableName( oleDb.TableNameBM( Tables.MZ_REG_TYPE , "A" ) , oleDb.TableNameBM( Tables.MZ_REG_ITEM_FEE , "B" ) , oleDb.TableNameBM( Tables.BASE_SERVICE_ITEMS , "C" ) );
                    string strsql = oleDb.Table( tb , "" , strWhere_3 ,
                               "A." + Tables.mz_reg_type.TYPE_CODE ,
                               "A." + Tables.mz_reg_type.TYPE_NAME ,
                               "A." + Tables.mz_reg_type.PY_CODE ,
                               "A." + Tables.mz_reg_type.WB_CODE ,
                               "A." + Tables.mz_reg_type.VALID_FLAG ,
                               oleDb.FiledNameBM( _gs_1_2 , "PRICE" ) );
                    strsql += oleDb.GroupBy( "A." + Tables.mz_reg_type.TYPE_CODE , "A." + Tables.mz_reg_type.TYPE_NAME , "A." + Tables.mz_reg_type.PY_CODE , "A." + Tables.mz_reg_type.WB_CODE , "A." + Tables.mz_reg_type.VALID_FLAG );
                    dtResult = oleDb.GetDataTable( strsql );
                    break;
                case DataEnum.挂号类别与服务项目对应表:
                    string strWhere_4 = "A." + Tables.mz_reg_type.TYPE_CODE + oleDb.EuqalTo() + "B." + Tables.mz_reg_item_fee.TYPE_CODE + oleDb.And() +
                             "B." + Tables.mz_reg_item_fee.ITEM_ID + oleDb.EuqalTo() + "C." + Tables.base_service_items.ITEM_ID + oleDb.And() + Tables.mz_reg_item_fee.APPEND + oleDb.EuqalTo() + "0";

                    string tb1 = oleDb.TableName( oleDb.TableNameBM( Tables.MZ_REG_TYPE , "A" ) , oleDb.TableNameBM( Tables.MZ_REG_ITEM_FEE , "B" ) , oleDb.TableNameBM( Tables.BASE_SERVICE_ITEMS , "C" ) );
                    string strsql1 = oleDb.Table( tb1 , "" , strWhere_4 ,
                               "A." + Tables.mz_reg_type.TYPE_CODE ,
                                "C." + Tables.base_service_items.ITEM_ID ,
                                "C." + Tables.base_service_items.ITEM_NAME ,
                                "C." + Tables.base_service_items.PRICE
                                );
                    dtResult = oleDb.GetDataTable( strsql1 );
                    break;
                case DataEnum.医技分类表:
                    dtResult = BindEntity<Base_Medical_Class>.CreateInstanceDAL( oleDb , Tables.BASE_MEDICAL_CLASS , workId ).GetList( "" , "*" );
                    break;
                case DataEnum.基本药品列表:
                    sql = @"select a.makerdicid as ITEM_ID,b.chemname as ITEM_NAME,b.spec as STANDARD,c.unitname  as ITEM_UNIT,a.retailprice AS PRICE,d.pym as PY_CODE,d.wbm as WB_CODE
                            from yp_makerdic a ,yp_specdic b, yp_unitdic c ,yp_bynamedic d
                            where a.specdicid=b.specdicid and b.unit = c.unitdicid and b.specdicid=d.specdicid";
                    dtResult = oleDb.GetDataTable( sql );
                    break;
                default:
                    throw new NotImplementedException( dataClass.ToString() + "的数据访问方法未实现" );
            }
            dtResult.TableName = dataClass.ToString();
            return dtResult;
        }
    }
}
