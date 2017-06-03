using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZYDoc_BLL
{
    public enum OrderType
    {
        长期医嘱,
        临时医嘱,
        长期账单,
        临时账单,
        自备,
        交病人临嘱,
        手术医嘱,
        出院带药临嘱,
        术后产后医嘱
    }

    public enum Status
    {
        医生保存,
        医生发送,
        护士转抄,
        医生停嘱,
        护士转抄停嘱,
        执行完毕,
        所有
    }

    public enum ItemType
    {       
        物资,
        西药,
        成药,
        草药,
        治疗,
        医技,
        手术,
        说明,
        护理,
        其他,
        出院,
        所有项目,
        长嘱新开,
        长嘱项目,
        临嘱新开

    }

    public struct WrongDecline
    {
       public  int colid;
       public  int rowid;
       public  string err;
       public void SetData(int _colid, int _rowid, string code,params string[] content)
       {
           colid = _colid;
           rowid = _rowid;
           err = MessageShows.GetMessages(code,content);
       }       
    }

   
}
