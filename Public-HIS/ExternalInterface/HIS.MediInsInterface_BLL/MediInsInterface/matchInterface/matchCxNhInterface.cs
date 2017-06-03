using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MediInsInterface_BLL.MediInsInterface.CxNhSystem;
using System.Data;

namespace HIS.MediInsInterface_BLL.MediInsInterface.matchInterface
{
    //[20100517.1.02]
    /// <summary>
    /// 匹配接口实现
    /// </summary>
    public class matchCxNhInterface : ImatchInterface
    {
        private string _DownLoadDrugContent_OperationId = "11007";
        private string _DownLoadItemContent_OperationId = "11001";
        private string _JudgeSingleContentMatch_OperationId = "11011";
        private string _UploadMatchContent_OperationId = "11006";
        private string _ResetMatchContent_OperationId = "11005";
        private string _DeleteMatchContent_OperationId = "11004";
        private string _DownLoadHospContent_OperationId = "11003";
        

        CxNhDataSource datasource = null;

        public matchCxNhInterface()
        {
            datasource = new CxNhDataSource();
        }

        #region ImatchInterface 成员
        //11007
        public DataTable DownLoadDrugContent(System.Collections.Hashtable hashtable)
        {
            //CxNhDataSource datasource = new CxNhDataSource();
            datasource.OperationId = _DownLoadDrugContent_OperationId;
            if (datasource.Execute())
            {
                datasource.OutDataSet = new DataSet();
                CxNhBaseData.Out_11007DT(datasource.OutDataSet);
                DataSet ds = datasource.GetDataSet();
                datasource.Complete();
                //this.dataGridView1.DataSource = ds.Tables[0];
                return ds.Tables[0];
            }
            return null;
        }
        //11001
        public DataTable DownLoadItemContent(System.Collections.Hashtable hashtable)
        {
            datasource.OperationId = _DownLoadItemContent_OperationId;
            if (datasource.Execute())
            {
                datasource.OutDataSet = new DataSet();
                CxNhBaseData.Out_11001DT(datasource.OutDataSet);
                DataSet ds = datasource.GetDataSet();
                datasource.Complete();
                return ds.Tables[0];
            }
            return null;
        }
        //11011
        public string JudgeSingleContentMatch(System.Collections.Hashtable hashtable)
        {
            datasource.OperationId = _JudgeSingleContentMatch_OperationId;
            datasource.PutParamByName = CxNhBaseData.Put_11011Dic(hashtable);
            if (datasource.Execute())
            {
                string flag = datasource.GetDataReslut("Flag");
                if (flag == "0")
                {
                    string Serial_match = datasource.GetDataReslut("Serial_match");
                    datasource.Complete();
                    return Serial_match;
                }
                else
                {
                    datasource.Complete();
                    return "-1";
                    //throw new Exception("上传匹配数据失败：" + datasource.GetErrorMessage());
                }
            }
            return null;
        }
        //11006
        public string UploadMatchContent(System.Collections.Hashtable hashtable)
        {
            string Serial_match=null;
            Serial_match= JudgeSingleContentMatch(hashtable);
            if (Serial_match == "-1")
            {
                datasource.OperationId = _UploadMatchContent_OperationId;
                datasource.PutParamByName = CxNhBaseData.Put_11006Dic(hashtable);
                if (datasource.Execute())
                {
                    string flag = datasource.GetDataReslut("Flag");
                    if (flag == "0")
                    {
                        Serial_match = datasource.GetDataReslut("Serial_match");
                        datasource.Complete();
                        return Serial_match;
                    }
                    else
                    {
                        datasource.Complete();
                        return "-1";
                        //throw new Exception("上传匹配数据失败：" + datasource.GetErrorMessage());
                    }
                }
            }
            return Serial_match;
        }
        //11005
        public bool ResetMatchContent(System.Collections.Hashtable hashtable)
        {
            datasource.OperationId = _ResetMatchContent_OperationId;
            datasource.PutParamByName = CxNhBaseData.Put_11005Dic(hashtable);
            if (datasource.Execute())
            {
                string flag = datasource.GetDataReslut("Flag");
                datasource.Complete();
                if (flag == "0")
                {
                    
                    return true;
                }
            }
            return false;
        }
        //11004
        public bool DeleteMatchContent(System.Collections.Hashtable hashtable)
        {
            datasource.OperationId = _DeleteMatchContent_OperationId;
            datasource.PutParamByName = CxNhBaseData.Put_11004Dic(hashtable);
            if (datasource.Execute())
            {
                string flag = datasource.GetDataReslut("Flag");
                datasource.Complete();
                if (flag == "0")
                {
                    return true;
                }
            }
            return false;
        }
        //11003
        public DataTable DownLoadHospContent(System.Collections.Hashtable hashtable)
        {
            datasource.OperationId = _DownLoadHospContent_OperationId;
            datasource.PutParamByName = CxNhBaseData.Put_11003Dic(hashtable);
            if (datasource.Execute())
            {
                datasource.OutDataSet = new DataSet();
                CxNhBaseData.Out_11003DT(datasource.OutDataSet);
                DataSet ds = datasource.GetDataSet();
                datasource.Complete();
                return ds.Tables[0];
            }
            return null;
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
