using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using grproLib;
using System.Windows.Forms;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_MZDocManager
{
    public partial class FrmTransfusionCard : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;  //当前用户
        private Deptment _currentDept;  //当前科室
        private HIS.MZDoc_BLL.Patient _currentPatient = null;
        private int _paintRowIndex = -1;
        private GridppReport report = null;
        private DataTable printTable = null;
        int skinTestUsageId;

        public FrmTransfusionCard(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            this.FormTitle = chineseName;
        }

        #region 方法
        /// <summary>
        /// 显示病人信息
        /// </summary>
        private void ShowPatientInfo()
        {
            if (_currentPatient != null || _currentPatient.PatList != null)
            {
                this.txtName.Text = _currentPatient.PatList.PatName;
                this.txtSex.Text = _currentPatient.PatList.PatSex;
                this.txtAge.Text = _currentPatient.PatList.Age.ToString() + _currentPatient.PatList.HpGrade;
                this.txtTel.Text = _currentPatient.PatientInfo.PatTEL;
                this.txtFeeType.Text = _currentPatient.FeeTypeName;
                this.tBCardno.Text = _currentPatient.PatList.MediCard;
                this.tBVisitNo.Text = _currentPatient.PatList.VisitNo;
                this.tBDiagnosis.Text = _currentPatient.PatList.DiseaseName;

                this.dGVEMain.AutoGenerateColumns = false;
                this.dGVEMain.DataSource = _currentPatient.GetTransfusionPres();
            }
        }

        /// <summary>
        /// 绘制组线
        /// </summary>
        /// <param name="groupFlag">组号</param>
        /// <param name="graphics">绘图对象</param>
        /// <param name="pen">画笔</param>
        protected void PaintGroupLine(int groupFlag, Graphics graphics, System.Drawing.Pen pen)
        {
            Rectangle rectangle = new Rectangle(this.dGVEMain.GetCellDisplayRectangle(this.Item_Id.Index, this._paintRowIndex, false).X,
                    this.dGVEMain.GetCellDisplayRectangle(this.Item_Id.Index, this._paintRowIndex, false).Y,
                    this.dGVEMain.GetCellDisplayRectangle(this.Item_Id.Index, this._paintRowIndex, false).Width + this.dGVEMain.GetCellDisplayRectangle(this.Item_Name.Index, this._paintRowIndex, false).Width,
                    this.dGVEMain.GetCellDisplayRectangle(this.Item_Id.Index, this._paintRowIndex, false).Height);

            //定义坐标变量
            int startPointX, startPointY, endPointX, endPointY;
            int firstLineWidth = 6;
            int firstLineHeight = rectangle.Height / 2;
            switch (groupFlag)
            {
                case 1:
                    //小横线
                    startPointX = rectangle.Left - firstLineWidth;
                    startPointY = rectangle.Bottom - firstLineHeight;
                    endPointX = rectangle.Left;
                    endPointY = rectangle.Bottom - firstLineHeight;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    //小竖线
                    startPointX = rectangle.Left - firstLineWidth;
                    startPointY = rectangle.Bottom - firstLineHeight;
                    endPointX = rectangle.Left - firstLineWidth;
                    endPointY = rectangle.Bottom;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    break;
                case 2:
                    startPointX = rectangle.Left - firstLineWidth;
                    startPointY = rectangle.Top;
                    endPointX = rectangle.Left - firstLineWidth;
                    endPointY = rectangle.Bottom;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    break;
                case 3:
                    //小竖线
                    startPointX = rectangle.Left - firstLineWidth;
                    startPointY = rectangle.Top;
                    endPointX = rectangle.Left - firstLineWidth;
                    endPointY = rectangle.Top + firstLineHeight;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    //小横线
                    startPointX = rectangle.Left - firstLineWidth;
                    startPointY = rectangle.Top + firstLineHeight;
                    endPointX = rectangle.Left;
                    endPointY = rectangle.Top + firstLineHeight;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 绘制组线
        /// </summary>
        /// <param name="graphics"></param>
        public void PaintGroup(Graphics graphics)
        {
            DataTable dataSource = (DataTable)this.dGVEMain.DataSource;
            int penWidth = 1;

            if (dataSource == null || dataSource.Rows.Count <= 0)
            {
                return;
            }

            //循环遍历所有记录
            for (int index = 0; index < dataSource.Rows.Count; index++)
            {
                Color penColer = Color.Black;
                _paintRowIndex = index;

                int groupFlag = Convert.ToInt32(dataSource.Rows[index]["Group_Id"]);
                int nextGroupFlag = index == dataSource.Rows.Count - 1 ? 0 : Convert.ToInt32(dataSource.Rows[index + 1]["Group_Id"]);
                if (groupFlag == 1)
                {
                    PaintGroupLine(1, graphics, new Pen(penColer, penWidth));
                }
                else if (groupFlag > 1 && nextGroupFlag > groupFlag)
                {
                    PaintGroupLine(2, graphics, new Pen(penColer, penWidth));
                }
                else if (groupFlag > 1)
                {
                    PaintGroupLine(3, graphics, new Pen(penColer, penWidth));
                }
            }
        }

        /// <summary>
        /// 按频次拆分打印输液卡
        /// </summary>
        private void CreatePrintTableOnFrequency()
        {
            printTable = ((DataTable)this.dGVEMain.DataSource).Clone();
            printTable.Columns.Add("Item_Usage_Amount", Type.GetType("System.String"));
            printTable.Columns.Add("Item_Usage_Name", Type.GetType("System.String"));
            printTable.Columns.Add("Group_Flag", Type.GetType("System.String"));

            int groupId = 0;
            printTable.Rows.Clear();
            DataTable dataSource = (DataTable)this.dGVEMain.DataSource;
            DataRow[] rows = dataSource.Select("Selected=1");
            for (int index = 0; index < rows.Length; index++)
            {
                printTable.Rows.Add(rows[index].ItemArray);
                DataRow row = printTable.Rows[printTable.Rows.Count - 1];
                row["Item_Name"] = rows[index]["Item_Name"].ToString().Trim() + "[" + rows[index]["Standard"].ToString().Trim() + "]";
                //row["Item_Days"] = rows[index]["Days"].ToString().Trim() + "天";
                //row["Entrust"] = rows[index]["Entrust"].ToString().Trim();
                //row["Frequency_Name"] = rows[index]["Frequency_Name"].ToString().Trim();
                if (Convert.ToInt32(rows[index]["SkinTest_Flag"]) > 0 && Convert.ToInt32(rows[index]["SkinTest_Flag"]) < 4)
                {
                    row["Item_Name"] = row["Item_Name"].ToString() + " 皮试(  )";
                }
                else if (Convert.ToInt32(rows[index]["SkinTest_Flag"]) == 4 && Convert.ToInt32(rows[index]["Usage_Id"]) != skinTestUsageId)
                {
                    row["Item_Name"] = row["Item_Name"].ToString() + "(免试)";
                }
                row["Item_Usage_Amount"] = Convert.ToDecimal(rows[index]["Usage_Amount"]).ToString().TrimEnd('0').TrimEnd('.') + "" + rows[index]["Usage_Unit"].ToString();
                int group_id = Convert.ToInt32(rows[index]["Group_Id"]);
                if (group_id < 2)
                {
                    if (index > 0)
                    {
                        decimal execNum = Convert.ToInt32(rows[index - 1]["Frequency_ExecNum"]) / Convert.ToInt32(rows[index - 1]["Frequency_CycleDay"]);
                        if (execNum > 1)
                        {
                            DataRow[] grouprows = printTable.Select("Group_Id=" + groupId.ToString());
                            for (decimal i = execNum; i > 1; i--)
                            {
                                groupId++;
                                for (int j = 0; j < grouprows.Length; j++)
                                {
                                    printTable.Rows.Add(grouprows[j].ItemArray);
                                    printTable.Rows[printTable.Rows.Count - 1]["Group_Id"] = groupId;
                                }
                            }
                        }
                    }
                    groupId++;
                    row["Group_Id"] = groupId;
                    row["Item_Usage_Name"] = rows[index]["Usage_Name"];
                    row["Group_Flag"] = "";
                    if (group_id == 1)
                    {
                        row["Group_Flag"] = "│";
                    }
                }
                else
                {
                    row["Group_Id"] = groupId;
                    row["Item_Usage_Name"] = "";
                    row["Group_Flag"] = "│";
                }

                //printTable.Rows.Add(row);
            }
            if (rows.Length > 0)
            {
                decimal execNum = Convert.ToInt32(rows[rows.Length - 1]["Frequency_ExecNum"]) / Convert.ToInt32(rows[rows.Length - 1]["Frequency_CycleDay"]);
                if (execNum > 1)
                {
                    DataRow[] grouprows = printTable.Select("Group_Id=" + groupId.ToString());
                    for (decimal i = execNum; i > 1; i--)
                    {
                        groupId++;
                        for (int j = 0; j < grouprows.Length; j++)
                        {
                            printTable.Rows.Add(grouprows[j].ItemArray);
                            printTable.Rows[printTable.Rows.Count - 1]["Group_Id"] = groupId;
                        }
                    }
                }
            }
        }

        private void Report_FetchRecord(ref bool Eof)
        {
            GWI_DesReport.HisReport.FillRecordToReport(report, printTable);
        }

        /// <summary>
        /// 处方打印
        /// </summary>
        public void PresPrint()
        {
            if (_currentPatient != null || _currentPatient.PatList != null)
            {
                report = new GridppReport();
                report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\门诊输液卡.grf");

                report.ParameterByName("医院名称").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                report.ParameterByName("开方科室").AsString = new Deptment(Convert.ToInt64(_currentPatient.PatList.CureDeptCode)).Name;
                report.ParameterByName("开方医师").AsString = new Employee(Convert.ToInt64(_currentPatient.PatList.CureEmpCode)).Name;
                report.ParameterByName("门诊号").AsString = _currentPatient.PatList.VisitNo;
                report.ParameterByName("病人姓名").AsString = _currentPatient.PatList.PatName;
                report.ParameterByName("性别").AsString = _currentPatient.PatList.PatSex;
                report.ParameterByName("年龄").AsString = _currentPatient.PatList.Age + _currentPatient.PatList.HpGrade;
                report.ParameterByName("打印人").AsString = _currentUser.Name;
                report.ParameterByName("诊断").AsString = _currentPatient.PatList.DiseaseName;

                report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(Report_FetchRecord);
                CreatePrintTableOnFrequency();
                report.PrintPreview(false);
            }
        }
        #endregion

        private void FrmTransfusionCard_Load(object sender, EventArgs e)
        {
            skinTestUsageId = Convert.ToInt32(HIS.MZDoc_BLL.OP_ReadBaseData.GetConfigValue("002"));
        }

        private void _btRefreshPatient_Click(object sender, EventArgs e)
        {
            this._lvwPatientList.Items.Clear();
            List<HIS.Model.MZ_PatList> patlist = HIS.MZDoc_BLL.OP_Patient.SearchPatList(dTPkBegin.Value, dTPkEnd.Value);
            for (int i = 0; i < patlist.Count; i++)
            {
                ListViewItem lstViewItem = new ListViewItem();
                lstViewItem.SubItems.Clear();
                lstViewItem.Tag = patlist[i];
                lstViewItem.SubItems[0].Text = patlist[i].VisitNo;
                lstViewItem.SubItems.Add(patlist[i].PatName);
                lstViewItem.SubItems.Add(patlist[i].PatSex);
                lstViewItem.SubItems.Add(patlist[i].Age.ToString());
                lstViewItem.SubItems.Add(patlist[i].REG_DOC_NAME);
                lstViewItem.SubItems.Add(patlist[i].REG_DEPT_NAME);
                lstViewItem.SubItems.Add(patlist[i].CureDate.ToString());
                this._lvwPatientList.Items.Add(lstViewItem);
            }
            _btRefreshPatient.Text = "刷新病人(共" + patlist.Count + "人)";
        }

        private void _lvwPatientList_DoubleClick(object sender, EventArgs e)
        {
            _currentPatient = new HIS.MZDoc_BLL.Patient((HIS.Model.MZ_PatList)_lvwPatientList.SelectedItems[0].Tag);
            ShowPatientInfo();
        }

        private void tBVisitNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                string searchValue = tBVisitNo.Text.Trim();
                if (searchValue != "")
                {
                    _currentPatient = new HIS.MZDoc_BLL.Patient(searchValue);
                    ShowPatientInfo();
                    if (_currentPatient.PatList.PatListID == 0)
                    {
                        MessageBox.Show("找不到与该门诊号对应的病人信息！", "提示");
                    }
                }
            }
        }

        private void dGVEMain_Paint(object sender, PaintEventArgs e)
        {
            PaintGroup(e.Graphics);
        }

        private void dGVEMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataTable dataSource = (DataTable)this.dGVEMain.DataSource;
                dataSource.Rows[e.RowIndex]["Selected"] = !(bool)dataSource.Rows[e.RowIndex]["Selected"];
                if (Convert.ToInt32(dataSource.Rows[e.RowIndex]["Group_Id"]) > 0)
                {
                    if (Convert.ToInt32(dataSource.Rows[e.RowIndex]["Group_Id"]) > 1)
                    {
                        for (int index = e.RowIndex - 1; index > -1; index--)
                        {
                            if (Convert.ToInt32(dataSource.Rows[index]["Group_Id"]) >= 1)
                            {
                                dataSource.Rows[index]["Selected"] = dataSource.Rows[e.RowIndex]["Selected"];
                            }
                            if (Convert.ToInt32(dataSource.Rows[index]["Group_Id"]) == 1)
                            {
                                break;
                            }
                        }
                    }
                    for (int index = e.RowIndex + 1; index < dataSource.Rows.Count; index++)
                    {
                        if (Convert.ToInt32(dataSource.Rows[index]["Group_Id"]) > 1)
                        {
                            dataSource.Rows[index]["Selected"] = dataSource.Rows[e.RowIndex]["Selected"];
                        }
                        else if (Convert.ToInt32(dataSource.Rows[index]["Group_Id"]) == 1)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            PresPrint();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            if (_currentPatient == null || _currentPatient.PatList == null)
            {
                string searchValue = tBVisitNo.Text.Trim();
                if (searchValue != "")
                {
                    _currentPatient = new HIS.MZDoc_BLL.Patient(searchValue);
                    ShowPatientInfo();
                    if (_currentPatient.PatList.PatListID == 0)
                    {
                        MessageBox.Show("找不到与该门诊号对应的病人信息！", "提示");
                    }
                }
            }
            else
            {
                ShowPatientInfo();
            }
        }
    }
}
