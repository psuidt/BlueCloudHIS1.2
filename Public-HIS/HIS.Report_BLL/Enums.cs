using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Base_BLL;

namespace HIS.Report_BLL
{
    public enum ReControlTyp  
    {
        TextBox = 0,
        ComboBox = 1,
        CheckBox = 2,
        dateTimePicker=3,
        QueryText=4
    }

    public enum ControlName
    {
        V_BTIME,
        V_ETIME,
        V_CURRDEPTID,
        V_CURREMPLOYEEID,
        V_ALLDEPTID,
        V_ALLDOCTORID,
        V_STATTYPE,
        V_MZDEPT,
        V_ZYDEPT,
        V_ALLCHARGER,              
        V_ITEMDRUG
    }
}
