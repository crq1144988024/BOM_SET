using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
    public partial class BOM_output_plan : Skin_Metro
    {
        public BOM_output_plan()
        {
            InitializeComponent();
        }
        BOM_Out_put_tools tool = new BOM_Out_put_tools();
        private void BOM_output_plan_Load(object sender, EventArgs e)
        {
           
            tool.find_bom_project(skinDataGridView_BOM_project,false);
        }
        /// <summary>
        /// 显示全部计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox1_find_condition_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1_find_condition.Checked)
            {
                tool.find_bom_project(skinDataGridView_BOM_project, true);
            }
            else
            {
                tool.find_bom_project(skinDataGridView_BOM_project, false);
            }
        }

        private void skinDataGridView_BOM_project_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tool.read_bom_all(skinDataGridView_BOM_project, e.RowIndex, e.ColumnIndex, DataGridView_BOM_list);
            tool.chech_audit(skinDataGridView_BOM_project, e.RowIndex, e.ColumnIndex);
          
        }

        private void DataGridView_BOM_list_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void DataGridView_BOM_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }
    }
}
