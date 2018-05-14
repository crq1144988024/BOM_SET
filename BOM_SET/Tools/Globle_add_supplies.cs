using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOM_SET.Tools
{
    public class Globle_add_supplies
    {

        sql.DataClasses_ADD_BOM_TEMPDataContext ADD_TEMP = new sql.DataClasses_ADD_BOM_TEMPDataContext();
        sql.DataClasses1DataContext bom_all = new sql.DataClasses1DataContext();
        /// <summary>
        ///物料新增到未审核区
        /// List<string> list_supplies,
        /// </summary>
        /// <param name="comboxcode_A">asd</param>
        /// <param name="comboxcode_B"></param>
        /// <param name="comboxcode_C"></param>
        /// <param name="Textbox_SUPPLIES_model1"></param>
        /// <param name="skinComboBox_SUPPLIES_NAME1"></param>
        /// <param name="Textbox_brank1"></param>
        /// <param name="Textbox_supples_sort1"></param>
        /// <param name="Textbox_supples_technical_parameters1"></param>
        /// <param name="Textbox_supples_spare1"></param>
        /// <param name="skinTextBox_pixturebox_path1"></param>
        /// <param name="skinTextBox_datapath"></param>
        /// <param name="skinCheckBox_price1"></param>
        /// <param name="skinTextBox_price1"></param>
        public void ADD_supplies(out bool reasult, ComboBox comboxcode_A, ComboBox comboxcode_B, ComboBox comboxcode_C, string Textbox_SUPPLIES_model1, string skinComboBox_SUPPLIES_NAME1,
            string Textbox_brank1, string Textbox_supples_sort1, string Textbox_supples_technical_parameters1, string Textbox_supples_spare1, string skinTextBox_pixturebox_path1
           , string skinTextBox_datapath1, CheckBox skinCheckBox_price1, string skinTextBox_price1)
        {
            reasult = true;

            string codeA = "";
            string codeB = "";
            string codeC = "";

            string SUPPLIES_model1 = "";
            string SUPPLIES_NAME1 = "";
            string brank1 = "";

            string supples_sort1 = "";
            string supples_technical_parameters1 = "";
            string supples_spare1 = "";
            string pixturebox_path1 = "";

            string datapath = "";
            string price1 = "";
            int TextBox_price1 = 0;



            if (comboxcode_A.SelectedItem != null) { codeA = comboxcode_A.SelectedItem.ToString().Substring(0, 3); } else { MessageBox.Show("请选择物料分类A"); reasult = false; return; }
            if (comboxcode_B.SelectedItem != null) { codeB = comboxcode_B.SelectedItem.ToString().Substring(0, 2); } else { MessageBox.Show("请选择物料分类B"); reasult = false; return; }
            if (comboxcode_C.SelectedItem != null) { codeC = comboxcode_C.SelectedItem.ToString().Substring(0, 1); } else { MessageBox.Show("请选择物料分类C"); reasult = false; return; }

            if (Textbox_SUPPLIES_model1 != null) { } else { MessageBox.Show("请填写物料型号"); reasult = false; return; }
            if (Textbox_SUPPLIES_model1.Length > 1) { SUPPLIES_model1 = Textbox_SUPPLIES_model1.ToString().Trim(); } else { MessageBox.Show("请填写物料型号"); reasult = false; return; }

            if (skinComboBox_SUPPLIES_NAME1 != null) { } else { MessageBox.Show("请填写物料名称"); reasult = false; return; }
            if (skinComboBox_SUPPLIES_NAME1.Length > 1) { SUPPLIES_NAME1 = skinComboBox_SUPPLIES_NAME1.ToString().Trim(); } else { MessageBox.Show("请填写物料名称"); reasult = false; return; }

            if (Textbox_brank1 != null) { } else { MessageBox.Show("请填写品牌"); reasult = false; return; }
            if (Textbox_brank1.Length > 1) { brank1 = Textbox_brank1.ToString().Trim(); } else { MessageBox.Show("请填写品牌"); reasult = false; return; }

            if (Textbox_supples_sort1 != null) { supples_sort1 = Textbox_supples_sort1.ToString().Trim(); }
            if (Textbox_supples_technical_parameters1 != null) { supples_technical_parameters1 = Textbox_supples_technical_parameters1.ToString().Trim(); }
            if (Textbox_supples_spare1 != null) { supples_spare1 = Textbox_supples_spare1.ToString().Trim(); }
            if (skinTextBox_pixturebox_path1 != null) { pixturebox_path1 = skinTextBox_pixturebox_path1.ToString().Trim(); }

            if (skinTextBox_datapath1 != null) { datapath = skinTextBox_datapath1.ToString().Trim(); }
            if (skinCheckBox_price1 != null) { price1 = skinCheckBox_price1.ToString().Trim(); }

            if (skinCheckBox_price1.Checked == true)
            {
                if (skinTextBox_price1 != null) { }
                if (skinTextBox_price1.Length > 1) { try { TextBox_price1 = Convert.ToInt32(skinTextBox_price1.ToString().Trim()); } catch { MessageBox.Show("请在价格处填入正确的字符！"); reasult = false; return; } }

            }
            else
            {
                TextBox_price1 = 0;
            }



            if (price1 == "否")
            {
                TextBox_price1 = 0;
            }

            string codeD = codeA + "." + codeB + "." + codeC;
            string code_ALL = codeD + SUPPLIES_model1;

            var table0 = new sql.Table_bom_all_add_temp
            {
                类别 = supples_sort1,
                //ID
                代码 = code_ALL,
                规格型号 = SUPPLIES_model1,
                名称 = SUPPLIES_NAME1,
                品牌 = brank1,

                技术参数 = supples_technical_parameters1,
                备注 = supples_spare1,
                价格 = TextBox_price1,
                图片 = pixturebox_path1,
                资料路径 = datapath,
                是否提交="否",
                 
                新增人 = LOGIN.ID.login_now_Nanme.Trim(),
                是否审核 = "否"


            };

            ADD_TEMP.Table_bom_all_add_temp.InsertOnSubmit(table0);
            ADD_TEMP.SubmitChanges();


        }

        /// <summary>
        /// 未审核物料查询
        /// </summary>
        /// <param name="datagridview1"></param>
        public void find_unchecked(DataGridView datagridview1)
        {
            datagridview1.Rows.Clear();
            var q_abc_text = from t in ADD_TEMP.Table_bom_all_add_temp

                             where t.新增人 == LOGIN.ID.login_now_Nanme.Trim() && t.是否审核.ToString().Trim() == "否"
                             //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                             //where t.代码.Contains(find_condition_text) || t.价格.ToString().Contains(find_condition_text) || t.全名.Contains(find_condition_text)
                             //|| t.名称.Contains(find_condition_text) || t.品牌.Contains(find_condition_text) || t.图片.Contains(find_condition_text)
                             //|| t.审核人.Contains(find_condition_text) || t.技术参数.Contains(find_condition_text) || t.规格型号.Contains(find_condition_text)
                             //|| t.附件.Contains(find_condition_text)
                             select t;
            //类别 = supples_sort1,
            //    //ID
            //    代码 = code_ALL,
            //    规格型号 = SUPPLIES_model1,
            //    名称 = SUPPLIES_NAME1,
            //    品牌 = brank1,

            //    技术参数 = supples_technical_parameters1,
            //    备注 = supples_spare1,
            //    价格 = TextBox_price1,
            //    图片 = pixturebox_path1,
            //    资料路径 = datapath,
            int i = 0;
            foreach (var item in q_abc_text)
            {
                datagridview1.Rows.Add();

                datagridview1.Rows[i].Cells[0].Value = check_value(item.类别);
                datagridview1.Rows[i].Cells[1].Value = check_value(item.ID);
                datagridview1.Rows[i].Cells[2].Value = check_value(item.代码);
                datagridview1.Rows[i].Cells[3].Value = check_value(item.规格型号);
                datagridview1.Rows[i].Cells[4].Value = check_value(item.名称);

                datagridview1.Rows[i].Cells[5].Value = check_value(item.品牌);
                datagridview1.Rows[i].Cells[6].Value = check_value(item.技术参数);
                datagridview1.Rows[i].Cells[7].Value = check_value(item.备注);

                datagridview1.Rows[i].Cells[8].Value = check_value(item.价格);
                datagridview1.Rows[i].Cells[9].Value = check_value(item.图片);
                datagridview1.Rows[i].Cells[10].Value = check_value(item.资料路径);

                DataGridViewButtonCell button_checked = (DataGridViewButtonCell)datagridview1.Rows[i].Cells[11];
                DataGridViewButtonCell button_delete = (DataGridViewButtonCell)datagridview1.Rows[i].Cells[12];
                if (check_value(item.是否提交) == "是")
                {


                    button_checked.Value = "撤回";


                }
                else
                {
                    button_checked.Value = "提交";
                }

                button_delete.Value = "删除";


                i++;

            }

        }
        /// <summary>
        /// 已审核物料查询
        /// </summary>
        /// <param name="datagridview1"></param>
        public void find_checked(DataGridView datagridview1)
        {
            datagridview1.Rows.Clear();
            var q_abc_text = from t in ADD_TEMP.Table_bom_all_add_temp

                             where t.新增人 == LOGIN.ID.login_now_Nanme.Trim() && t.是否审核.ToString().Trim() == "是"
                             //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                             //where t.代码.Contains(find_condition_text) || t.价格.ToString().Contains(find_condition_text) || t.全名.Contains(find_condition_text)
                             //|| t.名称.Contains(find_condition_text) || t.品牌.Contains(find_condition_text) || t.图片.Contains(find_condition_text)
                             //|| t.审核人.Contains(find_condition_text) || t.技术参数.Contains(find_condition_text) || t.规格型号.Contains(find_condition_text)
                             //|| t.附件.Contains(find_condition_text)
                             select t;
            //类别 = supples_sort1,
            //    //ID
            //    代码 = code_ALL,
            //    规格型号 = SUPPLIES_model1,
            //    名称 = SUPPLIES_NAME1,
            //    品牌 = brank1,

            //    技术参数 = supples_technical_parameters1,
            //    备注 = supples_spare1,
            //    价格 = TextBox_price1,
            //    图片 = pixturebox_path1,
            //    资料路径 = datapath,
            int i = 0;
            foreach (var item in q_abc_text)
            {
                datagridview1.Rows.Add();

                datagridview1.Rows[i].Cells[0].Value = check_value(item.类别);
                datagridview1.Rows[i].Cells[1].Value = check_value(item.ID);
                datagridview1.Rows[i].Cells[2].Value = check_value(item.代码);
                datagridview1.Rows[i].Cells[3].Value = check_value(item.规格型号);
                datagridview1.Rows[i].Cells[4].Value = check_value(item.名称);

                datagridview1.Rows[i].Cells[5].Value = check_value(item.品牌);
                datagridview1.Rows[i].Cells[6].Value = check_value(item.技术参数);
                datagridview1.Rows[i].Cells[7].Value = check_value(item.备注);

                datagridview1.Rows[i].Cells[8].Value = check_value(item.价格);
                datagridview1.Rows[i].Cells[9].Value = check_value(item.图片);
                datagridview1.Rows[i].Cells[10].Value = check_value(item.资料路径);

                datagridview1.Rows[i].Cells[9].Value = check_value(item.图片);
                datagridview1.Rows[i].Cells[10].Value = check_value(item.资料路径);

                datagridview1.Rows[i].Cells[11].Value = check_value(item.物料ID);
                string str0 = "";
                if (check_value(item.是否审核)=="是")
                {
                    str0 = "已审核";
                }
                else
                {
                    str0 = "未审核";
                }
                datagridview1.Rows[i].Cells[12].Value = str0;
                datagridview1.Rows[i].Cells[13].Value = check_value(item.审核意见);

                i++;

            }

        }

        public string check_value( object str)
        {
            string str0 = " ";

            if(str != null) { str0 = str.ToString().Trim(); }
            str = str0;
            return str0;
        }
        public bool delete(DataGridView datagridview1,int row_i, int column_i)
        {
            int ID_Colunm = 1;
            bool bool_temp = false;
            int i = datagridview1.Rows.Count;
            if (i <= 0) { return false ; }
            string cell_value = "";

            string nowcellname = "";
            if (row_i >= 0 && column_i>= 0)
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
                                int SET_ENABLE = 0;
                                int i_cell1 = 11;
                                string audit_status = ""; if (datagridview1.Rows[row_i].Cells[i_cell1].Value != null) { audit_status = datagridview1.Rows[row_i].Cells[i_cell1].Value.ToString().Trim(); }
                                if (audit_status == "撤回")
                                {
                                    MessageBox.Show("无法删除！请先撤销审批申请后再删除！");
                                    return false;
                                }
                                else { }

                            
                                    DialogResult result = MessageBox.Show("确定要删除？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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

                               
                              

                            }
                        }
                    }




                }
                catch { }
            }
            return bool_temp;
        }
        public bool delete_database(int ID)
        {
            bool bool_temp = false;
            try
            {
                var q_delete = (from t in ADD_TEMP.Table_bom_all_add_temp

                                where  t.ID==ID
                                //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                //where c.代码.Contains(sort_keywords)
                                //  where A.分类代码A
                                select t).First();

                ADD_TEMP.Table_bom_all_add_temp.DeleteOnSubmit(q_delete);//删除该物料
                ADD_TEMP.SubmitChanges();
                bool_temp = true;
            }
            catch
            {
                bool_temp = false;
            }
            return bool_temp;
        }
        public bool updata_database(int ID,int SET_ENABLE)
        {
            bool bool_temp = false;
            try
            {
                var q_abc_text = from t in ADD_TEMP.Table_bom_all_add_temp

                                 where t.新增人 == LOGIN.ID.login_now_Nanme.Trim() && t.是否审核.ToString().Trim() == "否"
                                 && t.ID == Convert.ToInt32(ID.ToString().Trim())
                                 //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                 //where t.代码.Contains(find_condition_text) || t.价格.ToString().Contains(find_condition_text) || t.全名.Contains(find_condition_text)
                                 //|| t.名称.Contains(find_condition_text) || t.品牌.Contains(find_condition_text) || t.图片.Contains(find_condition_text)
                                 //|| t.审核人.Contains(find_condition_text) || t.技术参数.Contains(find_condition_text) || t.规格型号.Contains(find_condition_text)
                                 //|| t.附件.Contains(find_condition_text)
                                 select t;


                foreach (var item in q_abc_text)
                {


                    //DataGridViewButtonCell button_checked = (DataGridViewButtonCell)datagridview1.Rows[i].Cells[11];
                    //DataGridViewButtonCell button_delete = (DataGridViewButtonCell)datagridview1.Rows[i].Cells[12];
                    if (SET_ENABLE == 1)
                    {

                        item.是否提交 = "否";



                    }
                    else if (SET_ENABLE == 2)
                    {
                        item.是否提交 = "是";

                    }

                }
                ADD_TEMP.SubmitChanges();
                bool_temp = true;
            }
            catch
            {
                bool_temp = false;
            }
            return bool_temp;
        }
        public bool chech_audit(DataGridView datagridview1, int row_i, int column_i)
        {
            int ID_Colunm = 1;
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
                    if (nowcellname == "提交审核")
                    {
                        for (int i_d_find = 0; i_d_find < i; i_d_find++)
                        {

                            if (datagridview1.Rows[i_d_find].Cells[ID_Colunm].Value.ToString().Trim() == ID.ToString().Trim())
                            {
                                int SET_ENABLE = 0;
                                int i_cell1 = 11;
                                string audit_status = ""; if (datagridview1.Rows[row_i].Cells[i_cell1].Value != null) { audit_status = datagridview1.Rows[row_i].Cells[i_cell1].Value.ToString().Trim(); }
                                if (audit_status == "撤回")
                                {
                                    datagridview1.Rows[row_i].Cells[i_cell1].Value = "提交";
                                    SET_ENABLE = 1;
                                    //return true;
                                }
                                else
                                {
                                    datagridview1.Rows[row_i].Cells[i_cell1].Value = "撤回";
                                    SET_ENABLE = 2;
                                    // return true;

                                }

                                updata_database(Convert.ToInt32(ID.ToString().Trim()),  SET_ENABLE);



                            }
                        }

                    }
                    bool_temp = true;
                }
                catch { bool_temp = false; }


            }
            return bool_temp;
        }


        
        public bool duplicate_checking(ComboBox comboxcode_A, ComboBox comboxcode_B, ComboBox comboxcode_C, TextBox Textbox_SUPPLIES_model1, string skinComboBox_SUPPLIES_NAME1)
        {
           
            bool BOOL_TEMP = false;
            string codeA = "";
            string codeB = "";
            string codeC = "";
            string codeD = "";
            string code_ALL = "";
            string SUPPLIES_model1 = "";

            string SUPPLIES_NAME1 = "";
            if (comboxcode_A.SelectedItem != null) { codeA = comboxcode_A.SelectedItem.ToString().Substring(0, 3); } else { MessageBox.Show("请选择物料分类A"); BOOL_TEMP = false; return BOOL_TEMP; }
            if (comboxcode_B.SelectedItem != null) { codeB = comboxcode_B.SelectedItem.ToString().Substring(0, 2); } else { MessageBox.Show("请选择物料分类B"); BOOL_TEMP = false; return BOOL_TEMP; }
            if (comboxcode_C.SelectedItem != null) { codeC = comboxcode_C.SelectedItem.ToString().Substring(0, 1); } else { MessageBox.Show("请选择物料分类C"); BOOL_TEMP = false; return BOOL_TEMP; }

            if (Textbox_SUPPLIES_model1 != null) { } else { MessageBox.Show("请填写物料型号"); BOOL_TEMP = false; return BOOL_TEMP; }
            if (Textbox_SUPPLIES_model1.Text.Length > 1) { SUPPLIES_model1 = Textbox_SUPPLIES_model1.ToString().Trim(); } else { MessageBox.Show("请填写物料型号"); BOOL_TEMP = false; return BOOL_TEMP; }

            if (skinComboBox_SUPPLIES_NAME1 != null) { } else { MessageBox.Show("请填写物料名称"); BOOL_TEMP = false; return BOOL_TEMP; }
            if (skinComboBox_SUPPLIES_NAME1.Length > 1) { SUPPLIES_NAME1 = skinComboBox_SUPPLIES_NAME1.ToString().Trim(); } else { MessageBox.Show("请填写物料名称"); BOOL_TEMP = false; return BOOL_TEMP; }

            //if (comboxcode_A.SelectedItem != null) { codeA = comboxcode_A.SelectedItem.ToString().Substring(0, 3); } else { BOOL_TEMP = false; return BOOL_TEMP; }
            //if (comboxcode_B.SelectedItem != null) { codeB = comboxcode_B.SelectedItem.ToString().Substring(0, 2); } else { BOOL_TEMP = false; return BOOL_TEMP; }
            //if (comboxcode_C.SelectedItem != null) { codeC = comboxcode_C.SelectedItem.ToString().Substring(0, 1); } else { BOOL_TEMP = false; return BOOL_TEMP; }

            //if (Textbox_SUPPLIES_model1 != null) { } else { BOOL_TEMP = false; return BOOL_TEMP; }
            //if (Textbox_SUPPLIES_model1.Text.Length > 1) { SUPPLIES_model1 = Textbox_SUPPLIES_model1.Text.ToString().Trim(); } else { BOOL_TEMP = false; return BOOL_TEMP; }

            //if (skinComboBox_SUPPLIES_NAME1 != null) { } else { BOOL_TEMP = false; return BOOL_TEMP; }
            //if (skinComboBox_SUPPLIES_NAME1.Length > 1) { SUPPLIES_NAME1 = skinComboBox_SUPPLIES_NAME1.ToString().Trim(); } else {  BOOL_TEMP = false; return BOOL_TEMP; }
            codeD = codeA + "." + codeB + "." + codeC;
            code_ALL = codeD + SUPPLIES_model1;
            var find_all_temp1 = from t in ADD_TEMP.Table_bom_all_add_temp

                                     // where t.代码.ToString().Trim() == code_ALL.Trim() 
                                 where t.代码 == code_ALL.Trim()
                                 select t;
            string str1 = "";
            foreach (var item in find_all_temp1)
            {
                str1 = item.代码.ToString().Trim();
            }
            if (find_all_temp1 != null) { if (find_all_temp1.Count() > 0) { MessageBox.Show("在新增数据库中查找到相同的物料代码，" + str1 + "，无法添加该物料"); BOOL_TEMP = false; return BOOL_TEMP; } }

            var find_all_temp2 = from t in ADD_TEMP.Table_bom_all_add_temp
                                 where t.名称.ToString().Trim() == SUPPLIES_NAME1.Trim()
                                 select t;

            string str2 = "";
            foreach (var item in find_all_temp2)
            {
                str2 = item.名称.ToString().Trim();
            }
            if (find_all_temp2 != null) { if (find_all_temp2.Count() > 0) { MessageBox.Show("在新增数据库中查找到相同的物料名称，" + str2 + "，无法添加该物料"); BOOL_TEMP = false; return BOOL_TEMP; } }

            var find_all_temp3 = from t in ADD_TEMP.Table_bom_all_add_temp

                                 //where t.规格型号.ToString().Trim() == SUPPLIES_model1.Trim()
                                 where t.规格型号 == SUPPLIES_model1.Trim()
                                 select t;

            string str3 = "";
            foreach (var item in find_all_temp3)
            {
                str3 = item.规格型号.ToString().Trim();
            }
            if (find_all_temp3 != null) { if (find_all_temp3.Count() > 0) { MessageBox.Show("在新增数据库中查找到相同的物料规格型号：" + str3 + "，无法添加该物料"); BOOL_TEMP = false; return BOOL_TEMP; } }




            var find_all1 = from t in bom_all.Table_bom_all

                           where t.代码.ToString().Trim() == code_ALL.Trim() 
                         
                           select t;
            string str11 = "";
            foreach (var item in find_all1)
            {
                str11 = item.代码.ToString().Trim();
            }
            if (find_all1 != null) { if (find_all1.Count() > 0) { MessageBox.Show("在总数据库中查找到相同的物料代码，" + str11 + "，无法添加该物料"); BOOL_TEMP = false; return BOOL_TEMP; } }



            var find_all2 = from t in bom_all.Table_bom_all

                           where  t.名称.ToString().Trim() == SUPPLIES_NAME1.Trim()
                          

                           select t;
            string str22 = "";
            foreach (var item in find_all2)
            {
                str22 = item.名称.ToString().Trim();
            }
            if (find_all2 != null) { if (find_all2.Count() > 0) { MessageBox.Show("在总数据库中查找到相同的物料名称，" + str22 + "，无法添加该物料"); BOOL_TEMP = false; return BOOL_TEMP; } }







            var find_all3 = from t in bom_all.Table_bom_all

                            where 
                             t.规格型号.ToString().Trim() == SUPPLIES_model1.Trim()

                            select t;

            string str33 = "";
            foreach (var item in find_all3)
            {
                str33 = item.规格型号.ToString().Trim();
            }
            if (find_all3 != null) { if (find_all3.Count() > 0) { MessageBox.Show("在总数据库中查找到相同的物料规格型号：" + str33 + "，无法添加该物料"); BOOL_TEMP = false; return BOOL_TEMP; } }



            BOOL_TEMP = true;

            return BOOL_TEMP;
        }
        public string get_code_all(ComboBox comboxcode_A, ComboBox comboxcode_B, ComboBox comboxcode_C, TextBox Textbox_SUPPLIES_model1)
        {
            bool BOOL_TEMP = false;
            string codeA = "";
            string codeB = "";
            string codeC = "";
            string codeD = "";
            string code_ALL = "";
            string SUPPLIES_model1 = "";
          

            if (comboxcode_A.SelectedItem != null) { codeA = comboxcode_A.SelectedItem.ToString().Substring(0, 3); } else {  BOOL_TEMP = false; return code_ALL; }
            if (comboxcode_B.SelectedItem != null) { codeB = comboxcode_B.SelectedItem.ToString().Substring(0, 2); } else { BOOL_TEMP = false; return code_ALL; }
            if (comboxcode_C.SelectedItem != null) { codeC = comboxcode_C.SelectedItem.ToString().Substring(0, 1); } else { BOOL_TEMP = false; return code_ALL; }

            if (Textbox_SUPPLIES_model1 != null) { } else {  BOOL_TEMP = false; return code_ALL; }
            if (Textbox_SUPPLIES_model1.Text.Length > 1) { SUPPLIES_model1 = Textbox_SUPPLIES_model1.Text.ToString().Trim(); } else { BOOL_TEMP = false; return code_ALL; }

          

            codeD = codeA + "." + codeB + "." + codeC;
            code_ALL = codeD + SUPPLIES_model1;
            return code_ALL;
        }
    }
}
