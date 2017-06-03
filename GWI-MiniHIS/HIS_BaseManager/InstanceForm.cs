using System;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Interfaces;
using HIS.SYSTEM.PubicBaseClasses;
namespace HIS_BaseManager
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
		private object[] _communicateValue;
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
				_communicateValue=value;
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
            FrmGroupMenu fMain = null;

            string sql;
            

            GWMHIS.BussinessLogicLayer.Classes.User currentUser = new GWMHIS.BussinessLogicLayer.Classes.User( _currentUserId );
            GWMHIS.BussinessLogicLayer.Classes.Deptment currentDept = new GWMHIS.BussinessLogicLayer.Classes.Deptment(_currentDeptId);

			switch(_functionName)
			{
				case "Fun_base_modulemenu":
                    fMain = new FrmGroupMenu(_currentUserId, _currentDeptId, _chineseName);
					if(_mdiParent!=null)
					{
						fMain.MdiParent=_mdiParent;
					}
					fMain.WindowState=FormWindowState.Maximized;
					fMain.BringToFront();
					fMain.Show();
					break;

                case "Fxc_HisReport":
                    FrmHisReport frmhr = new FrmHisReport(_currentUserId, _currentDeptId, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmhr.MdiParent = _mdiParent;
                    }
                    frmhr.WindowState = FormWindowState.Maximized;
                    frmhr.Show();
                    break;
                case "Fxc_DesReport":
                    FrmReportManager fm = new FrmReportManager();
                    fm.Show();
                    break;
                case "Fxc_FrmInForSerch":
                    FrmInforSerch fmIn = new FrmInforSerch(_chineseName);
                    if (_mdiParent != null)
                    {
                        fmIn.MdiParent = _mdiParent; 
                    }
                    fmIn.WindowState = FormWindowState.Maximized;
                    fmIn.Show();
                    break;
   

                #region 公共模块
                
                case "Fun_GWM_EmpDeptSet":
                    FrmEmpDeptSetting fRywh = new FrmEmpDeptSetting( _currentUserId , _currentDeptId , _chineseName );
                    if (_mdiParent != null)
                    {
                        fRywh.MdiParent = _mdiParent;
                    }
                    fRywh.WindowState = FormWindowState.Maximized;
                    fRywh.BringToFront();
                    fRywh.Show();
                    break;
                #endregion

                case "Fun_Base_Service_Items":
                    HIS_BaseManager.FrmSFXM frmSfxm = new FrmSFXM( _chineseName , currentUser );
                    if ( _mdiParent != null )
                    {
                        frmSfxm.MdiParent = _mdiParent;
                    }
                    frmSfxm.WindowState = FormWindowState.Maximized;
                    frmSfxm.Show( );
                    break;
                case "Fun_FrmGBDictionary":
                    HIS_BaseManager.FrmGBDictionary frmSfxm1 = new FrmGBDictionary(_chineseName);
                    if (_mdiParent != null)
                    {
                        frmSfxm1.MdiParent = _mdiParent;
                    }
                    frmSfxm1.WindowState = FormWindowState.Maximized;
                    frmSfxm1.Show();
                    break;
                case "Fun_StatItem":
                    HIS_BaseManager.FrmStatItem frmStat = new FrmStatItem( _chineseName );
                    if ( _mdiParent != null )
                    {
                        frmStat.MdiParent = _mdiParent;
                    }
                    frmStat.WindowState = FormWindowState.Maximized;
                    frmStat.Show( );
                    break;
                case "Fun_Drug_Match":
                    HIS_BaseManager.FrmInsurMatch frmDrugMatch = new FrmInsurMatch(_chineseName, HIS.Base_BLL.Enums.MatchClass.药品匹配 ,currentUser );
                    if ( _mdiParent != null )
                    {
                        frmDrugMatch.MdiParent = _mdiParent;
                    }
                    frmDrugMatch.WindowState = FormWindowState.Maximized;
                    frmDrugMatch.Show();
                    break;
                case "Fun_Item_Match":
                    HIS_BaseManager.FrmInsurMatch frmItemMatch = new FrmInsurMatch( _chineseName , HIS.Base_BLL.Enums.MatchClass.项目匹配 , currentUser  );
                    if ( _mdiParent != null )
                    {
                        frmItemMatch.MdiParent = _mdiParent;
                    }
                    frmItemMatch.WindowState = FormWindowState.Maximized;
                    frmItemMatch.Show();
                    break;
                case "Fun_base_hospital_item":
                    HIS_BaseManager.FrmHospitalItems frmHospitalItems = new HIS_BaseManager.FrmHospitalItems( _chineseName , currentUser );
                    if ( _mdiParent != null )
                    {
                        frmHospitalItems.MdiParent = _mdiParent;
                    }
                    frmHospitalItems.WindowState = FormWindowState.Maximized;
                    frmHospitalItems.Show( );
                    break;
                case "Fun_base_template_hj":
                    HIS_BaseManager.FrmTemplate frmTemplate = new FrmTemplate( _chineseName , currentUser,currentDept ,0 );
                    if ( _mdiParent != null )
                    {
                        frmTemplate.MdiParent = _mdiParent;
                    }
                    frmTemplate.WindowState = FormWindowState.Maximized;
                    frmTemplate.Show( );
                    break;
                case "Fun_base_CreatePYWB":
                    HIS_BaseManager.FrmCreatePYWB frmPYWB = new FrmCreatePYWB( currentUser );
                    frmPYWB.ShowDialog( );
                    break;
                case "Fun_base_work_unit":
                    HIS_BaseManager.FrmWorkUnit frmWorkUnit = new FrmWorkUnit( _chineseName   );
                    if ( _mdiParent != null )
                    {
                        frmWorkUnit.MdiParent = _mdiParent;
                    }
                    frmWorkUnit.WindowState = FormWindowState.Maximized;
                    frmWorkUnit.Show( );
                    break;
                case "Fun_basedata_Vindicator":
                    HIS_BaseManager.基本数据维护.FrmBaseDataVindicator frmBaseData = new HIS_BaseManager.基本数据维护.FrmBaseDataVindicator( _chineseName, currentUser );
                    if ( _mdiParent != null )
                    {
                        frmBaseData.MdiParent = _mdiParent;
                    }
                    frmBaseData.WindowState = FormWindowState.Maximized;
                    frmBaseData.Show();
                    break;
                case "Fun_ParameterSetting":
                    HIS_BaseManager.FrmParameterSet frmParaset = new FrmParameterSet( _chineseName );
                    if ( _mdiParent != null )
                    {
                        frmParaset.MdiParent = _mdiParent;
                    }
                    frmParaset.WindowState = FormWindowState.Maximized;
                    frmParaset.Show();
                    
                    break;
                case "Fun_GH_BaseDataSet":
                    HIS_BaseManager.FrmRegBaseDataSet frmGhBaseDataSet = new HIS_BaseManager.FrmRegBaseDataSet();
                    frmGhBaseDataSet.ShowDialog();
                    break;
				default :
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
            objectInfo.Name = "HIS_BaseManager";
			objectInfo.Text="基础数据维护";
			objectInfo.Remark="";
			return objectInfo;
		}
		/// <summary>
		/// 获得该Dll所有引出函数信息
		/// </summary>
		/// <returns></returns>
		public ObjectInfo[] GetFunctionsInfo()
		{
			ObjectInfo[] objectInfos=new ObjectInfo[17];
			

            objectInfos[0].Name = "Fxc_HisReport";
            objectInfos[0].Text = "报表管理";
            objectInfos[0].Remark = "";

            objectInfos[1].Name = "Fxc_DesReport";
            objectInfos[1].Text = "报表设计";
            objectInfos[1].Remark = "";

            objectInfos[2].Name = "Fun_GWM_EmpDeptSet";
            objectInfos[2].Text = "人员信科室息设置";
            objectInfos[2].Remark = "设置人员的基本信息，如职务等";

            objectInfos[3].Name = "Fxc_FrmInForSerch";
            objectInfos[3].Text = "资料查询";
            objectInfos[3].Remark = "";

            objectInfos[4].Name = "Fun_Base_Service_Items";
            objectInfos[4].Text = "基本医疗服务项目维护";
            objectInfos[4].Remark = "";

            objectInfos[5].Name = "Fun_FrmGBDictionary";
            objectInfos[5].Text = "国标项目字典";
            objectInfos[5].Remark = "";

            objectInfos[6].Name = "Fun_StatItem";
            objectInfos[6].Text = "统计大类及分类维护";
            objectInfos[6].Remark = "";

            objectInfos[7].Name = "Fun_Drug_Match";
            objectInfos[7].Text = "新农合药品匹配";
            objectInfos[7].Remark = "";

            objectInfos[8].Name = "Fun_Item_Match";
            objectInfos[8].Text = "新农合项目匹配";
            objectInfos[8].Remark = "";

            objectInfos[9].Name = "Fun_base_modulemenu";
            objectInfos[9].Text = "工作组菜单管理";
            objectInfos[9].Remark = "";

            objectInfos[10].Name = "Fun_base_hospital_item";
            objectInfos[10].Text = "本院医疗服务项目维护";
            objectInfos[10].Remark = "";

            objectInfos[11].Name = "Fun_base_template_hj";
            objectInfos[11].Text = "划价项目模板维护";
            objectInfos[11].Remark = "";

            objectInfos[12].Name = "Fun_base_CreatePYWB";
            objectInfos[12].Text = "拼音五笔码生成";
            objectInfos[12].Remark = "";

            objectInfos[13].Name = "Fun_base_work_unit";
            objectInfos[13].Text = "病人工作单位维护";
            objectInfos[13].Remark = "";

            objectInfos[14].Name = "Fun_basedata_Vindicator";
            objectInfos[14].Text = "公共基础数据维护";
            objectInfos[14].Remark = "";

            objectInfos[15].Name = "Fun_ParameterSetting";
            objectInfos[15].Text = "系统参数设置";
            objectInfos[15].Remark = "";

            objectInfos[16].Name = "Fun_GH_BaseDataSet";
            objectInfos[16].Text = "挂号基础数据维护";
            objectInfos[16].Remark = "";
			return objectInfos;
		}
		#endregion
		
		#endregion
	}
}
