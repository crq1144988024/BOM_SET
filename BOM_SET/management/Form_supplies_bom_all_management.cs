using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using CCWin;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using System.Data.Linq;
using BOM_SET.sql;
using System.Data.Linq.SqlClient;
using BOM_SET.Tools;
using static BOM_SET.Tools.Global1;

namespace BOM_SET.management
{
    public partial class Form_supplies_bom_all_management : Skin_Metro
    {
        public Form_supplies_bom_all_management()
        {
            InitializeComponent();
        }
        BOM_ALL_managemengt BOM_ALL_TOOL = new BOM_ALL_managemengt();
        private void Form_supplies_bom_all_management_Load(object sender, EventArgs e)
        {
            BOM_ALL_TOOL.codeA(comboxcode_A, comboxcode_B, comboxcode_C);
           // groupBox2.Enabled = false;
        }

        private void comboxcode_B_SelectedIndexChanged(object sender, EventArgs e)
        {
            BOM_ALL_TOOL.codeC(comboxcode_A, comboxcode_B, comboxcode_C);
        }

        private void comboxcode_C_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void skinButton6_Click(object sender, EventArgs e)
        {
            skinDataGridView_BOM_ALL.Rows.Clear();
            BOM_ALL_TOOL.search_datagridview(skinDataGridView_BOM_ALL, CheckBox1_find_condition, Textbox_find.Text, comboxcode_A, comboxcode_B, comboxcode_C);
        }

        private void comboxcode_A_SelectedIndexChanged(object sender, EventArgs e)
        {
            BOM_ALL_TOOL.codeB(comboxcode_A, comboxcode_B, comboxcode_C);
        }
        int hisfind_ = 0;
     /// <summary>
     /// 选择表中全部
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// 显示全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
           
            if (checkBox2.Checked == true)
            {
                groupBox1.Enabled = false;
                //groupBox2.Enabled = true;

                BOM_ALL_TOOL.display_all_bom(skinDataGridView_BOM_ALL);
                hisfind_ = 1;


            }
            else
            {
                skinDataGridView_BOM_ALL.Rows.Clear();
                groupBox1.Enabled = true;
                //groupBox2.Enabled = false;
                hisfind_ = 2;
            }
        }

        private void skinDataGridView_BOM_ALL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_now = 0;
            bool update = BOM_ALL_TOOL.chech_audit(skinDataGridView_BOM_ALL, e.RowIndex, e.ColumnIndex, out row_now);
            bool delete = BOM_ALL_TOOL.delete_database(skinDataGridView_BOM_ALL, e.RowIndex, e.ColumnIndex, out row_now);
            if (update)
            {
                if (hisfind_ == 1)
                {
                    ///刷新重新定位
                    //skinDataGridView_BOM_ALL.Rows.Clear();
                    int i =skinDataGridView_BOM_ALL.FirstDisplayedScrollingRowIndex;
                    BOM_ALL_TOOL.display_all_bom(skinDataGridView_BOM_ALL);//刷新显示
                    skinDataGridView_BOM_ALL.FirstDisplayedScrollingRowIndex=i;//定位
                    BOM_ALL_TOOL.location(skinDataGridView_BOM_ALL, row_now, 0);

                }
            }
           else  if (delete)
            {
               
                int i = skinDataGridView_BOM_ALL.FirstDisplayedScrollingRowIndex;
                BOM_ALL_TOOL.display_all_bom(skinDataGridView_BOM_ALL);//刷新显示
                try
                {
                    skinDataGridView_BOM_ALL.FirstDisplayedScrollingRowIndex = i;
                }
                catch
                {

                }
               
            }
           
          

        }

        private void skinButton_up_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (skinDataGridView_BOM_ALL.Rows.Count > 32)
            {
                int i = skinDataGridView_BOM_ALL.FirstDisplayedScrollingRowIndex;
                if (i >= 0)
                {
                    int u = 0;
                    u = i - 32;
                    if (u < 0) { u = 0; }
                    skinDataGridView_BOM_ALL.FirstDisplayedScrollingRowIndex = u;
                }
            }
           
            //}
            //catch
            //{

            //}
           
          
        }

        private void skinButton_down_Click(object sender, EventArgs e)
        {
            //try
            //{
            if( skinDataGridView_BOM_ALL.Rows.Count > 32)
            {
                int i = skinDataGridView_BOM_ALL.FirstDisplayedScrollingRowIndex;
                if (i >= 0)
                {
                    int u = 0;
                    u = i + 32;
                    if (u >= skinDataGridView_BOM_ALL.Rows.Count - 1) { u = skinDataGridView_BOM_ALL.Rows.Count - 1; }
                    skinDataGridView_BOM_ALL.FirstDisplayedScrollingRowIndex = u;
                }
            }
                
            //}
            //catch
            //{

            //}
           
        }
    }
}
