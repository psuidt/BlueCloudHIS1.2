using System;

namespace HIS.ZY_BLL.DataModel
{
	/// <summary>
	/// 实体类PatientInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    public partial class PatientInfo : HIS.ZY_BLL.DataModel.IPatientInfo
    {
        #region Model
        private int _patid;
        private string _patcode;
        private string _patname;
        private string _patsex;
        private string _pym;
        private string _wbm;
        private string _familycode;
        private string _medicard;
        private string _cureno;
        private int _curenum;
        private string _PatNumber;
        private DateTime _PatBriDate;
        private string _PatGroup;
        private string _PatTEL;
        private string _PatAddress;
        private string _PatCaseNo;
        private string _linkman;
        private string _linktel;
        private string _linkaddress;
        /// <summary>
        /// ID
        /// </summary>
        public int PatID
        {
            set { _patid = value; }
            get { return _patid; }
        }
        /// <summary>
        /// 病人代码
        /// </summary>
        public string PatCode
        {
            set { _patcode = value; }
            get { return _patcode; }
        }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatName
        {
            set { _patname = value; }
            get { return _patname; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string PatSex
        {
            set { _patsex = value; }
            get { return _patsex; }
        }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string PYM
        {
            set { _pym = value; }
            get { return _pym; }
        }
        /// <summary>
        /// 五笔码
        /// </summary>
        public string WBM
        {
            set { _wbm = value; }
            get { return _wbm; }
        }
        /// <summary>
        /// 家庭编号
        /// </summary>
        public string FamilyCode
        {
            set { _familycode = value; }
            get { return _familycode; }
        }
        /// <summary>
        /// 医疗证卡号
        /// </summary>
        public string MediCard
        {
            set { _medicard = value; }
            get { return _medicard; }
        }
        /// <summary>
        /// 住院号
        /// </summary>
        public string CureNo
        {
            set { _cureno = value; }
            get { return _cureno; }
        }
        /// <summary>
        /// 住院次数
        /// </summary>
        public int CureNum
        {
            set { _curenum = value; }
            get { return _curenum; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string PatNumber
        {
            get { return _PatNumber; }
            set { _PatNumber = value; }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime PatBriDate
        {
            get { return _PatBriDate; }
            set { _PatBriDate = value; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string PatGroup
        {
            get { return _PatGroup; }
            set { _PatGroup = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string PatTEL
        {
            get { return _PatTEL; }
            set { _PatTEL = value; }
        }
        /// <summary>
        /// 家庭住址
        /// </summary>
        public string PatAddress
        {
            get { return _PatAddress; }
            set { _PatAddress = value; }
        }
        /// <summary>
        /// 病历号
        /// </summary>
        public string PatCaseNo
        {
            get { return _PatCaseNo; }
            set { _PatCaseNo = value; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            get { return _linkman; }
            set { _linkman = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string LinkTel
        {
            get { return _linktel; }
            set { _linktel = value; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string LinkAddress
        {
            get { return _linkaddress; }
            set { _linkaddress = value; }
        }

        

        private string _PATJOB;
        /// <summary>
        /// 病人职业
        /// </summary>
        public string PATJOB
        {
            get
            {
                return _PATJOB;
            }
            set
            {
                _PATJOB = value;
            }
        }
        private string _ACCOUNTTYPE;
        /// <summary>
        /// 结算方式
        /// </summary>
        public string ACCOUNTTYPE
        {
            get
            {
                return _ACCOUNTTYPE;
            }
            set
            {
                _ACCOUNTTYPE = value;
            }
        }
        private string allergic;
        /// <summary>
        /// 过敏史描述
        /// </summary>
        public string ALLERGIC
        {
            get
            {
                return allergic;
            }
            set
            {
                allergic = value;
            }
        }
        #endregion Model
    }
}

