using System;
namespace HIS.Model
{
    /// <summary>
    /// 医技申请表
    /// </summary>
    public class Mz_Doc_Medical_Apply
	{
		private int _applyid;
		/// <summary>
        /// 申请ID
		/// </summary>
		public int ApplyId
		{
			get{return _applyid;}
			set{_applyid = value ;}

		}
		private int _patid;
		/// <summary>
        /// 病人ID
		/// </summary>
		public int PatId
		{
			get{return _patid;}
			set{_patid = value ;}

		}
		private int _patlistid;
		/// <summary>
        /// 就诊ID
		/// </summary>
		public int PatListId
		{
			get{return _patlistid;}
			set{_patlistid = value ;}

		}
		private int _preslistid;
		/// <summary>
        /// 处方明细ID
		/// </summary>
		public int PresListId
		{
			get{return _preslistid;}
			set{_preslistid = value ;}

		}
		private int _item_id;
		/// <summary>
        /// 项目ID
		/// </summary>
		public int Item_Id
		{
			get{return _item_id;}
			set{_item_id = value ;}

		}
		private string _item_name;
		/// <summary>
        /// 项目名称
		/// </summary>
		public string Item_Name
		{
			get{return _item_name;}
			set{_item_name = value ;}

		}
        private int _apply_type;
        /// <summary>
        /// 医技申请类型（0=化验，1=检查，2=治疗）
        /// </summary>
        public int Apply_Type
        {
            get { return _apply_type; }
            set { _apply_type = value; }

        }
        private int _medical_class;
        /// <summary>
        /// 医技项目类型
        /// </summary>
        public int Medical_Class
        {
            get { return _medical_class; }
            set { _medical_class = value; }

        }
		private string _apply_content;
		/// <summary>
        /// 申请内容
		/// </summary>
		public string Apply_Content
		{
			get{return _apply_content;}
			set{_apply_content = value ;}

		}
		private int _apply_doc;
		/// <summary>
        /// 申请医生
		/// </summary>
		public int Apply_Doc
		{
			get{return _apply_doc;}
			set{_apply_doc = value ;}

		}
		private int _apply_dept;
		/// <summary>
        /// 申请科室
		/// </summary>
		public int Apply_Dept
		{
			get{return _apply_dept;}
			set{_apply_dept = value ;}

		}
		private DateTime _apply_date;
		/// <summary>
        /// 申请时间
		/// </summary>
		public DateTime Apply_Date
		{
			get{return _apply_date;}
			set{_apply_date = value ;}

		}
		private int _apply_status;
		/// <summary>
        /// 申请状态
		/// </summary>
		public int Apply_Status
		{
			get{return _apply_status;}
			set{_apply_status = value ;}

		}
		private string _memo;
		/// <summary>
        /// 备注
		/// </summary>
		public string Memo
		{
			get{return _memo;}
			set{_memo = value ;}

		}
	}
}
