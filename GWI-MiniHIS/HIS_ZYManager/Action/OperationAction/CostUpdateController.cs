using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;

using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.NccmManager;
using System.Collections;
using HIS.MediInsInterface_BLL.MediInsInterface.zyInterface;

namespace HIS_ZYManager.Action
{
    //zenghao [20100510.2.01]
    public class CostUpdateController
    {
        private ICostUpdate view;

        public delegate void BackUpdateTypeEvent();
        /// <summary>
        /// 控制界面状态
        /// </summary>
        public event BackUpdateTypeEvent BackUpdateType;
        private Thread thread;
        /// <summary>
        /// 农合接口对象
        /// </summary>
        IzyInterface nccmInterface = null;

        private ZY_PatList zy_PatList;
        private ZY_PatList[] zy_PatLists;
        private ZY_PresOrder zypo;

        DataTable dt1;
        DataTable dt2;

        public CostUpdateController(ICostUpdate _view)
        {
            view = _view;
            zypo = new ZY_PresOrder();
        }
        /// <summary>
        /// 得到单个病人数据
        /// </summary>
        public void GetSinglePatData()
        {
            zy_PatList = view.zyPatList;
            zypo.PatListID = zy_PatList.PatListID;
            view.dgvFee = zypo.GetPresDataTable();
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
                ZY_PresOrder zypo = new ZY_PresOrder();
                zypo.PatListID = zy_PatList.PatListID;

                if (zy_PatList == null)
                {
                    view.rtbMessage = "没有指定病人！\n";
                    BackUpdateType();
                    return;
                }

                //加载农合病人信息，为农合病人做准备
                view.rtbMessage = "正在上传[" + zy_PatList.patientInfo.PatName + "]数据！\n";
                if (zy_PatList.patientInfo.MediCard != null && zy_PatList.patientInfo.MediCard.Trim() != "")
                {
                    //第一步：实例化接口对象
                    nccmInterface = NccmFactory.Create();
                    if (nccmInterface == null)
                    {
                        view.rtbMessage = "没有开启上传接口！\n";
                    }
                    else
                    {
                        //第二步：病人信息赋值
                        nccmInterface.zyPatlist = zy_PatList;
                        view.rtbMessage = "根据[" + zy_PatList.patientInfo.PatName + "]医疗证号获取病人信息！\n";
                        //第三步：根据医疗证号获取最新的农合病人信息

                        view.rtbMessage = "获取[" + zy_PatList.patientInfo.PatName + "]病人信息成功！\n";
                        //第四步：提取病人上传的费用信息
                        DataTable dt = zypo.GetPresDataTable();
                        view.rtbMessage = "提取[" + zy_PatList.patientInfo.PatName + "]病人费用成功！\n";
                        if (dt.Rows.Count > 0)
                        {
                            //第五步：更改所有费用为上传标志
                            //int[] presID = new int[dt.Rows.Count];
                            //for (int i = 0; i < dt.Rows.Count; i++)
                            //{
                            //    presID[i] = Convert.ToInt32(dt.Rows[i]["PRESORDERID"]);
                            //}
                            //HIS.ZY_BLL.OP_PresManage.UpdateComp(presID);
                            //第六步：调用费用上传接口（上传失败的费用会更改上传标识）

                            Hashtable hashtable = new Hashtable();
                            hashtable.Add("FeeDetail", zyNccmInterface.ConvertFeeDetail(dt));

                            nccmInterface.UploadzyPatFee(hashtable);
                            view.rtbMessage = "上传[" + zy_PatList.patientInfo.PatName + "]成功！\n";
                        }

                    }
                }
                else
                {
                    view.rtbMessage = "没有指定病人或此病人不是符合类型的病人！\n";
                }


            }
            catch
            {
                view.rtbMessage = "上传失败！\n";
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
            ZY_PresOrder zypo = new ZY_PresOrder();

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
                    if (zy_PatLists[i].patientInfo.MediCard != null && zy_PatLists[i].patientInfo.MediCard.Trim() != "")
                    {
                        //第一步：实例化接口对象
                        nccmInterface = NccmFactory.Create();
                        if (nccmInterface == null)
                        {
                            view.rtbMessage = "没有开启农合接口！\n";
                        }
                        else
                        {
                            //第二步：病人信息赋值
                            nccmInterface.zyPatlist = zy_PatLists[i];
                            view.rtbMessage = "根据医疗证号获取[" + zy_PatLists[i].patientInfo.PatName + "]病人信息！\n";
                            //第三步：根据医疗证号获取最新的农合病人信息

                            view.rtbMessage = "获取[" + zy_PatLists[i].patientInfo.PatName + "]病人信息成功！\n";
                            //第四步：提取病人上传的费用信息
                            zypo.PatListID = zy_PatLists[i].PatListID;
                            DataTable dt = zypo.GetPresDataTable();
                            view.rtbMessage = "提取[" + zy_PatLists[i].patientInfo.PatName + "]病人费用成功！\n";
                            if (dt.Rows.Count > 0)
                            {
                                //第五步：更改所有费用为上传标志
                                //int[] presID = new int[dt.Rows.Count];
                                //for (int k = 0; k < dt.Rows.Count; i++)
                                //{
                                //    presID[k] = Convert.ToInt32(dt.Rows[k]["PRESORDERID"]);
                                //}
                                //HIS.ZY_BLL.OP_PresManage.UpdateComp(presID);
                                //第六步：调用费用上传接口（上传失败的费用会更改上传标识）

                                Hashtable hashtable = new Hashtable();
                                hashtable.Add("FeeDetail", zyNccmInterface.ConvertFeeDetail(dt));
                                nccmInterface.UploadzyPatFee(hashtable);

                                view.rtbMessage = "上传[" + zy_PatLists[i].patientInfo.PatName + "]成功！\n";
                            }

                        }
                    }
                    else
                    {
                        view.rtbMessage = "此病人不是符合类型的病人！\n";
                    }
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
            if (zy_PatList != null)
            {
                ZY_PresOrder zypo = new ZY_PresOrder();
                zypo.PatListID = zy_PatList.PatListID;
                dt1 = zypo.GetPresDataTableOld();

                dt2 = null;
                if (zy_PatList.patientInfo.ACCOUNTTYPE.Trim() == "农合")
                {
                    if (zy_PatList.patientInfo.MediCard != null && zy_PatList.patientInfo.MediCard != "")
                    {
                        IzyInterface nccmInterface = NccmFactory.Create();
                        if (nccmInterface != null)
                        {
                            nccmInterface.zyPatlist = zy_PatList;
                            dt2 = nccmInterface.DownloadzyPatFee(null);
                        }
                    }
                }
                view.dgvHisFee = dt1;
                view.dgvNccmFee = dt2;
            }
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
                        if (this.dt1.Rows[i]["PresOrderID"].ToString() == this.dt2.Rows[k]["PresOrderID"].ToString())
                        {
                            break;
                        }
                        if (k == this.dt2.Rows.Count - 1)
                        {
                            dt1.Rows.Add(this.dt1.Rows[i].ItemArray);
                        }
                    }

                }

                DataTable dtcu2 = this.dt2.Clone();
                for (int i = 0; i < this.dt2.Rows.Count; i++)
                {
                    for (int k = 0; k < this.dt1.Rows.Count; k++)
                    {
                        if (this.dt1.Rows[i]["PresOrderID"].ToString() == this.dt2.Rows[k]["PresOrderID"].ToString())
                        {
                            break;
                        }
                        if (k == this.dt1.Rows.Count - 1)
                        {
                            dt2.Rows.Add(this.dt2.Rows[i].ItemArray);
                        }
                    }

                }

                view.dgvHisFee = dtcu1;
                view.dgvNccmFee = dtcu2;
            }
        }
    }
}
