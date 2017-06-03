using System;
namespace HIS .Model
{
    /// <summary>
    /// 实体类YP_UnitDic 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class YP_UnitDic
    {
        public YP_UnitDic()
        {
        }
        #region Model
        private int _unitdicid;
        private string _unitname;
        private string _pym;
        private string _wbm;
        /// <summary>
        /// 单位标识ID
        /// </summary>
        public int UnitDicID
        {
            set
            {
                _unitdicid = value;
            }
            get
            {
                return _unitdicid;
            }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName
        {
            set
            {
                _unitname = value;
            }
            get
            {
                return _unitname;
            }
        }
        /// <summary>
        /// 单位拼音码
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
        /// 单位五笔码
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
        #endregion Model

    }
}

