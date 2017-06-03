using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZDocManager
{
    public partial class FrmQueryShow : Form
    {
        public event EventHandler RecordRowSelected;
        public FrmQueryShow(string titleText,DataTable source,DataGridViewColumn[] columns)
        {
            InitializeComponent();
            this.Text = titleText;
            dGVEResult.AutoGenerateColumns = false;
            dGVEResult.Columns.AddRange(columns);
            for (int index = 0; index < dGVEResult.Columns.Count; index++)
            {
                dGVEResult.Columns[index].ReadOnly = true;
            }
            dGVEResult.DataSource = source;
            dGVEResult.EndEdit();
        }

        private void dGVEResult_DoubleClick(object sender, EventArgs e)
        {
            if (dGVEResult.DataSource != null)
            {
                DataTable table = (DataTable)dGVEResult.DataSource;
                if (table.Rows.Count > dGVEResult.CurrentCell.RowIndex)
                {
                    RecordRowSelected(table.Rows[dGVEResult.CurrentCell.RowIndex],e);
                }
            }
            this.Close();
        }

        private void dGVEResult_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (dGVEResult.DataSource != null)
            {
                DataTable table = (DataTable)dGVEResult.DataSource;
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        if (table.Rows.Count > dGVEResult.CurrentCell.RowIndex + 1)
                        {
                            dGVEResult.CurrentCell = dGVEResult[dGVEResult.CurrentCell.ColumnIndex, dGVEResult.CurrentCell.RowIndex + 1];
                        }
                        break;
                    case Keys.Up:
                        if (dGVEResult.CurrentCell.RowIndex > 0)
                        {
                            dGVEResult.CurrentCell = dGVEResult[dGVEResult.CurrentCell.ColumnIndex, dGVEResult.CurrentCell.RowIndex - 1];
                        }
                        break;
                    case Keys.Enter:
                        dGVEResult_DoubleClick(sender, null);
                        break;
                }
            }
        }
    }
}
