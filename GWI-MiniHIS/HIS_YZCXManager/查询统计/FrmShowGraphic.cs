using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_YZCXManager
{
    public partial class FrmShowGraphic : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private DataTable _dataSource;
        private string _itemName;
        private TableColumn[] _columns;
        private DataTableStruct _selectStruct;
        private string _title;

        public FrmShowGraphic(DataTable dataSource, string itemName, TableColumn[] columns,
            DataTableStruct selectStruct, string title)
        {
            _dataSource = dataSource;
            _itemName = itemName;
            _columns = columns;
            _selectStruct = selectStruct;
            _title = title;           
            InitializeComponent();
            this.FormTitle = title;
            this.Text = title;
        }

        private void FrmShowGraphic_Load(object sender, EventArgs e)
        {
            try
            {
                if (_dataSource != null)
                {
                    GraphControl gc;
                    Color[] colors = new Color[_dataSource.Rows.Count];
                    Random random = new Random();
                    for (int index = 0; index < _dataSource.Rows.Count; index++)
                    {
                        int red = random.Next(255);
                        int blue = random.Next(255);
                        int green = random.Next(255);
                        colors[index] = Color.FromArgb(red, green, blue);
                    }
                    gc = new CakyGraphControl(this.plBaseWorkArea, _selectStruct, _columns, colors, _dataSource, _itemName, 0);
                    gc.GraphTitle = _title;
                    gc.DrawGraph();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
