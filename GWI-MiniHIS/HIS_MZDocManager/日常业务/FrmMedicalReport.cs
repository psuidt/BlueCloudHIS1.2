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
    public partial class FrmMedicalReport : Form
    {
        public FrmMedicalReport()
        {
            InitializeComponent();
        }

        public Bitmap ShowImage
        {
            set
            {
                if (value != null)
                {
                    this.Width = value.Width;
                    this.pictureBox.Image = value;
                    this.pictureBox.Height = value.Height;
                }
            }
        }
    }
}
