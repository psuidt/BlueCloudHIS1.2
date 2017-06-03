using System;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Interfaces;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_MediInsInterface
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
				_functionName=value;
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
				_chineseName=value;
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
				_currentUserId=value;
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
				_currentDeptId=value;
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
				_menuId=value;
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
				_mdiParent=value;
			}
		}
		#endregion
            
		#region 函数
		/// <summary>
		/// 根据函数名称实例化窗体
		/// </summary>
		public void InstanceXcForm()
		{
			if(_functionName=="")
			{
				throw new Exception("引出函数名不能为空！");
			}
            GWMHIS.BussinessLogicLayer.Classes.User currentUser = new GWMHIS.BussinessLogicLayer.Classes.User(_currentUserId);
            GWMHIS.BussinessLogicLayer.Classes.Deptment currentDept = new GWMHIS.BussinessLogicLayer.Classes.Deptment(_currentDeptId);
			switch(_functionName)
			{

                case "Fxc_InsurMatchItem":
                    FrmInsurMatch frmItemMatch = new FrmInsurMatch(_chineseName, HIS.Base_BLL.Enums.MatchClass.项目匹配, currentUser);
                    if (_mdiParent != null)
                    {
                        frmItemMatch.MdiParent = _mdiParent;
                    }
                    frmItemMatch.WindowState = FormWindowState.Maximized;
                    frmItemMatch.Show();
                    break;
                case "Fxc_InsurMatchDrug":
                    FrmInsurMatch frmDrugMatch = new FrmInsurMatch(_chineseName, HIS.Base_BLL.Enums.MatchClass.药品匹配, currentUser);
                    if (_mdiParent != null)
                    {
                        frmDrugMatch.MdiParent = _mdiParent;
                    }
                    frmDrugMatch.WindowState = FormWindowState.Maximized;
                    frmDrugMatch.Show();
                    break;
                case "Fxc_PresOrderUpload":
                    FrmPatCostUpdate frmpatcu = new FrmPatCostUpdate();
                    if (_mdiParent != null)
                    {
                        frmpatcu.MdiParent = _mdiParent;
                    }
                    frmpatcu.currentDeptId = _currentDeptId;
                    frmpatcu.currentUserId = _currentUserId;
                    frmpatcu.chineseName = _chineseName;
                    frmpatcu.WindowState = FormWindowState.Maximized;
                    frmpatcu.Show();
                    break;
				default :
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
            objectInfo.Name = "HIS_MediInsInterface";
			objectInfo.Text="医疗保险接口";
            objectInfo.Remark = "医疗保险接口";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[3];

			objectInfos[0].Name="Fxc_InsurMatchItem";
			objectInfos[0].Text="项目匹配";
            objectInfos[0].Remark = "项目匹配";

            objectInfos[1].Name = "Fxc_InsurMatchDrug";
			objectInfos[1].Text="药品匹配";
            objectInfos[1].Remark = "药品匹配";

            objectInfos[2].Name = "Fxc_PresOrderUpload";
            objectInfos[2].Text = "费用上传";
            objectInfos[2].Remark = "费用上传";

			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
