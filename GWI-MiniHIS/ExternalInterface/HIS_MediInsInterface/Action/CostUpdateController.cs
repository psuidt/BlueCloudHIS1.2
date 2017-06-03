using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using System.Collections;
using HIS.MediInsInterface_BLL.MediInsInterface.zyInterface;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.NccmManager;
using HIS.MediInsInterface_BLL.MediInsBLL.Domain.zyUpload;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS_MediInsInterface.Action
{
    //zenghao [20100510.2.01]
    public class CostUpdateController:IDisposable
    {
        private ICostUpdate view;

        private IpatInfo _ipatinfo;

        public IpatInfo Ipatinfo
        {
            get
            {
                return _ipatinfo;
            }
            set
            {
                _ipatinfo = value;
                DataSet _dataSet = new DataSet();
                //加载病人诊断
                DataTable dt = BaseDataFactory.GetData(baseDataType.诊断);
                dt.TableName = "Disease";
                _dataSet.Tables.Add(dt);

                _ipatinfo.Initialize(_dataSet);
                _ipatinfo.DiseaseCode = zy_PatList.DiseaseCode;
                _ipatinfo.DiseaseName = zy_PatList.DiseaseName;
            }
        }

        public delegate void BackUpdateTypeEvent();
        /// <summary>
        /// 控制界面状态
        /// </summary>
        public event BackUpdateTypeEvent BackUpdateType;
        private Thread thread;
        /// <summary>
        /// 农合接口对象
        /// </summary>

        private ZY_PatList zy_PatList;
        private ZY_PatList[] zy_PatLists;
        private PatPresOrderUpload patpoUpload;

        DataTable dt1;
        DataTable dt2;

        public CostUpdateController(ICostUpdate _view,string _empid,string _name)
        {
            view = _view;
            patpoUpload = new PatPresOrderUpload();
            patpoUpload.ZyPatlist = zy_PatList;
            patpoUpload.EmpID = _empid;
            patpoUpload.Name = _name;

            view.rtbMessage = "连接接口成功！\n";
        }
        /// <summary>
        /// 得到单个病人数据
        /// </summary>
        public void GetSinglePatData()
        {
            zy_PatList = view.zyPatList;
            patpoUpload.ZyPatlist = zy_PatList;
            view.dgvFee = patpoUpload.GetPresOrderNoPass();
        }

        /// <summary>
        /// 单人上传
        /// </summary>
        public void SinglePatUpdate()
        {
            thread = new Thread(new ThreadStart(_SinglePatUpdate));
            thread.Start();
            //_SinglePatUpdate();
        }
        private void _SinglePatUpdate()
        {
            try
            {
            
                if (zy_PatList == null)
                {
                    view.rtbMessage = "没有指定病人！\n";
                    BackUpdateType();
                    return;
                }

                if (zy_PatList.Nccm_NO == null || zy_PatList.Nccm_NO == "")
                {
                    view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人还没有入院登记到农合系统！\n";
                    BackUpdateType();
                    return;
                }


                if (zy_PatList.patientInfo.MediCard == null || zy_PatList.patientInfo.MediCard.Trim() == "")
                {
                    view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人医疗证号信息为空，不能上传费用！\n";
                    BackUpdateType();
                    return;
                }


                //加载农合病人信息，为农合病人做准备
                view.rtbMessage = "正在上传[" + zy_PatList.patientInfo.PatName + "]数据！\n";
                patpoUpload.ErrMessage = "";
                patpoUpload.ZyPatlist = zy_PatList;
                if (patpoUpload.UploadPresOrder() == false)
                {
                    view.rtbMessage = patpoUpload.ErrMessage;
                    view.rtbMessage = "上传失败！\n";
                }
                else
                {
                    view.rtbMessage = "上传[" + zy_PatList.patientInfo.PatName + "]成功！\n";
                }
            }
            catch(Exception err)
            {
                view.rtbMessage = "上传失败！["+err.Message+"]\n";
            }
            BackUpdateType();
        }
        /// <summary>
        /// 多人上传
        /// </summary>
        public void ManyPatUpdate()
        {
            zy_PatLists = view.zyPatLists;
            thread = new Thread(new ThreadStart(_ManyPatUpdate));
            thread.Start();

            //_ManyPatUpdate();
        }
        private void _ManyPatUpdate()
        {
            
            if (zy_PatLists == null || zy_PatLists.Length==0)
            {
                view.rtbMessage = "没有勾选病人！\n";
                BackUpdateType();
                return;
            }

            for (int i = 0; i < zy_PatLists.Length; i++)
            {
                try
                {
                    //加载农合病人信息，为农合病人做准备
                    view.rtbMessage = "正在上传[" + zy_PatLists[i].patientInfo.PatName + "]数据！\n";

                    if (zy_PatLists[i].Nccm_NO == null || zy_PatLists[i].Nccm_NO == "")
                    {
                        view.rtbMessage = "[" + zy_PatLists[i].patientInfo.PatName + "]病人还没有入院登记到农合系统！\n";
                        continue;
                    }


                    if (zy_PatLists[i].patientInfo.MediCard == null || zy_PatLists[i].patientInfo.MediCard.Trim() == "")
                    {
                        view.rtbMessage = "[" + zy_PatLists[i].patientInfo.PatName + "]病人医疗证号信息为空，不能上传费用！\n";
                        continue;
                    }

                    //加载农合病人信息，为农合病人做准备
                    view.rtbMessage = "正在上传[" + zy_PatLists[i].patientInfo.PatName + "]数据！\n";

                    patpoUpload.ZyPatlist = zy_PatLists[i];
                    patpoUpload.ErrMessage = "";
                    if (patpoUpload.UploadPresOrder() == false)
                    {
                        view.rtbMessage = patpoUpload.ErrMessage;
                        view.rtbMessage = "上传失败！\n";
                    }
                    else
                    {
                        view.rtbMessage = "上传[" + zy_PatLists[i].patientInfo.PatName + "]成功！\n";
                    }

                    view.rtbMessage = "上传[" + zy_PatLists[i].patientInfo.PatName + "]成功！\n";
                }
                catch
                {
                    view.rtbMessage = "上传失败！\n";
                }
            }

            BackUpdateType();
        }
        /// <summary>
        /// 清除信息
        /// </summary>
        public void ClearMessage()
        {
            view.ClearMessage();
        }
        /// <summary>
        /// 终止上传
        /// </summary>
        public void StopUpdate()
        {
            thread.Abort();
        }
        /// <summary>
        /// 刷新上传费用
        /// </summary>
        public void BrushUploadFee()
        {
            if (zy_PatList == null)
            {
                return;
            }

            if (zy_PatList.Nccm_NO == null || zy_PatList.Nccm_NO == "")
            {
                return;
            }


            if (zy_PatList.patientInfo.MediCard == null || zy_PatList.patientInfo.MediCard.Trim() == "")
            {
                return;
            }

            patpoUpload.ZyPatlist = zy_PatList;
            patpoUpload.ErrMessage = "";
            DataSet ds = patpoUpload.BrushUploadFee();
            if (patpoUpload.ErrMessage != "")
                view.rtbMessage = patpoUpload.ErrMessage;
            dt1 = ds.Tables["dt1"];
            view.dgvHisFee = dt1;
            dt2 = ds.Tables["dt2"];
            view.dgvNccmFee = dt2;
        }
        /// <summary>
        /// 比较上传费用
        /// </summary>
        public void CompUploadFee()
        {
            if (dt1 != null && dt2 != null)
            {
                DataTable dtcu1 = dt1.Clone();
                for (int i = 0; i < this.dt1.Rows.Count; i++)
                {
                    for (int k = 0; k < this.dt2.Rows.Count; k++)
                    {
                        if (this.dt1.Rows[i]["PresOrderID"].ToString() == this.dt2.Rows[k]["hos_serial"].ToString())
                        {
                            break;
                        }
                        if (k == this.dt2.Rows.Count - 1)
                        {
                            dtcu1.Rows.Add(this.dt1.Rows[i].ItemArray);
                        }
                    }

                }

                DataTable dtcu2 = this.dt2.Clone();
                for (int i = 0; i < this.dt2.Rows.Count; i++)
                {
                    for (int k = 0; k < this.dt1.Rows.Count; k++)
                    {
                        if (this.dt1.Rows[k]["PresOrderID"].ToString() == this.dt2.Rows[i]["hos_serial"].ToString())
                        {
                            break;
                        }
                        if (k == this.dt1.Rows.Count - 1)
                        {
                            dtcu2.Rows.Add(this.dt2.Rows[i].ItemArray);
                        }
                    }

                }

                view.dgvHisFee = dtcu1;
                view.dgvNccmFee = dtcu2;
            }
        }

        #region IpatInfo

        private DataTable dtpatInfo;
        private string ywid;

        public void getpatinfodata()
        {
            patpoUpload.ZyPatlist = zy_PatList;
 
            dtpatInfo = patpoUpload.GetPatInfo();
 
            
            ywid = patpoUpload.GetPatYWID();
 
            Ipatinfo.ylzh = zy_PatList.patientInfo.MediCard;
            Ipatinfo.cbywlb = patpoUpload.GetPatYWLB();
 
            Ipatinfo.dgvpatInfo = dtpatInfo;
            Ipatinfo.ywid = ywid;
        }

        public void newgetpatinfodata()
        {
            zy_PatList.patientInfo.MediCard = Ipatinfo.ylzh;
            patpoUpload.ZyPatlist = zy_PatList;
            dtpatInfo = patpoUpload.GetPatInfo();
            ywid = patpoUpload.GetPatYWID();
            Ipatinfo.ylzh = zy_PatList.patientInfo.MediCard;
            Ipatinfo.cbywlb = patpoUpload.GetPatYWLB();
            Ipatinfo.dgvpatInfo = dtpatInfo;
            Ipatinfo.ywid = ywid;

            //view.brushpatlist();
        }

        public void PatRegister()
        {
            if (zy_PatList == null)
            {
                view.rtbMessage = "没有指定病人！\n";
                BackUpdateType();
                return;
            }

            if (zy_PatList.patientInfo.MediCard == null || zy_PatList.patientInfo.MediCard.Trim() == "")
            {
                view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人医疗证号信息为空，不能入院登记！\n";
                BackUpdateType();
                return;
            }
            try
            {
                zy_PatList.patientInfo.FamilyCode = dtpatInfo.Rows[Ipatinfo.currentRow]["GRBM"].ToString() + "-" + Ipatinfo.ywlb;
                zy_PatList.patientInfo.PatName = dtpatInfo.Rows[Ipatinfo.currentRow]["XM"].ToString();
                zy_PatList.Nccm_NO = ywid + "-";
                zy_PatList.DiseaseCode = Ipatinfo.DiseaseCode;
                zy_PatList.DiseaseName = Ipatinfo.DiseaseName;
                patpoUpload.ZyPatlist = zy_PatList;
                patpoUpload.ErrMessage = "";
                zy_PatList.Nccm_NO += patpoUpload.PatRegister();
                if (patpoUpload.ErrMessage != "")
                    view.rtbMessage = patpoUpload.ErrMessage;
                else
                    view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人操作成功！\n";
                //view.brushpatlist();

                BackUpdateType();
            }
            catch (Exception err)
            {
                //view.brushpatlist();
                zy_PatList.Nccm_NO = "";
                view.rtbMessage = err.Message + "\n";
            }

        }

        public void RestPatRegister()
        {
            if (zy_PatList == null)
            {
                view.rtbMessage = "没有指定病人！\n";
                BackUpdateType();
                return;
            }

            if (zy_PatList.patientInfo.MediCard == null || zy_PatList.patientInfo.MediCard.Trim() == "")
            {
                view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人医疗证号信息为空，不能操作！\n";
                BackUpdateType();
                return;
            }

            if (zy_PatList.PatType == "4")
            {
                patpoUpload.ZyPatlist = zy_PatList;
                patpoUpload.ErrMessage = "";
                patpoUpload.RestPatRegister();
                if (patpoUpload.ErrMessage != "")
                    view.rtbMessage = patpoUpload.ErrMessage;
                else
                    view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人操作成功！\n";
                BackUpdateType();
            }
            else
                throw new Exception("病人还没有出院！");
        }

        public void CancelPatRegister()
        {
            if (zy_PatList == null)
            {
                view.rtbMessage = "没有指定病人！\n";
                BackUpdateType();
                return;
            }

            if (zy_PatList.patientInfo.MediCard == null || zy_PatList.patientInfo.MediCard.Trim() == "")
            {
                view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人医疗证号信息为空，不能操作！\n";
                BackUpdateType();               
                return;
            }

            patpoUpload.ZyPatlist = zy_PatList;
            patpoUpload.ErrMessage = "";
            if (patpoUpload.CancelPatRegister())
            {
                if (patpoUpload.ErrMessage != "")
                    view.rtbMessage = patpoUpload.ErrMessage;
                else
                    view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人操作成功！\n";
                patpoUpload.ZyPatlist.Nccm_NO = "";
                zy_PatList.Nccm_NO = "";
                //view.brushpatlist();
            }
            else
            {
                if (patpoUpload.ErrMessage != "")
                    view.rtbMessage = patpoUpload.ErrMessage;
                view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人操作失败！\n";
            }
            BackUpdateType();
        }

        public void PatCost()
        {
            if (zy_PatList == null)
            {
                view.rtbMessage = "没有指定病人！\n";
                BackUpdateType();
                return;
            }

            if (zy_PatList.Nccm_NO == null || zy_PatList.Nccm_NO == "")
            {
                view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人还没有入院登记到农合系统！\n";
                BackUpdateType();
                return;
            }


            if (zy_PatList.patientInfo.MediCard == null || zy_PatList.patientInfo.MediCard.Trim() == "")
            {
                view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人医疗证号信息为空，不能操作！\n";
                BackUpdateType();     
                return;
            }
            patpoUpload.ZyPatlist = zy_PatList;
            patpoUpload.ErrMessage = "";
            patpoUpload.PatCost();
            if (patpoUpload.ErrMessage != "")
                view.rtbMessage = patpoUpload.ErrMessage;
            else
                view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人操作成功！\n";
            BackUpdateType();
        }

        public void CancelPatCost()
        {
            if (zy_PatList == null)
            {
                view.rtbMessage = "没有指定病人！\n";
                BackUpdateType();
                return;
            }

            if (zy_PatList.Nccm_NO == null || zy_PatList.Nccm_NO == "")
            {
                view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人还没有入院登记到农合系统！\n";
                BackUpdateType();
                return;
            }


            if (zy_PatList.patientInfo.MediCard == null || zy_PatList.patientInfo.MediCard.Trim() == "")
            {
                view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人医疗证号信息为空，不能操作！\n";
                BackUpdateType();
                return;
            }
            patpoUpload.ZyPatlist = zy_PatList;
            patpoUpload.ErrMessage = "";
            if (!patpoUpload.CancelPatCost())
            {
                view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人操作失败！\n";
            }
            if (patpoUpload.ErrMessage != "")
                view.rtbMessage = patpoUpload.ErrMessage;
            else
                view.rtbMessage = "[" + zy_PatList.patientInfo.PatName + "]病人操作成功！\n";

            BackUpdateType();
        }


        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            patpoUpload.Dispose();
        }

        #endregion
    }
}
