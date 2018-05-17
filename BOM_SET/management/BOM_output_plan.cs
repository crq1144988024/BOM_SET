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
            string str_0 = "当次数量";
            string str_1 = "全部数量";
            tool.find_bom_project(skinDataGridView_BOM_project,false);
           
            skinComboBox1.Items.Add(new ComboxItem(str_1, str_1));//bom
            skinComboBox1.Items.Add(new ComboxItem(str_0, str_0));
            skinComboBox1.SelectedIndex = 0;

           skinComboBox2.Items.Add(new ComboxItem(str_0, str_0));//采购
            skinComboBox2.Items.Add(new ComboxItem(str_1, str_1));
            skinComboBox2.SelectedIndex = 0;
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
                DialogResult result = MessageBox.Show("是否显示上次提取的数量？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    BOM_Out_put_tools.CheckBox1_find_condition_display_old_count = true;
                }
                else
                {
                    BOM_Out_put_tools.CheckBox1_find_condition_display_old_count = false;
                }

                  BOM_Out_put_tools.CheckBox1_find_condition = true;
                tool.find_bom_project(skinDataGridView_BOM_project, true);
                DataGridView_BOM_list.Rows.Clear();
            }
            else
            {
                BOM_Out_put_tools.CheckBox1_find_condition = false;
                tool.find_bom_project(skinDataGridView_BOM_project, false);
                DataGridView_BOM_list.Rows.Clear();
            }
        }

        private void skinDataGridView_BOM_project_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //for (int i = 0; i < skinDataGridView_BOM_project.Rows.Count; i++)
            //{
            //    this.skinDataGridView_BOM_project.Rows[i].Cells["选中"].Value = 0;
            //}
           
            tool.read_bom_all(skinDataGridView_BOM_project, e.RowIndex, e.ColumnIndex, DataGridView_BOM_list);
            tool.chech_audit(skinDataGridView_BOM_project, e.RowIndex, e.ColumnIndex, DataGridView_BOM_list);
            tool.select_one(skinDataGridView_BOM_project, e.RowIndex, e.ColumnIndex);


        }

        private void DataGridView_BOM_list_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void DataGridView_BOM_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }
        /// <summary>
        ///BOM表格生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton3_Click(object sender, EventArgs e)
        {
            int i_cell2 = 7;
            bool checked_temp = false;
            int ID_Colunm = 0;//ID
            string cell_value = "";
            string project_name = "";
            string num_st = "";
            string num_times = "";
           if(str_1_combox.Length < 2)
            {
                MessageBox.Show("请先选择要导出数量种类！");

            }


            for (int i_d_find = 0; i_d_find < skinDataGridView_BOM_project.Rows.Count; i_d_find++)
            {

         
                DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)skinDataGridView_BOM_project.Rows[i_d_find].Cells[i_cell2];

                if (chkBoxCell != null && ((bool)chkBoxCell.EditingCellFormattedValue == true || (bool)chkBoxCell.FormattedValue == true))
                {
                    checked_temp = true;
                    try
                    {
                        cell_value = skinDataGridView_BOM_project.Rows[i_d_find].Cells[ID_Colunm].Value.ToString();

                        ID_Colunm = Convert.ToInt32(cell_value);
                         project_name = check_value(skinDataGridView_BOM_project.Rows[i_d_find].Cells[1].Value);
                         num_st = check_value(skinDataGridView_BOM_project.Rows[i_d_find].Cells[3].Value);
                         num_times = check_value(skinDataGridView_BOM_project.Rows[i_d_find].Cells[4].Value);
                    }
                    catch { }
                
                }

              }
            if (checked_temp == false)
            {
                MessageBox.Show("请先选择要导出的一行！");
                return;
            }
            else
            {
               


                //int ID = Convert.ToInt32(cell_value);
                if (!tool.finad_bom_temp(DataGridView_BOM_list, ID_Colunm)) { return ; }

                DialogResult result1 = MessageBox.Show("确定导出当前BOM？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result1 == DialogResult.OK)
                {


                    if (tool.bom_out_put_excel(DataGridView_BOM_list, project_name, num_st, num_times))
                    {
                        MessageBox.Show("导出BOM成功！");
                    }
                }
            }

       

        }
        /// <summary>
        /// 生成采购单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton11_Click(object sender, EventArgs e)
        {

            int i_cell2 = 7;
            bool checked_temp = false;
            int ID_Colunm = 0;//ID
            string cell_value = "";
            string project_name = "";
            string num_st = "";
            string num_times = "";
            if (str_2_combox.Length < 2)
            {
                MessageBox.Show("请先选择要导出数量种类！");

            }


            for (int i_d_find = 0; i_d_find < skinDataGridView_BOM_project.Rows.Count; i_d_find++)
            {


                DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)skinDataGridView_BOM_project.Rows[i_d_find].Cells[i_cell2];

                if (chkBoxCell != null && ((bool)chkBoxCell.EditingCellFormattedValue == true || (bool)chkBoxCell.FormattedValue == true))
                {
                    checked_temp = true;
                    try
                    {
                        cell_value = skinDataGridView_BOM_project.Rows[i_d_find].Cells[ID_Colunm].Value.ToString();

                        ID_Colunm = Convert.ToInt32(cell_value);
                        project_name = check_value(skinDataGridView_BOM_project.Rows[i_d_find].Cells[1].Value);
                        num_st = check_value(skinDataGridView_BOM_project.Rows[i_d_find].Cells[3].Value);
                        num_times = check_value(skinDataGridView_BOM_project.Rows[i_d_find].Cells[4].Value);
                    }
                    catch { }

                }

            }
            if (checked_temp == false)
            {
                MessageBox.Show("请先选择要导出的一行！");
                return;
            }
            else
            {
                if (!tool.finad_bom_temp(DataGridView_BOM_list, ID_Colunm)) { return; }

                DialogResult result2 = MessageBox.Show("确定导出当前BOM的采购单？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result2 == DialogResult.OK)
                {

                    tool.shopping_out_put_excel(project_name, num_st, num_times, DataGridView_BOM_list);

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (BOM_Out_put_tools.shopping_ed)
            {

            }
        }
        string str_1_combox = " ";
        string str_2_combox = " ";
        /// <summary>
        /// BOM数量选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //for (int i = 0; i < skinComboBox1.Items.Count; i++)
            //{
            //    string strDict = ((ComboxItem)skinComboBox1.Items[i]).Values.ToString().Trim();
            //}
            if (((ComboxItem)skinComboBox1.SelectedItem).Values != null) { str_1_combox = ((ComboxItem)skinComboBox1.SelectedItem).Values.Trim(); }
          


            if (str_1_combox == "当次数量")
            {
                BOM_Out_put_tools.bom_out_excel_temp_num = true;
            }
            else
            {
                BOM_Out_put_tools.bom_out_excel_temp_num = false;
            }


        }
      
        /// <summary>
        /// 采购单数量选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void skinComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
       
          if (((ComboxItem)skinComboBox2.SelectedItem).Values != null) { str_2_combox = ((ComboxItem)skinComboBox2.SelectedItem).Values.Trim(); }


            if (str_2_combox == "全部数量")
            {
                BOM_Out_put_tools.shop_out_excel_temp_num = false;
            }
            else
            {
                BOM_Out_put_tools.shop_out_excel_temp_num = true;

            }
        }
        public string check_value(object str)
        {
            string str0 = " ";

            if (str != null) { str0 = str.ToString().Trim(); }
            str = str0;
            return str0;
        }
       
    }
    public class ComboxItem
    {
        private string text;
        private string values;

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public string Values
        {
            get { return this.values; }
            set { this.values = value; }
        }

        public ComboxItem(string _Text, string _Values)
        {
            Text = _Text;
            Values = _Values;
        }


        public override string ToString()
        {
            return Text;
        }
    }
}
