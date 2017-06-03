using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_PublicManager.SystemTool.GenerateDalSQL
{
    public partial class FrmData : Form
    {
        public FrmData(DataTable dt)
        {
            InitializeComponent();
            this.dataGridView1.DataSource = dt;
        }
    }
}
