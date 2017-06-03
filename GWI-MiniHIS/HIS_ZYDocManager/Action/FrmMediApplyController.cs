using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYDoc_BLL;
using GWI.HIS.Windows.Controls;

namespace HIS_ZYDocManager.Action
{
    public  class FrmMediApplyController
    {
        private HIS.Model.ZY_PatList zy_Patlist;
        private IFrmMediApplyView view;
        private DataSet _dataSet;
        private HIS.ZYDoc_BLL.MediApply.IMediApply applyop;
        private HIS.ZYDoc_BLL.BaseInfo.MediApplyBase applybase;       
        public FrmMediApplyController(IFrmMediApplyView _view,HIS.ZYDoc_BLL.MediApply.MediType meditype)
        {
            view = _view;
            _dataSet = new DataSet();
            zy_Patlist = view.zy_patlist_get;
            applyop = new HIS.ZYDoc_BLL.MediApply.ApplyOP();
            applybase = new HIS.ZYDoc_BLL.BaseInfo.MediApplyBase();
            LoadINFO(meditype);
        }

        #region 加载数据
       /// <summary>
        /// 加载数据
       /// </summary>
       /// <param name="meditype"></param>
        private void LoadINFO(HIS.ZYDoc_BLL.MediApply.MediType meditype)
        {
            DataTable tb = null;
            tb =applyop.GetDept(meditype);
            tb.TableName = "Dept";
            if (_dataSet.Tables.Contains("Dept"))
            {
                _dataSet.Tables.Remove("Dept");
            }
            _dataSet.Tables.Add(tb);

            tb = applyop.GetMediType(meditype);
            tb.TableName = "Type";
            if (_dataSet.Tables.Contains("Type"))
            {
                _dataSet.Tables.Remove("Type");
            }
            _dataSet.Tables.Add(tb);

            tb = applybase.GetMediClass();
            tb.TableName = "MediClass";
            if (_dataSet.Tables.Contains("MediClass"))
            {
                _dataSet.Tables.Remove("MediClass");
            }
            _dataSet.Tables.Add(tb);
        }
        #endregion

        #region 获得病人信息
        /// <summary>
        /// 获得病人信息
        /// </summary>
        public void GetPatlist()
        {
            zy_Patlist = view.zy_patlist_get;
            if (zy_Patlist != null)
            {
                view.BindPatControlData = zy_Patlist;
                HIS.ZY_BLL.ObjectModel.CostManager.IcostManager IcM = HIS.ZY_BLL.ObjectModel.ObjectFactory.GetObject<HIS.ZY_BLL.ObjectModel.CostManager.IcostManager>(typeof(HIS.ZY_BLL.DataModel.ZY_CostMaster));
                IcM.PatListID = zy_Patlist.PatListID;
                view.BindPatFeeControlData = IcM.GetPatFee();
            }
        }
        #endregion

        public void BindData()
        {
            view.Initialize(_dataSet);
        }
        public void getDept()
        {
            view.getDept(_dataSet);
        }

        #region 获得相应医技项目
        /// <summary>
        /// 获得相应医技项目
        /// </summary>
        /// <param name="sign">1=检查项目　2=检验项目　3=治疗项目</param>
        /// <param name="deptId"></param>
        /// <param name="medicalClass"></param>
        /// <returns></returns>
        public DataTable Items(HIS.ZYDoc_BLL.MediApply.MediType meditype, int deptId, int medicalClass)
        {
            DataTable items = applyop.GetItems(meditype, deptId, medicalClass);
            return items;
        }
        #endregion

        #region 获得标本
        public DataTable Sample()
        {
            return applybase.GetSample();
        }
        #endregion

        #region  获得附加说明
        public DataTable Param()
        {
            return applybase.GetParam();
        }
        #endregion

        #region 判断病人是否出院
        /// <summary>
        /// 判断病人是否出院
        /// </summary>
        /// <returns></returns>
        public  bool IsNotCanUse()
        {
            string type=zy_Patlist.PatType;
            if (type=="7" || type=="3" || type=="4" || type=="5" || HIS.ZYDoc_BLL.PatInfo.PatOperation.IsTurnDept(zy_Patlist.PatListID))
            {          
                    return true;               
            }
            else
            {
                return false;
            }
        }
        #endregion

        public string GetItemName(int itemid)
        {
            return applybase.GetItemClass(itemid);
        }
        public DataTable GetCheckPlace()
        {
            return applybase.getCheckPlace();
        }

        //检查申请提交
        public bool SaveCheck(List<HIS.Model.ZY_DOC_ORDERRECORD> orders,List<HIS.Model.ZY_DOC_CHECKAPPLY> applys)
        {
            return applyop.SaveCheck(orders, zy_Patlist, applys);
        }
        //检验申请提交
        public bool SaveTest(List<HIS.Model.ZY_DOC_ORDERRECORD> orders, List<HIS.Model.ZY_DOC_TESTAPPLY> applys)
        {
            return applyop.SaveTest(orders, zy_Patlist, applys);
        }

        public bool SaveCure(List<HIS.Model.ZY_DOC_ORDERRECORD> orders)
        {
            return applyop.SaveCure(orders, zy_Patlist);
        }

        public DataTable FindOrders(HIS.ZYDoc_BLL.MediApply.MediType meditype,DateTime ?Bdate,DateTime ?Edate)
        {
            return applyop.GetOrders(zy_Patlist.PatListID, meditype, Bdate, Edate);
        }

        public bool ConnectPacs()
        {
            return applybase.IsPacs();
        }
        public bool ConnectLis()
        {
            return applybase.IsLis();
        }
        public void CheckPrint(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string state, string palce, string deptname, string tjjg, string Xjg, string hyjg, string othercheck)
        {
            applyop.CheckPrint(path, patlist, applys, dtime, name, state, palce, deptname, tjjg, Xjg, hyjg, othercheck);
        }
        public void TestPrint(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string sample, string deptname, string diagname)
        {
            applyop.TestPrint(path, patlist, applys, dtime, name, sample, deptname, diagname);
        }
        public void CurePrint(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string state)
        {
            applyop.CurePrint(path, patlist, applys, dtime, name, state);
        }
    }
}
