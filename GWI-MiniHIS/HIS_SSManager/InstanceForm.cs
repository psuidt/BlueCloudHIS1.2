using System;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Interfaces;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_SSManager
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
            HIS_SSManager.FrmSsMain ssmain = null;
            HIS_SSManager.FrmSsRoom ssroom = null;
            HIS_SSManager.FrmRepot report = null;
            switch (_functionName)
            {
                case "Fun_SsMain":
                    ssmain = new FrmSsMain(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        ssmain.MdiParent = _mdiParent;
                    }
                    ssmain.WindowState = FormWindowState.Maximized;
                    ssmain.Show();
                    break;
                case "Fun_SsRoom":
                    ssroom = new FrmSsRoom(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        ssroom.MdiParent = _mdiParent;
                    }
                    ssroom.WindowState = FormWindowState.Maximized;
                    ssroom.Show();
                    break;
                case "Fun_SsReport":
                    report = new FrmRepot(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        report.MdiParent = _mdiParent;
                    }
                    report.WindowState = FormWindowState.Maximized;
                    report.Show();
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
            objectInfo.Name = "HIS_SSManager";
            objectInfo.Text = "手术麻醉系统";
            objectInfo.Remark = "手术麻醉系统";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[3];

            objectInfos[0].Name = "Fun_SsMain";
            objectInfos[0].Text = "手术麻醉主界面";
            objectInfos[0].Remark = "";

            objectInfos[1].Name = "Fun_SsRoom";
            objectInfos[1].Text = "手术室房间台次维护";
            objectInfos[1].Remark = "";

            objectInfos[2].Name = "Fun_SsReport";
            objectInfos[2].Text = "手术室费用统计";
            objectInfos[2].Remark = "";   

            return objectInfos;
        }
        #endregion

    }
}
