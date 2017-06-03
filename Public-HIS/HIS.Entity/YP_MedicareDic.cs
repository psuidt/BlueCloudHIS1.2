using System;
namespace HIS .Model
{
    /// <summary>
    /// 实体类YP_MedicareDic 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class YP_MedicareDic
    {
        public YP_MedicareDic()
        {
        }
        #region Model
        private int _medicaredicid;
        private string _medicarename;
        private string _pym;
        private string _wbm;
        private string _medicareremark;
        /// <summary>
        /// 医保类型标识ＩＤ
        /// </summary>
        public int MedicareDicID
        {
            set
            {
                _medicaredicid = value;
            }
            get
            {
                return _medicaredicid;
            }
        }
        /// <summary>
        /// 医保类型名称
        /// </summary>
        public string MedicareName
        {
            set
            {
                _medicarename = value;
            }
            get
            {
                return _medicarename;
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
        /// 备注
        /// </summary>
        public string MedicareRemark
        {
            set
            {
                _medicareremark = value;
            }
            get
            {
                return _medicareremark;
            }
        }
        #endregion Model

    }
}

