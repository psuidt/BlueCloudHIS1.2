using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace HIS_BaseManager
{
    public partial class FrmGBDictionary : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private DataTable tbGb_Item_Name;
        private DataTable tbGb_Sub_Item;

        public FrmGBDictionary(string chinesename)
        {
            InitializeComponent();
            this.Text = chinesename;
            this.FormTitle = chinesename;
        }

        private void bind_tritem()
        {
            
            try
            {
                TreeNode pnode = new TreeNode();
                pnode.Text = "国标项目";
                pnode.Tag = null;
                pnode.ImageIndex = 14;

                for ( int i = 0 ; i < tbGb_Item_Name.Rows.Count ; i++ )
                {
                    TreeNode node = new TreeNode();
                    node.Text = tbGb_Item_Name.Rows[i]["ITEM_NAME"].ToString( );
                    node.Tag = tbGb_Item_Name.Rows[i]["CODE"].ToString( );
                    node.ImageIndex = 15;
                    pnode.Nodes.Add(node);

                }
                this.tvitem.Nodes.Add(pnode);
            }
            catch (Exception err)
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void FrmGBDictionary_Load(object sender, EventArgs e)
        {
            tbGb_Item_Name = HIS.Base_BLL.BaseDataReader.GB_ITEM_NAME;
            tbGb_Sub_Item = HIS.Base_BLL.BaseDataReader.GB_SUB_ITEM;
            this.bind_tritem();

           
        }


        private void tvitem_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                return;
            }
           
            try
            {
                string code = this.tvitem.SelectedNode.Tag.ToString();
               
                DataRow[] drs = tbGb_Sub_Item.Select( "CODE='"+code.Trim()+"'" );
                this.lvsubitem.Items.Clear();
                for ( int i = 0 ; i < drs .Length; i++ )
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = drs[i]["sub_code"].ToString( );
                    item.SubItems.Add( drs[i]["SUB_ITEM_NAME"].ToString( ) );
                    item.ImageIndex = 11;
                    this.lvsubitem.Items.Add(item);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            

        }

        private void toolStripButton1_Click( object sender, EventArgs e )
        {
            this.Close();
        }

       

    }
}
