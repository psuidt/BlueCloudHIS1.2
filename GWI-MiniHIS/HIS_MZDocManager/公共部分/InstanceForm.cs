using System;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Interfaces;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_MZDocManager
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
            if (_functionName == "") 
            {
                throw new Exception( "引出函数名不能为空！" );
            }
            
            switch ( _functionName )
            {
                #region 日常业务
                case "Fun_FrmMedicalManage":
                    if (!(new Deptment(_currentDeptId)).MZ_Flag||!HIS.MZDoc_BLL.OP_ReadBaseData.IsClinicDept((int)_currentDeptId))
                    {
                        MessageBox.Show("请您选择登录门诊临床科室！","提示");
                        return;
                    }
                    FrmMedicalManage frmMedicalManage = FrmMedicalManage.GetInstance(_currentUserId, _currentDeptId, _chineseName);
                    //if (_mdiParent != null)
                    //{
                    //    frmMedicalManage.MdiParent = _mdiParent;
                    //}
                    frmMedicalManage.WindowState = FormWindowState.Maximized;
                    frmMedicalManage.Show();
                    frmMedicalManage.Select();
                    break;
                case "Fun_FrmSkinTestProcess":
                    FrmHisPreQuery frmSkinTestProcess = new FrmHisPreQuery(_currentUserId, _currentDeptId, _chineseName, true);
                    if (_mdiParent != null)
                    {
                        frmSkinTestProcess.MdiParent = _mdiParent;
                    }
                    frmSkinTestProcess.WindowState = FormWindowState.Maximized;
                    frmSkinTestProcess.Show();
                    break;
                case "Fun_FrmTransfusionCard":
                    FrmTransfusionCard frmTransfusionCard = new FrmTransfusionCard(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmTransfusionCard.MdiParent = _mdiParent;
                    }
                    frmTransfusionCard.WindowState = FormWindowState.Maximized;
                    frmTransfusionCard.Show();
                    break;
                #endregion

                #region 查询统计
                case "Fun_FrmWardBedQuery":
                    FrmWardBedQuery frmWardBedQuery = new FrmWardBedQuery(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmWardBedQuery.MdiParent = _mdiParent;
                    }
                    frmWardBedQuery.WindowState = FormWindowState.Maximized;
                    frmWardBedQuery.Show();
                    break;
                case "Fun_FrmHisPreQuery":
                    FrmHisPreQuery frmHisPreQuery = new FrmHisPreQuery(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmHisPreQuery.MdiParent = _mdiParent;
                    }
                    frmHisPreQuery.WindowState = FormWindowState.Maximized;
                    frmHisPreQuery.Show();
                    break;
                case "Fun_FrmDocWorkQuery":
                    FrmDocWorkQuery frmDocWorkQuery = new FrmDocWorkQuery(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmDocWorkQuery.MdiParent = _mdiParent;
                    }
                    frmDocWorkQuery.WindowState = FormWindowState.Maximized;
                    frmDocWorkQuery.Show();
                    break;
                #endregion

                #region 数据维护
                case "Fun_FrmPreMould":
                    FrmPreMould frmPreMould = new FrmPreMould(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmPreMould.MdiParent = _mdiParent;
                    }
                    frmPreMould.WindowState = FormWindowState.Maximized;
                    frmPreMould.Show();
                    break;
                case "Fun_FrmCommonItem":
                    FrmCommonItem frmCommonItem = new FrmCommonItem(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmCommonItem.MdiParent = _mdiParent;
                    }
                    frmCommonItem.WindowState = FormWindowState.Maximized;
                    frmCommonItem.Show();
                    break;
                case "Fun_FrmCommonDrug":
                    FrmCommonDrug frmCommonDrug = new FrmCommonDrug(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmCommonDrug.MdiParent = _mdiParent;
                    }
                    frmCommonDrug.WindowState = FormWindowState.Maximized;
                    frmCommonDrug.Show();
                    break;
                case "Fun_FrmCommonDiagnosis":
                    FrmCommonDiagnosis frmCommonDiagnosis = new FrmCommonDiagnosis(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmCommonDiagnosis.MdiParent = _mdiParent;
                    }

                    frmCommonDiagnosis.WindowState = FormWindowState.Maximized;
                    frmCommonDiagnosis.Show();
                    break;
                case "Fun_FrmMedicalApplyFormatSite":
                    FrmApplyFormat frmApplyFormat = new FrmApplyFormat(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmApplyFormat.MdiParent = _mdiParent;
                    }

                    frmApplyFormat.WindowState = FormWindowState.Maximized;
                    frmApplyFormat.Show();
                    break;
                #endregion

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
            objectInfo.Name = "HIS_MZDocManager";
            objectInfo.Text = "门诊医生站系统";
            objectInfo.Remark = "门诊医生站系统";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[11];
            int index = 0;
            objectInfos[index].Name = "Fun_FrmPreMould";
            objectInfos[index].Text = "医生模板设置";
            objectInfos[index].Remark = "医生模板设置";
            index++;
            objectInfos[index].Name = "Fun_FrmCommonItem";
            objectInfos[index].Text = "常用项目设置";
            objectInfos[index].Remark = "常用项目设置";
            index++;
            objectInfos[index].Name = "Fun_FrmCommonDrug";
            objectInfos[index].Text = "常用药品设置";
            objectInfos[index].Remark = "常用药品设置";
            index++;
            objectInfos[index].Name = "Fun_FrmCommonDiagnosis";
            objectInfos[index].Text = "常用诊断设置";
            objectInfos[index].Remark = "常用诊断设置";
            index++;
            objectInfos[index].Name = "Fun_FrmMedicalApplyFormatSite";
            objectInfos[index].Text = "医技申请格式设置";
            objectInfos[index].Remark = "医技申请格式设置";
            index++;
            objectInfos[index].Name = "Fun_FrmWardBedQuery";
            objectInfos[index].Text = "病区床位查询";
            objectInfos[index].Remark = "病区床位查询";
            index++;
            objectInfos[index].Name = "Fun_FrmHisPreQuery";
            objectInfos[index].Text = "历史诊疗记录查询";
            objectInfos[index].Remark = "历史诊疗记录查询";
            index++;
            objectInfos[index].Name = "Fun_FrmDocWorkQuery";
            objectInfos[index].Text = "医生工作量统计";
            objectInfos[index].Remark = "医生工作量统计";
            index++;
            objectInfos[index].Name = "Fun_FrmSkinTestProcess";
            objectInfos[index].Text = "皮试处理";
            objectInfos[index].Remark = "皮试处理";
            index++;
            objectInfos[index].Name = "Fun_FrmMedicalManage";
            objectInfos[index].Text = "诊疗管理";
            objectInfos[index].Remark = "诊疗管理";
            index++;
            objectInfos[index].Name = "Fun_FrmTransfusionCard";
            objectInfos[index].Text = "输液卡打印";
            objectInfos[index].Remark = "输液卡打印";
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
