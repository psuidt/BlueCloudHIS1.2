using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem.Core;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem.Enums;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem;

namespace HIS.Base_BLL
{

    /// <summary>
    /// 匹配管理类
    /// </summary>
    public class MatchManager : HIS.SYSTEM.Core.BaseBLL
    {
        
        /// <summary>
        /// 参合地区编码
        /// </summary>
        private static readonly string CURRENT_JOINAREA_CODE = "430121";
        /// <summary>
        /// 参合地区名称
        /// </summary>
        private static readonly string CURRENT_JOINAREA_NAME = "长沙县";

        private static readonly string CURRENT_MEDORG_CODE = "400866962";

        private static readonly string CURRENT_REGION_CODE = "430121";

        private HospitalInfo hosptialInfo;
        /// <summary>
        /// 下载农合药品目录到本地数据库
        /// </summary>
        public static void DownLoadAndSaveNcmsDrug()
        {
            try
            {
                //药品列表容器
                List<Drug> drugList = new List<Drug>();
                //定义入口参数
                DownLoadItem hisData = new DownLoadItem();
                JoinArea joinArea = new JoinArea();
                joinArea.code = CURRENT_JOINAREA_CODE;
                joinArea.name = CURRENT_JOINAREA_NAME;

                DataType dataType = new DataType();
                dataType.dataTypeName = NcmsDataType.门诊数据.ToString();
                dataType.dataTypeValue = ( (int)NcmsDataType.门诊数据 ).ToString();

                //项目类型 [1（所有目录）[2（药品目录），3（诊疗项目目录）]
                Condition condition = new Condition();
                condition.condition_name = "CONTENT_TYPE";
                condition.condition_value = ( (int)DownLoadItemType.DRUG ).ToString();
                //要下载的页码 整数
                int current_page = 1;
                Condition condition1 = new Condition();
                condition1.condition_name = "CURRENT_PAGE";
                condition1.condition_value = current_page.ToString();
                //要下载的每页大小
                Condition condition2 = new Condition();
                condition2.condition_name = "PAGE_SIZE";
                condition2.condition_value = "100";

                hisData.uploadorg = "23423";
                hisData.dataType = dataType;
                hisData.joinArea = joinArea;

                Condition[] conditions = new Condition[3];
                conditions[0] = condition;
                conditions[1] = condition1;
                conditions[2] = condition2;
                hisData.conditions = conditions;
                //下载第一页并取得页面相关信息
                DownLoadCenterItemResult result = NccmInterfaces.DownLoadDrugListInfo( hisData );
                if ( result.resultId )
                {
                    drugList = result.drug.ToList<Drug>();

                    int totalPage = result.drugPageInfo.totalPageNo;

                    current_page = 2;

                    while ( current_page <= totalPage )
                    {
                        //重新指定要下载的页
                        hisData.conditions[1].condition_value = current_page.ToString();

                        result = NccmInterfaces.DownLoadDrugListInfo( hisData );

                        if ( result.resultId )
                        {
                            //追加到List
                            for ( int i = 0; i < result.drug.Length; i++ )
                                drugList.Add( result.drug[i] );
                        }
                        else
                        {
                            throw new Exception( result.resultString );
                        }
                        current_page++;
                    }
                    //将药品信息保存到数据库
                    try
                    {
                        oleDb.BeginTransaction();
                        HIS.SYSTEM.Core.BindEntity<Model.NCMS_DRUG_CATALOG>.CreateInstanceDAL( oleDb ).Delete( "" );
                        foreach ( Drug drug in drugList )
                        {
                            Model.NCMS_DRUG_CATALOG model = new HIS.Model.NCMS_DRUG_CATALOG();
                            #region .......
                            model.DRUG_ALIAS = drug.drug_alias;
                            model.DRUG_CODE = drug.drug_code;
                            model.DRUG_CODE2 = drug.drug_code2;
                            model.DRUG_FORM = drug.drug_form;
                            model.DRUG_NAME = drug.drug_name;
                            model.DRUG_TYPE = drug.drug_type;
                            model.DRUGCLASS_CODE = drug.drugclass_code;
                            model.LIMIT_DEPT = drug.limit_dept;
                            model.LIMIT_DESC = drug.limit_desc;
                            model.LIMIT_DISEASE = drug.limit_disease;
                            model.LIMIT_DOCTOR = drug.limit_doctor;
                            model.LIMIT_FORM = drug.limit_form;
                            model.LIMIT_HOSPITAL = drug.limit_hospital;
                            model.LIMIT_LINE = drug.limit_line;
                            model.LIMIT_MAKER = drug.limit_maker;
                            model.LIMIT_PRICE = drug.limit_price.ToString();
                            model.LIMIT_PRICEFIELDSPECI = drug.limit_priceSpecified.ToString();
                            model.LIMIT_UNIT_NAME = drug.limit_unit_name;
                            model.LIMIT_UNIT_NUM = drug.limit_unit_num;
                            model.MARK = drug.mark;
                            model.USE_LEVEL = drug.use_level;
                            #endregion
                            
                            HIS.SYSTEM.Core.BindEntity<Model.NCMS_DRUG_CATALOG>.CreateInstanceDAL( oleDb ).Add( model );
                            
                        }
                        oleDb.CommitTransaction();
                    }
                    catch(Exception err)
                    {
                        oleDb.RollbackTransaction();
                        throw err;
                    }
                }
                else
                {
                    throw new Exception( result.resultString );
                }
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 下载诊疗服务项目
        /// </summary>
        public static void DownLoadAndSavNcmsTherapy()
        {
            try
            {
                //药品列表容器
                List<Therapy> theraypList = new List<Therapy>();
                //定义入口参数
                DownLoadItem hisData = new DownLoadItem();
                JoinArea joinArea = new JoinArea();
                joinArea.code = CURRENT_JOINAREA_CODE;
                joinArea.name = CURRENT_JOINAREA_NAME;

                DataType dataType = new DataType();
                dataType.dataTypeName = NcmsDataType.门诊数据.ToString();
                dataType.dataTypeValue = ( (int)NcmsDataType.门诊数据 ).ToString();

                //项目类型 [1（所有目录）[2（药品目录），3（诊疗项目目录）]
                Condition condition = new Condition();
                condition.condition_name = "CONTENT_TYPE";
                condition.condition_value = ( (int)DownLoadItemType.THERAPY ).ToString();
                //要下载的页码 整数
                int current_page = 1;
                Condition condition1 = new Condition();
                condition1.condition_name = "CURRENT_PAGE";
                condition1.condition_value = current_page.ToString();
                //要下载的每页大小
                Condition condition2 = new Condition();
                condition2.condition_name = "PAGE_SIZE";
                condition2.condition_value = "100";

                hisData.uploadorg = "23423";
                hisData.dataType = dataType;
                hisData.joinArea = joinArea;

                Condition[] conditions = new Condition[3];
                conditions[0] = condition;
                conditions[1] = condition1;
                conditions[2] = condition2;
                hisData.conditions = conditions;
                //下载第一页并取得页面相关信息
                DownLoadCenterItemResult result = NccmInterfaces.DownLoadDrugListInfo( hisData );
                if ( result.resultId )
                {
                    theraypList = result.therapy.ToList<Therapy>();

                    int totalPage = result.therapyPageInfo.totalPageNo;

                    current_page = 2;

                    while ( current_page <= totalPage )
                    {
                        //重新指定要下载的页
                        hisData.conditions[1].condition_value = current_page.ToString();

                        result = NccmInterfaces.DownLoadTherapyListInfo( hisData );

                        if ( result.resultId )
                        {
                            //追加到List
                            for ( int i = 0; i < result.therapy.Length; i++ )
                                theraypList.Add( result.therapy[i] );
                        }
                        else
                        {
                            throw new Exception( result.resultString );
                        }
                        current_page++;
                    }
                    //将药品信息保存到数据库
                    try
                    {
                        oleDb.BeginTransaction();
                        HIS.SYSTEM.Core.BindEntity<Model.NCMS_THERAPY_CATALOG>.CreateInstanceDAL( oleDb ).Delete( "" );
                        foreach ( Therapy therapy in theraypList )
                        {
                            Model.NCMS_THERAPY_CATALOG model = new HIS.Model.NCMS_THERAPY_CATALOG();
                            #region .......
                            model.EXCLUDE_CONTENT = therapy.exclude_content;
                            model.FINANCE_TYPE = therapy.finance_type;
                            model.ITEM_CODE = therapy.item_code;
                            model.ITEM_CONTENT = therapy.item_content;
                            model.ITEM_NAME = ConvertSpeciString( therapy.item_name );
                            model.MARK = therapy.mark;
                            model.MEDCLASS_CODE = therapy.medclass_code;
                            model.PRICE1 = therapy.price1;
                            model.PRICE2 = therapy.price2;
                            model.PRICE3 = therapy.price3;
                            model.SPECS = therapy.specs;
                            model.UNIT = therapy.unit;
                            #endregion

                            HIS.SYSTEM.Core.BindEntity<Model.NCMS_THERAPY_CATALOG>.CreateInstanceDAL( oleDb ).Add( model );

                        }
                        oleDb.CommitTransaction();
                    }
                    catch ( Exception err )
                    {
                        oleDb.RollbackTransaction();
                        throw err;
                    }
                }
                else
                {
                    throw new Exception( result.resultString );
                }
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 下载匹配信息
        /// </summary>
        public static void DownLoadAndSaveMatchInfo()
        {

            List<ItemMatchInfo> matchList = new List<ItemMatchInfo>();

            DownLoadItem hisData = new DownLoadItem();

            JoinArea joinArea = new JoinArea();
            joinArea.code = CURRENT_JOINAREA_CODE;
            joinArea.name = CURRENT_JOINAREA_NAME;


            DataClass dataClass = new DataClass();
            dataClass.dataClassName = NcmsDataClass.新农合数据.ToString();
            dataClass.dataClassValue = ((int)NcmsDataClass.新农合数据).ToString();

            DataType dataType = new DataType();
            dataType.dataTypeName = NcmsDataType.收费项目.ToString();
            dataType.dataTypeValue = ((int)NcmsDataType.收费项目).ToString();

            OperType operType = new OperType();
            operType.operTypeName = NcmsOperType.查询.ToString();
            operType.operTypeValue = ((int)NcmsOperType.查询).ToString();

            Condition Content_type = new Condition();
            Condition Approve_status = new Condition();
            Condition Current_page = new Condition();
            Condition Page_size = new Condition();

            Content_type.condition_displayname = "项目类型";
            Content_type.condition_name = "CONTENT_TYPE";
            Content_type.condition_value = "1";

            Approve_status.condition_displayname = "审核状态";
            Approve_status.condition_name = "APPROVE_STATUS";
            Approve_status.condition_value = "4";

            int current_page = 1;
            Current_page.condition_displayname = "要下载的页码";
            Current_page.condition_name = "CURRENT_PAGE";
            Current_page.condition_value = current_page.ToString();

            int pageSize = 100;
            Page_size.condition_displayname = "页面大小";
            Page_size.condition_name = "PAGE_SIZE";
            Page_size.condition_value = pageSize.ToString();

            Condition[] cond = new Condition[] { Content_type, Approve_status, Current_page, Page_size };

            hisData.joinArea = joinArea;
            hisData.dataClass = dataClass;
            hisData.dataType = dataType;
            hisData.operType = operType;
            hisData.conditions = cond;
            hisData.uploadorg = "400866951";

            try
            {
                RecieveHospitalMatchInfoResult result = NccmInterfaces.DownLoadMatchInfo( hisData );
                
                if ( result.resultId )
                {
                    matchList = result.itemMatchInfo.ToList<ItemMatchInfo>();

                    current_page = 2;

                    while ( 1==1 )
                    {
                        //重新指定要下载的页
                        hisData.conditions[2].condition_value = current_page.ToString();

                        result = NccmInterfaces.DownLoadMatchInfo( hisData );
                        if ( result.itemMatchInfo == null )
                            break;

                        if ( result.resultId )
                        {
                            //追加到List
                            for ( int i = 0; i < result.itemMatchInfo.Length; i++ )
                                matchList.Add( result.itemMatchInfo[i] );
                        }
                        else
                        {
                            throw new Exception( result.resultString );
                        }
                        current_page++;
                    }
                    //保存到数据库
                    try
                    {
                        oleDb.BeginTransaction();

                        HIS.SYSTEM.Core.BindEntity<Model.NCMS_MATCH_CATALOG>.CreateInstanceDAL( oleDb ).Delete( ""  );

                        foreach ( ItemMatchInfo match in matchList )
                        {
                            Model.NCMS_MATCH_CATALOG model = new HIS.Model.NCMS_MATCH_CATALOG();
                            model.APPROVE_STATUS = match.approve_status;
                            model.APPROVETIME = match.approveTime;
                            model.HOSPITAL_CODE = match.hospital_code;
                            model.IF_EQUAL = match.if_equal;
                            model.MEDORG_CODE = match.medorg_code;
                            model.NCMS_CODE = match.ncms_code;
                            model.REGION_CODE = match.region_code;
                            model.STATUS = match.status;
                            model.TYPE = match.type;
                            model.UPLOAD_TIME = match.upload_time;
                            model.UPLOADER = match.uploader;

                            HIS.SYSTEM.Core.BindEntity<Model.NCMS_MATCH_CATALOG>.CreateInstanceDAL( oleDb ).Add( model );
                        }
                        oleDb.CommitTransaction();
                    }
                    catch(Exception err)
                    {
                        oleDb.RollbackTransaction();
                        throw err;
                    }
                }
            }
            catch ( Exception err )
            {
                throw new Exception( err.Message );
            }
        }

        private static string ConvertSpeciString(string strValue )
        {
            strValue = strValue.Replace( "(", "（" );
            strValue = strValue.Replace( ")", "）" );
            strValue = strValue.Replace( "'", "''" );
            return strValue;
        }
        /// <summary>
        /// 建立匹配信息，保存到临时表
        /// </summary>
        /// <param name="NcmsCode">农合代码</param>
        /// <param name="HosptialCode">医院代码</param>
        /// <param name="ItemType">项目类型,1-药品，2-项目</param>
        /// <returns></returns>
        public static bool AddMatchInfo(string NcmsCode,string HosptialCode,string ItemType )
        {
            Model.NCMS_MATCH_CATALOG_TEMP model = new HIS.Model.NCMS_MATCH_CATALOG_TEMP();
            model.NCMS_CODE = NcmsCode;
            model.HOSPITAL_CODE = HosptialCode;
            model.TYPE = ItemType;
            model.STATUS = "0"; //上传状态 0-未上传 1-已上传

            try
            {
                if ( HIS.SYSTEM.Core.BindEntity<Model.NCMS_MATCH_CATALOG_TEMP>.CreateInstanceDAL( oleDb ).GetModel( HIS.BLL.Tables.ncms_match_catalog_temp.NCMS_CODE + "='" + NcmsCode + "' and " + HIS.BLL.Tables.ncms_match_catalog_temp.HOSPITAL_CODE + "='" + HosptialCode + "'" ) == null )
                {
                    HIS.SYSTEM.Core.BindEntity<Model.NCMS_MATCH_CATALOG_TEMP>.CreateInstanceDAL( oleDb ).Add( model );
                }
                else
                {
                    HIS.SYSTEM.Core.BindEntity<Model.NCMS_MATCH_CATALOG_TEMP>.CreateInstanceDAL( oleDb ).Update( model );
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 删除匹配关系
        /// </summary>
        /// <param name="NcmsCode"></param>
        /// <param name="HosptialCode"></param>
        /// <param name="ItemType"></param>
        /// <returns></returns>
        public static bool DeletematchInfo( string NcmsCode, string HosptialCode, string ItemType )
        {
            string strWhere = HIS.BLL.Tables.ncms_match_catalog_temp.NCMS_CODE + "='" + NcmsCode + "' and " + HIS.BLL.Tables.ncms_match_catalog_temp.HOSPITAL_CODE + "='" + HosptialCode + "'" ;
            try
            {
                HIS.SYSTEM.Core.BindEntity<Model.NCMS_MATCH_CATALOG_TEMP>.CreateInstanceDAL( oleDb ).Delete( strWhere );
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 上传匹配关系
        /// </summary>
        public static void UploadMatchInfo(MatchInfo[] matchList ,HospitalInfo hospitalInfo ,out string Msg )
        {
         
            JoinArea joinArea = new JoinArea();
            joinArea.code = CURRENT_JOINAREA_CODE;
            joinArea.name = CURRENT_JOINAREA_NAME;

            DataType dataType = new DataType();
            dataType.dataTypeName = NcmsDataType.门诊数据.ToString();
            dataType.dataTypeValue = ( (int)NcmsDataType.门诊数据 ).ToString();

            //定义本次上传的项目集合
            ItemMatchInfo[] matchItems = new ItemMatchInfo[matchList.Length];
            for ( int i = 0; i < matchList.Length; i++ )
            {
                ItemMatchInfo matchItem = new ItemMatchInfo();
                matchItem.drug_alias = matchList[i].drug_alias;
                matchItem.drug_form = matchList[i].drug_form;
                matchItem.drug_type = matchList[i].drug_type;
                matchItem.hospital_code = matchList[i].hospital_code;
                matchItem.if_equal = "0";
                matchItem.limit_desc = matchList[i].limit_desc;
                matchItem.medorg_code = hospitalInfo.org_id;
                matchItem.ncms_code = matchList[i].ncms_code;
                matchItem.price = matchList[i].price1;
                matchItem.price1 = matchList[i].price1;
                matchItem.price2 = matchList[i].price2;
                matchItem.price3 = matchList[i].price3;
                matchItem.region_code = CURRENT_REGION_CODE;
                matchItem.specs = matchList[i].specs;
                matchItem.status = "1";

                matchItem.therapy_content = matchList[i].therapy_content;
                matchItem.therapy_exclude = matchList[i].therapy_exclude;
                matchItem.type = matchList[i].type;
                matchItem.upload_time = DateTime.Now.ToString( "yyyy-MM-dd" );
                matchItem.uploader = hospitalInfo.userCode ;
                matchItem.use_level = matchList[i].use_levle;

                matchItems[i] = matchItem;                
            }

            RecieveHospitalMatchInfo hisData = new RecieveHospitalMatchInfo();

            hisData.itemMatchInfo = matchItems;
            hisData.joinArea = joinArea;
            hisData.dataType = dataType;
            hisData.uploadorg = "111";
            try
            {
                ItemMatchInfo[] uploadFailedItems;
                if ( NccmInterfaces.UploadMatchInfo( hisData, out uploadFailedItems, out Msg ) )
                {
                    //回写上传标识nnms_match_catalog_temp.status
                    for ( int i = 0; i < matchList.Length; i++ )
                    {
                        bool uploadSuccess = true;
                        if ( uploadFailedItems != null )
                        {
                            for ( int j = 0; j < uploadFailedItems.Length; j++ )
                            {
                                //跳过上传失败的记录
                                if ( matchList[i].ncms_code == uploadFailedItems[j].ncms_code
                                    && matchList[i].hospital_code == uploadFailedItems[j].hospital_code )
                                {
                                    uploadSuccess = false;
                                    break;
                                }
                            }
                        }
                        if ( uploadSuccess )
                        {
                            string strWhere = HIS.BLL.Tables.ncms_match_catalog_temp.HOSPITAL_CODE + oleDb.EuqalTo() + "'" + matchList[i].hospital_code + "'";
                            strWhere += oleDb.And() + HIS.BLL.Tables.ncms_match_catalog_temp.NCMS_CODE + oleDb.EuqalTo() + "'" + matchList[i].ncms_code + "'";
                            HIS.SYSTEM.Core.BindEntity<Model.NCMS_MATCH_CATALOG_TEMP>.CreateInstanceDAL( oleDb ).Update( strWhere, "STATUS='1'" );
                        }
                    }
                    
                }
            }
            catch(Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 保存补偿比例
        /// </summary>
        /// <param name="hospital_code"></param>
        /// <param name="ncms_code"></param>
        /// <param name="type"></param>
        /// <param name="rate"></param>
        public static void SaveCompRate(string hospital_code,string ncms_code,string type,decimal rate)
        {
            string strWhere = HIS.BLL.Tables.ncms_match_catalog_temp.NCMS_CODE + oleDb.EuqalTo() + "'" + ncms_code + "' " + oleDb.And() + 
                HIS.BLL.Tables.ncms_match_catalog_temp.HOSPITAL_CODE + oleDb.EuqalTo() + "'" + hospital_code + "'" + oleDb.And() + 
                HIS.BLL.Tables.ncms_match_catalog_temp.TYPE + oleDb.EuqalTo() + "'" + type + "'";
            
            Model.NCMS_MATCH_CATALOG_TEMP model = HIS.SYSTEM.Core.BindEntity<Model.NCMS_MATCH_CATALOG_TEMP>.CreateInstanceDAL( oleDb ).GetModel( strWhere );

            if ( model != null )
            {
                model.COMP_RATE = rate;
                HIS.SYSTEM.Core.BindEntity<Model.NCMS_MATCH_CATALOG_TEMP>.CreateInstanceDAL( oleDb ).Update( strWhere, HIS.BLL.Tables.ncms_match_catalog_temp.COMP_RATE + oleDb.EuqalTo() + rate );
            }
        }
    }
    /// <summary>
    /// 自定义的匹配信息
    /// </summary>
    public struct MatchInfo
    {
        public string type;
        public string drug_alias;
        public string drug_form;
        public string drug_type;
        public string limit_desc;
        public string ncms_code;
        public double price1;
        public double price2;
        public double price3;
        public string specs;
        public string therapy_content;
        public string therapy_exclude;
        public string use_levle;
        public string hospital_code;

    }
}
