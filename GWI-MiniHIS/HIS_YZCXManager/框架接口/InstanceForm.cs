using System;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Interfaces;
using HIS.SYSTEM.PubicBaseClasses;
using HIS_YZCXManager;

namespace HIS_YZCXManager
{
    /// <summary>
    /// InstanceForm 的摘要说明。
    /// 该类是每个DLL供外界访问的接口函数类
    /// 名称不能改（包括大小写）
    /// </summary>
    public class InstanceForm : IXcObject
    {
        private string _functionName;
        private string _chineseName;
        private long _currentUserId;
        private long _currentDeptId;
        private long _menuId;
        private Form _mdiParent;

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

        #region IXcObject 成员(一定要在此实现)

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
            
            switch (_functionName)
            {
                case "Fxc_FrmDrugCheckQurey":
                    FrmDrugCheckQuery frmdrugcheckquery = new FrmDrugCheckQuery((int)_currentUserId);
                    frmdrugcheckquery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmdrugcheckquery.MdiParent = _mdiParent;
                    }
                    frmdrugcheckquery.Show();
                    break;
                case "Fxc_FrmDrugInOutQuery":
                    FrmDrugInOutQuery frmdruginoutquery = new FrmDrugInOutQuery(_currentUserId, _currentDeptId, _chineseName);
                    frmdruginoutquery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmdruginoutquery.MdiParent = _mdiParent;
                    }
                    frmdruginoutquery.Show();
                    break;
                case "Fxc_FrmManagerDiary":
                    FrmManagerDiary frmmanagerdiary = new FrmManagerDiary();
                    frmmanagerdiary.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmmanagerdiary.MdiParent = _mdiParent;
                    }
                    frmmanagerdiary.Show();
                    break;
                case "Fxc_FrmPatfeeQuery":
                    FrmZYPatfeeQuery frmpatfeequery = new FrmZYPatfeeQuery();
                    frmpatfeequery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmpatfeequery.MdiParent = _mdiParent;
                    }
                    frmpatfeequery.Show();
                    break;
                case "Fxc_FrmProjectfeeQuery":
                    FrmProjectfeeQurey frmprojectfeequery = new FrmProjectfeeQurey();
                    frmprojectfeequery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmprojectfeequery.MdiParent = _mdiParent;
                    }
                    frmprojectfeequery.Show();
                    break;
                case "Fxc_FrmStoreQuery":
                    FrmStoreQuery frmstorequery = new FrmStoreQuery();
                    frmstorequery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmstorequery.MdiParent = _mdiParent;
                    }
                    frmstorequery.Show();
                    break;
                case "Fxc_FrmDispStatQuery":
                    FrmDispStatQuery frmdispstatquery = new FrmDispStatQuery();
                    frmdispstatquery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmdispstatquery.MdiParent = _mdiParent;
                    }
                    frmdispstatquery.Show();
                    break;
                case "Fxc_FrmMZFeeQuery":
                    FrmMZFeeQuery frmmzfeequery = new FrmMZFeeQuery(1000, "门诊收入统计");
                    frmmzfeequery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmmzfeequery.MdiParent = _mdiParent;
                    }
                    frmmzfeequery.Show();
                    break;
                case "Fxc_FrmZYFeeQuery":
                    FrmZYFeeQuery frmzyfeequery = new FrmZYFeeQuery(_currentUserId, _currentDeptId, _chineseName);
                    frmzyfeequery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmzyfeequery.MdiParent = _mdiParent;
                    }
                    frmzyfeequery.Show();
                    break;
                case "Fxc_FrmMZRegister":
                    FrmMZRegister frmmzregister = new FrmMZRegister((int)_currentUserId, "门诊人次统计");
                    frmmzregister.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmmzregister.MdiParent = _mdiParent;
                    }
                    frmmzregister.Show();
                    break;
                case "Fxc_FrmMZPatFeeQuery":
                    FrmMZPatFeeQuery frmmzpatfeeQuery = new FrmMZPatFeeQuery((int)_currentUserId, "门诊病人费用查询");
                    frmmzpatfeeQuery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmmzpatfeeQuery.MdiParent = _mdiParent;
                    }
                    frmmzpatfeeQuery.Show();
                    break;
                default:
                    throw new Exception("引出函数名称错误！");
            }

        }
        /// <summary>
        /// 获得该Dll的信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "HIS_YZCXManager";
            objectInfo.Text = "院长查询系统";
            objectInfo.Remark = "院长查询系统";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[11];
            objectInfos[0].Name = "Fxc_FrmDrugCheckQurey";
            objectInfos[0].Text = "库房盘点查询";
            objectInfos[0].Remark = "库房盘点查询";

            objectInfos[1].Name = "Fxc_FrmDrugInOutQuery";
            objectInfos[1].Text = "库房入出库查询";
            objectInfos[1].Remark = "库房入出库查询";

            objectInfos[2].Name = "Fxc_FrmManagerDiary";
            objectInfos[2].Text = "院长日志";
            objectInfos[2].Remark = "院长日志";

            objectInfos[3].Name = "Fxc_FrmPatfeeQuery";
            objectInfos[3].Text = "住院病人费用查询";
            objectInfos[3].Remark = "住院病人费用查询";

            objectInfos[4].Name = "Fxc_FrmProjectfeeQuery";
            objectInfos[4].Text = "项目金额分析";
            objectInfos[4].Remark = "项目金额分析";

            objectInfos[5].Name = "Fxc_FrmStoreQuery";
            objectInfos[5].Text = "全院药品库存查询";
            objectInfos[5].Remark = "全院药品库存查询";

            objectInfos[6].Name = "Fxc_FrmDispStatQuery";
            objectInfos[6].Text = "药品销量统计";
            objectInfos[6].Remark = "药品销量统计";

            objectInfos[7].Name = "Fxc_FrmMZFeeQuery";
            objectInfos[7].Text = "门诊收入统计";
            objectInfos[7].Remark = "门诊收入统计";

            objectInfos[8].Name = "Fxc_FrmZYFeeQuery";
            objectInfos[8].Text = "住院收入统计";
            objectInfos[8].Remark = "住院收入统计";

            objectInfos[9].Name = "Fxc_FrmMZRegister";
            objectInfos[9].Remark = "门诊人次统计";
            objectInfos[9].Text = "门诊人次统计";

            objectInfos[10].Name = "Fxc_FrmMZPatFeeQuery";
            objectInfos[10].Remark = "门诊病人费用查询";
            objectInfos[10].Text = "门诊病人费用查询";
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
