using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    /// <summary>
    /// 病人处方信息
    /// </summary>
    public class MZ_PresMasterInfo
    {
        public MZ_PresMasterInfo()
        {
        }
        private string patientName;
        private string sex;
        private int age;
        private string address;
        private string invoiceNo;
        private string presMasterId;
        private int patlistId;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName
        {
            get
            {
                return patientName;
            }
            set
            {
                patientName = value;
            }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        /// <summary>
        /// 地址
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
        /// 处方发票号
        /// </summary>
        public string InvoiceNo
        {
            get
            {
                return invoiceNo;
            }
            set
            {
                invoiceNo = value;
            }
        }
        /// <summary>
        /// 处方号
        /// </summary>
        public string PresMasterId
        {
            get
            {
                return presMasterId;
            }
            set
            {
                presMasterId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PatlistId
        {
            get
            {
                return patlistId;
            }
            set
            {
                patlistId = value;
            }
        }
    }
}
