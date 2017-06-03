using System;
using System.Collections.Generic;
using System.Text;

namespace HIS.ZYNurse_BLL
{
    public class DrugAmoutCalculation
    {
        public static decimal getlongAmout(bool float_flag, int unit_type, int item_type, int exec_num, decimal dose_num, int pack_num, int first_time, int last_time, decimal num, decimal pres_amount, DateTime order_bdate, DateTime order_enddate, DateTime current_time)
        {
            bool floatflag = float_flag;
            int unittype = unit_type;
            int itemtype = item_type;
            int execnum = exec_num;
            int firsttime = first_time;
            int lasttime = last_time;
            decimal amount = num;
            decimal presamount = pres_amount;
            DateTime orderbdate = order_bdate;
            DateTime orderedate = order_enddate;
            decimal dosenum = dose_num; //含量系数
            //float unpicknum;//拆零系数
            decimal packnum = pack_num;//包装系数
            decimal amountresult = 0;
            DateTime currentday = current_time;
            if (orderbdate.ToString("yyyy-MM-dd") == currentday.ToString("yyyy-MM-dd") && orderedate.ToString("yyyy-MM-dd") == currentday.ToString("yyyy-MM-dd"))//12月7日修改，解决收没次问题
            {
                execnum = lasttime;
            }
            else if (orderbdate.ToString("yyyy-MM-dd") == currentday.ToString("yyyy-MM-dd"))
            {
                execnum = firsttime;
            }
            else if (orderedate.ToString("yyyy-MM-dd") == currentday.ToString("yyyy-MM-dd"))
            {
                execnum = lasttime;
            }
            else
            {
                execnum = exec_num;
            }
            if (item_type != 3)//西成药
            {
                if (float_flag)//累计取整
                {
                    amountresult = Math.Ceiling(((amount * execnum) / dosenum));
                }
                else
                {
                    amountresult = Math.Ceiling(Math.Ceiling(amount / dosenum) * execnum);
                }
            }
            else
            {

            }
            return amountresult;
        }

        public static decimal gettempAmout(int order_type, bool float_flag, int unit_type, int item_type, int exec_num, decimal dose_num, int pack_num, decimal num, decimal pres_amount, DateTime order_bdate)
        {
            bool floatflag = float_flag;
            int unittype = unit_type;
            int itemtype = item_type;
            int execnum = exec_num;
            //int firsttime = first_time;
            //int lasttime = last_time;
            decimal amount = num;
            decimal presamount = pres_amount;
            DateTime orderbdate = order_bdate;
            //DateTime orderedate = order_enddate;
            decimal dosenum = dose_num; //含量系数
            //float unpicknum;//拆零系数
            decimal packnum = pack_num;//包装系数
            decimal amountresult;
            if (order_type == 7 || order_type == 5)
            {
                if (unittype == 0)//含量单位
                {

                    if (float_flag)
                    {
                        amountresult = Math.Ceiling((amount * presamount) / dosenum);
                    }
                    else
                    {
                        amountresult = Math.Ceiling((Math.Ceiling(amount / dosenum)) * presamount);
                    }
                }
                else if (unittype == 1)//最小单位
                {
                    if (float_flag)
                    {
                        amountresult = Math.Ceiling(amount);
                    }
                    else
                    {
                        amountresult = (Math.Ceiling(amount));
                    }
                }
                else//包装单位
                {
                    if (float_flag)
                    {
                        amountresult = Math.Ceiling((amount) * packnum);
                    }
                    else
                    {
                        amountresult = (Math.Ceiling(amount)) * packnum;
                    }
                }
            }
            else
            {
                if (unittype == 0)//含量单位
                {
                    if (item_type != 3)//西成药 
                    {
                        if (float_flag)//累计取整
                        {
                            amountresult = Math.Ceiling(((amount * execnum) / dosenum));
                        }
                        else
                        {
                            amountresult = Math.Ceiling(Math.Ceiling(amount / dosenum) * execnum);
                        }
                    }
                    else///中药只开含量单位，故只在含量单位里处理
                    {
                        if (float_flag)
                        {
                            amountresult = Math.Ceiling((amount * presamount) / dosenum);
                        }
                        else
                        {
                            amountresult = Math.Ceiling((Math.Ceiling(amount / dosenum)) * presamount);
                        }
                    }
                }
                else if (unittype == 1)//最小单位
                {
                    if (float_flag)
                    {
                        amountresult = Math.Ceiling(amount * execnum);
                    }
                    else
                    {
                        amountresult = (Math.Ceiling(amount)) * execnum;
                    }
                }
                else//包装单位
                {
                    if (float_flag)
                    {
                        amountresult = Math.Ceiling((amount * execnum) * packnum);
                    }
                    else
                    {
                        amountresult = (Math.Ceiling(amount)) * execnum * packnum;
                    }
                }
            }
            return amountresult;
        }
    }
}
