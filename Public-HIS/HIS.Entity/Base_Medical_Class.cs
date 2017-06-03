using System;
namespace HIS.Model
{
    public class Base_Medical_Class
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
        private string _name;
        /// <summary>
        ///
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }
        private int _orders;
        /// <summary>
        ///
        /// </summary>
        public int Orders
        {
            get { return _orders; }
            set { _orders = value; }

        }
        private string _comment;
        /// <summary>
        ///
        /// </summary>
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }

        }
        private int _class_type;
        /// <summary>
        ///
        /// </summary>
        public int Class_Type
        {
            get { return _class_type; }
            set { _class_type = value; }

        }
        private string _printtype;
        /// <summary>
        ///
        /// </summary>
        public string PrintType
        {
            get { return _printtype; }
            set { _printtype = value; }

        }
        private int _multselect;
        /// <summary>
        ///
        /// </summary>
        public int MultSelect
        {
            get { return _multselect; }
            set { _multselect = value; }

        }

    }
}
