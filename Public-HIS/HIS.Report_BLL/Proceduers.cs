using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;

namespace HIS.Report_BLL
{
    public class Proceduers : BaseBLL
    {
        public DataTable GetProcedureNames() //得到数据库中所有的存储过程
        {
            //string strsql = "SELECT * FROM SYSCAT.ROUTINES WHERE SUBSTR(VARCHAR(TEXT),1,16) = 'CREATE PROCEDURE'";
            string strsql = "SELECT * FROM SYSCAT.ROUTINES WHERE text like  'CREATE PROCEDURE%' and routinename like 'SP_%' ";
            return oleDb.GetDataTable(strsql);

        }


        public DataTable GetProcedureParameters(string procedurename) //得到指定存储过程的参数
        {
            string strsql = "select * from SYSIBM.SYSROUTINEPARMS where routinename='" + procedurename + "' order by ordinal";
            return oleDb.GetDataTable(strsql);
        }
    }
}
