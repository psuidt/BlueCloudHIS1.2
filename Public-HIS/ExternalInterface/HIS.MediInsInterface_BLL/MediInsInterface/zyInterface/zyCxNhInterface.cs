using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.ZY_BLL.DataModel;
using HIS.MediInsInterface_BLL.MediInsInterface.CxNhSystem;
using System.Collections;

namespace HIS.MediInsInterface_BLL.MediInsInterface.zyInterface
{
    //[20100518.1.05]
    /// <summary>
    /// 长信农合接口
    /// </summary>
    public class zyCxNhInterface : IzyInterface
    {
        private object _hospitalInfo;

        private string JOIN_AREA_CODE = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.JOIN_AREA_CODE;
        private string JOIN_AREA_NAME = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.JOIN_AREA_NAME;
        private string MED_ORG_CODE = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.MED_ORG_CODE;

        private string _GetPatientInfo_OperationId = "00015";
        private string _GetrecoupType_OperationId = "00021";
        private string _GetYwID_OperationId = "00011";
        private string _Register_OperationId = "01201";
        private string _AlterRegister_OperationId = "01202";
        private string _CancelRegister_OperationId = "01301";

        private string _UploadzyPatFee_OperationId = "01204";
        private string _Charge_OperationId = "01216";
        private string _IsRecoup_OperationId = "00020";
        private string _CancelCharge_OperationId = "01217";
        private string _DownloadzyPatFee_OperationId = "01219";

        CxNhDataSource datasource = null;

        private string _message;

        public string ErrMessage
        {
            get { return _message; }
            set { _message = value; }
        }

        public zyCxNhInterface()
        {
            datasource = new CxNhDataSource();
        }

        #region IzyInterface 成员

        public object HospitalInfo
        {
            get
            {
                object[] objs = new object[2];
                try
                {
                    datasource.OperationId = _GetrecoupType_OperationId;
                    datasource.PutParamByName = CxNhBaseData.Put_00021Dic(null);
                    if (datasource.Execute())
                    {
                        datasource.OutDataSet = new DataSet();
                        CxNhBaseData.Out_00021DT(datasource.OutDataSet);
                        DataSet ds = datasource.GetDataSet();
                        datasource.Complete(ref _message);

                        objs[0] = ds.Tables[0];
                    }

                    datasource.OperationId = _GetYwID_OperationId;
                    datasource.PutParamByName = CxNhBaseData.Put_00011Dic(null);
                    if (datasource.Execute())
                    {
                        objs[1] = datasource.GetDataReslut("YWID");
                        datasource.Complete(ref _message);
                    }
                }
                catch (Exception err)
                {
                    datasource.Complete(ref _message);
                    throw err;
                }
                _hospitalInfo = objs;
                return _hospitalInfo;
            }
            set
            {
                _hospitalInfo = value;
            }
        }

        public object GetPatientInfo(System.Collections.Hashtable hashtable)
        {
            try
            {
                datasource.OperationId = _GetPatientInfo_OperationId;
                datasource.PutParamByName = CxNhBaseData.Put_00015Dic(hashtable);
                if (datasource.Execute())
                {
                    datasource.OutDataSet = new DataSet();
                    CxNhBaseData.Out_00015DT(datasource.OutDataSet);
                    DataSet ds = datasource.GetDataSet();
                    datasource.Complete(ref _message);
                    return ds.Tables[0];
                }
                return null;
            }
            catch (Exception err)
            {
                datasource.Complete(ref _message);
                throw err;
            }
        }

        public object Register(System.Collections.Hashtable hashtable)
        {
            try
            {
                datasource.OperationId = _Register_OperationId;
                datasource.PutParamByName = CxNhBaseData.Put_01201Dic(hashtable);
                if (datasource.Execute())
                {
                    string flag = datasource.GetDataReslut("Flag");
                    if (flag == "0")
                    {
                        string Id = datasource.GetDataReslut("Id");
                        datasource.Complete(ref _message);
                        return Id;
                    }
                    else
                    {
                        datasource.Complete(ref _message);
                        throw new Exception("入院登记失败！" + datasource.GetDataReslut("Message"));
                    }
                }
                return null;
            }
            catch(Exception err)
            {
                datasource.Complete(ref _message);
                throw new Exception(err.Message);
            }
        }

        public bool AlterRegister(System.Collections.Hashtable hashtable)
        {
            try
            {
                datasource.OperationId = _AlterRegister_OperationId;
                datasource.PutParamByName = CxNhBaseData.Put_01202Dic(hashtable);
                if (datasource.Execute())
                {
                    string flag = datasource.GetDataReslut("Flag");
                    if (flag == "0")
                    {
                        datasource.Complete(ref _message);
                        return true;
                    }
                    else
                    {
                        datasource.Complete(ref _message);
                    }
                }
                return false;
            }
            catch (Exception err)
            {
                datasource.Complete(ref _message);
                throw err;
            }
        }

        public bool CancelRegister(System.Collections.Hashtable hashtable)
        {
            try
            {
                datasource.OperationId = _CancelRegister_OperationId;
                datasource.PutParamByName = CxNhBaseData.Put_01301Dic(hashtable);
                if (datasource.Execute())
                {
                    string flag = datasource.GetDataReslut("Flag");
                    if (flag == "0")
                    {
                        datasource.Complete(ref _message);
                        return true;
                    }
                    else
                    {
                        datasource.Complete(ref _message);
                    }
                }
                return false;
            }
            catch (Exception err)
            {
                datasource.Complete(ref _message);
                throw err;
            }
        }

        public object PreviewCharge(System.Collections.Hashtable hashtable)
        {
            throw new NotImplementedException();
        }

        public object Charge(System.Collections.Hashtable hashtable)
        {
            try
            {
                datasource.OperationId = _Charge_OperationId;
                datasource.PutParamByName = CxNhBaseData.Put_01216Dic(hashtable);
                if (datasource.Execute())
                {
                    datasource.OutDataSet = new DataSet();
                    CxNhBaseData.Out_01216DT1(datasource.OutDataSet);
                    CxNhBaseData.Out_01216DT2(datasource.OutDataSet);
                    CxNhBaseData.Out_01216DT3(datasource.OutDataSet);
                    DataSet ds = datasource.GetDataSet();
                    datasource.Complete(ref _message);
                    return ds;
                }
                return null;
            }
            catch (Exception err)
            {
                datasource.Complete(ref _message);
                throw err;
            }
        }

        private int IsRecoup(System.Collections.Hashtable hashtable)
        {
            try
            {
                datasource.OperationId = _IsRecoup_OperationId;
                datasource.PutParamByName = CxNhBaseData.Put_00020Dic(hashtable);
                if (datasource.Execute())
                {
                    string flag = datasource.GetDataReslut("Flag");
                    if (flag == "0")
                    {
                        string bcbz = datasource.GetDataReslut("BCBZ");
                        datasource.Complete(ref _message);
                        return Convert.ToInt32(bcbz.Trim());
                    }
                    else
                    {
                        datasource.Complete(ref _message);
                    }
                }
                return 0;
            }
            catch (Exception err)
            {
                datasource.Complete(ref _message);
                throw err;
            }
        }

        public bool CancelCharge(System.Collections.Hashtable hashtable)
        {
            try
            {
                if (IsRecoup(hashtable) == 2 || IsRecoup(hashtable) == 1)
                {
                    datasource.OperationId = _CancelCharge_OperationId;
                    datasource.PutParamByName = CxNhBaseData.Put_01217Dic(hashtable);
                    if (datasource.Execute())
                    {
                        string flag = datasource.GetDataReslut("Flag");
                        if (flag == "0")
                        {
                            datasource.Complete(ref _message);
                            return true;
                        }
                        else
                        {
                            datasource.Complete(ref _message);
                        }
                    }
                }
                return false;
            }
            catch (Exception err)
            {
                datasource.Complete();
                throw err;
            }
        }

        public bool UploadzyPatFee(System.Collections.Hashtable hashtable)
        {
            try
            {
                datasource.OperationId = _UploadzyPatFee_OperationId;
                datasource.PutParamByName = CxNhBaseData.Put_01204Dic(hashtable);
                datasource.PutRecByName = new DataSet();
                CxNhBaseData.Put_01204DTywxmmx(datasource.PutRecByName, hashtable);
                CxNhBaseData.Put_01204DTyzcfmx(datasource.PutRecByName, hashtable);

                if (datasource.Execute())
                {
                    string flag = datasource.GetDataReslut("Flag");
                    if (flag == "0")
                    {
                        datasource.Complete(ref _message);
                        return true;
                    }
                    else
                    {
                        datasource.Complete(ref _message);
                    }
                }
                return false;
            }
            catch(Exception err)
            {
                datasource.Complete(ref _message);
                //_message += err.Message;
                throw err;
            }
        }

        public object DownloadzyPatFee(System.Collections.Hashtable hashtable)
        {
            try
            {
                datasource.OperationId = _DownloadzyPatFee_OperationId;
                datasource.PutParamByName = CxNhBaseData.Put_01219Dic(hashtable);
                if (datasource.Execute())
                {
                    datasource.OutDataSet = new DataSet();
                    CxNhBaseData.Out_01219DT(datasource.OutDataSet);
                    DataSet ds = datasource.GetDataSet();
                    datasource.Complete(ref _message);
                    return ds.Tables[0];
                }
                return null;
            }
            catch (Exception err)
            {
                datasource.Complete(ref _message);
                throw err;
            }
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            datasource.Close();
        }

        #endregion
    }
}
