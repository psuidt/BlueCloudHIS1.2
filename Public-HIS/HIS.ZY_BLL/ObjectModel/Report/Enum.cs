using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZY_BLL.Report
{
    public enum Total_Type
    {
        开方医生,
        主管医生,
        病人科室,
        执行科室
    }

    public enum Item_Type
    {
        发票项目,
        会计项目,
        核算项目,
        大项目
    }

    public enum Date_Type
    {
        记账时间,
        结算时间,
        交款时间
    }

    //public enum Ticket_type
    //{
    //    按病人,
    //    按结算记录,
    //    按交款日期
    //}

    //public enum TicketDataShowType
    //{
    //    收费员,
    //    病人,
    //    医生,
    //    全部
    //}

    public enum AdvanceDataShowType
    {
        汇总,
        明细
    }

}
