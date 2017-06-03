using System;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Interfaces;
using HIS.SYSTEM.PubicBaseClasses;

namespace  HIS_ZYDocManager  
{
    /// <summary>
    /// InstanceForm 的摘要说明。
    /// 该类是每个DLL供外界访问的接口函数类
    /// 名称不能改（包括大小写）
    /// </summary>
    public class InstanceForm : IInnerCommunicate
    {   
        
        private string _functionName;
        private string _chineseName;
        private long _currentUserId;
        private long _currentDeptId;
        private long _menuId;
        private Form _mdiParent;
        private object[] _communicateValue;
        public InstanceForm()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            _functionName = "";
            _chineseName = "";
            _currentUserId = -1;
            _currentDeptId = -1;
            _menuId = -1;
            _mdiParent = null;
        }

       #region IInnerCommunicate 成员(一定要在此实现)

        #region 属性
        /// <summary>
        /// 实例化窗体函数名称
        /// </summary>
        public string FunctionName
        {
            get
            {
                return _functionName;
            }
            set
            {
                _functionName = value;
            }
        }
        /// <summary>
        /// 窗体中文名称
        /// </summary>
        public string ChineseName
        {
            get
            {
                return _chineseName;
            }
            set
            {
                _chineseName = value;
            }
        }
        /// <summary>
        /// 当前操作员ID
        /// </summary>
        public long CurrentUserId
        {
            get
            {
                return _currentUserId;
            }
            set
            {
                _currentUserId = value;
            }
        }
        /// <summary>
        /// 当前操作科室ID
        /// </summary>
        public long CurrentDeptId
        {
            get
            {
                return _currentDeptId;
            }
            set
            {
                _currentDeptId = value;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public long MenuId
        {
            get
            {
                return _menuId;
            }
            set
            {
                _menuId = value;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public Form MdiParent
        {
            get
            {
                return _mdiParent;
            }
            set
            {
                _mdiParent = value;
            }
        }
        #endregion


         /// <summary>
        /// 内部通信参数
        /// </summary>
        public object[] CommunicateValue
        {
            get
            {
                return _communicateValue;
            }
            set
            {
                _communicateValue = value;
            }
        }
        #endregion


        #region 函数
        /// <summary>
        /// 根据函数名称实例化窗体
        /// </summary>
        public void InstanceXcForm()
        {
            if (_functionName == "")
            {
                throw new Exception("引出函数名不能为空！");
            }      
            HIS_ZYDocManager.基础数据.FrmDocModel frmDocModel = null;
            HIS_ZYDocManager.日常业务.FrmDocMain frmDocFirst = null;
            HIS_ZYDocManager.查询统计.FrmDocWorkQuery frmdocquery = null;
            HIS_ZYDocManager.查询统计.FrmPatientInfo frmPatientInfo = null;
            switch (_functionName)
            {
                case "Fun_DocOrder":
                    frmDocFirst = new HIS_ZYDocManager.日常业务.FrmDocMain(_currentUserId, _currentDeptId, _chineseName);

                    if (_mdiParent != null)
                    {
                        frmDocFirst.MdiParent = _mdiParent;
                    }
                    frmDocFirst.WindowState = FormWindowState.Maximized;
                    frmDocFirst.Show();
                    break;
                case "Fun_DocModel":
                    frmDocModel = new HIS_ZYDocManager.基础数据.FrmDocModel(_currentUserId, _currentDeptId, _chineseName);
                    
                    if (_mdiParent != null)
                    {
                        frmDocModel.MdiParent = _mdiParent;
                    }
                    frmDocModel.WindowState = FormWindowState.Maximized;
                    frmDocModel.Show();
                    break;
                case "Fun_DocWork":
                    frmdocquery = new HIS_ZYDocManager.查询统计.FrmDocWorkQuery(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmdocquery.MdiParent = _mdiParent;
                    }
                    frmdocquery.WindowState = FormWindowState.Maximized;
                    frmdocquery.Show();
                    break;
                case "Fun_PatientFee":
                    frmPatientInfo = new HIS_ZYDocManager.查询统计.FrmPatientInfo(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmPatientInfo.MdiParent = _mdiParent;
                    }
                    frmPatientInfo.WindowState = FormWindowState.Maximized;
                    frmPatientInfo.Show();
                    break;
              
                default:
                    throw new Exception("引出函数名称错误！");
            }

        }
         /// <summary>
        /// 返回一个FORM对象
        /// </summary>
        /// <returns></returns>
        public object GetObject()
        {
            return null;
        }
        /// <summary>
        /// 获得该Dll的信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "HIS_ZYDocManager";
            objectInfo.Text = "住院医生站系统";
            objectInfo.Remark = "电子医嘱管理";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[4];

            objectInfos[0].Name = "Fun_DocOrder";
            objectInfos[0].Text = "诊疗管理";
            objectInfos[0].Remark = "";

            objectInfos[1].Name = "Fun_DocModel";
            objectInfos[1].Text="医生模板维护";
            objectInfos[1].Remark = "";

            objectInfos[2].Name = "Fun_DocWork";
            objectInfos[2].Text = "医生工作量统计";
            objectInfos[2].Remark = "";

            objectInfos[3].Name = "Fun_PatientFee";
            objectInfos[3].Text = "病人相关信息统计";
                
            return objectInfos;
        }
        #endregion

    }
}
