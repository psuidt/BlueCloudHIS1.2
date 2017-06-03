using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.ObjectModel.AOP;
using System.Runtime.Remoting.Messaging;
using System.Collections;
using HIS.ZY_BLL.DataModel;
using System.Data;
using HIS.MediInsInterface_BLL.MediInsInterface.zyInterface;

namespace HIS.ZY_BLL.ObjectModel.NccmManager
{
    //[20100518.2.05]
    public class NccmProxy : AopProxyBase
    {
        public NccmProxy(MarshalByRefObject obj, Type type)
            : base(obj, type)
        {
        }

        private ZY_PatList zyPatlist
        {
            get
            {
                return (ZY_PatList)CallContext.GetData("zyPatlist");
            }
        }
        /// <summary>
        /// 病人结算类型
        /// </summary>
        private int Ntype
        {
            get
            {
                return Convert.ToInt32(CallContext.GetData("Ntype"));
            }
        }
        /// <summary>
        /// 结算时农合上传的编码
        /// </summary>
        private string Nccm_NO
        {
            get
            {
                return CallContext.GetData("Nccm_NO").ToString();
            }
        }
        /// <summary>
        /// 农合计算后得到的农合金额
        /// </summary>
        private decimal villageFee
        {
            set
            {
                CallContext.SetData("villageFee", value);
            }
        }

        /// <summary>
        /// 农合病人入院
        /// </summary>
        /// <param name="zypatlist"></param>
        private void NccmPatRegister()
        {
            try
            {
                if (zyPatlist.patientInfo.ACCOUNTTYPE.Trim() == "农合")
                {
                    if (zyPatlist.patientInfo.MediCard != null && zyPatlist.patientInfo.MediCard != "")
                    {
                        //调用农合接口：入院
                        IzyInterface nccmInterface =NccmFactory.Create();
                        if (nccmInterface != null)
                        {
                            //nccmInterface.GetPatientInfo(HIS.ZY_BLL.SearchNccmPatType.医疗卡号, zypatlist.PatientInfo.MediCard);
                            zyPatlist.Nccm_NO = zyNccmInterface.GetNccmNo();
                            nccmInterface.zyPatlist = zyPatlist;
                            nccmInterface.Register(null);
                        }
                    }
                    else
                    {
                        throw new Exception("农合入院请输入医疗证号！");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "\n\n农合病人入院调用[农合接口]失败！");
            }
        }

        /// <summary>
        /// 农合病人取消入院
        /// </summary>
        /// <param name="zypatlist"></param>
        private void NccmPatCancel()
        {
            try
            {
                if (zyPatlist.patientInfo.ACCOUNTTYPE.Trim() == "农合")
                {
                    if (zyPatlist.patientInfo.MediCard != null && zyPatlist.patientInfo.MediCard != "")
                    {
                        //调用农合接口取消入院
                        IzyInterface nccmInterface = NccmFactory.Create();
                        if (nccmInterface != null)
                        {
                            nccmInterface.zyPatlist = zyPatlist;
                            nccmInterface.CancelRegister(null);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "\n\n农合病人取消入院调用[农合接口]失败！");
            }
        }
        /// <summary>
        /// 农合病人修改
        /// </summary>
        private void NccmPatAlter()
        {
            try
            {
                //病人类型自费转农合(调入院接口和费用上传接口)
                if (zyPatlist.patientInfo.ACCOUNTTYPE == "农合")
                {
                    if (zyPatlist.Nccm_NO == null || zyPatlist.Nccm_NO == "")
                    {
                        NccmPatRegister();
                        //农合记账

                        IzyInterface nccmInterface = NccmFactory.Create();
                        if (nccmInterface != null)
                        {
                            nccmInterface.zyPatlist = zyPatlist;
                            ZY_PresOrder zypo = new ZY_PresOrder();
                            zypo.PatListID = zyPatlist.PatListID;
                            DataTable dt = zypo.GetPresDataTable();
                            Hashtable hashtable = new Hashtable();
                            hashtable.Add("FeeDetail", zyNccmInterface.ConvertFeeDetail(dt));
                            nccmInterface.UploadzyPatFee(hashtable);
                        }
                    }
                }

                //病人类型农合转自费(调取消入院接口)
                if (zyPatlist.patientInfo.ACCOUNTTYPE != "农合")
                {
                    if (zyPatlist.Nccm_NO != null && zyPatlist.Nccm_NO != "")
                    {
                        NccmPatCancel();
                        zyPatlist.Nccm_NO = "";
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "\n\n农合病人修改调用[农合接口]失败！");
            }
        }

        //记账、冲账农合费用上传
        private void Nccm_UploadFee()
        {
            try
            {
                if (zyPatlist.patientInfo.ACCOUNTTYPE.Trim() == "农合")
                {
                    if (zyPatlist.patientInfo.MediCard != null && zyPatlist.patientInfo.MediCard.Trim() != "")
                    {
                        IzyInterface nccmInterface = NccmFactory.Create();
                        if (nccmInterface != null)
                        {
                            nccmInterface.zyPatlist = zyPatlist;
                            //找出所有待上传的费用记录
                            ZY_PresOrder zypo = new ZY_PresOrder();
                            zypo.PatListID = zyPatlist.PatListID;
                            DataTable dt = zypo.GetPresDataTable();

                            Hashtable hashtable = new Hashtable();
                            hashtable.Add("FeeDetail", zyNccmInterface.ConvertFeeDetail(dt));
                            nccmInterface.UploadzyPatFee(hashtable);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message+"\n\n农合费用上传失败！");
            }
        }

        //农合预算
        public void PreviewCharge()
        {

            try
            {
                //加载农合病人信息，为农合病人做准备
                if (zyPatlist.patientInfo.ACCOUNTTYPE.Trim() == "农合")
                {
                    if (zyPatlist.patientInfo.MediCard != null && zyPatlist.patientInfo.MediCard.Trim() != "")
                    {
                        IzyInterface nccmInterface = NccmFactory.Create();
                        if (nccmInterface != null)
                        {
                            nccmInterface.zyPatlist = zyPatlist;
                            //找出所有待上传的费用记录
                            ZY_PresOrder zypo = new ZY_PresOrder();
                            zypo.PatListID = zyPatlist.PatListID;
                            DataTable dt = zypo.GetPresDataTable();

                            Hashtable hashtable = new Hashtable();
                            hashtable.Add("FeeDetail", zyNccmInterface.ConvertFeeDetail(dt));
                            hashtable.Add("midWay", Ntype.ToString());

                            decimal _villageFee = nccmInterface.PreviewCharge(hashtable);
                            //Op_PatFee.SetvillageFee(ref patFee, villageFee);
                            villageFee = _villageFee;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                villageFee = 0;
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 农合结算
        /// </summary>
        /// <returns></returns>
        public void NccmCheck_CostPat()
        {
            try
            {
                //加载农合病人信息，为农合病人做准备
                if (zyPatlist.patientInfo.ACCOUNTTYPE.Trim() == "农合")
                {
                    if (zyPatlist.patientInfo.MediCard != null && zyPatlist.patientInfo.MediCard.Trim() != "")
                    {
                        IzyInterface nccmInterface = NccmFactory.Create();
                        if (nccmInterface != null)
                        {
                            nccmInterface.zyPatlist = zyPatlist;
                            string Nccm_NO = zyNccmInterface.GetNccmNo();
                            //找出所有待上传的费用记录
                            ZY_PresOrder zypo = new ZY_PresOrder();
                            zypo.PatListID = zyPatlist.PatListID;
                            DataTable dt = zypo.GetPresDataTable();

                            Hashtable hashtable = new Hashtable();
                            hashtable.Add("FeeDetail", zyNccmInterface.ConvertFeeDetail(dt));
                            hashtable.Add("midWay", Ntype.ToString());
                            hashtable.Add("Nccm_NO", Nccm_NO);
                            decimal _villageFee = nccmInterface.Charge(hashtable);
                            villageFee = _villageFee;
                        }
                    }
                }
                villageFee = 0;
            }
            catch (Exception e)
            {
                villageFee = 0;
                throw new Exception(e.Message+"\n\n农合结算失败！");
            }
        }

        /// <summary>
        /// 取消结算
        /// </summary>
        public void NccmCheck_CanelCostPat()
        {
            try
            {
                if (zyPatlist.patientInfo.ACCOUNTTYPE.Trim() == "农合")
                {
                    if (zyPatlist.patientInfo.MediCard != null && zyPatlist.patientInfo.MediCard.Trim() != "")
                    {
                        //调用农合接口取消入院
                        IzyInterface nccmInterface = NccmFactory.Create();
                        if (nccmInterface != null)
                        {
                            nccmInterface.zyPatlist = zyPatlist;

                            Hashtable hashtable = new Hashtable();
                            hashtable.Add("Nccm_NO", Nccm_NO);
                            nccmInterface.CancelCharge(hashtable);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message+"\n\n农合取消结算失败！");
            }
        }



        public override void PreProcess(IMessage requestMsg)
        {
            string Index="";
            string ClassName = "";
            foreach (DictionaryEntry de in requestMsg.Properties)
            {
                if (de.Key.ToString() == "__TypeName")
                {
                    ClassName = de.Value.ToString().Split(new char[] { ',' })[0].Trim();
                }
                if (de.Key.ToString() == "__MethodName")
                {
                    Index = de.Value.ToString();
                }
            }

            if (ClassName == typeof(ZY_PatList).Name)
            {
                switch (Index)
                {
                    case "Add":
                        NccmPatRegister();
                        break;
                    case "Delete":
                        NccmPatCancel();
                        break;
                    case "Update":
                        NccmPatAlter();
                        break;
                }
            }
            else if (ClassName == typeof(ZY_CostMaster).Name)
            {

            }


        }

        public override void PostProcess(IMessage requestMsg, IMessage Respond)
        {
            string Index = "";
            string ClassName = "";
            foreach (DictionaryEntry de in requestMsg.Properties)
            {
                if (de.Key.ToString() == "__TypeName")
                {
                    ClassName = de.Value.ToString().Split(new char[] { ',' })[0].Trim();
                }
                if (de.Key.ToString() == "__MethodName")
                {
                    Index = de.Value.ToString();
                }
            }

            if (ClassName == typeof(ZY_PresOrder).Name)
            {
                Nccm_UploadFee();
            }
        }

    }

    /// <summary>
    /// 获取农合病人的方式
    /// </summary>
    public enum SearchNccmPatType
    {
        病人姓名,
        身份证号,
        医疗卡号,
        家庭编码,
        住院编号
    }
}
