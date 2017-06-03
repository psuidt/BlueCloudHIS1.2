using System;
namespace HIS.Model
{
	public class Emr_Record
	{
		private int _recordid;
		/// <summary>
		///
		/// </summary>
		public int RecordId
		{
			get{return _recordid;}
			set{_recordid = value ;}

		}
		private int _patid;
		/// <summary>
		///
		/// </summary>
		public int PatId
		{
			get{return _patid;}
			set{_patid = value ;}

		}
		private int _patlistid;
		/// <summary>
		///
		/// </summary>
		public int PatListId
		{
			get{return _patlistid;}
			set{_patlistid = value ;}

		}
		private string _recordtype;
		/// <summary>
		///
		/// </summary>
		public string RecordType
		{
			get{return _recordtype;}
			set{_recordtype = value ;}

		}
		private string _recordcontent;
		/// <summary>
		///
		/// </summary>
		public string RecordContent
		{
			get{return _recordcontent;}
			set{_recordcontent = value ;}

		}
		private int _recordcreateemp;
		/// <summary>
		///
		/// </summary>
		public int RecordCreateEmp
		{
			get{return _recordcreateemp;}
			set{_recordcreateemp = value ;}

		}
		private int _recordcreatedept;
		/// <summary>
		///
		/// </summary>
		public int RecordCreateDept
		{
			get{return _recordcreatedept;}
			set{_recordcreatedept = value ;}

		}
		private DateTime _recordcreatedate;
		/// <summary>
		///
		/// </summary>
		public DateTime RecordCreateDate
		{
			get{return _recordcreatedate;}
			set{_recordcreatedate = value ;}

		}
		private int _historyrecordid;
		/// <summary>
		///
		/// </summary>
		public int HistoryRecordId
		{
			get{return _historyrecordid;}
			set{_historyrecordid = value ;}

		}
		private int _recordflag;
		/// <summary>
		///
		/// </summary>
		public int RecordFlag
		{
			get{return _recordflag;}
			set{_recordflag = value ;}

		}
        private int _updateflag;
        /// <summary>
        ///
        /// </summary>
        public int UpdateFlag
        {
            get { return _updateflag; }
            set { _updateflag = value; }

        }
		private int _delete_bit;
		/// <summary>
		///
		/// </summary>
		public int Delete_Bit
		{
			get{return _delete_bit;}
			set{_delete_bit = value ;}

		}
	}
}
