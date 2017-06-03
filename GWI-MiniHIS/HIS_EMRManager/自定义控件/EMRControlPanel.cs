using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.SYSTEM.PubicBaseClasses;
using System.Xml;
using System.Reflection;
using Word;

namespace HIS_EMRManager
{
    /// <summary>
    /// 病历控件承载面板
    /// </summary>
    public partial class EMRControlPanel : UserControl
    {
        private EMRControl _control;  //当前病历控件
        private IEMRPrint _emrPrint;  //病历打印接口
        private Public.EMRRecordInfo _recordInfo;  //当前病历记录信息
        private HIS.EMR_BLL.EmrRecord _oldRecord;  //最近一次的历史病历

        public event EventHandler EMRSaved;

        public EMRControlPanel()
        {
            InitializeComponent();
        }

        public EMRControlPanel(HIS.EMR_BLL.EmrRecord record)
        {
            InitializeComponent();
            _control = EMRRecordControlFactory.CreateEMRRecordControl(record.RecordType, record.RecordContentXml);
            _emrPrint = EMRPrintObjectFactory.CreateEMRPrintObject(record.RecordType, record.RecordContentXml);
            this._control.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Clear();
            this.Controls.Add(_control);
            this.Controls.Add(this.plBottom);
            this.plBottom.Visible = false;
        }

        /// <summary>
        /// 病历控件承载面板
        /// </summary>
        /// <param name="info">病历基本信息</param>
        public EMRControlPanel(Public.EMRRecordInfo info)
        {
            InitializeComponent();

            _recordInfo = info;
            Public.StaticVariable.CurrentRecordInfo = info;
            _oldRecord = new HIS.EMR_BLL.EmrRecord(info.Patid, info.PatListid, Public.PublicStaticFunction.GetEMRTypeCode(info.RecordType));
            _control = EMRRecordControlFactory.CreateEMRRecordControl(info.RecordType, _oldRecord.RecordContentXml);
            _emrPrint = EMRPrintObjectFactory.CreateEMRPrintObject(info.RecordType, _oldRecord.RecordContentXml);
            this._control.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Clear();
            this.Controls.Add(_control);
            this.Controls.Add(this.plBottom);
            this.btSaveEMRRecord.Enabled = this._oldRecord.UpdateFlag == 0;
        }

        /// <summary>
        /// 病历控件承载面板
        /// </summary>
        /// <param name="info">病历基本信息</param>
        /// <param name="createNewRecord">是否创建新病历记录</param>
        public EMRControlPanel(Public.EMRRecordInfo info,bool createNewRecord)
        {
            InitializeComponent();

            _recordInfo = info;
            Public.StaticVariable.CurrentRecordInfo = info;
            if (createNewRecord)
            {
                _oldRecord = new HIS.EMR_BLL.EmrRecord();
                _oldRecord.RecordId = -1;
                _control = EMRRecordControlFactory.CreateEMRRecordControl(info.RecordType);
                _emrPrint = EMRPrintObjectFactory.CreateEMRPrintObject(info.RecordType);
            }
            else
            {
                _oldRecord = new HIS.EMR_BLL.EmrRecord(info.Patid, info.PatListid, Public.PublicStaticFunction.GetEMRTypeCode(info.RecordType));
                _control = EMRRecordControlFactory.CreateEMRRecordControl(info.RecordType, _oldRecord.RecordContentXml);
                _emrPrint = EMRPrintObjectFactory.CreateEMRPrintObject(info.RecordType, _oldRecord.RecordContentXml);
            }
            this._control.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Clear();
            this.Controls.Add(_control);
            this.Controls.Add(this.plBottom);
            this.btSaveEMRRecord.Enabled = this._oldRecord.UpdateFlag == 0;
        }

        /// <summary>
        /// 病历控件承载面板
        /// </summary>
        /// <param name="info">病历基本信息</param>
        /// <param name="recordId">病历记录ID</param>
        public EMRControlPanel(Public.EMRRecordInfo info, int recordId)
        {
            InitializeComponent();

            _recordInfo = info;
            Public.StaticVariable.CurrentRecordInfo = info;
            _oldRecord = new HIS.EMR_BLL.EmrRecord(recordId);
            _control = EMRRecordControlFactory.CreateEMRRecordControl(info.RecordType, _oldRecord.RecordContentXml);
            _emrPrint = EMRPrintObjectFactory.CreateEMRPrintObject(info.RecordType, _oldRecord.RecordContentXml);
            this._control.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Clear();
            this.Controls.Add(_control);
            this.Controls.Add(this.plBottom);
            this.btSaveEMRRecord.Enabled = this._oldRecord.UpdateFlag == 0;
        }

        //保存病历记录
        public void btSaveEMRRecord_Click(object sender, EventArgs e)
        {
            HIS.EMR_BLL.EmrRecord newRecord = new HIS.EMR_BLL.EmrRecord();

            newRecord.PatId = (int)_recordInfo.Patid;
            newRecord.PatListId = (int)_recordInfo.PatListid;
            newRecord.RecordType = Public.PublicStaticFunction.GetEMRTypeCode(_recordInfo.RecordType) ;
            newRecord.RecordContentXml = _control.GetValue();
            newRecord.RecordCreateEmp = (int)_recordInfo.CreateEmpId;
            newRecord.RecordCreateDept = (int)_recordInfo.CreateDeptId;
            newRecord.RecordCreateDate = XcDate.ServerDateTime;
            newRecord.HistoryRecordId = -1;
            if (_oldRecord.RecordId >-1)
            {
                newRecord.HistoryRecordId = _oldRecord.RecordId;
            }
            newRecord.Add();
            _oldRecord.Invalid();
            this._oldRecord = newRecord;
            MessageBox.Show("保存成功！","提示");
            if (EMRSaved != null)
            {
                EMRSaved(sender,e);
            }
        }
        //应用模板
        private void btUseMould_Click(object sender, EventArgs e)
        {
            FrmWholeMould form = new FrmWholeMould(this._recordInfo.RecordType);
            form.ShowDialog();
            if (form.SelectedValue != null)
            {
                this._control.SetValue(form.SelectedValue);
            }
        }
        //保存模板
        private void btSaveMould_Click(object sender, EventArgs e)
        {
            this.ctMnSSaveLevel.Show(GetControlX(this.btSaveMould) + this.btSaveMould.Width + 8, GetControlY(this.btSaveMould));
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                //int mzZyFlag = (_recordInfo.RecordType == HIS_EMRManager.Public.EMRType.门诊病历 ? 0 : 1);
                //XmlDocument xmlDoc = HIS.EMR_BLL.OP_EmrDataUpdate.GetPatInfo((int)_recordInfo.PatListid, mzZyFlag, _oldRecord.RecordCreateDate);
                this._oldRecord.PatListId = (int)_recordInfo.PatListid;
                this._control.EmrRecord = _oldRecord;
                this._emrPrint.Print(_oldRecord);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btHistory_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string dahid = "";
                if (_recordInfo.MediCard != "")
                {
                    dahid = HIS.EMR_BLL.OP_EmrDataUpdate.GetPatFileId(_recordInfo.MediCard, _recordInfo.PatName);
                }
                else
                {
                    FrmPatList form = new FrmPatList(HIS.EMR_BLL.OP_EmrDataUpdate.GetPatFileId(_recordInfo.PatName));
                    form.ShowDialog();
                    if (form.IsSure)
                    {
                        dahid = form.SelectedFileId;
                    }
                }
                if (dahid.Trim() != "")
                {
                    FrmEmrList form = new FrmEmrList(HIS.EMR_BLL.OP_EmrDataUpdate.LoadEmrRecord(dahid, Public.PublicStaticFunction.GetEMRTypeCode(_recordInfo.RecordType)));
                    form.RecordRowSelected += new EventHandler(EmrList_RecordRowSelected);
                    form.ShowDialog();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void EmrList_RecordRowSelected(object sender, EventArgs e)
        {
            if (sender != null)
            {
                HIS.EMR_BLL.EmrRecord record = new HIS.EMR_BLL.EmrRecord();
                record.RecordType = Public.PublicStaticFunction.GetEMRTypeCode(_recordInfo.RecordType);
                record.RecordContent = sender.ToString();
                EMRControlPanel panel = new EMRControlPanel(record);
                panel.Dock = DockStyle.Fill;
                Form form = new Form();
                form.Size = new Size(650, 800);
                form.Controls.Add(panel);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();
            }
        }


        private int GetControlX(Control control)
        {
            if (control.Parent != null)
            {
                return control.Location.X + GetControlX(control.Parent);
            }
            return control.Location.X;
        }

        private int GetControlY(Control control)
        {
            if (control.Parent != null)
            {
                return control.Location.Y + GetControlY(control.Parent);
            }
            return control.Location.Y;
        }

        private void btCHI_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip.Show(GetControlX(this.btCHI) + this.btCHI.Width + 8, GetControlY(this.btCHI));
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string dahid = "";
                if (_recordInfo.MediCard != "")
                {
                    dahid = HIS.EMR_BLL.OP_EmrDataUpdate.GetPatFileId(_recordInfo.MediCard, _recordInfo.PatName);
                }
                else
                {
                    FrmPatList form = new FrmPatList(HIS.EMR_BLL.OP_EmrDataUpdate.GetPatFileId(_recordInfo.PatName));
                    form.ShowDialog();
                    if (form.IsSure)
                    {
                        dahid = form.SelectedFileId;
                    }
                }
                if (dahid.Trim() != "")
                {
                    object oMissing = Missing.Value; 
                    Word.Application wordApp = new Word.Application();
                    wordApp.Visible = true;
                    wordApp.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    //内容
                    wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordApp.Selection.Font.Size = 10;
                    wordApp.Selection.TypeText(HIS.EMR_BLL.OP_EmrDataUpdate.GetZhxx(dahid,((ToolStripMenuItem)sender).Tag.ToString()));
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ToolStripMenuItemLevel_Click(object sender, EventArgs e)
        {
            FrmWholeMould form = new FrmWholeMould(this._recordInfo.RecordType, this._control.GetValue(), Convert.ToInt32(((ToolStripMenuItem)sender).Tag));
            form.ShowDialog();
        }
    }
}
