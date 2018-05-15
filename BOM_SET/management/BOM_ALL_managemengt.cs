using BOM_SET.sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOM_SET.management
{
    public class BOM_ALL_managemengt
    {
        DataClasses_Code_ABCDataContext Code_ABC = new DataClasses_Code_ABCDataContext();
        /// <summary>
        /// 有关第一级菜单加载
        /// </summary>
        public void codeA(ComboBox comboxcode_A, ComboBox comboxcode_B, ComboBox comboxcode_C)
        {
            comboxcode_A.Items.Clear();

            comboxcode_B.Items.Clear();
            comboxcode_B.Text = "";

            comboxcode_C.Items.Clear();
            comboxcode_C.Text = "";
            var q_A = from A in Code_ABC.Table_structure_bom

                          //where c.分类代码A == codeA
                          //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                          //where c.代码.Contains(sort_keywords)
                          //  where A.分类代码A
                      select A;
            ///查重

            List<string> list = new List<string>() { };

            foreach (var li in q_A)
            {
                list.Add(li.分类代码A);
            }
            var newlist = list.Distinct();

            /////

            int i = 1;
            foreach (var item in newlist)//q.Where(s => s.Hometown == "多家营"))
            {
                ComboboxItem comboxitem = new ComboboxItem();
                comboxitem.Text = item.ToString();
                comboxitem.Value = i;
                comboxcode_A.Items.Add(comboxitem);
                //comboxcode_A.Items[i].

            }




        }
        /// <summary>
        /// 根据A来读取B
        /// </summary>
        public void codeB(ComboBox comboxcode_A, ComboBox comboxcode_B, ComboBox comboxcode_C)
        {
            if (comboxcode_A.SelectedText == null) return;
            comboxcode_B.Items.Clear();
            comboxcode_B.Text = "";

            comboxcode_C.Items.Clear();
            comboxcode_C.Text = "";

            string codeA = comboxcode_A.SelectedItem.ToString();
            var q_B = from B in Code_ABC.Table_structure_bom

                      where B.分类代码A == codeA
                      //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                      //where B.分类代码A.Contains(codeA)
                      select B;
            int i = 1;
            ///查重

            List<string> list = new List<string>() { };

            foreach (var li in q_B)
            {
                list.Add(li.分类代码B.ToString().Trim().Substring(1));
            }
            var newlist = list.Distinct();


            foreach (var item in newlist)//q.Where(s => s.Hometown == "多家营"))
            {
                ComboboxItem comboxitem = new ComboboxItem();
                comboxitem.Text = item.ToString();
                comboxitem.Value = i;
                comboxcode_B.Items.Add(comboxitem);

                i++;
            }
        }
        /// <summary>
        /// 根据A  B来读取C
        /// </summary>
        /// <param name="ws"></param>
        public void codeC(ComboBox comboxcode_A, ComboBox comboxcode_B, ComboBox comboxcode_C)
        {
            if (comboxcode_A.SelectedText == null | comboxcode_B.SelectedText == null) return;
            comboxcode_C.Items.Clear();
            comboxcode_C.Text = "";
            string codeA = comboxcode_A.SelectedItem.ToString();
            string codeB = "." + comboxcode_B.SelectedItem.ToString();

            var q_C = from C in Code_ABC.Table_structure_bom

                      where C.分类代码A == codeA && C.分类代码B == codeB
                      //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                      //where B.分类代码A.Contains(codeA)
                      select C;
            int i = 1;
            ///查重

            List<string> list = new List<string>() { };

            foreach (var li in q_C)
            {



                list.Add(li.分类代码C);


            }
            var newlist = list.Distinct();



            foreach (var item in newlist)
            {
                ComboboxItem comboxitem = new ComboboxItem();
                comboxitem.Text = item.ToString();
                comboxitem.Value = i;
                comboxcode_C.Items.Add(comboxitem);

                i++;
            }
        }
        DataClasses1DataContext data_bom = new DataClasses1DataContext();
        List<string> list_ID_FIND = new List<string>();
        List<string[]> list0_all = new List<string[]>() { };
        ////
        public void search_datagridview(DataGridView datagridview_1, CheckBox CheckBox1_find_condition, string Textbox_find, ComboBox comboxcode_A, ComboBox comboxcode_B, ComboBox comboxcode_C)
        {
            string find_condition_text = Textbox_find.Trim();
            List<string[]> list0 = new List<string[]>() { };
            if (CheckBox1_find_condition.Checked == false)
            {
                if (find_condition_text == "") { return; }
                var q_abc_text = from t in data_bom.Table_bom_all

                                     //  where a.代码.Substring(0,3) == codeA && a.d == codeB
                                     //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                     //where t.代码.Contains(find_condition_text) || t.价格.ToString().Contains(find_condition_text) || t.全名.Contains(find_condition_text)
                                     //|| t.名称.Contains(find_condition_text) || t.品牌.Contains(find_condition_text) || t.图片.Contains(find_condition_text)
                                     //|| t.审核人.Contains(find_condition_text) || t.技术参数.Contains(find_condition_text) || t.规格型号.Contains(find_condition_text)
                                     //|| t.附件.Contains(find_condition_text)
                                 select t;


                foreach (var li in q_abc_text)
                {
                    string[] strs = new string[] { "", li.ID.ToString(), li.类别, li.代码, li.规格型号, li.名称, li.品牌, li.技术参数, li.价格.ToString(), li.图片, li.资料路径, li.添加者, li.添加日期, li.附件, li.全名 };
                    if ((int)strs[3][0] > 127) { continue; }

                    for (int k = 1; k < 15; k++)
                    {
                        if (strs[k] != null)
                        {
                            if (strs[k].Contains(find_condition_text)) { strs[0] = k.ToString(); list0.Add(strs); break; }
                        }

                    }


                    //if (strs[2].Contains(find_condition_text)) { strs[0] = "2"; list0.Add(strs); return; }
                    //if (strs[3].Contains(find_condition_text)) { strs[0] = "3"; list0.Add(strs); return; }
                    //if (strs[4].Contains(find_condition_text)) { strs[0] = "4"; list0.Add(strs); return; }
                    //if (strs[5].Contains(find_condition_text)) { strs[0] = "5"; list0.Add(strs); return; }
                    //if (strs[6].Contains(find_condition_text)) { strs[0] = "6"; list0.Add(strs); return; }
                    //if (strs[7].Contains(find_condition_text)) { strs[0] = "7"; list0.Add(strs); return; }
                    //if (strs[8].Contains(find_condition_text)) { strs[0] = "8"; list0.Add(strs); return; }
                    //if (strs[9].Contains(find_condition_text)) { strs[0] = "9"; list0.Add(strs); return; }
                    //if (strs[10].Contains(find_condition_text)) { strs[0] = "10"; list0.Add(strs); return; }

                }
                int n = 0;
                foreach (var li in list0)
                {



                    DataGridViewRow row = new DataGridViewRow();
                    datagridview_1.Rows.Add(row);
                    datagridview_1.Rows[n].Cells[0].Value = check_value(li[1]);
                    datagridview_1.Rows[n].Cells[1].Value = check_value(li[2]);
                    datagridview_1.Rows[n].Cells[2].Value = check_value(li[3]);
                    datagridview_1.Rows[n].Cells[3].Value = check_value(li[4]);
                    datagridview_1.Rows[n].Cells[4].Value = check_value(li[5]);
                    datagridview_1.Rows[n].Cells[5].Value = check_value(li[6]);
                    datagridview_1.Rows[n].Cells[6].Value = check_value(li[7]);
                    datagridview_1.Rows[n].Cells[7].Value = check_value(li[8]);
                    datagridview_1.Rows[n].Cells[8].Value = check_value(li[9]);
                    datagridview_1.Rows[n].Cells[9].Value = check_value(li[10]);
                    datagridview_1.Rows[n].Cells[10].Value = check_value(li[11]);
                    datagridview_1.Rows[n].Cells[11].Value = check_value(li[12]);
                    datagridview_1.Rows[n].Cells[12].Value = check_value(li[13]);
                    //datagridview_1.Rows[n].Cells[13].Value = check_value(li[14]);


                    DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)datagridview_1.Rows[n].Cells[13];
                    DataGridViewButtonCell buttonCell14 = (DataGridViewButtonCell)datagridview_1.Rows[n].Cells[14];
                    DataGridViewButtonCell buttonCell15 = (DataGridViewButtonCell)datagridview_1.Rows[n].Cells[15];

                    chkBoxCell.Value = false;
                    buttonCell14.Value = "修改";
                    buttonCell15.Value = "删除";

                    n++;

                }
                list0_all = list0;
                return;
            }
            else { }
            //  if (comboxcode_A.SelectedText == null | comboxcode_B.SelectedText == null) return;
            string codeA = "";
            string codeB = "";
            string codeC = "";

            if (comboxcode_A.SelectedItem != null) { codeA = comboxcode_A.SelectedItem.ToString().Substring(0, 3); }
            if (comboxcode_B.SelectedItem != null) { codeB = "." + comboxcode_B.SelectedItem.ToString().Substring(0, 2); }
            if (comboxcode_C.SelectedItem != null) { codeC = comboxcode_C.SelectedItem.ToString().Substring(0, 1); }



            var q_abc = from a in data_bom.Table_bom_all

                            //  where a.代码.Substring(0,3) == codeA && a.d == codeB
                            //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                            //where B.分类代码A.Contains(codeA)
                        select a;

            List<string[]> list = new List<string[]>() { };


            foreach (var li in q_abc)
            {
                string[] strs = new string[] { li.ID.ToString(), li.类别, li.代码, li.规格型号, li.名称, li.品牌, li.技术参数, li.价格.ToString(), li.图片, li.资料路径, li.添加者, li.添加日期, li.附件, li.全名 };
                //li.代码, li.名称, li.品牌, li.技术参数, li.价格.ToString(), li.图片, li.规格型号, li.附件, li.全名, li.添加者, li.ID.ToString(), li.备注 };
                if ((int)strs[2][0] > 127) { continue; }

                if (codeA != "")
                {
                    if (strs[2].Trim().Length < 3) { continue; }

                    if (strs[2].Trim().Substring(0, 3) == codeA)
                    {


                        if (codeB != "")
                        {
                            if (strs[2].Trim().Length < 6) { continue; }
                            if (strs[2].Trim().Substring(3, 3) == codeB)
                            {
                                if (codeC != "")
                                {
                                    if (strs[2].Trim().Length < 8) { continue; }
                                    if (strs[2].Trim().Substring(6, 1) == ".")
                                    {
                                        if (strs[2].Trim().Substring(7, 1) == codeC)
                                        {
                                            list.Add(strs);
                                        }
                                        else { }

                                    }
                                    else { if (strs[2].Trim().Substring(6, 1) == codeC) { list.Add(strs); } }
                                }
                                else { list.Add(strs); }
                            }
                        }
                        else { list.Add(strs); }
                    }
                }
                else { list.Add(strs); }


            }
            int i = 0;
            if (list.Count <= 0) { return; }
            var newlist = list.Distinct();

            list0_all = list;
            foreach (var li in newlist)
            {
                bool condition_text = false;
                if (find_condition_text == "")//搜索框为空的时候
                {
                    condition_text = true;

                }
                else
                {

                    foreach (var str in li)//搜索框不为空的时候 遍历string[]每个字符串 看看是否有关键字
                    {
                        if (String.IsNullOrEmpty(str) || str == "") { continue; }
                        if (str.Contains(find_condition_text))
                        {

                            condition_text = true;
                            break;
                        }
                    }
                }


                if (condition_text == true)
                {
                    //li.ID.ToString(), li.类别, li.代码, li.规格型号, li.名称, li.品牌, li.技术参数, li.备注,li.价格.ToString(),  li.图片, li.资料路径, li.添加者, li.添加日期, li.附件, li.全名 }
                    DataGridViewRow row = new DataGridViewRow();
                    datagridview_1.Rows.Add(row);
                    if (li[0] != "") { datagridview_1.Rows[i].Cells[0].Value = li[0]; }//ID
                    if (li[1] != "") { datagridview_1.Rows[i].Cells[1].Value = li[1]; }//类别
                    if (li[2] != "") { datagridview_1.Rows[i].Cells[2].Value = li[2]; }//代码
                    if (li[3] != "") { datagridview_1.Rows[i].Cells[3].Value = li[3]; }//规格型号
                    if (li[4] != "") { datagridview_1.Rows[i].Cells[4].Value = li[4]; }//物料名称
                    if (li[5] != "") { datagridview_1.Rows[i].Cells[5].Value = li[5]; }//品牌
                    if (li[6] != "") { datagridview_1.Rows[i].Cells[6].Value = li[6]; }//技术参数
                    if (li[7] != "") { datagridview_1.Rows[i].Cells[7].Value = li[7]; }//备注

                    if (li[8] != "") { datagridview_1.Rows[i].Cells[8].Value = li[8]; }//价格
                    if (li[9] != "") { datagridview_1.Rows[i].Cells[9].Value = li[9]; }//图片
                    if (li[10] != "") { datagridview_1.Rows[i].Cells[10].Value = li[10]; }//资料路径
                    if (li[11] != "") { datagridview_1.Rows[i].Cells[11].Value = li[11]; }//添加者
                    if (li[12] != "") { datagridview_1.Rows[i].Cells[12].Value = li[12]; }//添加日期




                    DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)datagridview_1.Rows[i].Cells[13];
                    DataGridViewButtonCell buttonCell14 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[14];
                    DataGridViewButtonCell buttonCell15 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[15];

                    chkBoxCell.Value = false;
                    buttonCell14.Value = "修改";
                    buttonCell15.Value = "删除";

                    list_ID_FIND.Add(li[1]);
                    i++;
                }
            }
        }
        public string check_value(object str)
        {
            string str0 = " ";

            if (str != null) { str0 = str.ToString().Trim(); }
            str = str0;
            return str0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="datagridview1"></param>
        /// <param name="row_i"></param>
        /// <param name="column_i"></param>
        /// <returns></returns>
        public bool chech_audit(DataGridView datagridview1, int row_i, int column_i, out int out_i)
        {
            int out_i_temp = 0;
            out_i = out_i_temp;
            int ID_Colunm = 0;
            bool bool_temp = false;
            int i = datagridview1.Rows.Count;
            if (i <= 0) { return false; }
            string cell_value = "";

            string nowcellname = "";
            if (row_i >= 0 && column_i >= 0)
            {


                try
                {
                    cell_value = datagridview1.Rows[row_i].Cells[ID_Colunm].Value.ToString();

                    nowcellname = datagridview1.Columns[column_i].HeaderText;
                }
                catch { }

                try
                {

                    int ID = Convert.ToInt32(cell_value);
                    if (nowcellname == "修改")
                    {
                        for (int i_d_find = 0; i_d_find < i; i_d_find++)
                        {

                            if (datagridview1.Rows[i_d_find].Cells[ID_Colunm].Value.ToString().Trim() == ID.ToString().Trim())
                            {
                                DialogResult result = MessageBox.Show("确定修改？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (result == DialogResult.OK)
                                {
                                    int SET_ENABLE = 0;
                                    DataGridViewRow datagridviewRow = datagridview1.Rows[row_i];
                                    updata_database(Convert.ToInt32(ID.ToString().Trim()), SET_ENABLE, datagridviewRow);

                                    out_i_temp = Convert.ToInt32(ID.ToString().Trim());
                                    MessageBox.Show("修改成功！");

                                }

                                //int SET_ENABLE = 0;
                                //int i_cell1 = 11;
                                //string audit_status = ""; if (datagridview1.Rows[row_i].Cells[i_cell1].Value != null) { audit_status = datagridview1.Rows[row_i].Cells[i_cell1].Value.ToString().Trim(); }
                                //if (audit_status == "撤回")
                                //{
                                //    datagridview1.Rows[row_i].Cells[i_cell1].Value = "提交";
                                //    SET_ENABLE = 1;
                                //    //return true;
                                //}
                                //else
                                //{
                                //    datagridview1.Rows[row_i].Cells[i_cell1].Value = "撤回";
                                //    SET_ENABLE = 2;
                                //    // return true;

                                //}




                            }
                        }

                    }
                    bool_temp = true;
                }
                catch { bool_temp = false; }


            }
            out_i = out_i_temp;
            return bool_temp;
        }
        /// <summary>
        /// 修改当前行的总数据库
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="SET_ENABLE"></param>
        /// <param name="datagridviewRow"></param>
        /// <returns></returns>
        public bool updata_database(int ID, int SET_ENABLE, DataGridViewRow datagridviewRow)
        {
            bool bool_temp = false;
            try
            {
                var q_abc_text = from t in data_bom.Table_bom_all

                                 where t.ID == Convert.ToInt32(ID.ToString().Trim())

                                 select t;

                foreach (var item in q_abc_text)
                {
                    int price = 0;
                    try
                    {

                        price = Convert.ToInt32(check_value(datagridviewRow.Cells[8].Value));
                    }
                    catch
                    {
                        price = 0;
                    }
                    item.类别 = check_value(datagridviewRow.Cells[1].Value);

                    item.代码 = check_value(datagridviewRow.Cells[2].Value);
                    item.规格型号 = check_value(datagridviewRow.Cells[3].Value);
                    item.名称 = check_value(datagridviewRow.Cells[4].Value);
                    item.品牌 = check_value(datagridviewRow.Cells[5].Value);
                    item.技术参数 = check_value(datagridviewRow.Cells[6].Value);
                    item.备注 = check_value(datagridviewRow.Cells[7].Value);
                    item.价格 = price;
                    item.图片 = check_value(datagridviewRow.Cells[9].Value);

                    item.资料路径 = check_value(datagridviewRow.Cells[10].Value);
                    // item.添加者 = check_value(datagridviewRow.Cells[10].Value);
                    //item.添加日期 = check_value(datagridviewRow.Cells[12].Value);



                    // li.ID.ToString(), li.类别, li.代码, li.规格型号, li.名称, li.品牌, li.技术参数, li.价格.ToString(), li.图片, li.资料路径, li.添加者, li.添加日期, li.附件, li.全名 };





                    //DataGridViewButtonCell button_checked = (DataGridViewButtonCell)datagridview1.Rows[i].Cells[11];
                    //DataGridViewButtonCell button_delete = (DataGridViewButtonCell)datagridview1.Rows[i].Cells[12];



                }
                data_bom.SubmitChanges();
                bool_temp = true;
            }
            catch
            {
                bool_temp = false;
            }
            return bool_temp;
        }




        public void display_all_bom(DataGridView datagridview_1)
        {
            //li.ID.ToString(), li.类别, li.代码, li.规格型号, li.名称, li.品牌, li.技术参数, li.备注,li.价格.ToString(),  li.图片, li.资料路径, li.添加者, li.添加日期, li.附件, li.全名 }
            var q_abc_text = from t in data_bom.Table_bom_all

                                 //  where a.代码.Substring(0,3) == codeA && a.d == codeB
                                 //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                 //where t.代码.Contains(find_condition_text) || t.价格.ToString().Contains(find_condition_text) || t.全名.Contains(find_condition_text)
                                 //|| t.名称.Contains(find_condition_text) || t.品牌.Contains(find_condition_text) || t.图片.Contains(find_condition_text)
                                 //|| t.审核人.Contains(find_condition_text) || t.技术参数.Contains(find_condition_text) || t.规格型号.Contains(find_condition_text)
                                 //|| t.附件.Contains(find_condition_text)
                             select t;

            int i = 0;
            datagridview_1.Rows.Clear();
            foreach (var li in q_abc_text)
            {
                // DataGridViewRow row = new DataGridViewRow();


                datagridview_1.Rows.Add();
                datagridview_1.Rows[i].Cells[0].Value = check_value(li.ID); //ID
                datagridview_1.Rows[i].Cells[1].Value = check_value(li.类别); //类别
                datagridview_1.Rows[i].Cells[2].Value = check_value(li.代码); //代码
                datagridview_1.Rows[i].Cells[3].Value = check_value(li.规格型号); //规格型号
                datagridview_1.Rows[i].Cells[4].Value = check_value(li.名称); //物料名称
                datagridview_1.Rows[i].Cells[5].Value = check_value(li.品牌);//品牌
                datagridview_1.Rows[i].Cells[6].Value = check_value(li.技术参数); //技术参数
                datagridview_1.Rows[i].Cells[7].Value = check_value(li.备注); //备注

                datagridview_1.Rows[i].Cells[8].Value = check_value(li.价格); //价格
                datagridview_1.Rows[i].Cells[9].Value = check_value(li.图片); //图片
                datagridview_1.Rows[i].Cells[10].Value = check_value(li.资料路径); //资料路径
                datagridview_1.Rows[i].Cells[11].Value = check_value(li.添加者); //添加者
                datagridview_1.Rows[i].Cells[12].Value = check_value(li.添加日期); //添加日期

                DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)datagridview_1.Rows[i].Cells[13];
                DataGridViewButtonCell buttonCell14 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[14];
                DataGridViewButtonCell buttonCell15 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[15];

                chkBoxCell.Value = false;
                buttonCell14.Value = "修改";
                buttonCell15.Value = "删除";
                i++;
            }

        }

        /// <summary>
        /// 定位刚才修改的行
        /// </summary>
        /// <param name="datagridview_1"></param>
        public void location(DataGridView datagridview_1, int ID, int column_id)
        {
            foreach (DataGridViewRow rowone in datagridview_1.Rows)
            {
                if (rowone.Cells[column_id].Value != null)
                {
                    if (Convert.ToUInt32(rowone.Cells[column_id].Value.ToString()) == ID)
                    {

                        datagridview_1.ClearSelection();
                        rowone.Selected = true;
                        datagridview_1.CurrentCell = rowone.Cells[1];
                        break;



                    }

                }

            }
        }
        /// <summary>
        /// 翻页操作
        /// </summary>
        /// <param name="datagridview_1"></param>
        /// <param name="ID"></param>
        /// <param name="column_id"></param>
        public void location_pgup_or_pgdg(DataGridView datagridview_1, int ID, int i_upordg)
        {
            foreach (DataGridViewRow rowone in datagridview_1.Rows)
            {


                datagridview_1.ClearSelection();
                rowone.Selected = true;
                datagridview_1.CurrentCell = rowone.Cells[1];
                break;




            }

        }

        public bool delete_database(DataGridView datagridview1, int row_i, int column_i, out int out_i)
        {
            int out_i_temp = 0;
            out_i = out_i_temp;
            int ID_Colunm = 0;
            bool bool_temp = false;
            int i = datagridview1.Rows.Count;
            if (i <= 0) { return false; }
            string cell_value = "";

            string nowcellname = "";
            if (row_i >= 0 && column_i >= 0)
            {


                try
                {
                    cell_value = datagridview1.Rows[row_i].Cells[ID_Colunm].Value.ToString();

                    nowcellname = datagridview1.Columns[column_i].HeaderText;
                }
                catch { }

                try
                {

                    int ID = Convert.ToInt32(cell_value);
                    if (nowcellname == "删除")
                    {
                        for (int i_d_find = 0; i_d_find < i; i_d_find++)
                        {

                            if (datagridview1.Rows[i_d_find].Cells[ID_Colunm].Value.ToString().Trim() == ID.ToString().Trim())
                            {
                                DialogResult result = MessageBox.Show("确定删除？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                if (result == DialogResult.OK)
                                {
                                    if (delete_database(Convert.ToInt32(ID.ToString().Trim())))
                                    {
                                        DataGridViewRow row = datagridview1.Rows[row_i];
                                        datagridview1.Rows.Remove(row);
                                        MessageBox.Show("删除成功！");
                                        return true;
                                    };
                                }
                                else
                                {

                                }


                                //int SET_ENABLE = 0;
                                //int i_cell1 = 11;
                                //string audit_status = ""; if (datagridview1.Rows[row_i].Cells[i_cell1].Value != null) { audit_status = datagridview1.Rows[row_i].Cells[i_cell1].Value.ToString().Trim(); }
                                //if (audit_status == "撤回")
                                //{
                                //    datagridview1.Rows[row_i].Cells[i_cell1].Value = "提交";
                                //    SET_ENABLE = 1;
                                //    //return true;
                                //}
                                //else
                                //{
                                //    datagridview1.Rows[row_i].Cells[i_cell1].Value = "撤回";
                                //    SET_ENABLE = 2;
                                //    // return true;

                                //}




                            }
                        }

                    }
                    bool_temp = true;
                }
                catch { bool_temp = false; }


            }
            out_i = out_i_temp;
            return bool_temp;
        }
        /// <summary>
        /// 删除主数据库
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool delete_database(int ID)
        {
            
            bool bool_temp = false;
            try
            {
                var q_delete = (from t in data_bom.Table_bom_all

                                where t.ID == ID
                                //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                //where c.代码.Contains(sort_keywords)
                                //  where A.分类代码A
                                select t).First();

                data_bom.Table_bom_all.DeleteOnSubmit(q_delete);//删除该物料
                data_bom.SubmitChanges();
                bool_temp = true;
            }
            catch
            {
                bool_temp = false;
            }
            return bool_temp;
         
        }

    }





    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
