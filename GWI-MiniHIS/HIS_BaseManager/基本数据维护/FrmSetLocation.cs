using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS_BaseManager.基本数据维护.Controller;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.Base_BLL;
using GWI.HIS.Windows.Controls;

namespace HIS_BaseManager.基本数据维护
{
    public partial class FrmSetLocation : BaseForm
    {
        private Control[] selectedControls;
        private bool beginMove;
        private Point mousePos;   //   记录鼠标位置  
        private bool tabeIndexEditing;//是否在编辑TabIndex
        private int currentTabIndex;
        private readonly int scale = 10;
        private readonly int margin = 10;
        private bool inselected; //是否在选择

        private List<FieldConfig> locationSettings;
        /// <summary>
        /// 
        /// </summary>
        public List<FieldConfig> LocationSettings
        {
            get
            {
                return locationSettings;
            }
        }

        void BindEvent( Control ctrl, bool flag )
        {
            if ( flag )
            {
                ctrl.MouseDown += new MouseEventHandler( sourceCtrl_MouseDown );
                ctrl.MouseMove += new MouseEventHandler( sourceCtrl_MouseMove );
                ctrl.MouseUp += new MouseEventHandler( sourceCtrl_MouseUp );
                ctrl.Click += new EventHandler( sourceCtrl_Click );
                ctrl.SizeChanged += new EventHandler( ctrl_SizeChanged );
            }
            else
            {
                ctrl.MouseDown -= new MouseEventHandler( sourceCtrl_MouseDown );
                ctrl.MouseMove -= new MouseEventHandler( sourceCtrl_MouseMove );
                ctrl.MouseUp -= new MouseEventHandler( sourceCtrl_MouseUp );
                ctrl.Click -= new EventHandler( sourceCtrl_Click );
                ctrl.SizeChanged -= new EventHandler( ctrl_SizeChanged );
            }
        }
        /// <summary>
        /// 对齐控件
        /// </summary>
        /// <param name="direct">0-左对齐 1-顶对齐,2 - 大小相同，3-水平间距，4-垂直间距</param>
        private void SnapControl( int direct )
        {
            if ( selectedControls == null )
                return;
            if ( selectedControls.Length == 0 )
                return;
            
            

            if ( direct == 0 )
            {
                int left = selectedControls[0].Left;
                for ( int i = 0; i < selectedControls.Length; i++ )
                    selectedControls[i].Left = left;
            }
            else if ( direct == 1)
            {
                int top = selectedControls[0].Top;
                for ( int i = 0; i < selectedControls.Length; i++ )
                    selectedControls[i].Top = top;
            }
            else if ( direct == 2 )
            {
                int width = selectedControls[0].Width;
                int height = selectedControls[0].Height;
                for ( int i = 0; i < selectedControls.Length; i++ )
                    selectedControls[i].Size = new Size( width, height );
            }
            else 
            {
                if ( selectedControls.Length <= 2 )
                    return;

                ReSortSelectedControls( direct );

                if ( direct == 3 )
                {
                    //水平间隔
                    int firstLeft = selectedControls[0].Left;
                    int lastLeft = selectedControls[selectedControls.Length - 1].Left;
                    int avg = ( lastLeft - firstLeft ) / ( selectedControls.Length - 1 );
                    int nextLeft = 0;
                    for ( int i = 0; i < selectedControls.Length; i++ )
                    {
                        if ( i == 0 )
                        {
                            selectedControls[i].Left = firstLeft;
                            nextLeft = selectedControls[i].Left +  avg;
                        }
                        else
                        {
                            selectedControls[i].Left = nextLeft;
                            nextLeft = selectedControls[i].Left + avg;
                        }
                                                
                    }
                }
                else
                {
                    //垂直间隔
                    int firstTop = selectedControls[0].Top;
                    int lastTop = selectedControls[selectedControls.Length - 1].Top;
                    int avg = ( lastTop - firstTop ) / ( selectedControls.Length - 1 );
                    for ( int i = 0; i < selectedControls.Length; i++ )
                    {
                        selectedControls[i].Top = firstTop;
                        firstTop = firstTop +  avg;
                    }
                }
            }
            
        }
        /// <summary>
        /// 重排序控件
        /// </summary>
        /// <param name="direct">0-左对齐 1-顶对齐,2 - 大小相同，3-水平间距，4-垂直间距</param>
        private void ReSortSelectedControls( int direct )
        {
            
            Control tmpCtrl = null;
            
            if ( selectedControls.Length <= 2 )
                return;

            if ( direct == 3 )
            {
                //水平间隔
                int[] lefts = new int[selectedControls.Length];
                for ( int i = 0; i < selectedControls.Length; i++ )
                    lefts[i] = selectedControls[i].Left;
                int tmp = 0;
                for ( int i = 0; i < lefts.Length; i++ )
                {
                    for ( int j = i + 1; j < lefts.Length; j++ )
                    {
                        if ( lefts[i] > lefts[j] )
                        {
                            tmp = lefts[i];
                            lefts[i] = lefts[j];
                            lefts[j] = tmp;
                        }
                    }
                }

                for ( int i = 0; i < selectedControls.Length; i++ )
                {
                    for ( int j = i + 1; j < selectedControls.Length; j++ )
                    {
                        if ( selectedControls[i].Left > selectedControls[j].Left )
                        {
                            tmpCtrl = selectedControls[i];
                            selectedControls[i] = selectedControls[j];
                            selectedControls[j] = tmpCtrl;
                        }
                    }
                }

                
            }
            else
            {
                //垂直间隔
                //int[] tops = new int[selectedControls.Length];
                //for ( int i = 0; i < selectedControls.Length; i++ )
                //    tops[i] = selectedControls[i].Top;
                //int tmp = 0;
                //for ( int i = 0; i < tops.Length; i++ )
                //{
                //    for ( int j = i + 1; j < tops.Length; j++ )
                //    {
                //        if ( tops[i] > tops[j] )
                //        {
                //            tmp = tops[i];
                //            tops[i] = tops[j];
                //            tops[j] = tmp;
                //        }
                //    }
                //}

                for ( int i = 0; i < selectedControls.Length; i++ )
                {
                    for ( int j = i + 1; j < selectedControls.Length; j++ )
                    {
                        if ( selectedControls[i].Top > selectedControls[j].Top )
                        {
                            tmpCtrl = selectedControls[i];
                            selectedControls[i] = selectedControls[j];
                            selectedControls[j] = tmpCtrl;
                        }
                    }
                }
            }
            
        }

        void ctrl_SizeChanged( object sender, EventArgs e )
        {
            object obj = ( (Control)sender ).Tag;
            if ( obj != null )
            {
                ( (FieldConfig)obj ).WIDTH = ( (Control)sender ).Width;
                ( (FieldConfig)obj ).HEIGHT = ( (Control)sender ).Height;
            }
        }

        void sourceCtrl_Click( object sender, EventArgs e )
        {
            txtWidth.TextChanged-=new EventHandler(txtWidth_TextChanged);
            txtHeight.TextChanged-=new EventHandler(txtHeight_TextChanged);
            txtLocationX.ValueChanged -= new EventHandler( txtLocation_ValueChanged );
            txtLocationY.ValueChanged -= new EventHandler( txtLocation_ValueChanged );

            txtWidth.Text = ( (Control)sender ).Width.ToString();
            txtHeight.Text = ( (Control)sender ).Height.ToString();
            txtLocationX.Value = ( (Control)sender ).Left;
            txtLocationY.Value = ( (Control)sender ).Top;

            txtWidth.TextChanged += new EventHandler( txtWidth_TextChanged );
            txtHeight.TextChanged += new EventHandler( txtHeight_TextChanged );
            txtLocationX.ValueChanged += new EventHandler( txtLocation_ValueChanged );
            txtLocationY.ValueChanged += new EventHandler( txtLocation_ValueChanged );

            foreach ( Control ctrl in plControls.Controls )
            {
                if ( ctrl is TextBox )
                {
                    ( (TextBox)ctrl ).BackColor = Color.White;
                    ( (TextBox)ctrl ).ForeColor = Color.Black;
                }
                if ( ctrl is CheckBox )
                {
                    ( (CheckBox)ctrl ).BackColor = Color.Transparent;
                    ( (CheckBox)ctrl ).ForeColor = Color.Black;
                }
            }

            if ( ( (Control)sender ) is TextBox )
            {
                ( (TextBox)sender ).BackColor = SystemColors.Highlight;
                ( (TextBox)sender ).ForeColor = SystemColors.HighlightText;
            }
            if ( ( (Control)sender ) is CheckBox )
            {
                ( (CheckBox)sender ).BackColor = SystemColors.Highlight;
                ( (CheckBox)sender ).ForeColor = SystemColors.HighlightText;
            }

            if ( tabeIndexEditing )
            {
                FieldConfig config = (FieldConfig)( (Control)sender ).Tag;
                config.TABINDEX = currentTabIndex;
                currentTabIndex = currentTabIndex + 1;
                if ( ( (Control)sender ) is TextBox )
                {
                    ( (TextBox)sender ).Text = config.FIELD_CN_NAME + "(" + config.TABINDEX + ")";
                    
                }
                if ( ( (Control)sender ) is CheckBox )
                {
                    ( (CheckBox)sender ).Text = config.FIELD_CN_NAME + "(" + config.TABINDEX + ")";
                }

            }
        }

        void sourceCtrl_MouseUp( object sender, MouseEventArgs e )
        {
            if ( tabeIndexEditing )
                return;

            beginMove = false;
            this.plControls.Refresh();
            
        }

        void sourceCtrl_MouseMove( object sender, MouseEventArgs e )
        {
            if ( tabeIndexEditing )
                return;
            int diffx, diffy;
            diffx = mousePos.X - e.X;
            diffy = mousePos.Y - e.Y;

            if ( beginMove )
            {
                Point p = new Point( ( (Control)sender ).Location.X - diffx, ( (Control)sender ).Location.Y - diffy );
                ( (Control)sender ).Location = p;
                object obj = ( (Control)sender ).Tag;
                if ( obj != null )
                {
                    ( (FieldConfig)obj ).LOCATION_X = p.X;
                    ( (FieldConfig)obj ).LOCATION_Y = p.Y;
                }
                if ( p.X > 0 && p.Y > 0 )
                {
                    txtLocationX.Value = p.X;
                    txtLocationY.Value = p.Y;
                }
                //画参考对齐线
                using ( Graphics g = this.plControls.CreateGraphics() )
                {
                    Point ptH1 = new Point( 0, selectedControls[0].Top );
                    Point ptH2 = new Point( this.plControls.Width, selectedControls[0].Top );
                    Point ptH3 = new Point( 0, selectedControls[0].Top + selectedControls[0].Height );
                    Point ptH4 = new Point( this.plControls.Width, selectedControls[0].Top + selectedControls[0].Height );

                    Point ptV1 = new Point( selectedControls[0].Left, 0 );
                    Point ptV2 = new Point( selectedControls[0].Left, this.plControls.Height );
                    Point ptV3 = new Point( selectedControls[0].Left + selectedControls[0].Width, 0 );
                    Point ptV4 = new Point( selectedControls[0].Left + selectedControls[0].Width, this.plControls.Height );

                    Pen pen = new Pen( Color.Red );
                    this.plControls.Refresh();
                    g.DrawLine( pen, ptH1, ptH2 );
                    g.DrawLine( pen, ptH3, ptH4 );
                    g.DrawLine( pen, ptV1, ptV2 );
                    g.DrawLine( pen, ptV3, ptV4 );
                }

            }
            
        }

        void sourceCtrl_MouseDown( object sender, MouseEventArgs e )
        {
            selectedControls = new Control[1];
            selectedControls[0] = (Control)sender;
            
            if ( tabeIndexEditing )
                return;

            mousePos = new Point( e.X, e.Y );
            beginMove = true;
            
        }

        private List<FieldConfig> lstTableFields;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LstTableFields"></param>
        public FrmSetLocation( List<FieldConfig> LstTableFields)
        {
            InitializeComponent();

            lstTableFields = LstTableFields;

            
        }

        private void FrmSetLocation_Load( object sender, EventArgs e )
        {
            inselected = false;

            this.plControls.Top = margin;
            this.plControls.Left = margin;
            this.plControls.Height = panel3.Height -  margin;
            this.plControls.Width = panel3.Width - margin;

            #region 创建布局用控件
            for ( int i = 0; i < lstTableFields.Count; i++ )
            {
                Control ctrl = new Control();
                ctrl.Name = lstTableFields[i].FIELD_DB_NAME;

                if ( lstTableFields[i].UIC_TYPE == HIS.Base_BLL.Enums.ControlType.CheckBox )
                {
                    ctrl = new CheckBox();
                    ( (CheckBox)ctrl ).Text = lstTableFields[i].FIELD_CN_NAME + "(" + lstTableFields[i].TABINDEX + ")";
                    ( (CheckBox)ctrl ).Location = new Point( lstTableFields[i].LOCATION_X, lstTableFields[i].LOCATION_Y );
                    ( (CheckBox)ctrl ).Cursor = Cursors.SizeAll;
                    ( (CheckBox)ctrl ).Tag = lstTableFields[i];
                }
                else
                {
                    ctrl = new TextBox();
                    ( (TextBox)ctrl ).Text = lstTableFields[i].FIELD_CN_NAME + "(" + lstTableFields[i].TABINDEX + ")";
                    ( (TextBox)ctrl ).Location = new Point( lstTableFields[i].LOCATION_X, lstTableFields[i].LOCATION_Y );
                    ( (TextBox)ctrl ).Size = new Size( lstTableFields[i].WIDTH, lstTableFields[i].HEIGHT );
                    ( (TextBox)ctrl ).Cursor = Cursors.SizeAll;
                    ( (TextBox)ctrl ).ReadOnly = true;
                    ( (TextBox)ctrl ).BackColor = Color.White;
                    ( (TextBox)ctrl ).Tag = lstTableFields[i];
                }
                BindEvent( ctrl, true );
                this.plControls.Controls.Add( ctrl );

                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = lstTableFields[i].FIELD_DB_NAME;
                col.HeaderText = lstTableFields[i].FIELD_CN_NAME;
                col.Width = lstTableFields[i].GRID_COL_WIDTH;

                dgvColumn.Columns.Add( col );
            }
            #endregion
            txtHeight.Leave += new EventHandler( txtHeight_Leave );
            txtHeight.TextChanged += new EventHandler( txtHeight_TextChanged );
            

            txtWidth.Leave += new EventHandler( txtWidth_Leave );
            txtWidth.TextChanged += new EventHandler( txtWidth_TextChanged );

            txtLocationY.ValueChanged += new EventHandler( txtLocation_ValueChanged );
            txtLocationX.ValueChanged +=new EventHandler(txtLocation_ValueChanged);

            panel3.Paint += new PaintEventHandler( panel3_Paint );

            plControls.MouseDown += new MouseEventHandler( plControls_MouseDown );
            plControls.MouseUp += new MouseEventHandler( plControls_MouseUp );
            plControls.MouseMove += new MouseEventHandler( plControls_MouseMove );
        }

        void plControls_MouseMove( object sender, MouseEventArgs e )
        {
            if ( inselected )
            {
                plControls.Refresh();
                using ( Graphics g = this.plControls.CreateGraphics() )
                {
                    Point endPt = new Point( e.X, e.Y );
                    Size size = new Size( endPt.X - mousePos.X, endPt.Y - mousePos.Y );
                    Pen pen = new Pen( Color.Blue );
                    Rectangle selectedRect = new Rectangle( mousePos, size );
                    g.DrawRectangle( pen, selectedRect );

                    List<Control> curSelCtrl = new List<Control>();
                    foreach ( Control ctrl in plControls.Controls )
                    {
                        if ( ctrl.Bounds.IntersectsWith( selectedRect) )
                        {
                            if ( ctrl is TextBox )
                            {
                                ( (TextBox)ctrl ).BackColor = SystemColors.Highlight;
                                ( (TextBox)ctrl ).ForeColor = SystemColors.HighlightText;
                            }
                            if ( ctrl is CheckBox )
                            {
                                ( (CheckBox)ctrl ).BackColor = SystemColors.Highlight;
                                ( (CheckBox)ctrl ).ForeColor = SystemColors.HighlightText;
                            }

                            curSelCtrl.Add( ctrl );
                        }
                        else
                        {
                            if ( ctrl is TextBox )
                            {
                                ( (TextBox)ctrl ).BackColor = Color.White;
                                ( (TextBox)ctrl ).ForeColor = Color.Black;
                            }
                            if ( ctrl is CheckBox )
                            {
                                ( (CheckBox)ctrl ).BackColor = Color.Transparent;
                                ( (CheckBox)ctrl ).ForeColor = Color.Black;
                            }
                        }
                    }
                    selectedControls = curSelCtrl.ToArray();
                }
            }
        }

        void plControls_MouseUp( object sender, MouseEventArgs e )
        {
            inselected = false;
            plControls.Refresh();
        }

        void plControls_MouseDown( object sender, MouseEventArgs e )
        {
            inselected = true;
            mousePos = new Point( e.X, e.Y );
        }

        void panel3_Paint( object sender, PaintEventArgs e )
        {
            
            using ( Graphics g = panel3.CreateGraphics() )
            {
                Pen pen = new Pen( Color.Black );
                int x = 0;
                int y = 0;
                int count = 0;
                x = scale;
                while ( x < panel3.Width )
                {
                    if ( ( count % 5 ) == 0 )
                        y = margin;
                    else
                        y = margin / 2;
                    Point ptTop = new Point( x, 0 );
                    Point ptButtom = new Point( x , y );
                    g.DrawLine( pen,ptTop, ptButtom );
                    x = x + scale;
                    count++;
                }
                y = scale;
                count = 0;
                while ( y < panel3.Height )
                {
                    if ( ( count % 5 ) == 0 )
                        x = margin;
                    else
                        x = margin / 2;

                    Point ptTop = new Point( 0, y );
                    Point ptButtom = new Point( x, y );
                    g.DrawLine( pen, ptTop, ptButtom );
                    y = y + scale;
                    count++;
                }
            }
        }

        void txtLocation_ValueChanged( object sender, EventArgs e )
        {
            if ( selectedControls.Length == 0 )
                return;
            NumericUpDown txt = (NumericUpDown)sender;
            if ( txt.Name == txtLocationX.Name )
            {
                selectedControls[0].Left = Convert.ToInt32( txt.Value );
            }
            if ( txt.Name == txtLocationY.Name )
            {
                selectedControls[0].Top = Convert.ToInt32( txt.Value );
            }
        }

        void txtWidth_TextChanged( object sender, EventArgs e )
        {
            if ( selectedControls.Length == 0 )
                return;
            if ( txtWidth.Text.Trim() == "" )
                return;
            if ( Convert.ToInt32( txtWidth.Text ) == 0 )
                return;

            try
            {
                selectedControls[0].Width = Convert.ToInt32( txtWidth.Text );
            }
            catch
            {
                selectedControls[0].Width = 75;
            }
        }

        void txtHeight_TextChanged( object sender, EventArgs e )
        {
            if ( selectedControls.Length == 0 )
                return;
            if ( txtHeight.Text.Trim() == "" )
                return;
            if ( Convert.ToInt32( txtHeight.Text ) == 0 )
                return;

            try
            {
                selectedControls[0].Height = Convert.ToInt32( txtHeight.Text );
            }
            catch
            {
                selectedControls[0].Height = 75;
            }
        }

        void txtWidth_Leave( object sender, EventArgs e )
        {
            if ( selectedControls.Length == 0 )
                return;
            int width = 75;
            if ( txtWidth.Text.Trim() == "" )
                txtWidth.Text = width.ToString();

            try
            {
                selectedControls[0].Width = Convert.ToInt32( txtWidth.Text );
            }
            catch
            {
                selectedControls[0].Width = 75;
            }
        }

        void txtHeight_Leave( object sender, EventArgs e )
        {
            if ( selectedControls.Length == 0 )
                return;
            int height = 23;
            if ( txtHeight.Text.Trim() == "" )
                txtHeight.Text = height.ToString();

            try
            {
                selectedControls[0].Height = Convert.ToInt32( txtHeight.Text );
            }
            catch
            {
                selectedControls[0].Height = 23;
            }
        }

        private void btnOk_Click( object sender, EventArgs e )
        {
            locationSettings = new List<FieldConfig>();

            foreach ( Control ctrl in this.plControls.Controls )
            {
                FieldConfig config = (FieldConfig)ctrl.Tag;
                config.LOCATION_X = ctrl.Left;
                config.LOCATION_Y = ctrl.Top;
                config.GRID_COL_WIDTH = dgvColumn.Columns[config.FIELD_DB_NAME].Width;

                locationSettings.Add( config );
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            if ( locationSettings != null )
                locationSettings = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnToLeft_Click( object sender, EventArgs e )
        {
            SnapControl( 0 );
        }

        private void btnToTop_Click( object sender, EventArgs e )
        {
            SnapControl( 1 );
        }

        private void btnSameSize_Click( object sender, EventArgs e )
        {
            SnapControl( 2 );
        }

        private void btnSameHInterval_Click( object sender, EventArgs e )
        {
            //垂直间距
            SnapControl( 4 );
        }

        private void btnSameVInterval_Click( object sender, EventArgs e )
        {
            //水平间距
            SnapControl( 3 );
        }

        private void chkTabIndex_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkTabIndex.Checked )
            {
                currentTabIndex = 0;
                tabeIndexEditing = true;
            }
            else
            {
                tabeIndexEditing = false;
            }
        }
        

    }
}
