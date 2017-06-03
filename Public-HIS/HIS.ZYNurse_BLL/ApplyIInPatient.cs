using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using HIS.SYSTEM.Core;
using HIS.ZY_BLL;
using GWI.HIS.Windows.Controls;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYNurse_BLL
{
    public class ApplyIInPatient : BaseBLL, GWI.HIS.Windows.Controls.IInPatient, GWI.HIS.Windows.Controls.IInpatientExtDB
    {
        #region 变量
        string str;
        DataTable dt;
        int _patlistid;
        decimal _BalanceFee;
        string _BedNo;
        DateTime _BordDay;
        BindValue? _CureDoctor;
        BindValue? _CurrentDepartment;
        BindValue? _EconomyDoctor;
        DateTime? _InDate;
        BindValue? _InDepartment;
        BindValue? _InDisease;
        string _InpitentNo;
        BindValue? _Nurse;
        string _PatientName;
        BindValue? _PatientType;
        decimal _PrePayFee;
        string _Sex;
        string _TendInfo;
        decimal _txtdb;
        #endregion

        #region 属性
        /// <summary>
        /// 获取患者住院ID
        /// </summary>
        public int patlistid { get { return _patlistid; }}
        /// <summary>
        /// 获取和设置患者余额
        /// </summary>
        public decimal BalanceFee { get { return _BalanceFee; } set { _BalanceFee = value; } }
        /// <summary>
        /// 获取和设置患者床号
        /// </summary>
        public string BedNo { get { return _BedNo; } set { _BedNo = value; } }
        /// <summary>
        /// 获取和设置患者出生日期
        /// </summary>
        public DateTime BordDay { get { return _BordDay; } set { _BordDay = value; } }
        /// <summary>
        /// 获取和设置患者的主治医师
        /// </summary>
        public BindValue? CureDoctor { get { return _CureDoctor; } set { _CureDoctor = value; } }
        /// <summary>
        /// 获取和设置患者的当前科室
        /// </summary>
        public BindValue? CurrentDepartment { get { return _CurrentDepartment; } set { _CurrentDepartment = value; } }
        /// <summary>
        /// 获取和设置患者的经治医生
        /// </summary>
        public BindValue? EconomyDoctor { get { return _EconomyDoctor; } set { _EconomyDoctor = value; } }
        /// <summary>
        /// 获取和设置患者的入院时间
        /// </summary>
        public DateTime? InDate { get { return _InDate; } set { _InDate = value; } }
        /// <summary>
        /// 获取和设置患者的入院科室
        /// </summary>
        public BindValue? InDepartment { get { return _InDepartment; } set { _InDepartment = value; } }
        /// <summary>
        /// 获取和设置患者的入院诊断
        /// </summary>
        public BindValue? InDisease { get { return _InDisease; } set { _InDisease = value; } }
        /// <summary>
        /// 获取和设置患者的住院号
        /// </summary>
        public string InpitentNo { get { return _InpitentNo; } set { _InpitentNo = value; } }
        /// <summary>
        /// 获取和设置患者的责任护士
        /// </summary>
        public BindValue? Nurse { get { return _Nurse; } set { _Nurse = value; } }
        /// <summary>
        /// 获取和设置患者姓名
        /// </summary>
        public string PatientName { get { return _PatientName; } set { _PatientName = value; } }
        /// <summary>
        /// 获取和设置患者的病人类型
        /// </summary>
        public BindValue? PatientType { get { return _PatientType; } set { _PatientType = value; } }
        /// <summary>
        /// 获取和设置患者的预交金
        /// </summary>
        public decimal PrePayFee { get { return _PrePayFee; } set { _PrePayFee = value; } }
        /// <summary>
        /// 获取和设置患者性别
        /// </summary>
        public string Sex { get { return _Sex; } set { _Sex = value; } }
        /// <summary>
        /// 获取和设置患者护理信息，暂缺
        /// </summary>
        public string TendInfo { get { return _TendInfo; } set { _TendInfo = value; } }
        #endregion

        #region 构造方法
        /// <summary>
        /// 创建一个ApplyIInPatient类的实例
        /// </summary>
        /// <param name="patlistid">患者住院ID</param>
        public ApplyIInPatient(int patlistid)
        {
            _patlistid = patlistid;
            HIS.ZY_BLL.ObjectModel.CostManager.IcostManager IcM = HIS.ZY_BLL.ObjectModel.ObjectFactory.GetObject<HIS.ZY_BLL.ObjectModel.CostManager.IcostManager>(typeof(HIS.ZY_BLL.DataModel.ZY_CostMaster));
            IcM.PatListID = _patlistid;
            //_BalanceFee = IcM.GetPatFee().surplusFee;          
            str = @"select a.dbfee, a.BEDCODE BedNo, a.markdate,b.PATBRIDATE BordDay, d.NAME CureDoctor, e.NAME CurrentDepartment, f.NAME EconomyDoctor, " +
                " a.CUREDATE InDate, g.NAME InDepartment,a.DISEASENAME InDisease,a.CURENO InpitentNo,h.NAME Nurse,b.PATNAME PatientName," +
                " b.ACCOUNTTYPE PatientType, b.PATSEX Sex, '' TendInfo " +
                "from ZY_PATLIST a " +
                " left join PATIENTINFO b on a.PATID=b.PATID " +
                " left join ZY_NURSE_BED c on a.PATLISTID=c.PATLIST_ID " +
                " left join BASE_EMPLOYEE_PROPERTY d on c.ZZ_DOC=d.EMPLOYEE_ID " +
                " left join BASE_DEPT_PROPERTY e on a.CURRDEPTCODE=cast(e.DEPT_ID as char(20)) " +
                " left join BASE_EMPLOYEE_PROPERTY f on a.CUREDOCCODE=cast(f.EMPLOYEE_ID as char(20)) " +
                " left join BASE_DEPT_PROPERTY g on a.CUREDEPTCODE=cast(g.DEPT_ID as char(20)) " +
                " left join BASE_EMPLOYEE_PROPERTY h on c.CHARGE_NURSE=h.EMPLOYEE_ID " +
                " where patlistid=" + _patlistid;
            dt = oleDb.GetDataTable(str);
            if (dt == null || dt.Rows.Count == 0)
            {
                _BedNo = "";
                _BordDay = Convert.ToDateTime(null);
                _CureDoctor = new BindValue(null, null);
                _CurrentDepartment = new BindValue(null, null);
                _EconomyDoctor = new BindValue(null, null);
                _InDate = Convert.ToDateTime(null);
                _InDepartment = new BindValue(null, null);
                _InDisease = new BindValue(null, null);
                _InpitentNo = "";
                _Nurse = new BindValue(null, null);
                _PatientName = "";
                _PatientType = new BindValue(null, null);
                _Sex = "";
                _TendInfo = "";
            }
            else
            {
                _BedNo = dt.Rows[0]["BedNo"].ToString();
                _BordDay = Convert.ToDateTime(XcConvert.IsNull(dt.Rows[0]["BordDay"].ToString(), "0001-01-01 00:00:00.000000"));//(dt.Rows[0]["BordDay"].ToString());
                _CureDoctor = new BindValue(null,dt.Rows[0]["CureDoctor"].ToString());
                _CurrentDepartment = new BindValue(null, dt.Rows[0]["CurrentDepartment"].ToString());
                _EconomyDoctor = new BindValue(null, dt.Rows[0]["EconomyDoctor"].ToString());
                _InDate = Convert.ToDateTime(dt.Rows[0]["InDate"].ToString());
                _InDepartment = new BindValue(null, dt.Rows[0]["InDepartment"].ToString());
                _InDisease = new BindValue(null, dt.Rows[0]["InDisease"].ToString());
                _InpitentNo = dt.Rows[0]["InpitentNo"].ToString();
                _Nurse = new BindValue(null, dt.Rows[0]["Nurse"].ToString());
                _PatientName = dt.Rows[0]["PatientName"].ToString();
                _PatientType = new BindValue(null, dt.Rows[0]["PatientType"].ToString());
                _Sex = dt.Rows[0]["Sex"].ToString();
                _TendInfo =" 登记时间："+ dt.Rows[0]["markdate"].ToString();
                _PrePayFee = IcM.GetPatFee().chargeFee;
                _BalanceFee = IcM.GetPatFee().surplusFee;
                _txtdb = Convert.ToDecimal(dt.Rows[0]["dbfee"]);
            }
        }
        #endregion

        #region IInpatientExtDB 成员

        public decimal txtdb
        {
            get
            {
                return _txtdb;
            }
            set
            {
                _txtdb = value;
            }
        }

        #endregion
    }
}
