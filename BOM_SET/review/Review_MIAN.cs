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
namespace BOM_SET.review
{
    public partial class Review_MIAN : Skin_Metro
    {
        Class_review_tools tool = new Class_review_tools();
        public Review_MIAN()
        {
            InitializeComponent();
        }

        private void Review_MIAN_Load(object sender, EventArgs e)
        {

            tool.find_bom_project(skinDataGridView_BOM_project, false);
            tool.find_bom_project(skinDataGridView_BOM_project_2, true);
        }
        /// <summary>
        /// 未审批项目表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView_BOM_project_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tool.read_bom_all(skinDataGridView_BOM_project, e.RowIndex, e.ColumnIndex, DataGridView_BOM_list,false);
            tool.close_bom_all(skinDataGridView_BOM_project, e.RowIndex, e.ColumnIndex, DataGridView_BOM_list);
        
        }
        /// <summary>
        /// 审批项目表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView_BOM_project_2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tool.read_bom_all(skinDataGridView_BOM_project_2, e.RowIndex, e.ColumnIndex, DataGridView_BOM_list_2,true);
        }
        /// <summary>
        /// 未审核  更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_BOM_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool zero_ = false;
            tool. update_bom_all(DataGridView_BOM_list, e.RowIndex, e.ColumnIndex,out zero_);
            if (zero_)
            {
                MessageBox.Show("本BOM单审核完成！即将刷新！");
                tool.find_bom_project(skinDataGridView_BOM_project, false);
                DataGridView_BOM_list.Rows.Clear();
            }
           
          //  tool.close_bom_all(skinDataGridView_BOM_project, e.RowIndex, e.ColumnIndex, DataGridView_BOM_list);
        }
    }
}
