
namespace HIS.BLL
{
    public struct Tables
    {
        #region 参数
        public static string MZ_CONFIG = "MZ_CONFIG";
        public struct mz_config
        {
            public static string ID = "ID";
            public static string CODE = "CODE";
            public static string NAME = "NAME";
            public static string VALUE = "VALUE";
            public static string BZ = "BZ";
            public static string DEPTID = "DEPTID";
        }
        public static string MZ_DOC_CONFIG = "MZ_DOC_CONFIG";
        public struct mz_doc_config
        {
            public static string ID = "ID";
            public static string CODE = "CODE";
            public static string NAME = "NAME";
            public static string VALUE = "VALUE";
            public static string BZ = "BZ";
            public static string DEPTID = "DEPTID";
        }
        public static string YP_CONFIG = "YP_CONFIG";
        public struct yp_config
        {
            public static string ID = "ID";
            public static string CODE = "CODE";
            public static string NAME = "NAME";
            public static string VALUE = "VALUE";
            public static string BZ = "BZ";
            public static string DEPTID = "DEPTID";
        }
        public static string ZY_CONFIG = "ZY_CONFIG";
        public struct zy_config
        {
            public static string ID = "ID";
            public static string CODE = "CODE";
            public static string NAME = "NAME";
            public static string VALUE = "VALUE";
            public static string BZ = "BZ";
            public static string DEPTID = "DEPTID";
        }
        public static string ZY_DOC_CONFIG = "ZY_DOC_CONFIG";
        public struct zy_doc_config
        {
            public static string ID = "ID";
            public static string CODE = "CODE";
            public static string NAME = "NAME";
            public static string VALUE = "VALUE";
            public static string BZ = "BZ";
            public static string DEPTID = "DEPTID";
        }
        public static string ZY_NURSE_CONFIG = "ZY_NURSE_CONFIG";
        public struct zy_nurse_config
        {
            public static string ID = "ID";
            public static string CODE = "CODE";
            public static string NAME = "NAME";
            public static string VALUE = "VALUE";
            public static string BZ = "BZ";
            public static string DEPTID = "DEPTID";
        }
        #endregion

        #region 手术麻醉

        public static string BASE_SSANESTH = "BASE_SSANESTH";
        public struct base_ssanesth
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
        }
        public static string BASE_SSAPPLICE = "BASE_SSAPPLICE";
        public struct base_ssapplice
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string UNIT = "UNIT";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
            public static string TYPE = "TYPE";
        }
        public static string BASE_SSBODY = "BASE_SSBODY";
        public struct base_ssbody
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
        }
        public static string BASE_SSGRADE = "BASE_SSGRADE";
        public struct base_ssgrade
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
        }
        public static string SS_APPLY = "SS_APPLY";
        public struct ss_apply
        {
            public static string APPLY_ID = "APPLY_ID";
            public static string CURENO = "CURENO";
            public static string PATLISTID = "PATLISTID";
            public static string PAT_WEIGHT = "PAT_WEIGHT";
            public static string PAT_HEIGHT = "PAT_HEIGHT";
            public static string PAT_DEPT = "PAT_DEPT";
            public static string HBSAG = "HBSAG";
            public static string HCV = "HCV";
            public static string HIV = "HIV";
            public static string TP = "TP";
            public static string TEND_OPERA = "TEND_OPERA";
            public static string TEND_OPERADATE = "TEND_OPERADATE";
            public static string OTHER_OPERA = "OTHER_OPERA";
            public static string OTHER_OPERA1 = "OTHER_OPERA1";
            public static string OTHER_OPERA2 = "OTHER_OPERA2";
            public static string OTHER_OPERA3 = "OTHER_OPERA3";
            public static string OPERA_DOC = "OPERA_DOC";
            public static string OPERA_ASSIST1 = "OPERA_ASSIST1";
            public static string OPERA_ASSIST2 = "OPERA_ASSIST2";
            public static string OPERA_ASSIST3 = "OPERA_ASSIST3";
            public static string TEND_ANESTH = "TEND_ANESTH";
            public static string OPERA_BODY = "OPERA_BODY";
            public static string OPERA_GRADE = "OPERA_GRADE";
            public static string DRUG_ALLERGY = "DRUG_ALLERGY";
            public static string OPERA_DEPT = "OPERA_DEPT";
            public static string OPERA_MEMO = "OPERA_MEMO";
            public static string ARRANGE_FLAG = "ARRANGE_FLAG";
            public static string DELETE_FLAG = "DELETE_FLAG";
            public static string APPLY_DATE = "APPLY_DATE";
            public static string APPLY_DOC = "APPLY_DOC";
            public static string OPERA_APPLIANCE = "OPERA_APPLIANCE";
            public static string OPERA_APPLIANCE1 = "OPERA_APPLIANCE1";
            public static string OPERA_APPLIANCE2 = "OPERA_APPLIANCE2";
            public static string OPERA_APPLIANCE3 = "OPERA_APPLIANCE3";
            public static string OPERA_CONSENT = "OPERA_CONSENT";
            public static string ANESTH_CONSENT = "ANESTH_CONSENT";
            public static string EMERGENCY_OPERA = "EMERGENCY_OPERA";
            public static string TEND_OPERADRUG = "TEND_OPERADRUG";
            public static string TEND_OPERADRUG1 = "TEND_OPERADRUG1";
            public static string TEND_OPERADRUG2 = "TEND_OPERADRUG2";
            public static string TEND_OPERADRUG3 = "TEND_OPERADRUG3";
            public static string OPERA_VISIT = "OPERA_VISIT";
            public static string OPERA_VISIT1 = "OPERA_VISIT1";
            public static string SS_DIAG = "SS_DIAG";
            public static string SS_DIAG1 = "SS_DIAG1";
            public static string SS_DIAG2 = "SS_DIAG2";
            public static string AFTERSS_DIAG = "AFTERSS_DIAG";
        }
        public static string SS_ARRANGE = "SS_ARRANGE";
        public struct ss_arrange
        {
            public static string ARRANGE_ID = "ARRANGE_ID";
            public static string PATLISTID = "PATLISTID";
            public static string APPLY_ID = "APPLY_ID";
            public static string FINISH_FLAG = "FINISH_FLAG";
            public static string TEND_OPERA = "TEND_OPERA";
            public static string ACTUAL_OPERA = "ACTUAL_OPERA";
            public static string WASH_NURSE = "WASH_NURSE";
            public static string WASH_NURSE1 = "WASH_NURSE1";
            public static string WASH_NURSE2 = "WASH_NURSE2";
            public static string OPERA_ROOMBED = "OPERA_ROOMBED";
            public static string OPERA_BEGINTIME = "OPERA_BEGINTIME";
            public static string OPERA_ENDTIME = "OPERA_ENDTIME";
            public static string ARRAGE_TIME = "ARRAGE_TIME";
            public static string DELETE_FLAG = "DELETE_FLAG";
            public static string OPERA_DOC = "OPERA_DOC";
            public static string OPERA_FINISHTIME = "OPERA_FINISHTIME";
            public static string OPERA_FINISHDOC = "OPERA_FINISHDOC";

            public static string OPERA_DATE = "OPERA_DATE";
            public static string TOUR_NURSE2 = "TOUR_NURSE2";
            public static string TOUR_NURSE1 = "TOUR_NURSE1";
            public static string TOUR_NURSE = "TOUR_NURSE";
            public static string ANESTH_DOC1 = "ANESTH_DOC1";
            public static string ANESTH_DOC = "ANESTH_DOC";
            public static string OPERA_GRADE = "OPERA_GRADE";
            public static string ACTUAL_ANESTH = "ACTUAL_ANESTH";
            public static string ACTUAL_ANESTH1 = "ACTUAL_ANESTH1";


        }
        public static string SS_ROOM = "SS_ROOM";
        public struct ss_room
        {
            public static string ROOMID = "ROOMID";
            public static string ROOMNO = "ROOMNO";
            public static string ROOMNAME = "ROOMNAME";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
            public static string DEPTID = "DEPTID";
        }
        public static string SS_ROOMBED = "SS_ROOMBED";
        public struct ss_roombed
        {
            public static string ID = "ID";
            public static string ROOMID = "ROOMID";
            public static string NAME = "NAME";
            public static string PATLISTID = "PATLISTID";
            public static string USE_FLAG = "USE_FLAG";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
        }

        #endregion
        #region 基础数据部分
        public static string BASE_USEAGE_FEE = "BASE_USEAGE_FEE";
        public struct base_useage_fee
        {
            public static string ID = "ID";
            public static string USE_NAME = "USE_NAME";
            public static string NUM = "NUM";
            public static string HSITEM_ID = "HSITEM_ID";
        }
        public static string BASE_MEDICAL_CLASS = "BASE_MEDICAL_CLASS";
        public struct base_medical_class
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string ORDERS = "ORDERS";
            public static string COMMENT = "COMMENT";
            public static string CLASS_TYPE = "CLASS_TYPE";
            public static string PRINTTYPE = "PRINTTYPE";
            public static string MULTSELECT = "MULTSELECT";
        }

        public static string BASE_ORDER_TYPE = "BASE_ORDER_TYPE";
        public struct base_order_type
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string CODE = "CODE";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string COMMENTS = "COMMENTS";
        }
        public static string BASE_ENTRUST = "BASE_ENTRUST";
        public struct base_entrust
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string D_CODE = "D_CODE";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string BASE_FREQUENCY = "BASE_FREQUENCY";
        public struct base_frequency
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string D_CODE = "D_CODE";
            public static string EXECNUM = "EXECNUM";
            public static string CYCLEDAY = "CYCLEDAY";
            public static string EXECTIME = "EXECTIME";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string BASE_PARAM = "BASE_PARAM";
        public struct base_param
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string D_CODE = "D_CODE";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string BASE_SAMPLE = "BASE_SAMPLE";
        public struct base_sample
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string D_CODE = "D_CODE";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string BASE_USAGEDICTION = "BASE_USAGEDICTION";
        public struct base_usagediction
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string D_CODE = "D_CODE";
            public static string UNIT = "UNIT";
            public static string PRINT_LONG = "PRINT_LONG";
            public static string PRINT_TEMP = "PRINT_TEMP";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string BASE_USAGE_USETYPE_ROLE = "BASE_USAGE_USETYPE_ROLE";
        public struct base_usage_usetype_role
        {
            public static string ID = "ID";
            public static string TYPE_NAME = "TYPE_NAME";
            public static string USAGE_ID = "USAGE_ID";
        }
        public static string BASE_EXAMINEPLACE = "BASE_EXAMINEPLACE";
        public struct base_examineplace
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string MEDICAL_CLASS = "MEDICAL_CLASS";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
        }
        #endregion

        #region 临床部分部分
        public static string ZY_DOC_CHECKAPPLY = "ZY_DOC_CHECKAPPLY";
        public struct zy_doc_checkapply
        {
            public static string CHECKAPPLY_ID = "CHECKAPPLY_ID";
            public static string PATID = "PATID";
            public static string GROUP_ID = "GROUP_ID";
            public static string ITEM_ID = "ITEM_ID";
            public static string CHECK_PLACE = "CHECK_PLACE";
            public static string PLACE_NUM = "PLACE_NUM";
            public static string MEDICAL_STATE = "MEDICAL_STATE";
            public static string DIAGNOSIS = "DIAGNOSIS";
            public static string CHECK_NO = "CHECK_NO";
            public static string DELETE_FLAG = "DELETE_FLAG";
            public static string SEVERS_ID = "SEVERS_ID";
            public static string TC_ID = "TC_ID";
            public static string CHECK_A1 = "CHECK_A1";
            public static string CHECK_A2 = "CHECK_A2";
        }
        public static string ZY_DOC_DIAGNOSIS = "ZY_DOC_DIAGNOSIS";
        public struct zy_doc_diagnosis
        {
            public static string DIAGNOSIS_ID = "DIAGNOSIS_ID";
            public static string PATID = "PATID";
            public static string DIAG_NAME = "DIAG_NAME";
            public static string DIAG_DOC = "DIAG_DOC";
            public static string DIAG_DATE = "DIAG_DATE";
            public static string DELETE_FLAG = "DELETE_FLAG";
            public static string DELETE_DOC = "DELETE_DOC";
            public static string DELETE_DATE = "DELETE_DATE";
            public static string DIAG_A1 = "DIAG_A1";
            public static string DIAG_A2 = "DIAG_A2";
        }
        public static string ZY_DOC_ORDERMODEL = "ZY_DOC_ORDERMODEL";
        public struct zy_doc_ordermodel
        {
            public static string MODEL_ID = "MODEL_ID";
            public static string P_ID = "P_ID";
            public static string MODEL_NAME = "MODEL_NAME";
            public static string MODEL_LEVEL = "MODEL_LEVEL";
            public static string MODEL_TYPE = "MODEL_TYPE";
            public static string WARD_ID = "WARD_ID";
            public static string CREATE_DEPT = "CREATE_DEPT";
            public static string CREATE_DOC = "CREATE_DOC";
            public static string CREATE_DATE = "CREATE_DATE";
            public static string UPDATE_DATE = "UPDATE_DATE";
            public static string MEMO = "MEMO";
            public static string DELETE_FLAG = "DELETE_FLAG";
            public static string MODEL_A1 = "MODEL_A1";
            public static string MODEL_A2 = "MODEL_A2";
        }
        public static string ZY_DOC_ORDERMODELLIST = "ZY_DOC_ORDERMODELLIST";
        public struct zy_doc_ordermodellist
        {
            public static string MODELLIST_ID = "MODELLIST_ID";
            public static string MODEL_ID = "MODEL_ID";
            public static string GROUP_ID = "GROUP_ID";
            public static string ITEM_TYPE = "ITEM_TYPE";
            public static string ITEM_ID = "ITEM_ID";
            public static string ITEM_CODE = "ITEM_CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string AMOUNT = "AMOUNT";
            public static string PRESAMOUNT = "PRESAMOUNT";
            public static string UNIT = "UNIT";
            public static string ORDER_STRUC = "ORDER_STRUC";
            public static string FRIST_TIMES = "FRIST_TIMES";
            public static string ORDER_USAGE = "ORDER_USAGE";
            public static string ORDER_FRENQUECY = "ORDER_FRENQUECY";
            public static string EXEC_DEPT = "EXEC_DEPT";
            public static string DROPSPER = "DROPSPER";
            public static string SEVERS_ID = "SEVERS_ID";
            public static string TC_ID = "TC_ID";
            public static string FLAG = "FLAG";
            public static string UNITTYPE = "UNITTYPE";
            public static string MODELLIST_A1 = "MODELLIST_A1";
            public static string MODELLIST_A2 = "MODELLIST_A2";
            public static string doseunit = "doseunit";
        }
        public static string ZY_DOC_ORDERRECORD = "ZY_DOC_ORDERRECORD";
        public struct zy_doc_orderrecord
        {
            public static string ORDER_ID = "ORDER_ID";
            public static string PATID = "PATID";
            public static string BABYID = "BABYID";
            public static string WARD_ID = "WARD_ID";
            public static string PAT_DEPTID = "PAT_DEPTID";
            public static string PRES_DEPTID = "PRES_DEPTID";
            public static string ORDER_TYPE = "ORDER_TYPE";
            public static string ORDER_DOC = "ORDER_DOC";
            public static string ORDER_BDATE = "ORDER_BDATE";
            public static string ITEM_TYPE = "ITEM_TYPE";
            public static string GROUP_ID = "GROUP_ID";
            public static string SERIAL_ID = "SERIAL_ID";
            public static string ORDITEM_ID = "ORDITEM_ID";
            public static string MAKEDICID = "MAKEDICID";
            public static string ITEM_CODE = "ITEM_CODE";
            public static string ORDER_CONTENT = "ORDER_CONTENT";
            public static string AMOUNT = "AMOUNT";
            public static string PRES_AMOUNT = "PRES_AMOUNT";
            public static string UNIT = "UNIT";
            public static string UNITTYPE = "UNITTYPE";
            public static string ORDER_SPEC = "ORDER_SPEC";
            public static string ORDER_STRUC = "ORDER_STRUC";
            public static string ORDER_USAGE = "ORDER_USAGE";
            public static string FREQUENCY = "FREQUENCY";
            public static string DROPSPEC = "DROPSPEC";
            public static string EXEC_DEPT = "EXEC_DEPT";
            public static string FIRSET_TIMES = "FIRSET_TIMES";
            public static string TEMINAL_TIMES = "TEMINAL_TIMES";
            public static string TRANS_NURSE = "TRANS_NURSE";
            public static string TRANS_DATE = "TRANS_DATE";
            public static string CHECK_NURSE = "CHECK_NURSE";
            public static string CHECK_DATE = "CHECK_DATE";
            public static string VERIFY_NURSE = "VERIFY_NURSE";
            public static string VERIFY_DATE = "VERIFY_DATE";
            public static string EORDER_DATE = "EORDER_DATE";
            public static string EORDER_DOC = "EORDER_DOC";
            public static string EORDER_TSNURSE = "EORDER_TSNURSE";
            public static string EORDER_TSDATE = "EORDER_TSDATE";
            public static string EORDER_CHKNURSE = "EORDER_CHKNURSE";
            public static string EORDER_CHKDATE = "EORDER_CHKDATE";
            public static string EORDER_VENURSE = "EORDER_VENURSE";
            public static string EORDER_VEDATE = "EORDER_VEDATE";
            public static string STATUS_FALG = "STATUS_FALG";
            public static string OPRERATOR = "OPRERATOR";
            public static string OP_DATE = "OP_DATE";
            public static string DELETE_FLAG = "DELETE_FLAG";
            public static string PS_FLAG = "PS_FLAG";
            public static string PS_ORDERID = "PS_ORDERID";
            public static string PS_USER = "PS_USER";
            public static string NOEXE_FLAG = "NOEXE_FLAG";
            public static string CHARGE_FLAG = "CHARGE_FLAG";
            public static string ORDER_PRICE = "ORDER_PRICE";
            public static string MEMO = "MEMO";
            public static string SEVERS_ID = "SEVERS_ID";
            public static string TC_ID = "TC_ID";
            public static string ORECORD_A1 = "ORECORD_A1";
            public static string ORECORD_A2 = "ORECORD_A2";
        }
        public static string ZY_DOC_TESTAPPLY = "ZY_DOC_TESTAPPLY";
        public struct zy_doc_testapply
        {
            public static string TESTAPPLY_ID = "TESTAPPLY_ID";
            public static string ORDER_ID = "ORDER_ID";
            public static string GROUP_ID = "GROUP_ID";
            public static string PATID = "PATID";
            public static string BABY_ID = "BABY_ID";
            public static string ORDER_CONTENT = "ORDER_CONTENT";
            public static string SAMPLE = "SAMPLE";
            public static string EXEC_DEPT = "EXEC_DEPT";
            public static string ORDER_DOC = "ORDER_DOC";
            public static string ORDER_DATE = "ORDER_DATE";
            public static string DELETE_FLAG = "DELETE_FLAG";
            public static string FINISH_FLAG = "FINISH_FLAG";
            public static string AMOUNT = "AMOUNT";
            public static string EXPLAIN = "EXPLAIN";
            public static string MEMO = "MEMO";
            public static string SERVERS_ID = "SERVERS_ID";
            public static string TC_ID = "TC_ID";
            public static string TEST_A1 = "TEST_A1";
            public static string TEST_A2 = "TEST_A2";
        }
        public static string ZY_DOC_TRANSDEPT = "ZY_DOC_TRANSDEPT";
        public struct zy_doc_transdept
        {
            public static string TRANSDEPT_ID = "TRANSDEPT_ID";
            public static string PATID = "PATID";
            public static string ORIGE_DEPT = "ORIGE_DEPT";
            public static string GET_DEPT = "GET_DEPT";
            public static string TRANSFER_DATE = "TRANSFER_DATE";
            public static string OPERATE_DATE = "OPERATE_DATE";
            public static string OPERATOR = "OPERATOR";
            public static string DESCRIPTION = "DESCRIPTION";
            public static string CANCEL_FLAG = "CANCEL_FLAG";
            public static string CANCEL_DATE = "CANCEL_DATE";
            public static string CANCEL_USER = "CANCEL_USER";
            public static string BABY_ID = "BABY_ID";
            public static string ORDER_ID = "ORDER_ID";
            public static string FINISH_FLAG = "FINISH_FLAG";
            public static string TRSDPT_A1 = "TRSDPT_A1";
            public static string TRSDPT_A2 = "TRSDPT_A2";
        }
        public static string BASE_ORDER_ITEMS = "BASE_ORDER_ITEMS";
        public struct base_order_items
        {
            public static string ORDER_ID = "ORDER_ID";
            public static string ORDER_NAME = "ORDER_NAME";
            public static string ORDER_UNIT = "ORDER_UNIT";
            public static string ORDER_TYPE = "ORDER_TYPE";
            public static string MEDICAL_CLASS = "MEDICAL_CLASS";
            public static string DEFAULT_USAGE = "DEFAULT_USAGE";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string D_CODE = "D_CODE";
            public static string ITEM_ID = "ITEM_ID";
            public static string TC_FLAG = "TC_FLAG";
            public static string DELETE_BIT = "DELETE_BIT";
            public static string BOOK_DATE = "BOOK_DATE";
            public static string DEL_DATE = "DEL_DATE";
            public static string BZ = "BZ";
        }
        public static string MZ_DOC_COMMONDIAGNOSIS = "MZ_DOC_COMMONDIAGNOSIS";
        public struct mz_doc_commondiagnosis
        {
            public static string COMMONDIAGNOSISID = "COMMONDIAGNOSISID";
            public static string DIAGNOSIS_CODE = "DIAGNOSIS_CODE";
            public static string DIAGNOSIS_NAME = "DIAGNOSIS_NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string RECORD_DOC = "RECORD_DOC";
            public static string FREQUENCY = "FREQUENCY";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string MZ_DOC_COMMONITEM = "MZ_DOC_COMMONITEM";
        public struct mz_doc_commonitem
        {
            public static string COMMONITEMID = "COMMONITEMID";
            public static string ITEM_ID = "ITEM_ID";
            public static string RECORD_DOC = "RECORD_DOC";
            public static string FREQUENCY = "FREQUENCY";
            public static string TYPE = "TYPE";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string MZ_DOC_PRESHEAD = "MZ_DOC_PRESHEAD";
        public struct mz_doc_preshead
        {
            public static string PRESHEADID = "PRESHEADID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string PRESTYPE = "PRESTYPE";
            public static string PRES_DOC = "PRES_DOC";
            public static string PRES_DEPT = "PRES_DEPT";
            public static string PRES_EXEDEPT = "PRES_EXEDEPT";
            public static string PRES_DATE = "PRES_DATE";
            public static string PRESMASTERID = "PRESMASTERID";
            public static string PRES_FLAG = "PRES_FLAG";
        }
        public static string MZ_DOC_PRESLIST = "MZ_DOC_PRESLIST";
        public struct mz_doc_preslist
        {
            public static string PRESLISTID = "PRESLISTID";
            public static string PRESHEADID = "PRESHEADID";
            public static string ORDERNO = "ORDERNO";
            public static string STATITEM_CODE = "STATITEM_CODE";
            public static string ITEM_ID = "ITEM_ID";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string ITEM_PRICE = "ITEM_PRICE";
            public static string BUY_PRICE = "BUY_PRICE";
            public static string SELL_PRICE = "SELL_PRICE";
            public static string STANDARD = "STANDARD";
            public static string USAGE_AMOUNT = "USAGE_AMOUNT";
            public static string USAGE_UNIT = "USAGE_UNIT";
            public static string USAGE_RATE = "USAGE_RATE";
            public static string DOSAGE = "DOSAGE";
            public static string USAGE_ID = "USAGE_ID";
            public static string FREQUENCY_ID = "FREQUENCY_ID";
            public static string DAYS = "DAYS";
            public static string ITEM_AMOUNT = "ITEM_AMOUNT";
            public static string ITEM_UNIT = "ITEM_UNIT";
            public static string ITEM_RATE = "ITEM_RATE";
            public static string RELATIONNUM = "RELATIONNUM";
            public static string UNIT = "UNIT";
            public static string GROUP_ID = "GROUP_ID";
            public static string SKINTEST_FLAG = "SKINTEST_FLAG";
            public static string SELFDRUG_FLAG = "SELFDRUG_FLAG";
            public static string ENTRUST = "ENTRUST";
            public static string FOOTNOTE = "FOOTNOTE";
            public static string TC_FLAG = "TC_FLAG";
            public static string SERVICE_ITEM_ID = "SERVICE_ITEM_ID";
            public static string PRESORDERID = "PRESORDERID";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string MZ_DOC_PRESMOULDHEAD = "MZ_DOC_PRESMOULDHEAD";
        public struct mz_doc_presmouldhead
        {
            public static string PRESMOULDHEADID = "PRESMOULDHEADID";
            public static string P_ID = "P_ID";
            public static string MOULD_NAME = "MOULD_NAME";
            public static string MOULD_TYPE = "MOULD_TYPE";
            public static string MOULD_LEVEL = "MOULD_LEVEL";
            public static string CREATE_DOC = "CREATE_DOC";
            public static string CREATE_DEPT = "CREATE_DEPT";
            public static string CREATE_DATE = "CREATE_DATE";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string MZ_DOC_PRESMOULDLIST = "MZ_DOC_PRESMOULDLIST";
        public struct mz_doc_presmouldlist
        {
            public static string PRESMOULDLISTID = "PRESMOULDLISTID";
            public static string PRESMOULDHEADID = "PRESMOULDHEADID";
            public static string PRESNO = "PRESNO";
            public static string ORDERNO = "ORDERNO";
            public static string STATITEM_CODE = "STATITEM_CODE";
            public static string ITEM_ID = "ITEM_ID";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string STANDARD = "STANDARD";
            public static string USAGE_AMOUNT = "USAGE_AMOUNT";
            public static string USAGE_UNIT = "USAGE_UNIT";
            public static string USAGE_RATE = "USAGE_RATE";
            public static string DOSAGE = "DOSAGE";
            public static string USAGE_ID = "USAGE_ID";
            public static string FREQUENCY_ID = "FREQUENCY_ID";
            public static string DAYS = "DAYS";
            public static string ITEM_AMOUNT = "ITEM_AMOUNT";
            public static string ITEM_UNIT = "ITEM_UNIT";
            public static string ITEM_RATE = "ITEM_RATE";
            public static string RELATIONNUM = "RELATIONNUM";
            public static string UNIT = "UNIT";
            public static string DEPT_ID = "DEPT_ID";
            public static string ENTRUST = "ENTRUST";
            public static string GROUP_ID = "GROUP_ID";
            public static string FOOTNOTE = "FOOTNOTE";
            public static string TC_FLAG = "TC_FLAG";
            public static string SERVICE_ITEM_ID = "SERVICE_ITEM_ID";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string MZ_DOC_MEDICAL_APPLY = "MZ_DOC_MEDICAL_APPLY";
        public struct mz_doc_medical_apply
        {
            public static string APPLYID = "APPLYID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string PRESLISTID = "PRESLISTID";
            public static string ITEM_ID = "ITEM_ID";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string APPLY_TYPE = "APPLY_TYPE";
            public static string MEDICAL_CLASS = "MEDICAL_CLASS";
            public static string APPLY_CONTENT = "APPLY_CONTENT";
            public static string APPLY_DOC = "APPLY_DOC";
            public static string APPLY_DEPT = "APPLY_DEPT";
            public static string APPLY_DATE = "APPLY_DATE";
            public static string APPLY_STATUS = "APPLY_STATUS";
            public static string MEMO = "MEMO";
        }
        public static string MZ_DOC_MEDICALAPPLY_MOULD = "MZ_DOC_MEDICALAPPLY_MOULD";
        public struct mz_doc_medicalapply_mould
        {
            public static string ID = "ID";
            public static string MEDICAL_CLASS = "MEDICAL_CLASS";
            public static string ELEMENT_NAME = "ELEMENT_NAME";
            public static string LEVEL = "LEVEL";
            public static string CREATE_EMP = "CREATE_EMP";
            public static string CREATE_DEPT = "CREATE_DEPT";
            public static string CONTENT = "CONTENT";
        }
        public static string MZ_DOC_ZY_INPAT_REG = "MZ_DOC_ZY_INPAT_REG";
        public struct mz_doc_zy_inpat_reg
        {
            public static string REGID = "REGID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string REG_CONTENT = "REG_CONTENT";
            public static string REG_EMP = "REG_EMP";
            public static string REG_DATE = "REG_DATE";
            public static string REG_STATUS = "REG_STATUS";
        }
        public static string ZY_NURSE_FEEMODEL = "ZY_NURSE_FEEMODEL";
        public struct zy_nurse_feemodel
        {
            public static string MODEL_ID = "MODEL_ID";
            public static string P_ID = "P_ID";
            public static string MODEL_NAME = "MODEL_NAME";
            public static string MODEL_LEVEL = "MODEL_LEVEL";
            public static string MODEL_TYPE = "MODEL_TYPE";
            public static string CREATE_DEPT = "CREATE_DEPT";
            public static string CREATE_NURSE = "CREATE_NURSE";
            public static string CREATE_DATE = "CREATE_DATE";
            public static string UPDATE_DATE = "UPDATE_DATE";
            public static string MEMO = "MEMO";
            public static string DELETE_FLAG = "DELETE_FLAG";
        }
        public static string ZY_NURSE_FEEMODELLIST = "ZY_NURSE_FEEMODELLIST";
        public struct zy_nurse_feemodellist
        {
            public static string MODELLIST_ID = "MODELLIST_ID";
            public static string MODEL_ID = "MODEL_ID";
            public static string ITEM_TYPE = "ITEM_TYPE";
            public static string ITEM_ID = "ITEM_ID";
            public static string ITEM_CODE = "ITEM_CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string AMOUNT = "AMOUNT";
            public static string UNIT = "UNIT";
            public static string ORDER_USAGE = "ORDER_USAGE";
            public static string EXEC_DEPT = "EXEC_DEPT";
            public static string SEVERS_ID = "SEVERS_ID";
            public static string TC_ID = "TC_ID";
            public static string DELETE_FLAG = "DELETE_FLAG";
        }
        public static string ZY_NURSE_BED = "ZY_NURSE_BED";
        public struct zy_nurse_bed
        {
            public static string BED_ID = "BED_ID";
            public static string WARD_ID = "WARD_ID";
            public static string DEPT_ID = "DEPT_ID";
            public static string ROOM_NO = "ROOM_NO";
            public static string BED_NO = "BED_NO";
            public static string BED_FEE = "BED_FEE";
            public static string ZZ_DOC = "ZZ_DOC";
            public static string ZY_DOC = "ZY_DOC";
            public static string IS_PLUS = "IS_PLUS";
            public static string CHARGE_NURSE = "CHARGE_NURSE";
            public static string PATLIST_ID = "PATLIST_ID";
            public static string BABY_ID = "BABY_ID";
            public static string INPATIENT_DEPT = "INPATIENT_DEPT";
            public static string BED_SEX = "BED_SEX";
            public static string IS_USE = "IS_USE";
        }
        public static string ZY_NURSE_BED_ASSIGN = "ZY_NURSE_BED_ASSIGN";
        public struct zy_nurse_bed_assign
        {
            public static string ASSIGN_ID = "ASSIGN_ID";
            public static string BED_ID = "BED_ID";
            public static string DEPT_ID = "DEPT_ID";
            public static string INPATIENT_ID = "INPATIENT_ID";
            public static string ASSIGN_DATE = "ASSIGN_DATE";
            public static string ASSIGN_USER = "ASSIGN_USER";
            public static string STOP_DATE = "STOP_DATE";
            public static string STOP_USER = "STOP_USER";
            public static string FINISH_BIT = "FINISH_BIT";
            public static string BOOK_DATE = "BOOK_DATE";
            public static string CANCEL_BIT = "CANCEL_BIT";
            public static string BABY_ID = "BABY_ID";
            public static string PATDEPT = "PATDEPT";
            public static string BEGIN_FLAG = "BEGIN_FLAG";
            public static string STOP_FLAG = "STOP_FLAG";
            public static string ZZ_DOC = "ZZ_DOC";
            public static string ZY_DOC = "ZY_DOC";
            public static string JZ_NURSE = "JZ_NURSE";
        }
        public static string ZY_NURSE_FEE_SPECI = "ZY_NURSE_FEE_SPECI";
        public struct zy_nurse_fee_speci
        {
            public static string ID = "ID";
            public static string PRESORDERID = "PRESORDERID";
            public static string BABY_ID = "BABY_ID";
            public static string OREDEREXEC_ID = "OREDEREXEC_ID";
            public static string PRESCRIPTION_ID = "PRESCRIPTION_ID";
            public static string PRESC_NO = "PRESC_NO";
            public static string BOOK_DATE = "BOOK_DATE";
            public static string BOOK_NAME = "BOOK_NAME";
            public static string TCID = "TCID";
            public static string TC_FLAG = "TC_FLAG";
            public static string SDVALUE = "SDVALUE";
            public static string ACVALUE = "ACVALUE";
            public static string FEETYPE = "FEETYPE";
            public static string HS_BIT = "HS_BIT";
            public static string HS_ID = "HS_ID";
            public static string GROUP_ID = "GROUP_ID";
            public static string APPLY_ID = "APPLY_ID";
            public static string APPLY_DATE = "APPLY_DATE";
            public static string FYBS_BIT = "FYBS_BIT";
            public static string FY_DATE = "FY_DATE";
            public static string FY_PERSON = "FY_PERSON";
            public static string PY_PERSON = "PY_PERSON";
            public static string MEN_ID = "MEN_ID";
            public static string DEPT_LY = "DEPT_LY";
        }
        public static string ZY_NURSE_INPATIENT_BABY = "ZY_NURSE_INPATIENT_BABY";
        public struct zy_nurse_inpatient_baby
        {
            public static string BABY_ID = "BABY_ID";
            public static string INPATIENT_ID = "INPATIENT_ID";
            public static string INPATIENT_NO = "INPATIENT_NO";
            public static string BABY_NO = "BABY_NO";
            public static string BABY_NAME = "BABY_NAME";
            public static string BIRTHDAY = "BIRTHDAY";
            public static string SEX = "SEX";
        }
        public static string ZY_NURSE_ORDEREXEC = "ZY_NURSE_ORDEREXEC";
        public struct zy_nurse_orderexec
        {
            public static string ID = "ID";
            public static string ORDER_ID = "ORDER_ID";
            public static string EXEC_DATE = "EXEC_DATE";
            public static string EXEC_USER = "EXEC_USER";
            public static string PATIENT_ID = "PATIENT_ID";
            public static string BABY_ID = "BABY_ID";
            public static string REALEXEC_USER = "REALEXEC_USER";
            public static string REALEXEC_TIME = "REALEXEC_TIME";
        }
        #endregion
        public static string EMR_BASE_ELEMENT = "EMR_BASE_ELEMENT";
        public struct emr_base_element
        {
            public static string ID = "ID";
            public static string ELEMENTCODE = "ELEMENTCODE";
            public static string ELEMENTNAME = "ELEMENTNAME";
            public static string P_ELEMENTCODE = "P_ELEMENTCODE";
            public static string ELEMENTLEVEL = "ELEMENTLEVEL";
        }
        public static string EMR_MOULD_CLASS = "EMR_MOULD_CLASS";
        public struct emr_mould_class
        {
            public static string MOULDID = "MOULDID";
            public static string MOULDNAME = "MOULDNAME";
            public static string MOULDCLASS = "MOULDCLASS";
            public static string MOULDTYPE = "MOULDTYPE";
            public static string MOULDLEVEL = "MOULDLEVEL";
            public static string MOULDCREATEEMP = "MOULDCREATEEMP";
            public static string MOULDCREATEDEPT = "MOULDCREATEDEPT";
            public static string MOULDCREATEDATE = "MOULDCREATEDATE";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string EMR_MOULD_CONTENT = "EMR_MOULD_CONTENT";
        public struct emr_mould_content
        {
            public static string ID = "ID";
            public static string MOULDID = "MOULDID";
            public static string MOULDCONTENT = "MOULDCONTENT";
        }
        public static string EMR_MOULD_ELEMENT = "EMR_MOULD_ELEMENT";
        public struct emr_mould_element
        {
            public static string MOULDID = "MOULDID";
            public static string MOULDCONTENT = "MOULDCONTENT";
            public static string MOULDTYPE = "MOULDTYPE";
            public static string MOULDLEVEL = "MOULDLEVEL";
            public static string MOULDCREATEEMP = "MOULDCREATEEMP";
            public static string MOULDCREATEDEPT = "MOULDCREATEDEPT";
            public static string MOULDCREATEDATE = "MOULDCREATEDATE";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string EMR_RECORD = "EMR_RECORD";
        public struct emr_record
        {
            public static string RECORDID = "RECORDID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string RECORDTYPE = "RECORDTYPE";
            public static string RECORDCONTENT = "RECORDCONTENT";
            public static string RECORDCREATEEMP = "RECORDCREATEEMP";
            public static string RECORDCREATEDEPT = "RECORDCREATEDEPT";
            public static string RECORDCREATEDATE = "RECORDCREATEDATE";
            public static string HISTORYRECORDID = "HISTORYRECORDID";
            public static string RECORDFLAG = "RECORDFLAG";
            public static string UPDATEFLAG = "UPDATEFLAG";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string BASE_TABLE_CONFIG = "BASE_TABLE_CONFIG";
        public struct base_table_config
        {
            public static string TABLE_DB_NAME = "TABLE_DB_NAME";
            public static string TABLE_CN_NAME = "TABLE_CN_NAME";
            public static string FIELD_DB_NAME = "FIELD_DB_NAME";
            public static string FIELD_CN_NAME = "FIELD_CN_NAME";
            public static string FIELD_DB_TYPE = "FIELD_DB_TYPE";
            public static string IS_PRIMARY_KEY = "IS_PRIMARY_KEY";
            public static string AUTO_INCREASE = "AUTO_INCREASE";
            public static string ALLOW_EMPTY = "ALLOW_EMPTY";
            public static string MAXLENGTH = "MAXLENGTH";
            public static string IS_FOREIGNER_KEY = "IS_FOREIGNER_KEY";
            public static string FOREIGNER_TABLE = "FOREIGNER_TABLE";
            public static string FOREIGNER_FIELD_DB_NAME = "FOREIGNER_FIELD_DB_NAME";
            public static string FOREIGNER_FIELD_CN_NAME = "FOREIGNER_FIELD_CN_NAME";
            public static string FOREIGNER_FILTER_SQL = "FOREIGNER_FILTER_SQL";
            public static string UIC_TYPE = "UIC_TYPE";
            public static string LOCATION_X = "LOCATION_X";
            public static string LOCATION_Y = "LOCATION_Y";
            public static string WIDTH = "WIDTH";
            public static string HEIGHT = "HEIGHT";
            public static string GRID_COL_WIDTH = "GRID_COL_WIDTH";
            public static string TABINDEX = "TABINDEX";
            public static string ALLOW_EDIT = "ALLOW_EDIT";
            public static string FIELD_MARK_TYPE = "FIELD_MARK_TYPE";
        }
        public static string BASE_VINDICATE_TABLE = "BASE_VINDICATE_TABLE";
        public struct base_vindicate_table
        {
            public static string BASE_TABLE_DB_NAME = "BASE_TABLE_DB_NAME";
            public static string BASE_TABLE_CN_NAME = "BASE_TABLE_CN_NAME";
            public static string ALLOW_USER_EDIT = "ALLOW_USER_EDIT";
            public static string ALLOW_PHYSIC_DELETE = "ALLOW_PHYSIC_DELETE";
        }
        public static string BASE_WORK_UNIT = "BASE_WORK_UNIT";
        public struct base_work_unit
        {
            public static string CODE = "CODE";
            public static string NAME = "NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
        }
        public static string BASE_TEMPLATE_ITEM = "BASE_TEMPLATE_ITEM";
        public struct base_template_item
        {
            public static string TMPLATE_ID = "TMPLATE_ID";
            public static string TMPLATE_NAME = "TMPLATE_NAME";
            public static string TMPLATE_TYPE = "TMPLATE_TYPE";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string EXEC_DEPT_ID = "EXEC_DEPT_ID";
            public static string EXEC_DEPT_NAME = "EXEC_DEPT_NAME";
            public static string CREATOR_ID = "CREATOR_ID";
            public static string CREATOR_NAME = "CREATOR_NAME";
            public static string DEPT_ID = "DEPT_ID";
            public static string DEPT_NAME = "DEPT_NAME";
            public static string SHARE_LEVEL = "SHARE_LEVEL";
            public static string CREATE_DATE = "CREATE_DATE";
            public static string VALID_FLAG = "VALID_FLAG";
        }
        public static string BASE_TEMPLATE_DETAIL = "BASE_TEMPLATE_DETAIL";
        public struct base_template_detail
        {
            public static string TEMPLATE_ID = "TEMPLATE_ID";
            public static string ITEM_ID = "ITEM_ID";
            public static string COMPLEX_ID = "COMPLEX_ID";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string STANDARD = "STANDARD";
            public static string UNIT = "UNIT";
            public static string BIGITEMCODE = "BIGITEMCODE";
            public static string DOSAGE = "DOSAGE";
            public static string FREQUEN_ID = "FREQUEN_ID";
            public static string FREQUEN_NAME = "FREQUEN_NAME";
            public static string DAYS = "DAYS";
            public static string USAGE_NAME = "USAGE_NAME";
            public static string GROUP_FLAG = "GROUP_FLAG";
            public static string SORT_NO = "SORT_NO";
            public static string AMONUT = "AMOUNT";
        }

        public static string BASE_COMPLEX_DETAIL = "BASE_COMPLEX_DETAIL";
        public struct base_complex_detail
        {
            public static string COMPLEX_ID = "COMPLEX_ID";
            public static string SERVICE_ITEM_ID = "SERVICE_ITEM_ID";
            public static string NUM = "NUM";
        }
        public static string YK_BATCH = "YK_BATCH";
        public struct yk_batch
        {
            public static string ID = "ID";
            public static string MAKERDICID = "MAKERDICID";
            public static string INSTORETIME = "INSTORETIME";
            public static string DEPTID = "DEPTID";
            public static string CURRENTNUM = "CURRENTNUM";
            public static string UNIT = "UNIT";
            public static string UNITNUM = "UNITNUM";
            public static string BATCHNUM = "BATCHNUM";
            public static string VAILIDITYDATE = "VALIDITYDATE";
            public static string DEL_FLAG = "DEL_FLAG";
        }

        public static string BASE_COMPLEX_ITEM = "BASE_COMPLEX_ITEM";
        public struct base_complex_item
        {
            public static string COMPLEX_ID = "COMPLEX_ID";
            public static string CODE = "CODE";
            public static string COMPLEX_NAME = "COMPLEX_NAME";
            public static string ITEM_UNIT = "ITEM_UNIT";
            public static string PRICE = "PRICE";
            public static string STATITEM_CODE = "STATITEM_CODE";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string VALID_FLAG = "VALID_FLAG";
        }
        public static string BASE_CONFIG = "BASE_CONFIG";
        public struct base_config
        {
            public static string ID = "ID";
            public static string CONFIG = "CONFIG";
            public static string NOTE = "NOTE";
            public static string MODULE_ID = "MODULE_ID";
            public static string CSJB = "CSJB";
            public static string RWBZ = "RWBZ";
            public static string BLBZ = "BLBZ";
        }
        public static string BASE_DEPT_LAYER = "BASE_DEPT_LAYER";
        public struct base_dept_layer
        {
            public static string LAYER_ID = "LAYER_ID";
            public static string P_LAYER_ID = "P_LAYER_ID";
            public static string NAME = "NAME";
        }
        public static string BASE_DEPT_PROPERTY = "BASE_DEPT_PROPERTY";
        public struct base_dept_property
        {
            public static string DEPT_ID = "DEPT_ID";
            public static string P_DEPT_ID = "P_DEPT_ID";
            public static string LAYER = "LAYER";
            public static string TYPE_CODE = "TYPE_CODE";
            public static string NSDEPTCODE = "NSDEPTCODE";
            public static string NAME = "NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string D_CODE = "D_CODE";
            public static string CODE = "CODE";
            public static string MZ_FLAG = "MZ_FLAG";
            public static string ZY_FLAG = "ZY_FLAG";
            public static string YJ_FLAG = "YJ_FLAG";
            public static string JZ_FLAG = "JZ_FLAG";
            public static string DELETED = "DELETED";
            public static string DEPTADDR = "DEPTADDR";
            public static string ISJZ = "ISJZ";
            public static string ISFACT = "ISFACT";
            public static string SORT_ID = "SORT_ID";
            public static string HZ_FLAG = "HZ_FLAG";
            public static string SM_FLAG = "SM_FLAG";
            public static string MEMO = "MEMO";
        }
        public static string BASE_DEPT_TYPE = "BASE_DEPT_TYPE";
        public struct base_dept_type
        {
            public static string CODE = "CODE";
            public static string NAME = "NAME";
            public static string PY_CODE = "PY_CODE";
            public static string SERVER = "SERVER";
            public static string COMMENT = "COMMENT";
        }
        public static string BASE_DISEASE = "BASE_DISEASE";
        public struct base_disease
        {
            public static string ID = "ID";
            public static string CODING = "CODING";
            public static string SERIALNO = "SERIALNO";
            public static string ATTACH = "ATTACH";
            public static string NAME = "NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string COMMENT = "COMMENT";
            public static string SLIMIT = "SLIMIT";
            public static string LLIMIT = "LLIMIT";
            public static string SORT = "SORT";
            public static string SORTID = "SORTID";
        }
        public static string BASE_DOCTOR_TYPE = "BASE_DOCTOR_TYPE";
        public struct base_doctor_type
        {
            public static string TYPE_ID = "TYPE_ID";
            public static string TYPE_NAME = "TYPE_NAME";
            public static string GHF_ID = "GHF_ID";
            public static string ZCF_ID = "ZCF_ID";
            public static string JCF_ID = "JCF_ID";
            public static string FZF_ID = "FZF_ID";
            public static string JGHF_ID = "JGHF_ID";
            public static string JZCF_ID = "JZCF_ID";
            public static string JJCF_ID = "JJCF_ID";
            public static string JFZF_ID = "JFZF_ID";
            public static string WB_CODE = "WB_CODE";
            public static string PY_CODE = "PY_CODE";
        }
        public static string BASE_EMP_DEPT_ROLE = "BASE_EMP_DEPT_ROLE";
        public struct base_emp_dept_role
        {
            public static string ID = "ID";
            public static string EMPLOYEE_ID = "EMPLOYEE_ID";
            public static string ROLE_ID = "ROLE_ID";
            public static string DEFAULT = "DEFAULT";
            public static string DEPT_ID = "DEPT_ID";
        }
        public static string BASE_EMPLOYEE_PROPERTY = "BASE_EMPLOYEE_PROPERTY";
        public struct base_employee_property
        {
            public static string EMPLOYEE_ID = "EMPLOYEE_ID";
            public static string NAME = "NAME";
            public static string SEX = "SEX";
            public static string BRITHDAY = "BRITHDAY";
            public static string MARITALS = "MARITALS";
            public static string MAX_DEGREE = "MAX_DEGREE";
            public static string NATIONALITY = "NATIONALITY";
            public static string FOLK = "FOLK";
            public static string TECHNICAL = "TECHNICAL";
            public static string D_CODE = "D_CODE";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string STATUS = "STATUS";
            public static string BIRTHADDR = "BIRTHADDR";
            public static string DOORADDR = "DOORADDR";
            public static string DOORSTREET = "DOORSTREET";
            public static string HOMEADDR = "HOMEADDR";
            public static string HOMESTREET = "HOMESTREET";
            public static string HOME_TEL = "HOME_TEL";
            public static string HANDLE_TEL = "HANDLE_TEL";
            public static string DELETE_BIT = "DELETE_BIT";
            public static string FP_FLAG = "FP_FLAG";
        }
        public static string BASE_GROUP = "BASE_GROUP";
        public struct base_group
        {
            public static string GROUP_ID = "GROUP_ID";
            public static string NAME = "NAME";
            public static string DELETE_FLAG = "DELETE_FLAG";
            public static string ADMINISTRATORS = "ADMINISTRATORS";
            public static string EVERYONE = "EVERYONE";
            public static string MEMO = "MEMO";
            public static string PROPERTY = "PROPERTY";
        }
        public static string BASE_GROUP_MENU = "BASE_GROUP_MENU";
        public struct base_group_menu
        {
            public static string ID = "ID";
            public static string GROUP_ID = "GROUP_ID";
            public static string MODULE_ID = "MODULE_ID";
            public static string MENU_ID = "MENU_ID";
        }
        public static string BASE_GROUP_USER = "BASE_GROUP_USER";
        public struct base_group_user
        {
            public static string ID = "ID";
            public static string USER_ID = "USER_ID";
            public static string GROUP_ID = "GROUP_ID";
            public static string MEMO = "MEMO";
        }
        public static string BASE_HZK = "BASE_HZK";
        public struct base_hzk
        {
            public static string ID = "ID";
            public static string HZ = "HZ";
            public static string PYM = "PYM";
        }
        public static string BASE_ITEM_DEPT = "BASE_ITEM_DEPT";
        public struct base_item_dept
        {
            public static string ITEM_ID = "ITEM_ID";
            public static string DEPT_ID = "DEPT_ID";
            public static string COMPLEX_ID = "COMPLEX_ID";
            public static string DEFAULT_FLAG = "DEFAULT_FLAG";
        }
        public static string BASE_MENU = "BASE_MENU";
        public struct base_menu
        {
            public static string MENU_ID = "MENU_ID";
            public static string SORT_ID = "SORT_ID";
            public static string NAME = "NAME";
            public static string DLL_NAME = "DLL_NAME";
            public static string FUNCTION_NAME = "FUNCTION_NAME";
            public static string FUNCTION_TAG = "FUNCTION_TAG";
            public static string MODULE_ID = "MODULE_ID";
            public static string P_MENU_ID = "P_MENU_ID";
            public static string MENU_TOOLBAR = "MENU_TOOLBAR";
            public static string MENU_OUTLOOKBAR = "MENU_OUTLOOKBAR";
            public static string MEMO = "MEMO";
            public static string IMAGE = "IMAGE";
        }
        public static string BASE_MODULE = "BASE_MODULE";
        public struct base_module
        {
            public static string MODULE_ID = "MODULE_ID";
            public static string NAME = "NAME";
            public static string MEMO = "MEMO";
            public static string SORT_ID = "SORT_ID";
        }
        public static string BASE_NATIONCO = "BASE_NATIONCO";
        public struct base_nationco
        {
            public static string CODE = "CODE";
            public static string NAME = "NAME";
            public static string PY_CODE = "PY_CODE";
            public static string CODE2 = "CODE2";
            public static string ORDERS = "ORDERS";
        }
        public static string BASE_ITEM_FAVORABLE = "BASE_ITEM_FAVORABLE";
        public struct base_item_favorable
        {
            public static string PATTYPECODE = "PATTYPECODE";
            public static string ITEMCODE = "ITEMCODE";
            public static string ITEMTYPE_FLAG = "ITEMTYPE_FLAG";
            public static string FAVORABLE_SCALE = "FAVORABLE_SCALE";
        }
        public static string BASE_ITEMMX_FAVORABLE = "BASE_ITEMMX_FAVORABLE";
        public struct base_itemmx_favorable
        {
            public static string PATTYPECODE = "PATTYPECODE";
            public static string ITEMID = "ITEMID";
            public static string ITEMTYPE = "ITEMTYPE";
            public static string FAVORABLE_SCALE = "FAVORABLE_SCALE";
        }
        public static string BASE_PATIENTTYPE = "BASE_PATIENTTYPE";
        public struct base_patienttype
        {
            public static string CODE = "CODE";
            public static string NAME = "NAME";
        }
        public static string BASE_PATIENTTYPE_COST = "BASE_PATIENTTYPE_COST";
        public struct base_patienttype_cost
        {
            public static string PATTYPECODE = "PATTYPECODE";
            public static string NAME = "NAME";
            public static string FAVORABLE_SCALE = "FAVORABLE_SCALE";
            public static string FAVORABLE_TYPE = "FAVORABLE_TYPE";
            public static string MZ_FLAG = "MZ_FLAG";
            public static string ZY_FLAG = "ZY_FLAG";
            public static string MEDSAFECODE = "MEDSAFECODE";
            public static string DEL_FLAG = "DEL_FLAG";
        }
        public static string BASE_PYMWBM = "BASE_PYMWBM";
        public struct base_pymwbm
        {
            public static string ID = "ID";
            public static string HZ = "HZ";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
        }
        public static string BASE_ROLE_DOCTOR = "BASE_ROLE_DOCTOR";
        public struct base_role_doctor
        {
            public static string DOC_ID = "DOC_ID";
            public static string EMPLOYEE_ID = "EMPLOYEE_ID";
            public static string DEPT_ID = "DEPT_ID";
            public static string YS_CODE = "YS_CODE";
            public static string CF_RIGHT = "CF_RIGHT";
            public static string MZ_RIGHT = "MZ_RIGHT";
            public static string DM_RIGHT = "DM_RIGHT";
            public static string YS_TYPEID = "YS_TYPEID";
            public static string PASSWORD = "PASSWORD";
        }
        public static string BASE_ROLE_NURSE = "BASE_ROLE_NURSE";
        public struct base_role_nurse
        {
            public static string NURSE_ID = "NURSE_ID";
            public static string DEPT_ID = "DEPT_ID";
            public static string EMPLOYEE_ID = "EMPLOYEE_ID";
            public static string PASSWORD = "PASSWORD";
        }
        public static string BASE_SERVICE_ITEMS = "BASE_SERVICE_ITEMS";
        public struct base_service_items
        {
            public static string ITEM_ID = "ITEM_ID";
            public static string STD_CODE = "STD_CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string ITEM_CODE = "ITEM_CODE";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string ITEM_UNIT = "ITEM_UNIT";
            public static string PRICE = "PRICE";
            public static string VALID_FLAG = "VALID_FLAG";
            public static string STATITEM_CODE = "STATITEM_CODE";
        }
        public static string BASE_HOSPITAL_ITEMS = "BASE_HOSPITAL_ITEMS";
        public struct base_hospital_items
        {
            public static string ID = "ID";
            public static string ITEM_ID = "ITEM_ID";
            public static string COMPLEX_ID = "COMPLEX_ID";
        }
        public static string BASE_STAT_BA = "BASE_STAT_BA";
        public struct base_stat_ba
        {
            public static string CODE = "CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string VALID_FLAG = "VALID_FLAG";
        }
        public static string BASE_STAT_HS = "BASE_STAT_HS";
        public struct base_stat_hs
        {
            public static string CODE = "CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string VALID_FLAG = "VALID_FLAG";
        }
        public static string BASE_STAT_ITEM = "BASE_STAT_ITEM";
        public struct base_stat_item
        {
            public static string CODE = "CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string MZKJ_CODE = "MZKJ_CODE";
            public static string ZYKJ_CODE = "ZYKJ_CODE";
            public static string MZFP_CODE = "MZFP_CODE";
            public static string ZYFP_CODE = "ZYFP_CODE";
            public static string HS_CODE = "HS_CODE";
            public static string BA_CODE = "BA_CODE";
            public static string MZYB_CODE = "MZYB_CODE";
            public static string ZYYB_CODE = "ZYYB_CODE";
            public static string ITEM_TYPE = "ITEM_TYPE";
            public static string CFLX_CODE = "CFLX_CODE";
        }
        public static string BASE_STAT_MZFP = "BASE_STAT_MZFP";
        public struct base_stat_mzfp
        {
            public static string CODE = "CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string VALID_FLAG = "VALID_FLAG";
        }
        public static string BASE_STAT_MZKJ = "BASE_STAT_MZKJ";
        public struct base_stat_mzkj
        {
            public static string CODE = "CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string VALID_FLAG = "VALID_FLAG";
        }
        public static string BASE_STAT_MZYB = "BASE_STAT_MZYB";
        public struct base_stat_mzyb
        {
            public static string CODE = "CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string VALID_FLAG = "VALID_FLAG";
        }
        public static string BASE_STAT_ZYFP = "BASE_STAT_ZYFP";
        public struct base_stat_zyfp
        {
            public static string CODE = "CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string VALID_FLAG = "VALID_FLAG";
        }
        public static string BASE_STAT_ZYKJ = "BASE_STAT_ZYKJ";
        public struct base_stat_zykj
        {
            public static string CODE = "CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string VALID_FLAG = "VALID_FLAG";
        }
        public static string BASE_STAT_ZYYB = "BASE_STAT_ZYYB";
        public struct base_stat_zyyb
        {
            public static string CODE = "CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string VALID_FLAG = "VALID_FLAG";
        }
        public static string BASE_SYSTEMUPDATE = "BASE_SYSTEMUPDATE";
        public struct base_systemupdate
        {
            public static string ID = "ID";
            public static string TYPE = "TYPE";
            public static string NAME = "NAME";
            public static string UPDATE_TIME = "UPDATE_TIME";
            public static string VERSION = "VERSION";
            public static string FILE_VALUE = "FILE_VALUE";
            public static string DELETE_BIT = "DELETE_BIT";
        }
        public static string BASE_USER = "BASE_USER";
        public struct base_user
        {
            public static string USER_ID = "USER_ID";
            public static string EMPLOYEE_ID = "EMPLOYEE_ID";
            public static string CODE = "CODE";
            public static string PASSWORD = "PASSWORD";
            public static string GROUP_ID = "GROUP_ID";
            public static string YB_OPERATOR = "YB_OPERATOR";
            public static string JZ_OPERATOR = "JZ_OPERATOR";
            public static string JK_OPERATOR = "JK_OPERATOR";
            public static string CHG_PWD_NEXTIME = "CHG_PWD_NEXTIME";
            public static string DENY_CHG_PWD = "DENY_CHG_PWD";
            public static string PWD_NEVER_EXPIRE = "PWD_NEVER_EXPIRE";
            public static string CHG_PWD_LASTIME = "CHG_PWD_LASTIME";
            public static string PWD_EXPIRE_TIME = "PWD_EXPIRE_TIME";
            public static string LOCK = "LOCK";
            public static string CURFPNO = "CURFPNO";
            public static string CURSJNO = "CURSJNO";
            public static string CURTKDNO = "CURTKDNO";
            public static string CURYJNO = "CURYJNO";
            public static string MEMO = "MEMO";
        }
        public static string BASE_WARD = "BASE_WARD";
        public struct base_ward
        {
            public static string ID = "ID";
            public static string WARD_ID = "WARD_ID";
            public static string DEPT_ID = "DEPT_ID";
            public static string WARD_NAME = "WARD_NAME";
            public static string PY_CODE = "PY_CODE";
            public static string JZ_FLAG = "JZ_FLAG";
        }
        public static string BASE_WARDRDEPT = "BASE_WARDRDEPT";
        public struct base_wardrdept
        {
            public static string ID = "ID";
            public static string WARD_ID = "WARD_ID";
            public static string DEPT_ID = "DEPT_ID";
            public static string MINEXECYE = "MINEXECYE";
        }
        public static string GB_ITEM_NAME = "GB_ITEM_NAME";
        public struct gb_item_name
        {
            public static string CODE = "CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string GB_CODE = "GB_CODE";
        }
        public static string GB_SUB_ITEM = "GB_SUB_ITEM";
        public struct gb_sub_item
        {
            public static string CODE = "CODE";
            public static string SUB_CODE = "SUB_CODE";
            public static string SUB_ITEM_NAME = "SUB_ITEM_NAME";
            public static string DESCRIBTION = "DESCRIBTION";
        }
        public static string GB_STANDARD_SERVICE_ITEMS = "GB_STANDARD_SERVICE_ITEMS";
        public struct gb_standard_service_items
        {
            public static string XH = "XH";
            public static string CWFL = "CWFL";
            public static string FBM = "FBM";
            public static string BM = "BM";
            public static string MC = "MC";
            public static string NH = "NH";
            public static string YBCW = "YBCW";
            public static string DW = "DW";
            public static string SM = "SM";
            public static string SJJG = "SJJG";
            public static string EJJG = "EJJG";
            public static string YJJG = "YJJG";
        }
        public static string HIS_LOG = "HIS_LOG";
        public struct his_log
        {
            public static string ID = "ID";
            public static string DEPT_ID = "DEPT_ID";
            public static string OPERATOR_ID = "OPERATOR_ID";
            public static string OPERATOR_TYPE = "OPERATOR_TYPE";
            public static string CONTENTS = "CONTENTS";
            public static string STARTTIME = "STARTTIME";
            public static string ERRLEVEL = "ERRLEVEL";
            public static string WORKSTATION = "WORKSTATION";
            public static string MODULE_ID = "MODULE_ID";
        }
        public static string HIS_REPORT = "HIS_REPORT";
        public struct his_report
        {
            public static string REPORTID = "REPORTID";
            public static string REPORTNAME = "REPORTNAME";
            public static string REPORTPATH = "REPORTPATH";
            public static string BUILDEMPNAME = "BUILDEMPNAME";
            public static string BUILDEMPCODE = "BUILDEMPCODE";
            public static string BUILDDATETIME = "BUILDDATETIME";
        }
        public static string HIS_WORKERS = "HIS_WORKERS";
        public struct his_workers
        {
            public static string WORKNO = "WORKNO";
            public static string WORKNAME = "WORKNAME";
            public static string WORKMEMO = "WORKMEMO";
            public static string TABLEHEAD = "TABLEHEAD";
            public static string CRYP_FLAG = "CRYP_FLAG";
            public static string PASSLENGTH = "PASSLENGTH";
            public static string PASSBACK = "PASSBACK";
            public static string REGKEY = "REGKEY";
        }
        public static string INSUR_PATIENT_INFO = "INSUR_PATIENT_INFO";
        public struct insur_patient_info
        {
            public static string AREA_ID = "AREA_ID";
            public static string PERSON_CODE = "PERSON_CODE";
            public static string NAME = "NAME";
            public static string SEX = "SEX";
            public static string IDCARD = "IDCARD";
            public static string BIRTHDATE = "BIRTHDATE";
            public static string AGE = "AGE";
            public static string FAMILY_CODE = "FAMILY_CODE";
            public static string MEDCARD_ID = "MEDCARD_ID";
            public static string TRANS_ORGCODE = "TRANS_ORGCODE";
            public static string TRANS_ORGLEVEL = "TRANS_ORGLEVEL";
        }
        public static string MZ_DOCTYPE_REGTYPE = "MZ_DOCTYPE_REGTYPE";
        public struct mz_doctype_regtype
        {
            public static string DOCTOR_TYPE_ID = "DOCTOR_TYPE_ID";
            public static string REG_TYPE_CODE = "REG_TYPE_CODE";
        }
        public static string MZ_ACCOUNT = "MZ_ACCOUNT";
        public struct mz_account
        {
            public static string ACCOUNTID = "ACCOUNTID";
            public static string LASTDATE = "LASTDATE";
            public static string TOTAL_FEE = "TOTAL_FEE";
            public static string CASH_FEE = "CASH_FEE";
            public static string POS_FEE = "POS_FEE";
            public static string ACCOUNTCODE = "ACCOUNTCODE";
            public static string ACCOUNTDATE = "ACCOUNTDATE";
            public static string BLANKOUT = "BLANKOUT";
        }
        public static string MZ_COSTMASTER = "MZ_COSTMASTER";
        public struct mz_costmaster
        {
            public static string COSTMASTERID = "COSTMASTERID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string PRESMASTERID = "PRESMASTERID";
            public static string TICKETNUM = "TICKETNUM";
            public static string TICKETCODE = "TICKETCODE";
            public static string CHARGECODE = "CHARGECODE";
            public static string CHARGENAME = "CHARGENAME";
            public static string TOTAL_FEE = "TOTAL_FEE";
            public static string SELF_FEE = "SELF_FEE";
            public static string VILLAGE_FEE = "VILLAGE_FEE";
            public static string FAVOR_FEE = "FAVOR_FEE";
            public static string POS_FEE = "POS_FEE";
            public static string MONEY_FEE = "MONEY_FEE";
            public static string TICKET_FLAG = "TICKET_FLAG";
            public static string COSTDATE = "COSTDATE";
            public static string RECORD_FLAG = "RECORD_FLAG";
            public static string OLDID = "OLDID";
            public static string ACCOUNTID = "ACCOUNTID";
            public static string HANG_FLAG = "HANG_FLAG";
            public static string HURRIED_FLAG = "HURRIED_FLAG";
            public static string SELF_TALLY = "SELF_TALLY";
        }
        public static string MZ_COSTORDER = "MZ_COSTORDER";
        public struct mz_costorder
        {
            public static string COSTORDERID = "COSTORDERID";
            public static string COSTID = "COSTID";
            public static string TICKETNUM = "TICKETNUM";
            public static string TICKETCODE = "TICKETCODE";
            public static string ITEMTYPE = "ITEMTYPE";
            public static string TOTAL_FEE = "TOTAL_FEE";
            public static string PRESMASTERID = "PRESMASTERID";
        }
        public static string MZ_INCOME_DETAIL = "MZ_INCOME_DETAIL";
        public struct mz_income_detail
        {
            public static string ID = "ID";
            public static string RPTID = "RPTID";
            public static string CHARGE_NAME = "CHARGE_NAME";
            public static string DEPT_NAME = "DEPT_NAME";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string ITEM_FEE = "ITEM_FEE";
            public static string SORT_NO = "SORT_NO";
        }
        public static string MZ_INCOME_RPT = "MZ_INCOME_RPT";
        public struct mz_income_rpt
        {
            public static string RPTID = "RPTID";
            public static string REPORT_TYPE = "REPORT_TYPE";
            public static string STAT_TYPE = "STAT_TYPE";
            public static string STAT_YEAR = "STAT_YEAR";
            public static string STAT_MONTH = "STAT_MONTH";
            public static string STAT_DATE_TYPE = "STAT_DATE_TYPE";
            public static string BEGIN_DATE = "BEGIN_DATE";
            public static string END_DATE = "END_DATE";
            public static string OPERATOR = "OPERATOR";
            public static string LAST_CHANGE_DATE = "LAST_CHANGE_DATE";
            public static string CREATOR = "CREATOR";
            public static string CREATE_DATE = "CREATE_DATE";
        }
        public static string MZ_INVOICE = "MZ_INVOICE";
        public struct mz_invoice
        {
            public static string ID = "ID";
            public static string INVOICE_TYPE = "INVOICE_TYPE";
            public static string EMPLOYEE_ID = "EMPLOYEE_ID";
            public static string START_NO = "START_NO";
            public static string END_NO = "END_NO";
            public static string CURRENT_NO = "CURRENT_NO";
            public static string STATUS = "STATUS";
            public static string ALLOT_DATE = "ALLOT_DATE";
            public static string ALLOT_USER = "ALLOT_USER";
            public static string PERFCHAR = "PERFCHAR";
        }
        public static string MZ_PATIENT = "MZ_PATIENT";
        public struct mz_patient
        {
            public static string PATID = "PATID";
            public static string CARDNO = "CARDNO";
            public static string PATNAME = "PATNAME";
            public static string SEX = "SEX";
            public static string TYPE = "TYPE";
            public static string TYPE_NAME = "TYPE_NAME";
            public static string IDCARD = "IDCARD";
            public static string BORNDAY = "BORNDAY";
            public static string FOLK = "FOLK";
            public static string TEL = "TEL";
            public static string OCCUPATION = "OCCUPATION";
            public static string ADDRESS = "ADDRESS";
        }
        public static string MZ_PATLIST = "MZ_PATLIST";
        public struct mz_patlist
        {
            public static string PATLISTID = "PATLISTID";
            public static string PATID = "PATID";
            public static string PATCODE = "PATCODE";
            public static string VISITNO = "VISITNO";
            public static string REGCODE = "REGCODE";
            public static string REGNAME = "REGNAME";
            public static string REG_DEPT_CODE = "REG_DEPT_CODE";
            public static string REG_DOC_CODE = "REG_DOC_CODE";
            public static string REG_DOC_NAME = "REG_DOC_NAME";
            public static string REG_DEPT_NAME = "REG_DEPT_NAME";
            public static string PATNAME = "PATNAME";
            public static string PATSEX = "PATSEX";
            public static string AGE = "AGE";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
            public static string MEDICARD = "MEDICARD";
            public static string MEDITYPE = "MEDITYPE";
            public static string HPCODE = "HPCODE";
            public static string HPGRADE = "HPGRADE";
            public static string CUREDEPTCODE = "CUREDEPTCODE";
            public static string CUREEMPCODE = "CUREEMPCODE";
            public static string DISEASECODE = "DISEASECODE";
            public static string DISEASENAME = "DISEASENAME";
            public static string CUREDATE = "CUREDATE";
            public static string CURESTATUS = "CURESTATUS";
        }
        public static string MZ_PRESMASTER = "MZ_PRESMASTER";
        public struct mz_presmaster
        {
            public static string PRESMASTERID = "PRESMASTERID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string PRESTYPE = "PRESTYPE";
            public static string PRESDOCCODE = "PRESDOCCODE";
            public static string PRESDEPTCODE = "PRESDEPTCODE";
            public static string EXECDOCCODE = "EXECDOCCODE";
            public static string EXECDEPTCODE = "EXECDEPTCODE";
            public static string PRESCOSTCODE = "PRESCOSTCODE";
            public static string CHARGECODE = "CHARGECODE";
            public static string PRESAMOUNT = "PRESAMOUNT";
            public static string TOTAL_FEE = "TOTAL_FEE";
            public static string REDEEMCOST = "REDEEMCOST";
            public static string COSTMASTERID = "COSTMASTERID";
            public static string OLDID = "OLDID";
            public static string TICKETNUM = "TICKETNUM";
            public static string TICKETCODE = "TICKETCODE";
            public static string RECORD_FLAG = "RECORD_FLAG";
            public static string CHARGE_FLAG = "CHARGE_FLAG";
            public static string DRUG_FLAG = "DRUG_FLAG";
            public static string PRESDATE = "PRESDATE";
            public static string HAND_FLAG = "HAND_FLAG";
            public static string ROUNGINGMONEY = "ROUNGINGMONEY";
            public static string DOCPRESID = "DOCPRESID";
        }
        public static string MZ_PRESORDER = "MZ_PRESORDER";
        public struct mz_presorder
        {
            public static string PRESORDERID = "PRESORDERID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string PRESMASTERID = "PRESMASTERID";
            public static string ITEMID = "ITEMID";
            public static string ITEMTYPE = "ITEMTYPE";
            public static string BIGITEMCODE = "BIGITEMCODE";
            public static string ITEMNAME = "ITEMNAME";
            public static string STANDARD = "STANDARD";
            public static string UNIT = "UNIT";
            public static string RELATIONNUM = "RELATIONNUM";
            public static string BUY_PRICE = "BUY_PRICE";
            public static string SELL_PRICE = "SELL_PRICE";
            public static string AMOUNT = "AMOUNT";
            public static string PRESAMOUNT = "PRESAMOUNT";
            public static string TOLAL_FEE = "TOLAL_FEE";
            public static string COMP_MONEY = "COMP_MONEY";
            public static string ORDER_FLAG = "ORDER_FLAG";
            public static string PASSID = "PASSID";
            public static string CASEID = "CASEID";
        }
        public static string MZ_REG_DEPT_FEE = "MZ_REG_DEPT_FEE";
        public struct mz_reg_dept_fee
        {
            public static string DEPT_ID = "DEPT_ID";
            public static string ITEM_ID = "ITEM_ID";
        }
        public static string MZ_REG_ITEM_FEE = "MZ_REG_ITEM_FEE";
        public struct mz_reg_item_fee
        {
            public static string TYPE_CODE = "TYPE_CODE";
            public static string ITEM_ID = "ITEM_ID";
            public static string APPEND = "APPEND";
        }
        public static string MZ_REG_TYPE = "MZ_REG_TYPE";
        public struct mz_reg_type
        {
            public static string TYPE_CODE = "TYPE_CODE";
            public static string TYPE_NAME = "TYPE_NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string VALID_FLAG = "VALID_FLAG";
        }
        public static string MZ_REPORT_LIST = "MZ_REPORT_LIST";
        public struct mz_report_list
        {
            public static string REPORT_NAME = "REPORT_NAME";
            public static string CREATOR = "CREATOR";
            public static string CRRATORDATE = "CRRATORDATE";
            public static string LASTCHAGEUSER = "LASTCHAGEUSER";
            public static string LASTCHAGEDATE = "LASTCHAGEDATE";
        }
        public static string MZ_REPORT_TITLE = "MZ_REPORT_TITLE";
        public struct mz_report_title
        {
            public static string REPORT_NAME = "REPORT_NAME";
            public static string TITLE_NAME = "TITLE_NAME";
            public static string SORTNO = "SORTNO";
            public static string FIXCOL = "FIXCOL";
        }
        public static string MZ_REPORT_TITLE_FIELD = "MZ_REPORT_TITLE_FIELD";
        public struct mz_report_title_field
        {
            public static string REPORT_NAME = "REPORT_NAME";
            public static string TITLE_NAME = "TITLE_NAME";
            public static string FIELD_NAME = "FIELD_NAME";
        }
        public static string MZ_SERIAL_NO = "MZ_SERIAL_NO";
        public struct mz_serial_no
        {
            public static string VISIT_NO = "VISIT_NO";
        }
        public static string NCMS_DRUG_CATALOG = "NCMS_DRUG_CATALOG ";
        public struct ncms_drug_catalog
        {
            public static string DRUG_ALIAS = "DRUG_ALIAS";
            public static string DRUG_CODE = "DRUG_CODE";
            public static string DRUG_CODE2 = "DRUG_CODE2";
            public static string DRUG_FORM = "DRUG_FORM";
            public static string DRUG_NAME = "DRUG_NAME";
            public static string DRUG_TYPE = "DRUG_TYPE";
            public static string DRUGCLASS_CODE = "DRUGCLASS_CODE";
            public static string LIMIT_DEPT = "LIMIT_DEPT";
            public static string LIMIT_DESC = "LIMIT_DESC";
            public static string LIMIT_DISEASE = "LIMIT_DISEASE";
            public static string LIMIT_DOCTOR = "LIMIT_DOCTOR";
            public static string LIMIT_FORM = "LIMIT_FORM";
            public static string LIMIT_HOSPITAL = "LIMIT_HOSPITAL";
            public static string LIMIT_LINE = "LIMIT_LINE";
            public static string LIMIT_MAKER = "LIMIT_MAKER";
            public static string LIMIT_PRICE = "LIMIT_PRICE";
            public static string LIMIT_PRICEFIELDSPECIFIED = "LIMIT_PRICEFIELDSPECIFIED";
            public static string LIMIT_UNIT_NAME = "LIMIT_UNIT_NAME";
            public static string LIMIT_UNIT_NUM = "LIMIT_UNIT_NUM";
            public static string MARK = "MARK";
            public static string USE_LEVEL = "USE_LEVEL";
        }
        public static string NCMS_THERAPY_CATALOG = "NCMS_THERAPY_CATALOG";
        public struct ncms_therapy_catalog
        {
            public static string EXCLUDE_CONTENT = "EXCLUDE_CONTENT";
            public static string FINANCE_TYPE = "FINANCE_TYPE";
            public static string ITEM_CODE = "ITEM_CODE";
            public static string ITEM_CONTENT = "ITEM_CONTENT";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string MARK = "MARK";
            public static string MEDCLASS_CODE = "MEDCLASS_CODE";
            public static string PRICE1 = "PRICE1";
            public static string PRICE2 = "PRICE2";
            public static string PRICE3 = "PRICE3";
            public static string SPECS = "SPECS";
            public static string UNIT = "UNIT";
        }
        public static string NCMS_MATCH_CATALOG = "NCMS_MATCH_CATALOG";
        public struct ncms_match_catalog
        {
            public static string APPROVETIME = "APPROVETIME";
            public static string APPROVE_STATUS = "APPROVE_STATUS";
            public static string HOSPITAL_CODE = "HOSPITAL_CODE";
            public static string IF_EQUAL = "IF_EQUAL";
            public static string MEDORG_CODE = "MEDORG_CODE";
            public static string NCMS_CODE = "NCMS_CODE";
            public static string REGION_CODE = "REGION_CODE";
            public static string STATUS = "STATUS";
            public static string TYPE = "TYPE";
            public static string UPLOAD_TIME = "UPLOAD_TIME";
            public static string UPLOADER = "UPLOADER";
        }
        public static string NCMS_MATCH_CATALOG_TEMP = "NCMS_MATCH_CATALOG_TEMP";
        public struct ncms_match_catalog_temp
        {
            public static string HOSPITAL_CODE = "HOSPITAL_CODE";
            public static string MEDORG_CODE = "MEDORG_CODE";
            public static string NCMS_CODE = "NCMS_CODE";
            public static string REGION_CODE = "REGION_CODE";
            public static string STATUS = "STATUS";
            public static string COMP_RATE = "COMP_RATE";
            public static string TYPE = "TYPE";

        }
        public static string PATIENTINFO = "PATIENTINFO";
        public struct patientinfo
        {
            public static string PATID = "PATID";
            public static string PATCODE = "PATCODE";
            public static string PATNAME = "PATNAME";
            public static string PATSEX = "PATSEX";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
            public static string FAMILYCODE = "FAMILYCODE";
            public static string MEDICARD = "MEDICARD";
            public static string CURENO = "CURENO";
            public static string CURENUM = "CURENUM";
            public static string PATNUMBER = "PATNUMBER";
            public static string PATBRIDATE = "PATBRIDATE";
            public static string PATGROUP = "PATGROUP";
            public static string PATTEL = "PATTEL";
            public static string PATADDRESS = "PATADDRESS";
            public static string PATCASENO = "PATCASENO";
            public static string PATJOB = "PATJOB";
            public static string ACCOUNTTYPE = "ACCOUNTTYPE";
            public static string ALLERGIC = "ALLERGIC";
        }
        public static string PUB_IPINFORMATION = "PUB_IPINFORMATION";
        public struct pub_ipinformation
        {
            public static string ID = "ID";
            public static string IP_ADDRESS = "IP_ADDRESS";
            public static string HOSTNAME = "HOSTNAME";
            public static string PORT = "PORT";
            public static string DEPT_ID = "DEPT_ID";
            public static string DTYPE = "DTYPE";
            public static string D_DEPT_ID = "D_DEPT_ID";
            public static string D_USER = "D_USER";
            public static string D_DATE = "D_DATE";
            public static string USE_FLAG = "USE_FLAG";
        }
        public static string PUB_MESSAGE = "PUB_MESSAGE";
        public struct pub_message
        {
            public static string ID = "ID";
            public static string BDATE = "BDATE";
            public static string EDATE = "EDATE";
            public static string TITLE = "TITLE";
            public static string CONTENT = "CONTENT";
            public static string INFORM = "INFORM";
            public static string BOOK_USER = "BOOK_USER";
            public static string BOOK_DATE = "BOOK_DATE";
            public static string MTYPE = "MTYPE";
            public static string FLAG = "FLAG";
            public static string READER = "READER";
            public static string READ_DATE = "READ_DATE";
            public static string MEMO = "MEMO";
            public static string SDEPT_ID = "SDEPT_ID";
            public static string LEVEL = "LEVEL";
            public static string XTYPE = "XTYPE";
            public static string TLSJ = "TLSJ";
        }
        public static string PUB_MESSAGE_DEPT = "PUB_MESSAGE_DEPT";
        public struct pub_message_dept
        {
            public static string ID = "ID";
            public static string P_ID = "P_ID";
            public static string DEPT_ID = "DEPT_ID";
            public static string IP_ADDRESS = "IP_ADDRESS";
        }
        public static string PUB_REGISTER = "PUB_REGISTER";
        public struct pub_register
        {
            public static string ID = "ID";
            public static string D_USER = "D_USER";
            public static string D_DEPT_ID = "D_DEPT_ID";
            public static string D_DATE = "D_DATE";
            public static string L_DATE = "L_DATE";
            public static string USE_FLAG = "USE_FLAG";
            public static string DTYPE = "DTYPE";
            public static string IP_ADDRESS = "IP_ADDRESS";
            public static string HOSTNAME = "HOSTNAME";
        }
        public static string YF_ACCOUNT = "YF_ACCOUNT";
        public struct yf_account
        {
            public static string MACCOUNTID = "MACCOUNTID";
            public static string ACCOUNTYEAR = "ACCOUNTYEAR";
            public static string ACCOUNTMONTH = "ACCOUNTMONTH";
            public static string ACCOUNTTYPE = "ACCOUNTTYPE";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string STOCKPRICE = "STOCKPRICE";
            public static string OPTYPE = "OPTYPE";
            public static string BILLNUM = "BILLNUM";
            public static string UNITNUM = "UNITNUM";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string REGTIME = "REGTIME";
            public static string DEBITNUM = "DEBITNUM";
            public static string LENDERNUM = "LENDERNUM";
            public static string OVERNUM = "OVERNUM";
            public static string DEBITFEE = "DEBITFEE";
            public static string LENDERFEE = "LENDERFEE";
            public static string BALANCEFEE = "BALANCEFEE";
            public static string BALANCE_FLAG = "BALANCE_FLAG";
            public static string ACCOUNTHISTORYID = "ACCOUNTHISTORYID";
            public static string MAKERDICID = "MAKERDICID";
            public static string DEPTID = "DEPTID";
            public static string ORDERID = "ORDERID";
        }
        public static string YF_ACCOUNTHIS = "YF_ACCOUNTHIS";
        public struct yf_accounthis
        {
            public static string ACCOUNTHISTORYID = "ACCOUNTHISTORYID";
            public static string ACCOUNTYEAR = "ACCOUNTYEAR";
            public static string ACCOUNTMONTH = "ACCOUNTMONTH";
            public static string BEGINTIME = "BEGINTIME";
            public static string ENDTIME = "ENDTIME";
            public static string REGMAN = "REGMAN";
            public static string REGTIME = "REGTIME";
            public static string DEPTID = "DEPTID";
        }
        public static string YF_CHECKMASTER = "YF_CHECKMASTER";
        public struct yf_checkmaster
        {
            public static string MASTERCHECKID = "MASTERCHECKID";
            public static string BILLNUM = "BILLNUM";
            public static string REGPEOPLEID = "REGPEOPLEID";
            public static string REGTIME = "REGTIME";
            public static string AUDITPEOPLEID = "AUDITPEOPLEID";
            public static string AUDITTIME = "AUDITTIME";
            public static string REMARK = "REMARK";
            public static string DEL_FLAG = "DEL_FLAG";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string OPTYPE = "OPTYPE";
            public static string DEPTID = "DEPTID";
            public static string AUDITNUM = "AUDITNUM";
            public static string MORERETAILFEE = "MORERETAILFEE";
            public static string MORETRADEFEE = "MORETRADEFEE";
            public static string LESSRETAILFEE = "LESSRETAILFEE";
            public static string LESSTRADEFEE = "LESSTRADEFEE";
        }
        public static string YF_CHECKORDER = "YF_CHECKORDER";
        public struct yf_checkorder
        {
            public static string CHECKORDERID = "CHECKORDERID";
            public static string STORAGEID = "STORAGEID";
            public static string DEPTID = "DEPTID";
            public static string MAKERDICID = "MAKERDICID";
            public static string BILLNUM = "BILLNUM";
            public static string CHECKNUM = "CHECKNUM";
            public static string CKTRADEFEE = "CKTRADEFEE";
            public static string CKRETAILFEE = "CKRETAILFEE";
            public static string FACTNUM = "FACTNUM";
            public static string FTTRADEFEE = "FTTRADEFEE";
            public static string FTRETAILFEE = "FTRETAILFEE";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string UNITNUM = "UNITNUM";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string BILLTIME = "BILLTIME";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string GROUPNUM = "GROUPNUM";
            public static string MASTERCHECKID = "MASTERCHECKID";
            public static string BATCHNUM = "BATCHNUM";
            public static string VALIDITYDATE = "VALIDITYDATE";
        }
        public static string YF_DRMASTER = "YF_DRMASTER";
        public struct yf_drmaster
        {
            public static string MASTERDRUGOCID = "MASTERDRUGOCID";
            public static string RETAILFEE = "RETAILFEE";
            public static string INVOICENUM = "INVOICENUM";
            public static string INPATIENTID = "INPATIENTID";
            public static string RECIPEID = "RECIPEID";
            public static string RECIPENUM = "RECIPENUM";
            public static string PATIENTNO = "PATIENTNO";
            public static string PATIENTID = "PATIENTID";
            public static string PATIENTNAME = "PATIENTNAME";
            public static string DOCID = "DOCID";
            public static string OPPEOPLEID = "OPPEOPLEID";
            public static string OPTIME = "OPTIME";
            public static string CHARGE_FLAG = "CHARGE_FLAG";
            public static string DRUGOC_FLAG = "DRUGOC_FLAG";
            public static string OPTYPE = "OPTYPE";
            public static string RECEIPTCODE = "RECEIPTCODE";
            public static string DOSAGEMAN = "DOSAGEMAN";
            public static string CHARGEDATE = "CHARGEDATE";
            public static string CHARGEMAN = "CHARGEMAN";
            public static string DEPTID = "DEPTID";
            public static string UNIFORMID = "UNIFORMID";
        }
        public static string YF_DRORDER = "YF_DRORDER";
        public struct yf_drorder
        {
            public static string ORDERDRUGOCID = "ORDERDRUGOCID";
            public static string MASTERDRUGOCID = "MASTERDRUGOCID";
            public static string INVOICENUM = "INVOICENUM";
            public static string ORDERRECIPEID = "ORDERRECIPEID";
            public static string INPATIENTID = "INPATIENTID";
            public static string MAKERDICID = "MAKERDICID";
            public static string SPECDICID = "SPECDICID";
            public static string CHEMNAME = "CHEMNAME";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string UNITNUM = "UNITNUM";
            public static string DRUGOCNUM = "DRUGOCNUM";
            public static string DOSENUM = "DOSENUM";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string RETAILFEE = "RETAILFEE";
            public static string TRADEFEE = "TRADEFEE";
            public static string DRUGOC_FLAG = "DRUGOC_FLAG";
            public static string REFUNDMENT_FLAG = "REFUNDMENT_FLAG";
            public static string UNIFORM_FLAG = "UNIFORM_FLAG";
            public static string DEPTID = "DEPTID";
            public static string UNIFORMID = "UNIFORMID";
            public static string CUREDEPTID = "CUREDEPTID";
        }
        public static string YF_INMASTER = "YF_INMASTER";
        public struct yf_inmaster
        {
            public static string MASTERINSTORAGEID = "MASTERINSTORAGEID";
            public static string OPMANID = "OPMANID";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string DEL_FLAG = "DEL_FLAG";
            public static string REMARK = "REMARK";
            public static string AUDITTIME = "AUDITTIME";
            public static string AUDITPEOPLEID = "AUDITPEOPLEID";
            public static string REGTIME = "REGTIME";
            public static string REGPEOPLEID = "REGPEOPLEID";
            public static string BILLNUM = "BILLNUM";
            public static string STOCKFEE = "STOCKFEE";
            public static string RETAILFEE = "RETAILFEE";
            public static string TRADEFEE = "TRADEFEE";
            public static string INVOICENUM = "INVOICENUM";
            public static string INVOICEDATE = "INVOICEDATE";
            public static string BILLDATE = "BILLDATE";
            public static string SUPPORTDICID = "SUPPORTDICID";
            public static string DELIVERNUM = "DELIVERNUM";
            public static string PAY_FLAG = "PAY_FLAG";
            public static string OPTYPE = "OPTYPE";
            public static string DEPTID = "DEPTID";
        }
        public static string YF_INORDER = "YF_INORDER";
        public struct yf_inorder
        {
            public static string INSTORAGEID = "INSTORAGEID";
            public static string MAKERDICID = "MAKERDICID";
            public static string BATCHNUM = "BATCHNUM";
            public static string VALIDITYDATE = "VALIDITYDATE";
            public static string RECSCALE = "RECSCALE";
            public static string INNUM = "INNUM";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string UNITNUM = "UNITNUM";
            public static string STOCKPRICE = "STOCKPRICE";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string STOCKFEE = "STOCKFEE";
            public static string RETAILFEE = "RETAILFEE";
            public static string TRADEFEE = "TRADEFEE";
            public static string BILLNUM = "BILLNUM";
            public static string DEPTID = "DEPTID";
            public static string REMARK = "REMARK";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string MASTERINSTORAGEID = "MASTERINSTORAGEID";
            public static string SUPPORTDICID = "SUPPORTDICID";
            public static string DELIVERNUM = "DELIVERNUM";
        }
        public static string YF_OUTMASTER = "YF_OUTMASTER";
        public struct yf_outmaster
        {
            public static string MASTEROUTSTORAGEID = "MASTEROUTSTORAGEID";
            public static string REMARK = "REMARK";
            public static string DEL_FLAG = "DEL_FLAG";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string AUDITTIME = "AUDITTIME";
            public static string AUDITPEOPLEID = "AUDITPEOPLEID";
            public static string REGTIME = "REGTIME";
            public static string REGPEOPLEID = "REGPEOPLEID";
            public static string BILLNUM = "BILLNUM";
            public static string OUTFEE = "OUTFEE";
            public static string RETAILFEE = "RETAILFEE";
            public static string TRADEFEE = "TRADEFEE";
            public static string INVOICENUM = "INVOICENUM";
            public static string INVOICEDATE = "INVOICEDATE";
            public static string BILLDATE = "BILLDATE";
            public static string OPTYPE = "OPTYPE";
            public static string DEPTID = "DEPTID";
            public static string OUTDEPTID = "OUTDEPTID";
        }
        public static string YF_OUTORDER = "YF_OUTORDER";
        public struct yf_outorder
        {
            public static string OUTSTORAGEID = "OUTSTORAGEID";
            public static string MAKERDICID = "MAKERDICID";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string REMARK = "REMARK";
            public static string BILLNUM = "BILLNUM";
            public static string TRADEFEE = "TRADEFEE";
            public static string RETAILFEE = "RETAILFEE";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string UNITNUM = "UNITNUM";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string OUTNUM = "OUTNUM";
            public static string RECSCALE = "RECSCALE";
            public static string VALIDITYDATE = "VALIDITYDATE";
            public static string PRODUCTNUM = "PRODUCTNUM";
            public static string OUTREASON = "OUTREASON";
            public static string OUTDEPTID = "OUTDEPTID";
            public static string MASTEROUTSTORAGEID = "MASTEROUTSTORAGEID";
            public static string DEPTID = "DEPTID";
        }
        public static string YF_STORAGE = "YF_STORAGE";
        public struct yf_storage
        {
            public static string STORAGEID = "STORAGEID";
            public static string MAKERDICID = "MAKERDICID";
            public static string CURRENTNUM = "CURRENTNUM";
            public static string PLACE = "PLACE";
            public static string LSTOCKPRICE = "LSTOCKPRICE";
            public static string REGTIME = "REGTIME";
            public static string UPPERLIMIT = "UPPERLIMIT";
            public static string LOWERLIMIT = "LOWERLIMIT";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string UNITNUM = "UNITNUM";
            public static string DEL_FLAG = "DEL_FLAG";
            public static string DEPTID = "DEPTID";
        }
        public static string YK_ACCOUNT = "YK_ACCOUNT";
        public struct yk_account
        {
            public static string MACCOUNTID = "MACCOUNTID";
            public static string ACCOUNTYEAR = "ACCOUNTYEAR";
            public static string ACCOUNTMONTH = "ACCOUNTMONTH";
            public static string ACCOUNTTYPE = "ACCOUNTTYPE";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string STOCKPRICE = "STOCKPRICE";
            public static string OPTYPE = "OPTYPE";
            public static string BILLNUM = "BILLNUM";
            public static string UNITNUM = "UNITNUM";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string REGTIME = "REGTIME";
            public static string DEBITNUM = "DEBITNUM";
            public static string LENDERNUM = "LENDERNUM";
            public static string OVERNUM = "OVERNUM";
            public static string DEBITFEE = "DEBITFEE";
            public static string LENDERFEE = "LENDERFEE";
            public static string BALANCEFEE = "BALANCEFEE";
            public static string BALANCE_FLAG = "BALANCE_FLAG";
            public static string ACCOUNTHISTORYID = "ACCOUNTHISTORYID";
            public static string MAKERDICID = "MAKERDICID";
            public static string DEPTID = "DEPTID";
            public static string ORDERID = "ORDERID";
        }
        public static string YK_ACCOUNTHIS = "YK_ACCOUNTHIS";
        public struct yk_accounthis
        {
            public static string ACCOUNTHISTORYID = "ACCOUNTHISTORYID";
            public static string ACCOUNTYEAR = "ACCOUNTYEAR";
            public static string ACCOUNTMONTH = "ACCOUNTMONTH";
            public static string BEGINTIME = "BEGINTIME";
            public static string ENDTIME = "ENDTIME";
            public static string REGMAN = "REGMAN";
            public static string REGTIME = "REGTIME";
            public static string DEPTID = "DEPTID";
        }
        public static string YK_CHECKMASTER = "YK_CHECKMASTER";
        public struct yk_checkmaster
        {
            public static string MASTERCHECKID = "MASTERCHECKID";
            public static string BILLNUM = "BILLNUM";
            public static string REGPEOPLEID = "REGPEOPLEID";
            public static string REGTIME = "REGTIME";
            public static string AUDITPEOPLEID = "AUDITPEOPLEID";
            public static string AUDITTIME = "AUDITTIME";
            public static string REMARK = "REMARK";
            public static string DEL_FLAG = "DEL_FLAG";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string OPTYPE = "OPTYPE";
            public static string DEPTID = "DEPTID";
            public static string AUDITNUM = "AUDITNUM";
            public static string MORERETAILFEE = "MORERETAILFEE";
            public static string MORETRADEFEE = "MORETRADEFEE";
            public static string LESSRETAILFEE = "LESSRETAILFEE";
            public static string LESSTRADEFEE = "LESSTRADEFEE";
        }
        public static string YK_CHECKORDER = "YK_CHECKORDER";
        public struct yk_checkorder
        {
            public static string CHECKORDERID = "CHECKORDERID";
            public static string STORAGEID = "STORAGEID";
            public static string DEPTID = "DEPTID";
            public static string MAKERDICID = "MAKERDICID";
            public static string BILLNUM = "BILLNUM";
            public static string CHECKNUM = "CHECKNUM";
            public static string CKTRADEFEE = "CKTRADEFEE";
            public static string CKRETAILFEE = "CKRETAILFEE";
            public static string FACTNUM = "FACTNUM";
            public static string FTTRADEFEE = "FTTRADEFEE";
            public static string FTRETAILFEE = "FTRETAILFEE";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string UNITNUM = "UNITNUM";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string BILLTIME = "BILLTIME";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string GROUPNUM = "GROUPNUM";
            public static string MASTERCHECKID = "MASTERCHECKID";
            public static string BATCHNUM = "BATCHNUM";
            public static string VALIDITYDATE = "VALIDITYDATE";
        }
        public static string YK_INMASTER = "YK_INMASTER";
        public struct yk_inmaster
        {
            public static string MASTERINSTORAGEID = "MASTERINSTORAGEID";
            public static string OPMANID = "OPMANID";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string DEL_FLAG = "DEL_FLAG";
            public static string REMARK = "REMARK";
            public static string AUDITTIME = "AUDITTIME";
            public static string AUDITPEOPLEID = "AUDITPEOPLEID";
            public static string REGTIME = "REGTIME";
            public static string REGPEOPLEID = "REGPEOPLEID";
            public static string BILLNUM = "BILLNUM";
            public static string STOCKFEE = "STOCKFEE";
            public static string RETAILFEE = "RETAILFEE";
            public static string TRADEFEE = "TRADEFEE";
            public static string INVOICENUM = "INVOICENUM";
            public static string INVOICEDATE = "INVOICEDATE";
            public static string BILLDATE = "BILLDATE";
            public static string SUPPORTDICID = "SUPPORTDICID";
            public static string DELIVERNUM = "DELIVERNUM";
            public static string PAY_FLAG = "PAY_FLAG";
            public static string OPTYPE = "OPTYPE";
            public static string DEPTID = "DEPTID";
        }
        public static string YK_INORDER = "YK_INORDER";
        public struct yk_inorder
        {
            public static string INSTORAGEID = "INSTORAGEID";
            public static string MAKERDICID = "MAKERDICID";
            public static string BATCHNUM = "BATCHNUM";
            public static string VALIDITYDATE = "VALIDITYDATE";
            public static string RECSCALE = "RECSCALE";
            public static string INNUM = "INNUM";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string UNITNUM = "UNITNUM";
            public static string STOCKPRICE = "STOCKPRICE";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string STOCKFEE = "STOCKFEE";
            public static string RETAILFEE = "RETAILFEE";
            public static string TRADEFEE = "TRADEFEE";
            public static string BILLNUM = "BILLNUM";
            public static string DEPTID = "DEPTID";
            public static string REMARK = "REMARK";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string MASTERINSTORAGEID = "MASTERINSTORAGEID";
            public static string DELIVERNUM = "DELIVERNUM";
        }
        public static string YK_OUTMASTER = "YK_OUTMASTER";
        public struct yk_outmaster
        {
            public static string MASTEROUTSTORAGEID = "MASTEROUTSTORAGEID";
            public static string REMARK = "REMARK";
            public static string DEL_FLAG = "DEL_FLAG";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string AUDITTIME = "AUDITTIME";
            public static string AUDITPEOPLEID = "AUDITPEOPLEID";
            public static string REGTIME = "REGTIME";
            public static string REGPEOPLEID = "REGPEOPLEID";
            public static string BILLNUM = "BILLNUM";
            public static string OUTFEE = "OUTFEE";
            public static string RETAILFEE = "RETAILFEE";
            public static string TRADEFEE = "TRADEFEE";
            public static string INVOICENUM = "INVOICENUM";
            public static string INVOICEDATE = "INVOICEDATE";
            public static string BILLDATE = "BILLDATE";
            public static string OPTYPE = "OPTYPE";
            public static string DEPTID = "DEPTID";
            public static string RELATIONNUM = "RELATIONNUM";
            public static string OUTDEPTID = "OUTDEPTID";
        }
        public static string YK_OUTORDER = "YK_OUTORDER";
        public struct yk_outorder
        {
            public static string OUTSTORAGEID = "OUTSTORAGEID";
            public static string MAKERDICID = "MAKERDICID";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string REMARK = "REMARK";
            public static string BILLNUM = "BILLNUM";
            public static string TRADEFEE = "TRADEFEE";
            public static string RETAILFEE = "RETAILFEE";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string UNITNUM = "UNITNUM";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string OUTNUM = "OUTNUM";
            public static string RECSCALE = "RECSCALE";
            public static string VALIDITYDATE = "VALIDITYDATE";
            public static string PRODUCTNUM = "PRODUCTNUM";
            public static string OUTREASON = "OUTREASON";
            public static string OUTDEPTID = "OUTDEPTID";
            public static string MASTEROUTSTORAGEID = "MASTEROUTSTORAGEID";
            public static string DEPTID = "DEPTID";
        }
        public static string YK_PLANMASTER = "YK_PLANMASTER";
        public struct yk_planmaster
        {
            public static string PLANMASTERID = "PLANMASTERID";
            public static string REGTIME = "REGTIME";
            public static string REGPEOPLENAME = "REGPEOPLENAME";
            public static string REGPEOPLE = "REGPEOPLE";
            public static string RETAILFEE = "RETAILFEE";
            public static string TRADEFEE = "TRADEFEE";
            public static string LASTCHANGTIME = "LASTCHANGTIME";
        }
        public static string YK_PLANORDER = "YK_PLANORDER";
        public struct yk_planorder
        {
            public static string PLANORDERID = "PLANORDERID";
            public static string PLANMASTERID = "PLANMASTERID";
            public static string MAKERDICID = "MAKERDICID";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string TRADEFEE = "TRADEFEE";
            public static string RETAILFEE = "RETAILFEE";
            public static string UNIT = "UNIT";
            public static string STOCKNUM = "STOCKNUM";
            public static string UNITNAME = "UNITNAME";
        }
        public static string YK_STORAGE = "YK_STORAGE";
        public struct yk_storage
        {
            public static string STORAGEID = "STORAGEID";
            public static string MAKERDICID = "MAKERDICID";
            public static string CURRENTNUM = "CURRENTNUM";
            public static string PLACE = "PLACE";
            public static string LSTOCKPRICE = "LSTOCKPRICE";
            public static string REGTIME = "REGTIME";
            public static string UPPERLIMIT = "UPPERLIMIT";
            public static string LOWERLIMIT = "LOWERLIMIT";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string UNITNUM = "UNITNUM";
            public static string DEL_FLAG = "DEL_FLAG";
            public static string DEPTID = "DEPTID";
        }
        public static string YP_ADJMASTER = "YP_ADJMASTER";
        public struct yp_adjmaster
        {
            public static string MASTERADJPRICEID = "MASTERADJPRICEID";
            public static string BILLNUM = "BILLNUM";
            public static string REGPEOPLE = "REGPEOPLE";
            public static string REGTIME = "REGTIME";
            public static string REMARK = "REMARK";
            public static string ADJCODE = "ADJCODE";
            public static string EXETIME = "EXETIME";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string DEL_FLAG = "DEL_FLAG";
            public static string OPTYPE = "OPTYPE";
            public static string OVER_FLAG = "OVER_FLAG";
            public static string DEPTID = "DEPTID";
        }
        public static string YP_ADJORDER = "YP_ADJORDER";
        public struct yp_adjorder
        {
            public static string ORDERADJPRICEID = "ORDERADJPRICEID";
            public static string MASTERIADJPRICED = "MASTERIADJPRICED";
            public static string MAKERDICID = "MAKERDICID";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string UNITNUM = "UNITNUM";
            public static string OLDTRADEPRICE = "OLDTRADEPRICE";
            public static string NEWTRADEPRICE = "NEWTRADEPRICE";
            public static string ADJTRADEFEE = "ADJTRADEFEE";
            public static string OLDRETAILPRICE = "OLDRETAILPRICE";
            public static string NEWRETAILPRICE = "NEWRETAILPRICE";
            public static string ADJRETAILFEE = "ADJRETAILFEE";
            public static string DEPTID = "DEPTID";
            public static string BILLNUM = "BILLNUM";
            public static string AUDIT_FLAG = "AUDIT_FLAG";
            public static string ADJNUM = "ADJNUM";
        }
        public static string YP_BILLNUMDIC = "YP_BILLNUMDIC";
        public struct yp_billnumdic
        {
            public static string BILLNUMDICID = "BILLNUMDICID";
            public static string OPTYPE = "OPTYPE";
            public static string BILLNUM = "BILLNUM";
            public static string DEPTID = "DEPTID";
        }
        public static string YP_BYNAMEDIC = "YP_BYNAMEDIC";
        public struct yp_bynamedic
        {
            public static string BYNAMEDICID = "BYNAMEDICID";
            public static string SPECDICID = "SPECDICID";
            public static string BYNAME = "BYNAME";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
        }
        public static string YP_PHARMACOLOGY = "YP_PHARMACOLOGY";
        public struct yp_pharmacology
        {
            public static string ID = "ID";
            public static string FID = "FID";
            public static string NAME = "NAME";
            public static string DEL_FLAG = "DEL_FLAG";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
        }
        public static string YP_DEPT_YPTYPE = "YP_DEPT_YPTYPE";
        public struct yp_dept_yptype
        {
            public static string ID = "ID";
            public static string DEPTDICID = "DEPTDICID";
            public static string DEPTID = "DEPTID";
            public static string TYPEDICID = "TYPEDICID";
        }
        public static string YP_DEPTDIC = "YP_DEPTDIC";
        public struct yp_deptdic
        {
            public static string DEPTDICID = "DEPTDICID";
            public static string DEPTNAME = "DEPTNAME";
            public static string DEPTTYPE1 = "DEPTTYPE1";
            public static string DEPTTYPE2 = "DEPTTYPE2";
            public static string USE_FLAG = "USE_FLAG";
            public static string DEPTID = "DEPTID";
        }
        public static string YP_DISPDEPTHIS = "YP_DISPDEPTHIS";
        public struct yp_dispdepthis
        {
            public static string ID = "ID";
            public static string DISPDEPT = "DISPDEPT";
            public static string TOTALFEE = "TOTALFEE";
            public static string DEPTID = "DEPTID";
            public static string OPTIME = "OPTIME";
            public static string OPMAN = "OPMAN";
        }
        public static string YP_DOSEDIC = "YP_DOSEDIC";
        public struct yp_dosedic
        {
            public static string DOSEDICID = "DOSEDICID";
            public static string TYPEDICID = "TYPEDICID";
            public static string DOSENAME = "DOSENAME";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
        }
        public static string YP_MAKERDIC = "YP_MAKERDIC";
        public struct yp_makerdic
        {
            public static string MAKERDICID = "MAKERDICID";
            public static string SPECDICID = "SPECDICID";
            public static string BALENUM = "BALENUM";
            public static string BARCODE = "BARCODE";
            public static string PRODUCTID = "PRODUCTID";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string HRETAILPRICE = "HRETAILPRICE";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string APPROVENUM = "APPROVENUM";
            public static string VALIDITYDATE = "VALIDITYDATE";
            public static string MEDICAREDICID = "MEDICAREDICID";
            public static string OWNPAYSCALE = "OWNPAYSCALE";
            public static string DEFRECSCALE = "DEFRECSCALE";
            public static string DEFSTOCKPRICE = "DEFSTOCKPRICE";
            public static string DEL_FLAG = "DEL_FLAG";
            public static string OWNPAY_FLAG = "OWNPAY_FLAG";
            public static string VIRULENT_FLAG = "VIRULENT_FLAG";
            public static string NARCOTIC_FLAG = "NARCOTIC_FLAG";
            public static string SKINTEST_FLAG = "SKINTEST_FLAG";
            public static string RECIPE_FLAG = "RECIPE_FLAG";
            public static string LUNACY_FLAG = "LUNACY_FLAG";
            public static string COSTLY_FLAG = "COSTLY_FLAG";
            public static string BIGTRANSFU_FLAG = "BIGTRANSFU_FLAG";
            public static string GMP_FLAG = "GMP_FLAG";
            public static string MEDICARE_FLAG = "MEDICARE_FLAG";
            public static string USEOUT_FLAG = "USEOUT_FLAG";
            public static string REMARK = "REMARK";
            public static string REGTIME = "REGTIME";
            public static string GETWAY = "GETWAY";
            public static string UNIFGETTYPE = "UNIFGETTYPE";
            public static string MEDI_INVERSE = "MEDI_INVERSE";

        }
        public static string YP_MEDICAREDIC = "YP_MEDICAREDIC";
        public struct yp_medicaredic
        {
            public static string MEDICAREDICID = "MEDICAREDICID";
            public static string MEDICARENAME = "MEDICARENAME";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
            public static string MEDICAREREMARK = "MEDICAREREMARK";
        }
        public static string YP_PRODUCTDIC = "YP_PRODUCTDIC";
        public struct yp_productdic
        {
            public static string PRODUCTID = "PRODUCTID";
            public static string PRODUCTNAME = "PRODUCTNAME";
            public static string PYM = "PYM";
            public static string WMB = "WMB";
            public static string LINKPHONE = "LINKPHONE";
            public static string LINKNAME = "LINKNAME";
            public static string ADDRESS = "ADDRESS";
            public static string DEL_FLAG = "DEL_FLAG";
        }
        public static string YP_SPECDIC = "YP_SPECDIC";
        public struct yp_specdic
        {
            public static string SPECDICID = "SPECDICID";
            public static string TYPEDICID = "TYPEDICID";
            public static string CTYPEDICID = "CTYPEDICID";
            public static string GBCODE = "GBCODE";
            public static string CHEMNAME = "CHEMNAME";
            public static string NAME = "NAME";
            public static string NAMEREMARK = "NAMEREMARK";
            public static string UNIT = "UNIT";
            public static string PHARMACOLOGY = "PHARMACOLOGY";
            public static string DOSEDICID = "DOSEDICID";
            public static string DOSENUM = "DOSENUM";
            public static string DOSEUNIT = "DOSEUNIT";
            public static string PACKNUM = "PACKNUM";
            public static string PACKUNIT = "PACKUNIT";
            public static string USENUM = "USENUM";
            public static string SPEC = "SPEC";
            public static string CUREDISEASE = "CUREDISEASE";
            public static string REMARK = "REMARK";
            public static string DEL_FLAG = "DEL_FLAG";
            public static string USEWAY = "USEWAY";
            public static string REGTIME = "REGTIME";
            public static string RECIPELVL = "RECIPELVL";
            public static string LATINNAME = "LATINNAME";
        }
        public static string YP_SUPPORTDIC = "YP_SUPPORTDIC";
        public struct yp_supportdic
        {
            public static string SUPPORTDICID = "SUPPORTDICID";
            public static string NAME = "NAME";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
            public static string PHONE = "PHONE";
            public static string LINKMAN = "LINKMAN";
            public static string ADDRESS = "ADDRESS";
            public static string DEL_FLAG = "DEL_FLAG";
        }
        public static string YP_TYPEDIC = "YP_TYPEDIC";
        public struct yp_typedic
        {
            public static string TYPEDICID = "TYPEDICID";
            public static string TYPENAME = "TYPENAME";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
        }
        public static string YP_UNITDIC = "YP_UNITDIC";
        public struct yp_unitdic
        {
            public static string UNITDICID = "UNITDICID";
            public static string UNITNAME = "UNITNAME";
            public static string PYM = "PYM";
            public static string WBM = "WBM";
        }
        public static string ZY_BADTICKET = "ZY_BADTICKET";
        public struct zy_badticket
        {
            public static string TICKETNO = "TICKETNO";
            public static string EMPCODE = "EMPCODE";
            public static string BADDATE = "BADDATE";
            public static string ACCOUNTID = "ACCOUNTID";
        }
        public static string ZY_ACCOUNT = "ZY_ACCOUNT";
        public struct zy_account
        {
            public static string ACCOUNTID = "ACCOUNTID";
            public static string ACCOUNTTYPE = "ACCOUNTTYPE";
            public static string LASTDATE = "LASTDATE";
            public static string WTICKETFEE = "WTICKETFEE";
            public static string BTICKETFEE = "BTICKETFEE";
            public static string WTICKETNUM = "WTICKETNUM";
            public static string BTICKETNUM = "BTICKETNUM";
            public static string TOTAL_FEE = "TOTAL_FEE";
            public static string CASH_FEE = "CASH_FEE";
            public static string POS_FEE = "POS_FEE";
            public static string ACCOUNTCODE = "ACCOUNTCODE";
            public static string ACCOUNTDATE = "ACCOUNTDATE";
            public static string COSTFEE = "COSTFEE";
            public static string FAOVERFEE = "FAOVERFEE";
            public static string PRINTNUM = "PRINTNUM";
        }
        public static string ZY_CHARGELIST = "ZY_CHARGELIST";
        public struct zy_chargelist
        {
            public static string CHARGELISTID = "CHARGELISTID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string CURENO = "CURENO";
            public static string BILLNO = "BILLNO";
            public static string OLDBILLNO = "OLDBILLNO";
            public static string FEETYPE = "FEETYPE";
            public static string TOTAL_FEE = "TOTAL_FEE";
            public static string CHARGECODE = "CHARGECODE";
            public static string COSTDATE = "COSTDATE";
            public static string DELETE_FLAG = "DELETE_FLAG";
            public static string ACCOUNTID = "ACCOUNTID";
            public static string RECORD_FLAG = "RECORD_FLAG";
        }
        public static string ZY_COSTMASTER = "ZY_COSTMASTER";
        public struct zy_costmaster
        {
            public static string COSTMASTERID = "COSTMASTERID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string NTYPE = "NTYPE";
            public static string DISCHARGE_DATE = "DISCHARGE_DATE";
            public static string DISCHARGE_BDATE = "DISCHARGE_BDATE";
            public static string DISCHARGE_EDATE = "DISCHARGE_EDATE";
            public static string TICKETNUM = "TICKETNUM";
            public static string TICKETCODE = "TICKETCODE";
            public static string CHARGECODE = "CHARGECODE";
            public static string TOTAL_FEE = "TOTAL_FEE";
            public static string DEPTOSIT_FEE = "DEPTOSIT_FEE";
            public static string SELF_FEE = "SELF_FEE";
            public static string VILLAGE_FEE = "VILLAGE_FEE";
            public static string FAVOR_FEE = "FAVOR_FEE";
            public static string REALITY_FEE = "REALITY_FEE";
            public static string POS_FEE = "POS_FEE";
            public static string MONEY_FEE = "MONEY_FEE";
            public static string TICKET_FLAG = "TICKET_FLAG";
            public static string COSTDATE = "COSTDATE";
            public static string DELETE_FLAG = "DELETE_FLAG";
            public static string ACCOUNTID = "ACCOUNTID";
            public static string RECORD_FLAG = "RECORD_FLAG";
            public static string OLDID = "OLDID";
            public static string NCCM_NO = "NCCM_NO";
            public static string VILLAGE_TYPE = "VILLAGE_TYPE";
            public static string PATTYPE = "PATTYPE";
            public static string WORKUNIT = "WORKUNIT";
            public static string WORKUNIT_FEE = "WORKUNIT_FEE";
            public static string NOTWORKUNIT_FEE = "NOTWORKUNIT_FEE";
            public static string RATION_FEE = "RATION_FEE";
            public static string MORERATION_FEE = "MORERATION_FEE";

        }
        public static string ZY_COSTORDER = "ZY_COSTORDER";
        public struct zy_costorder
        {
            public static string COSTORDERID = "COSTORDERID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string COSTID = "COSTID";
            public static string TICKETNUM = "TICKETNUM";
            public static string TICKETCODE = "TICKETCODE";
            public static string BIGITEMCODE = "BIGITEMCODE";
            public static string TOTAL_FEE = "TOTAL_FEE";
        }
        public static string ZY_INVOICE = "ZY_INVOICE";
        public struct zy_invoice
        {
            public static string ID = "ID";
            public static string INVOICE_TYPE = "INVOICE_TYPE";
            public static string EMPLOYEE_ID = "EMPLOYEE_ID";
            public static string START_NO = "START_NO";
            public static string END_NO = "END_NO";
            public static string CURRENT_NO = "CURRENT_NO";
            public static string STATUS = "STATUS";
            public static string ALLOT_DATE = "ALLOT_DATE";
            public static string ALLOT_USER = "ALLOT_USER";
            public static string PERFCHAR = "PERFCHAR";
        }
        public static string ZY_PATIENTNO = "ZY_PATIENTNO";
        public struct zy_patientno
        {
            public static string PATNO = "PATNO";
            public static string BILLNO = "BILLNO";
            public static string TODAYDATE = "TODAYDATE";
            public static string TICKETNO = "TICKETNO";
            public static string NCCM_NO = "NCCM_NO";
        }
        public static string ZY_PATLIST = "ZY_PATLIST";
        public struct zy_patlist
        {
            public static string PATLISTID = "PATLISTID";
            public static string CURENO = "CURENO";
            public static string PATID = "PATID";
            public static string PATIENTCODE = "PATIENTCODE";
            public static string CUREDEPTCODE = "CUREDEPTCODE";
            public static string CUREDOCCODE = "CUREDOCCODE";
            public static string ORIGINDEPTCODE = "ORIGINDEPTCODE";
            public static string ORIGINDOCCODE = "ORIGINDOCCODE";
            public static string PATTYPE = "PATTYPE";
            public static string DISEASECODE = "DISEASECODE";
            public static string DISEASENAME = "DISEASENAME";
            public static string CUREDATE = "CUREDATE";
            public static string CURRDEPTCODE = "CURRDEPTCODE";
            public static string BEDCODE = "BEDCODE";
            public static string CURESTATE = "CURESTATE";
            public static string OUT_FLAG = "OUT_FLAG";
            public static string OUTDIAGNCODE = "OUTDIAGNCODE";
            public static string OUTDIAGNNAME = "OUTDIAGNNAME";
            public static string OUTDATE = "OUTDATE";
            public static string REALIVENUM = "REALIVENUM";
            public static string MARKDATE = "MARKDATE";
            public static string MARKEMPCODE = "MARKEMPCODE";
            public static string NCCM_NO = "NCCM_NO";
        }
        public static string ZY_PRESMASTER = "ZY_PRESMASTER";
        public struct zy_presmaster
        {
            public static string PRESMASTERID = "PRESMASTERID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string PRESTYPE = "PRESTYPE";
            public static string TOTAL_FEE = "TOTAL_FEE";
            public static string PRES_FLAG = "PRES_FLAG";
            public static string PRESDATE = "PRESDATE";
            public static string DEL_FLAG = "DEL_FLAG";
        }
        public static string ZY_PRESORDER = "ZY_PRESORDER";
        public struct zy_presorder
        {
            public static string PRESORDERID = "PRESORDERID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string PRESMASTERID = "PRESMASTERID";
            public static string ITEMID = "ITEMID";
            public static string ITEMTYPE = "ITEMTYPE";
            public static string PRESTYPE = "PRESTYPE";
            public static string ITEMNAME = "ITEMNAME";
            public static string STANDARD = "STANDARD";
            public static string UNIT = "UNIT";
            public static string RELATIONNUM = "RELATIONNUM";
            public static string BUY_PRICE = "BUY_PRICE";
            public static string SELL_PRICE = "SELL_PRICE";
            public static string AMOUNT = "AMOUNT";
            public static string PRESAMOUNT = "PRESAMOUNT";
            public static string TOLAL_FEE = "TOLAL_FEE";
            public static string PRESDEPTCODE = "PRESDEPTCODE";
            public static string PRESDOCCODE = "PRESDOCCODE";
            public static string EXECDEPTCODE = "EXECDEPTCODE";
            public static string CHARGECODE = "CHARGECODE";
            public static string PRESDATE = "PRESDATE";
            public static string MARKDATE = "MARKDATE";
            public static string COSTDATE = "COSTDATE";
            public static string ORDER_FLAG = "ORDER_FLAG";
            public static string CHARGE_FLAG = "CHARGE_FLAG";
            public static string DRUG_FLAG = "DRUG_FLAG";
            public static string DELETE_FLAG = "DELETE_FLAG";
            public static string OLDID = "OLDID";
            public static string RECORD_FLAG = "RECORD_FLAG";
            public static string COSTMASTERID = "COSTMASTERID";
            public static string COST_FLAG = "COST_FLAG";
            public static string PASSID = "PASSID";
            public static string PACKUNIT = "PACKUNIT";
            public static string COMP_MONEY = "COMP_MONEY";
            public static string ORDER_ID = "ORDER_ID";
            public static string GROUP_ID = "GROUP_ID";
            public static string ORDER_TYPE = "ORDER_TYPE";
        }
        public static string ZY_DRUGMESSAGE_MASTER = "ZY_DRUGMESSAGE_MASTER";
        public struct zy_drugmessage_master
        {
            public static string DRUGMESSAGEID = "DRUGMESSAGEID";
            public static string SENDTIME = "SENDTIME";
            public static string DISPDEPT = "DISPDEPT";
            public static string DR_FLAG = "DR_FLAG";
            public static string MESSAGETYPE = "MESSAGETYPE";
            public static string SENDER = "SENDER";
            public static string SENDERNAME = "SENDERNAME";
            public static string PRESDEPTID = "PRESDEPTID";
        }
        public static string ZY_DRUGMESSAGE_ORDER = "ZY_DRUGMESSAGE_ORDER";
        public struct zy_drugmessage_order
        {
            public static string DRUGMESSAGEID = "DRUGMESSAGEID";
            public static string MASTERID = "MASTERID";
            public static string MAKERDICID = "MAKERDICID";
            public static string CHEMNAME = "CHEMNAME";
            public static string SPEC = "SPEC";
            public static string BEDNO = "BEDNO";
            public static string CURENO = "CURENO";
            public static string PATNAME = "PATNAME";
            public static string CUREDEPT = "CUREDEPT";
            public static string CUREDOC = "CUREDOC";
            public static string PATID = "PATID";
            public static string RECIPENUM = "RECIPENUM";
            public static string DRUGNUM = "DRUGNUM";
            public static string UNIT = "UNIT";
            public static string UNITNAME = "UNITNAME";
            public static string UNITNUM = "UNITNUM";
            public static string DOSENAME = "DOSENAME";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string RETAILFEE = "RETAILFEE";
            public static string TRADEFEE = "TRADEFEE";
            public static string RECIPEMASTERID = "RECIPEMASTERID";
            public static string ORDERRECIPEID = "ORDERRECIPEID";
            public static string CHARGEMAN = "CHARGEMAN";
            public static string CHARGEDATE = "CHARGEDATE";
            public static string REFUNDFLAG = "REFUNDFLAG";
            public static string UNIFORM_FLAG = "UNIFORM_FLAG";
            public static string CHARGECODE = "CHARGECODE";
            public static string ORDERGROUP_ID = "ORDERGROUP_ID";
            public static string DOCORDERTYPE = "DOCORDERTYPE";
            public static string DOCORDERID = "DOCORDERID";
            public static string DISP_FLAG = "DISP_FLAG";
            public static string SPECDICID = "SPECDICID";
            public static string PRODUCTNAME = "PRODUCTNAME";
            public static string NODRUG_FLAG = "NODRUG_FLAG";
        }
        public static string MEDICAL_CONFIR = "MEDICAL_CONFIR";
        public struct medical_confir
        {
            public static string CONFIRID = "CONFIRID";
            public static string PRESORDERID = "PRESORDERID";
            public static string PATLISTID = "PATLISTID";
            public static string CONFIRDOC = "CONFIRDOC";
            public static string CONFIRDATE = "CONFIRDATE";
            public static string CONFIRDEPT = "CONFIRDEPT";
            public static string MARK_FLAG = "MARK_FLAG";
            public static string CANCELDOC = "CANCELDOC";
            public static string CANCELDATE = "CANCELDATE";
            public static string CANCEL_FLAG = "CANCEL_FLAG";

        }

        public static string BASE_ENUME = "BASE_ENUME";
        public struct base_enume
        {
            public static string ID = "ID";
            public static string ENUMNAME = "ENUMNAME";
            public static string REMARK = "REMARK";
        }
        public static string BASE_ENUMEORDER = "BASE_ENUMEORDER";
        public struct base_enumeorder
        {
            public static string ID = "ID";
            public static string NAME = "NAME";
            public static string ENUMVALUE = "ENUMVALUE";
            public static string ENUMEID = "ENUMEID";
        }
        public static string BASE_GROUP_REPORT = "BASE_GROUP_REPORT";
        public struct base_group_report
        {
            public static string ID = "ID";
            public static string REPORT_ID = "REPORT_ID";
            public static string GROUP_ID = "GROUP_ID";
            public static string HIS_WORKID = "HIS_WORKID";
            public static string ISGLOBAL = "ISGLOBAL";
        }
        public static string BASE_REPORTMASTER = "BASE_REPORTMASTER";
        public struct base_reportmaster
        {
            public static string REPORTMASTER_ID = "REPORTMASTER_ID";
            public static string P_ID = "P_ID";
            public static string NAME = "NAME";
            public static string DEIETE_FLAG = "DEIETE_FLAG";
            public static string REPORT_TYPE = "REPORT_TYPE";
        }
        public static string BASE_REPORT = "BASE_REPORT";
        public struct base_report
        {
            public static string REPORT_ID = "REPORT_ID";
            public static string REPORTMASTER_ID = "REPORTMASTER_ID";
            public static string NAME = "NAME";
            public static string PROCEDURES = "PROCEDURES";
            public static string REMARK = "REMARK";
            public static string DELETE_FLAG = "DELETE_FLAG";
        }
        public static string BASE_REPORT_PARAMETER = "BASE_REPORT_PARAMETER";
        public struct base_report_parameter
        {
            public static string REPORT_ID = "REPORT_ID";
            public static string PARAMETER_CN = "PARAMETER_CN";
            public static string PARAMETER = "PARAMETER";
            public static string DATALENGTH = "DATALENGTH";
            public static string PARAMDATATYPE = "PARAMDATATYPE";
            public static string PARAMETER_TYPE = "PARAMETER_TYPE";
            public static string UIC_TYPE = "UIC_TYPE";
            public static string UIC_X_LOCA = "UIC_X_LOCA";
            public static string UIC_Y_LOCA = "UIC_Y_LOCA";
            public static string FOREIGNER_TABLE = "FOREIGNER_TABLE";
            public static string WIDTH = "WIDTH";
            public static string HEIGHT = "HEIGHT";
            public static string FOREIGNER_FIELD_DB_NAME = "FOREIGNER_FIELD_DB_NAME";
            public static string FOREIGNER_FIELD_CN_NAME = "FOREIGNER_FIELD_CN_NAME";
            public static string PARAMETERID = "PARAMETERID";
            public static string FOREIGNER_FILTER_SQL = "FOREIGNER_FILTER_SQL";
            public static string ENUMEID = "ENUMEID";
        }
    }
    public struct Views
    {
        #region 临床部分视图
        public static string VI_USEAGE_FEE = "VI_USEAGE_FEE";
        public struct vi_useage_fee
        {
            public static string ID = "ID";
            public static string USE_NAME = "USE_NAME";
            public static string NUM = "NUM";
            public static string HSITEM_ID = "HSITEM_ID";
            public static string ITEM_ID = "ITEM_ID";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string PRICE = "PRICE";
            public static string ITEM_UNIT = "ITEM_UNIT";
        }
        public static string VI_CLINICAL_ALL_ITEMS = "VI_CLINICAL_ALL_ITEMS";
        public struct vi_clinical_all_items
        {
            public static string ITEMID = "ITEMID";
            public static string ITEMNAME = "ITEMNAME";
            public static string ORDER_TYPE = "ORDER_TYPE";
            public static string STATITEM_CODE = "STATITEM_CODE";
            public static string STANDARD = "STANDARD";
            public static string PACKUNIT = "PACKUNIT";
            public static string LEASTUNIT = "LEASTUNIT";
            public static string UNPICKUNIT = "UNPICKUNIT";
            public static string UNPICKNUM = "UNPICKNUM";
            public static string PACKNUM = "PACKNUM";
            public static string DOSEUNIT = "DOSEUNIT";
            public static string DOSENUM = "DOSENUM";
            public static string NCMS_COMP_RATE = "NCMS_COMP_RATE";
            public static string INSUR_TYPE = "INSUR_TYPE";
            public static string BUY_PRICE = "BUY_PRICE";
            public static string SELL_PRICE = "SELL_PRICE";
            public static string ADDRESS = "ADDRESS";
            public static string STORENUM = "STORENUM";
            public static string EXECDEPTCODE = "EXECDEPTCODE";
            public static string EXECDEPTNAME = "EXECDEPTNAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string D_CODE = "D_CODE";
            public static string SERVER_ITEM_ID = "SERVER_ITEM_ID";
            public static string TC_FLAG = "TC_FLAG";
            public static string UNPICK_FLAG = "UNPICK_FLAG";
            public static string FLOAT_FLAG = "FLOAT_FLAG";
            public static string VIRULENT_FLAG = "VIRULENT_FLAG";
            public static string NARCOTIC_FLAG = "NARCOTIC_FLAG";
            public static string SKINTEST_FLAG = "SKINTEST_FLAG";
            public static string LUNACY_FLAG = "LUNACY_FLAG";
            public static string COSTLY_FLAG = "COSTLY_FLAG";
            public static string PRINTNAME = "PRINTNAME";
            public static string DRUG_FLAG = "DRUG_FLAG";
        }
        public static string VI_CLINICAL_ORDER = "VI_CLINICAL_ORDER";
        public struct vi_clinical_order
        {
            public static string ORDER_ID = "ORDER_ID";
            public static string ORDER_NAME = "ORDER_NAME";
            public static string ORDER_UNIT = "ORDER_UNIT";
            public static string ORDER_TYPE = "ORDER_TYPE";
            public static string MEDICAL_CLASS = "MEDICAL_CLASS";
            public static string DEPT_ID = "DEPT_ID";
            public static string DEPT_NAME = "DEPT_NAME";
            public static string STATITEM_CODE = "STATITEM_CODE";
            public static string PRICE = "PRICE";
            public static string NCMS_COMP_RATE = "NCMS_COMP_RATE";
            public static string INSUR_TYPE = "INSUR_TYPE";
            public static string DEFAULT_USAGE = "DEFAULT_USAGE";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string D_CODE = "D_CODE";
            public static string CLASS_TYPE = "CLASS_TYPE";
            public static string MEDICAL_CLASS_NAME = "MEDICAL_CLASS_NAME";
            public static string ITEM_ID = "ITEM_ID";
            public static string TC_FLAG = "TC_FLAG";
            public static string BZ = "BZ";
        }
        public static string VI_MZ_MEDICAL_APPLY = "VI_MZ_MEDICAL_APPLY";
        public struct vi_mz_medical_apply
        {
            public static string APPLYID = "APPLYID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string PRESLISTID = "PRESLISTID";
            public static string ITEM_ID = "ITEM_ID";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string APPLY_TYPE = "APPLY_TYPE";
            public static string MEDICAL_CLASS = "MEDICAL_CLASS";
            public static string APPLY_CONTENT = "APPLY_CONTENT";
            public static string APPLY_DOC = "APPLY_DOC";
            public static string APPLY_DEPT = "APPLY_DEPT";
            public static string APPLY_DATE = "APPLY_DATE";
            public static string APPLY_STATUS = "APPLY_STATUS";
            public static string MEMO = "MEMO";
            public static string STATUS = "STATUS";
            public static string DEPT_ID = "DEPT_ID";
            public static string DEPT_NAME = "DEPT_NAME";
            public static string PRICE = "PRICE";
            public static string NUM = "NUM";
        }
        public static string VI_ZY_NURSE_BEDSHO = "VI_ZY_NURSE_BEDSHO";
        public struct vi_zy_nurse_bedsho
        {
            public static string DEPT_ID = "DEPT_ID";
            public static string BED_NO = "BED_NO";
            public static string PATID = "PATID";
            public static string PATNAME = "PATNAME";
            public static string PATSEX = "PATSEX";
            public static string ACCOUNTTYPE = "ACCOUNTTYPE";
        }
        #endregion
        public static string ITEM_YP = "ITEM_YP";
        public struct item_yp
        {
        }
        public static string VI_DRUG_DIC = "VI_DRUG_DIC";
        public struct vi_drug_dic
        {
            public static string BYNAME = "BYNAME";
            public static string WB_CODE = "WB_CODE";
            public static string PY_CODE = "PY_CODE";
            public static string NAME = "NAME";
            public static string SPECDICID = "SPECDICID";
            public static string MAKERDICID = "MAKERDICID";
            public static string TYPEDICID = "TYPEDICID";
            public static string SPEC = "SPEC";
            public static string UNITNAME = "UNITNAME";
            public static string DOSEDICID = "DOSEDICID";
            public static string PACKUNIT = "PACKUNIT";
            public static string PACKNUM = "PACKNUM";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string PRODUCTNAME = "PRODUCTNAME";
            public static string CURRENTNUM = "CURRENTNUM";
            public static string DEFSTOCKPRICE = "DEFSTOCKPRICE";
        }
        public static string VI_DRUG_YF = "VI_DRUG_YF";
        public struct vi_drug_yf
        {
            public static string BYNAME = "BYNAME";
            public static string WB_CODE = "WB_CODE";
            public static string PY_CODE = "PY_CODE";
            public static string NAME = "NAME";
            public static string SPECDICID = "SPECDICID";
            public static string MAKERDICID = "MAKERDICID";
            public static string TYPEDICID = "TYPEDICID";
            public static string SPEC = "SPEC";
            public static string UNITNAME = "UNITNAME";
            public static string DOSEDICID = "DOSEDICID";
            public static string PACKUNIT = "PACKUNIT";
            public static string UNIT = "UNIT";
            public static string PACKNUM = "PACKNUM";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string PRODUCTNAME = "PRODUCTNAME";
            public static string CURRENTNUM = "CURRENTNUM";
            public static string DEPTID = "DEPTID";
            public static string LUNITNAME = "LUNITNAME";
        }
        public static string VI_DRUG_YK = "VI_DRUG_YK";
        public struct vi_drug_yk
        {
            public static string BYNAME = "BYNAME";
            public static string WB_CODE = "WB_CODE";
            public static string PY_CODE = "PY_CODE";
            public static string NAME = "NAME";
            public static string SPECDICID = "SPECDICID";
            public static string MAKERDICID = "MAKERDICID";
            public static string TYPEDICID = "TYPEDICID";
            public static string SPEC = "SPEC";
            public static string UNITNAME = "UNITNAME";
            public static string DOSEDICID = "DOSEDICID";
            public static string PACKUNIT = "PACKUNIT";
            public static string PACKNUM = "PACKNUM";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string PRODUCTNAME = "PRODUCTNAME";
            public static string CURRENTNUM = "CURRENTNUM";
            public static string DEPTID = "DEPTID";
        }
        public static string VI_ITEM_DRUG = "VI_ITEM_DRUG";
        public struct vi_item_drug
        {
            public static string WB_CODE = "WB_CODE";
            public static string PY_CODE = "PY_CODE";
            public static string D_CODE = "D_CODE";
            public static string BYNAME = "BYNAME";
            public static string SPECDICID = "SPECDICID";
            public static string ITEMID = "ITEMID";
            public static string PRESTYPE = "PRESTYPE";
            public static string ITEMNAME = "ITEMNAME";
            public static string ITEMTYPE = "ITEMTYPE";
            public static string STANDARD = "STANDARD";
            public static string PACKUNIT = "PACKUNIT";
            public static string UNIT = "UNIT";
            public static string RELATIONNUM = "RELATIONNUM";
            public static string BUY_PRICE = "BUY_PRICE";
            public static string SELL_PRICE = "SELL_PRICE";
            public static string ADDRESS = "ADDRESS";
            public static string STORENUM = "STORENUM";
            public static string EXECDEPTCODE = "EXECDEPTCODE";
            public static string EXECDEPTNAME = "EXECDEPTNAME";
        }
        public static string VI_ITEM_PROJECT = "VI_ITEM_PROJECT";
        public struct vi_item_project
        {
            public static string WB_CODE = "WB_CODE";
            public static string PY_CODE = "PY_CODE";
            public static string D_CODE = "D_CODE";
            public static string EXECDEPTNAME = "EXECDEPTNAME";
            public static string BYNAME = "BYNAME";
            public static string EXECDEPTCODE = "EXECDEPTCODE";
            public static string SPECDICID = "SPECDICID";
            public static string ITEMID = "ITEMID";
            public static string PRESTYPE = "PRESTYPE";
            public static string ITEMNAME = "ITEMNAME";
            public static string ITEMTYPE = "ITEMTYPE";
            public static string STANDARD = "STANDARD";
            public static string PACKUNIT = "PACKUNIT";
            public static string UNIT = "UNIT";
            public static string RELATIONNUM = "RELATIONNUM";
            public static string BUY_PRICE = "BUY_PRICE";
            public static string SELL_PRICE = "SELL_PRICE";
            public static string ADDRESS = "ADDRESS";
            public static string COMPLEX_ID = "COMPLEX_ID";
            public static string ISDRUG = "ISDRUG";
        }
        public static string VI_MZ_SHOWCARD = "VI_MZ_SHOWCARD";
        public struct vi_mz_showcard
        {
            public static string ITEM_ID = "ITEM_ID";
            public static string CODE = "CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string STANDARD = "STANDARD";
            public static string ITEM_UNIT = "ITEM_UNIT";
            public static string BASE_UNIT = "BASE_UNIT";
            public static string PRICE = "PRICE";
            public static string COMPLEX_ID = "COMPLEX_ID";
            public static string ADDRESS = "ADDRESS";
            public static string ISDRUG = "ISDRUG";
            public static string STATITEM_CODE = "STATITEM_CODE";
            public static string HJXS = "HJXS";
            public static string EXEC_DEPT_NAME = "EXEC_DEPT_NAME";
            public static string EXEC_DEPT_CODE = "EXEC_DEPT_CODE";
            public static string AMOUNT = "AMOUNT";
            public static string COMP_RATE = "COMP_RATE";
            public static string CHEM_NAME = "CHEM_NAME";
        }
        public static string VI_BASE_HOSPITAL_ITEMS = "VI_BASE_HOSPITAL_ITEMS";
        public struct vi_base_hospital_items
        {
            public static string ITEM_ID = "ITEM_ID";
            public static string STD_CODE = "STD_CODE";
            public static string ITEM_NAME = "ITEM_NAME";
            public static string PY_CODE = "PY_CODE";
            public static string WB_CODE = "WB_CODE";
            public static string ITEM_UNIT = "ITEM_UNIT";
            public static string PRICE = "PRICE";
            public static string COMPLEX_ID = "COMPLEX_ID";
            public static string STATITEM_CODE = "STATITEM_CODE";
            public static string NCMS_COMP_RATE = "NCMS_COMP_RATE";
            public static string INSUR_TYPE = "INSUR_TYPE";
            public static string VALID_FLAG = "VALID_FLAG";
        }

        public static string VI_YK_CHECKDRUG = "VI_YK_CHECKDRUG";
        public struct vi_yk_checkdrug
        {
            public static string BYNAME = "BYNAME";
            public static string WB_CODE = "WB_CODE";
            public static string PY_CODE = "PY_CODE";
            public static string NAME = "NAME";
            public static string SPECDICID = "SPECDICID";
            public static string CHEMNAME = "CHEMNAME";
            public static string MAKERDICID = "MAKERDICID";
            public static string TYPEDICID = "TYPEDICID";
            public static string SPEC = "SPEC";
            public static string UNITNAME = "UNITNAME";
            public static string DOSEDICID = "DOSEDICID";
            public static string PACKUNIT = "PACKUNIT";
            public static string PACKNUM = "PACKNUM";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string PRODUCTNAME = "PRODUCTNAME";
            public static string DEPTID = "DEPTID";
            public static string TYPENAME = "TYPENAME";
            public static string DOSENAME = "DOSENAME";
            public static string BATCHNUM = "BATCHNUM";
            public static string CURRENTNUM = "CURRENTNUM";
            public static string VALIDITYDATE = "VALIDITYDATE";
            public static string ID = "ID";
        }
        public static string VI_YF_CHECKDRUG = "VI_YF_CHECKDRUG";
        public struct vi_yf_checkdrug
        {
            public static string BYNAME = "BYNAME";
            public static string WB_CODE = "WB_CODE";
            public static string PY_CODE = "PY_CODE";
            public static string NAME = "NAME";
            public static string SPECDICID = "SPECDICID";
            public static string CHEMNAME = "CHEMNAME";
            public static string MAKERDICID = "MAKERDICID";
            public static string TYPEDICID = "TYPEDICID";
            public static string SPEC = "SPEC";
            public static string UNITNAME = "UNITNAME";
            public static string DOSEDICID = "DOSEDICID";
            public static string PACKUNIT = "PACKUNIT";
            public static string UNIT = "UNIT";
            public static string PACKNUM = "PACKNUM";
            public static string TRADEPRICE = "TRADEPRICE";
            public static string RETAILPRICE = "RETAILPRICE";
            public static string PRODUCTNAME = "PRODUCTNAME";
            public static string CURRENTNUM = "CURRENTNUM";
            public static string DEPTID = "DEPTID";
            public static string LUNITNAME = "LUNITNAME";
            public static string DOSENAME = "DOSENAME";
            public static string TYPENAME = "TYPENAME";
            public static string STORAGEID = "STORAGEID";
        }
        public static string VI_ZY_SENDDRUG = "VI_ZY_SENDDRUG";
        public struct vi_zy_senddrug
        {
            public static string PRESORDERID = "PRESORDERID";
            public static string PATID = "PATID";
            public static string PATLISTID = "PATLISTID";
            public static string PRESMASTERID = "PRESMASTERID";
            public static string ISDISPENSE = "ISDISPENSE";
            public static string CURENO = "CURENO";
            public static string SPECDICID = "SPECDICID";
            public static string DOSEDICID = "DOSEDICID";
            public static string PRODUCTNAME = "PRODUCTNAME";
            public static string UNITID = "UNITID";
            public static string UNIT = "UNIT";
            public static string ITEMID = "ITEMID";
            public static string ITEMTYPE = "ITEMTYPE";
            public static string PRESTYPE = "PRESTYPE";
            public static string ITEMNAME = "ITEMNAME";
            public static string STANDARD = "STANDARD";
            public static string RELATIONNUM = "RELATIONNUM";
            public static string BUY_PRICE = "BUY_PRICE";
            public static string SELL_PRICE = "SELL_PRICE";
            public static string AMOUNT = "AMOUNT";
            public static string TOLAL_FEE = "TOLAL_FEE";
            public static string PRESAMOUNT = "PRESAMOUNT";
            public static string PRESDEPTCODE = "PRESDEPTCODE";
            public static string PRESDEPTNAME = "PRESDEPTNAME";
            public static string PRESDOCCODE = "PRESDOCCODE";
            public static string PRESDOCNAME = "PRESDOCNAME";
            public static string EXECDEPTCODE = "EXECDEPTCODE";
            public static string CHARGECODE = "CHARGECODE";
            public static string PRESDATE = "PRESDATE";
            public static string MARKDATE = "MARKDATE";
            public static string COSTDATE = "COSTDATE";
        }

        public static string VI_ITEM_ZY_DRUG = "VI_ITEM_ZY_DRUG";
        public struct vi_item_zy_drug
        {
            public static string SPECDICID = "SPECDICID";
            public static string ITEMID = "ITEMID";
            public static string PRESTYPE = "PRESTYPE";
            public static string ITEMNAME = "ITEMNAME";
            public static string ITEMTYPE = "ITEMTYPE";
            public static string STANDARD = "STANDARD";
            public static string RELATIONNUM = "RELATIONNUM";
            public static string MEDI_INVERSE = "MEDI_INVERSE";
            public static string BUY_PRICE = "BUY_PRICE";
            public static string SELL_PRICE = "SELL_PRICE";
            public static string STORENUM = "STORENUM";
            public static string EXECDEPTCODE = "EXECDEPTCODE";
            public static string SCALE = "SCALE";
            public static string INSUR_TYPE = "INSUR_TYPE";
            public static string GBCODE = "GBCODE";
            public static string D_CODE = "D_CODE";
        }

    }
}
