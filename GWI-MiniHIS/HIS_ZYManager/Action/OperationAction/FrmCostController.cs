using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.ZY_BLL.DataModel;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.ZY_BLL.ObjectModel.BaseData;
using HIS.ZY_BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_ZYManager.Action
{
    public class FrmCostController
    {
        private DataSet _dataSet;

        private ZY_PatList zyPatlist;
        private ZY_CostMaster zyCostMaster;

        public User user;
        private Deptment dept;

        private PatFee patFee;
        private DataTable dgFee;

        private IFrmCostView _ifrmCostView;

        //记账类型
        private string _patType;
        //记账单位
        string WorkUnit = "";
        //单位记账金额
        decimal workUnit_Fee = 0;
        //定额记账总额
        decimal Ration_Fee = 0;
        //住院参数008
        int zyConfig008;

        public IFrmCostView IfrmCostView
        {
            get { return _ifrmCostView; }
            set { _ifrmCostView = value; }
        }
        private IFrmCostDiagView _ifrmCostDiagView;

        public IFrmCostDiagView IfrmCostDiagView
        {
            get { return _ifrmCostDiagView; }
            set { _ifrmCostDiagView = value; }
        }

        public FrmCostController(IFrmCostView _view)
        {
            IfrmCostView = _view;
            _dataSet = new DataSet();
            user = IfrmCostView.currentUser;
            dept = IfrmCostView.currentDept;

            zyCostMaster = new ZY_CostMaster();
            zyPatlist = new ZY_PatList();

            LoadINFO();

            zyConfig008 = HIS.ZY_BLL.OP_ZYConfigSetting.GetConfigValue("008");
        }

        // 导入科室信息和诊断信息
        private void LoadINFO()
        {
            DataTable dt = BaseDataFactory.GetData(baseDataType.诊断);
            dt.TableName = "Disease";
            _dataSet.Tables.Add(dt);
            dt = null;
            dt = BaseDataFactory.GetData(baseDataType.住院临床科室);
            dt.TableName = "Dept";
            _dataSet.Tables.Add(dt);
        }

        #region FrmCost

        /// <summary>
        /// 得到当前病人TextBox里显示的数据
        /// </summary>
        private void GetTextFeeData()
        {
            patFee = zyCostMaster.GetPatCostFee();
           
        }
        /// <summary>
        /// 得到病人DataGrid里显示的数据
        /// </summary>
        private void GetdgFeeData()
        {
            dgFee = zyCostMaster.GetPatOrderFee();
           
        }
        /// <summary>
        /// 得到病人的数据
        /// </summary>
        public void GetPatData()
        {
            zyPatlist = IfrmCostView.zyPatList;
            zyCostMaster.PatListID = zyPatlist.PatListID;

            GetTextFeeData();
            GetdgFeeData();
            IfrmCostView.patFee = patFee;
            IfrmCostView.dgFee = dgFee;

            IfrmCostView.zyPatList = zyPatlist;
        }

        /// <summary>
        /// 根据住院号加载病人的信息
        /// </summary>
        public void GetInpatNo()
        {
            ZY_PatList zypl = zyPatlist.GetPatInfo(IfrmCostView.InpatNo);
            if (zypl != null)
            {
                if (zypl.PatType == "4" || zypl.PatType == "5")
                {
                    throw new Exception("您输入的住院号病人已出院！");
                }
                zyPatlist = zypl;
                IfrmCostView.zyPatList = zyPatlist;
                IfrmCostView.ChargePatData();
            }
            else
            {
                IfrmCostView.InpatNo = "0";
                throw new Exception("您输入的住院号病人不存在！");
            }
        }
        /// <summary>
        /// 获取记账金额
        /// </summary>
        public void GetvillageFee()
        {
            if (zyPatlist != null)
            {
                Op_PatFee.SetvillageFee(ref patFee, 0);
                decimal selfFee = patFee.costFee - zyCostMaster.GetPatSelfFee(zyPatlist.PatListID);
                HIS_PublicManager.FrmCostCalculate frmcc = new HIS_PublicManager.FrmCostCalculate(zyPatlist.PatListID, patFee.costFee, selfFee, dgFee);
                frmcc.ShowDialog();
                Op_PatFee.SetvillageFee(ref patFee, frmcc.CalResult);
                //
                _patType = frmcc.CalType;
                WorkUnit = frmcc.WorkUnit == null ? "" : frmcc.WorkUnit;
                workUnit_Fee = frmcc.workUnit_Fee;

                IfrmCostView.patFee = patFee;
            }
        }
        /// <summary>
        /// 获取优惠金额
        /// </summary>
        public void GetfaoverFee()
        {
            if (zyPatlist != null)
            {
                Op_PatFee.SetfaoverFee(ref patFee, 0);
                HIS_PublicManager.FrmCostFavorable frmcf = new HIS_PublicManager.FrmCostFavorable();
                frmcf.ShowDialog();
                Op_PatFee.SetfaoverFee(ref patFee, frmcf.outFee);
                IfrmCostView.patFee = patFee;
            }
        }
        /// <summary>
        /// 获取自费药品金额
        /// </summary>
        public void GetselfDrugFee()
        {
            string value = GWMHIS.BussinessLogicLayer.Forms.DlgInputBoxStatic.InputBox("录入自费药品金额", "自费药品", "", true);

            value = Convert.ToDecimal(value).ToString("0.00");

            if (value != null)
            {
                IfrmCostView.selfDrugFee = value;
            }
        }

        // 检查费用是否发生更改
        private bool CheckFee()
        {
            PatFee _patFee = zyCostMaster.GetPatCostFee();
            if (_patFee.chargeFee !=patFee.chargeFee || _patFee.costFee != patFee.costFee)
            {
                IfrmCostView.ChargePatData();
                return false;
            }
            return true;
        }

        private int CostPat(int costType, FrmCostDiag fcd)
        {
            try
            {
                ZY_PresOrder zypo = new ZY_PresOrder();
                zypo.PatListID = zyPatlist.PatListID;

                if (zyConfig008 != 0)
                {
                    DataTable dt1 = zypo.GetNotSendDurgPresDataTable();

                    if (dt1.Rows.Count > 0)
                    {
                        throw new Exception("该病人还有未发药的费用！");
                    }
                }

                if (costType != 1)
                {
                    if (costType == 2)
                        zyPatlist.PatType = "4";
                    else if (costType == 3)
                        zyPatlist.PatType = "5";
                }

                ZY_CostMaster zy_CostM = new ZY_CostMaster();

                zy_CostM.PatID = zyPatlist.PatID;
                zy_CostM.PatListID = zyPatlist.PatListID;
                zy_CostM.Ntype = costType;
                zy_CostM.Discharge_date = XcDate.ServerDateTime.Date;
                zy_CostM.Discharge_bdate = zyPatlist.CureDate.Date;//入院日期
                zy_CostM.Discharge_edate = zyPatlist.OutDate;      //出院日期
                zy_CostM.TicketNum = zyCostMaster.GetNewTicketNO(XcDate.ServerDateTime);//?
                zy_CostM.TicketCode = IfrmCostDiagView.tbTicketNO;//fcd.TicketNo.Trim();
                zy_CostM.ChargeCode = user.EmployeeID.ToString();


                zy_CostM.Ticket_Flag = (int)IfrmCostDiagView.Ptt;
                zy_CostM.CostDate = XcDate.ServerDateTime;
                zy_CostM.Record_Flag = 0;
                //农合结算
                //decimal villageFee = HIS.ZY_BLL.OP_CostManage.NccmCheck_CostPat(zy_CostM, base.zy_PatList);
                //if (villageFee != 0)
                //    Op_PatFee.SetvillageFee(ref patFee, villageFee);

                zy_CostM.Total_Fee = Convert.ToDecimal(patFee.costFee.ToString("0.00"));
                zy_CostM.Deptosit_Fee = Convert.ToDecimal(patFee.chargeFee.ToString("0.00"));
                zy_CostM.Self_Fee = Convert.ToDecimal(patFee.selfFee.ToString("0.00"));
                zy_CostM.Village_Fee = Convert.ToDecimal(patFee.villageFee.ToString("0.00"));
                zy_CostM.Favor_Fee = Convert.ToDecimal(patFee.faoverFee.ToString("0.00"));
                zy_CostM.Pos_Fee = IfrmCostDiagView.tbPos;
                zy_CostM.Money_Fee = IfrmCostDiagView.tbFee;

                zy_CostM.Reality_Fee = zy_CostM.Pos_Fee + zy_CostM.Money_Fee;//实收金额=pos金额+现金金额

                zy_CostM.Village_Type = 3;
                if (_patType.Trim() == "01")
                    zy_CostM.Village_Type = 3;
                else if (_patType.Trim() == "02")
                    zy_CostM.Village_Type = 2;
                else if (_patType.Trim() == "03")
                    zy_CostM.Village_Type = 0;
                else if (_patType.Trim() == "04")
                    zy_CostM.Village_Type = 1;
                else if (_patType.Trim() == "05")
                    zy_CostM.Village_Type = 3;
                else if (_patType.Trim() == "06")
                    zy_CostM.Village_Type = 3;

                zy_CostM.PatType = _patType;
                zy_CostM.WorkUnit = WorkUnit;
                zy_CostM.WorkUnit_Fee = workUnit_Fee;
                zy_CostM.NotWorkUnit_Fee = zy_CostM.Village_Fee - workUnit_Fee;
                zy_CostM.Ration_Fee = Ration_Fee;
                zy_CostM.MoreRation_Fee = Ration_Fee != 0 ? (Ration_Fee - zy_CostM.Village_Fee) : 0;
                zy_CostM.SelfDrug_Fee = Convert.ToDecimal(IfrmCostView.selfDrugFee);
                //TicketNum = zy_CostM.TicketNum;//add zenghao 090209

                DataTable dt = zyCostMaster.GetPatBigItemOrderFee();
                List<ZY_CostOrder> zy_CostOL = new List<ZY_CostOrder>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ZY_CostOrder zy_CostO = new ZY_CostOrder();
                    zy_CostO.PatID = zyPatlist.PatID;
                    zy_CostO.PatListID = zyPatlist.PatListID;
                    zy_CostO.TicketNum = zy_CostM.TicketNum;
                    zy_CostO.TicketCode = zy_CostM.TicketCode;
                    zy_CostO.BigItemCode = dt.Rows[i]["itemtype"].ToString();
                    zy_CostO.Total_Fee = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[i]["tolal_fee"]).ToString("0.00"));
                    zy_CostOL.Add(zy_CostO);
                }

                zyCostMaster.CostPat(zy_CostM, zy_CostOL, zyPatlist);
                return zy_CostM.CostMasterID;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

        }

        /// <summary>
        /// 病人结算
        /// </summary>
        /// <param name="_costType">结算类型</param>
        public void CostPat(CostType _costType,FrmCostController controller)
        {
            if (zyPatlist == null || zyPatlist.PatListID <= 0)
            {
                throw new Exception("请指定一个病人！");
            }
            if (zyPatlist.CureDate.Date > XcDate.ServerDateTime.Date)
            {
                throw new Exception("入院日期大于结算日期，不能结算!");
            }

            if (CheckFee() == false)
            {
                throw new Exception("该病人的费用发生变化，请重新核对后再结算！");
            }

            switch (_costType)
            {
                case CostType.中途结算:
                    #region 中途结算

                    if (zyPatlist.PatType != "1" && zyPatlist.PatType != "2" && zyPatlist.PatType != "7")
                    {
                        throw new Exception("该病人无法办理[中途]结算！");
                    }
                    if (patFee.receiveFee > 0)
                    {
                        throw new Exception("该病人已经欠费，请先补交费用再结算！");
                    }

                    #endregion
                    break;
                case CostType.出院结算:
                    #region 出院结算
                    if (zyConfig008 == 0)
                    {
                        if (zyPatlist.PatType != "3")
                        {
                            throw new Exception("该病人没有定义出院，无法办理[出院]结算！");
                        }
                    }
                    else
                    {
                        if (zyPatlist.PatType == "4" || zyPatlist.PatType == "5")
                        {
                            throw new Exception("该病人已经办理了出院结算！");
                        }
                    }
                    #endregion
                    break;
                case CostType.欠费结算:
                    #region 欠费结算
                    if (zyConfig008 == 0)
                    {
                        if (zyPatlist.PatType != "3")
                        {
                            throw new Exception("该病人没有定义出院，无法办理[欠费]结算！");
                        }
                    }
                    else
                    {
                        if (zyPatlist.PatType == "4" || zyPatlist.PatType == "5")
                        {
                            throw new Exception("该病人已经办理了出院结算！");
                        }
                    }
                    if (patFee.retreatFee > 0 || patFee.receiveFee == 0)
                    {
                        throw new Exception("该病人没有欠费，不能办理欠费结算！");
                    }
                    #endregion
                    break;
            }

            FrmCostDiag fcd = new FrmCostDiag(_costType,this);
            fcd.ShowDialog();

            if (CheckFee() == false)
            {
                throw new Exception("该病人的费用发生变化，请重新核对后再结算！");
            }

            if (fcd.isDiag)
            {
                zyPatlist = IfrmCostDiagView.zyPatList;
                _patType = zyPatlist.PatientCode;
                int CostmasterID = CostPat((int)_costType, fcd);
                if (CostmasterID > 0)//住院中途结算
                {
                    if (IfrmCostDiagView.Ptt != PrintTicketType.不打发票)
                    {
                        IfrmCostView.CostPrint(CostmasterID);//打印发票
                    }
                    IfrmCostView.BrushPatList();
                }
                else
                {
                    throw new Exception("结算失败！");
                }
            }
        }

        #endregion

        #region FrmCostDiag

        public void OnLoadData(Action.CostType _costType)
        {
            IfrmCostDiagView.Initialize(_dataSet);

            IfrmCostDiagView.GroupBoxEnabled = true;
            IfrmCostDiagView.tbFeeEnabled = true;
            IfrmCostDiagView.tbPosEnabled = true;
            IfrmCostDiagView.tbExtraEnabled = true;

            //显示数据
            IfrmCostDiagView.zyPatList = zyPatlist;
            IfrmCostDiagView.patFee = patFee;
           
            //临床不允许输入出院信息
            if (zyConfig008 == 0)
            {
                IfrmCostDiagView.GroupBoxEnabled = false;
            }
            //金额置0
            IfrmCostDiagView.tbFee = 0;
            IfrmCostDiagView.tbPos = 0;
            IfrmCostDiagView.tbExtra = 0;
           
            //结算方式
            if (_costType == Action.CostType.中途结算)
            {
                IfrmCostDiagView.LabTitle = "中途结算";
                IfrmCostDiagView.tbFeeEnabled = false;
                IfrmCostDiagView.tbPosEnabled = false;
                IfrmCostDiagView.tbExtraEnabled = false;
            }
            else if (_costType == Action.CostType.出院结算)
            {
                IfrmCostDiagView.LabTitle = "出院结算";
                IfrmCostDiagView.tbExtraEnabled = false;

                //退费
                if (patFee.retreatFee > 0)
                {
                    IfrmCostDiagView.tbFeeEnabled = false;
                    IfrmCostDiagView.tbPosEnabled = false;
                    IfrmCostDiagView.tbFee = 0 - patFee.retreatFee;
                }
                //补收
                else if (patFee.receiveFee > 0)
                {
                    IfrmCostDiagView.tbFeeEnabled = false;
                    IfrmCostDiagView.tbFee = patFee.receiveFee;
                }

            }
            else if (_costType == Action.CostType.欠费结算)
            {
                IfrmCostDiagView.tbExtraEnabled = false;
                IfrmCostDiagView.LabTitle = "欠费结算";
                IfrmCostDiagView.tbExtra = patFee.receiveFee;
            }

           

        }

        #endregion
    }
}
