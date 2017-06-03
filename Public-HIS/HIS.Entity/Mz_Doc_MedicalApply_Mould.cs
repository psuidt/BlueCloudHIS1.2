using System;
namespace HIS.Model
{
    /// <summary>
    /// 医技申请模板表
    /// </summary>
    public class Mz_Doc_MedicalApply_Mould
	{
		private int _id;
		/// <summary>
		///
		/// </summary>
		public int Id
		{
			get{return _id;}
			set{_id = value ;}

		}
        private int _medical_class;  //医技类型
		/// <summary>
        /// 医技类型
		/// </summary>
        public int Medical_Class
		{
			get{return _medical_class;}
			set{_medical_class = value ;}

		}
        private string _element_name;  //元素名称
        /// <summary>
        /// 元素名称
        /// </summary>
        public string Element_Name
        {
            get { return _element_name; }
            set { _element_name = value; }

        }
        private int _level;  //模板级别
		/// <summary>
        /// 模板级别
		/// </summary>
		public int Level
		{
			get{return _level;}
			set{_level = value ;}

		}
        private int _create_emp;  //创建人
		/// <summary>
        /// 创建人
		/// </summary>
		public int Create_Emp
		{
			get{return _create_emp;}
			set{_create_emp = value ;}

		}
        private int _create_dept;  //创建科室
		/// <summary>
        /// 创建科室
		/// </summary>
		public int Create_Dept
		{
			get{return _create_dept;}
			set{_create_dept = value ;}

		}
        private string _content;  //内容
		/// <summary>
        /// 内容
		/// </summary>
		public string Content
		{
			get{return _content;}
			set{_content = value ;}

		}
	}
}
