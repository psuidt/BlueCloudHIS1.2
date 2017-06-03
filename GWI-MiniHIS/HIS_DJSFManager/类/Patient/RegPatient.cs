using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_DJSFManager.类
{
    /// <summary>
    /// 挂号病人对象
    /// </summary>
    public class RegPatient : BasePatient
    {
        private PatientType patType;
        private string idCard;
        private string folk;
        private string tel;
        private string occupation;
        private string address;
        private string regTypeCode;
        private string regTypeName;
        private string regDeptCode;
        private string regDeptName;
        private string regDocCode;
        private string regDocName;
        private DateTime regDate;
        /// <summary>
        /// 
        /// </summary>
        private bool validCardNo;

        private ChargeInfo regFeeInfo;
        /// <summary>
        /// 挂号类型
        /// </summary>
        public string RegTypeCode
        {
            get
            {
                return regTypeCode;
            }
            set
            {
                regTypeCode = value;
            }
        }
        public string RegTypeName
        {
            get
            {
                return regTypeName;
            }
            set
            {
                regTypeName = value;
            }
        }
        /// <summary>
        /// 挂号科室
        /// </summary>
        public string RegDeptCode
        {
            get
            {
                return regDeptCode;
            }
            set
            {
                regDeptCode = value;
            }
        }
        public string RegDeptName
        {
            get
            {
                return regDeptName;
            }
            set
            {
                regDeptName = value;
            }
        }

        /// <summary>
        /// 挂号医生
        /// </summary>
        public string RegDoctorCode
        {
            get
            {
                return regDocCode;
            }
            set
            {
                regDocCode = value;
            }
        }
        public string RegDoctorName
        {
            get
            {
                return regDocName;
            }
            set
            {
                regDocName = value;
            }
        }
        /// <summary>
        /// 挂号日期
        /// </summary>
        public DateTime RegDate
        {
            get
            {
                return regDate;
            }
            set
            {
                regDate = value;
            }
        }
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        /// <summary>
        /// 职业
        /// </summary>
        public string Occupation
        {
            get
            {
                return occupation;
            }
            set
            {
                occupation = value;
            }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            get
            {
                return tel;
            }
            set
            {
                tel = value;
            }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string Folk
        {
            get
            {
                return folk;
            }
            set
            {
                folk = value;
            }
        }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IDCard
        {
            get
            {
                return idCard;
            }
            set
            {
                idCard = value;
            }
        }
        /// <summary>
        /// 病人类型代码
        /// </summary>
        public PatientType PatType 
        {
            get
            {
                

                return patType;
            }
            set
            {
                patType  = value;
            }
        }
        
        /// <summary>
        /// 挂号费用计算信息
        /// </summary>
        public ChargeInfo RegFeeInfo
        {
            get
            {
                return regFeeInfo;
            }
            set
            {
                regFeeInfo = value;
            }
        }
        /// <summary>
        /// 卡号是否有效
        /// </summary>
        public bool ValidCardNo
        {
            get
            {
                return validCardNo;
            }
            set
            {
                validCardNo = value;
            }
        }
        
    }
}
