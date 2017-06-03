using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.EMR_BLL;

namespace HIS_EMRManager
{
    /// <summary>
    /// 元素文本框
    /// </summary>
    internal class ElementTextBox : System.Windows.Forms.TextBox
    {
        private bool _hasMould;
        private bool _isPrint;
        private ContextMenuStrip contextMenuStrip;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem tSMnIAddMould;
        private ElementButton _mouldButton;

        /// <summary>
        /// 元素编码
        /// </summary>
        public new object Tag
        {
            get
            { 
                return base.Tag;
            }
            set
            { 
                base.Tag = value;
                //this._mouldButton.Tag = value;
            }
        }
        /// <summary>
        /// 控件名称
        /// </summary>
        public new string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
                this._mouldButton.Name = value + "_MouldButton";
            }
        }
        /// <summary>
        /// 是否有模板
        /// </summary>
        public bool HasMould
        {
            get 
            { 
                return _hasMould; 
            }
            set
            {
                if (this._mouldButton.Parent != null)
                {
                    this._mouldButton.Parent.Controls.Remove(this._mouldButton);
                }
                _mouldButton.Location = new System.Drawing.Point(this.Location.X + this.Width, this.Location.Y);
                _mouldButton.Visible = this.Visible;
                if (this.Parent != null)
                {
                    if (value)
                    {
                        this.Parent.Controls.Add(_mouldButton);
                    }
                }
                _hasMould = value;
            }
        }
        /// <summary>
        /// 是否打印
        /// </summary>
        public bool IsPrint
        {
            get { return _isPrint; }
            set { _isPrint = value; }
        }

        /// <summary>
        /// 元素文本框
        /// </summary>
        public ElementTextBox()
        {
            InitializeComponent();
            //this.Multiline = true;
            this._hasMould = false;
            this._isPrint = true;

            _mouldButton = new ElementButton();
            _mouldButton.Name = this.Name.Trim() + "_MouldButton";
            _mouldButton.Size = new System.Drawing.Size(30, 20);
            _mouldButton.Text = "...";
            _mouldButton.Location = new System.Drawing.Point(this.Location.X + this.Width, this.Location.Y);
            //_mouldButton.Tag = this.Tag;
            _mouldButton.Click += new EventHandler(MouldButton_Click);

            this.KeyUp += new KeyEventHandler(ElementTextBox_KeyUp);
            this.SizeChanged += new EventHandler(ElementTextBox_SizeChanged);
            this.LocationChanged += new EventHandler(ElementTextBox_LocationChanged);
            this.ParentChanged += new EventHandler(ElementTextBox_ParentChanged);
        }
        //回车跳转
        private void ElementTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{Tab}");
        }
        //调用模板
        private void MouldButton_Click(object sender, EventArgs e)
        {
            EmrElement element = new EmrElement().CreateElement(this.Tag.ToString());
            FrmElementMould form = new FrmElementMould(element);
            form.ShowDialog();
            if (form.IsSure && form.SelectedValue.Trim()!="")
            {
                this.Text = this.Text + (this.Text.Trim()==""?"":"，")+ form.SelectedValue;
            }
            //MouldButtonClick(this.Tag,e);
        }
        //更改父控件
        private void ElementTextBox_ParentChanged(object sender, EventArgs e)
        {
            this.HasMould = _hasMould;
        }
        //更改位置
        private void ElementTextBox_LocationChanged(object sender, EventArgs e)
        {
            this.HasMould = _hasMould;
        }
        //更改控件大小
        private void ElementTextBox_SizeChanged(object sender, EventArgs e)
        {
            this.HasMould = _hasMould;
        }
        //初始化
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMnIAddMould = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMnIAddMould});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(119, 26);
            // 
            // tSMnIAddMould
            // 
            this.tSMnIAddMould.Name = "tSMnIAddMould";
            this.tSMnIAddMould.Size = new System.Drawing.Size(118, 22);
            this.tSMnIAddMould.Text = "存为模板";
            this.tSMnIAddMould.Click += new System.EventHandler(this.tSMnIAddMould_Click);
            // 
            // ElementTextBox
            // 
            this.ContextMenuStrip = this.contextMenuStrip;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        //存为模板
        private void tSMnIAddMould_Click(object sender, EventArgs e)
        {
            if (this.Tag != null && this.Tag.ToString().Length > 0 && this.Text.ToString().Length > 0)
            {
                HIS.EMR_BLL.EmrElementMould mould = new HIS.EMR_BLL.EmrElementMould();
                mould.MouldCreateDate = System.DateTime.Now; ;
                mould.MouldCreateDept = (int)Public.PublicStaticFunction.CurrentDeptId;
                mould.MouldCreateEmp = (int)Public.PublicStaticFunction.CurrentEmployeeId;
                mould.MouldLevel = 1;
                mould.MouldType = this.Tag.ToString();
                mould.MouldContent = this.Text.Trim();
                mould.Add();
                MessageBox.Show("保存成功！", "提示");
            }
        }
    }
}
