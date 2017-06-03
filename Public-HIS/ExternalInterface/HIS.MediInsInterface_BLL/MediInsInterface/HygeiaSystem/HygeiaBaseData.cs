using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace HIS.MediInsInterface_BLL.MediInsInterface.HygeiaSystem
{
    public class HygeiaBaseData
    {
        /// <summary>
        /// 中心代码 
        /// </summary>
        public static string Center_Id = "";
        /// <summary>
        /// 中心名称 
        /// </summary>
        public static string Center_Name = "";
        /// <summary>
        /// 医院编码
        /// </summary>
        public static string HospId = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.MED_ORG_CODE;
        /// <summary>
        /// 地址
        /// </summary>
        public static string Addr = "";
        /// <summary>
        /// 端口
        /// </summary>
        public static int Port = 7001;
        /// <summary>
        /// 服务器
        /// </summary>
        public static string Servlet = "";

        /// <summary>
        /// Debug标记
        /// </summary>
        public static int DebugFlag = 0;

        /// <summary>
        /// 系统路径
        /// </summary>
        public static string AppPath = "";

        public enum BUSI_TYPE
        {
            普通门诊 = 11,
            普通住院 = 12,
            门诊特殊病 = 13,
            家庭病床 = 14,
            门诊急救 = 15,
            特治特检 = 16,
            急诊留观 = 17,
            工伤门诊 = 41,
            工伤住院 = 42,
            生育门诊 = 51,
            生育住院 = 52
        }

        /// <summary>
        /// 项目药品匹配信息结构
        /// </summary>
        public struct MatchInfo
        {
            public string Center_id;        //医保中心编码
            public string hospital_id;		//医疗机构编码
            public string Hosp_code;		//医院目录编码
            public string Hosp_name;		//医院目录名称
            public string Hosp_model;		//医院目录剂型
            public string Stat_type;        //费用统计类别
            public string price;			//单价
            public string item_code;		//中心目录编码
            public string Item_name;		//中心目录名称
            public string Model_name;		//中心目录剂型
            public string Serial_match;		//匹配序列号
            public string Valid_flag;		//有效标志
            public string Audit_flag;		//审核标志
            public string Match_type;		//匹配类型
            public string Staple_flag;		//甲乙标志
            public string Self_scale;       //自付比例

            public string effect_date;		//生效日期
            public string expire_date;		//失效日期
            public string edit_staff;		//操作员工号
            public string edit_man;			//操作员姓名
            public string edit_date;		//操作员登记日期
        }
        /// <summary>
        /// 医保病人信息结构
        /// </summary>
        public struct HyInfo
        {
            /// <summary>
            /// /////////personinfo///////////
            /// </summary>
            public string indi_id;	            //个人电脑号
            public string serial_no;            //就医登记号
            public string center_id;	        //中心编码
            public string center_name;	        //中心名称
            public string name;	                //姓名
            public string sex;	                //性别
            public string pers_type;	        //人员类别
            public string pers_name;	        //人员类别名称	
            public string indi_join_sta;        //个人状态
            public string indi_sta_name;	    //人员状态名称
            public string official_code;	    //公务员级别编码
            public string official_name;	    //公务员级别名称
            public string hire_type;			//用工形式编码
            public string hire_name;			//用工形式名称
            public string idcard;               //医保卡号
            public string insr_code;            //保险号
            public string telephone;	        //联系电话
            public string birthday;	            //出生日期
            public string post_code;		    //地区编码
            public string corp_id;              //单位编码
            public string corp_code;            //单位代码
            public string corp_name;            //单位名称
            public string corp_sta_code;        //单位状态
            public string freeze_sta;		    //基金冻结状态
            public string last_balance;         //个人帐户余额

            /////////////
            ///spinfo//////////////////
            //////
            public string serial_apply;    	    //业务申请序列号		
            public string biz_type;	            //业务类型
            public string biz_name;         	//业务名称
            public string apply_content;    	//申请内容编码
            public string apply_content_name;	//申请内容名称	
            public string treatment_type;   	//待遇类型
            public string treatment_name;   	//待遇名称
            public string admit_effect;     	//申请生效日期
            public string admit_date;	        //申请失效日期		
            public string icd;					//诊断编码
            public string disease;	            //申请病种名称
            public string injury_borth_sn;   	//工伤生育序列号

            /////////////
            ///elseinfo//////////////////////
            ////////////
            public string rela_hosp_id;	    	//关联医疗机构编码
            public string rela_serial_no; 		//关联业务序列号
            public string rela_serial_apply;   	//转院申请序列号
            public string reg_flag;		        //入院标志
            public string biz_times;		    //本年度住院次数
            public string declare_year;		    //本能住院申报累计

            //////////////
            ///lastbizinfo////////////
            //////////////
            public string L_hospital_id;	    //医疗机构编号
            public string L_biz_type;	        //业务类型
            public string L_center_id;	        //中心编码
            public string L_center_name;	    //中心名称
            public string L_indi_id;	        //个人电脑号
            public string L_name;	            //姓名
            public string L_sex;	            //性别
            public string L_idcard;             //公民身份号码
            public string L_ic_no;	            //IC卡号
            public string L_birthday;	        //出生日期
            public string L_telephone;	        //联系电话
            public string L_corp_id;	        //单位编码
            public string L_corp_name;	        //单位名称
            public string L_treatment_type;	    //待遇类别
            public string L_reg_date;	        //业务登记日期
            public string L_reg_staff;	        //登记人工号
            public string L_reg_man;	        //登记人
            public string L_reg_flag;	        //登记标志
            public string L_begin_date;	        //业务开始时间
            public string L_reg_info;	        //业务开始情况
            public string L_in_dept;	        //入院科室
            public string L_in_dept_name;	    //入院科室名称
            public string L_in_area;	        //入院病区
            public string L_in_area_name;	    //入院病区名称
            public string L_in_bed;	            //入院床位号
            public string L_patient_id;	        //医院业务号(挂号)
            public string L_in_disease;	        //入院疾病诊断（icd码）
            public string L_disease;	        //入院诊断疾病名称

            public string in_disease_name;	    //入院诊断疾病名称
            public string diagnose;         	//确认疾病诊断（icd码）
            public string diagnose_name;	    //确认诊断名称
            public string diagnose_date;	    //确诊日期
            public string fin_disease;	        //出院疾病诊断（icd码）
            public string fin_disease_name;	    //出院诊断名称
            public string end_date;	            //出院日期
            public string in_days;	            //住院天数
            public string end_staff;	        //出院登记人工号
            public string end_man;	            //出院登记人
            public string finish_flag;	        //出院标志
            public string trade_no;	            //发送方交易号

            ////////////////
            ///freezeinfo//////////
            ///////////////
            public string fund_id;	            //基金编号
            public string fund_name;	        //基金名称
            public string indi_freeze_status;   //基金状态标志"0"——"正常" "1"——"冻结""2"——"暂停参保" "3"——"中止参保" "9"—— "未参保"

            public string real_pay;	            //支付金额
            public string bill_no;	            //单据号

            //////////////////
            ///totalbizinfo////////////
            /////////////////  
            public string biz_year;	            //本年业务总次数
            public string drug_year;	        //本年购药次数
            public string diag_year;	        //本年门诊次数
            public string inhosp_year;	        //本年住院次数
            public string special_year;	        //本年门诊特殊病次数
            public string fee_year;	            //本年总费用
            public string fund_year;	        //本年统筹基金累计支出
            public string acct_year;	        //本年个人帐户累计支出
            public string additional_year;      //本年大病互助金累计支出
            public string retire_year;	        //本年离休基金累计支出
            public string official_year;        //本年公务员补助累计支出
            public string qfx_year;	            //本年住院起付线支出
            public string T_declare_year;	    //本年申报费用累计

            /////////////////////
            ///injuryorbirthinfo///////////////
            ////////////////////
            public string serial_bo_no;      	//工伤生育序列号

            /////////////////////
            ///icinfo///////////////
            ////////////////////
            public string card_no;         	//工伤生育序列号
            public string indi_sta;         	//个人状态
            public string total_salary;       	//月平均工资

            /// <summary>
            /// /////////bizinfo///////////
            /// </summary>
            public string hospital_id;       	//医疗机构编号
            //		public string biz_type;         	//业务类型
            //		public string center_id;         	//中心编码
            //		public string indi_id;          	//个人电脑号
            //		public string name;       	        //姓名
            //		public string sex;       	        //性别
            //		public string idcard;           	//公民身份号码
            public string ic_no;            	//医保卡号
            //		public string birthday;          	//出生日期
            //		public string telephone;        	//联系电话
            //		public string pers_type;        	//人员类别
            //		public string pers_name;        	//人员类别名称
            //		public string official_code;       	//公务员级别编码
            //		public string official_name;      	//公务员级别名称
            //		public string corp_id;          	//单位编码
            //		public string corp_name;         	//单位名称
            //		public string treatment_type;      	//待遇类别
            public string reg_date;         	//业务登记日期
            public string reg_staff;        	//登记人工号
            public string reg_man;          	//登记人
            //		public string reg_flag;         	//登记标志
            public string begin_date;       	//业务开始时间
            public string reg_info;         	//业务开始情况
            public string in_dept;          	//入院科室
            public string in_dept_name;        	//入院科室名称
            public string in_area;          	//入院病区
            public string in_area_name;       	//入院病区名称
            public string in_bed;       	    //入院床位号
            public string patient_id;       	//医院业务号(挂号)
            public string in_disease;       	//入院疾病诊断（icd码）
            //		public string in_disease_name;     	//入院诊断疾病名称
            //		public string diagnose;         	//确认疾病诊断（icd码）
            //		public string diagnose_name;       	//确认诊断名称
            //		public string diagnose_date;       	//确诊日期
            //		public string fin_disease;       	//出院疾病诊断（icd码）
            //		public string fin_disease_name;    	//出院诊断名称
            //		public string end_date;         	//出院日期
            //		public string in_days;          	//住院天数
            //		public string end_staff;         	//出院登记人工号
            //		public string end_man;          	//出院登记人
            //		public string finish_flag;       	//出院标志
            //		public string trade_no;         	//发送方交易号
            //		public string serial_no;        	//就医登记号

            /// <summary>
            /// /////////diagnoseinfo ///////////
            /// </summary>
            public string foregift;         	//预付款总额
            public string remark;           	//病情备注

        }
        /// <summary>
        /// 病人费用结构
        /// </summary>
        public struct ZyFeeInfo
        {
            public string hospital_id;      //医疗机构编码
            public string indi_id;          //个人电脑号
            public string biz_type;         //业务类型
            public string serial_no;        //就医登记号
            public string input_staff;      //录入人工号
            public string input_man;        //录入人姓名
            public string recipe_no;        //处方号	
            public string doctor_no;        //处方医生编号
            public string doctor_name;      //处方医生姓名

            public string medi_item_type;	//项目药品类型
            public string stat_type;	    //费用统计类别
            public string his_item_code;	//医院药品项目编码
            public string item_code;	    //中心药品项目编码
            public string item_name;	    //中心药品项目名称
            public string his_item_name;	//医院药品项目名称
            public string model;	        //剂型
            public string factory;	        //厂家
            public string standard;	        //规格
            public string fee_date;     	//费用发生时间
            public string unit;	            //计量单位	
            public string price;	        //单价
            public string dosage;	        //用量
            public string money;	        //金额
            public string usage_flag;	    //用药标志
            public string usage_days;	    //出院带药天数
            public string opp_serial_fee;	//对应费用序列号
            public string hos_serial;	    //医院费用序列号
            public string remark;	        //备注	

        }
        /// <summary>
        /// 住院结算单结构
        /// </summary>
        public struct ZyDischargeInfo
        {
            /// <summary>
            /// /////////info ///////////
            /// </summary>
            public string indi_id;                      //个人电脑号
            public string name;                         //姓名
            public string sex;                          //性别
            public string birthday;                     //出生日期
            public string ic_no;                        //IC卡号
            public string idcard;                       //身份证号码
            public string pers_name;                    //人员类别名称
            public string office_grade;                 //公务员级别
            public string Official_name;                //公务员级别名称
            public string patient_id;                   //住院号
            public string hospital_name;                //医疗机构名称
            public string hosp_level_name;              //医疗机构级别
            public string hosp_grade_name;              //医疗机构等级
            public string corp_name;                    //单位名称
            public string in_disease;                   //入院诊断
            public string fin_disease;                  //出院诊断
            public string begin_date;                   //入院日期
            public string end_date;                    //出院日期
            public string days;                        //住院天数
            public string in_dept_name;                 //科室名称
            public string treatment_type;               //待遇类型
            public string treatment_name;               //待遇类型名称

            /// <summary>
            /// /////////fee ///////////
            /// </summary>
            public string stat_type;                    //收费项目类型
            public string stat_name;                    //收费项目名称
            public string zfy;                          //总费用
            public string qzf;                          //个人完全自费
            public string blzf;                         //个人部分自负

            /// <summary>
            /// /////////seg ///////////
            /// </summary>
            public string policy_type;                  //支付名称
            public string total_pay;                    //总费用
            public string cash_pay;                     //现金
            public string acct_pay;                     //个人帐户支付
            public string base_pay;                     //统筹支付
            public string additional_pay;               //大病救助
            public string official_pay;                 //公务员补助
            public string hosp_pay;                     //医院支付
            public string corp_pay;                     //企业补助

            /// <summary>
            /// /////////fund ///////////
            /// </summary>
            public string F_total_pay;                    //企业补助
            public string F_fund_pay;                     //统筹支付
            public string F_db_pay;                       //大病支付
            public string F_self_pay;                     //个人全自费
            public string F_Part_pay;                     //个人部分自付
            public string F_part_pay_offi;                //部分自付公务员补助
            public string F_start_pay;                    //起伏线
            public string F_start_pay_offi;               //起伏线公务员补助
            public string F_base_pay;                     //统筹段费用
            public string F_self_pay_seg;                 //统筹段个人自付
            public string F_official_pay_seg;             //统筹段公务员补助
            public string F_additional_pay;               //大病段费用
            public string F_additional_pay_cash;          //大病段个人自付
            public string F_additional_pay_offi;          //大病段公务员补助
            public string F_declare_pay;                  //申报费用
            public string F_self_pay_exceed;              //超标个人自付
        }
        /// <summary>
        /// 医保病人门诊登记信息结构
        /// </summary>
        public struct BizInfo
        {
            public string serial_no;                //就医登记号
            public string trade_no;                 //发送方交易流水号
            public string bill_no;                  //单据号
            public string fund_name;                //基金支付名称
            public string real_pay;                 //基金支付金额
            public string fund_id;                  //基金类别
        }

        static DataTable RecDt;
        static Dictionary<string, string> dic;

        /// <summary>
        /// 取中心药品目录总条数
        /// 取中心药品目录分页信息(BIZC110118)  
        /// center_id	中心编码	10	否	
        ///type	操作类型	20	否	传入“version” 
        ///condition	查询条件	100	否	传入“bs_medi”
        ///once_find	查询情况返回标志	1	否	1：表示返回查询结果的总记录数  0：表示不返回
        ///first_row	查询起始行数	10	否	分页查询时，输入的开始行号
        ///last_row	查询结束行数	10	否	分页查询时，输入的结束行号
        ///first_version_id	查询起始版本号	10	否	传入“1”
        ///last_version_id	查询结束版本号	10	否	传入“1000000”
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_BIZC110118_DrugCountDic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();

            dic.Add("center_id", Center_Id);
            dic.Add("type", "version");
            dic.Add("condition", "bs_medi");
            dic.Add("once_find", "1");
            dic.Add("first_row", "1");
            dic.Add("last_row", "1000");
            dic.Add("first_version_id", "1");
            dic.Add("last_version_id", "500000");
            dic.Add("last_date", DateTime.Now.ToString());
            return dic;
        }

        /// <summary>
        /// 取中心项目目录总条数
        /// 取中心项目目录分页信息(BIZC110118)  
        /// center_id	中心编码	10	否	
        ///type	操作类型	20	否	传入“version” 
        ///condition	查询条件	100	否	传入“bs_medi”
        ///once_find	查询情况返回标志	1	否	1：表示返回查询结果的总记录数  0：表示不返回
        ///first_row	查询起始行数	10	否	分页查询时，输入的开始行号
        ///last_row	查询结束行数	10	否	分页查询时，输入的结束行号
        ///first_version_id	查询起始版本号	10	否	传入“1”
        ///last_version_id	查询结束版本号	10	否	传入“1000000”
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_BIZC110118_ItemCountDic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();

            dic.Add("center_id", Center_Id);
            dic.Add("type", "version");
            dic.Add("condition", "bs_item");
            dic.Add("once_find", "1");
            dic.Add("first_row", "1");
            dic.Add("last_row", "1000");
            dic.Add("first_version_id", "1");
            dic.Add("last_version_id", "500000");
            dic.Add("last_date", DateTime.Now.ToString());
            return dic;
        }

        /// <summary>
        /// 取中心药品目录分页信息(BIZC110118)  
        /// center_id	中心编码	10	否	
        ///type	操作类型	20	否	传入“version” 
        ///condition	查询条件	100	否	传入“bs_medi”
        ///once_find	查询情况返回标志	1	否	1：表示返回查询结果的总记录数  0：表示不返回
        ///first_row	查询起始行数	10	否	分页查询时，输入的开始行号
        ///last_row	查询结束行数	10	否	分页查询时，输入的结束行号
        ///first_version_id	查询起始版本号	10	否	传入“1”
        ///last_version_id	查询结束版本号	10	否	传入“1000000”
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_BIZC110118_DrugDic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();

            dic.Add("center_id", Center_Id);
            dic.Add("type", "version");
            dic.Add("condition", "bs_medi");
            dic.Add("once_find", "0");
            dic.Add("first_row", "1");
            dic.Add("last_row", hashtable["count"].ToString());
            dic.Add("first_version_id", "1");
            dic.Add("last_version_id", "500000");
            dic.Add("last_date", DateTime.Now.ToString());
            return dic;
        }

        /// <summary>
        /// 取中心项目目录分页信息(BIZC110118)  
        /// center_id	中心编码	10	否	
        ///type	操作类型	20	否	传入“version” 
        ///condition	查询条件	100	否	传入“bs_medi”
        ///once_find	查询情况返回标志	1	否	1：表示返回查询结果的总记录数  0：表示不返回
        ///first_row	查询起始行数	10	否	分页查询时，输入的开始行号
        ///last_row	查询结束行数	10	否	分页查询时，输入的结束行号
        ///first_version_id	查询起始版本号	10	否	传入“1”
        ///last_version_id	查询结束版本号	10	否	传入“1000000”
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Put_BIZC110118_ItemDic(Hashtable hashtable)
        {
            dic = new Dictionary<string, string>();

            dic.Add("center_id", Center_Id);
            dic.Add("type", "version");
            dic.Add("condition", "bs_item");
            dic.Add("once_find", "0");
            dic.Add("first_row", "1");
            dic.Add("last_row", hashtable["count"].ToString());
            dic.Add("first_version_id", "1");
            dic.Add("last_version_id", "500000");
            dic.Add("last_date", DateTime.Now.ToString());
            return dic;
        }

        /// <summary>
        /// 2." pageinfo"，查询结果信息，包含以下内容：
        /// item_code	项目编码
        ///item_name	项目名称
        ///class_code	项目分类编码
        ///unit	标准单位
        ///price	标准单价
        ///medi_item_type	项目类型
        ///stat_type	项目费用分类
        ///code_wb	五笔码
        ///code_py		拼音码
        ///self_scale	标准单价
        ///effect_date	生效日期
        ///expire_date	失效日期
        ///otc	处方用药标志
        ///mt_flag	医疗目录
        ///wl_flag	工伤补充目录
        ///bo_flag	生育补充目录
        ///sp_flag	特殊人群补充目录
        /// </summary>
        /// <param name="ds"></param>
        public static void Out_BIZC110118_ItemDT(DataSet ds)
        {
            RecDt = new DataTable("pageinfo");
            DataColumn col;

            col = new System.Data.DataColumn("item_code");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("item_name");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("class_code");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("unit");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("price");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("medi_item_type");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("stat_type");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("code_wb");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("code_py");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("self_scale");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("effect_date");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("expire_date");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("otc");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("mt_flag");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("wl_flag");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("bo_flag");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("sp_flag");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("valid_flag");
            RecDt.Columns.Add(col);

            ds.Tables.Add(RecDt);
        }

        /// <summary>
        /// 2." pageinfo"，查询结果信息，包含以下内容：
        ///medi_code	药品编码
        ///medi_name	药品名称
        ///english_name	药品英名名
        ///model	剂型编码
        ///model_name	剂型名称
        ///medi_item_type	药品类型
        ///stat_type	药品费用分类
        ///code_wb	五笔码
        ///code_py		拼音码
        ///price	标准单价
        ///staple_flag	甲/乙标志
        ///effect_date	生效日期
        ///expire_date	失效日期
        ///otc	处方用药标志
        ///mt_flag	医疗目录
        ///wl_flag	工伤补充目录
        ///bo_flag	生育补充目录
        ///sp_flag	特殊人群补充目录
        /// </summary>
        /// <param name="ds"></param>
        public static void Out_BIZC110118_DrugDT(DataSet ds)
        {
            RecDt = new DataTable("pageinfo");
            DataColumn col;

            col = new System.Data.DataColumn("medi_code");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("medi_name");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("english_name");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("model");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("model_name");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("medi_item_type");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("stat_type");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("code_wb");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("code_py");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("price");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("staple_flag");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("effect_date");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("expire_date");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("otc");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("mt_flag");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("wl_flag");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("bo_flag");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("sp_flag");
            RecDt.Columns.Add(col);
            col = new System.Data.DataColumn("valid_flag");
            RecDt.Columns.Add(col);

            ds.Tables.Add(RecDt);
        }
        /// <summary>
        /// 3.2.6	新增医院目录匹配(BIZC110201)
        /// center_id	中心编码	10	否	
        ///hospital_id	医院编码	20	否	
        ///match_type	匹配类型	1	否 "0"：诊疗项目匹配
                                        ///"1"：西药匹配
                                        ///"2"：中成药匹配
                                        ///"3"：中草药匹配
        ///hosp_code	医院目录编码	20	否	
        ///hosp_name	医院目录名称	100	否	
        ///hosp_model	医院目录剂型	20	否	
        ///price	单价	8	是	
        ///item_code	中心目录编码	20	否	
        ///item_name	中心目录名称	50	否	
        ///model_name	中心目录剂型	20	否	
        ///effect_date	生效日期	20	否	格式:YYYY-MM-DD hh:mm:ss
        ///expire_date	失效日期	20	否	格式:YYYY-MM-DD hh:mm:ss
        ///edit_staff	操作员工号	10	否	
        ///edit_man	操作员姓名	30	否	
        ///valid_flag	有效标志	1	否	传入参数“1”
        ///audit_flag	审核标志	1	否	传入参数“0”
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="hashtable"></param>
        public static void Put_BIZC110201DTAdd(DataSet ds, Hashtable hashtable)
        {
            RecDt = new DataTable("insertinfo");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "center_id";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "hospital_id";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "match_type";
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
            column.ColumnName = "hosp_model";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "price";
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
            column.ColumnName = "model_name";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "effect_date";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "expire_date";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "edit_staff";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "edit_man";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "valid_flag";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "audit_flag";
            RecDt.Columns.Add(column);

            ds.Tables.Add(RecDt);

            MatchInfo matchInfo = (MatchInfo)hashtable["matchInfo"];


            DataRow dr = ds.Tables["insertinfo"].NewRow();
            dr["center_id"] = matchInfo.Center_id;      //中心编码
            dr["hospital_id"] = matchInfo.hospital_id;  //医疗机构编码
            dr["match_type"] = matchInfo.Match_type;    //匹配类型
            dr["hosp_code"] = matchInfo.Hosp_code;      //医院目录编码
            dr["hosp_name"] = matchInfo.Hosp_name;      //医院目录名称
            dr["hosp_model"] = matchInfo.Hosp_model;    //医院目录剂型
            dr["price"] = matchInfo.price;              //单价
            dr["item_code"] = matchInfo.item_code;      //中心目录编码
            dr["item_name"] = matchInfo.Item_name;      //中心目录名称
            dr["model_name"] = matchInfo.Model_name;    //中心目录剂型
            dr["effect_date"] = matchInfo.effect_date;  //生效日期
            dr["expire_date"] = matchInfo.expire_date;  //失效日期
            dr["edit_staff"] = matchInfo.edit_staff;    //操作员工号 
            dr["edit_man"] = matchInfo.edit_man;        //操作员姓名
            dr["audit_flag"] = matchInfo.Audit_flag;      //审核标志
            dr["valid_flag"] = matchInfo.Valid_flag;    //有效标志

            //dr["edit_date"] = matchInfo.edit_date;      //操作员登记日期
            //dr["Staple_flag"] = matchInfo.Staple_flag;  //药品性质类型
            //dr["Stat_type"] = matchInfo.Stat_type;      //费用统计类别
            

            ds.Tables["insertinfo"].Rows.Add(dr);

        }

        public static void Put_BIZC110201DTDel(DataSet ds, Hashtable hashtable)
        {
            RecDt = new DataTable("insertinfo");
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "center_id";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "hospital_id";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "match_type";
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
            column.ColumnName = "hosp_model";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "price";
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
            column.ColumnName = "model_name";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "effect_date";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "expire_date";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "edit_staff";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "edit_man";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "valid_flag";
            RecDt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "audit_flag";
            RecDt.Columns.Add(column);

            ds.Tables.Add(RecDt);

            MatchInfo matchInfo = (MatchInfo)hashtable["matchInfo"];


            DataRow dr = ds.Tables["insertinfo"].NewRow();
            dr["center_id"] = matchInfo.Center_id;      //中心编码
            dr["hospital_id"] = matchInfo.hospital_id;  //医疗机构编码
            dr["match_type"] = matchInfo.Match_type;    //匹配类型
            dr["hosp_code"] = matchInfo.Hosp_code;      //医院目录编码
            dr["hosp_name"] = matchInfo.Hosp_name;      //医院目录名称
            dr["hosp_model"] = matchInfo.Hosp_model;    //医院目录剂型
            dr["price"] = matchInfo.price;              //单价
            dr["item_code"] = matchInfo.item_code;      //中心目录编码
            dr["item_name"] = matchInfo.Item_name;      //中心目录名称
            dr["model_name"] = matchInfo.Model_name;    //中心目录剂型
            dr["effect_date"] = matchInfo.effect_date;  //生效日期
            dr["expire_date"] = matchInfo.expire_date;  //失效日期
            dr["edit_staff"] = matchInfo.edit_staff;    //操作员工号 
            dr["edit_man"] = matchInfo.edit_man;        //操作员姓名
            dr["audit_flag"] = matchInfo.Audit_flag;      //审核标志
            dr["valid_flag"] = matchInfo.Valid_flag;    //有效标志

            //dr["edit_date"] = matchInfo.edit_date;      //操作员登记日期
            //dr["Staple_flag"] = matchInfo.Staple_flag;  //药品性质类型
            //dr["Stat_type"] = matchInfo.Stat_type;      //费用统计类别


            ds.Tables["insertinfo"].Rows.Add(dr);

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
    }
}
