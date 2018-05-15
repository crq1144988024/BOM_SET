
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public partial class Form_supplies_managemengt : Skin_Metro
    {
        Globle_add_supplies_manegement add = new Globle_add_supplies_manegement();
        public Form_supplies_managemengt()
        {
            InitializeComponent();
        }

        private void Form_supplies_managemengt_Load(object sender, EventArgs e)
        {
            add.find_unchecked(skinDataGridView_unchecked);
            add.find_checked(skinDataGridView_checked);
        }
        /// <summary>
        /// 审核选中项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_request_offer_Click(object sender, EventArgs e)
        {
            if (add.add_bom_all(skinDataGridView_unchecked))
            {
                MessageBox.Show("审核成功！");

                DialogResult result = MessageBox.Show("是否导出刚审核的物料？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    int check_num_ = 13;
                    excel.PrintReporter(null, "未审核的新增物料", skinDataGridView_unchecked, check_num_);
                }

                add.find_unchecked(skinDataGridView_unchecked);
                add.find_checked(skinDataGridView_checked);

             

                   
            }
        }

        Excel_output excel = new Excel_output();
        /// <summary>
        /// 导出已审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_OUTPUT_EXCEL_checked_Click(object sender, EventArgs e)
        {
            int check_num_ = 14;
            excel.PrintReporter(null, "已审核的新增物料", skinDataGridView_checked, check_num_);
        }
        /// <summary>
        /// 导出未审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_OUTPUT_EXCEL_unchecked_Click(object sender, EventArgs e)
        {
            int check_num_ = 11;
            excel.PrintReporter(null, "未审核的新增物料", skinDataGridView_unchecked, check_num_);
        }
    }
}
