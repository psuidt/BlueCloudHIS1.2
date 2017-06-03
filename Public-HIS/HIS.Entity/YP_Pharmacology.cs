using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    /// <summary>
    /// 药理分类对象
    /// </summary>
    public class YP_Pharmacology
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public YP_Pharmacology()
        { 
        }
        private int _id;
        private int _fid;
        private string _name;
        private int _del_flag;
        private string _pym;
        private string _wbm;

        /// <summary>
        /// ID号
        /// </summary>
        public int Id
        {
            set
            {
                _id = value;
            }
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// 父节点ID
        /// </summary>
        public int Fid
        {
            set
            {
                _fid = value;
            }
            get
            {
                return _fid;
            }
        }

        /// <summary>
        /// 药理分类名称
        /// </summary>
        public string Name
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int Del_Flag
        {
            set
            {
                _del_flag = value;
            }
            get
            {
                return _del_flag;
            }
        }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string PYM
        {
            set
            {
                _pym = value;
            }
            get
            {
                return _pym;
            }
        }

        /// <summary>
        /// 五笔码
        /// </summary>
        public string WBM
        {
            set
            {
                _wbm = value;
            }
            get
            {
                return _wbm;
            }
        }
    }
}
