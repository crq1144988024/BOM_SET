using BOM_SET.sql;
using BOM_SET.Tools;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace BOM_SET.review
{
  public  class Class_review_tools
    {
       
            sql.DataClasses_LoginDataContext login = new sql.DataClasses_LoginDataContext();
            sql.DataClasses_BOM_ALLDataContext BOM_all = new sql.DataClasses_BOM_ALLDataContext();
            sql.bom_hoidDataContext BOM_project_hold = new sql.bom_hoidDataContext();
            public void find_bom_project(DataGridView datagridview_1, bool bool_all)
            {

                BOM_project_hold = new sql.bom_hoidDataContext();
                if (!bool_all)
                {
                    var q_abc_text = from t in BOM_project_hold.Table_BOM_HOLD

                                     where t.当次计划是否提完 == "否" && t.是否激活 == "是" && t.当次审批是否通过 == "否"

                                     select t;

               

                // MessageBox.Show(q_abc_text.Count().ToString());
                int i = 0;
                    datagridview_1.Rows.Clear();
                    foreach (var li in q_abc_text)
                    {
                    // DataGridViewRow row = new DataGridViewRow();
                     checked_count_zero(Convert.ToInt32(check_value(li.ID)));

                        if (bom_all_count_empty)
                        {
                            continue;
                        }
                        datagridview_1.Rows.Add();
                        datagridview_1.Rows[i].Cells[0].Value = check_value(li.ID); //ID
                        datagridview_1.Rows[i].Cells[1].Value = check_value(li.项目代号); //项目代号
                        datagridview_1.Rows[i].Cells[2].Value = check_value(li.项目名称); //项目名称
                        datagridview_1.Rows[i].Cells[3].Value = check_value(li.设备序号); //设备序号
                        datagridview_1.Rows[i].Cells[4].Value = check_value(li.第几次申请); //第几次申请

                    int name_int = 0;
                    try
                    {
                        name_int = Convert.ToInt32(check_value(li.项目负责人ID));
                    }
                    catch
                    {

                    }

                    var q_name = from t in login.Login

                                     where t.ID == name_int

                                 select t;
                        string nametemp = "";
                        string name_2 = "";
                        foreach (var name in q_name)
                        {
                            nametemp = name.NAME;
                       
                        }
                    int change_int = 0;
                    try
                    {
                        change_int = Convert.ToInt32(check_value(li.最后修改人ID));
                    }
                    catch
                    {

                    }
                        var q_name2 = from t in login.Login

                                     where t.ID == change_int

                                      select t;
                        foreach (var name in q_name2)
                        {
                            name_2 = name.NAME;

                        }
                    datagridview_1.Rows[i].Cells[5].Value = check_value(nametemp); //项目负责人
                    datagridview_1.Rows[i].Cells[6].Value = check_value(name_2); //最后修改人
                    datagridview_1.Rows[i].Cells[7].Value = check_value(li.备注); //备注
                                                                                
                        DataGridViewButtonCell combox8 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[8];
                   

                        combox8.Value = "读取";

                    DataGridViewButtonCell combox9 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[9];


                    combox9.Value = "关闭";
                    i++;
                    }

                }
                else
                {
                    var q_abc_text = from t in BOM_project_hold.Table_BOM_HOLD

                                   where t.是否已提计划 == "是" && t.是否已获过审批 == "是"

                                     select t;
                    int i = 0;
                datagridview_1.Rows.Clear();
                foreach (var li in q_abc_text)
                {
                    // DataGridViewRow row = new DataGridViewRow();


                    datagridview_1.Rows.Add();
                    datagridview_1.Rows[i].Cells[0].Value = check_value(li.ID); //ID
                    datagridview_1.Rows[i].Cells[1].Value = check_value(li.项目代号); //项目代号
                    datagridview_1.Rows[i].Cells[2].Value = check_value(li.项目名称); //项目名称
                    datagridview_1.Rows[i].Cells[3].Value = check_value(li.设备序号); //设备序号
                    datagridview_1.Rows[i].Cells[4].Value = check_value(li.第几次申请); //第几次申请

                    int name_int = 0;
                    try
                    {
                        name_int = Convert.ToInt32(check_value(li.项目负责人ID));
                    }
                    catch
                    {

                    }

                    var q_name = from t in login.Login

                                 where t.ID == name_int

                                 select t;
                    string nametemp = "";
                    string name_2 = "";
                    foreach (var name in q_name)
                    {
                        nametemp = name.NAME;

                    }
                    int change_int = 0;
                    try
                    {
                        change_int = Convert.ToInt32(check_value(li.最后修改人ID));
                    }
                    catch
                    {

                    }
                    var q_name2 = from t in login.Login

                                  where t.ID == change_int

                                  select t;
                    foreach (var name in q_name2)
                    {
                        name_2 = name.NAME;

                    }
                    datagridview_1.Rows[i].Cells[5].Value = check_value(nametemp); //项目负责人
                    datagridview_1.Rows[i].Cells[6].Value = check_value(name_2); //最后修改人
                    datagridview_1.Rows[i].Cells[7].Value = check_value(li.备注); //备注

                    DataGridViewButtonCell combox8 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[8];


                    combox8.Value = "读取";

                    //bool temp = false;
                    //DataGridViewButtonCell combox9 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[9];


                  //  combox9.Value = "关闭";


                    i++;
                    }
                }
           
        }
        public static int  project_ID_NOW =-1 ;
            public bool read_bom_all(DataGridView datagridview1, int row_i, int column_i, DataGridView datagridview_list,bool bool_oldornew)
            {
            
               int ID_Colunm = 0;//ID
                int i_cell1 = 0;//
                                //int i_cell2 = 8;
                                //MessageBox.Show("");

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

                        if (nowcellname == "读取")
                        {
                            for (int i_d_find = 0; i_d_find < i; i_d_find++)
                            {

                                if (datagridview1.Rows[i_d_find].Cells[ID_Colunm].Value.ToString().Trim() == ID.ToString().Trim())
                                {
                                    int SET_ENABLE = 0;
                                    string audit_status = ""; if (datagridview1.Rows[row_i].Cells[i_cell1].Value != null) { audit_status = datagridview1.Rows[row_i].Cells[i_cell1].Value.ToString().Trim(); }
                                // MessageBox.Show(audit_status);
                                project_ID_NOW = ID;
                                if (bool_oldornew)
                                {
                                    finad_bom_temp_old(datagridview_list, Convert.ToInt32(audit_status));
                                }
                                else
                                {
                                    close_ennable = false;
                                    finad_bom_temp(datagridview_list, Convert.ToInt32(audit_status));
                                   
                                    close_ennable = checked_count_zero(project_ID_NOW);//检查是否为空
                                    
                                }
                                   
                              
                                return bool_temp;


                                }
                            }

                        }
                        bool_temp = true;
                    }
                    catch { bool_temp = false; }


                }
                return bool_temp;
            }
        public bool close_bom_all(DataGridView datagridview1, int row_i, int column_i, DataGridView datagridview_list)
        {
           
            int ID_Colunm = 0;//ID
            int i_cell1 = 0;//
                            //int i_cell2 = 8;
                            //MessageBox.Show("");

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

                    if (nowcellname == "关闭")
                    {
                        if(close_ennable == false)
                        {
                            MessageBox.Show("BOM可能还没审批完！请先审批完再关闭！");
                            return false;
                        }
                        for (int i_d_find = 0; i_d_find < i; i_d_find++)
                        {

                            if (datagridview1.Rows[i_d_find].Cells[ID_Colunm].Value.ToString().Trim() == ID.ToString().Trim())
                            {
                                int SET_ENABLE = 0;
                                string audit_status = ""; if (datagridview1.Rows[row_i].Cells[i_cell1].Value != null) { audit_status = datagridview1.Rows[row_i].Cells[i_cell1].Value.ToString().Trim(); }
                                // MessageBox.Show(audit_status);
                                project_ID_NOW = ID;

                                DialogResult result2 = MessageBox.Show("此申请单已审批完是否关闭？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (result2 == DialogResult.OK)
                                {
                                   updata_database_project(project_ID_NOW, "是", "否", "未采购", "是");
                                    find_bom_project(datagridview1, false);
                                    datagridview_list.Rows.Clear();
                                }

                                return bool_temp;


                            }
                        }

                    }
                    bool_temp = true;
                }
                catch { bool_temp = false; }


            }
            return bool_temp;
        }
        public static bool shopping_ed;
            public static bool bom_out_excel_temp_num;
            public static bool shop_out_excel_temp_num;
            public bool chech_audit(DataGridView datagridview1, int row_i, int column_i, DataGridView DataGridView_BOM_list)
            {
                int ID_Colunm = 0;//ID
                int i_cell1 = 9;//
                int i_cell2 = 6;


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

                        if (nowcellname == "计划")
                        {
                            for (int i_d_find = 0; i_d_find < i; i_d_find++)
                            {

                                if (datagridview1.Rows[i_d_find].Cells[ID_Colunm].Value.ToString().Trim() == ID.ToString().Trim())
                                {
                                    int SET_ENABLE = 0;

                                    string audit_status = ""; if (datagridview1.Rows[row_i].Cells[i_cell1].Value != null) { audit_status = datagridview1.Rows[row_i].Cells[i_cell1].Value.ToString().Trim(); }

                                    string project_name = check_value(datagridview1.Rows[row_i].Cells[1].Value);
                                    string num_st = check_value(datagridview1.Rows[row_i].Cells[3].Value);
                                    string num_times = check_value(datagridview1.Rows[row_i].Cells[4].Value);

                                   // if (!finad_bom_temp(DataGridView_BOM_list, ID)) { return false; }


                                    if (audit_status == "已提")
                                    {
                                        //DialogResult result = MessageBox.Show("确定要撤销为未提状态？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                        //if (result == DialogResult.OK)
                                        //{
                                        //    datagridview1.Rows[row_i].Cells[i_cell1].Value = "未提";
                                        //    SET_ENABLE = 1;
                                        //}
                                        //else
                                        //{

                                        //}


                                        //return true;
                                    }
                                    else
                                    {

                                        DialogResult result1 = MessageBox.Show("修改前是否导出当前BOM？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                        if (result1 == DialogResult.OK)
                                        {

                                            bom_out_excel_temp_num = false;
                                            if (bom_out_put_excel(DataGridView_BOM_list, project_name, num_st, num_times))
                                            {
                                                MessageBox.Show("导出BOM成功！");
                                            }
                                        }



                                        DialogResult result = MessageBox.Show("确定要修改为已提状态？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                        if (result == DialogResult.OK)
                                        {
                                            datagridview1.Rows[row_i].Cells[i_cell1].Value = "已提";

                                          //  updata_database_project(ID, "否", "是", "已采购");
                                          //  updata_database_bom(ID, "否", "否", "已提", "已采购");
                                            SET_ENABLE = 2;


                                            find_bom_project(datagridview1, false);//刷新一下
                                            DataGridView_BOM_list.Rows.Clear();
                                        }
                                        else
                                        {

                                        }
                                        DialogResult result2 = MessageBox.Show("是否导出当前BOM的采购单？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                        if (result2 == DialogResult.OK)
                                        {
                                            shop_out_excel_temp_num = true;
                                            shopping_out_put_excel(project_name, num_st, num_times, DataGridView_BOM_list);
                                            //while ( Form2_procurement_open==false)
                                            //{

                                            //}
                                            // shopping_ed = true;

                                            //  MessageBox.Show("导出采购单成功！");
                                        }
                                        // return true;




                                    }

                                    // updata_database(Convert.ToInt32(ID.ToString().Trim()),  SET_ENABLE);



                                }
                            }

                        }
                        bool_temp = true;
                    }
                    catch { bool_temp = false; }


                }
                return bool_temp;
            }
            public bool select_one(DataGridView datagridview1, int row_i, int column_i)
            {
                int ID_Colunm = 0;//ID
                int i_cell1 = 9;//
                int i_cell2 = 7;
                // datagridview1.EndEdit();   //此处必须加上结束编辑状态代码，切记

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

                        if (nowcellname == "选中")
                        {


                            for (int i_d_find = 0; i_d_find < i; i_d_find++)
                            {

                                //MessageBox.Show("Test");
                                DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)datagridview1.Rows[row_i].Cells[i_cell2];
                                //  chkBoxCell.KeyEntersEditMode = true;
                                //chkBoxCell.Selected = false;
                                //  datagridview1.Rows[row_i].Cells[i_cell2].Value = 1;
                                //    ((DataGridViewCheckBoxCell)dataGridView1.Rows[0].Cells[0]).Value = true.value
                                //  chkBoxCell.IsInEditMode = false;
                                //  chkBoxCell.EditingCellValueChanged = false;
                                // chkBoxCell.Dispose();
                                //datagridview1.Rows[row_i].Cells[i_cell2].Value = false;

                                if (datagridview1.Rows[i_d_find].Cells[ID_Colunm].Value.ToString().Trim() == ID.ToString().Trim())
                                {
                                    int SET_ENABLE = 0;


                                    string audit_status_set = ""; if (datagridview1.Rows[row_i].Cells[i_cell2].Value != null) { audit_status_set = datagridview1.Rows[row_i].Cells[i_cell2].Value.ToString().Trim(); }




                                    //datagridview1.Rows[i_d_find].Cells["选中"].Value = 1;
                                    // chkBoxCell.Value = 1;
                                    datagridview1.Rows[row_i].Selected = true;
                                    //   chkBoxCell.Value = true;
                                    datagridview1.Rows[row_i].Cells[i_cell2].Value = 1;




                                    // updata_database(Convert.ToInt32(ID.ToString().Trim()),  SET_ENABLE);



                                }
                                else
                                {
                                    datagridview1.Rows[i_d_find].Cells[i_cell2].Value = 0;
                                    //chkBoxCell.Value = 0;
                                    //   datagridview1.Rows[i_d_find].Selected = false;

                                }
                            }

                        }
                        bool_temp = true;
                    }
                    catch { bool_temp = false; }


                }
                return bool_temp;
            }
            /// <summary>
            /// 更新bom_project区数据
            /// </summary>
            // DataClasses_BOM_ALLDataContext bomall_classes = new DataClasses_BOM_ALLDataContext();
            public bool updata_database_project(int projectID, string step1, string step2, string step3,string step4)
            {
            BOM_project_hold = new sql.bom_hoidDataContext();
            bool bool_temp = false;
                try
                {
                    var q_abc_text = from t in BOM_project_hold.Table_BOM_HOLD

                                     where t.ID == projectID
                                     //  whereqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                     //where t.代码.Contains(find_condition_text) || t.价格.ToString().Contains(find_condition_text) || t.全名.Contains(find_condition_text)
                                     //|| t.名称.Contains(find_condition_text) || t.品牌.Contains(find_condition_text) || t.图片.Contains(find_condition_text)
                                     //|| t.审核人.Contains(find_condition_text) || t.技术参数.Contains(find_condition_text) || t.规格型号.Contains(find_condition_text)
                                     //|| t.附件.Contains(find_condition_text)
                                     select t;


                    foreach (var item in q_abc_text)
                    {
                        item.是否激活 = step1;
                        item.当次计划是否提完 = step2;
                        item.当次采购是否完成 = step3;
                         item.当次审批是否通过 = step4;
                       item.是否已获过审批 = step4;

                       // item.是否已提计划 = "否";
                       //item.是否已提采购 = "未采购";


                }
                    BOM_project_hold.SubmitChanges();
                    bool_temp = true;
                }
                catch
                {
                    bool_temp = false;
                }
                return bool_temp;
            }
            /// <summary>
            /// 更新BOM主表格数据
            /// </summary>
            /// <param name="projectID"></param>
            /// <param name="step1"></param>
            /// <param name="check_opinion"></param>
            /// <param name="SHOP"></param>
            /// <returns></returns>
            public bool updata_database_bom_(int projectID, int  supplies_ID, string step1, string step2, string step3)
           {
          
                bool bool_temp = false;
                try
                {
                    var q_abc_text = from t in BOM_all.BOM_ALL

                                     where t.项目ID == projectID  && t.是否激活 == "是"&&t.物料ID== supplies_ID
                                     //&& t.审核状态 == "已通过"
                                     //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                     //where t.代码.Contains(find_condition_text) || t.价格.ToString().Contains(find_condition_text) || t.全名.Contains(find_condition_text)
                                     //|| t.名称.Contains(find_condition_text) || t.品牌.Contains(find_condition_text) || t.图片.Contains(find_condition_text)
                                     //|| t.审核人.Contains(find_condition_text) || t.技术参数.Contains(find_condition_text) || t.规格型号.Contains(find_condition_text)
                                     //|| t.附件.Contains(find_condition_text)
                                     select t;

              
                    foreach (var item in q_abc_text)
                    {


                        item.是否激活 = step1;


                        item.审核状态 = step2;
                        item.审核意见 = step3;
                   

                        item.是否已提计划 = "未提";
                        item.采购状态 = "未采购";///目前小曲修改
                        //item.是否采购 = step3;


                        //int old_num = check_int(item.已采购数量);

                        //int all_num = check_int(item.总数量);

                        //int new_num = check_int(item.本次提交数量);

                        //int new_num_recently = check_int(item.最近一次数量);

                        //item.最近一次数量 = new_num;
                        //item.总数量 = old_num + new_num;

                        //item.已采购数量 = old_num + new_num;///目前小曲修改

                        //item.本次提交数量 = 0;//清零
                                
                    }
                    BOM_all.SubmitChanges();


             


                bool_temp = true;
                }
                catch
                {
                    bool_temp = false;
                }
                return bool_temp;
            }
        public static bool bom_all_count_empty;//为空标志
        /// <summary>
        /// 检测是否为空
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public bool checked_count_zero(int projectID)
        {
            bom_all_count_empty = false;
            bool   zero = false;
            BOM_all = new sql.DataClasses_BOM_ALLDataContext();

            var q_abc_text_find_s = from t in BOM_all.BOM_ALL

                                  where t.项目ID == projectID && t.是否激活 == "是"
                                  && t.审核状态 == "未审核"

                                  select t;
            if (q_abc_text_find_s.Count() == 0)
            {
                bom_all_count_empty = true;
            }
                var q_abc_text_find = from t in BOM_all.BOM_ALL

                                  where t.项目ID == projectID && t.是否激活 == "是"
                                  && t.审核状态 == "未审核"

                                  select t;
            if (q_abc_text_find.Count() == 0)
            {

                zero = true;
            }
            return zero;

        }
        public static bool CheckBox1_find_condition;
            public static bool CheckBox1_find_condition_display_old_count;

            /// <summary>
            /// 读取该项目的BOM区数据
            /// </summary>
            /// <param name="DataGridView_BOM_Hold"></param>
            /// <param name="project_id"></param>
            /// <returns></returns>
            public bool finad_bom_temp(DataGridView DataGridView_BOM_Hold, int project_id)
            {
                bool bool_temp = false;
                DataGridView_BOM_Hold.Rows.Clear();
                //先查询
                var q_find_supplies = from A in BOM_all.BOM_ALL

                                      where A.项目ID == project_id
                                     // where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                      //where c.代码.Contains(sort_keywords)
                                      //  where A.分类代码A
                                      select A;
                int row_now = 0;
                foreach (var q_find_one in q_find_supplies)
                {

                    string Is_SHOP = " "; if (q_find_one.是否激活 != null) { Is_SHOP = q_find_one.是否激活.ToString().Trim(); }
                    // DataGridView_BOM_Hold.Rows[row_now].Cells[10].Value = Is_SHOP;//10是否采购
                    int cell_num0 = 11;
                    string count_use = ""; if (q_find_one.本次提交数量 != null) { count_use = q_find_one.本次提交数量.ToString().Trim(); }
                    int cell_num3 = 10;
                    string shop_paied_count = ""; if (q_find_one.已采购数量 != null) { shop_paied_count = q_find_one.已采购数量.ToString().Trim(); }

                    int cell_num4 = 12;//总数量
                    string shop_paied_count_all = "0"; if (q_find_one.总数量 != null) { shop_paied_count_all = q_find_one.总数量.ToString().Trim(); }

                    int count_all = Convert.ToInt32(shop_paied_count_all);
                    int count_temp = Convert.ToInt32(count_use);

                    count_all = count_all + count_temp;
                    string shop_paied_count_old = ""; if (q_find_one.最近一次数量 != null) { shop_paied_count_old = q_find_one.最近一次数量.ToString().Trim(); }


                    string audit_status = ""; if (q_find_one.审核状态 != null) { audit_status = q_find_one.审核状态.ToString().Trim(); }

                //if (check_value(audit_status) != "已通过") { continue; }
                if (check_value(Is_SHOP) == "否") { continue; }
                //if (!CheckBox1_find_condition)
                //    {
                       

                //    }
                //    else//不过滤
                //    {

                //    }
                //    if (CheckBox1_find_condition_display_old_count)
                //    {
                //        count_use = shop_paied_count_old;
                //    }

                    //DataGridView_BOM_Hold.Rows.Add();
                    //0类别 1 ID  2 物料代码 3规格型号 4物料名称 5品牌 6数量  7技术参数 8备注 9价格 10是否采购 11审核状态 12审核意见 13采购计划  14采购状态 15已采购数量 16删除
                    //6数量 8备注  10是否采购 11审核状态 12审核意见 13采购计划  14采购状态 15已采购数量
                    string remarks = "";
                    if (q_find_one.备注 != null)
                    {

                        remarks = q_find_one.备注.ToString().Trim();
                    };

                    int ID = Convert.ToInt32(q_find_one.物料ID);
                    try
                    {

                        add_datagridview_hold_fromdatabase(DataGridView_BOM_Hold, ID, out row_now);
                    }
                    catch
                    {
                        MessageBox.Show("未找到物料ID:" + q_find_one.物料ID);
                    }


                    DataGridView_BOM_Hold.Rows[row_now].Cells[6].Value = count_use;//6数量


                    DataGridView_BOM_Hold.Rows[row_now].Cells[8].Value = remarks;//8备注

                //string Is_SHOP = ""; if (q_find_one.是否采购 != null) { Is_SHOP = q_find_one.是否采购.ToString().Trim(); }
                //DataGridView_BOM_Hold.Rows[row_now].Cells[10].Value = Is_SHOP;//10是否采购

                DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num0].Value = audit_status;//11审核状态

                //if (audit_status == "已通过") { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num0].Style.BackColor = Color.Green; }
                //else { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num0].Style.BackColor = Color.Gray; }

                string audit_idea = ""; if (q_find_one.审核意见 != null) { audit_idea = q_find_one.审核意见.ToString().Trim(); }
                DataGridView_BOM_Hold.Rows[row_now].Cells[12].Value = audit_idea;//12审核意见

                //int cell_num1 = 11;
                //string Is_request_shop = ""; if (q_find_one.是否已提计划 != null) { Is_request_shop = q_find_one.是否已提计划.ToString().Trim(); }
                //DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num1].Value = Is_request_shop;//13采购计划

                //if (Is_request_shop == "已提") { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num1].Style.BackColor = Color.Green; }
                //else { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num1].Style.BackColor = Color.Gray; }

                //int cell_num2 = 12;
                //string shop_status = ""; if (q_find_one.采购状态 != null) { shop_status = q_find_one.采购状态.ToString().Trim(); }
                //DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num2].Value = shop_status;//14采购状态
                //if (shop_status == "已采购") { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num2].Style.BackColor = Color.Green; }
                //else { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num2].Style.BackColor = Color.Red; }


                DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num3].Value = shop_paied_count;//15已采购数量





                    //DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num4].Value = count_all;//总数量

                    //  DataGridViewButtonCell buttonCell7 = (DataGridViewButtonCell)DataGridView_BOM_Hold.Rows[row_now].Cells[15];
                    //  DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)DataGridView_BOM_Hold.Rows[row_now].Cells[16];


                    //   chkBoxCell.Value = false;




                    // buttonCell7.Value = check_value(q_find_one.是否已提计划);

                    row_now++;

                }
                bool_temp = true;

                if (DataGridView_BOM_Hold.Rows.Count <= 0)
                {
                    bool_temp = false;
                    MessageBox.Show("该BOM为空！");
                }
                return bool_temp;
            }
        public bool finad_bom_temp_old(DataGridView DataGridView_BOM_Hold, int project_id)
        {
            bool bool_temp = false;
            DataGridView_BOM_Hold.Rows.Clear();
            //先查询
            var q_find_supplies = from A in BOM_all.BOM_ALL

                                  where A.项目ID == project_id
                                  //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                  //where c.代码.Contains(sort_keywords)
                                  //  where A.分类代码A
                                  select A;
            int row_now = 0;
            foreach (var q_find_one in q_find_supplies)
            {

                string Is_SHOP = " "; if (q_find_one.是否激活 != null) { Is_SHOP = q_find_one.是否激活.ToString().Trim(); }
                // DataGridView_BOM_Hold.Rows[row_now].Cells[10].Value = Is_SHOP;//10是否采购
                int cell_num0 = 11;
                string count_use = ""; if (q_find_one.本次提交数量 != null) { count_use = q_find_one.本次提交数量.ToString().Trim(); }
                int cell_num3 = 10;
                string shop_paied_count = ""; if (q_find_one.已采购数量 != null) { shop_paied_count = q_find_one.已采购数量.ToString().Trim(); }

                int cell_num4 = 12;//总数量
        
                string shop_paied_count_all = "0"; if (q_find_one.总数量 != null) { shop_paied_count_all = q_find_one.总数量.ToString().Trim(); }
              
                int count_all = Convert.ToInt32(shop_paied_count_all);
                int count_temp = Convert.ToInt32(count_use);

                count_all = count_all + count_temp;
                string shop_paied_count_old = ""; if (q_find_one.最近一次数量 != null) { shop_paied_count_old = q_find_one.最近一次数量.ToString().Trim(); }


                string audit_status = ""; if (q_find_one.审核状态 != null) { audit_status = q_find_one.审核状态.ToString().Trim(); }

                //if (check_value(audit_status) != "已通过") { continue; }
                if (check_value(Is_SHOP) == "否") { continue; }
                //if (!CheckBox1_find_condition)
                //    {


                //    }
                //    else//不过滤
                //    {

                //    }
                //    if (CheckBox1_find_condition_display_old_count)
                //    {
                //        count_use = shop_paied_count_old;
                //    }

                //DataGridView_BOM_Hold.Rows.Add();
                //0类别 1 ID  2 物料代码 3规格型号 4物料名称 5品牌 6数量  7技术参数 8备注 9价格 10是否采购 11审核状态 12审核意见 13采购计划  14采购状态 15已采购数量 16删除
                //6数量 8备注  10是否采购 11审核状态 12审核意见 13采购计划  14采购状态 15已采购数量
                string remarks = "";
                if (q_find_one.备注 != null)
                {

                    remarks = q_find_one.备注.ToString().Trim();
                };

                int ID = Convert.ToInt32(q_find_one.物料ID);
                try
                {

                    add_datagridview_hold_fromdatabase(DataGridView_BOM_Hold, ID, out row_now);
                }
                catch
                {
                    MessageBox.Show("未找到物料ID:" + q_find_one.物料ID);
                }
                row_now++;
               continue ;

                DataGridView_BOM_Hold.Rows[row_now].Cells[6].Value = count_use;//6数量


                DataGridView_BOM_Hold.Rows[row_now].Cells[8].Value = remarks;//8备注

                //string Is_SHOP = ""; if (q_find_one.是否采购 != null) { Is_SHOP = q_find_one.是否采购.ToString().Trim(); }
                //DataGridView_BOM_Hold.Rows[row_now].Cells[10].Value = Is_SHOP;//10是否采购

                DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num0].Value = audit_status;//11审核状态

                //if (audit_status == "已通过") { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num0].Style.BackColor = Color.Green; }
                //else { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num0].Style.BackColor = Color.Gray; }

                string audit_idea = ""; if (q_find_one.审核意见 != null) { audit_idea = q_find_one.审核意见.ToString().Trim(); }
                DataGridView_BOM_Hold.Rows[row_now].Cells[12].Value = audit_idea;//12审核意见

                //int cell_num1 = 11;
                //string Is_request_shop = ""; if (q_find_one.是否已提计划 != null) { Is_request_shop = q_find_one.是否已提计划.ToString().Trim(); }
                //DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num1].Value = Is_request_shop;//13采购计划

                //if (Is_request_shop == "已提") { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num1].Style.BackColor = Color.Green; }
                //else { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num1].Style.BackColor = Color.Gray; }

                //int cell_num2 = 12;
                //string shop_status = ""; if (q_find_one.采购状态 != null) { shop_status = q_find_one.采购状态.ToString().Trim(); }
                //DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num2].Value = shop_status;//14采购状态
                //if (shop_status == "已采购") { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num2].Style.BackColor = Color.Green; }
                //else { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num2].Style.BackColor = Color.Red; }


                DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num3].Value = shop_paied_count;//15已采购数量





                //DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num4].Value = count_all;//总数量

                //  DataGridViewButtonCell buttonCell7 = (DataGridViewButtonCell)DataGridView_BOM_Hold.Rows[row_now].Cells[15];
                //  DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)DataGridView_BOM_Hold.Rows[row_now].Cells[16];


                //   chkBoxCell.Value = false;




                // buttonCell7.Value = check_value(q_find_one.是否已提计划);

                row_now++;

            }
            bool_temp = true;

            if (DataGridView_BOM_Hold.Rows.Count <= 0)
            {
                bool_temp = false;
                MessageBox.Show("该BOM为空！");
            }
            return bool_temp;
        }
        sql.DataClasses1DataContext data_bom = new DataClasses1DataContext();
            /// <summary>
            /// 此函数用来向BOM暂存区从数据库读取数据的  
            /// </summary>
            /// <param name="datagridview_1"></param>
            /// <param name="ID"></param>
            public void add_datagridview_hold_fromdatabase(DataGridView datagridview_1, int ID, out int erow_num)
            {

                int erow_num_temp = 0;
                var q_ = from a in data_bom.Table_bom_all // bom_hold.Table_BOM_HOLD

                             //  where a.代码.Substring(0,3) == codeA && a.d == codeB
                             //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                             //where B.分类代码A.Contains(codeA)
                         where a.ID == ID
                         select a;



                List<string[]> list = new List<string[]>() { };
            int i = 0;
            
                i = datagridview_1.Rows.Count;

                if (i > 0)
                {
                    for (int i_d_find = 0; i_d_find < i; i_d_find++)
                    {

                        if (datagridview_1.Rows[i_d_find].Cells[1].Value.ToString().Trim() == ID.ToString().Trim())
                        {
                            MessageBox.Show("BOM里已有此物料！");
                            erow_num = 0;
                            return;

                        }
                    }

                }
          
                
                foreach (var K in q_)
                {
               

                
                    string[] strs = new string[] { K.ID.ToString(), K.代码, K.规格型号, K.名称, K.品牌, K.技术参数, K.价格.ToString() };
                    list.Add(strs);
                    DataGridViewRow row = new DataGridViewRow();
                    datagridview_1.Rows.Add(row);
                //datagridview_1.Rows[0].Cells["ID"].Value = "asa";
               
                if (K.ID.ToString() != "") { datagridview_1.Rows[i].Cells[1].Value = K.ID.ToString(); }
               
                if (strs[1] != "") { datagridview_1.Rows[i].Cells[2].Value = strs[1]; }
                if (strs[2] != "") { datagridview_1.Rows[i].Cells[3].Value = strs[2]; }
                if (strs[3] != "") { datagridview_1.Rows[i].Cells[4].Value = strs[3]; }
                if (strs[4] != "") { datagridview_1.Rows[i].Cells[5].Value = strs[4]; }
                if (strs[5] != "") { datagridview_1.Rows[i].Cells[6].Value = strs[5]; }
              

                if (strs[6] != "")
                    {
                        try
                        {

                            int totalprices = Convert.ToInt32(strs[6]);
                        }
                        catch
                        {

                        }
                    //totalprices
                    datagridview_1.Rows[i].Cells["价格"].Value = strs[6];
                }
                    //BOM_ALL0 

                    Global.temp_add_supplies_ID.Add(Convert.ToInt32(datagridview_1.Rows[i].Cells[1].Value));
                    erow_num_temp = i;
                    i++;
                }

                erow_num = erow_num_temp;

            }
            /// <summary>
            /// 获取当前行BOM信息
            /// </summary>
            /// <param name="datagridview1"></param>
            /// <param name="row_i"></param>
            /// <param name="column_i"></param>
            /// <returns></returns>
            public bool get_row_project_message(DataGridView datagridview1, int row_i, int column_i)
            {
                int ID_Colunm = 0;//ID
                int i_cell1 = 9;//
                int i_cell2 = 8;


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

                        if (nowcellname == "计划")
                        {
                            for (int i_d_find = 0; i_d_find < i; i_d_find++)
                            {

                                if (datagridview1.Rows[i_d_find].Cells[ID_Colunm].Value.ToString().Trim() == ID.ToString().Trim())
                                {
                                    int SET_ENABLE = 0;

                                    string audit_status = ""; if (datagridview1.Rows[row_i].Cells[i_cell1].Value != null) { audit_status = datagridview1.Rows[row_i].Cells[i_cell1].Value.ToString().Trim(); }

                                    if (audit_status == "已提")
                                    {
                                        DialogResult result = MessageBox.Show("确定要撤销为未提状态？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                        if (result == DialogResult.OK)
                                        {
                                            datagridview1.Rows[row_i].Cells[i_cell1].Value = "未提";
                                            SET_ENABLE = 1;
                                        }
                                        else
                                        {

                                        }


                                        //return true;
                                    }
                                    else
                                    {
                                        DialogResult result = MessageBox.Show("确定要修改为已提状态？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                        if (result == DialogResult.OK)
                                        {
                                            datagridview1.Rows[row_i].Cells[i_cell1].Value = "已提";


                                        
                                            SET_ENABLE = 2;
                                        }
                                        else
                                        {

                                        }

                                    }

                                }
                            }

                        }
                        bool_temp = true;
                    }
                    catch { bool_temp = false; }


                }
                return bool_temp;
            }
            public static bool Form2_procurement_open = false;
            /// <summary>
            /// 导出采购单
            /// </summary>
            /// <param name="DataGridView_BOM_Hold"></param>
            /// <param name="project_name"></param>
            /// <param name="num_st"></param>
            /// <param name="num_times"></param>
            /// <returns></returns>
            public bool shopping_out_put_excel(string project_name, string num_st, string num_times, DataGridView DataGridView_BOM_Hold)
            {
                string str_0 = num_st;
                string str_1 = num_times;
                Global.project_name = project_name;
                Global.project_ST_name = str_0;
                Global.project_ST_num_name = str_1;
                Global.project_BOM_SORT_name = "电气";





                add_list_bom(DataGridView_BOM_Hold);
                if (Form2_procurement_open == false)
                {
                    Form2_procurement form2 = new Form2_procurement();
                    form2.Show();
                }
                return true;

            }
            public void add_list_bom(DataGridView DataGridView_BOM_Hold)
            {
                int n = 1;
                if (Global.BOM_LIST != null)
                {
                    Global.BOM_LIST.Clear();
                }



                for (int i = 0; i < DataGridView_BOM_Hold.Rows.Count; i++)
                {
                    int row = i + 1;
                    if (DataGridView_BOM_Hold.Rows[i].Cells[2].Value == null) { MessageBox.Show("物料信息不全，请检查物料信息"); Form2_procurement_open = true; return; }
                    if (DataGridView_BOM_Hold.Rows[i].Cells[3].Value == null) { MessageBox.Show("物料信息不全，请检查物料信息"); Form2_procurement_open = true; return; }
                    if (DataGridView_BOM_Hold.Rows[i].Cells[4].Value == null) { MessageBox.Show("物料信息不全，请检查物料信息"); Form2_procurement_open = true; return; }
                    if (DataGridView_BOM_Hold.Rows[i].Cells[6].Value == null) { MessageBox.Show("第" + row.ToString() + "行物料数量未填！"); Form2_procurement_open = true; return; }
                    //if (DataGridView_BOM_Hold.Rows[i].Cells[6].Value.ToString()=="") { MessageBox.Show("第" + row.ToString() + "行物料数量未填！"); Form2_procurement_open = true; return; }
                    string count = "0 ";
                    string count_temp = "0 ";
                    string count_all = " 0";

                    string label = " ";
                    string remarks = " ";

                    if (DataGridView_BOM_Hold.Rows[i].Cells[6].Value != null) { try { count_temp = DataGridView_BOM_Hold.Rows[i].Cells[6].Value.ToString(); if (count_temp == "") { count = " "; } } catch { } }

                    if (DataGridView_BOM_Hold.Rows[i].Cells[12].Value != null) { try { count_all = DataGridView_BOM_Hold.Rows[i].Cells[12].Value.ToString(); if (count_all == "") { count = " "; } } catch { } }


                    if (shop_out_excel_temp_num == true)
                    {
                        count = count_temp;
                    }
                    else
                    {
                        count = count_all;
                    }

                    if (DataGridView_BOM_Hold.Rows[i].Cells[6].Value != null) { try { label = DataGridView_BOM_Hold.Rows[i].Cells[5].Value.ToString(); if (label == "") { label = " "; } } catch { } }
                    if (DataGridView_BOM_Hold.Rows[i].Cells[6].Value != null) { try { remarks = DataGridView_BOM_Hold.Rows[i].Cells[8].Value.ToString(); if (remarks == "") { remarks = " "; } } catch { } }


                    String[] ROW_ONE = new string[]{
                    DataGridView_BOM_Hold.Rows[i].Cells[1].Value.ToString(),//0 ID 
                    n.ToString(),//1序号
                    DataGridView_BOM_Hold.Rows[i].Cells[2].Value.ToString(),//2代码
                    DataGridView_BOM_Hold.Rows[i].Cells[3].Value.ToString(),//3物料名称
                    DataGridView_BOM_Hold.Rows[i].Cells[4].Value.ToString(),//4规格型号
                    "个",//5单位
                  
                   count ,//6数量
                   label ,//7品牌
                   remarks };//8备注
                    Global.BOM_LIST.Add(ROW_ONE);
                    n++;
                }
            }
            /// <summary>
            /// 导出BOM excel
            /// </summary>
            /// <param name="DataGridView_BOM_Hold"></param>
            /// <param name="project_name"></param>
            /// <param name="num_st"></param>
            /// <param name="num_times"></param>
            /// <returns></returns>
            public bool bom_out_put_excel(DataGridView DataGridView_BOM_Hold, string project_name, string num_st, string num_times)
            {
                bool temp_bool = false;

                string str_0 = project_name;
                string str_1 = num_st;
                string str_2 = num_times;

                string str_all = str_0 + " - " + str_1 + " - " + str_2;

                FolderDialog_file fdialog = new FolderDialog_file();
                string file_path = "";//tbFilePath = dialog.FileName;EXCEL表格文件(*.txt)|*.txt|所有文件(*.*)|*.*”c
                                      //fdialog. file_path_save("EXCEL表格文件(*.xls)|*.xls", out file_path);
                fdialog.file_path_save("EXCEL表格文件(*.xls)|*.xls", str_0 + " - " + str_1 + " - " + str_2 + "E", out file_path);
                PrintReporter(file_path, DataGridView_BOM_Hold, project_name, num_st, num_times);
                MessageBox.Show("生成成功！");
                temp_bool = true;
                return temp_bool;

            }
            private const string kSheetNameAbAssets = "Sheet1";

            private const string kSheetNameAbDetail = "Sheet2";
            public void PrintReporter(string path, DataGridView DataGridView_BOM_Hold, string str0, string str1, string str2)

            {//skinTextBox1.Text
             //MessageBox.Show(skinComboBox11.Text);return;
                var newFile = new FileInfo(path);

                if (newFile.Exists)

                {
                    newFile.Delete();
                }

                using (var package = new ExcelPackage(newFile))

                {

                    CreateWorksheetAbAssets(package.Workbook.Worksheets.Add(kSheetNameAbAssets));

                    // CreateWorksheetAbDetail(package.Workbook.Worksheets.Add(kSheetNameAbDetail));


                    FillWorksheetAbAssets(package.Workbook.Worksheets[1], DataGridView_BOM_Hold, str0, str1, str2);
                    package.Save();

                }

            }
            private static void CreateWorksheetAbAssets(ExcelWorksheet ws)

            {
                return;
                ws.TabColor = ColorTranslator.FromHtml("#32b1fa");

                // 标签颜色
                // 全体颜色
                ws.Cells.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#3d4d65"));

                {

                    // 边框样式

                    var border = ws.Cells.Style.Border;

                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                    // 边框颜色
                    var clr = ColorTranslator.FromHtml("#cad7e2");

                    border.Bottom.Color.SetColor(clr);

                    border.Top.Color.SetColor(clr);

                    border.Left.Color.SetColor(clr);


                    border.Right.Color.SetColor(clr);
                }
            }
            private void FillWorksheetAbAssets(ExcelWorksheet ws, DataGridView DataGridView_BOM_Hold, string str0, string str1, string str2)
            {


                // 测试数据
                ws.Cells[1, 1].Value = "[G]组别";
                ws.Cells[2, 1].Value = "组别代码";
                ws.Cells[2, 2].Value = "组别名称";
                ws.Cells[3, 1].Value = str0 + ".01";
                ws.Cells[3, 2].Value = "电气";
                ws.Cells[4, 1].Value = "[P]产品";

                ws.Cells[5, 1].Value = "BOM代码";
                ws.Cells[5, 2].Value = "代码";
                ws.Cells[5, 3].Value = "物料名称";
                ws.Cells[5, 4].Value = "规格型号";
                ws.Cells[5, 5].Value = "单位";
                ws.Cells[5, 6].Value = "数量";
                ws.Cells[5, 7].Value = "成品率";
                ws.Cells[5, 8].Value = "版本号";
                ws.Cells[5, 9].Value = "使用状态";
                ws.Cells[5, 10].Value = "类型";
                ws.Cells[5, 11].Value = "工艺路线代码";
                ws.Cells[5, 12].Value = "工艺路线名称";
                ws.Cells[5, 13].Value = "审核状态";
                ws.Cells[5, 14].Value = "备注";
                ws.Cells[5, 15].Value = "是否特性配置来源物料";
                ws.Cells[5, 16].Value = "跳层";


                //string str_0 = ""; //if (((ComboxItem)ComboBox_mechine_number.SelectedItem).Values != null) { str_0 = ((ComboxItem)ComboBox_mechine_number.SelectedItem).Values.Substring(0, 2); }
                //string str_1 = ""; // if (((ComboxItem)ComboBox_num_request.SelectedItem).Values != null) { str_1 = ((ComboxItem)ComboBox_num_request.SelectedItem).Values.Substring(0, 2); }
                ws.Cells[6, 1].Value = str0 + "-" + str1 + "-" + str2 + "E";//
                ws.Cells[6, 2].Value = "M09." + str0 + "-00-00-00-00E";//

                //  ws.Cells[6, 3].Value = "装配线";

                ws.Cells[6, 4].Value = str0 + "-00-00-00-00";//
                ws.Cells[6, 5].Value = "个";
                ws.Cells[6, 6].Value = "1";
                ws.Cells[6, 7].Value = "100";
                ws.Cells[6, 8].Value = "";
                ws.Cells[6, 9].Value = "未使用";
                ws.Cells[6, 10].Value = "0";
                ws.Cells[6, 11].Value = "";
                ws.Cells[6, 12].Value = "";
                ws.Cells[6, 13].Value = "未审核";
                ws.Cells[6, 14].Value = "";
                ws.Cells[6, 15].Value = "否";
                ws.Cells[6, 16].Value = "否";

                ws.Cells[7, 1].Value = "[D]材料";

                ws.Cells[8, 1].Value = "代码";
                ws.Cells[8, 2].Value = "物料名称";
                ws.Cells[8, 3].Value = "规格型号";
                ws.Cells[8, 4].Value = "单位";
                ws.Cells[8, 5].Value = "数量";
                ws.Cells[8, 6].Value = "损耗率";
                ws.Cells[8, 7].Value = "位置号";
                ws.Cells[8, 8].Value = "坯料尺寸";
                ws.Cells[8, 9].Value = "坯料数";
                ws.Cells[8, 10].Value = "工位";
                ws.Cells[8, 11].Value = "工序号";
                ws.Cells[8, 12].Value = "工序";
                ws.Cells[8, 13].Value = "是否倒冲";
                ws.Cells[8, 14].Value = "配置属性";
                ws.Cells[8, 15].Value = "提前期偏置";
                ws.Cells[8, 16].Value = "计划百分比";
                ws.Cells[8, 17].Value = "生效日期";
                ws.Cells[8, 18].Value = "失效日期";
                ws.Cells[8, 19].Value = "发料仓位";
                ws.Cells[8, 20].Value = "发料仓库";
                ws.Cells[8, 21].Value = "子项类型";
                ws.Cells[8, 22].Value = "备注";
                ws.Cells[8, 23].Value = "备注1";
                ws.Cells[8, 24].Value = "备注2";
                ws.Cells[8, 25].Value = "备注3";
                ws.Cells[8, 26].Value = "是否有特性";
                ws.Cells[8, 27].Value = "存在替代关系";

                int k = 9;

                for (int i = 0; i < DataGridView_BOM_Hold.Rows.Count; i++)
                {



                    ws.Cells[k, 1].Value = DataGridView_BOM_Hold.Rows[i].Cells[2].Value;//代码
                    ws.Cells[k, 2].Value = DataGridView_BOM_Hold.Rows[i].Cells[3].Value;//物料名称
                    ws.Cells[k, 3].Value = DataGridView_BOM_Hold.Rows[i].Cells[4].Value;//规格型号
                    ws.Cells[k, 4].Value = "个";//单位
                    if (bom_out_excel_temp_num)
                    {
                        ws.Cells[k, 5].Value = DataGridView_BOM_Hold.Rows[i].Cells[6].Value;//数量
                    }
                    else
                    {
                        ws.Cells[k, 5].Value = DataGridView_BOM_Hold.Rows[i].Cells[12].Value;//数量
                    }

                    ws.Cells[k, 6].Value = "0";//损耗率
                    ws.Cells[k, 13].Value = "否";
                    ws.Cells[k, 14].Value = "通用";
                    ws.Cells[k, 15].Value = "0";
                    ws.Cells[k, 16].Value = "100";
                    ws.Cells[k, 17].Value = "1900/1/1";
                    ws.Cells[k, 18].Value = "2100/1/1";
                    ws.Cells[k, 19].Value = "*";
                    ws.Cells[k, 20].Value = "01." + str0.Substring(1, 5);
                    ws.Cells[k, 21].Value = "普通件";
                    ws.Cells[k, 26].Value = "否";
                    ws.Cells[k, 27].Value = "N";
                    k++;
                }


                //ws.Cells[3, 1].Hyperlink = new ExcelHyperLink(kSheetNameAbDetail + "!A3", "SubTerrainObjs_1_1.assetbundle");


                //ws.Cells[4, 1].Hyperlink = new ExcelHyperLink(kSheetNameAbDetail + "!A300", "Terrain_Data_1_8.assetbundle");



            }
        /// <summary>
        /// 未审核 更新BOM
        /// </summary>
        /// <param name="datagridview1"></param>
        /// <param name="row_i"></param>
        /// <param name="column_i"></param>
        /// <param name="datagridview_list"></param>
        /// <returns></returns>
        public static bool close_ennable = false;//可以关闭申请单 
        public bool update_bom_all(DataGridView datagridview1, int row_i, int column_i, out bool zero)
        {
            zero = false;
            int ID_Colunm = 1;//ID
            int i_cell1 = 11;//
            int i_cell2 = 12;//
                             //int i_cell2 = 8;
                             //MessageBox.Show("");

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

                    if (nowcellname == "审核")
                    {
                        for (int i_d_find = 0; i_d_find < i; i_d_find++)
                        {

                            if (datagridview1.Rows[i_d_find].Cells[ID_Colunm].Value.ToString().Trim() == ID.ToString().Trim())
                            {
                                int SET_ENABLE = 0;
                                string audit_status = ""; if (datagridview1.Rows[row_i].Cells[i_cell1].Value != null) { audit_status = datagridview1.Rows[row_i].Cells[i_cell1].Value.ToString().Trim(); }
                                // MessageBox.Show(audit_status);
                                string opinion = check_value(datagridview1.Rows[row_i].Cells[i_cell2].Value);
                                if (audit_status == "已通过")
                                {
                                    datagridview1.Rows[row_i].Cells[i_cell1].Value = "未通过";
                                    bool zero_1 = false;
                                    updata_database_bom_(project_ID_NOW, ID, "否", "未通过", opinion);
                                    zero_1= checked_count_zero(project_ID_NOW);
                                    if (zero_1 == true)
                                    {

                                    }
                                }
                                else
                                {
                                    datagridview1.Rows[row_i].Cells[i_cell1].Value = "已通过";
                                    bool zero_2 = false;
                                    updata_database_bom_(project_ID_NOW, ID, "是", "已通过", opinion);
                                    zero_2 = checked_count_zero(project_ID_NOW);
                                    if (zero_2 == true)
                                    {
                                        close_ennable = true;
                                          DialogResult result2 = MessageBox.Show("此申请单已审批完是否关闭？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                        if (result2 == DialogResult.OK)
                                        {
                                            updata_database_project(project_ID_NOW, "是", "否", "未采购", "是");
                                            zero = zero_2;
                                        }
                                         
                                    }
                                  
                                }
                              
                              //  finad_bom_temp(datagridview_list, Convert.ToInt32(audit_status));
                                return bool_temp;


                            }
                        }

                    }
                    bool_temp = true;
                }
                catch { bool_temp = false; }


            }
            
            return bool_temp;
        }
        public string check_value(object str)
            {
                string str0 = " ";

                if (str != null) { str0 = str.ToString().Trim(); }
                str = str0;
                return str0;
            }
            public int check_int(object str)
            {
                string str0 = " ";

                if (str != null) { str0 = str.ToString().Trim(); }
                int i = 0;
                try
                {
                    i = Convert.ToInt32(str0);
                }
                catch
                {
                    i = 0;
                }
                str = str0;
                return i;
            }

        }

    }

