using System;
namespace HIS.Model
{
	public class Emr_Mould_Content
	{
        private int _id;
        /// <summary>
        ///
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }

        }
		private int _mouldid;
		/// <summary>
		///
		/// </summary>
		public int MouldId
		{
			get{return _mouldid;}
			set{_mouldid = value ;}

		}
		private string _mouldcontent;
		/// <summary>
		///
		/// </summary>
		public string MouldContent
		{
			get{return _mouldcontent;}
			set{_mouldcontent = value ;}

		}
	}
}
