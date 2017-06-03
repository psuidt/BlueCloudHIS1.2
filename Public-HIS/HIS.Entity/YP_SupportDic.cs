using System;
namespace HIS .Model
{
    /// <summary>
    /// 实体类YP_SupportDic 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class YP_SupportDic
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public YP_SupportDic()
        {
        }
        #region Model
        private int _supportdicid;
        private string _name;
        private string _pym;
        private string _wbm;
        private string _linkman;
        private string _phone;
        private string _address;
        private int _del_flag;
        /// <summary>
        /// 供应商标识ＩＤ
        /// </summary>
        public int SupportDicID
        {
            set
            {
                _supportdicid = value;
            }
            get
            {
                return _supportdicid;
            }
        }
        /// <summary>
        /// 供应商名称
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
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LinkMan
        {
            set
            {
                _linkman = value;
            }
            get
            {
                return _linkman;
            }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            set
            {
                _phone = value;
            }
            get
            {
                return _phone;
            }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set
            {
                _address = value;
            }
            get
            {
                return _address;
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
        #endregion Model

    }
}

