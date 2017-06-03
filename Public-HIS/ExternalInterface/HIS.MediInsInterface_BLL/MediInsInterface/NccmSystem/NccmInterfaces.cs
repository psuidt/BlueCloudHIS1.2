using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem.Core;


namespace HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem
{
    /// <summary>
    /// 调用农合接口类
    /// </summary>
    public class NccmInterfaces
    {
        private const string sKey = "12345678";
        private static bool Des = false;
        private static bool Gzip = false;

        private static hisInterface ncmsInterface = new hisInterface();
        /// <summary>
        /// 下载医院信息
        /// </summary>
        /// <returns></returns>
        public static HospitalInfo DownLoadHospitalInfo( HisData hisData )
        {
                       
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject( hisData );

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.downLoadHospitalInfo( recieveMsg );
                //先解密
                if ( retMsg.DES == true )
                    retMsg.dataContent = NccmFunction.decrypt( retMsg.dataContent, sKey );
                //再解压
                if ( retMsg.GZipCompress == true )
                    retMsg.dataContent = NccmFunction.gZipDeCompress( retMsg.dataContent );

                Type type = typeof( DownLoadHospitalInfoResult );
                //反序列化对象
                DownLoadHospitalInfoResult info = (DownLoadHospitalInfoResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject( retMsg.dataContent, type );
                if ( info.resultId == false )
                    throw new Exception( info.resultString );
                
                HospitalInfo hsInfo = info.hospitalInfo;

                return hsInfo;

            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 下载药品目录
        /// </summary>
        /// <returns></returns>
        public static DownLoadCenterItemResult DownLoadDrugListInfo( DownLoadItem hisData )
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject( hisData );

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.downLoadCenterItem( recieveMsg );
                if ( retMsg.DES )
                    retMsg.dataContent = NccmFunction.decrypt( retMsg.dataContent, sKey );
                if ( retMsg.GZipCompress )
                    retMsg.dataContent = NccmFunction.gZipDeCompress( retMsg.dataContent );

                Type type = typeof( DownLoadCenterItemResult );
                DownLoadCenterItemResult result = (DownLoadCenterItemResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject( retMsg.dataContent, type );
                
                return result;
            }
            catch ( Exception err )
            {
                throw err;
            }

        }
        /// <summary>
        /// 下载诊疗目录
        /// </summary>
        /// <returns></returns>
        public static DownLoadCenterItemResult DownLoadTherapyListInfo( DownLoadItem hisData )
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject( hisData );

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.downLoadCenterItem( recieveMsg );
                if ( retMsg.DES )
                    retMsg.dataContent = NccmFunction.decrypt( retMsg.dataContent, sKey );
                if ( retMsg.GZipCompress )
                    retMsg.dataContent = NccmFunction.gZipDeCompress( retMsg.dataContent );

                Type type = typeof( DownLoadCenterItemResult );
                DownLoadCenterItemResult result = (DownLoadCenterItemResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject( retMsg.dataContent, type );
                return result;
            }
            catch ( Exception err )
            {
                throw err;
            }

        }
        /// <summary>
        /// 参合病人信息查询
        /// </summary>
        public static FindPatientCompInfoResult FindPatientCompInfo( FindPatientCompInfo hisData )
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject( hisData );

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.findPatientCompInfo( recieveMsg );
                if ( retMsg.DES )
                    retMsg.dataContent = NccmFunction.decrypt( retMsg.dataContent, sKey );
                if ( retMsg.GZipCompress )
                    retMsg.dataContent = NccmFunction.gZipDeCompress( retMsg.dataContent );

                Type type = typeof( FindPatientCompInfoResult );
                FindPatientCompInfoResult result = (FindPatientCompInfoResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject( retMsg.dataContent, type );
                
                return result;
            }
            catch(Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 下载指定病人的所有费用明细数据
        /// </summary>
        public static RecieveDetailFeeResult DownLoadDetailFee(DownLoadItem hisData)
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject(hisData);

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.downLoadDetailFee(recieveMsg);
                if (retMsg.DES)
                    retMsg.dataContent = NccmFunction.decrypt(retMsg.dataContent, sKey);
                if (retMsg.GZipCompress)
                    retMsg.dataContent = NccmFunction.gZipDeCompress(retMsg.dataContent);

                Type type = typeof(RecieveDetailFeeResult);
                RecieveDetailFeeResult result = (RecieveDetailFeeResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject(retMsg.dataContent, type);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 下载医院的匹配关系
        /// </summary>
        /// <param name="hisData"></param>
        /// <returns></returns>
        public static RecieveHospitalMatchInfoResult DownLoadMatchInfo( DownLoadItem hisData )
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject( hisData );

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.downLoadMatchInfo( recieveMsg );
                if ( retMsg.DES )
                    retMsg.dataContent = NccmFunction.decrypt( retMsg.dataContent, sKey );
                if ( retMsg.GZipCompress )
                    retMsg.dataContent = NccmFunction.gZipDeCompress( retMsg.dataContent );

                Type type = typeof( RecieveHospitalMatchInfoResult );
                RecieveHospitalMatchInfoResult result = (RecieveHospitalMatchInfoResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject( retMsg.dataContent, type );

                return result ;
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 上传匹配信息
        /// </summary>
        /// <param name="hisData"></param>
        /// <param name="upLoadfaildItems">返回的上传失败的记录</param>
        /// <param name="strMsg">返回的消息</param>
        /// <returns></returns>
        public static bool UploadMatchInfo(RecieveHospitalMatchInfo hisData ,out ItemMatchInfo[] upLoadfaildItems ,out string strMsg)
        {
            upLoadfaildItems = null;
            strMsg = "";
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject( hisData );

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.recieveHospitalMatchInfo( recieveMsg );
                if ( retMsg.DES )
                    retMsg.dataContent = NccmFunction.decrypt( retMsg.dataContent, sKey );
                if ( retMsg.GZipCompress )
                    retMsg.dataContent = NccmFunction.gZipDeCompress( retMsg.dataContent );

                Type type = typeof( RecieveHospitalMatchInfoResult );
                RecieveHospitalMatchInfoResult result = (RecieveHospitalMatchInfoResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject( retMsg.dataContent, type );
                if ( result.resultId )
                {
                    upLoadfaildItems = result.itemMatchInfo;
                    strMsg = result.resultString;
                    return true;
                }
                else
                    throw new Exception( result.resultString );
                
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
       
        /// <summary>
        /// 上传病人费用明细(住院和门诊)
        /// </summary>
        /// <param name="hisData"></param>
        /// <returns></returns>
        public static FeeDetail[] UploadPatientFeeDetail( BudgetFee hisData )
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject( hisData );

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.recieveDetailFee( recieveMsg );
                if ( retMsg.DES )
                    retMsg.dataContent = NccmFunction.decrypt( retMsg.dataContent, sKey );
                if ( retMsg.GZipCompress )
                    retMsg.dataContent = NccmFunction.gZipDeCompress( retMsg.dataContent );

                Type type = typeof( RecieveDetailFeeResult );
                RecieveDetailFeeResult result = (RecieveDetailFeeResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject( retMsg.dataContent, type );
                if ( result.resultId )
                    return result.feeDetail;
                else
                    throw new Exception( result.resultString );

            }
            catch ( Exception err )
            {
                throw err;
            }
            throw new Exception( "" );
        }
        /// <summary>
        /// 门诊预算返回CompData类数组
        /// </summary>
        /// <param name="hisData"></param>
        /// <returns></returns>
        public static CompData[] OutPatientBudegt( PatientComp hisData )
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject( hisData );

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.budgetFee( recieveMsg );
                if ( retMsg.DES )
                    retMsg.dataContent = NccmFunction.decrypt( retMsg.dataContent, sKey );
                if ( retMsg.GZipCompress )
                    retMsg.dataContent = NccmFunction.gZipDeCompress( retMsg.dataContent );

                Type type = typeof( CompResult );
                CompResult result = (CompResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject( retMsg.dataContent, type );
                if ( result.resultId )
                    return result.compData;
                else
                    throw new Exception( result.resultString );

            }
            catch ( Exception err )
            {
                throw err;
            }
           
        }
        /// <summary>
        /// 正式结算
        /// </summary>
        /// <returns></returns>
        public static CompData[] OutPatientCharge( PatientComp hisData )
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject( hisData );

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.patientComp( recieveMsg );
                if ( retMsg.DES )
                    retMsg.dataContent = NccmFunction.decrypt( retMsg.dataContent, sKey );
                if ( retMsg.GZipCompress )
                    retMsg.dataContent = NccmFunction.gZipDeCompress( retMsg.dataContent );

                Type type = typeof( CompResult );
                CompResult result = (CompResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject( retMsg.dataContent, type );
                if ( result.resultId )
                    return result.compData;
                else
                    throw new Exception( result.resultString );

            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 门诊退费
        /// </summary>
        /// <param name="hisData"></param>
        /// <returns></returns>
        public static bool OutPatientCancelCharge(CanceDetail hisData)
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject( hisData );

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.canceDetailFee( recieveMsg );
                if ( retMsg.DES )
                    retMsg.dataContent = NccmFunction.decrypt( retMsg.dataContent, sKey );
                if ( retMsg.GZipCompress )
                    retMsg.dataContent = NccmFunction.gZipDeCompress( retMsg.dataContent );
                return retMsg.success;
                //Type type = typeof( NcmsResult );
                //NcmsResult result = (NcmsResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject( retMsg.dataContent, type );
                //if ( result.resultId )
                //    return result;
                //else
                //    throw new Exception( result.resultString );

            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 临时用。。
        /// </summary>
        private static void temp_trans_fee()
        {
            BudgetFee hisData = new BudgetFee();
            JoinArea joinArea = new JoinArea();
            joinArea.code = "430121" ;
            joinArea.name = "长沙县" ;

            DataType dataType = new DataType();
            dataType.dataTypeName = "门诊数据" ;
            dataType.dataTypeValue = "2" ;

            ZyPatBaseData zyPat = new ZyPatBaseData();
            zyPat.idCard = "440100199707010033" ;
            zyPat.person_code = "430121112001001000101" ;
            zyPat.hisID = "200904080001" ;
            zyPat.area_id = "430121" ;
            zyPat.medorg_code = "400866951" ;

            FeeDetail feeDetail = new FeeDetail();
            feeDetail.his_billno = "" ;
            feeDetail.item_sn = "123523";
            feeDetail.item_code = "112010702110105";
            feeDetail.item_class = "1";
            feeDetail.item_equal = "0";
            feeDetail.item_name = "青霉素";
            feeDetail.item_use_time = "2009-4-1";
            feeDetail.amount = 12.00;
            feeDetail.drugform = "针剂";
            feeDetail.doctorTitle = "232";
            feeDetail.doctor = "刘医生";
            feeDetail.money = 24.00 ;
            feeDetail.price = 2.00 ;
            feeDetail.center_item_code = "0101010605110201";
            feeDetail.specs = "1.0g*24支";
            feeDetail.unit = "支" ;

            FeeDetail[] detailList = new FeeDetail[1];
            detailList[0] = feeDetail;
            hisData.zyPat = zyPat ;
            hisData.feeDetail = detailList ;
            hisData.uploadorg = "400866951" ;
            hisData.dataType = dataType ;
            hisData.joinArea = joinArea ;
        }
        /// <summary>
        /// 住院病人入院登记
        /// </summary>
        /// <param name="ps">病人信息</param>
        /// <returns></returns>
        public static PatientSignInfo InpatientRegister(PatientSign ps)
        {

            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject(ps);

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.patientSign(recieveMsg);
                if (retMsg.DES)
                    retMsg.dataContent = NccmFunction.decrypt(retMsg.dataContent, sKey);
                if (retMsg.GZipCompress)
                    retMsg.dataContent = NccmFunction.gZipDeCompress(retMsg.dataContent);
                Type type = typeof(PatientSignInfo);
                PatientSignInfo result = (PatientSignInfo)Newtonsoft.Json.JavaScriptConvert.DeserializeObject(retMsg.dataContent, type);
                return result;
            }
            catch (Exception err)
            {
                throw new Exception(retMsg.errMsg);
            }
        }
        /// <summary>
        /// 住院病人费用上传
        /// </summary>
        public static RecieveDetailFeeResult UploadZYPatFee(BudgetFee hisData)
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject(hisData);

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.recieveDetailFee(recieveMsg);
                if (retMsg.DES)
                    retMsg.dataContent = NccmFunction.decrypt(retMsg.dataContent, sKey);
                if (retMsg.GZipCompress)
                    retMsg.dataContent = NccmFunction.gZipDeCompress(retMsg.dataContent);
                Type type = typeof(RecieveDetailFeeResult);
                RecieveDetailFeeResult result = (RecieveDetailFeeResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject(retMsg.dataContent, type);
                return result;

            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 住院预算
        /// </summary>
        /// <param name="hisData"></param>
        /// <returns></returns>
        public static CompResult OutZYPatientBudegt(PatientComp hisData)
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject(hisData);

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.budgetFee(recieveMsg);
                if (retMsg.DES)
                    retMsg.dataContent = NccmFunction.decrypt(retMsg.dataContent, sKey);
                if (retMsg.GZipCompress)
                    retMsg.dataContent = NccmFunction.gZipDeCompress(retMsg.dataContent);

                Type type = typeof(CompResult);
                CompResult result = (CompResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject(retMsg.dataContent, type);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }

        }
        /// <summary>
        /// 住院正式结算
        /// </summary>
        /// <returns></returns>
        public static CompResult OutZYPatientCharge(PatientComp hisData)
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject(hisData);

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.patientComp(recieveMsg);
                if (retMsg.DES)
                    retMsg.dataContent = NccmFunction.decrypt(retMsg.dataContent, sKey);
                if (retMsg.GZipCompress)
                    retMsg.dataContent = NccmFunction.gZipDeCompress(retMsg.dataContent);

                Type type = typeof(CompResult);
                CompResult result = (CompResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject(retMsg.dataContent, type);
                return result;

            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 取消出院结算（中途结算）
        /// </summary>
        public static NcmsResult CanOutPatZYCharge(BudgetFee hisData)
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject(hisData);

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.canceInPatientComp(recieveMsg);
                if (retMsg.DES)
                    retMsg.dataContent = NccmFunction.decrypt(retMsg.dataContent, sKey);
                if (retMsg.GZipCompress)
                    retMsg.dataContent = NccmFunction.gZipDeCompress(retMsg.dataContent);
                Type type = typeof(NcmsResult);
                NcmsResult result = (NcmsResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject(retMsg.dataContent, type);
                return result;

            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 住院病人取消入院（不包括已结算的病人）
        /// </summary>
        public static NcmsResult CanInpatientRegister(PatBaseInfo hisData)
        {
            string strParameter = Newtonsoft.Json.JavaScriptConvert.SerializeObject(hisData);

            Message recieveMsg = new Message();
            recieveMsg.DES = false;
            recieveMsg.GZipCompress = false;
            recieveMsg.dataContent = strParameter;

            Message retMsg = new Message();
            try
            {
                retMsg = ncmsInterface.cancePatientSign(recieveMsg);
                if (retMsg.DES)
                    retMsg.dataContent = NccmFunction.decrypt(retMsg.dataContent, sKey);
                if (retMsg.GZipCompress)
                    retMsg.dataContent = NccmFunction.gZipDeCompress(retMsg.dataContent);
                Type type = typeof(NcmsResult);
                NcmsResult result = (NcmsResult)Newtonsoft.Json.JavaScriptConvert.DeserializeObject(retMsg.dataContent, type);
                return result;
            }
            catch 
            {
                throw new Exception(retMsg.errMsg);
            }
        }
    }
}
