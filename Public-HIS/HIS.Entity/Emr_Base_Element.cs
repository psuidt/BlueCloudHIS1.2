using System;
namespace HIS.Model
{
	public class Emr_Base_Element
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
		private string _elementcode;
		/// <summary>
		///
		/// </summary>
		public string ElementCode
		{
			get{return _elementcode;}
			set{_elementcode = value ;}

		}
		private string _elementname;
		/// <summary>
		///
		/// </summary>
		public string ElementName
		{
			get{return _elementname;}
			set{_elementname = value ;}

		}
		private string _p_elementcode;
		/// <summary>
		///
		/// </summary>
		public string P_ElementCode
		{
			get{return _p_elementcode;}
			set{_p_elementcode = value ;}

		}
		private int _elementlevel;
		/// <summary>
		///
		/// </summary>
		public int ElementLevel
		{
			get{return _elementlevel;}
			set{_elementlevel = value ;}

		}
	}
}
