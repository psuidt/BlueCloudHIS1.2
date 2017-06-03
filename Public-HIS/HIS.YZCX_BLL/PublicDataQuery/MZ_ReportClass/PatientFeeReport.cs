using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.BLL;

namespace HIS.YZCX_BLL
{
    public class PatientFeeReport : BaseReport
    {
        private  System.Data.DataTable _dataResult;
        private string patientTypeCode;
        private OPDBillKind invoiceType;
        private string visitno;
        private string patname;

        public string VisitNo
        {
            get
            {
                return visitno;
            }
            set
            {
                visitno = value;
            }
        }

        public string PatName
        {
            get
            {
                return patname;
            }
            set
            {
                patname = value;
            }
        }

        public string PatientTypeCode
        {
            get
            {
                return patientTypeCode;
            }
            set
            {
                patientTypeCode = value;
            }
        }

        public OPDBillKind InvoiceType
        {
            get
            {
                return invoiceType;
            }
            set
            {
                invoiceType = value;
            }
        }

        public override string DataSQL
        {
            get
            {
                string workId = EntityConfig.WorkID.ToString(); // %d1
                string begindate = BeginDate.ToString("yyyy-MM-dd HH:mm:ss"); //%d2
                string enddate = EndDate.ToString("yyyy-MM-dd HH:mm:ss"); //%d3
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("select visitno,patname,pattype as meditype,sum(item_fee) as totalfee");
                strSql1.Append(" from yzcx_mz_cost ");
                strSql1.Append(" where cost_date between '%d2' and '%d3' and workid=%d1");
                strSql1.Append(" group by visitno,patname,pattype");
                string AA2_Fields = "";
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select ");
                for (int i = 0; i < PublicDataReader.MzfpItemList.Rows.Count; i++)
                {
                    string mzfp_code = PublicDataReader.MzfpItemList.Rows[i][Tables.base_stat_mzfp.CODE].ToString().Trim();
                    string mzfp_name = PublicDataReader.MzfpItemList.Rows[i][Tables.base_stat_mzfp.ITEM_NAME].ToString().Trim();
                    AA2_Fields = AA2_Fields + mzfp_name.Trim() + ",";
                    strSql2.Append("sum( case when fpcode='" + mzfp_code + "' then item_fee else 0 end) as " + mzfp_name + ",");
                }
                strSql2.Append("visitno");
                AA2_Fields = AA2_Fields.Remove(AA2_Fields.Length - 1, 1);
                strSql2.Append(" from yzcx_mz_cost");
                strSql2.Append(" where cost_date between '%d2' and '%d3' and workid=%d1");
                strSql2.Append(" group by visitno ");
                StringBuilder sbSQL3 = new StringBuilder();
                sbSQL3.Append(" select ");
                sbSQL3.Append(" AA1.visitno as 门诊就诊号,");
                sbSQL3.Append(" AA1.patname as 病人姓名,");
                sbSQL3.Append(" AA3.name as 类型,");
                sbSQL3.Append(" AA1.totalfee as 总金额,");
                sbSQL3.Append(AA2_Fields);
                sbSQL3.Append(" from ");
                sbSQL3.Append("(" + strSql1.ToString() + ") AA1 ");
                sbSQL3.Append(" inner join ");
                sbSQL3.Append("(" + strSql2.ToString() + ") AA2 ");
                sbSQL3.Append(" on AA1.visitno=AA2.visitno");
                sbSQL3.Append(" left join base_patienttype AA3 on AA1.meditype = AA3.code");
                if (patname != "")
                {
                    sbSQL3.Append(" where AA1.patname='%d4'");
                    if (visitno != "")
                    {
                        sbSQL3.Append(" and AA1.visitno='%d5'");
                    }
                }
                else
                {
                    if (visitno != "")
                    {
                        sbSQL3.Append(" where AA1.visitno='%d5'");
                    }
                }
                
                sbSQL3 = sbSQL3.Replace("%d1", workId).Replace("%d2",
                    begindate).Replace("%d3", enddate).Replace("%d4", patname).Replace("%d5", visitno);
                return sbSQL3.ToString();
            }
        }

        public override System.Data.DataTable DataResult
        {
            get
            {
                return _dataResult;
            }
            set
            {
                _dataResult = value;
            }
        }
    }
}
