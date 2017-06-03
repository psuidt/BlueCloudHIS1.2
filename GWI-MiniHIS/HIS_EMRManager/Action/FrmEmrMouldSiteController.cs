using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_EMRManager
{
    /// <summary>
    /// 病历模板设置控制器
    /// </summary>
    internal class FrmEmrMouldSiteController
    {
        private IFrmEmrMouldSiteView _view;  //病历模板设置界面接口

        public FrmEmrMouldSiteController(IFrmEmrMouldSiteView view)
        {
            _view = view;
            Public.PublicStaticFunction.CurrentEmployeeId = _view.currentUser.EmployeeID;
            Public.PublicStaticFunction.CurrentDeptId = _view.currentDept.DeptID;

            LoadBaseData();
            _view.MouldList = new HIS.EMR_BLL.EmrMould().GetAllMouldClass();
            _view.ElementList = new HIS.EMR_BLL.EmrElement().GetAllElement();
        }

        #region 整体模板
        /// <summary>
        /// 加载基础数据
        /// </summary>
        private void LoadBaseData()
        {
            _view.ChiefElement = new HIS.EMR_BLL.EmrElement().GetChiefElement();
        }
        /// <summary>
        /// 加载模板数据
        /// </summary>
        public void LoadMouldData()
        {
            _view.MouldList = new HIS.EMR_BLL.EmrMould().GetAllMouldClass(_view.CurrentMouldLevel,_view.currentUser.EmployeeID,_view.currentDept.DeptID);
        }
        /// <summary>
        /// 新增模板
        /// </summary>
        public void AddMould()
        {
            FrmEmrMouldInfo form = new FrmEmrMouldInfo();
            form.ShowDialog();
            if (form.IsSure)
            {
                HIS.EMR_BLL.EmrMould mould = new HIS.EMR_BLL.EmrMould();
                mould.MouldClass = -1;
                mould.MouldCreateDate = XcDate.ServerDateTime;
                mould.MouldCreateDept = (int)_view.currentDept.DeptID;
                mould.MouldCreateEmp = (int)_view.currentUser.EmployeeID;
                mould.MouldLevel = _view.CurrentMouldLevel;
                mould.MouldName = form.MouldName;
                mould.MouldType = _view.CurrentChiefElement.ElementCode;
                mould.MouldContent = EMRRecordControlFactory.CreateEMRRecordControl(_view.CurrentChiefElement.ElementCode).GetValue(); 
                mould.Add();
                _view.CurrentMould = mould;
                LoadMouldData();
            }
        }
        /// <summary>
        /// 删除模板
        /// </summary>
        public void DeleteMould()
        {
            _view.CurrentMould.Delete();
            _view.MouldList = new HIS.EMR_BLL.EmrMould().GetAllMouldClass();
        }
        /// <summary>
        /// 保存模板
        /// </summary>
        /// <returns></returns>
        public bool SaveMould()
        {
            _view.CurrentMould.Update();
            return true;
        }
        /// <summary>
        /// 重命名模板
        /// </summary>
        /// <returns></returns>
        public bool RenameMould()
        {
            FrmEmrMouldInfo form = new FrmEmrMouldInfo();
            form.ShowDialog();
            if (form.IsSure)
            {
                _view.CurrentMould.MouldName = form.MouldName;
                _view.CurrentMould.Update();
                return true;
            }
            return false;
        }
        #endregion

        #region 元素模板
        /// <summary>
        /// 加载元素数据
        /// </summary>
        public void LoadElementData()
        {
            _view.ElementList = new HIS.EMR_BLL.EmrElement().GetAllElement();
        }
        /// <summary>
        /// 加载元素模板数据
        /// </summary>
        public void LoadElementMouldData()
        {
            if (_view.CurrentElement != null)
            {
                _view.ElementMouldList = _view.CurrentElement.GetElementMould(_view.CurrentElementMouldLevel, _view.currentUser.EmployeeID, _view.currentDept.DeptID);
            }
        }
        /// <summary>
        /// 保存元素模板
        /// </summary>
        /// <param name="content">模板内容</param>
        public bool SaveElementMould(string content)
        {
            try
            {
                if (_view.CurrentElementMould != null)
                {
                    _view.CurrentElementMould.MouldContent = content;
                    _view.CurrentElementMould.Update();
                }
                else
                {
                    HIS.EMR_BLL.EmrElementMould mould = new HIS.EMR_BLL.EmrElementMould();
                    mould.MouldCreateDate = XcDate.ServerDateTime;
                    mould.MouldCreateDept = (int)_view.currentDept.DeptID;
                    mould.MouldCreateEmp = (int)_view.currentUser.EmployeeID;
                    mould.MouldLevel = _view.CurrentElementMouldLevel;
                    mould.MouldType = _view.CurrentElement.ElementCode;
                    mould.MouldContent = content;
                    mould.Add();
                }
                LoadElementMouldData();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 删除元素模板
        /// </summary>
        public void DeleteElementMould()
        {
            _view.CurrentElementMould.Delete();
            LoadElementMouldData();
        }
        #endregion
    }
}
