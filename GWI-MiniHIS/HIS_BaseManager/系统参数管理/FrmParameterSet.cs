using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.Base_BLL.Enums;
using HIS.Base_BLL;


namespace HIS_BaseManager
{
    public partial class FrmParameterSet : BaseMainForm
    {
        private ParameterController parameterController;

        public FrmParameterSet(string FormText)
        {
            InitializeComponent();
            this.Text = FormText;
            this.FormTitle = FormText;

        }

        private void tvwModels_AfterSelect( object sender, TreeViewEventArgs e )
        {
            if ( e.Node.Tag != null )
            {
                UserControl uc = null;
                ParameterCatalog catalog = CurrentSelectCatalog;
                switch ( catalog )
                {
                    case ParameterCatalog.门诊经管:
                        uc = new UC_MZJG();
                        ( (UC_MZJG)uc ).AllowEditDocPresRange = parameterController.AllowEditDocPresItems;
                        break;
                    case ParameterCatalog.住院经管:
                        uc = new UC_ZYJG();
                        break;
                    case ParameterCatalog.门诊医生站:
                        uc = new UC_MZYS();
                        break;
                    case ParameterCatalog.住院医生站:
                        uc = new UC_ZYYS();
                        break;
                    case ParameterCatalog.住院护士站:
                        uc = new UC_ZYHS();
                        break;
                    case ParameterCatalog.药品管理:
                        uc = new UC_YPGL();
                        break;
                }
                try
                {
                    ( (IParameter)uc ).Parameters = parameterController.ParameterCollect[catalog];
                    plUI.Controls.Clear();
                    plUI.Controls.Add( uc );
                    uc.Dock = DockStyle.Fill;
                }
                catch ( Exception err )
                {
                    MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
            else
            {
                plUI.Controls.Clear();
            }
        }

        private ParameterCatalog CurrentSelectCatalog
        {
            get
            {
                if ( tvwModels.SelectedNode != null )
                {
                    if ( tvwModels.SelectedNode.Tag != null )
                    {
                        ParameterCatalog catalog = (ParameterCatalog)tvwModels.SelectedNode.Tag;
                        return catalog;
                    }
                    else
                    {
                        throw new InvalidOperationException( "没有指定分类,如果不指指定分类,请勾选上【全部】选项" );
                    }
                }
                else
                    throw new InvalidOperationException( "没有指定分类,如果不指指定分类,请勾选上【全部】选项" );
            }
        }

        private void FrmParameterSet_Load( object sender, EventArgs e )
        {
            parameterController = new ParameterController();

            CreateCatalogTree();

            
        }
        /// <summary>
        /// 创建功能分类树
        /// </summary>
        private void CreateCatalogTree()
        {
            TreeNode ndRoot = new TreeNode( "功能分类目录", 0, 0 );
            tvwModels.Nodes.Add( ndRoot );
            foreach ( object obj in Enum.GetValues( typeof( ParameterCatalog ) ) )
            {
                TreeNode catalogNode = new TreeNode();
                ParameterCatalog catalog = (ParameterCatalog)obj;
                catalogNode.Text = catalog.ToString();
                catalogNode.ImageIndex = 1;
                catalogNode.SelectedImageIndex = 2;
                catalogNode.Tag = catalog;
                catalogNode.Expand();
                ndRoot.Nodes.Add( catalogNode );
            }
            tvwModels.ExpandAll();
        }

        private void btnCheck_Click( object sender, EventArgs e )
        {
            try
            {
                if ( chkAll.Checked )
                {
                    parameterController.Initialize();
                }
                else
                {
                    parameterController.Initialize( CurrentSelectCatalog );
                }
                MessageBox.Show( "参数检测完毕！", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            try
            {
                if ( chkAll.Checked )
                {
                    parameterController.UpdateConfig();
                }
                else
                {
                    parameterController.UpdateConfig( CurrentSelectCatalog );
                }
                MessageBox.Show( "参数保存成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btnRefresh_Click( object sender, EventArgs e )
        {
            parameterController = new ParameterController();
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        

        
    }
}
