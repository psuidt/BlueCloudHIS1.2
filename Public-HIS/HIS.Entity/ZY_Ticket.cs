using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.Model
{
    public class ZY_Ticket
    {
        private string _发票流水号;
        private string _发票号;
        private string _住院号;
        private string _科室;

        private string _年;
        private string _月;
        private string _日;

        private string _床位号;
        private string _病人姓名;
        private DateTime _入院日期;
        private DateTime _出院日期;

        private string _结算方式;

        private int _住院天数;

        private string _拾万;
        private string _万;
        private string _仟;
        private string _佰;
        private string _拾;
        private string _元;
        private string _角;
        private string _分;

        private string _总费用;

        private string _记账金额;
        private string _单位金额;
        private string _自付金额;
        private string _优惠金额;

        private string _预交金;
        private string _补收;
        private string _应退;
        private string _欠费;
        private string _收费员;
        
        private DataTable _发票项目费用;

        private string _CT;
        private string _MRI;
        private string _X光;
        private string _心脑电图;
        private string _输血费;
        private string _输养费;
        private string _自费西药;

        public string 发票号
        {
            get
            {
                return _发票号;
            }
            set
            {
                _发票号 = value;
            }
        }

        public string 住院号
        {
            get
            {
                return _住院号;
            }
            set
            {
                _住院号 = value;
            }
        }

        public string 科室
        {
            get
            {
                return _科室;
            }
            set
            {
                _科室 = value;
            }
        }

        public string 床位号
        {
            get
            {
                return _床位号;
            }
            set
            {
                _床位号 = value;
            }
        }

        public string 病人姓名
        {
            get
            {
                return _病人姓名;
            }
            set
            {
                _病人姓名 = value;
            }
        }

        public DateTime 入院日期
        {
            get
            {
                return _入院日期;
            }
            set
            {
                _入院日期 = value;
            }
        }

        public int 住院天数
        {
            get
            {
                return _住院天数;
            }
            set
            {
                _住院天数 = value;
            }
        }

        public DateTime 出院日期
        {
            get
            {
                return _出院日期;
            }
            set
            {
                _出院日期 = value;
            }
        }

        public string 总费用
        {
            get
            {
                return _总费用;
            }
            set
            {
                _总费用 = value;
            }
        }

        public string 预交金
        {
            get
            {
                return _预交金;
            }
            set
            {
                _预交金 = value;
            }
        }

        public string 补收
        {
            get
            {
                return _补收;
            }
            set
            {
                _补收 = value;
            }
        }

        public string 应退
        {
            get
            {
                return _应退;
            }
            set
            {
                _应退 = value;
            }
        }

        public string 欠费
        {
            get
            {
                return _欠费;
            }
            set
            {
                _欠费 = value;
            }
        }

        public string 收费员
        {
            get
            {
                return _收费员;
            }
            set
            {
                _收费员 = value;
            }
        }

        public string 发票流水号
        {
            get
            {
                return _发票流水号;
            }
            set
            {
                _发票流水号 = value;
            }
        }

        public DataTable 发票项目费用
        {
            get
            {
                return _发票项目费用;
            }
            set
            {
                _发票项目费用 = value;
            }
        }

        public string 年
        {
            set { _年 = value; }
            get { return _年; }
        }
        public string 月
        {
            set { _月 = value; }
            get { return _月; }
        }
        public string 日
        {
            set { _日 = value; }
            get { return _日; }
        }

        public string 结算方式
        {
            set { _结算方式 = value; }
            get { return _结算方式; }
        }

        public string 拾万
        {
            set { _拾万 = value; }
            get { return _拾万; }
        }
        public string 万
        {
            set { _万 = value; }
            get { return _万; }
        }
        public string 仟
        {
            set { _仟 = value; }
            get { return _仟; }
        }
        public string 佰
        {
            set { _佰 = value; }
            get { return _佰; }
        }
        public string 拾
        {
            set { _拾 = value; }
            get { return _拾; }
        }
        public string 元
        {
            set { _元 = value; }
            get { return _元; }
        }
        public string 角
        {
            set { _角 = value; }
            get { return _角; }
        }
        public string 分
        {
            set { _分 = value; }
            get { return _分; }
        }

        public string 记账金额
        {
            set { _记账金额 = value; }
            get { return _记账金额; }
        }
        public string 自付金额
        {
            set { _自付金额 = value; }
            get { return _自付金额; }
        }
        public string 单位金额
        {
            set { _单位金额 = value; }
            get { return _单位金额; }
        }
        public string 优惠金额
        {
            set { _优惠金额 = value; }
            get { return _优惠金额; }
        }

        public string CT
        {
            set { _CT = value; }
            get { return _CT; }
        }
        public string MRI
        {
            set { _MRI = value; }
            get { return _MRI; }
        }
        public string X光
        {
            set { _X光 = value; }
            get { return _X光; }
        }
        public string 心脑电图
        {
            set { _心脑电图 = value; }
            get { return _心脑电图; }
        }
        public string 输血费
        {
            set { _输血费 = value; }
            get { return _输血费; }
        }
        public string 输养费
        {
            set { _输养费 = value; }
            get { return _输养费; }
        }

        public string 自费西药
        {
            set { _自费西药 = value; }
            get { return _自费西药; }
        }
    }
}
