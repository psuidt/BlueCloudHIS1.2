using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;

namespace HIS.DAL
{
    /// <summary>
    /// 公共DAL数据访问类
    /// </summary>
    public class Public_DAL
    {
        /// <summary>
        /// 优惠的数据
        /// </summary>
        public class faoverAllData
        {
            private string _code;
            /// <summary>
            /// 代码
            /// </summary>
            public string Code
            {
                set { _code = value; }
                get { return _code; }
            }

            private int _type;
            /// <summary>
            /// 费用类型（0，诊疗服务项目1，组合项目2，药品）
            /// </summary>
            public int Type
            {
                set { _type = value; }
                get { return _type; }
            }

            private decimal _totalfee;
            /// <summary>
            /// 金额
            /// </summary>
            public decimal Totalfee
            {
                set { _totalfee = value; }
                get { return _totalfee; }
            }
        }
        /// <summary>
        /// 数据操作对象
        /// </summary>
        public RelationalDatabase _OleDB = null;
        /// <summary>
        /// 得到优惠费用
        /// </summary>
        /// <param name="SystemType">系统类型 1门诊，2住院</param>
        /// <param name="patientCode">病人类型代码</param>
        /// <param name="CostAllFee">全部费用</param>
        /// <param name="ItemTypeFee">项目数据</param>
        /// <param name="OrderFee">费用数据</param>
        /// <returns></returns>
        public decimal GetfaoverAll_Fee(int SystemType, string patientCode,decimal CostAllFee, List<faoverAllData> ItemTypeFee,List<faoverAllData> OrderFee)
        {
            string strWhere = Tables.base_patienttype_cost.PATTYPECODE + _OleDB.EuqalTo() + "'" + patientCode + "'";
            DataTable dt = BindEntity<object>.CreateInstanceDAL(_OleDB, Tables.BASE_PATIENTTYPE_COST).GetList(strWhere, Tables.base_patienttype_cost.PATTYPECODE
                , Tables.base_patienttype_cost.FAVORABLE_SCALE
                , Tables.base_patienttype_cost.FAVORABLE_TYPE
                );
            if (dt.Rows.Count < 1)
                return 0;
            int type = Convert.ToInt32(dt.Rows[0]["FAVORABLE_TYPE"]);
            if (type == 0)
            {
                return 0;//优惠功能待实现
            }
            else if (type == 1)
            {
                decimal scale = Convert.ToDecimal(dt.Rows[0]["FAVORABLE_SCALE"]);
                return Convert.ToDecimal(CostAllFee * (1 - scale));
            }
            else if (type == 2)
            {
                decimal dec = 0;
                strWhere = Tables.base_item_favorable.PATTYPECODE + _OleDB.EuqalTo() + "'" + patientCode + "'"
                    + _OleDB.And() + Tables.base_item_favorable.ITEMTYPE_FLAG + _OleDB.EuqalTo() + SystemType;
                DataTable favorData = BindEntity<object>.CreateInstanceDAL(_OleDB, Tables.BASE_ITEM_FAVORABLE).GetList(strWhere);

                for (int k = 0; k < ItemTypeFee.Count; k++)
                {
                    for (int i = 0; i < favorData.Rows.Count; i++)
                    {
                        if (favorData.Rows[i]["ITEMCODE"].ToString().Trim() == ItemTypeFee[k].Code)
                        {
                            decimal fee = Convert.ToDecimal(ItemTypeFee[k].Totalfee);
                            decimal scale = Convert.ToDecimal(favorData.Rows[i]["FAVORABLE_SCALE"]);
                            dec += fee * (1 - scale);
                            break;
                        }
                    }
                }

                return dec;
            }
            else if (type == 3)
            {
                decimal dec = 0;

                strWhere = Tables.base_itemmx_favorable.PATTYPECODE + _OleDB.EuqalTo() + "'" + patientCode + "'";
                DataTable favorData = BindEntity<object>.CreateInstanceDAL(_OleDB, Tables.BASE_ITEMMX_FAVORABLE).GetList(strWhere);

                for (int i = 0; i < OrderFee.Count; i++)
                {
                    for (int k = 0; k < favorData.Rows.Count; k++)
                    {
                        if (OrderFee[i].Type==2)//药品
                        {
                            if (Convert.ToInt32(favorData.Rows[k]["ITEMTYPE"]) == 2 && favorData.Rows[k]["ITEMID"].ToString().Trim() == OrderFee[i].Code.ToString())
                            {
                                decimal fee = OrderFee[i].Totalfee;
                                decimal scale = Convert.ToDecimal(favorData.Rows[k]["FAVORABLE_SCALE"]);
                                dec += fee * (1 - scale);
                                break;
                            }
                        }
                        else if (OrderFee[i].Type==0)//服务项目
                        {
                            if (Convert.ToInt32(favorData.Rows[k]["ITEMTYPE"]) == 0 && favorData.Rows[k]["ITEMID"].ToString().Trim() == OrderFee[i].Code.ToString())
                            {
                                decimal fee = OrderFee[i].Totalfee;
                                decimal scale = Convert.ToDecimal(favorData.Rows[k]["FAVORABLE_SCALE"]);
                                dec += fee * (1 - scale);
                                break;
                            }
                        }
                        else if (OrderFee[i].Type==1)//组合项目
                        {
                            if (Convert.ToInt32(favorData.Rows[k]["ITEMTYPE"]) == 1 && favorData.Rows[k]["ITEMID"].ToString().Trim() == OrderFee[i].Code.ToString())
                            {
                                decimal fee = OrderFee[i].Totalfee;
                                decimal scale = Convert.ToDecimal(favorData.Rows[k]["FAVORABLE_SCALE"]);
                                dec += fee * (1 - scale);
                                break;
                            }
                        }
                    }
                }

                return dec;
            }
            else
            {
                return 0;
            }
        }
    }
}
