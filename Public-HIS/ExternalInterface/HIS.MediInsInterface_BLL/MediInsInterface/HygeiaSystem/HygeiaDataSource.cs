using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.MediInsInterface_BLL.MediInsInterface.HygeiaSystem
{
    public class HygeiaDataSource
    {
        private int hInterface;
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

        public HygeiaDataSource()
        {
            Open();
            IsComplete = true;
        }

        public void Open()
        {
            //建立并初始化接口
            hInterface = Hygeia.NewInterfaceWithInit(HygeiaBaseData.Addr, HygeiaBaseData.Port, HygeiaBaseData.Servlet);

            if (hInterface <= 0)
            {
                throw new Exception("初始化接口错误！");
            }
            IsOpenInterface = true;
        }
        /// <summary>
        /// 释放接口
        /// </summary>
        public void Close()
        {
            if (IsOpenInterface == true)
            {
                int index = Hygeia.DestoryInterface(hInterface);
                IsOpenInterface = false;
            }
        }

        public bool Execute()
        {
            if (IsOpenInterface == false)
            {
                Open();
            }
            if (OperationId == null)
                throw new Exception("请先给业务号赋值！");
            if (IsComplete == false)
                throw new Exception("当前业务并没有完成，不允许重新开始业务！");

            int index = 0;
            int ParamNum = PutParamByName == null ? 0 : PutParamByName.Count;
            int MaxRecNO = PutRecByName == null ? 0 : PutRecByName.Tables.Count;

            index = Hygeia.SetDebug(hInterface, HygeiaBaseData.DebugFlag, HygeiaBaseData.AppPath);

            int ret = Hygeia.Start(hInterface, OperationId);
            Console.Out.WriteLine("开始业务号：" + OperationId);
            if (ret < 0)
            {
                throw new Exception("开始调用接口：" + GetErrorMessage());
            }
            else
            {

                index = Hygeia.Putcol(hInterface, "oper_centerid", HygeiaBaseData.Center_Id);
                index = Hygeia.Putcol(hInterface, "oper_hospitalid", HygeiaBaseData.HospId);
                index = Hygeia.Putcol(hInterface, "oper_staffid", "000");
            }

            //传入参数
            if (ParamNum > 0)
            {
                //Console.Out.WriteLine(PutParamByName.GetEnumerator());
                for (int i = 0; i < ParamNum; i++)
                {
                    index = Hygeia.Putcol(hInterface, PutParamByName.ToList()[i].Key, PutParamByName.ToList()[i].Value);
                    Console.Out.WriteLine("传入参数：" + PutParamByName.ToList()[i].Key + "   " + PutParamByName.ToList()[i].Value);
                    if (index < 0)
                    {
                        throw new Exception("传入参数失败：" + GetErrorMessage());
                    }
                }
            }

            //传入数据集
            if (MaxRecNO > 0)
            {
                Console.Out.WriteLine("传入数据集：" + PutRecByName.GetXml());
                //表
                for (int i = 0; i < MaxRecNO; i++)
                {
                    //设置记录集
                    index = SetResultset(PutRecByName.Tables[i].TableName);
                    //行
                    for (int j = 0; j < PutRecByName.Tables[i].Rows.Count; j++)
                    {
                        //列
                        for (int k = 0; k < PutRecByName.Tables[i].Columns.Count; k++)
                        {
                            string value = PutRecByName.Tables[i].Rows[j][k] == DBNull.Value ? "" : PutRecByName.Tables[i].Rows[j][k].ToString();
                            index = Hygeia.Put(hInterface, j + 1, PutRecByName.Tables[i].Columns[k].ColumnName, value);
                            if (index < 0)
                            {
                                throw new Exception("传入数据集：" + GetErrorMessage());
                            }
                        }
                    }
                }
            }

            index = Hygeia.Run(hInterface);

            if (index < 0)
            {
                throw new Exception("运行失败：" + GetErrorMessage());
            }
            //获取结果
            return true;
        }     

        public string GetDataReslut(string ParamByName)
        {
            StringBuilder para = new StringBuilder(1024);
            Hygeia.GetbyName(hInterface, ParamByName, para);
            return para.ToString();
        }

        public DataSet GetDataSet()
        {
            int index;
            for (int i = 0; i < OutDataSet.Tables.Count; i++)
            {
                //设置记录集
                index = SetResultset(OutDataSet.Tables[i].TableName);
                if (index > 0)
                {
                    index = Hygeia.FirstRow( hInterface );
                    if (index > 0)
                    {
                        //新增一行
                        DataRow drs = OutDataSet.Tables[i].NewRow();
                        //列
                        for (int _col = 0; _col < OutDataSet.Tables[i].Columns.Count; _col++)
                        {
                            StringBuilder value = new StringBuilder(1024);
                            index = Hygeia.GetbyName(hInterface, OutDataSet.Tables[i].Columns[_col].ColumnName, value);
                            //赋值
                            drs[_col] = value.ToString();
                        }
                        //加入结果集
                        OutDataSet.Tables[i].Rows.Add(drs);
                    }

                    while (Hygeia.NextRow(hInterface) > 0)
                    {
                        //新增一行
                        DataRow drs = OutDataSet.Tables[i].NewRow();
                        //列
                        for (int _col = 0; _col < OutDataSet.Tables[i].Columns.Count; _col++)
                        {
                            StringBuilder value = new StringBuilder(1024);
                            index = Hygeia.GetbyName(hInterface, OutDataSet.Tables[i].Columns[_col].ColumnName, value);
                            //赋值
                            drs[_col] = value.ToString();
                        }
                        //加入结果集
                        OutDataSet.Tables[i].Rows.Add(drs);
                    }
                }
            }

            return OutDataSet;
        }

        public int SetResultset(string result_name)
        {
            StringBuilder resultName = new StringBuilder(result_name);
            int index = Hygeia.SetResultset(hInterface, resultName);
            if (index < 0)
            {
                throw new Exception("设置记录集：" + GetErrorMessage());
            }
            return index;
        }
        /// <summary>
        /// 返回错误信息
        /// </summary>
        /// <returns></returns>
        public string GetErrorMessage()
        {
            StringBuilder errMsg = new StringBuilder(1024);
            Hygeia.GetMessage(hInterface, errMsg);
            return errMsg.ToString();
        }
        public void Complete()
        {
            IsComplete = true;
            Clear();
        }
        /// <summary>
        /// 清除属性数据
        /// </summary>
        private void Clear()
        {
            OperationId = null;
            PutParamByName = null;
            PutRecByName = null;
            OutDataSet = null;
        }

    }
}
