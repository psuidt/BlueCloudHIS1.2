using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS.MediInsInterface_BLL.MediInsInterface.CxNhSystem
{
    //[20100517.1.01]
    /// <summary>
    /// 基本结果集结构
    /// </summary>
    public class CxNhBaseData
    {
        /// <summary>
        /// 医疗机构编码
        /// </summary>
        static string MED_ORG_CODE = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.MED_ORG_CODE;

        static DataTable RecDt;
        static Dictionary<string, string> dic;
        /// <summary>
        /// 11001取农医保中心诊疗项目函数（中心）
        ///item_code	项目编码
        ///item_name	项目名称
        ///Price	单价
        ///code_wb	五笔码
        ///code_py		拼音码
        /// </summary>
        /// <param name="ds"></param>
        public static void Out_11001DT(DataSet ds)
        {
            RecDt = new DataTable("Out_11001DT");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "item_code";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "item_name";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Price";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "code_wb";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "code_py";
            RecDt.Columns.Add(column);

            ds.Tables.Add(RecDt);
        }
        /// <summary>
        /// 11007取农医保中心药品项目函数（中心）
        ///Medi_code	药品编码
        ///Medi_name	药品名称
        ///Model_name	剂型名称
        ///Factory	生产厂家
        ///Standard	规格
        ///Medi_item_type	药品类型
        ///Medi_item_name	药品类型名称
        ///Code_wb	五笔码
        ///Code_py		拼音码
        ///STAPLE_FLAG	国家药品目录标志
        /// </summary>
        /// <param name="ds"></param>
        public static void Out_11007DT(DataSet ds)
        {
            RecDt = new DataTable("Out_11007DT");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Medi_code";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Medi_name";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Model_name";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Factory";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Standard";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Medi_item_type";
            RecDt.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Medi_item_name";
            RecDt.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Code_wb";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Code_py";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "STAPLE_FLAG";
            RecDt.Columns.Add(column);

            ds.Tables.Add(RecDt);
        }
        /// <summary>
        /// 11003取农医保匹配项目信息函数（中心本院匹配）
        /// hosp_code	医院目录编码
        /// hosp_name	医院目录名称
        /// hosp_model	医院目录剂型
        /// Item_code	中心目录编码
        /// item_name	中心目录名称
        /// model_name	中心目录剂型
        /// serial_match	匹配序列号
        /// valid_flag	有效标志
        /// audit_flag	审核标志
        /// match_type	匹配类型
        /// </summary>
        /// <param name="ds"></param>
        public static void Out_11003DT(DataSet ds)
        {
            RecDt = new DataTable("Out_11003DT");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "hosp_code";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "hosp_name";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "hosp_model";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Item_code";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "item_name";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "model_name";
            RecDt.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "serial_match";
            RecDt.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "valid_flag";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "audit_flag";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "match_type";
            RecDt.Columns.Add(column);

            ds.Tables.Add(RecDt);
        }
        /// <summary>
        /// 00015通过医疗证号检索一户参合人员信息
        /// ZKLSH	证卡流水号
        ///YLZH	医疗证号
        ///HZXM	户主姓名
        ///ZNHBH	  组内户编号
        ///HNRBH	户内人编号
        ///YHZGX	与户主关系
        ///GRBM	个人编码
        ///XM	姓名
        ///XB	性别
        ///CSRQ	出生日期
        ///SFZHM	身份证号码
        ///NN	年龄
        ///XDZ	乡镇名称
        ///CDZ	村名称
        ///ZDZ	组名称
        /// </summary>
        /// <param name="ds"></param>
        public static void Out_00015DT(DataSet ds)
        {
            RecDt = new DataTable("Out_00015DT");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ZKLSH";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "YLZH";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "HZXM";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ZNHBH";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "HNRBH";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "YHZGX";
            RecDt.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "GRBM";
            RecDt.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "XM";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "XB";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CSRQ";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SFZHM";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NN";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "XDZ";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CDZ";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ZDZ";
            RecDt.Columns.Add(column);

            ds.Tables.Add(RecDt);
        }
        /// <summary>
        /// 00021获取医疗机构的农合补偿类型
        /// YWLB	补偿类别代码
        /// YWMC	补偿类别名称
        /// </summary>
        /// <param name="ds"></param>
        public static void Out_00021DT(DataSet ds)
        {
            RecDt = new DataTable("Out_00015DT");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "YWLB";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "YWMC";
            RecDt.Columns.Add(column);

            ds.Tables.Add(RecDt);
        }
      
        /// <summary>
        /// 01216	出院结算函数
        /// MEDI_ITEM_CODE	项目编码
        ///MEDI_ITEM_NAME	项目名称
        ///ZFY	总费用
        ///KBXFY	可报销费用
        ///BXBL	报销比例
        ///SXH	顺序号
        /// </summary>
        /// <param name="ds"></param>
        public static void Out_01216DT1(DataSet ds)
        {
            RecDt = new DataTable("Out_01216DT1");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "MEDI_ITEM_CODE";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "MEDI_ITEM_NAME";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ZFY";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "KBXFY";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "BXBL";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SXH";
            RecDt.Columns.Add(column);
            ds.Tables.Add(RecDt);
        }
        /// <summary>
        ///  01216	出院结算函数
        ///  FDH	分段号
        ///FDMC	分段名称
        ///QSJE	起始金额
        ///JSJE	结束金额
        ///TCZFBL	统筹支付比例
        ///KBXFY	可报销费用
        ///JSTCZF	计算统筹支付
        ///SJTCZF	实际统筹支付
        /// </summary>
        /// <param name="ds"></param>
        public static void Out_01216DT2(DataSet ds)
        {
            RecDt = new DataTable("Out_01216DT2");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "FDH";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "FDMC";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "QSJE";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "JSJE";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "TCZFBL";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "KBXFY";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "JSTCZF";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SJTCZF";
            RecDt.Columns.Add(column);
            ds.Tables.Add(RecDt);
        }
        /// <summary>
        ///  01216	出院结算函数
        ///  GRMC	姓名
        ///CYRQ	出院日期
        ///HOSPITAL_NAME	就医机构名称
        ///ZYH	住院号
        ///ZFY	住院医药费
        ///BCRQ	补偿日期
        ///SJBCE	实际补偿额
        ///FKR	付款人
        ///DZBZ	打折标志
        ///ROW_NUMBER	行号
        /// </summary>
        /// <param name="ds"></param>
        public static void Out_01216DT3(DataSet ds)
        {
            RecDt = new DataTable("Out_01216DT3");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "GRMC";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CYRQ";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "HOSPITAL_NAME";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ZYH";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ZFY";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "BCRQ";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SJBCE";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "FKR";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "DZBZ";
            RecDt.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ROW_NUMBER";
            RecDt.Columns.Add(column);
            ds.Tables.Add(RecDt);
        }
        /// <summary>
        /// 01219 住院费用明细信息查询
        /// hos_serial	医院费用主键
        ///fyxh	农合费用序号
        ///hosp_code	医院费用编码
        ///hosp_name	医院费用名称
        ///item_code	农合项目编码
        ///item_name	农合项目名称
        ///gg	医院规格
        ///hosp_model	医院剂型
        ///dj	单价
        ///yl	用量
        ///je	金额
        ///shbz	审核标志
        ///jrbxje	进入补偿金额
        /// </summary>
        /// <param name="ds"></param>
        public static void Out_01219DT(DataSet ds)
        {
            RecDt = new DataTable("Out_01216DT3");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "hos_serial";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "fyxh";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "hosp_code";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "hosp_name";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "item_code";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "item_name";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "gg";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "hosp_model";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "dj";
            RecDt.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "yl";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "je";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "shbz";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "jrbxje";
            RecDt.Columns.Add(column);

            ds.Tables.Add(RecDt);
        }

        /// <summary>
        /// 01204录入住院的费用明细信息函数
        /// HOSP_CODE	医院目录编码
        ///HOSP_NAME	医院目录名称
        ///MEDI_ITEM_TYPE	项目药品类型
        ///Hosp_model	医院目录剂型
        ///Cj	厂家
        ///Gg	规格
        ///DJ	单价
        ///Jldw	计量单位
        ///YL	用量
        ///JE	金额
        ///Hos_serial	医院费用序列号
        ///Opp_serial_fee	对应费用序号
        ///YZCFH	对应处方或医嘱序号
        ///HOSP_TYPE	医院统计类别
        ///FYFSSJ	费用发生时间
        /// </summary>
        /// <param name="ds"></param>
        public static void Put_01204DTywxmmx(DataSet ds, Hashtable hashtable)
        {
            RecDt = new DataTable("Put_01204DTywxmmx");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "HOSP_CODE";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "HOSP_NAME";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "MEDI_ITEM_TYPE";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Hosp_model";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Cj";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Gg";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "DJ";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Jldw";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "YL";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "JE";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Hos_serial";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Opp_serial_fee";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "YZCFH";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "HOSP_TYPE";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "FYFSSJ";
            RecDt.Columns.Add(column);


            ds.Tables.Add(RecDt);

            DataTable dt = (DataTable)hashtable["dt"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = ds.Tables["Put_01204DTywxmmx"].NewRow();
                dr["HOSP_CODE"] = dt.Rows[i]["itemid"].ToString();
                dr["HOSP_NAME"] = dt.Rows[i]["itemname"].ToString();
                dr["MEDI_ITEM_TYPE"] = dt.Rows[i]["prestype"].ToString().Trim() == "4" ? "0" : dt.Rows[i]["prestype"].ToString().Trim();
                dr["Hosp_model"] = "1";
                dr["Cj"] = "1";
                dr["Gg"] = dt.Rows[i]["standard"].ToString().Trim();
                //[20100617.0.01]
                dr["DJ"] = (Convert.ToDecimal(dt.Rows[i]["tolal_fee"].ToString().Trim()) / Convert.ToDecimal(dt.Rows[i]["amount"].ToString().Trim())).ToString("0.00"); //dt.Rows[i]["buy_price"].ToString().Trim();
                dr["Jldw"] = dt.Rows[i]["unit"].ToString().Trim();
                dr["YL"] = dt.Rows[i]["amount"].ToString().Trim();
                dr["JE"] = dt.Rows[i]["tolal_fee"].ToString().Trim();
                dr["Hos_serial"] = dt.Rows[i]["presorderid"].ToString().Trim();
                dr["Opp_serial_fee"] = dt.Rows[i]["oldid"].ToString().Trim();
                dr["YZCFH"] = dt.Rows[i]["order_id"].ToString().Trim() == "" ? "1" : dt.Rows[i]["order_id"].ToString().Trim();
                dr["HOSP_TYPE"] = "01";
                dr["FYFSSJ"] = Convert.ToDateTime(dt.Rows[i]["costdate"]).ToString("yyyy-MM-dd");

                ds.Tables["Put_01204DTywxmmx"].Rows.Add(dr);
            }

        }
        /// <summary>
        /// 01204录入住院的费用明细信息函数
        /// YZCFH	医嘱处方号
        ///ZYH	住院号
        ///KYZYSDM	开医嘱医生代码
        ///KYZYSXM	开医嘱医生姓名
        ///YZTZSJ	医嘱停止时间
        ///TZYZYSDM	停止医嘱医生代码
        ///TZYZYSXM	停止医嘱医生姓名
        ///YZZXSJ	医嘱执行时间
        ///ZXKS	执行科室名称
        ///JZKS	就诊科室名称
        ///BZ	备注
        ///CZYDM	操作员代码
        ///CZYXM	操作员姓名
        /// </summary>
        /// <param name="ds"></param>
        public static void Put_01204DTyzcfmx(DataSet ds, Hashtable hashtable)
        {
            RecDt = new DataTable("Put_01204DTyzcfmx");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "YZCFH";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ZYH";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "KYZYSDM";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "KYZYSXM";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "YZTZSJ";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "TZYZYSDM";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "TZYZYSXM";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "YZZXSJ";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ZXKS";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "JZKS";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "BZ";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CZYDM";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CZYXM";
            RecDt.Columns.Add(column);

            ds.Tables.Add(RecDt);

            DataTable dt = (DataTable)hashtable["dt"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //不添加重复的数据
                if (ds.Tables["Put_01204DTyzcfmx"].Select("YZCFH='" + dt.Rows[i]["order_id2"].ToString().Trim() + "'").Length == 0)
                {
                    DataRow dr = ds.Tables["Put_01204DTyzcfmx"].NewRow();

                    dr["YZCFH"] = GetIsNull(dt.Rows[i]["order_id2"].ToString(), "0");
                    dr["ZYH"] = GetIsNull(hashtable["zyh"]);
                    dr["KYZYSDM"] = GetIsNull(dt.Rows[i]["ORDER_DOC"].ToString().Trim(), "01");
                    dr["KYZYSXM"] = GetIsNull(BaseNameFactory.GetName(baseNameType.用户名称, dt.Rows[i]["ORDER_DOC"].ToString().Trim()), "01");
                    dr["YZTZSJ"] = Convert.ToDateTime(GetIsNull(dt.Rows[i]["EORDER_DATE"],DateTime.Now.ToString("yyyy-MM-dd"))).ToString("yyyy-MM-dd");
                    dr["TZYZYSDM"] = GetIsNull(dt.Rows[i]["EORDER_DOC"].ToString().Trim(), "00");
                    dr["TZYZYSXM"] = GetIsNull(BaseNameFactory.GetName(baseNameType.用户名称, dt.Rows[i]["EORDER_DOC"].ToString().Trim()), "00");
                    dr["YZZXSJ"] = Convert.ToDateTime(GetIsNull(dt.Rows[i]["TRANS_DATE"],DateTime.Now.ToString("yyyy-MM-dd"))).ToString("yyyy-MM-dd");
                    dr["ZXKS"] = GetIsNull(BaseNameFactory.GetName(baseNameType.科室名称, dt.Rows[i]["EXEC_DEPT"].ToString().Trim()), "00");
                    dr["JZKS"] = GetIsNull(hashtable["jzks"], "00");
                    dr["BZ"] = GetIsNull("", "00");
                    dr["CZYDM"] = GetIsNull(hashtable["empid"]);
                    dr["CZYXM"] = GetIsNull(hashtable["name"]);

                    ds.Tables["Put_01204DTyzcfmx"].Rows.Add(dr);
                }
            }
        }

        /// <summary>
        /// 11003	取农医保匹配项目信息函数（中心本院匹配）
        /// HOSPITAL_ID	医疗机构编码
        ///AUDIT_FLAG	匹配状态
        ///ITEM_TYPE	项目类型
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_11003Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("HOSPITAL_ID", MED_ORG_CODE);
            dic.Add("AUDIT_FLAG", GetIsNull( hashtable["AUDIT_FLAG"]));
            dic.Add("ITEM_TYPE", GetIsNull( hashtable["ITEM_TYPE"]));
            return dic;
        }
        /// <summary>
        /// 00011获得业务流水号
        /// HOSPITAL_ID	医院编号
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_00011Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("HOSPITAL_ID", MED_ORG_CODE);
            return dic;
        }
        /// <summary>
        /// 11011 判断单条项目是否已经匹配函数
        /// HOSPITAL_ID	医疗机构编码
        /// MATCH_TYPE	匹配类型
        /// HOSP_CODE	医院目录编码
        /// HOSP_NAME	医院目录名称
        /// Hosp_model	医院目录剂型
        /// </summary>
        public static Dictionary<string, string> Put_11011Dic(Hashtable hashtable)
        {
            dic =new Dictionary<string,string>();
            dic.Add("HOSPITAL_ID", MED_ORG_CODE);
            dic.Add("MATCH_TYPE", GetIsNull( hashtable["Medi_item_type"]));
            dic.Add("HOSP_CODE", GetIsNull( hashtable["code"]));
            dic.Add("HOSP_NAME", GetIsNull( hashtable["chemname"]));
            dic.Add("Hosp_model", GetIsNull( hashtable["model"]));
            return dic;
        }
        /// <summary>
        /// 11006	项目匹配函数
        /// Hospital_id	医疗机构编码
        ///match_type	匹配类型
        ///hosp_code	医院目录编码
        ///hosp_name	医院目录名称
        ///hosp_model	医院目录剂型
        ///Price	单价
        ///item_code	中心目录编码
        ///item_name	中心目录名称
        ///model_name	中心目录剂型
        ///effect_date	生效日期
        ///expire_date	失效日期
        ///edit_staff	操作员工号
        ///edit_man	操作员姓名
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_11006Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("Hospital_id", MED_ORG_CODE);
            dic.Add("match_type", GetIsNull( hashtable["Medi_item_type"]));
            dic.Add("hosp_code", GetIsNull( hashtable["code"]));
            dic.Add("hosp_name", GetIsNull( hashtable["chemname"]));
            dic.Add("hosp_model", GetIsNull( hashtable["model"]));
            dic.Add("Price", GetIsNull( hashtable["price"]));
            dic.Add("item_code", GetIsNull( hashtable["Medi_code"]));
            dic.Add("item_name", GetIsNull( hashtable["Medi_name"]));
            dic.Add("model_name", GetIsNull( hashtable["Model_name"]));
            dic.Add("effect_date", ((DateTime)hashtable["effect_date"]).ToString("yyyy-MM-dd"));
            dic.Add("expire_date", ((DateTime) hashtable["expire_date"]).ToString("yyyy-MM-dd"));
            dic.Add("edit_staff", GetIsNull( hashtable["empid"]));
            dic.Add("edit_man", GetIsNull( hashtable["name"]));
            return dic;
        }
        /// <summary>
        /// 11005	重置匹配信息函数
        /// Serial_match	匹配序列号
        ///Hospital_id	医疗机构编码
        ///match_type	匹配类型
        ///hosp_code	医院目录编码
        ///hosp_name	医院目录名称
        ///hosp_model	医院目录剂型
        ///Price	单价
        ///item_code	中心目录编码
        ///item_name	中心目录名称
        ///model_name	中心目录剂型
        ///effect_date	生效日期
        ///expire_date	失效日期
        ///edit_staff	操作员工号
        ///edit_man	操作员姓名
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_11005Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("Serial_match", GetIsNull( hashtable["Serial_match"]));
            dic.Add("Hospital_id", MED_ORG_CODE);
            dic.Add("match_type", GetIsNull( hashtable["Medi_item_type"]));
            dic.Add("hosp_code", GetIsNull( hashtable["code"]));
            dic.Add("hosp_name", GetIsNull( hashtable["chemname"]));
            dic.Add("hosp_model", GetIsNull( hashtable["model"]));
            dic.Add("Price", GetIsNull( hashtable["price"]));
            dic.Add("item_code", GetIsNull( hashtable["Medi_code"]));
            dic.Add("item_name", GetIsNull( hashtable["Medi_name"]));
            dic.Add("model_name", GetIsNull( hashtable["Model_name"]));
            dic.Add("effect_date", ((DateTime) hashtable["effect_date"]).ToString("yyyy-MM-dd"));
            dic.Add("expire_date", ((DateTime) hashtable["expire_date"]).ToString("yyyy-MM-dd"));
            dic.Add("edit_staff", GetIsNull( hashtable["empid"]));
            dic.Add("edit_man", GetIsNull( hashtable["name"]));
            return dic;
        }
        /// <summary>
        /// 11004	删除匹配信息函数
        /// SERIAL_MATCH	匹配序列号
        ///AUDIT_FLAG	审核标志
        ///EDIT_STAFF	操作员编码
        ///EDIT_MAN	操作员姓名
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_11004Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("SERIAL_MATCH", GetIsNull( hashtable["Serial_match"]));
            dic.Add("AUDIT_FLAG", GetIsNull( hashtable["AUDIT_FLAG"]));
            dic.Add("EDIT_STAFF", GetIsNull( hashtable["EDIT_STAFF"]));
            dic.Add("EDIT_MAN", GetIsNull( hashtable["EDIT_MAN"]));
            return dic;
        }
        /// <summary>
        /// 00015通过医疗证号检索一户参合人员信息
        /// YLZH	医疗证号
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_00015Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("YLZH", GetIsNull( hashtable["MEDICARD"]));
            return dic;
        }
        /// <summary>
        /// 00021获取医疗机构的农合补偿类型
        /// Hospital_id	医疗机构编码
        /// YWBZ	医疗机构业务标志
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_00021Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("HOSPITAL_ID", MED_ORG_CODE);
            dic.Add("YWBZ", "2");
            return dic;
        }
        /// <summary>
        /// 01201	入院登记函数
        /// YKBZ	用卡标志0不用卡 1用卡
        ///GRBM	个人编码
        ///Hospital_id	医疗机构编码
        ///Ywlb	业务类型
        ///Zyfs	住院方式
        ///Djsj	登记时间
        ///Zyksbh	入院科室编号
        ///Zyksmc	入院科室名称
        ///Zybqbh	入院病区编号
        ///Zybqmc	入院病区名称
        ///Zybcbh	入院病床编号
        ///Cwlb	床位类型
        ///Zyh	住院号
        ///ICD_RY	入院诊断
        ///RYZT_ID	入院状态
        ///DJRDM	登记人代码
        ///DJRMC	登记人名称
        ///YWID	业务ID
        ///YLZH	医疗证号
        ///RYSJ	入院时间
        ///YSDM	医生代码
        ///YSMC	医生名称
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_01201Dic(Hashtable hashtable)
        {


            dic = new Dictionary<string, string>();
            dic.Add("YKBZ", "0");
            dic.Add("GRBM", GetIsNull(hashtable["GRBM"]));
            dic.Add("Hospital_id", MED_ORG_CODE);
            dic.Add("Ywlb", GetIsNull(hashtable["Ywlb"]));
            dic.Add("Zyfs", GetIsNull(hashtable["Zyfs"]));
            dic.Add("Djsj", GetIsNull(hashtable["Djsj"]));
            dic.Add("Zyksbh", GetIsNull(hashtable["Zyksbh"]));
            dic.Add("Zyksmc", GetIsNull(hashtable["Zyksmc"]));
            dic.Add("Zybqbh", GetIsNull(hashtable["Zybqbh"]));
            dic.Add("Zybqmc", GetIsNull(hashtable["Zybqmc"]));
            dic.Add("Zybcbh", GetIsNull(hashtable["Zybcbh"]));
            dic.Add("Cwlb", GetIsNull(hashtable["Cwlb"]));
            dic.Add("Zyh", GetIsNull(hashtable["Zyh"]));
            dic.Add("ICD_RY", GetIsNull(hashtable["ICD_RY"], "A01.101"));
            dic.Add("RYZT_ID", "3");// GetIsNull(hashtable["RYZT_ID"]));
            dic.Add("DJRDM", GetIsNull(hashtable["DJRDM"]));
            dic.Add("DJRMC", GetIsNull(hashtable["DJRMC"]));
            dic.Add("YWID", GetIsNull(hashtable["YWID"]));
            dic.Add("YLZH",GetIsNull( hashtable["YLZH"]));
            dic.Add("RYSJ",GetIsNull( hashtable["RYSJ"]));
            dic.Add("YSDM",GetIsNull( hashtable["YSDM"],"00"));
            dic.Add("YSMC",GetIsNull( hashtable["YSMC"],"00"));
            return dic;
        }
        /// <summary>
        /// 01202修改住院(出院)信息函数
        /// hospital_id 	医疗机构编码
        ///Ywid	业务ID号
        ///Id	序号
        ///Ywlb	业务类型
        ///Djrdm	操作员工号
        ///Djrmc	操作员姓名
        ///RYSJ	入院时间
        ///Zyksbh	住院科室编号
        ///Zyksmc	住院科室名称
        ///Zybqbh	住院病区编号
        ///Zybqmc	住院病区名称
        ///Zybcbh	住院病床编号
        ///Cwlb	床位类型
        ///Zyh	住院号
        ///Icd_ry	入院诊断
        ///RYZT_ID	入院状态
        ///Bz	备注
        ///Icd_zy	出院诊断
        ///Cyrq	出院日期
        ///Zyfs	住院方式
        ///Jssj	结算日期
        ///Jsr	结算人
        ///Jsrxm	结算人姓名
        ///OPERATION_CODE	手术代码
        ///Cyzt	出院状态
        ///Jsdh	结算单号
        ///Ysdm	医生代码
        ///Ysmc	医生名称
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_01202Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("hospital_id", MED_ORG_CODE);
            dic.Add("Ywid", "");
            dic.Add("Id", "");
            dic.Add("Ywlb", "");
            dic.Add("Djrdm", "");
            dic.Add("Djrmc", "");
            dic.Add("RYSJ", "");
            dic.Add("Zyksbh", "");
            dic.Add("Zyksmc", "");
            dic.Add("Zybqbh", "");
            dic.Add("Zybqmc", "");
            dic.Add("Zybcbh", "");
            dic.Add("Cwlb", "");
            dic.Add("Zyh", "");
            dic.Add("ICD_RY", "D03");
            dic.Add("RYZT_ID", "");
            dic.Add("Bz", "");
            dic.Add("Icd_zy", "");
            dic.Add("Cyrq", "");
            dic.Add("Zyfs", "");
            dic.Add("Jssj", "");
            dic.Add("Jsr", "");
            dic.Add("Jsrxm", "");
            dic.Add("OPERATION_CODE", "");
            dic.Add("Cyzt", "");
            dic.Add("Jsdh", "");
            dic.Add("Ysdm", "");
            dic.Add("Ysmc", "");
            return dic;
        }
        /// <summary>
        /// 01301	取消入院登记信息函数
        /// HOSPITAL_ID 	医疗机构编码
        ///YWID	业务ID号
        ///Grbm	个人编码
        ///Djrdm	登记人代码
        ///Djrmc	登记人姓名
        ///ID	序号
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_01301Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("hospital_id", MED_ORG_CODE);
            dic.Add("Ywid", GetIsNull( hashtable["Ywid"]));
            dic.Add("Id", GetIsNull( hashtable["Id"]));
            dic.Add("Grbm", GetIsNull( hashtable["Grbm"]));
            dic.Add("Djrdm", GetIsNull( hashtable["Djrdm"]));
            dic.Add("Djrmc", GetIsNull( hashtable["Djrmc"]));
            return dic;
        }
        /// <summary>
        /// 01204录入住院的费用明细信息函数
        /// Hospital_id 	医疗机构编码
        ///Grbm	个人编码
        ///00015通过医疗证号检索一户参合人员信息
        ///Ywlb	业务类型
        ///00021获取医疗机构的农合补偿类型
        ///Ywid	业务ID号
        ///00011获得业务流水号
        ///ID	业务内序号
        ///01201	入院登记函数
        ///Lrrdm	录入人代码
        ///Lrrxm	录入人姓名
        ///Lrsj	录入时间
        ///Cfh		处方号
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_01204Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("hospital_id", MED_ORG_CODE);
            dic.Add("Grbm", GetIsNull( hashtable["Grbm"]));
            dic.Add("Ywlb", GetIsNull( hashtable["Ywlb"]));
            dic.Add("Ywid", GetIsNull( hashtable["Ywid"]));
            dic.Add("ID", GetIsNull(hashtable["Id"]));
            dic.Add("Lrrdm", GetIsNull( hashtable["Lrrdm"]));
            dic.Add("Lrrxm", GetIsNull( hashtable["Lrrxm"]));
            dic.Add("Lrsj", GetIsNull( hashtable["Lrsj"]));
            dic.Add("Cfh", GetIsNull( hashtable["Cfh"]));
            return dic;
        }
        /// <summary>
        /// 01216	出院结算函数
        /// hospital_id 	医疗机构编码
        ///Ywid	业务ID号
        ///Id	序号
        ///Ywlb	业务类型
        ///Djrdm	操作员工号
        ///Djrmc	操作员姓名
        ///RYSJ	入院时间
        ///Zyksbh	住院科室编号
        ///Zyksmc	住院科室名称
        ///Zybqbh	住院病区编号
        ///Zybqmc	住院病区名称
        ///Zybcbh	住院病床编号
        ///Cwlb	床位类型
        ///Zyh	住院号
        ///Icd_ry	入院诊断
        ///RYZT_ID	入院状态
        ///Bz	备注
        ///Icd_zy	出院诊断
        ///Cyrq	出院日期
        ///Zyfs	住院方式
        ///Jssj	结算日期
        ///Jsr	结算人
        ///Jsrxm	结算人姓名
        ///OPERATION_CODE	手术代码
        ///Cyzt	出院状态
        ///Jsdh	结算单号
        ///Ysdm	医生代码
        ///Ysmc	医生名称
        ///Zfy	已传输费用总额
        ///Ylzh	医疗证号
        ///JSBZ	计算标志（0：试算 1：结算）
        ///QTBCFS	前台补偿方式（0:先付后补,1:即付即补）
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_01216Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("hospital_id", MED_ORG_CODE);
            dic.Add("Ywid", GetIsNull(hashtable["Ywid"]));
            dic.Add("Id", GetIsNull(hashtable["Id"]));
            dic.Add("Ywlb", GetIsNull(hashtable["Ywlb"]));
            dic.Add("Djrdm", GetIsNull(hashtable["DJRDM"]));
            dic.Add("Djrmc", GetIsNull(hashtable["DJRMC"]));
            dic.Add("RYSJ", GetIsNull(hashtable["RYSJ"])); //?
            dic.Add("Zyksbh", GetIsNull(hashtable["Zyksbh"]));
            dic.Add("Zyksmc", GetIsNull(hashtable["Zyksmc"]));
            dic.Add("Zybqbh", GetIsNull(hashtable["Zybqbh"]));
            dic.Add("Zybqmc", GetIsNull(hashtable["Zybqmc"]));
            dic.Add("Zybcbh", GetIsNull(hashtable["Zybcbh"]));
            dic.Add("Cwlb", GetIsNull(hashtable["Cwlb"]));
            dic.Add("Zyh", GetIsNull(hashtable["Zyh"]));
            dic.Add("ICD_RY", GetIsNull(hashtable["ICD_RY"], "A01.101"));
            dic.Add("RYZT_ID", "3");// GetIsNull(hashtable["RYZT_ID"]));

            dic.Add("Bz", "11");

            dic.Add("Icd_zy", GetIsNull(hashtable["Icd_zy"], "A01.101"));
            dic.Add("Cyrq", GetIsNull(hashtable["Cyrq"]));
            dic.Add("Zyfs", GetIsNull(hashtable["Zyfs"]));
            dic.Add("Jssj", GetIsNull(hashtable["Jssj"]));
            dic.Add("Jsr", GetIsNull(hashtable["Jsr"]));
            dic.Add("Jsrxm", GetIsNull(hashtable["Jsrxm"]));
            dic.Add("OPERATION_CODE", GetIsNull(hashtable["OPERATION_CODE"],"00"));
            dic.Add("Cyzt", GetIsNull(hashtable["Cyzt"]));
            dic.Add("Jsdh", GetIsNull(hashtable["Jsdh"]));
            dic.Add("Ysdm", GetIsNull(hashtable["YSDM"]));
            dic.Add("Ysmc", GetIsNull(hashtable["YSMC"]));
            dic.Add("Zfy", GetIsNull(hashtable["Zfy"]));  //?
            dic.Add("Ylzh", GetIsNull(hashtable["Ylzh"]));
            dic.Add("JSBZ", GetIsNull(hashtable["JSBZ"]));
            dic.Add("QTBCFS", GetIsNull(hashtable["QTBCFS"]));
            return dic;
        }
        /// <summary>
        /// 00020 判断业务是否已经在农合补偿
        /// Hospital_id	医疗机构编码
        /// Ywid	业务Id号
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_00020Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("hospital_id", MED_ORG_CODE);
            dic.Add("Ywid", GetIsNull(hashtable["Ywid"]));
            return dic;
        }
        /// <summary>
        /// 01217取消出院函数
        /// hospital_id 	医疗机构编码
        ///Ywid	业务ID号
        ///Id	序号
        ///Ywlb	业务类型
        ///Djrdm	操作员工号
        ///Djrmc	操作员姓名
        ///RYSJ	入院时间
        ///Zyksbh	住院科室编号
        ///Zyksmc	住院科室名称
        ///Zybqbh	住院病区编号
        ///Zybqmc	住院病区名称
        ///Zybcbh	住院病床编号
        ///Cwlb	床位类型
        ///Zyh	住院号
        ///Icd_ry	入院诊断
        ///RYZT_ID	入院状态
        ///Bz	备注
        ///Icd_zy	出院诊断
        ///Cyrq	出院日期
        ///Zyfs	住院方式
        ///Jssj	结算日期
        ///Jsr	结算人
        ///Jsrxm	结算人姓名
        ///OPERATION_CODE	手术代码
        ///Cyzt	出院状态
        ///Jsdh	结算单号
        ///Ysdm	医生代码
        ///Ysmc	医生名称
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_01217Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("hospital_id", MED_ORG_CODE);

            dic.Add("Ywid", GetIsNull(hashtable["Ywid"]));
            dic.Add("Id", GetIsNull(hashtable["Id"]));
            dic.Add("Ywlb", GetIsNull(hashtable["Ywlb"]));
            dic.Add("Djrdm", GetIsNull(hashtable["DJRDM"]));
            dic.Add("Djrmc", GetIsNull(hashtable["DJRMC"]));
            //dic.Add("RYSJ", GetIsNull(hashtable["RYSJ"]));
            dic.Add("Zyksbh", GetIsNull(hashtable["Zyksbh"]));
            dic.Add("Zyksmc", GetIsNull(hashtable["Zyksmc"]));
            dic.Add("Zybqbh", GetIsNull(hashtable["Zybqbh"]));
            dic.Add("Zybqmc", GetIsNull(hashtable["Zybqmc"]));
            dic.Add("Zybcbh", GetIsNull(hashtable["Zybcbh"]));
            dic.Add("Cwlb", GetIsNull(hashtable["Cwlb"]));
            dic.Add("Zyh", GetIsNull(hashtable["Zyh"]));
            dic.Add("ICD_RY", GetIsNull(hashtable["ICD_RY"], "A01.101"));
            dic.Add("RYZT_ID", "3");// GetIsNull(hashtable["RYZT_ID"]));

            dic.Add("Bz", "11");

            dic.Add("Icd_zy", GetIsNull(hashtable["Icd_zy"], "A01.101"));
            dic.Add("Cyrq", GetIsNull(hashtable["Cyrq"]));
            dic.Add("Zyfs", GetIsNull(hashtable["Zyfs"]));
            dic.Add("Jssj", "");
            dic.Add("Jsr","");
            dic.Add("Jsrxm", "");
            dic.Add("OPERATION_CODE", "");
            dic.Add("Cyzt", "");
            dic.Add("Jsdh","");
            dic.Add("Ysdm", GetIsNull(hashtable["YSDM"]));
            dic.Add("Ysmc", GetIsNull(hashtable["YSMC"]));
            return dic;
        }
        /// <summary>
        /// 01219 住院费用明细信息查询
        /// hospital_id 	医疗机构编码
        /// Ywid	业务ID号
        /// Id	序号
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_01219Dic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();
            dic.Add("hospital_id", MED_ORG_CODE);
            dic.Add("Ywid", GetIsNull(hashtable["Ywid"],"1"));
            dic.Add("Id", GetIsNull(hashtable["Id"], "1"));
            return dic;
        }

        public static string GetIsNull(object obj, bool b)
        {
            if (obj == null || obj == DBNull.Value)
            {
                if (b)
                    return "";
                else
                    return "00";
            }
            else
            {
                if (obj.ToString() == "" && b==false)
                {
                    return "00";
                }
                return obj.ToString();
            }
        }

        public static string GetIsNull(object obj, string str)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return str;
            }
            else
            {
                if (obj.ToString() == "")
                {
                    return str;
                }
                return obj.ToString();
            }
        }

        public static string GetIsNull(object obj)
        {
            return GetIsNull(obj, "");
        }
    }
}
