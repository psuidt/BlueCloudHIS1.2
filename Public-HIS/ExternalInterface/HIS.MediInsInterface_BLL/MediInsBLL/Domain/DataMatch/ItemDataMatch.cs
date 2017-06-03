using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace HIS.MediInsInterface_BLL.MediInsBLL.Domain.DataMatch
{
    //[20100519.1.03]
    //[20100520.1.04]
    public class ItemDataMatch:AbstractDataMatch
    {
         private DataTable cxDT;
        private DataTable hisDT;
        private DataTable matchDT;

        public ItemDataMatch()
            : base()
        {          
        }
        public ItemDataMatch(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
            : base(_OleDb)
        {
        }

        public override DataTable OuterData(bool b)
        {
            cxDT = idatamatch_dao.CxHn_GetTherapyList(b);
            return cxDT;
        }

        public override DataTable HisData(bool b)
        {
            hisDT = idatamatch_dao.Get_HIS_ItemList(b);
            return hisDT;
        }

        public override DataTable RelationData(bool IsNew, string itemType)
        {
            matchDT = idatamatch_dao.CxHn_GetMatchInfo(IsNew, "3");
            return matchDT;
        }

        public override void DownLoadContent()
        {
            DataTable dt = match_sys.DownLoadItemContent(null);
            idatamatch_dao.CxHn_AddItemContent(dt);
        }

        public override void AddMatchRelation(string ncms_code, string hospital_code, string item_type)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("empid", EmpID);
            hashtable.Add("name", Name);
            hashtable.Add("effect_date", DateTime.Now);
            hashtable.Add("expire_date", DateTime.Now);

            DataRow[] drs = cxDT.Select("ITEM_CODE='" + ncms_code + "'");
            if (drs.Length > 0)
            {
                hashtable.Add("Medi_code", drs[0]["ITEM_CODE"].ToString());
                hashtable.Add("Medi_name", drs[0]["ITEM_NAME"].ToString());
                hashtable.Add("Model_name", "");
                hashtable.Add("Medi_item_type", "0");
            }
            else
            {
                throw new Exception("请正确选择农合目录的项目！");
            }
            drs = hisDT.Select("item_id = '" + hospital_code + "'");
            if (drs.Length > 0)
            {
                hashtable.Add("code", drs[0]["item_id"].ToString());
                hashtable.Add("chemname", drs[0]["item_name"].ToString());
                hashtable.Add("model", "");
                hashtable.Add("price", drs[0]["price"].ToString());
            }
            else
            {
                throw new Exception("请正确选择本院目录的项目！");
            }
            //上传到中心
            string Serial_match = match_sys.UploadMatchContent(hashtable);

            string[] fvs = new string[12];
            fvs[0] = hashtable["code"].ToString();
            fvs[1] = hashtable["chemname"].ToString();
            fvs[2] = hashtable["model"].ToString();
            fvs[3] = hashtable["Medi_code"].ToString();
            fvs[4] = hashtable["Medi_name"].ToString();
            fvs[5] = hashtable["Model_name"].ToString();
            fvs[6] = Serial_match;
            fvs[7] = Serial_match == "-1" ? "0" : "1";
            fvs[8] = "0";
            fvs[9] = hashtable["Medi_item_type"].ToString();
            fvs[10] = DateTime.Now.ToString();
            fvs[11] = Name;
            //保存到本地
            idatamatch_dao.CxHn_AddMatchData(fvs);
        }

        public override void UploadSingleMatchRelation(string hosp_code, string item_code, string serial_match, string match_type)
        {
            if (serial_match == "-1")
            {
                AddMatchRelation(item_code, hosp_code, match_type);
            }
            else
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("Serial_match", serial_match);
                hashtable.Add("empid", EmpID);
                hashtable.Add("name", Name);
                hashtable.Add("effect_date", DateTime.Now);
                hashtable.Add("expire_date", DateTime.Now);

                DataRow[] drs = cxDT.Select("ITEM_CODE='" + item_code + "'");
                if (drs.Length > 0)
                {
                    hashtable.Add("Medi_code", drs[0]["ITEM_CODE"].ToString());
                    hashtable.Add("Medi_name", drs[0]["ITEM_NAME"].ToString());
                    hashtable.Add("Model_name", "");
                    hashtable.Add("Medi_item_type", "0");
                }
                else
                {
                    throw new Exception("请正确选择农合目录的药品！");
                }
                drs = hisDT.Select("item_id = '" + hosp_code + "'");
                if (drs.Length > 0)
                {
                    hashtable.Add("code", drs[0]["item_id"].ToString());
                    hashtable.Add("chemname", drs[0]["item_name"].ToString());
                    hashtable.Add("model", "");
                    hashtable.Add("price", drs[0]["price"].ToString());
                }
                else
                {
                    throw new Exception("请正确选择本院目录的药品！");
                }
                //重新上传到中心
                match_sys.ResetMatchContent(hashtable);
            }
        }

        public override void UploadAllMatchRelation()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("AUDIT_FLAG", "0");
            hashtable.Add("ITEM_TYPE", "0");
            //获取未审核通过的药品
            DataTable auditnoDT = match_sys.DownLoadHospContent(hashtable);
            //获取审核通过的药品
            hashtable["AUDIT_FLAG"] = "1";
            DataTable auditokDT = match_sys.DownLoadHospContent(hashtable);
            //更新数据库标识
            idatamatch_dao.CxHn_UpdateMatchData(auditnoDT, true);
            idatamatch_dao.CxHn_UpdateMatchData(auditokDT, true);


            //上传未上传的匹配数据
            DataTable nodt = idatamatch_dao.CxHn_GetMatchInfo(false, "2");

            for (int i = 0; i < nodt.Rows.Count; i++)
            {
                hashtable = new Hashtable();
                hashtable.Add("empid", EmpID);
                hashtable.Add("name", Name);
                hashtable.Add("effect_date", DateTime.Now);
                hashtable.Add("expire_date", DateTime.Now);

                DataRow[] drs = cxDT.Select("ITEM_CODE='" + nodt.Rows[i]["ITEM_CODE"].ToString() + "'");
                if (drs.Length > 0)
                {
                    hashtable.Add("Medi_code", drs[0]["ITEM_CODE"].ToString());
                    hashtable.Add("Medi_name", drs[0]["ITEM_NAME"].ToString());
                    hashtable.Add("Model_name", "");
                    hashtable.Add("Medi_item_type", "0");
                }
                else
                {
                    throw new Exception("请正确选择农合目录的药品！");
                }
                drs = hisDT.Select("item_id = '" + nodt.Rows[i]["HOSP_CODE"].ToString() + "'");
                if (drs.Length > 0)
                {
                    hashtable.Add("code", drs[0]["item_id"].ToString());
                    hashtable.Add("chemname", drs[0]["item_name"].ToString());
                    hashtable.Add("model", "");
                    hashtable.Add("price", drs[0]["price"].ToString());
                }
                else
                {
                    throw new Exception("请正确选择本院目录的药品！");
                }
                //上传到中心
                string Serial_match = match_sys.UploadMatchContent(hashtable);
                if (Serial_match != "-1")
                {
                    nodt.Rows[i]["VALID_FLAG"] = "1";
                    nodt.Rows[i]["Serial_match"] = Serial_match;
                }
            }
            //更新上传标识
            idatamatch_dao.CxHn_UpdateMatchData(nodt, false);
        }

        public override void DeleteMatchRelation(string hosp_code, string item_code, string serial_match, string match_type, string audit_flag)
        {
            bool b = false;
            if (serial_match != "-1")
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("Serial_match", serial_match);
                hashtable.Add("AUDIT_FLAG", audit_flag);
                hashtable.Add("EDIT_STAFF", EmpID);
                hashtable.Add("EDIT_MAN", Name);
                b = match_sys.DeleteMatchContent(hashtable);
            }
            else
            {
                b = true;
            }
            if (b == true)
            {
                idatamatch_dao.CxHn_DeleteMatchData(hosp_code, item_code, serial_match, match_type);
            }
        }
    }
}
