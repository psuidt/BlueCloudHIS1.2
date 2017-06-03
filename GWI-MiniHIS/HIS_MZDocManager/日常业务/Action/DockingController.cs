using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_MZDocManager.日常业务.Action
{
    class DockingController
    {
        #region 助手 自定义控件
        private Crownwood.Magic.Docking.DockingManager _manager;

        protected bool _captionBars = true;
        protected bool _closeButtons = true;
        protected int _colorIndex = 0;

        private System.Windows.Forms.ImageList _images;

        //病人列表
        private System.Windows.Forms.Panel _pnlPatientList;				//我的病人
        private System.Windows.Forms.ListView _lvwPatientList;
        private System.Windows.Forms.DateTimePicker _dtpBegin;
        private System.Windows.Forms.DateTimePicker _dtpEnd;
        private System.Windows.Forms.RadioButton _rdbDocPatient;
        private System.Windows.Forms.RadioButton _rdbDeptPatient;
        private System.Windows.Forms.RadioButton _rdbWaitPatient;
        private System.Windows.Forms.RadioButton _rdbFinishPatient;
        private System.Windows.Forms.Button _btRefreshPatient;

        private System.Windows.Forms.ColumnHeader itemHeader1;
        private System.Windows.Forms.ColumnHeader itemHeader2;
        private System.Windows.Forms.ColumnHeader itemHeader3;
        private System.Windows.Forms.ColumnHeader itemHeader4;
        private System.Windows.Forms.ColumnHeader itemHeader5;

        //常用药品
        private System.Windows.Forms.ComboBox _cmbFilterFieldDrug;		//过滤字段类别
        private System.Windows.Forms.TextBox _txtSearchDrug;				//查询内容
        private System.Windows.Forms.Panel _pnlOfenDrug;					//医生常用药品
        private System.Windows.Forms.Panel _pnlDrugLetter;				//药品选择字母
        private System.Windows.Forms.ListView _lvwOfenDrug;

        private System.Windows.Forms.ColumnHeader itemHeader6;
        private System.Windows.Forms.ColumnHeader itemHeader7;
        private System.Windows.Forms.ColumnHeader itemHeader8;
        private System.Windows.Forms.ColumnHeader itemHeader9;
        private System.Windows.Forms.ColumnHeader itemHeader10;
        private System.Windows.Forms.ColumnHeader itemHeader11;
        private System.Windows.Forms.ColumnHeader itemHeader12;
        private System.Windows.Forms.ColumnHeader itemHeader13;
        private System.Windows.Forms.ColumnHeader itemHeader14;
        private System.Windows.Forms.ColumnHeader itemHeader15;
        private System.Windows.Forms.ColumnHeader itemHeader16;
        private System.Windows.Forms.ColumnHeader itemHeader17;
        private System.Windows.Forms.ColumnHeader itemHeader18;
        private System.Windows.Forms.ColumnHeader itemHeader19;
        private System.Windows.Forms.ColumnHeader itemHeader20;
        private System.Windows.Forms.ColumnHeader itemHeader21;
        private System.Windows.Forms.ColumnHeader itemHeader22;
        private System.Windows.Forms.ColumnHeader itemHeader23;
        private System.Windows.Forms.ColumnHeader itemHeader24;
        private System.Windows.Forms.ColumnHeader itemHeader25;
        private System.Windows.Forms.ColumnHeader itemHeader26;
        private System.Windows.Forms.ColumnHeader itemHeader27;
        private System.Windows.Forms.ColumnHeader itemHeader28;
        private System.Windows.Forms.ColumnHeader itemHeader29;
        private System.Windows.Forms.ColumnHeader itemHeader30;

        //常用项目
        private System.Windows.Forms.ComboBox _cmbFilterFieldItem;		//过滤字段类别
        private System.Windows.Forms.TextBox _txtSearchItem;				//查询内容
        private System.Windows.Forms.Panel _pnlOfenItem;					//医生常用项目
        private System.Windows.Forms.Panel _pnlItemLetter;				//项目选择字母
        private System.Windows.Forms.ListView _lvwOfenItem;

        private System.Windows.Forms.ColumnHeader itemHeader31;
        private System.Windows.Forms.ColumnHeader itemHeader32;
        private System.Windows.Forms.ColumnHeader itemHeader33;
        private System.Windows.Forms.ColumnHeader itemHeader34;
        private System.Windows.Forms.ColumnHeader itemHeader35;
        private System.Windows.Forms.ColumnHeader itemHeader36;
        private System.Windows.Forms.ColumnHeader itemHeader37;
        private System.Windows.Forms.ColumnHeader itemHeader38;
        private System.Windows.Forms.ColumnHeader itemHeader39;
        private System.Windows.Forms.ColumnHeader itemHeader40;
        private System.Windows.Forms.ColumnHeader itemHeader41;
        private System.Windows.Forms.ColumnHeader itemHeader42;
        private System.Windows.Forms.ColumnHeader itemHeader43;
        private System.Windows.Forms.ColumnHeader itemHeader44;
        private System.Windows.Forms.ColumnHeader itemHeader45;
        private System.Windows.Forms.ColumnHeader itemHeader46;
        private System.Windows.Forms.ColumnHeader itemHeader47;
        private System.Windows.Forms.ColumnHeader itemHeader48;
        private System.Windows.Forms.ColumnHeader itemHeader49;
        private System.Windows.Forms.ColumnHeader itemHeader50;
        private System.Windows.Forms.ColumnHeader itemHeader51;
        private System.Windows.Forms.ColumnHeader itemHeader52;
        private System.Windows.Forms.ColumnHeader itemHeader53;
        private System.Windows.Forms.ColumnHeader itemHeader54;
        private System.Windows.Forms.ColumnHeader itemHeader55;

        //常用诊断
        private System.Windows.Forms.Panel _pnlOfenDiagnosis;			//常用诊断
        private System.Windows.Forms.ListView _lvwOfenDiagnosis;

        private System.Windows.Forms.ColumnHeader itemHeader56;
        private System.Windows.Forms.ColumnHeader itemHeader57;
        private System.Windows.Forms.ColumnHeader itemHeader58;
        private System.Windows.Forms.ColumnHeader itemHeader59;
        private System.Windows.Forms.ColumnHeader itemHeader60;

        //医生模板
        private System.Windows.Forms.Panel _pnlYSMB;						//医生模板
        private System.Windows.Forms.RadioButton _rdbYSLevelH;		//院级
        private System.Windows.Forms.RadioButton _rdbYSLevelD;		//科级
        private System.Windows.Forms.RadioButton _rdbYSLevelP;		//个人级
        private System.Windows.Forms.TextBox txtModuleName = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TreeView _tvwYSModule;
        private System.Windows.Forms.DataGrid dtgrdYSMB;


        private System.Windows.Forms.Panel pnlPatient;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel pnlDrugInfo;
        private System.Windows.Forms.Panel pnlItemInfo;
        private System.Windows.Forms.Button btRefreshOfenDiagnosis;
        private System.Windows.Forms.Splitter splt1;
        private System.Windows.Forms.Panel pnlModuleName;
        private System.Windows.Forms.Label labelModuleName;
        private System.Windows.Forms.Panel pnlYSModule;
        private System.Windows.Forms.Button btRefreshYSMB;

        #endregion
        private void ii()
        {
            this.itemHeader1 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader2 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader3 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader4 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader5 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader6 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader7 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader8 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader9 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader10 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader11 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader12 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader13 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader14 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader15 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader16 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader17 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader18 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader19 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader20 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader21 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader22 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader23 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader24 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader25 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader26 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader27 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader28 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader29 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader30 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader31 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader32 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader33 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader34 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader35 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader36 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader37 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader38 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader39 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader40 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader41 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader42 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader43 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader44 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader45 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader46 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader47 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader48 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader49 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader50 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader51 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader52 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader53 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader54 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader55 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader56 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader57 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader58 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader59 = new System.Windows.Forms.ColumnHeader();
            this.itemHeader60 = new System.Windows.Forms.ColumnHeader();
            this._pnlPatientList = new System.Windows.Forms.Panel();
            this._lvwPatientList = new System.Windows.Forms.ListView();
            this._btRefreshPatient = new System.Windows.Forms.Button();
            this.pnlPatient = new System.Windows.Forms.Panel();
            this._rdbDeptPatient = new System.Windows.Forms.RadioButton();
            this._rdbDocPatient = new System.Windows.Forms.RadioButton();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this._rdbFinishPatient = new System.Windows.Forms.RadioButton();
            this._rdbWaitPatient = new System.Windows.Forms.RadioButton();
            this._dtpEnd = new System.Windows.Forms.DateTimePicker();
            this._dtpBegin = new System.Windows.Forms.DateTimePicker();
            this._pnlOfenDrug = new System.Windows.Forms.Panel();
            this.pnlDrugInfo = new System.Windows.Forms.Panel();
            this._lvwOfenDrug = new System.Windows.Forms.ListView();
            this._pnlDrugLetter = new System.Windows.Forms.Panel();
            this._pnlOfenItem = new System.Windows.Forms.Panel();
            this.pnlItemInfo = new System.Windows.Forms.Panel();
            this._lvwOfenItem = new System.Windows.Forms.ListView();
            this._pnlItemLetter = new System.Windows.Forms.Panel();
            this._pnlOfenDiagnosis = new System.Windows.Forms.Panel();
            this._lvwOfenDiagnosis = new System.Windows.Forms.ListView();
            this.btRefreshOfenDiagnosis = new System.Windows.Forms.Button();
            this._pnlYSMB = new System.Windows.Forms.Panel();
            this._tvwYSModule = new System.Windows.Forms.TreeView();
            this.splt1 = new System.Windows.Forms.Splitter();
            this.dtgrdYSMB = new System.Windows.Forms.DataGrid();
            this.pnlModuleName = new System.Windows.Forms.Panel();
            this.labelModuleName = new System.Windows.Forms.Label();
            this.pnlYSModule = new System.Windows.Forms.Panel();
            this._rdbYSLevelP = new System.Windows.Forms.RadioButton();
            this._rdbYSLevelD = new System.Windows.Forms.RadioButton();
            this._rdbYSLevelH = new System.Windows.Forms.RadioButton();
            this.btRefreshYSMB = new System.Windows.Forms.Button();

            // 
            // itemHeader1
            // 
            this.itemHeader1.Text = "序号";
            // 
            // itemHeader2
            // 
            this.itemHeader2.Text = "病人姓名";
            this.itemHeader2.Width = 85;
            // 
            // itemHeader3
            // 
            this.itemHeader3.Text = "性别";
            this.itemHeader3.Width = 55;
            // 
            // itemHeader4
            // 
            this.itemHeader4.Text = "挂号医师";
            this.itemHeader4.Width = 85;
            // 
            // itemHeader5
            // 
            this.itemHeader5.Text = "挂号时间";
            this.itemHeader5.Width = 150;
            // 
            // itemHeader6
            // 
            this.itemHeader6.Text = "项目编码";
            this.itemHeader6.Width = 70;
            // 
            // itemHeader7
            // 
            this.itemHeader7.Text = "项目名称";
            this.itemHeader7.Width = 150;
            // 
            // itemHeader8
            // 
            this.itemHeader8.Text = "使用频度";
            this.itemHeader8.Width = 85;
            // 
            // itemHeader9
            // 
            this.itemHeader9.Text = "规格";
            this.itemHeader9.Width = 80;
            // 
            // itemHeader10
            // 
            this.itemHeader10.Text = "单位";
            this.itemHeader10.Width = 55;
            // 
            // itemHeader11
            // 
            this.itemHeader11.Text = "单价";
            this.itemHeader11.Width = 85;
            // 
            // itemHeader12
            // 
            this.itemHeader12.Text = "拼音码";
            this.itemHeader12.Width = 0;
            // 
            // itemHeader13
            // 
            this.itemHeader13.Text = "五笔码";
            this.itemHeader13.Width = 0;
            // 
            // itemHeader14
            // 
            this.itemHeader14.Text = "数字码";
            this.itemHeader14.Width = 0;
            // 
            // itemHeader15
            // 
            this.itemHeader15.Text = "药房/执行科室";
            this.itemHeader15.Width = 120;
            // 
            // itemHeader16
            // 
            this.itemHeader16.Text = "EXECDEPTID";
            this.itemHeader16.Width = 0;
            // 
            // itemHeader17
            // 
            this.itemHeader17.Text = "ITEMPFJ";
            this.itemHeader17.Width = 0;
            // 
            // itemHeader18
            // 
            this.itemHeader18.Text = "ITEMYHJ";
            this.itemHeader18.Width = 0;
            // 
            // itemHeader19
            // 
            this.itemHeader19.Text = "BIGITEMCODE";
            this.itemHeader19.Width = 0;
            // 
            // itemHeader20
            // 
            this.itemHeader20.Text = "TCID";
            this.itemHeader20.Width = 0;
            // 
            // itemHeader21
            // 
            this.itemHeader21.Text = "ISDRUG";
            this.itemHeader21.Width = 0;
            // 
            // itemHeader22
            // 
            this.itemHeader22.Text = "PRESCTYPE";
            this.itemHeader22.Width = 0;
            // 
            // itemHeader23
            // 
            this.itemHeader23.Text = "PSYP";
            this.itemHeader23.Width = 0;
            // 
            // itemHeader24
            // 
            this.itemHeader24.Text = "ITEMID";
            this.itemHeader24.Width = 0;
            // 
            // itemHeader25
            // 
            this.itemHeader25.Text = "SYXD";
            this.itemHeader25.Width = 0;
            // 
            // itemHeader26
            // 
            this.itemHeader26.Text = "USAGEID";
            this.itemHeader26.Width = 0;
            // 
            // itemHeader27
            // 
            this.itemHeader27.Text = "USAGE";
            this.itemHeader27.Width = 0;
            // 
            // itemHeader28
            // 
            this.itemHeader28.Text = "DWBL";
            this.itemHeader28.Width = 0;
            // 
            // itemHeader29
            // 
            this.itemHeader29.Text = "生产厂家";
            this.itemHeader29.Width = 150;
            // 
            // itemHeader30
            // 
            this.itemHeader30.Text = "JSYP";
            this.itemHeader30.Width = 0;
            // 
            // itemHeader31
            // 
            this.itemHeader31.Text = "数字码";
            this.itemHeader31.Width = 0;
            // 
            // itemHeader32
            // 
            this.itemHeader32.Text = "项目名称";
            this.itemHeader32.Width = 150;
            // 
            // itemHeader33
            // 
            this.itemHeader33.Text = "使用频度";
            this.itemHeader33.Width = 85;
            // 
            // itemHeader34
            // 
            this.itemHeader34.Text = "规格";
            this.itemHeader34.Width = 80;
            // 
            // itemHeader35
            // 
            this.itemHeader35.Text = "单位";
            this.itemHeader35.Width = 55;
            // 
            // itemHeader36
            // 
            this.itemHeader36.Text = "单价";
            this.itemHeader36.Width = 70;
            // 
            // itemHeader37
            // 
            this.itemHeader37.Text = "拼音码";
            this.itemHeader37.Width = 70;
            // 
            // itemHeader38
            // 
            this.itemHeader38.Text = "五笔码";
            this.itemHeader38.Width = 70;
            // 
            // itemHeader39
            // 
            this.itemHeader39.Text = "项目编码";
            this.itemHeader39.Width = 85;
            // 
            // itemHeader40
            // 
            this.itemHeader40.Text = "药房/执行科室";
            this.itemHeader40.Width = 120;
            // 
            // itemHeader41
            // 
            this.itemHeader41.Text = "EXECDEPTID";
            this.itemHeader41.Width = 0;
            // 
            // itemHeader42
            // 
            this.itemHeader42.Text = "ITEMPFJ";
            this.itemHeader42.Width = 0;
            // 
            // itemHeader43
            // 
            this.itemHeader43.Text = "ITEMYHJ";
            this.itemHeader43.Width = 0;
            // 
            // itemHeader44
            // 
            this.itemHeader44.Text = "BIGITEMCODE";
            this.itemHeader44.Width = 0;
            // 
            // itemHeader45
            // 
            this.itemHeader45.Text = "TCID";
            this.itemHeader45.Width = 0;
            // 
            // itemHeader46
            // 
            this.itemHeader46.Text = "ISDRUG";
            this.itemHeader46.Width = 0;
            // 
            // itemHeader47
            // 
            this.itemHeader47.Text = "PRESCTYPE";
            this.itemHeader47.Width = 0;
            // 
            // itemHeader48
            // 
            this.itemHeader48.Text = "PSYP";
            this.itemHeader48.Width = 0;
            // 
            // itemHeader49
            // 
            this.itemHeader49.Text = "ITEMID";
            this.itemHeader49.Width = 0;
            // 
            // itemHeader50
            // 
            this.itemHeader50.Text = "SYXD";
            this.itemHeader50.Width = 0;
            // 
            // itemHeader51
            // 
            this.itemHeader51.Text = "USAGEID";
            this.itemHeader51.Width = 0;
            // 
            // itemHeader52
            // 
            this.itemHeader52.Text = "USAGE";
            this.itemHeader52.Width = 0;
            // 
            // itemHeader53
            // 
            this.itemHeader53.Text = "DWBL";
            this.itemHeader53.Width = 0;
            // 
            // itemHeader54
            // 
            this.itemHeader54.Text = "PROD_AREA";
            this.itemHeader54.Width = 0;
            // 
            // itemHeader55
            // 
            this.itemHeader55.Text = "JSYP";
            this.itemHeader55.Width = 0;
            // 
            // itemHeader56
            // 
            this.itemHeader56.Text = "编码";
            // 
            // itemHeader57
            // 
            this.itemHeader57.Text = "名称";
            this.itemHeader57.Width = 150;
            // 
            // itemHeader58
            // 
            this.itemHeader58.Text = "使用频率";
            this.itemHeader58.Width = 70;
            // 
            // itemHeader59
            // 
            this.itemHeader59.Text = "拼音码";
            this.itemHeader59.Width = 80;
            // 
            // itemHeader60
            // 
            this.itemHeader60.Text = "五笔码";
            this.itemHeader60.Width = 80;
            // 
            // _pnlPatientList
            // 
            this._pnlPatientList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this._pnlPatientList.Controls.Add(this._lvwPatientList);
            this._pnlPatientList.Controls.Add(this._btRefreshPatient);
            this._pnlPatientList.Controls.Add(this.pnlPatient);
            this._pnlPatientList.Controls.Add(this.pnlStatus);
            this._pnlPatientList.Controls.Add(this._dtpEnd);
            this._pnlPatientList.Controls.Add(this._dtpBegin);
            this._pnlPatientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlPatientList.Location = new System.Drawing.Point(0, 0);
            this._pnlPatientList.Name = "_pnlPatientList";
            this._pnlPatientList.Size = new System.Drawing.Size(200, 100);
            this._pnlPatientList.TabIndex = 0;
            // 
            // _lvwPatientList
            // 
            this._lvwPatientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemHeader1,
            this.itemHeader2,
            this.itemHeader3,
            this.itemHeader4,
            this.itemHeader5});
            this._lvwPatientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvwPatientList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lvwPatientList.FullRowSelect = true;
            this._lvwPatientList.GridLines = true;
            this._lvwPatientList.Location = new System.Drawing.Point(0, 119);
            this._lvwPatientList.MultiSelect = false;
            this._lvwPatientList.Name = "_lvwPatientList";
            this._lvwPatientList.Size = new System.Drawing.Size(200, 0);
            this._lvwPatientList.TabIndex = 0;
            this._lvwPatientList.UseCompatibleStateImageBehavior = false;
            this._lvwPatientList.View = System.Windows.Forms.View.Details;
            // 
            // _btRefreshPatient
            // 
            this._btRefreshPatient.BackColor = System.Drawing.Color.Transparent;
            this._btRefreshPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this._btRefreshPatient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._btRefreshPatient.Location = new System.Drawing.Point(0, 94);
            this._btRefreshPatient.Name = "_btRefreshPatient";
            this._btRefreshPatient.Size = new System.Drawing.Size(200, 25);
            this._btRefreshPatient.TabIndex = 1;
            this._btRefreshPatient.Text = "刷新病人(共0人)";
            this._btRefreshPatient.UseVisualStyleBackColor = false;
            // 
            // pnlPatient
            // 
            this.pnlPatient.BackColor = System.Drawing.Color.Transparent;
            this.pnlPatient.Controls.Add(this._rdbDeptPatient);
            this.pnlPatient.Controls.Add(this._rdbDocPatient);
            this.pnlPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPatient.Location = new System.Drawing.Point(0, 70);
            this.pnlPatient.Name = "pnlPatient";
            this.pnlPatient.Size = new System.Drawing.Size(200, 24);
            this.pnlPatient.TabIndex = 2;
            // 
            // _rdbDeptPatient
            // 
            this._rdbDeptPatient.BackColor = System.Drawing.Color.Transparent;
            this._rdbDeptPatient.Dock = System.Windows.Forms.DockStyle.Left;
            this._rdbDeptPatient.Location = new System.Drawing.Point(75, 0);
            this._rdbDeptPatient.Name = "_rdbDeptPatient";
            this._rdbDeptPatient.Size = new System.Drawing.Size(75, 24);
            this._rdbDeptPatient.TabIndex = 0;
            this._rdbDeptPatient.Text = "科室病人";
            this._rdbDeptPatient.UseVisualStyleBackColor = false;
            // 
            // _rdbDocPatient
            // 
            this._rdbDocPatient.BackColor = System.Drawing.Color.Transparent;
            this._rdbDocPatient.Checked = true;
            this._rdbDocPatient.Dock = System.Windows.Forms.DockStyle.Left;
            this._rdbDocPatient.Location = new System.Drawing.Point(0, 0);
            this._rdbDocPatient.Name = "_rdbDocPatient";
            this._rdbDocPatient.Size = new System.Drawing.Size(75, 24);
            this._rdbDocPatient.TabIndex = 1;
            this._rdbDocPatient.TabStop = true;
            this._rdbDocPatient.Text = "我的病人";
            this._rdbDocPatient.UseVisualStyleBackColor = false;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.Transparent;
            this.pnlStatus.Controls.Add(this._rdbFinishPatient);
            this.pnlStatus.Controls.Add(this._rdbWaitPatient);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatus.Location = new System.Drawing.Point(0, 46);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(200, 24);
            this.pnlStatus.TabIndex = 3;
            // 
            // _rdbFinishPatient
            // 
            this._rdbFinishPatient.BackColor = System.Drawing.Color.Transparent;
            this._rdbFinishPatient.Dock = System.Windows.Forms.DockStyle.Left;
            this._rdbFinishPatient.Location = new System.Drawing.Point(75, 0);
            this._rdbFinishPatient.Name = "_rdbFinishPatient";
            this._rdbFinishPatient.Size = new System.Drawing.Size(75, 24);
            this._rdbFinishPatient.TabIndex = 0;
            this._rdbFinishPatient.Text = "已诊状态";
            this._rdbFinishPatient.UseVisualStyleBackColor = false;
            // 
            // _rdbWaitPatient
            // 
            this._rdbWaitPatient.BackColor = System.Drawing.Color.Transparent;
            this._rdbWaitPatient.Checked = true;
            this._rdbWaitPatient.Dock = System.Windows.Forms.DockStyle.Left;
            this._rdbWaitPatient.Location = new System.Drawing.Point(0, 0);
            this._rdbWaitPatient.Name = "_rdbWaitPatient";
            this._rdbWaitPatient.Size = new System.Drawing.Size(75, 24);
            this._rdbWaitPatient.TabIndex = 1;
            this._rdbWaitPatient.TabStop = true;
            this._rdbWaitPatient.Text = "候诊状态";
            this._rdbWaitPatient.UseVisualStyleBackColor = false;
            // 
            // _dtpEnd
            // 
            this._dtpEnd.Dock = System.Windows.Forms.DockStyle.Top;
            this._dtpEnd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._dtpEnd.Location = new System.Drawing.Point(0, 23);
            this._dtpEnd.Name = "_dtpEnd";
            this._dtpEnd.Size = new System.Drawing.Size(200, 23);
            this._dtpEnd.TabIndex = 4;
            // 
            // _dtpBegin
            // 
            this._dtpBegin.Dock = System.Windows.Forms.DockStyle.Top;
            this._dtpBegin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._dtpBegin.Location = new System.Drawing.Point(0, 0);
            this._dtpBegin.Name = "_dtpBegin";
            this._dtpBegin.Size = new System.Drawing.Size(200, 23);
            this._dtpBegin.TabIndex = 5;
            // 
            // _pnlOfenDrug
            // 
            this._pnlOfenDrug.BackColor = System.Drawing.Color.Transparent;
            this._pnlOfenDrug.Controls.Add(this.pnlDrugInfo);
            this._pnlOfenDrug.Controls.Add(this._pnlDrugLetter);
            this._pnlOfenDrug.Location = new System.Drawing.Point(0, 0);
            this._pnlOfenDrug.Name = "_pnlOfenDrug";
            this._pnlOfenDrug.Size = new System.Drawing.Size(200, 100);
            this._pnlOfenDrug.TabIndex = 0;
            // 
            // pnlDrugInfo
            // 
            this.pnlDrugInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlDrugInfo.Controls.Add(this._lvwOfenDrug);
            this.pnlDrugInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDrugInfo.Location = new System.Drawing.Point(0, 45);
            this.pnlDrugInfo.Name = "pnlDrugInfo";
            this.pnlDrugInfo.Size = new System.Drawing.Size(200, 55);
            this.pnlDrugInfo.TabIndex = 0;
            // 
            // _lvwOfenDrug
            // 
            this._lvwOfenDrug.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemHeader6,
            this.itemHeader7,
            this.itemHeader8,
            this.itemHeader9,
            this.itemHeader10,
            this.itemHeader11,
            this.itemHeader12,
            this.itemHeader13,
            this.itemHeader14,
            this.itemHeader15,
            this.itemHeader16,
            this.itemHeader17,
            this.itemHeader18,
            this.itemHeader19,
            this.itemHeader20,
            this.itemHeader21,
            this.itemHeader22,
            this.itemHeader23,
            this.itemHeader24,
            this.itemHeader25,
            this.itemHeader26,
            this.itemHeader27,
            this.itemHeader28,
            this.itemHeader29,
            this.itemHeader30});
            this._lvwOfenDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvwOfenDrug.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lvwOfenDrug.FullRowSelect = true;
            this._lvwOfenDrug.GridLines = true;
            this._lvwOfenDrug.Location = new System.Drawing.Point(0, 0);
            this._lvwOfenDrug.MultiSelect = false;
            this._lvwOfenDrug.Name = "_lvwOfenDrug";
            this._lvwOfenDrug.Size = new System.Drawing.Size(200, 55);
            this._lvwOfenDrug.TabIndex = 0;
            this._lvwOfenDrug.UseCompatibleStateImageBehavior = false;
            this._lvwOfenDrug.View = System.Windows.Forms.View.Details;
            // 
            // _pnlDrugLetter
            // 
            this._pnlDrugLetter.BackColor = System.Drawing.Color.Transparent;
            this._pnlDrugLetter.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlDrugLetter.Location = new System.Drawing.Point(0, 0);
            this._pnlDrugLetter.Name = "_pnlDrugLetter";
            this._pnlDrugLetter.Size = new System.Drawing.Size(200, 45);
            this._pnlDrugLetter.TabIndex = 1;
            // 
            // _pnlOfenItem
            // 
            this._pnlOfenItem.BackColor = System.Drawing.Color.Transparent;
            this._pnlOfenItem.Controls.Add(this.pnlItemInfo);
            this._pnlOfenItem.Controls.Add(this._pnlItemLetter);
            this._pnlOfenItem.Location = new System.Drawing.Point(0, 0);
            this._pnlOfenItem.Name = "_pnlOfenItem";
            this._pnlOfenItem.Size = new System.Drawing.Size(200, 100);
            this._pnlOfenItem.TabIndex = 0;
            // 
            // pnlItemInfo
            // 
            this.pnlItemInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlItemInfo.Controls.Add(this._lvwOfenItem);
            this.pnlItemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItemInfo.Location = new System.Drawing.Point(0, 45);
            this.pnlItemInfo.Name = "pnlItemInfo";
            this.pnlItemInfo.Size = new System.Drawing.Size(200, 55);
            this.pnlItemInfo.TabIndex = 0;
            // 
            // _lvwOfenItem
            // 
            this._lvwOfenItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemHeader31,
            this.itemHeader32,
            this.itemHeader33,
            this.itemHeader34,
            this.itemHeader35,
            this.itemHeader36,
            this.itemHeader37,
            this.itemHeader38,
            this.itemHeader39,
            this.itemHeader40,
            this.itemHeader41,
            this.itemHeader42,
            this.itemHeader43,
            this.itemHeader44,
            this.itemHeader45,
            this.itemHeader46,
            this.itemHeader47,
            this.itemHeader48,
            this.itemHeader49,
            this.itemHeader50,
            this.itemHeader51,
            this.itemHeader52,
            this.itemHeader53,
            this.itemHeader54,
            this.itemHeader55});
            this._lvwOfenItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvwOfenItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lvwOfenItem.FullRowSelect = true;
            this._lvwOfenItem.GridLines = true;
            this._lvwOfenItem.Location = new System.Drawing.Point(0, 0);
            this._lvwOfenItem.MultiSelect = false;
            this._lvwOfenItem.Name = "_lvwOfenItem";
            this._lvwOfenItem.Size = new System.Drawing.Size(200, 55);
            this._lvwOfenItem.TabIndex = 0;
            this._lvwOfenItem.UseCompatibleStateImageBehavior = false;
            this._lvwOfenItem.View = System.Windows.Forms.View.Details;
            // 
            // _pnlItemLetter
            // 
            this._pnlItemLetter.BackColor = System.Drawing.Color.Transparent;
            this._pnlItemLetter.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlItemLetter.Location = new System.Drawing.Point(0, 0);
            this._pnlItemLetter.Name = "_pnlItemLetter";
            this._pnlItemLetter.Size = new System.Drawing.Size(200, 45);
            this._pnlItemLetter.TabIndex = 1;
            // 
            // _pnlOfenDiagnosis
            // 
            this._pnlOfenDiagnosis.Controls.Add(this._lvwOfenDiagnosis);
            this._pnlOfenDiagnosis.Controls.Add(this.btRefreshOfenDiagnosis);
            this._pnlOfenDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlOfenDiagnosis.Location = new System.Drawing.Point(0, 0);
            this._pnlOfenDiagnosis.Name = "_pnlOfenDiagnosis";
            this._pnlOfenDiagnosis.Size = new System.Drawing.Size(200, 100);
            this._pnlOfenDiagnosis.TabIndex = 0;
            // 
            // _lvwOfenDiagnosis
            // 
            this._lvwOfenDiagnosis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemHeader56,
            this.itemHeader57,
            this.itemHeader58,
            this.itemHeader59,
            this.itemHeader60});
            this._lvwOfenDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvwOfenDiagnosis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lvwOfenDiagnosis.FullRowSelect = true;
            this._lvwOfenDiagnosis.GridLines = true;
            this._lvwOfenDiagnosis.Location = new System.Drawing.Point(0, 25);
            this._lvwOfenDiagnosis.MultiSelect = false;
            this._lvwOfenDiagnosis.Name = "_lvwOfenDiagnosis";
            this._lvwOfenDiagnosis.Size = new System.Drawing.Size(200, 75);
            this._lvwOfenDiagnosis.TabIndex = 0;
            this._lvwOfenDiagnosis.UseCompatibleStateImageBehavior = false;
            this._lvwOfenDiagnosis.View = System.Windows.Forms.View.Details;
            // 
            // btRefreshOfenDiagnosis
            // 
            this.btRefreshOfenDiagnosis.BackColor = System.Drawing.Color.Transparent;
            this.btRefreshOfenDiagnosis.Dock = System.Windows.Forms.DockStyle.Top;
            this.btRefreshOfenDiagnosis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRefreshOfenDiagnosis.Location = new System.Drawing.Point(0, 0);
            this.btRefreshOfenDiagnosis.Name = "btRefreshOfenDiagnosis";
            this.btRefreshOfenDiagnosis.Size = new System.Drawing.Size(200, 25);
            this.btRefreshOfenDiagnosis.TabIndex = 1;
            this.btRefreshOfenDiagnosis.Text = "刷新常用诊断";
            this.btRefreshOfenDiagnosis.UseVisualStyleBackColor = false;
            // 
            // _pnlYSMB
            // 
            this._pnlYSMB.Controls.Add(this._tvwYSModule);
            this._pnlYSMB.Controls.Add(this.splt1);
            this._pnlYSMB.Controls.Add(this.dtgrdYSMB);
            this._pnlYSMB.Controls.Add(this.pnlModuleName);
            this._pnlYSMB.Controls.Add(this.pnlYSModule);
            this._pnlYSMB.Controls.Add(this.btRefreshYSMB);
            this._pnlYSMB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlYSMB.Location = new System.Drawing.Point(0, 0);
            this._pnlYSMB.Name = "_pnlYSMB";
            this._pnlYSMB.Size = new System.Drawing.Size(200, 100);
            this._pnlYSMB.TabIndex = 0;
            // 
            // _tvwYSModule
            // 
            this._tvwYSModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tvwYSModule.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._tvwYSModule.LineColor = System.Drawing.Color.Empty;
            this._tvwYSModule.Location = new System.Drawing.Point(0, 73);
            this._tvwYSModule.Name = "_tvwYSModule";
            this._tvwYSModule.Size = new System.Drawing.Size(200, -226);
            this._tvwYSModule.TabIndex = 0;
            // 
            // splt1
            // 
            this.splt1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splt1.Location = new System.Drawing.Point(0, -153);
            this.splt1.Name = "splt1";
            this.splt1.Size = new System.Drawing.Size(200, 3);
            this.splt1.TabIndex = 1;
            this.splt1.TabStop = false;
            // 
            // dtgrdYSMB
            // 
            this.dtgrdYSMB.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dtgrdYSMB.CaptionVisible = false;
            this.dtgrdYSMB.DataMember = "";
            this.dtgrdYSMB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgrdYSMB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgrdYSMB.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgrdYSMB.Location = new System.Drawing.Point(0, -150);
            this.dtgrdYSMB.Name = "dtgrdYSMB";
            this.dtgrdYSMB.RowHeadersVisible = false;
            this.dtgrdYSMB.Size = new System.Drawing.Size(200, 250);
            this.dtgrdYSMB.TabIndex = 2;
            // 
            // pnlModuleName
            // 
            this.pnlModuleName.BackColor = System.Drawing.Color.Transparent;
            this.pnlModuleName.Controls.Add(this.labelModuleName);
            this.pnlModuleName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlModuleName.Location = new System.Drawing.Point(0, 49);
            this.pnlModuleName.Name = "pnlModuleName";
            this.pnlModuleName.Size = new System.Drawing.Size(200, 24);
            this.pnlModuleName.TabIndex = 3;
            // 
            // labelModuleName
            // 
            this.labelModuleName.BackColor = System.Drawing.Color.Transparent;
            this.labelModuleName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelModuleName.Location = new System.Drawing.Point(0, 0);
            this.labelModuleName.Name = "labelModuleName";
            this.labelModuleName.Size = new System.Drawing.Size(50, 24);
            this.labelModuleName.TabIndex = 0;
            this.labelModuleName.Text = "模板名:";
            this.labelModuleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlYSModule
            // 
            this.pnlYSModule.BackColor = System.Drawing.Color.Transparent;
            this.pnlYSModule.Controls.Add(this._rdbYSLevelP);
            this.pnlYSModule.Controls.Add(this._rdbYSLevelD);
            this.pnlYSModule.Controls.Add(this._rdbYSLevelH);
            this.pnlYSModule.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlYSModule.Location = new System.Drawing.Point(0, 25);
            this.pnlYSModule.Name = "pnlYSModule";
            this.pnlYSModule.Size = new System.Drawing.Size(200, 24);
            this.pnlYSModule.TabIndex = 4;
            // 
            // _rdbYSLevelP
            // 
            this._rdbYSLevelP.BackColor = System.Drawing.Color.Transparent;
            this._rdbYSLevelP.Checked = true;
            this._rdbYSLevelP.Dock = System.Windows.Forms.DockStyle.Left;
            this._rdbYSLevelP.Location = new System.Drawing.Point(96, 0);
            this._rdbYSLevelP.Name = "_rdbYSLevelP";
            this._rdbYSLevelP.Size = new System.Drawing.Size(48, 24);
            this._rdbYSLevelP.TabIndex = 0;
            this._rdbYSLevelP.TabStop = true;
            this._rdbYSLevelP.Text = "个人";
            this._rdbYSLevelP.UseVisualStyleBackColor = false;
            // 
            // _rdbYSLevelD
            // 
            this._rdbYSLevelD.BackColor = System.Drawing.Color.Transparent;
            this._rdbYSLevelD.Dock = System.Windows.Forms.DockStyle.Left;
            this._rdbYSLevelD.Location = new System.Drawing.Point(48, 0);
            this._rdbYSLevelD.Name = "_rdbYSLevelD";
            this._rdbYSLevelD.Size = new System.Drawing.Size(48, 24);
            this._rdbYSLevelD.TabIndex = 1;
            this._rdbYSLevelD.Text = "科级";
            this._rdbYSLevelD.UseVisualStyleBackColor = false;
            // 
            // _rdbYSLevelH
            // 
            this._rdbYSLevelH.BackColor = System.Drawing.Color.Transparent;
            this._rdbYSLevelH.Dock = System.Windows.Forms.DockStyle.Left;
            this._rdbYSLevelH.Location = new System.Drawing.Point(0, 0);
            this._rdbYSLevelH.Name = "_rdbYSLevelH";
            this._rdbYSLevelH.Size = new System.Drawing.Size(48, 24);
            this._rdbYSLevelH.TabIndex = 2;
            this._rdbYSLevelH.Text = "院级";
            this._rdbYSLevelH.UseVisualStyleBackColor = false;
            // 
            // btRefreshYSMB
            // 
            this.btRefreshYSMB.BackColor = System.Drawing.Color.Transparent;
            this.btRefreshYSMB.Dock = System.Windows.Forms.DockStyle.Top;
            this.btRefreshYSMB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRefreshYSMB.Location = new System.Drawing.Point(0, 0);
            this.btRefreshYSMB.Name = "btRefreshYSMB";
            this.btRefreshYSMB.Size = new System.Drawing.Size(200, 25);
            this.btRefreshYSMB.TabIndex = 5;
            this.btRefreshYSMB.Text = "刷新医生模板";
            this.btRefreshYSMB.UseVisualStyleBackColor = false;

            this._pnlPatientList.SuspendLayout();
            this.pnlPatient.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this._pnlOfenDrug.SuspendLayout();
            this.pnlDrugInfo.SuspendLayout();
            this._pnlOfenItem.SuspendLayout();
            this.pnlItemInfo.SuspendLayout();
            this._pnlOfenDiagnosis.SuspendLayout();
            this._pnlYSMB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdYSMB)).BeginInit();
            this.pnlModuleName.SuspendLayout();
            this.pnlYSModule.SuspendLayout();


        }
    }
}
