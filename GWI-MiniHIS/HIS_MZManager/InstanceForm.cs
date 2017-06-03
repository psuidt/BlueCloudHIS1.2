using System;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Interfaces;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_MZManager
{
    public enum FormType
    {
        门诊划价,
        门诊收费,
        门诊医生
    }
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
            HIS_MZManager.HJSF.FrmHJSF frmHJSF = null;

            HIS_MZManager.Account.FrmAccount frmAccount = null;
            HIS_MZManager.Query.FrmInvoiceQuery frmInvoiceQuery = null;
            HIS_MZManager.Query.FrmPrescriptionQuery frmPrescriptionQuery = null;
            HIS_MZManager.Account.FrmAllAccount frmAllAccount = null;
            HIS_MZManager.GH.FrmMzgh frmGh = null;
            HIS_MZManager.InvoiceManager.FrmInvoiceManager frmInvoiceManager = null;
            HIS_MZManager.HJSF.FrmUnCharge frmDisCharge = null;
            HIS_MZManager.HJSF.FrmSetting frmSetting = null;
            
            HIS_MZManager.Report.FrmRegisterReport frmRegReport = null;
            HIS_MZManager.FrmDownLoad fDownLoad = null;
            HIS_MZManager.Report.FrmReport frmIncomeReport = null;
            HIS_MZManager.Query.FrmPatientFeeQuery frmPatientFeeQuery = null;
            HIS_MZManager.Report.FrmPatientFeeReport frmPatientFeeReport = null;
            //HIS_MZManager.HJSF.FrmBudgetBalance frmBudgetBalance;
            HIS_MZManager.Report.FrmPerformSectionIncomeReport frmPerformSectionReport;
            

            GWMHIS.BussinessLogicLayer.Classes.User currentUser = new GWMHIS.BussinessLogicLayer.Classes.User( _currentUserId );
            GWMHIS.BussinessLogicLayer.Classes.Deptment currentDept = new GWMHIS.BussinessLogicLayer.Classes.Deptment( _currentDeptId );
            switch ( _functionName )
            {
                case "Fun_MZHJ":
                    frmHJSF = new HIS_MZManager.HJSF.FrmHJSF( _chineseName , FormType.门诊划价 , currentUser , currentDept );
                    if ( _mdiParent != null )
                    {
                        frmHJSF.MdiParent = _mdiParent;
                    }
                    frmHJSF.WindowState = FormWindowState.Maximized;
                    frmHJSF.BringToFront( );
                    frmHJSF.Show( );
                    break;
                case "Fun_MZSF":
                    frmHJSF = new HIS_MZManager.HJSF.FrmHJSF(_chineseName, FormType.门诊收费, currentUser, currentDept);
                    if (_mdiParent != null)
                    {
                        frmHJSF.MdiParent = _mdiParent;
                    }
                    frmHJSF.WindowState = FormWindowState.Maximized;
                    frmHJSF.BringToFront();
                    frmHJSF.Show();

                    break;
                case "Fun_MZYS":
                    frmHJSF = new HIS_MZManager.HJSF.FrmHJSF( _chineseName , FormType.门诊医生 , currentUser , currentDept );
                    if ( _mdiParent != null )
                    {
                        frmHJSF.MdiParent = _mdiParent;
                    }
                    frmHJSF.WindowState = FormWindowState.Maximized;
                    frmHJSF.BringToFront( );
                    frmHJSF.Show( );
                    break;
                case "Fun_MZ_InvoiceQuery":
                    frmInvoiceQuery = new HIS_MZManager.Query.FrmInvoiceQuery( _chineseName,currentUser );
                    if ( _mdiParent != null )
                    {
                        frmInvoiceQuery.MdiParent = _mdiParent;
                    }
                    frmInvoiceQuery.WindowState = FormWindowState.Maximized;
                    frmInvoiceQuery.BringToFront( );
                    frmInvoiceQuery.Show( );
                    break;
                case "Fun_MZ_PrescriptionQuery":
                    frmPrescriptionQuery = new HIS_MZManager.Query.FrmPrescriptionQuery( _chineseName , currentUser );
                    if ( _mdiParent != null )
                    {
                        frmPrescriptionQuery.MdiParent = _mdiParent;
                    }
                    frmPrescriptionQuery.WindowState = FormWindowState.Maximized;
                    frmPrescriptionQuery.BringToFront( );
                    frmPrescriptionQuery.Show( );
                    break;
                case "Fun_MZ_Account":
                    frmAccount = new HIS_MZManager.Account.FrmAccount( currentUser );
                    frmAccount.ShowDialog( );
                    break;
                case "Fun_MZ_AllAccount":
                    frmAllAccount = new HIS_MZManager.Account.FrmAllAccount( _chineseName , currentUser );
                    if ( _mdiParent != null )
                    {
                        frmAllAccount.MdiParent = _mdiParent;
                    }
                    frmAllAccount.WindowState = FormWindowState.Maximized;
                    frmAllAccount.BringToFront( );
                    frmAllAccount.Show( );
                    break;
                case "Fun_MZ_GH":
                    frmGh = new HIS_MZManager.GH.FrmMzgh( _chineseName , currentUser );
                    if ( _mdiParent != null )
                    {
                        frmGh.MdiParent = _mdiParent;
                    }
                    frmGh.WindowState = FormWindowState.Maximized;
                    frmGh.BringToFront( );
                    frmGh.Show( );
                    break;
                case "Fun_MZ_InvoiceManager":
                    frmInvoiceManager = new HIS_MZManager.InvoiceManager.FrmInvoiceManager( _chineseName , currentUser );
                    if ( _mdiParent != null )
                    {
                        frmInvoiceManager.MdiParent = _mdiParent;
                    }
                    frmInvoiceManager.WindowState = FormWindowState.Maximized;
                    frmInvoiceManager.BringToFront( );
                    frmInvoiceManager.Show( );
                    break;                
                case "Fun_MZ_Discharge":
                    frmDisCharge = new HIS_MZManager.HJSF.FrmUnCharge( Convert.ToInt32( currentUser.EmployeeID ) );
                    frmDisCharge.ShowDialog();
                    break;
                
                case "Fun_MZ_PersonSetting":
                    frmSetting = new HIS_MZManager.HJSF.FrmSetting( FormType.门诊收费 , currentUser );
                    frmSetting.ShowDialog( );
                    break;
                case "Fun_MZ_IncomeReport":
                    frmIncomeReport = new HIS_MZManager.Report.FrmReport( Convert.ToInt32( currentUser.EmployeeID ) , _chineseName );
                    if ( _mdiParent != null )
                    {
                        frmIncomeReport.MdiParent = _mdiParent;
                    }
                    frmIncomeReport.WindowState = FormWindowState.Maximized;
                    frmIncomeReport.BringToFront( );
                    frmIncomeReport.Show( );
                    break;
                case "Fun_MZ_RegReport":
                    frmRegReport = new HIS_MZManager.Report.FrmRegisterReport( Convert.ToInt32( currentUser.EmployeeID ) , _chineseName );
                    if ( _mdiParent != null )
                    {
                        frmRegReport.MdiParent = _mdiParent;
                    }
                    frmRegReport.WindowState = FormWindowState.Maximized;
                    frmRegReport.BringToFront( );
                    frmRegReport.Show( );
                    break;
                case "Fun_MZ_DownloadData":
                    fDownLoad = new FrmDownLoad( );
                    fDownLoad.ShowDialog( );
                    break;
                case "Fun_MZ_PatientFeeQuery":
                    frmPatientFeeQuery = new HIS_MZManager.Query.FrmPatientFeeQuery (  _chineseName );
                    if ( _mdiParent != null )
                    {
                        frmPatientFeeQuery.MdiParent = _mdiParent;
                    }
                    frmPatientFeeQuery.WindowState = FormWindowState.Maximized;
                    frmPatientFeeQuery.BringToFront( );
                    frmPatientFeeQuery.Show( );
                    break;
                case "Fun_MZ_PatientFeeReport":
                    frmPatientFeeReport = new HIS_MZManager.Report.FrmPatientFeeReport( Convert.ToInt32( currentUser.EmployeeID ) , _chineseName );
                    if ( _mdiParent != null )
                    {
                        frmPatientFeeReport.MdiParent = _mdiParent;
                    }
                    frmPatientFeeReport.WindowState = FormWindowState.Maximized;
                    frmPatientFeeReport.BringToFront( );
                    frmPatientFeeReport.Show( );
                    break;
                case "Fun_FrmPerformSectionReport":
                    frmPerformSectionReport = new HIS_MZManager.Report.FrmPerformSectionIncomeReport( _chineseName );
                    if ( _mdiParent != null )
                    {
                        frmPerformSectionReport.MdiParent = _mdiParent;
                    }
                    frmPerformSectionReport.WindowState = FormWindowState.Maximized;
                    frmPerformSectionReport.BringToFront( );
                    frmPerformSectionReport.Show( );
                    break;
                case "Fun_FrmChargerFeeReport":
                    HIS_MZManager.Query.FrmChargeUserQuery frmChargerfee = new HIS_MZManager.Query.FrmChargeUserQuery(Convert.ToInt32(currentUser.EmployeeID), _chineseName);
                    if (_mdiParent != null)
                    {
                        frmChargerfee.MdiParent = _mdiParent;
                    }
                    frmChargerfee.WindowState = FormWindowState.Maximized;
                    frmChargerfee.BringToFront();
                    frmChargerfee.Show();
                    break;
                case "Fun_FrmItemFeeQuery":
                    HIS_MZManager.Query.FrmItemFeeQuery frmItemfee = new HIS_MZManager.Query.FrmItemFeeQuery(_currentUserId);
                    if (_mdiParent != null)
                    {
                        frmItemfee.MdiParent = _mdiParent;
                    }
                    frmItemfee.WindowState = FormWindowState.Maximized;
                    frmItemfee.BringToFront();
                    frmItemfee.Show();
                    break;

                default:
                    throw new Exception( "引出函数名称错误！" );
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
            objectInfo.Name = "HIS_MZManager";
            objectInfo.Text = "门诊子系统";
            objectInfo.Remark = "";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[20];
            objectInfos[0].Name = "Fun_MZHJ";
            objectInfos[0].Text = "药房划价";
            objectInfos[0].Remark = "";

            objectInfos[1].Name = "Fun_MZSF";
            objectInfos[1].Text = "门诊收费";
            objectInfos[1].Remark = "";

            objectInfos[2].Name = "Fun_MZ_InvoiceQuery";
            objectInfos[2].Text = "门诊发票查询";
            objectInfos[2].Remark = "";

            objectInfos[3].Name = "Fun_MZ_PrescriptionQuery";
            objectInfos[3].Text = "门诊处方查询";
            objectInfos[3].Remark = "";

            objectInfos[4].Name = "Fun_MZ_Account";
            objectInfos[4].Text = "门诊个人交款表";
            objectInfos[4].Remark = "";

            objectInfos[5].Name = "Fun_MZ_AllAccount";
            objectInfos[5].Text = "门诊交款表汇总";
            objectInfos[5].Remark = "";

            objectInfos[6].Name = "Fun_MZ_GH";
            objectInfos[6].Text = "门诊挂号";
            objectInfos[6].Remark = "";

            objectInfos[7].Name = "Fun_MZ_InvoiceManager";
            objectInfos[7].Text = "门诊票据管理";
            objectInfos[7].Remark = "";

            objectInfos[8].Name = "Fun_MZYS";
            objectInfos[8].Text = "门诊划价";
            objectInfos[8].Remark = "";

            
            objectInfos[9].Name = "Fun_MZ_Discharge";
            objectInfos[9].Text = "门诊退费";
            objectInfos[9].Remark = "";

            objectInfos[10].Name = "Fun_MZ_CardManager";
            objectInfos[10].Text = "门诊病人信息管理";
            objectInfos[10].Remark = "";
          
            objectInfos[11].Name = "Fun_MZ_PersonSetting";
            objectInfos[11].Text = "门诊个人设置";
            objectInfos[11].Remark = "";
     
            objectInfos[12].Name = "Fun_MZ_IncomeReport";
            objectInfos[12].Text = "门诊收入统计";
            objectInfos[12].Remark = "";
     
            objectInfos[13].Name = "Fun_MZ_RegReport";
            objectInfos[13].Text = "门诊挂号人次统计";
            objectInfos[13].Remark = "";
      
            objectInfos[14].Name = "Fun_MZ_DownloadData";
            objectInfos[14].Text = "基础数据下载";
            objectInfos[14].Remark = "下载单机收费模式所需的基础数据";

            objectInfos[15].Name = "Fun_MZ_PatientFeeQuery";
            objectInfos[15].Text = "门诊病人费用查询";
            objectInfos[15].Remark = "查询门诊病人来院就诊的费用情况";

            objectInfos[16].Name = "Fun_MZ_PatientFeeReport";
            objectInfos[16].Text = "门诊病人费用统计";
            objectInfos[16].Remark = "统计门诊病人费用情况";

            objectInfos[17].Name = "Fun_FrmPerformSectionReport";
            objectInfos[17].Text = "执行科室门诊收入统计";
            objectInfos[17].Remark = "统计门诊科室和执行科室的收入表";

            objectInfos[18].Name = "Fun_FrmChargerFeeReport";
            objectInfos[18].Text = "门诊收费员工作量统计";
            objectInfos[18].Remark = "门诊收费员工作量统计";

            objectInfos[19].Name = "Fun_FrmItemFeeQuery";
            objectInfos[19].Text = "门诊收费项目收入统计";
            objectInfos[19].Remark = "门诊收费项目收入统计";

            return objectInfos;
        }
        #endregion

        #endregion
    }
}
