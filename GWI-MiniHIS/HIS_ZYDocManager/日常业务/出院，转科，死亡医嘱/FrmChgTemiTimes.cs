using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;

namespace HIS_ZYDocManager.日常业务
{
    public partial class FrmChgTemiTimes : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmChgTemiTimes()
        {
            InitializeComponent();
        }
        public DataTable ChangeOrders;
        public DataTable groupTb = new DataTable();
        public int endnum=0;
        private int patlistid;
        public bool isOK = false;
        bool flag = false;
        private HIS.ZYDoc_BLL.BaseInfo.DrugBase drugbase = new HIS.ZYDoc_BLL.BaseInfo.DrugBase();
        private HIS.ZYDoc_BLL.OrderInfo.IOrderOP orderop = new HIS.ZYDoc_BLL.OrderInfo.OrderOperation();
        private void FrmChgTemiTimes_Load(object sender, EventArgs e)
        {
           this.teminal_times.TextFormatStyle = GWI.HIS.Windows.Controls.TextFormatStyle.Numberic;
        }
        public FrmChgTemiTimes(HIS.Model.ZY_PatList patlist,int num)
        {
            InitializeComponent();            
            if (num < 0)
            {
                this.endnum =0;
                flag = true;
            }
            else
            {
                this.endnum = num;
            }
            this.lb_ts.Text = "注：末次根据频率和停嘱时间默认";
            this.patlistid = patlist.PatListID;                    
            GetPatOrder(patlist);
        }
        public void  GetPatOrder(HIS.Model.ZY_PatList plist)
        {
            DataTable myTb = orderop.GetOrders(HIS.ZYDoc_BLL.OrderType.长期医嘱,HIS.ZYDoc_BLL.Status.护士转抄, plist,Convert.ToInt32( plist.CurrDeptCode));
            CheckDataLong(myTb);
        }
        public void CheckDataLong(DataTable mytable)
        {
            if (mytable == null || mytable.Rows.Count == 0)
            {
                return;
            }
            int exenum = 0;
            DateTime  dtime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            DataTable myTb;
            DataView tempDataView = new DataView(mytable, "","order_bdate,group_id,serial_id", DataViewRowState.CurrentRows);
            myTb = insertRow(tempDataView, mytable);
            tempDataView.Dispose(); 
                myTb.Rows[0]["begintime"] = myTb.Rows[0]["order_bdate"].ToString();
                DateTime beginDateTime =Convert.ToDateTime(myTb.Rows[0]["order_bdate"].ToString());
                string frnquecy = myTb.Rows[0]["frequency"].ToString();
                exenum = drugbase.getExecTimes(myTb.Rows[0]["frequency"].ToString(), dtime, 1); 
                if (flag)
                {
                    if (dtime.Date == beginDateTime.Date)//当天开当天停的
                    {
                        if (frnquecy == "持续" || frnquecy == "Q1h")
                        {
                            int hour1 = dtime.Hour;
                            int bhour = beginDateTime.Hour;
                            myTb.Rows[0]["teminal_times"] = hour1 - bhour + 1;
                        }
                        else
                        {
                            myTb.Rows[0]["teminal_times"] = drugbase.getExecTimes(myTb.Rows[0]["frequency"].ToString(), dtime, 1);
                        }
                    }
                    else
                    {
                        if (frnquecy == "持续" || frnquecy == "Q1h")
                        {
                            myTb.Rows[0]["teminal_times"] = (HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.Hour + 1);
                        }
                        else
                        {
                            myTb.Rows[0]["teminal_times"] = drugbase.getExecTimes(myTb.Rows[0]["frequency"].ToString(), dtime, 1);
                        }

                    }
                }
                else
                {
                    myTb.Rows[0]["teminal_times"] = endnum;// (exenum >= endnum) ? endnum : exenum; //末次不加限制 2009.11.25
                }
                for (int i = 1; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["order_content"].ToString().Trim() == "产后医嘱" || myTb.Rows[i]["order_content"].ToString().Trim() == "术后医嘱")
                    {
                        continue;
                    }
                    if (myTb.Rows[i]["group_id"].ToString().Trim() != myTb.Rows[i - 1]["group_id"].ToString().Trim())
                    {
                        myTb.Rows[i]["begintime"] = myTb.Rows[i]["order_bdate"].ToString(); 
                    }
                     beginDateTime =Convert.ToDateTime(myTb.Rows[i]["order_bdate"].ToString());                   
                     frnquecy = myTb.Rows[i]["frequency"].ToString();
                     exenum = drugbase.getExecTimes(myTb.Rows[i]["frequency"].ToString(), dtime, 1);
                   
                        if (flag)
                        {
                            if (dtime.Date == beginDateTime.Date)//当天开当天停的
                            {
                                if (frnquecy == "持续" || frnquecy == "Q1h")
                                {
                                    int hour1 = dtime.Hour;
                                    int bhour = beginDateTime.Hour;
                                    myTb.Rows[i]["teminal_times"] = hour1 - bhour + 1;
                                }
                                else
                                {
                                    myTb.Rows[i]["teminal_times"] = drugbase.getExecTimes(myTb.Rows[i]["frequency"].ToString(), dtime, 1);
                                }

                            }
                            else
                            {
                                if (frnquecy == "持续" || frnquecy == "Q1h")
                                {
                                    myTb.Rows[i]["teminal_times"] = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.Hour + 1;
                                }
                                else
                                {
                                    myTb.Rows[i]["teminal_times"] = drugbase.getExecTimes(myTb.Rows[i]["frequency"].ToString(), dtime, 1);
                                }

                            }                            
                        }
                        else
                        {
                            myTb.Rows[i]["teminal_times"] =  endnum;// (exenum >= endnum) ? endnum : exenum; //末次不加限制 2009.11.25
                        }                   
                }
                this.dtgrdLong.AutoGenerateColumns = false;
                this.dtgrdLong.DataSource = myTb;                
                DataTable dt =(DataTable) this.dtgrdLong.DataSource;            
                int count = dt.Rows.Count;
                 
        }       

        #region 数据视图→表
        private DataTable insertRow(DataView myView, DataTable dt)
        {
            DataTable myTb = dt.Copy(); ;
            myTb.Rows.Clear();
            foreach (DataRowView myDRV in myView)
            {
                DataRow newDR = myTb.NewRow();
                for (int i = 0; i < myView.Table.Columns.Count; i++)
                {
                    newDR[i] = myDRV[i];
                }
                myTb.Rows.Add(newDR);
            }
            return myTb;
        }
        #endregion       

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.isOK = true;
            DataTable tempTb = (DataTable)this.dtgrdLong.DataSource;
            if (tempTb == null || tempTb.Rows.Count == 0)
            {
                this.Close();
                return;
            }
            DataRow[] drList = tempTb.Select("teminal_times>=0");
            this.groupTb = tempTb.Clone();
            foreach (DataRow dr in drList)
            {
                //末次不要限制
                //string frequcy = dr["frequency"].ToString();
                //int teminaltime = HIS.ZYDoc_BLL.OP_LongOrder.getExecTimes(frequcy, HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime, 1);
                //if (Convert.ToInt32 (dr["teminal_times"].ToString()) > teminaltime)
                //{
                //    dr["teminal_times"] = teminaltime;
                //}
                groupTb.Rows.Add(dr.ItemArray);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isOK = false;
            this.Close();
        }

        private void dtgrdLong_DataGridViewCellKeyPress(object sender, KeyPressEventArgs e, ref bool handle)
        {
            if (this.dtgrdLong == null || this.dtgrdLong.Rows.Count == 0 || this.dtgrdLong.CurrentCell == null)
            {
                return;
            }
            int rowid = this.dtgrdLong.CurrentCell.RowIndex;
            int colid = this.dtgrdLong.CurrentCell.ColumnIndex;
            if (colid == 8)
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 96 && e.KeyChar < 110) || e.KeyChar == 13 || (e.KeyChar >= 37 && e.KeyChar <= 40) || e.KeyChar == 8 || e.KeyChar == 46)
                {

                }
                else
                {
                    handle = true;
                }
            }
        }
       
    }
}
