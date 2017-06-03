using System;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Interfaces;
using HIS.SYSTEM.PubicBaseClasses;


namespace HIS_ZYNurseManager
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
			_functionName="";
			_chineseName="";
			_currentUserId=-1;
			_currentDeptId=-1;
			_menuId=-1;
			_mdiParent=null;
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
                case "FrmPatOut":

                    FrmPatOut frmPatOut = new FrmPatOut(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmPatOut.MdiParent = _mdiParent;
                    }
                    frmPatOut.WindowState = FormWindowState.Maximized;
                    frmPatOut.Show();
                    break;

                case "FrmInsertNewBed":

                    FrmInsertNewBed frmInsertNewBed = new FrmInsertNewBed(_currentUserId, _currentDeptId, _chineseName, false);
                    if (_mdiParent != null)
                    {
                        frmInsertNewBed.MdiParent = _mdiParent;
                    }
                    frmInsertNewBed.WindowState = FormWindowState.Maximized;
                    frmInsertNewBed.Show();
                    break;

                //本科室床位维护
                case "FrmInsertBedCurrDept":
                    FrmInsertNewBed frmInsertBedCurrDept = new FrmInsertNewBed(_currentUserId, _currentDeptId, _chineseName, true);
                    if (_mdiParent != null)
                    {
                        frmInsertBedCurrDept.MdiParent = _mdiParent;
                    }
                    frmInsertBedCurrDept.WindowState = FormWindowState.Maximized;
                    frmInsertBedCurrDept.Show();
                    break;

                case "FrmOrderTrans":

                    FrmOrderTrans frmOrderTrans = new FrmOrderTrans(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmOrderTrans.MdiParent = _mdiParent;
                    }
                    frmOrderTrans.WindowState = FormWindowState.Maximized;
                    frmOrderTrans.Show();
                    break;

                case "FrmOrderManager":

                    FrmOrderManager frmOrderManager = new FrmOrderManager(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmOrderManager.MdiParent = _mdiParent;
                    }
                    frmOrderManager.WindowState = FormWindowState.Maximized;
                    frmOrderManager.Show();
                    break;
                case "FrmFeeInput":

                    FrmFeeInput frmFeeInput = new FrmFeeInput(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmFeeInput.MdiParent = _mdiParent;
                    }
                    frmFeeInput.WindowState = FormWindowState.Maximized;
                    frmFeeInput.Show();
                    break;
                case "FrmBedShow":

                    FrmBedShow frmBedShow = new FrmBedShow(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmBedShow.MdiParent = _mdiParent;
                    }
                    frmBedShow.WindowState = FormWindowState.Maximized;
                    frmBedShow.Show();
                    break;              

                case "FrmOrderExec":

                    FrmOrderExec frmOrderExec = new FrmOrderExec(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmOrderExec.MdiParent = _mdiParent;
                    }
                    frmOrderExec.WindowState = FormWindowState.Maximized;
                    frmOrderExec.Show();
                    break;
                case "FrmAccountCheck":

                    FrmAccountCheck frmaccountcheck = new FrmAccountCheck(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmaccountcheck.MdiParent = _mdiParent;
                    }
                    frmaccountcheck.WindowState = FormWindowState.Maximized;
                    frmaccountcheck.Show();
                    break;          
                case "FrmOrderPrint":
                    FrmOrderPrint frmOrderPrint = new FrmOrderPrint(-1, _currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmOrderPrint.MdiParent = _mdiParent;
                    }
                    frmOrderPrint.WindowState = FormWindowState.Maximized;
                    frmOrderPrint.Show();
                    break;
                case "FrmFeeModel":
                    FrmFeeModel frmfeeModel = new FrmFeeModel(_currentUserId, _currentDeptId);
                    if (_mdiParent != null)
                    {
                        frmfeeModel.MdiParent = _mdiParent;
                    }
                    frmfeeModel.WindowState = FormWindowState.Maximized;
                    frmfeeModel.Show();
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
            objectInfo.Name = "HIS_ZYNurseManager        ";
            objectInfo.Text = "住院护士站系统";
            objectInfo.Remark = "住院护士站系统";
            return objectInfo;
        }
        /// <summary>
        /// 获得该Dll所有引出函数信息
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[13];

            objectInfos[0].Name = "FrmPatOut";
            objectInfos[0].Text = "病人出区";
            objectInfos[0].Remark = "病人出区";

            objectInfos[1].Name = "FrmInsertNewBed";
            objectInfos[1].Text = "床位维护";
            objectInfos[1].Remark ="床位维护";

            objectInfos[2].Name = "FrmOrderTrans";
            objectInfos[2].Text = "医嘱转抄";
            objectInfos[2].Remark = "医嘱转抄";

            objectInfos[3].Name = "FrmOrderManager";
            objectInfos[3].Text = "医嘱管理";
            objectInfos[3].Remark = "医嘱管理";

            objectInfos[4].Name = "FrmFeeInput";
            objectInfos[4].Text = "账单录入";
            objectInfos[4].Remark = "医嘱发送";

            objectInfos[5].Name = "FrmBedShow";
            objectInfos[5].Text = "床位管理";
            objectInfos[5].Remark = "床位管理";

            objectInfos[6].Name = "FrmBedAssign";
            objectInfos[6].Text = "床位分配";
            objectInfos[6].Remark = "床位分配";

            objectInfos[7].Name = "FrmOrderExec";
            objectInfos[7].Text = "医嘱执行";
            objectInfos[7].Remark = "医嘱执行";

            objectInfos[8].Name = "FrmAccountCheck";
            objectInfos[8].Text = "费用核对";
            objectInfos[8].Remark = "费用核对";

            objectInfos[9].Name = "FrmInsertBedCurrDept";
            objectInfos[9].Text = "科室床位维护";
            objectInfos[9].Remark = "科室床位维护";

            objectInfos[10].Name = "FrmAllOrderManager";
            objectInfos[10].Text = "医嘱管理(全)";
            objectInfos[10].Remark = "医嘱管理(全)";

            objectInfos[11].Name = "FrmOrderPrint";
            objectInfos[11].Text = "医嘱打印";
            objectInfos[11].Remark = "医嘱打印";


            objectInfos[12].Name = "FrmFeeModel";
            objectInfos[12].Text = "护士账单模板维护";
            objectInfos[12].Remark = "护士账单模板维护";


            return objectInfos;
        }
        #endregion


        #endregion
    }
}
