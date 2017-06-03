using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MediInsInterface_BLL.MediInsInterface.HygeiaSystem;
using System.Data;

namespace HIS.MediInsInterface_BLL.MediInsInterface.matchInterface
{
    public class matchHygeiaInterface:ImatchInterface
    {
        private string _DownLoadDrugContent_OperationId = "BIZC110118";
        private string _DownLoadItemContent_OperationId = "BIZC110118";
        private string _JudgeSingleContentMatch_OperationId = "";
        private string _UploadMatchContent_OperationId = "BIZC110201";
        private string _ResetMatchContent_OperationId = "";
        private string _DeleteMatchContent_OperationId = "BIZC110201";
        private string _DownLoadHospContent_OperationId = "BIZC110101";

        HygeiaDataSource datasource = null;

        public matchHygeiaInterface()
        {
            datasource = new HygeiaDataSource();
        }

    
        public System.Data.DataTable DownLoadDrugContent(System.Collections.Hashtable hashtable)
        {
            datasource.OperationId = _DownLoadDrugContent_OperationId;
            datasource.PutParamByName = HygeiaBaseData.Put_BIZC110118_DrugCountDic(null);
            if (datasource.Execute())
            {
                datasource.SetResultset("count");
                //取总记录条数
                string count = datasource.GetDataReslut("count");

                //取出所有数据集,因为它这个是采用分页形式
                hashtable = new System.Collections.Hashtable();
                hashtable.Add("count", count);
                datasource.PutParamByName = HygeiaBaseData.Put_BIZC110118_DrugDic(hashtable);
                if (datasource.Execute())
                {
                    datasource.OutDataSet = new DataSet();
                    HygeiaBaseData.Out_BIZC110118_DrugDT(datasource.OutDataSet);
                    DataSet ds = datasource.GetDataSet();
                    datasource.Complete();
                    return ds.Tables[0];
                }
            }
            return null;
        }

        public System.Data.DataTable DownLoadItemContent(System.Collections.Hashtable hashtable)
        {
            datasource.OperationId = _DownLoadItemContent_OperationId;
            datasource.PutParamByName = HygeiaBaseData.Put_BIZC110118_ItemCountDic(null);
            if (datasource.Execute())
            {
                datasource.SetResultset("count");
                //取总记录条数
                string count = datasource.GetDataReslut("count");

                //取出所有数据集,因为它这个是采用分页形式
                hashtable = new System.Collections.Hashtable();
                hashtable.Add("count", count);
                datasource.PutParamByName = HygeiaBaseData.Put_BIZC110118_ItemDic(hashtable);
                if (datasource.Execute())
                {
                    datasource.OutDataSet = new DataSet();
                    HygeiaBaseData.Out_BIZC110118_ItemDT(datasource.OutDataSet);
                    DataSet ds = datasource.GetDataSet();
                    datasource.Complete();
                    return ds.Tables[0];
                }
            }
            return null;
        }

        public string JudgeSingleContentMatch(System.Collections.Hashtable hashtable)
        {
            throw new NotImplementedException();
        }

        public string UploadMatchContent(System.Collections.Hashtable hashtable)
        {
            datasource.OperationId = _UploadMatchContent_OperationId;
            HygeiaBaseData.Put_BIZC110201DTAdd(datasource.PutRecByName, hashtable);
            if (datasource.Execute())
            {
                datasource.SetResultset("effectdetail");
                return datasource.GetDataReslut("serial_match");
            }
            return null;
        }

        public bool ResetMatchContent(System.Collections.Hashtable hashtable)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMatchContent(System.Collections.Hashtable hashtable)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable DownLoadHospContent(System.Collections.Hashtable hashtable)
        {
            throw new NotImplementedException();
        }

        

        public void Dispose()
        {
            datasource.Close();
        }

 
    }
}
