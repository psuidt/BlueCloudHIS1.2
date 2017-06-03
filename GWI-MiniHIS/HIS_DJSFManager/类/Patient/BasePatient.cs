using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_DJSFManager.类
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BasePatient 
    {
        /// <summary>
        /// 病人就诊ID
        /// </summary>
        private int _patListID;
        /// <summary>
        /// 病人ID
        /// </summary>
        private decimal _patID;
        /// <summary>
        /// 病人姓名
        /// </summary>
        private string _patientName = "";
        /// <summary>
        /// 性别
        /// </summary>
        private string _sex = "";
        /// <summary>
        /// 门诊就诊号
        /// </summary>
        private string _visitNo;
        /// <summary>
        /// 拼音码
        /// </summary>
        private string _pYM = "";
        /// <summary>
        /// 五笔码
        /// </summary>
        private string _wBM = "";
        /// <summary>
        /// 出生日期
        /// </summary>
        private DateTime _bornDate;
        /// <summary>
        /// 年龄
        /// </summary>
        private int _age;
        /// <summary>
        /// 医院诊疗卡号
        /// </summary>
        private string hisCardNo;
        
        /// <summary>
        /// 病人就诊ID
        /// </summary>
        public int PatListID
        {
            get
            {
                return _patListID;
            }
            set
            {
                _patListID = value;
            }
        }
        /// <summary>
        /// 病人ID
        /// </summary>
        public decimal PatID
        {
            get
            {
                return _patID;
            }
            set
            {
                _patID = value;
            }
        }
        /// <summary>
        /// 就诊号
        /// </summary>
        public string VisitNo
        {
            get
            {
                return _visitNo;
            }
            set
            {
                _visitNo = value;
            }
        }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName
        {
            get
            {
                return _patientName;
            }
            set
            {
                _patientName = value;
            }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
            }
        }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string PYM
        {
            get
            {
                return _pYM;
            }
            set
            {
                _pYM = value;
            }
        }
        /// <summary>
        /// 五笔码
        /// </summary>
        public string WBM
        {
            get
            {
                return _wBM;
            }
            set
            {
                _wBM = value;
            }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BornDate
        {
            get
            {
                return _bornDate;
            }
            set
            {
                _bornDate = value;
            }
        }
        /// <summary>
        /// 年龄
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
        /// 医院诊疗卡号
        /// </summary>
        public string HisCardNo
        {
            get
            {
                return hisCardNo;
            }
            set
            {
                hisCardNo = value;
            }
        }
        
    }
}
