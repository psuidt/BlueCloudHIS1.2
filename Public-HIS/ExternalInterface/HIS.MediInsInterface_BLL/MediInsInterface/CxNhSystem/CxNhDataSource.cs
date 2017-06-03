using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace HIS.MediInsInterface_BLL.MediInsInterface.CxNhSystem
{
    //[20100517.1.01]
    public class CxNhDataSource
    {
        private bool IsOpenInterface;
        private bool IsComplete;

        private string _operationId;
        /// <summary>
        /// 业务号
        /// </summary>
        public string OperationId
        {
            get { return _operationId; }
            set { _operationId = value; }
        }

        private Dictionary<string, string> _putParamByName;
        /// <summary>
        /// 传入参数
        /// </summary>
        public Dictionary<string, string> PutParamByName
        {
            get { return _putParamByName; }
            set { _putParamByName = value; }
        }

        private DataSet _putRecByName;
        /// <summary>
        /// 传入数据集
        /// </summary>
        public DataSet PutRecByName
        {
            get { return _putRecByName; }
            set { _putRecByName = value; }
        }

        private DataSet _outDataSet;
        /// <summary>
        /// 传出数据集
        /// </summary>
        public DataSet OutDataSet
        {
            get { return _outDataSet; }
            set { _outDataSet = value; }
        }

        public CxNhDataSource()
        {
            Open();
            IsComplete = true;
        }
        /// <summary>
        /// 创建连接
        /// </summary>
        public void Open()
        {
            int index = CxNhInterface.NewInterface();
            if (index != 0)
            {
                throw new Exception("创建连接出错：" + CxNhInterface.GetMessage());
            }
            IsOpenInterface = true;
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if (IsOpenInterface == true)
            {
                int index = CxNhInterface.DestoryInterface();
                if (index != 0)
                {
                    //throw new Exception("关闭连接出错：" + CxNhInterface.GetMessage());
                }
                IsOpenInterface = false;
            }
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        public bool Execute()
        {
            if (IsOpenInterface == false)
            {
                Open();
            }

            if(OperationId==null)
                throw new Exception("请先给业务号赋值！");
            if(IsComplete==false)
                throw new Exception("当前业务并没有完成，不允许重新开始业务！");

            int MaxRecNO = PutRecByName == null ? 0 : PutRecByName.Tables.Count;
            int ParamNum = PutParamByName == null ? 0 : PutParamByName.Count;
            int index;
            
            //开始
            index = CxNhInterface.Start(OperationId, MaxRecNO);
            Console.Out.WriteLine("开始业务号："+OperationId);
            if (index < 0)
            {
                throw new Exception("开始调用接口："+CxNhInterface.GetMessage());
            }
            IsComplete = false;
            //传入参数
            if (ParamNum > 0)
            {
                //Console.Out.WriteLine(PutParamByName.GetEnumerator());
                for (int i = 0; i < ParamNum; i++)
                {
                    index = CxNhInterface.PutParamByName(PutParamByName.ToList()[i].Key, PutParamByName.ToList()[i].Value);
                    Console.Out.WriteLine("传入参数：" + PutParamByName.ToList()[i].Key + "   " + PutParamByName.ToList()[i].Value);
                    if (index < 0)
                    {
                        throw new Exception("传入参数："+CxNhInterface.GetMessage());
                    }
                }
            }
            //传入数据集
            if (MaxRecNO > 0)
            {
                Console.Out.WriteLine("传入数据集："+PutRecByName.GetXml());
                //表
                for (int i = 0; i < MaxRecNO; i++)
                {
                    //行
                    for (int j = 0; j < PutRecByName.Tables[i].Rows.Count; j++)
                    {
                        //列
                        for (int k = 0; k < PutRecByName.Tables[i].Columns.Count; k++)
                        {
                            string value=PutRecByName.Tables[i].Rows[j][k]==DBNull.Value?"":PutRecByName.Tables[i].Rows[j][k].ToString();
                            index = CxNhInterface.PutRecByName(i + 1, j + 1, PutRecByName.Tables[i].Columns[k].ColumnName, value);
                            if (index < 0)
                            {
                                throw new Exception("传入数据集：" + CxNhInterface.GetMessage());
                            }
                        }
                    }
                }
            }
            //运行
            index = CxNhInterface.Run();
            if (index < 0)
            {
                throw new Exception("运行失败：" + CxNhInterface.GetMessage());
            }
            //获取结果
            return true;
        }
        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="ParamByName">结果的名称</param>
        /// <returns></returns>
        public string GetDataReslut(string ParamByName)
        {
            string reslut = CxNhInterface.GetParamByName(ParamByName);
            Console.Out.WriteLine(reslut);
            return reslut;
        }
        /// <summary>
        /// 得到结果集
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet()
        {
            //得到每个记录集的行数
            int[] RowCounts = new int[OutDataSet.Tables.Count];
            for (int i = 0; i < RowCounts.Length; i++)
            {
                RowCounts[i] = CxNhInterface.GetRecCount(i+1);
                if (RowCounts[i] < 0)
                {
                    throw new Exception("获取结果集失败：" + CxNhInterface.GetMessage());
                }
            }
            //记录集
            for (int rec=0;rec< RowCounts.Length ;rec++)
            {
                //行
                for (int _row = 0; _row < RowCounts[rec]; _row++)
                {
                    //新增一行
                    DataRow drs= OutDataSet.Tables[rec].NewRow();
                    //列
                    for (int _col = 0; _col < OutDataSet.Tables[rec].Columns.Count; _col++)
                    {
                        string value = CxNhInterface.GetRecByName(_row + 1, OutDataSet.Tables[rec].Columns[_col].ColumnName, rec + 1);
                        //赋值
                        drs[_col] = value;
                    }
                    //加入结果集
                    OutDataSet.Tables[rec].Rows.Add(drs);
                }
            }

            return OutDataSet;

        }
        /// <summary>
        /// 返回错误信息
        /// </summary>
        /// <returns></returns>
        public string GetErrorMessage()
        {
            return CxNhInterface.GetMessage();
        }
        /// <summary>
        /// 业务完成
        /// </summary>
        public void Complete(ref string err)
        {
            IsComplete = true;
            Clear();
            //Close();
            try
            {
                err = GetDataReslut("message");
                if (err == null || err == "")
                {
                    err = GetErrorMessage();
                }
            }
            catch { }
            if (err != "")
                err += "\n";
        }

        public void Complete()
        {
            IsComplete = true;
            Clear();
            //Close();
        }
        /// <summary>
        /// 清除属性数据
        /// </summary>
        public void Clear()
        {
            OperationId = null;
            PutParamByName = null;
            PutRecByName = null;
            OutDataSet = null;
        }
    }
}
