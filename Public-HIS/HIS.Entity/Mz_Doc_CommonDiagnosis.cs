using System;
namespace HIS.Model
{
    /// <summary>
    /// 常用诊断
    /// </summary>
	public class Mz_Doc_CommonDiagnosis
    {
        /// <summary>
        /// 常用诊断
        /// </summary>
        public Mz_Doc_CommonDiagnosis()
        {
        }

        #region Model
        private int _commondiagnosisid;    //常用诊断ID
        private string _diagnosis_code;  //诊断代码
        private string _diagnosis_name;  //诊断名称
        private string _py_code;         //拼音码
        private string _wb_code;         //五笔码
        private int _record_doc;         //所属医生
        private int _frequency;          //使用频率
        private int _delete_bit;         //删除标志

        /// <summary>
        /// 常用诊断ID
		/// </summary>
		public int CommonDiagnosisId
		{
            get { return _commondiagnosisid; }
            set { _commondiagnosisid = value; }

		}

		/// <summary>
        /// 诊断代码
		/// </summary>
		public string Diagnosis_Code
		{
			get{return _diagnosis_code;}
			set{_diagnosis_code = value ;}

		}
		
		/// <summary>
        /// 诊断名称
		/// </summary>
		public string Diagnosis_Name
		{
			get{return _diagnosis_name;}
			set{_diagnosis_name = value ;}

		}
		
		/// <summary>
        /// 拼音码
		/// </summary>
		public string Py_Code
		{
			get{return _py_code;}
			set{_py_code = value ;}

		}
		
		/// <summary>
        /// 五笔码
		/// </summary>
		public string Wb_Code
		{
			get{return _wb_code;}
			set{_wb_code = value ;}

		}
		
		/// <summary>
        /// 所属医生
		/// </summary>
		public int Record_Doc
		{
			get{return _record_doc;}
			set{_record_doc = value ;}

		}
		
		/// <summary>
        /// 使用频率
		/// </summary>
		public int Frequency
		{
			get{return _frequency;}
			set{_frequency = value ;}

		}
		
		/// <summary>
        /// 删除标志
		/// </summary>
		public int Delete_Bit
		{
			get{return _delete_bit;}
			set{_delete_bit = value ;}

        }
        #endregion Model
    }
}
