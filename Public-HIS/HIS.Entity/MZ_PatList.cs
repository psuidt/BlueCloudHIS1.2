using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    /// <summary>
    /// 实体类MZ_PatList 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MZ_PatList
    {
        public MZ_PatList()
        { }
        #region Model
        private int _patlistid;
        private decimal _patid;
        private string _patcode;
        private string _visitno;
        private string _patname;
        private string _patsex;
        private int _age;
        private string _pym;
        private string _wbm;
        private string _medicard;
        private string _meditype;
        private string _hpcode;
        private string _hpgrade;
        private string _curedeptcode;
        private string _cureempcode;
        private string _diseasecode;
        private string _diseasename;
        private DateTime _curedate;
        private string _regcode;
        private string _regname;
        /// <summary>
        /// 
        /// </summary>
        public int PatListID
        {
            set { _patlistid = value; }
            get { return _patlistid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal PatID
        {
            set { _patid = value; }
            get { return _patid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PatCode
        {
            set { _patcode = value; }
            get { return _patcode; }
        }
        /// <summary>
        /// 门诊号
        /// </summary>
        public string VisitNo
        {
            get
            {
                return _visitno;
            }
            set
            {
                _visitno = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PatName
        {
            set { _patname = value; }
            get { return _patname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PatSex
        {
            set { _patsex = value; }
            get { return _patsex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PYM
        {
            set { _pym = value; }
            get { return _pym; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WBM
        {
            set { _wbm = value; }
            get { return _wbm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MediCard
        {
            set { _medicard = value; }
            get { return _medicard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MediType
        {
            set { _meditype = value; }
            get { return _meditype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HpCode
        {
            set { _hpcode = value; }
            get { return _hpcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HpGrade
        {
            set { _hpgrade = value; }
            get { return _hpgrade; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CureDeptCode
        {
            set { _curedeptcode = value; }
            get { return _curedeptcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CureEmpCode
        {
            set { _cureempcode = value; }
            get { return _cureempcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DiseaseCode
        {
            set { _diseasecode = value; }
            get { return _diseasecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DiseaseName
        {
            set { _diseasename = value; }
            get { return _diseasename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CureDate
        {
            set { _curedate = value; }
            get { return _curedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegCode
        {
            get
            {
                return _regcode;
            }
            set
            {
                _regcode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegName
        {
            get
            {
                return _regname;
            }
            set
            {
                _regname = value;
            }
        }
        private string _reg_dept_code;
        /// <summary>
        ///
        /// </summary>
        public string REG_DEPT_CODE
        {
            get
            {
                return _reg_dept_code;
            }
            set
            {
                _reg_dept_code = value;
            }

        }
        private string _reg_doc_code;
        /// <summary>
        ///
        /// </summary>
        public string REG_DOC_CODE
        {
            get
            {
                return _reg_doc_code;
            }
            set
            {
                _reg_doc_code = value;
            }

        }
        private string _reg_doc_name;
        /// <summary>
        ///
        /// </summary>
        public string REG_DOC_NAME
        {
            get
            {
                return _reg_doc_name;
            }
            set
            {
                _reg_doc_name = value;
            }

        }
        private string _reg_dept_name;
        /// <summary>
        ///
        /// </summary>
        public string REG_DEPT_NAME
        {
            get
            {
                return _reg_dept_name;
            }
            set
            {
                _reg_dept_name = value;
            }

        }
        private int _curestatus;
        /// <summary>
        ///
        /// </summary>
        public int CureStatus
        {
            get
            {
                return _curestatus;
            }
            set
            {
                _curestatus = value;
            }

        }
        #endregion Model

    }
}
