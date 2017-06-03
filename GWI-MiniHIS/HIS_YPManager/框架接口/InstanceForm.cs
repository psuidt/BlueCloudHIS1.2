using System;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Interfaces;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.YP_BLL;
using HIS_YPManager;

namespace HIS_YPManager
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
                #region 药房入库申请
                case "Fxc_FrmApplyMaster":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmYFApplyMaster frmyfapplymaster = new FrmYFApplyMaster(_currentUserId, _currentDeptId, _chineseName);
                    frmyfapplymaster.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmyfapplymaster.MdiParent = _mdiParent;
                    }
                    frmyfapplymaster.Show();
                    break;
                #endregion
                case "Fxc_FrmYFInMaster":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmInMaster FrmInMaster = new FrmInMaster(_currentUserId, _currentDeptId, _chineseName, ConfigManager.YF_SYSTEM);
                    FrmInMaster.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        FrmInMaster.MdiParent = _mdiParent;
                    }
                    FrmInMaster.Show();
                    break;
                case "Fxc_FrmYFOutMaster":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmOutMaster frmyfoutmaster = new FrmOutMaster(_currentUserId, _currentDeptId, _chineseName, ConfigManager.YF_SYSTEM);
                    frmyfoutmaster.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmyfoutmaster.MdiParent = _mdiParent;
                    }
                    frmyfoutmaster.Show();
                    break;
                case "Fxc_FrmYKInMaster":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmInMaster frmykinmaster = new FrmInMaster(_currentUserId, _currentDeptId, _chineseName, ConfigManager.YK_SYSTEM);
                    frmykinmaster.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmykinmaster.MdiParent = _mdiParent;
                    }
                    frmykinmaster.Show();
                    break;
                case "Fxc_FrmYKOutMaster":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmOutMaster frmykoutmaster = new FrmOutMaster(_currentUserId, _currentDeptId, _chineseName, ConfigManager.YK_SYSTEM);
                    frmykoutmaster.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmykoutmaster.MdiParent = _mdiParent;
                    }
                    frmykoutmaster.Show();
                    break;
                case "Fxc_FrmYFAdjMaster":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmYPAdjMaster frmyfadjmaster = new FrmYPAdjMaster(_currentUserId, _currentDeptId, _chineseName, ConfigManager.YF_SYSTEM);
                    frmyfadjmaster.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmyfadjmaster.MdiParent = _mdiParent;
                    }
                    frmyfadjmaster.Show();
                    break;
                case "Fxc_FrmYKAdjMaster":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmYPAdjMaster frmykadjmaster = new FrmYPAdjMaster(_currentUserId, _currentDeptId, _chineseName, ConfigManager.YK_SYSTEM);
                    frmykadjmaster.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmykadjmaster.MdiParent = _mdiParent;
                    }
                    frmykadjmaster.Show();
                    break;
                case "Fxc_FrmYFMonthAccount":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmMonthAccount frmyfmonthaccount = new FrmMonthAccount(ConfigManager.YF_SYSTEM, _currentUserId, _currentDeptId);
                    frmyfmonthaccount.Show();
                    break;
                case "Fxc_FrmYKMonthAccount":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmMonthAccount frmykmonthaccount = new FrmMonthAccount(ConfigManager.YK_SYSTEM, _currentUserId, _currentDeptId);
                    frmykmonthaccount.Show();
                    break;
                case "Fxc_FrmProductDic":
                    FrmProductDic frmproductdic = new FrmProductDic();
                    frmproductdic.ShowDialog();
                    break;
                case "Fxc_FrmSupportDic":
                    FrmSupportDic frmsupportdic = new FrmSupportDic();
                    frmsupportdic.ShowDialog();
                    break;
                case "Fxc_FrmYKCheckMaster":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmCheckMaster frmYKCheckMaster = new FrmCheckMaster(_currentUserId, _currentDeptId, _chineseName,
                        ConfigManager.YK_SYSTEM);
                    frmYKCheckMaster.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmYKCheckMaster.MdiParent = _mdiParent;
                    }
                    frmYKCheckMaster.Show();
                    break;
                case "Fxc_FrmYFCheckMaster":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmCheckMaster frmYFCheckMaster = new FrmCheckMaster(_currentUserId, _currentDeptId, _chineseName,
                        ConfigManager.YF_SYSTEM);
                    frmYFCheckMaster.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmYFCheckMaster.MdiParent = _mdiParent;
                    }
                    frmYFCheckMaster.Show();
                    break;
                case "Fxc_FrmDrugDic":
                    FrmDrugSpec frmspec = new FrmDrugSpec(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmspec.MdiParent = _mdiParent;
                        frmspec.WindowState = FormWindowState.Maximized;
                    }
                    frmspec.Show();
                    break;
                case "Fxc_ZYFrmDrugDispense":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    ZYFrmDrugDispense frmDispense = new ZYFrmDrugDispense(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmDispense.MdiParent = _mdiParent;
                    }
                    frmDispense.WindowState = FormWindowState.Maximized;
                    frmDispense.Show();
                    break;
                case "Fxc_ZYFrmDrugDispenseJG":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    ZYFrmDrugDispenseJG frmDispenseJG = new ZYFrmDrugDispenseJG(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmDispenseJG.MdiParent = _mdiParent;
                    }
                    frmDispenseJG.WindowState = FormWindowState.Maximized;
                    frmDispenseJG.Show();
                    break;
                case "Fxc_MZFrmDrugDispense":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    MZFrmDrugDispense frmmzDispense = new MZFrmDrugDispense(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmmzDispense.MdiParent = _mdiParent;
                    }
                    frmmzDispense.WindowState = FormWindowState.Maximized;
                    frmmzDispense.Show();
                    break;
                case "Fxc_ZYFrmDrugRefund":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    ZYFrmDrugRefund zyfrmRefund = new ZYFrmDrugRefund(_currentUserId, _currentDeptId, _chineseName);
                    zyfrmRefund.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        zyfrmRefund.MdiParent = _mdiParent;
                    }
                    zyfrmRefund.Show();
                    break;

                case "Fxc_FrmYFOrderAccount":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmOrderAccount frmyforderaccount = new FrmOrderAccount(_currentDeptId, _chineseName, ConfigManager.YF_SYSTEM);
                    frmyforderaccount.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmyforderaccount.MdiParent = _mdiParent;
                    }
                    frmyforderaccount.Show();
                    break;
                case "Fxc_FrmYKOrderAccount":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmOrderAccount frmykorderaccount = new FrmOrderAccount(_currentDeptId, _chineseName, ConfigManager.YK_SYSTEM);
                    frmykorderaccount.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmykorderaccount.MdiParent = _mdiParent;
                    }
                    frmykorderaccount.Show();
                    break;
                case "Fxc_FrmYFStoreQuery":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmStoreQuery frmyfstorequery = new FrmStoreQuery(_currentUserId, _currentDeptId, _chineseName, ConfigManager.YF_SYSTEM);
                    frmyfstorequery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmyfstorequery.MdiParent = _mdiParent;
                    }
                    frmyfstorequery.Show();
                    break;
                case "Fxc_FrmYKStoreQuery":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmStoreQuery frmykstorequery = new FrmStoreQuery(_currentUserId, _currentDeptId, _chineseName, ConfigManager.YK_SYSTEM);
                    frmykstorequery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmykstorequery.MdiParent = _mdiParent;
                    }
                    frmykstorequery.Show();
                    break;
                case "Fxc_FrmYFIOSQuery":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmIOSQuery frmyfiosquery = new FrmIOSQuery(_currentUserId, _currentDeptId,
                        _chineseName, ConfigManager.YF_SYSTEM);
                    frmyfiosquery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmyfiosquery.MdiParent = _mdiParent;
                    }
                    frmyfiosquery.Show();
                    break;
                case "Fxc_FrmYKIOSQuery":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmIOSQuery frmykiosquery = new FrmIOSQuery(_currentUserId, _currentDeptId,
                        _chineseName, ConfigManager.YK_SYSTEM);
                    frmykiosquery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmykiosquery.MdiParent = _mdiParent;
                    }
                    frmykiosquery.Show();
                    break;
                case "Fxc_FrmDrugDept":
                    FrmDrugDept frmdrugdept = new FrmDrugDept(_currentUserId, _currentDeptId, _chineseName);
                    frmdrugdept.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmdrugdept.MdiParent = _mdiParent;
                    }
                    frmdrugdept.Show();
                    break;
                case "Fxc_FrmYKSetStoreLimit":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmSetStoreLimit frmyksetstorelimit = new FrmSetStoreLimit(_currentUserId, _currentDeptId,
                        _chineseName, ConfigManager.YK_SYSTEM);
                    frmyksetstorelimit.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmyksetstorelimit.MdiParent = _mdiParent;
                    }
                    frmyksetstorelimit.Show();
                    break;
                case "Fxc_FrmYFSetStoreLimit":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmSetStoreLimit frmyfsetstorelimit = new FrmSetStoreLimit(_currentUserId, _currentDeptId,
                        _chineseName, ConfigManager.YF_SYSTEM);
                    frmyfsetstorelimit.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmyfsetstorelimit.MdiParent = _mdiParent;
                    }
                    frmyfsetstorelimit.MdiParent = _mdiParent;
                    break;
                case "Fxc_FrmDispenseQuery":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmDispenseQuery frmdispenseQuery = new FrmDispenseQuery(_currentUserId, _currentDeptId, _chineseName);
                    frmdispenseQuery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmdispenseQuery.MdiParent = _mdiParent;
                    }
                    frmdispenseQuery.Show();
                    break;
                case "Fxc_FrmYKStoreLimitQuery":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmStoreLimitQuery frmykstorelimitquery = new FrmStoreLimitQuery(_chineseName,
                        _currentUserId, _currentDeptId, ConfigManager.YK_SYSTEM);
                    if (_mdiParent != null)
                    {
                        frmykstorelimitquery.MdiParent = _mdiParent;
                    }
                    frmykstorelimitquery.Show();
                    break;
                case "Fxc_FrmYFStoreLimitQuery":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmStoreLimitQuery frmyfstorelimitquery = new FrmStoreLimitQuery(_chineseName,
                        _currentUserId, _currentDeptId, ConfigManager.YF_SYSTEM);
                    if (_mdiParent != null)
                    {
                        frmyfstorelimitquery.MdiParent = _mdiParent;
                    }
                    frmyfstorelimitquery.Show();
                    break;
                case "Fxc_FrmValidityDate":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmValidityDate frmvaliditydate = new FrmValidityDate(_currentUserId, _currentDeptId, _chineseName);
                    frmvaliditydate.ShowDialog();
                    break;
                case "Fxc_MZFrmDrugRefund":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YF_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    MZFrmDrugRefund mzfrmdrugrefund = new MZFrmDrugRefund(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        mzfrmdrugrefund.MdiParent = _mdiParent;
                    }
                    mzfrmdrugrefund.Show();
                    break;
                case "Fxc_FrmStockPlan":
                    if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    {
                        throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    }
                    FrmStockPlan frmstockplan = new FrmStockPlan(_currentUserId, _currentDeptId, false);
                    frmstockplan.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmstockplan.MdiParent = _mdiParent;
                    }
                    frmstockplan.Show();
                    break;

                case "Fxc_FrmProductIOQuery":
                    //if (!DrugBaseDataBll.CheckRegDept(ConfigManager.YK_SYSTEM, _currentDeptId))
                    //{
                    //    throw new Exception("登陆科室错误，请选择正确的药剂科室登陆！");
                    //}
                  
                    FrmProductIOQuery frmproductquery = new FrmProductIOQuery(_currentUserId, _currentDeptId);
                    frmproductquery.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmproductquery.MdiParent = _mdiParent;
                    }
                    frmproductquery.Show();
                    break;

                case "Fxc_ZyFrmPresDispense":
                    ZYFrmPresDispense frmpres = new ZYFrmPresDispense(_currentUserId, _currentDeptId);

                    frmpres.WindowState = FormWindowState.Maximized;
                    if (_mdiParent != null)
                    {
                        frmpres.MdiParent = _mdiParent;
                    }
                    frmpres.Show();
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
            objectInfo.Name = "HIS_YPManager";
            objectInfo.Text = "药品系统";
            objectInfo.Remark = "药品系统";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[35];
            objectInfos[0].Name = "Fxc_FrmApplyMaster";
            objectInfos[0].Text = "药房申请入库";
            objectInfos[0].Remark = "药房申请入库";

            objectInfos[1].Name = "Fxc_FrmYKOutMaster";
            objectInfos[1].Text = "药库出库";
            objectInfos[1].Remark = "药库出库";

            objectInfos[2].Name = "Fxc_FrmYFAdjMaster";
            objectInfos[2].Text = "药品调价";
            objectInfos[2].Remark = "药品调价";

            objectInfos[3].Name = "Fxc_FrmYFMonthAccount";
            objectInfos[3].Text = "药房系统月结";
            objectInfos[3].Remark = "药房系统月结";

            objectInfos[4].Name = "Fxc_FrmProductDic";
            objectInfos[4].Text = "药品生产商维护";
            objectInfos[4].Remark = "药品生产商维护";

            objectInfos[5].Name = "Fxc_FrmSupportDic";
            objectInfos[5].Text = "药品供应商维护";
            objectInfos[5].Remark = "药品供应商维护";

            objectInfos[6].Name = "Fxc_FrmYFCheckMaster";
            objectInfos[6].Text = "药房盘点";
            objectInfos[6].Remark = "药房盘点";

            objectInfos[7].Name = "Fxc_FrmDrugDic";
            objectInfos[7].Text = "药品字典维护";
            objectInfos[7].Remark = "药品字典维护";

            objectInfos[8].Name = "Fxc_ZYFrmDrugDispense";
            objectInfos[8].Text = "药房住院发药";
            objectInfos[8].Remark = "药房住院发药";

            objectInfos[9].Name = "Fxc_ZYFrmDrugRefund";
            objectInfos[9].Text = "药房住院退药";
            objectInfos[9].Remark = "药房住院退药";

            objectInfos[10].Name = "Fxc_FrmYFOrderAccount";
            objectInfos[10].Text = "药品明细账查询";
            objectInfos[10].Remark = "药品明细账查询";

            objectInfos[11].Name = "Fxc_FrmYFStoreQuery";
            objectInfos[11].Text = "药品库存查询";
            objectInfos[11].Remark = "药品库存查询";

            objectInfos[12].Name = "Fxc_FrmYFIOSQuery";
            objectInfos[12].Text = "药品进销存查询";
            objectInfos[12].Remark = "药品进销存查询";

            objectInfos[13].Name = "Fxc_FrmYKInMaster";
            objectInfos[13].Text = "药库入库";
            objectInfos[13].Remark = "药库入库";

            objectInfos[14].Name = "Fxc_FrmYKCheckMaster";
            objectInfos[14].Text = "药库盘点";
            objectInfos[14].Remark = "药库盘点";

            objectInfos[15].Name = "Fxc_FrmYFInMaster";
            objectInfos[15].Text = "药房期初入库";
            objectInfos[15].Remark = "药房期初入库";

            objectInfos[16].Name = "Fxc_FrmYFOutMaster";
            objectInfos[16].Text = "药房出库";
            objectInfos[16].Remark = "药房出库";

            objectInfos[17].Name = "Fxc_FrmYKAdjMaster";
            objectInfos[17].Text = "药品调价";
            objectInfos[17].Remark = "药品调价";

            objectInfos[18].Name = "Fxc_FrmYKIOSQuery";
            objectInfos[18].Text = "药品进销存查询";
            objectInfos[18].Remark = "药品进销存查询";

            objectInfos[19].Name = "Fxc_FrmYKOrderAccount";
            objectInfos[19].Text = "药品明细账查询";
            objectInfos[19].Remark = "药品明细账查询";

            objectInfos[20].Name = "Fxc_FrmYKStoreQuery";
            objectInfos[20].Text = "药品库存查询";
            objectInfos[20].Remark = "药品库存查询";

            objectInfos[21].Name = "Fxc_FrmDrugDept";
            objectInfos[21].Text = "药剂科室设置";
            objectInfos[21].Remark = "药剂科室设置";

            objectInfos[22].Name = "Fxc_FrmYKSetStoreLimit";
            objectInfos[22].Text = "药库库存上下限设置";
            objectInfos[22].Remark = "药库库存上下限设置";

            objectInfos[23].Name = "Fxc_FrmYFSetStoreLimit";
            objectInfos[23].Text = "药房库存上下限设置";
            objectInfos[23].Remark = "药房库存上下限设置";

            objectInfos[24].Name = "Fxc_FrmYKMonthAccount";
            objectInfos[24].Text = "药库系统月结";
            objectInfos[24].Remark = "药库系统月结";

            objectInfos[25].Name = "Fxc_FrmDispenseQuery";
            objectInfos[25].Text = "药房发药查询";
            objectInfos[25].Remark = "药房发药查询";

            objectInfos[26].Name = "Fxc_FrmYKStoreLimitQuery";
            objectInfos[26].Text = "药库库位高低储报警";
            objectInfos[26].Remark = "药库库位高低储报警";

            objectInfos[27].Name = "Fxc_FrmYFStoreLimitQuery";
            objectInfos[27].Text = "药房库位高低储报警";
            objectInfos[27].Remark = "药房库位高低储报警";

            objectInfos[28].Name = "Fxc_FrmValidityDate";
            objectInfos[28].Text = "药品效期报警";
            objectInfos[28].Remark = "药品效期报警";

            objectInfos[29].Name = "Fxc_MZFrmDrugDispense";
            objectInfos[29].Text = "药房门诊发药";
            objectInfos[29].Remark = "药房门诊发药";

            objectInfos[30].Name = "Fxc_MZFrmDrugRefund";
            objectInfos[30].Text = "药房门诊退药";
            objectInfos[30].Remark = "药房门诊退药";

            objectInfos[31].Name = "Fxc_FrmStockPlan";
            objectInfos[31].Text = "制定采购计划";
            objectInfos[31].Remark = "药库制定采购计划";

            objectInfos[32].Name = "Fxc_ZYFrmDrugDispenseJG";
            objectInfos[32].Text = "药房住院发药(非消息统领)";
            objectInfos[32].Remark = "药房住院发药(非消息统领)";

            objectInfos[33].Name = "Fxc_FrmProductIOQuery";
            objectInfos[33].Text = "西成药采购按供应商统计";
            objectInfos[33].Remark = "西成药采购按供应商统计";

            objectInfos[33].Name = "Fxc_ZyFrmPresDispense";
            objectInfos[33].Text = "住院中草药发药";
            objectInfos[33].Remark = "住院中草药发药";

            return objectInfos;
        }
        #endregion

        #endregion
    }
}