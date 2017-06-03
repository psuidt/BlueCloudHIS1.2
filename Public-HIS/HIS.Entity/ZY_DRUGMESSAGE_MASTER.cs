using System;
namespace HIS.Model
{
	public class ZY_DRUGMESSAGE_MASTER
	{
		private int _drugmessageid;
		/// <summary>
		///
		/// </summary>
		public int DRUGMESSAGEID
		{
			get{return _drugmessageid;}
			set{_drugmessageid = value ;}

		}
		private DateTime _sendtime;
		/// <summary>
		///
		/// </summary>
		public DateTime SENDTIME
		{
			get{return _sendtime;}
			set{_sendtime = value ;}

		}
		private int _dispdept;
		/// <summary>
		///
		/// </summary>
		public int DISPDEPT
		{
			get{return _dispdept;}
			set{_dispdept = value ;}

		}
		private int _dr_flag;
		/// <summary>
		///
		/// </summary>
		public int DR_FLAG
		{
			get{return _dr_flag;}
			set{_dr_flag = value ;}

		}
		private int _messagetype;
		/// <summary>
		///
		/// </summary>
		public int MESSAGETYPE
		{
			get{return _messagetype;}
			set{_messagetype = value ;}

		}
		private int _workid;
		/// <summary>
		///
		/// </summary>
		public int WORKID
		{
			get{return _workid;}
			set{_workid = value ;}

		}
		private int _sender;
		/// <summary>
		///
		/// </summary>
		public int SENDER
		{
			get{return _sender;}
			set{_sender = value ;}

		}

        private string _sendername;
        /// <summary>
        /// 
        /// </summary>
        public string SENDERNAME
        {
            get { return _sendername; }
            set { _sendername = value; }
        }

        private int _presdeptid;
        /// <summary>
        /// 
        /// </summary>
        public int PRESDEPTID
        {
            get { return _presdeptid; }
            set { _presdeptid = value; }
        }
	}
}
