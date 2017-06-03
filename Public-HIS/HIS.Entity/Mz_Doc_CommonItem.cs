using System;
namespace HIS.Model
{
    /// <summary>
    /// 常用项
    /// </summary>
	public class Mz_Doc_CommonItem
    {
        public Mz_Doc_CommonItem()
        { 
        }

        #region Model
        private int _commonitemid; //常用项ID
        private int _item_id;      //项目ID
        private int _record_doc;   //所属医生
        private int _frequency;    //使用频率
        private int _type;         //常用项类型
        private int _delete_bit;   //删除标志
    
		/// <summary>
        /// 常用项ID
		/// </summary>
		public int CommonItemId
		{
			get{return _commonitemid;}
			set{_commonitemid = value ;}

		}
		
		/// <summary>
        /// 项目ID
		/// </summary>
		public int Item_Id
		{
			get{return _item_id;}
			set{_item_id = value ;}

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
        ///  使用频率
		/// </summary>
		public int Frequency
		{
			get{return _frequency;}
			set{_frequency = value ;}

		}

        /// <summary>
        /// 常用项类型
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
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
