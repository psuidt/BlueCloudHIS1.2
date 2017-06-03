using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_ZYDocManager.日常业务
{
    public partial class ImageReport : Form
    {
        public ImageReport()
        {
            InitializeComponent();
            
        }
         public ImageReport(Bitmap image)
        {
            InitializeComponent();
            this.pictureBox1.BackgroundImage = null;
            this.Size = image.Size;
            this.pictureBox1.Size = image.Size;
            this.pictureBox1.BackgroundImage = image;
        }

        private void ImageReport_Load(object sender, EventArgs e)
        {

        }
    }
}
