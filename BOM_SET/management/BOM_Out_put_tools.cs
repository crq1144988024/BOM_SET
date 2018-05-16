using BOM_SET.sql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOM_SET.management
{
     public class BOM_Out_put_tools
    {///
        /////DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)datagridview_1.Rows[i].Cells[6];
        //   DataGridViewButtonCell buttonCell7 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[7];
        //   DataGridViewButtonCell buttonCell8 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[8];


        //   bool temp = false;

        //           if (chkBoxCell != null && ((bool)chkBoxCell.EditingCellFormattedValue == true || (bool)chkBoxCell.FormattedValue == true))
        //           {
        //               temp = true;
        //           }

        //           if (temp == true)
        sql.DataClasses_LoginDataContext login = new sql.DataClasses_LoginDataContext();
        sql.DataClasses_BOM_ALLDataContext BOM_all = new sql.DataClasses_BOM_ALLDataContext();
        sql.bom_hoidDataContext   BOM_project_hold = new sql.bom_hoidDataContext();
        public void find_bom_project(DataGridView datagridview_1,bool bool_all)
        {
            
           
            if (!bool_all)
            {
                var q_abc_text = from t in BOM_project_hold.Table_BOM_HOLD

                                where t.是否已提计划 == "否"&& t.是否提交申请 == "是"

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


                    var q_name = from t in login.Login

                                 where t.ID == Convert.ToInt32(check_value(li.项目负责人ID))

                                 select t;
                    string nametemp = "";
                    foreach (var name in q_name)
                    {
                        nametemp = name.NAME;
                    }
                    datagridview_1.Rows[i].Cells[5].Value = check_value(nametemp); //项目负责人
                    datagridview_1.Rows[i].Cells[6].Value = check_value(li.备注); //备注
                                                                                //datagridview_1.Rows[i].Cells[5].Value = check_value(li.品牌);//品牌
                                                                                //datagridview_1.Rows[i].Cells[6].Value = check_value(li.技术参数); //技术参数
                                                                                //datagridview_1.Rows[i].Cells[7].Value = check_value(li.备注); //备注

                    //datagridview_1.Rows[i].Cells[8].Value = check_value(li.价格); //价格
                    //datagridview_1.Rows[i].Cells[9].Value = check_value(li.图片); //图片
                    //datagridview_1.Rows[i].Cells[10].Value = check_value(li.资料路径); //资料路径
                    //datagridview_1.Rows[i].Cells[11].Value = check_value(li.添加者); //添加者
                    //datagridview_1.Rows[i].Cells[12].Value = check_value(li.添加日期); //添加日期

                    DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)datagridview_1.Rows[i].Cells[7];
                    DataGridViewButtonCell buttonCell7 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[8];
                    //  DataGridViewComboBoxCell combox8 = (DataGridViewComboBoxCell)datagridview_1.Rows[i].Cells[9];
                    DataGridViewButtonCell combox8 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[9];
                    DataGridViewButtonCell combox10 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[10];
                    combox10.Value = "读取";
                    //chkBoxCell.Items.Add(new ComboxItem(str_0, str_0));

                    chkBoxCell.Value = false;
                    buttonCell7.Value = "导出";

                    combox8.Value = "未提";
               
                    //bool temp = false;



                    //if (temp == true)
                    //{

                    //}


                    //if (check_value(li.是否已提计划)=="是")
                    //{

                    //  buttonCell8.Value = "已";
                    //}
                    //else
                    //{

                    //}
                    i++;
                }

            }
            else
            {
                var q_abc_text = from t in BOM_project_hold.Table_BOM_HOLD

                                 where t.是否提交申请 == "是"

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


                    var q_name = from t in login.Login

                                 where t.ID == Convert.ToInt32(check_value(li.项目负责人ID))

                                 select t;
                    string nametemp = "";
                    foreach (var name in q_name)
                    {
                        nametemp = name.NAME;
                    }
                    datagridview_1.Rows[i].Cells[5].Value = check_value(nametemp); //项目负责人
                    datagridview_1.Rows[i].Cells[6].Value = check_value(li.备注); //备注
                                                                                //datagridview_1.Rows[i].Cells[5].Value = check_value(li.品牌);//品牌
                                                                                //datagridview_1.Rows[i].Cells[6].Value = check_value(li.技术参数); //技术参数
                                                                                //datagridview_1.Rows[i].Cells[7].Value = check_value(li.备注); //备注

                    //datagridview_1.Rows[i].Cells[8].Value = check_value(li.价格); //价格
                    //datagridview_1.Rows[i].Cells[9].Value = check_value(li.图片); //图片
                    //datagridview_1.Rows[i].Cells[10].Value = check_value(li.资料路径); //资料路径
                    //datagridview_1.Rows[i].Cells[11].Value = check_value(li.添加者); //添加者
                    //datagridview_1.Rows[i].Cells[12].Value = check_value(li.添加日期); //添加日期

                    DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)datagridview_1.Rows[i].Cells[7];
                    DataGridViewButtonCell buttonCell7 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[8];
                    //DataGridViewComboBoxCell combox8 = (DataGridViewComboBoxCell)datagridview_1.Rows[i].Cells[9];
                    DataGridViewButtonCell combox8 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[9];

                    //chkBoxCell.Items.Add(new ComboxItem(str_0, str_0));

                    chkBoxCell.Value = false;
                    buttonCell7.Value = "导出";
                    if (check_value(li.是否已提计划) == "是")
                    {
                        combox8.Value ="已提" ;
                    }
                    else
                    {
                        combox8.Value = "未提";
                    }
                    DataGridViewButtonCell combox10 = (DataGridViewButtonCell)datagridview_1.Rows[i].Cells[10];
                    combox10.Value = "读取";
                    //bool temp = false;



                    //if (temp == true)
                    //{

                    //}


                    //if (check_value(li.是否已提计划)=="是")
                    //{

                    //  buttonCell8.Value = "已";
                    //}
                    //else
                    //{

                    //}
                    i++;
                }
            }
          
        }
        public bool read_bom_all(DataGridView datagridview1, int row_i, int column_i, DataGridView datagridview_list)
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
                               
                                   
                                    finad_bom_temp(datagridview_list, Convert.ToInt32(audit_status));
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
        public bool chech_audit(DataGridView datagridview1, int row_i, int column_i)
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
        /// <summary>
        /// 更新bom_project区数据
        /// </summary>
        DataClasses_BOM_ALLDataContext bomall_classes = new DataClasses_BOM_ALLDataContext();
        public bool updata_database_project(int projectID, String step1, string step2, String step3)
        {
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
                    item.是否提交申请 = step1;
                    item.是否已提计划 = step2;
                    item.是否已提采购 = step3;
                
                  
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
        public bool updata_database_bom(int projectID, String step1, string step2, String step3)
        {
            bool bool_temp = false;
            try
            {
                var q_abc_text = from t in bomall_classes.BOM_ALL

                                 where t.项目ID == projectID&& t.审核状态== "已审核"&&t.是否采购=="是"
                                 //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                 //where t.代码.Contains(find_condition_text) || t.价格.ToString().Contains(find_condition_text) || t.全名.Contains(find_condition_text)
                                 //|| t.名称.Contains(find_condition_text) || t.品牌.Contains(find_condition_text) || t.图片.Contains(find_condition_text)
                                 //|| t.审核人.Contains(find_condition_text) || t.技术参数.Contains(find_condition_text) || t.规格型号.Contains(find_condition_text)
                                 //|| t.附件.Contains(find_condition_text)
                                 select t;


                foreach (var item in q_abc_text)
                {
                    item.是否提交申请 = step1;
                    item.是否已提计划 = step2;
                    item.是否采购 = step3;



                    int old_num = check_int(item.已采购数量);

                    int all_num= check_int(item.数量);
                    //int all_num = check_int(item.本次提交数量);
                    //DataGridViewButtonCell button_checked = (DataGridViewButtonCell)datagridview1.Rows[i].Cells[11];
                    //DataGridViewButtonCell button_delete = (DataGridViewButtonCell)datagridview1.Rows[i].Cells[12];
                    //    item.审核日期 = DateTime.Now.ToString();
                    //    item.是否审核 = "是";
                    //    item.物料ID = BOMAL_ID.ToString().Trim();
                    //    if (check_opinion != null)
                    //    {

                    //        item.审核意见 = check_opinion;



                    //    }

                    //}
                    bomall_classes.SubmitChanges();
                    bool_temp = true;
                }
            }
            catch
            {
                bool_temp = false;
            }
            return bool_temp;
        }
        /// <summary>
        /// 读取该项目的BOM区数据
        /// </summary>
        /// <param name="DataGridView_BOM_Hold"></param>
        /// <param name="project_id"></param>
        /// <returns></returns>
        public bool finad_bom_temp(DataGridView DataGridView_BOM_Hold,int project_id)
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

                string count_use = ""; if (q_find_one.数量 != null) { count_use = q_find_one.数量.ToString().Trim(); }
                DataGridView_BOM_Hold.Rows[row_now].Cells[6].Value = count_use;//6数量


                DataGridView_BOM_Hold.Rows[row_now].Cells[8].Value = remarks;//8备注

                //string Is_SHOP = ""; if (q_find_one.是否采购 != null) { Is_SHOP = q_find_one.是否采购.ToString().Trim(); }
                //DataGridView_BOM_Hold.Rows[row_now].Cells[10].Value = Is_SHOP;//10是否采购
                int cell_num0 = 10;
                string audit_status = ""; if (q_find_one.审核状态 != null) { audit_status = q_find_one.审核状态.ToString().Trim(); }
                DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num0].Value = audit_status;//11审核状态
                if (audit_status == "已审核") { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num0].Style.BackColor = Color.Green; }
                else { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num0].Style.BackColor = Color.Gray; }

                //string audit_idea = ""; if (q_find_one.审核意见 != null) { audit_idea = q_find_one.审核意见.ToString().Trim(); }
                //DataGridView_BOM_Hold.Rows[row_now].Cells[12].Value = audit_idea;//12审核意见

                int cell_num1 = 11;
                string Is_request_shop = ""; if (q_find_one.是否已提计划 != null) { Is_request_shop = q_find_one.是否已提计划.ToString().Trim(); }
                DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num1].Value = Is_request_shop;//13采购计划
                if (Is_request_shop == "已提") { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num1].Style.BackColor = Color.Green; }
                else { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num1].Style.BackColor = Color.Gray; }

                int cell_num2 = 12;
                string shop_status = ""; if (q_find_one.采购状态 != null) { shop_status = q_find_one.采购状态.ToString().Trim(); }
                DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num2].Value = shop_status;//14采购状态
                if (shop_status == "已采购") { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num2].Style.BackColor = Color.Green; }
                else { DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num2].Style.BackColor = Color.Red; }

                int cell_num3 = 13;
                string shop_paied_count = ""; if (q_find_one.已采购数量 != null) { shop_paied_count = q_find_one.已采购数量.ToString().Trim(); }
                DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num3].Value = shop_paied_count;//15已采购数量

                int cell_num4 = 14;//总数量
                string shop_paied_count_all = ""; if (q_find_one.数量 != null) { shop_paied_count_all = q_find_one.数量.ToString().Trim(); }
                DataGridView_BOM_Hold.Rows[row_now].Cells[cell_num3].Value = shop_paied_count_all;//

                DataGridViewButtonCell buttonCell7 = (DataGridViewButtonCell)DataGridView_BOM_Hold.Rows[row_now].Cells[15];
                DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)DataGridView_BOM_Hold.Rows[row_now].Cells[16];


                chkBoxCell.Value = false;
             

             
              
                   buttonCell7.Value = check_value(q_find_one.是否已提计划);

                row_now++;

            }
            bool_temp = true;
            return bool_temp;
        }
        sql.DataClasses1DataContext  data_bom = new DataClasses1DataContext();
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
            int i = datagridview_1.Rows.Count;

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
                if (strs[0] != "") { datagridview_1.Rows[i].Cells["ID"].Value = strs[0]; }
                if (strs[1] != "") { datagridview_1.Rows[i].Cells["物料代码"].Value = strs[1]; }
                if (strs[2] != "") { datagridview_1.Rows[i].Cells["规格型号"].Value = strs[2]; }
                if (strs[3] != "") { datagridview_1.Rows[i].Cells["物料名称"].Value = strs[3]; }
                if (strs[4] != "") { datagridview_1.Rows[i].Cells["品牌"].Value = strs[4]; }
                if (strs[5] != "") { datagridview_1.Rows[i].Cells["技术参数"].Value = strs[5]; }


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

                Global.temp_add_supplies_ID.Add(Convert.ToInt32(datagridview_1.Rows[i].Cells["ID"].Value));
                erow_num_temp = i;
                i++;
            }

            erow_num = erow_num_temp;

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
