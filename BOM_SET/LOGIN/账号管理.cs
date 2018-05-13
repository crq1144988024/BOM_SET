using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOM_SET.sql;
using System.Data.Linq.SqlClient;
using BOM_SET.Tools;
using static BOM_SET.Tools.Global1;
using System.Xml.Linq;
using CCWin;
using System.IO;
using System.Threading;

namespace BOM_SET.LOGIN
{
    public partial class 账号管理 : Skin_DevExpress
    {
        DataClasses_LoginDataContext DATACALSSES = new DataClasses_LoginDataContext();
        public 账号管理()
        {
            InitializeComponent();
        }

        private void 账号管理_Load(object sender, EventArgs e)
        {

            refresh();

        }
        public void refresh()
        {
            ID convert = new ID();
            skinDataGridView1.Rows.Clear();
            var q_A = from A in DATACALSSES.Login

                          /// where A.NAME.Trim() == ComboBox1.Text.Trim()
                          //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                          //where c.代码.Contains(sort_keywords)
                          //  where A.分类代码A
                      select A;
            int row = 0;

            foreach (var people in q_A)
            {
                skinDataGridView1.Rows.Add();
                skinDataGridView1.Rows[row].Cells[0].Value = people.ID;
                skinDataGridView1.Rows[row].Cells[1].Value = people.NAME;
                skinDataGridView1.Rows[row].Cells[2].Value = people.password;

                string combox2_text = "";
                DataGridViewComboBoxCell combox2 = (DataGridViewComboBoxCell)skinDataGridView1.Rows[row].Cells[3];
                //1 操作者
                //2管理员
                //3数据库管理员
                convert.ID_output_Permission(Convert.ToInt32(people.Permission), out combox2_text);
                combox2.Value = combox2_text;


                string combox3_text = "";
                DataGridViewComboBoxCell combox3 = (DataGridViewComboBoxCell)skinDataGridView1.Rows[row].Cells[4];
                //1电气设计
                //2机械设计
                //3物料管理员
                //4采购
                //5电气审核
                //6机械审核

                convert.ID_output_SORT(Convert.ToInt32(people.SORT), out combox3_text);
                combox3.Value = combox3_text;

                if (Convert.ToInt32(people.status) == 1)
                {
                    skinDataGridView1.Rows[row].Cells[5].Value = "在线 ";
                    skinDataGridView1.Rows[row].Cells[5].Style.BackColor = Color.Green;
                }
                else
                {
                    skinDataGridView1.Rows[row].Cells[5].Value = "离线 ";
                    skinDataGridView1.Rows[row].Cells[5].Style.BackColor = Color.Red;
                }



                DataGridViewButtonCell button = (DataGridViewButtonCell)skinDataGridView1.Rows[row].Cells[6];

                button.Value = "删除";
                row++;

            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = skinDataGridView1.Rows.Count;
            if (i <= 0) { return; }
            string cell_value = "";

            string nowcellname = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
               
                try
                {
                   
                    nowcellname = skinDataGridView1.Columns[e.ColumnIndex].HeaderText;

                    cell_value = skinDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                  
                }
                catch { }

                try
                {
                    if (skinDataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
                    {
                        DataGridViewRow row = skinDataGridView1.Rows[e.RowIndex];
                        skinDataGridView1.Rows.Remove(row);
                    }

                    int ID_ = Convert.ToInt32(cell_value);
                    if (nowcellname.Trim () == "删除")
                    {
                       
                            for (int i_d_find = 0; i_d_find < i; i_d_find++)
                        {

                            if (skinDataGridView1.Rows[i_d_find].Cells[0].Value.ToString().Trim() == ID_.ToString().Trim())
                            {
                                DialogResult result = MessageBox.Show("确定要删除该用户吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                if (result == DialogResult.OK)
                                {
                                    DataGridViewRow row = skinDataGridView1.Rows[e.RowIndex];
                                    skinDataGridView1.Rows.Remove(row);



                                    var q_A =( from A in DATACALSSES.Login

                                                   where A.NAME.Trim() == row.Cells[1].Value.ToString () .Trim()
                                                  //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                                  //where c.代码.Contains(sort_keywords)
                                                  //  where A.分类代码A
                                              select A).First();
                                 
                                    DATACALSSES.Login.DeleteOnSubmit(q_A);
                                    DATACALSSES.SubmitChanges();

                                




                                    MessageBox.Show("删除成功！");
                                    return;

                                }
                            }
                        }

                    }
               }catch { }
                
                }
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton2_Click(object sender, EventArgs e)
        {
            skinDataGridView1.Rows.Add();
            DataGridViewButtonCell button = (DataGridViewButtonCell)skinDataGridView1.Rows[skinDataGridView1.Rows.Count-1].Cells[6];

            button.Value = "删除";
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton1_Click(object sender, EventArgs e)
        {

            for (int k = 0; k < skinDataGridView1.Rows.Count; k++)
            {
                for(int n = 1; n < 4; n++)
                {
                    if (skinDataGridView1.Rows[k].Cells[n].Value == null) { MessageBox.Show("请把信息填写完整!"); return; }
                    if (string.IsNullOrEmpty(skinDataGridView1.Rows[k].Cells[n].Value.ToString())) { MessageBox.Show("请把信息填写完整!"); return; }
                    if (skinDataGridView1.Rows[k].Cells[n].Value.ToString().Count() == 0) { MessageBox.Show("请把信息填写完整!"); return; }
                }
                
            }


                ID convert_1 = new ID();
            var q_A = from A in DATACALSSES.Login

                          // where A.NAME.Trim() == ComboBox1.Text.Trim()
                          //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                          //where c.代码.Contains(sort_keywords)
                          //  where A.分类代码A
                      select A;
            int row = 0;

            foreach (var people in q_A)
            {
                if (skinDataGridView1.Rows[row].Cells[0].Value == null) { continue; }
                    if (people.ID== Convert .ToUInt32 ( skinDataGridView1.Rows[row].Cells[0].Value.ToString()))
                {
                    DataGridViewComboBoxCell combox2 = (DataGridViewComboBoxCell)skinDataGridView1.Rows[row].Cells[3];
                    DataGridViewComboBoxCell combox3 = (DataGridViewComboBoxCell)skinDataGridView1.Rows[row].Cells[4];

                    people.NAME = skinDataGridView1.Rows[row].Cells[1].Value.ToString();
                    people.password = skinDataGridView1.Rows[row].Cells[2].Value.ToString();
                    int per = 1;
                    convert_1.ID_output_Permission(combox2.Value.ToString().Trim(), out per);
                    people.Permission = per;


                    int sor = 1;
                    convert_1.ID_output_SORT(combox3.Value.ToString().Trim(), out sor);
                    people.SORT = sor;
                    row++;
                }
              
            }
            DATACALSSES.SubmitChanges();
           

            if (skinDataGridView1.Rows.Count > row)
            {
                for (int k=row ;k < skinDataGridView1.Rows.Count; k++)
                {
                    DataGridViewComboBoxCell combox2 = (DataGridViewComboBoxCell)skinDataGridView1.Rows[row].Cells[3];
                    DataGridViewComboBoxCell combox3 = (DataGridViewComboBoxCell)skinDataGridView1.Rows[row].Cells[4];

                    int per = 1;
                    convert_1.ID_output_Permission(combox2.Value.ToString().Trim(), out per);
                 


                    int sor = 1;
                    convert_1.ID_output_SORT(combox3.Value.ToString().Trim(), out sor);
                  
                   

                    var newCustomer = new Login
                    {
                        NAME = skinDataGridView1.Rows[row].Cells[1].Value.ToString(),
                        password = skinDataGridView1.Rows[row].Cells[2].Value.ToString(),
                        Permission= per,
                         SORT  = sor

                    };
                    DATACALSSES.Login. InsertOnSubmit(newCustomer);
                    DATACALSSES.SubmitChanges();

                    row++;
                }
               
            }


            refresh();
        }
    }
}
