using System;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Interfaces;
using HIS.SYSTEM.PubicBaseClasses;
using HIS_PublicManager.SystemTool.DBClient;

namespace HIS_PublicManager
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
            if ( _functionName == "" )
            {
                throw new Exception( "引出函数名不能为空！" );
            }
            

            GWMHIS.BussinessLogicLayer.Classes.User currentUser = new GWMHIS.BussinessLogicLayer.Classes.User( _currentUserId );
            GWMHIS.BussinessLogicLayer.Classes.Deptment currentDept = new GWMHIS.BussinessLogicLayer.Classes.Deptment( _currentDeptId );
            switch (_functionName)
            {
                case "Fun_Public_ReportPrinterSet":
                    FrmReportPrinterSet fSet = new FrmReportPrinterSet();
                    fSet.ShowDialog();
                    break;
                case "Fxc_FrmFavorable":
                    FrmFavorable frmFavorable = new FrmFavorable();
                    if (_mdiParent != null)
                    {
                        frmFavorable.MdiParent = _mdiParent;
                    }
                    frmFavorable.WindowState = FormWindowState.Maximized;
                    frmFavorable.Show();
                    break;
                case "Fxc_FrmPatientType":
                    FrmPatientType frmPt = new FrmPatientType();
                    if (_mdiParent != null)
                    {
                        frmPt.MdiParent = _mdiParent;
                    }
                    frmPt.WindowState = FormWindowState.Maximized;
                    frmPt.Show();
                    break;
                case "Fxc_FrmformulaManager":
                    FrmformulaManager frmformula = new FrmformulaManager();
                    if (_mdiParent != null)
                    {
                        frmformula.MdiParent = _mdiParent;
                    }
                    frmformula.WindowState = FormWindowState.Maximized;
                    frmformula.Show();
                    break;
                case "Fxc_FrmClient":
                    string value = GWMHIS.BussinessLogicLayer.Forms.DlgInputBoxStatic.InputBox("输入使用密码?", "数据库维护", "", false, true, '*');
                    if (value != null  && value!="" )
                    {
                        if (value.Trim() == "kakake!@#$%^")
                        {
                            FrmClient fc = new FrmClient();
                            if (_mdiParent != null)
                            {
                                fc.MdiParent = _mdiParent;
                            }
                            fc.WindowState = FormWindowState.Maximized;
                            fc.Show();
                        }
                        else
                        {
                            MessageBox.Show("密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                  
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
            objectInfo.Name = "HIS_PublicManager";
            objectInfo.Text = "门诊公共设置";
            objectInfo.Remark = "";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[5];
            objectInfos[0].Name = "Fun_Public_ReportPrinterSet";
            objectInfos[0].Text = "报表打印机设置";
            objectInfos[0].Remark = "";

            objectInfos[1].Name = "Fxc_FrmFavorable";
            objectInfos[1].Text = "优惠项目维护";
            objectInfos[1].Remark = "优惠项目维护";

            objectInfos[2].Name = "Fxc_FrmPatientType";
            objectInfos[2].Text = "病人类型维护";
            objectInfos[2].Remark = "病人类型维护";

            objectInfos[3].Name = "Fxc_FrmformulaManager";
            objectInfos[3].Text = "记账计算公式维护";
            objectInfos[3].Remark = "记账计算公式维护";


            objectInfos[4].Name = "Fxc_FrmClient";
            objectInfos[4].Text = "数据库客户端";
            objectInfos[4].Remark = "数据库客户端";   
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
