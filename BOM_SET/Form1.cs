
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

namespace BOM_SET
{

    public partial class Form1 : Skin_Metro
    {
        
        DataClasses_Code_ABCDataContext Code_ABC = new DataClasses_Code_ABCDataContext();
        bom_hoidDataContext bom_hold = new bom_hoidDataContext();
        bom_sortDataContext bom_sort = new bom_sortDataContext();
        private const string kSheetNameAbAssets = "Sheet1";

        private const string kSheetNameAbDetail = "Sheet2";
        public Form1()
        {
            InitializeComponent();
            Global.dataset.Tables.Add("table1");
            codeA(comboxcode_A, comboxcode_B, comboxcode_C);
            find_add_datagridview(datagridview_matter);
            datagridview_matter.Rows.Clear();


            //以下是物料新增页面

            codeA(skinComboBox_A1, skinComboBox_B1, skinComboBox_C1);
            codeA(skinComboBox_A2, skinComboBox_B2, skinComboBox_C2);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Enabled = false;
            LOGIN.ID.login_now_Permission = -1;
            timer1.Enabled = true;
            LOGIN.Login_form form1 = new LOGIN.Login_form();
            form1.Show();
           

        }
       

        public   void set_login()
        {
           

            if (LOGIN.ID.login_now_Permission == 100)
            {
                ToolStripMenuItem1.Enabled = false;
                ToolStripMenuItem3.Enabled = false;
                tabControl1.Enabled = false;
                toolStripLabel_peoplename.Text = "未登录";
                toolStripStatusLabel_permission.Text = "未知";
                toolStripStatusLabel_sort.Text = "未知";
                ToolStripMenuItem4.Text = "登录系统";
                LOGIN.ID.login_now_Permission = -1;
                timer1.Enabled = false;
                return;
            }
            if (LOGIN.ID.login_now_Permission == 0)
            {
               
                this.Close();
                return;
            }
            if(LOGIN.ID.login_now_Permission > 0 && ToolStripMenuItem4.Text == "登录系统")
            {
                if (LOGIN.ID.login_now_Permission >= 2)
                {
                    ToolStripMenuItem1.Enabled = true;
                    // ToolStripMenuItem2.Enabled = true;
                    //  ToolStripMenuItem3.Enabled = true;
                    ToolStripMenuItem3.Enabled = true;




                }
                else
                {
                    ToolStripMenuItem1.Enabled = false;
                    //ToolStripMenuItem2.Enabled = false;
                    //ToolStripMenuItem3.Enabled = false;
                    ToolStripMenuItem3.Enabled = false;

                }
                toolStripLabel_peoplename.Text = LOGIN.ID.login_now_Nanme;
                toolStripStatusLabel_permission.Text = LOGIN.ID.login_now_Permission_str;
                toolStripStatusLabel_sort.Text = LOGIN.ID.login_now_SORT_str;
                tabControl1.Enabled = true ;

                //for(int i=0;i<tabControl1.TabPages.Count;i++)
                //{
                //    tabControl1.TabPages[i].Parent = this.tabControl1;
                //}
                TabPage tp0 = tabControl1.TabPages[0];//BOM   
                TabPage tp1 = tabControl1.TabPages[1];//物料新增  
                TabPage tp2 = tabControl1.TabPages[2];//报价
                TabPage tp3 = tabControl1.TabPages[3];//采购
                TabPage tp4 = tabControl1.TabPages[4];//图纸管理
                TabPage tp5 = tabControl1.TabPages[5];//物料管理
                TabPage tp6 = tabControl1.TabPages[6];//物料审核

                tabControl1.TabPages.Remove(tp0);//隐藏（删除）
                tabControl1.TabPages.Remove(tp1);//隐藏（删除）
                tabControl1.TabPages.Remove(tp2);//隐藏（删除）
                tabControl1.TabPages.Remove(tp3);//隐藏（删除）
                tabControl1.TabPages.Remove(tp4);//隐藏（删除）
                tabControl1.TabPages.Remove(tp5);//隐藏（删除）
                tabControl1.TabPages.Remove(tp6);//隐藏（删除）
                if (LOGIN.ID.login_now_Permission >= 3)
                {
                    tabControl1.TabPages.Insert(0, tp0);///BOM
                    tabControl1.TabPages.Insert(1, tp1);//物料新增  
                    tabControl1.TabPages.Insert(2, tp2);//报价
                    tabControl1.TabPages.Insert(3, tp3);//采购
                    tabControl1.TabPages.Insert(4, tp4);//图纸管理）
                    tabControl1.TabPages.Insert(5, tp5);//物料管理
                    tabControl1.TabPages.Insert(6, tp6);//物料审核
                }
                else
                {
                    if (LOGIN.ID.login_now_SORT == 1)//电气设计
                    {//采购 和 数据库管理员
                        tabControl1.TabPages.Insert(0, tp0);///BOM
                        tabControl1.TabPages.Insert(1, tp1);//物料新增  
                        tabControl1.TabPages.Insert(2, tp2);//报价
                        ComboBox_bom_sort.Text = "电气";
                        ComboBox_bom_sort.Enabled = false;
                        find_bom_usernoew_Project_name_add();


                    }
                    if (LOGIN.ID.login_now_SORT == 2)//机械设计
                    {
                        tabControl1.TabPages.Insert(0, tp0);///BOM
                        tabControl1.TabPages.Insert(1, tp1);//物料新增  
                        tabControl1.TabPages.Insert(2, tp2);//报价
                        ComboBox_bom_sort.Text = "机械";
                        ComboBox_bom_sort.Enabled = false;
                        find_bom_usernoew_Project_name_add();
                    }
                    if (LOGIN.ID.login_now_SORT == 3)//物料管理员
                    {
                        tabControl1.TabPages.Insert(1, tp1);//物料新增  
                       
                       tabControl1.TabPages.Insert(4, tp4);//图纸管理
                        tabControl1.TabPages.Insert(5, tp5);//物料管理
                    }
                    if (LOGIN.ID.login_now_SORT == 4)//采购
                    {
                        tabControl1.TabPages.Insert(3, tp3);//采购
                    }
                    if (LOGIN.ID.login_now_SORT == 5)//电气审核
                    {
                        tabControl1.TabPages.Insert(0, tp0);///BOM
                        tabControl1.TabPages.Insert(1, tp1);//物料新增  
                        tabControl1.TabPages.Insert(2, tp2);//报价
                      //  tabControl1.TabPages.Insert(3, tp3);//采购
                        tabControl1.TabPages.Insert(4, tp4);//图纸管理
                        tabControl1.TabPages.Insert(5, tp5);//物料管理
                        tabControl1.TabPages.Insert(6, tp6);//物料审核
                        ComboBox_bom_sort.Text = "电气";
                        ComboBox_bom_sort.Enabled = false;
                        find_bom_usernoew_Project_name_add();
                    }
                    if (LOGIN.ID.login_now_SORT == 6)//机械审核
                    {
                        tabControl1.TabPages.Insert(0, tp0);///BOM
                        tabControl1.TabPages.Insert(1, tp1);//物料新增  
                        tabControl1.TabPages.Insert(2, tp2);//报价
                      //  tabControl1.TabPages.Insert(3, tp3);//采购
                        tabControl1.TabPages.Insert(4, tp4);//图纸管理
                        tabControl1.TabPages.Insert(5, tp5);//物料管理
                        tabControl1.TabPages.Insert(6, tp6);//物料审核
                        ComboBox_bom_sort.Text = "机械";
                        ComboBox_bom_sort.Enabled = false;
                        find_bom_usernoew_Project_name_add();
                    }
                }
                   
                timer1.Enabled = false;
                ToolStripMenuItem4.Text = "退出登录";
                return;
            }
          

          
        }
        public void find_bom_usernoew_Project_name_add()
        {
            ComboBox_project_name.Items.Clear();
            
            var customer = from cust in bomstruct_classes.Table_BOM_HOLD

                           where Convert.ToInt32(cust.项目负责人ID) == LOGIN.ID.login_now_ID
                        
                           //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                           //where c.代码.Contains(sort_keywords)
                           //  where A.分类代码A
                           select cust;

            foreach (var item in customer)
            {
                string str_0 = "";
                string str_1 = "";
                string str_2 = "";
                bool find_temp = false;
                for(int i=0;i< ComboBox_project_name.Items.Count;i++)
                {
                    string strDict = ((ComboxItem)ComboBox_project_name.Items[i]).Values.ToString().Trim();
                    if(strDict== item.项目代号.ToString().Trim())
                    {
                        find_temp = true;
                        break;
                    }
                }
                str_0 = item.项目代号.ToString().Trim();
                str_1 = item.设备序号.ToString().Trim();
                str_2 = item.第几次申请.ToString().Trim();
                if (find_temp == false)
                {
                    
                    ComboBox_project_name.Items.Add(new ComboxItem(str_0, str_0));
                }
                string project_all = "";
              if (ComboBox_bom_sort.Text == "电气")
                {
                    project_all = str_0 + "-" + str_1 + "-" + str_2 + "E";
                }
                else
                {
                    project_all = str_0 + "-" + str_1 + "-" + str_2 + "M";
                }
                    

                listBox_project_recods.Items.Add(new ComboxItem(project_all, project_all));
            }


            
        }
        /// <summary>
        /// 登陆之后读取用户的BOM
        /// </summary>
        /// <param name="user_ID"></param>
        public void find_bom_usernoew(string PROJECT_NAME)
        {
            ComboBox_mechine_number.Items.Clear();
            ComboBox_num_request.Items.Clear();
            var customer = from cust in bomstruct_classes.Table_BOM_HOLD

                           where Convert.ToInt32(cust.项目负责人ID) == LOGIN.ID.login_now_ID
                           && cust.项目代号.Trim() == PROJECT_NAME.Trim()
                           //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                           //where c.代码.Contains(sort_keywords)
                           //  where A.分类代码A
                           select cust;
            if (customer.Count() == 0)
            {
                //没有该表格则新增
            };
            int g = 0;
            for (int i = 0; i < 60; i++)
            {
                string str_0 = "";
                string str_projectname = "";


                if (g < 10)
                {
                    str_0 = "0" + g.ToString();
                }
                else
                {
                    str_0 = g.ToString();
                }


                foreach (var item in customer)
                {
                    if (Convert.ToInt32(item.设备序号) == g)
                    {
                        str_0 = str_0 + "  已提";

                        break;
                    }

                }




                if (g == 52)
                {
                    ComboBox_mechine_number.SelectedIndex = 0;
                    find_bom_usernoew_num("00");
                    ComboBox_num_request.SelectedIndex = 0;
                    return;
                }

                if (g == 52)
                {
                    return;
                }
                //  string str_projectname = str_0;

                // str_projectname =



                ComboBox_mechine_number.Items.Add(new ComboxItem(str_0, str_0));
                
                g++;
                // ComboBox_num_request.Items.Add(str_1);
            }
           
        }

            /// <summary>
            /// 提的次数更新
            /// </summary>
        public void find_bom_usernoew_num(string  NUM)
        {
            ComboBox_num_request.Items.Clear();
            var customer = from cust in bomstruct_classes.Table_BOM_HOLD

                           where Convert.ToInt32(cust.项目负责人ID) == LOGIN.ID.login_now_ID
                           && Convert.ToInt32(cust.设备序号) == Convert.ToInt32(NUM)
                           //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                           //where c.代码.Contains(sort_keywords)
                           //  where A.分类代码A
                           select cust;
            if (customer.Count() == 0)
            {
                //没有该表格则新增
            };
            int g = 0;
            for (int i = 0; i < 60; i++)
            {
                string str_0 = "";
                string str_projectname = "";


                if (g < 10)
                {
                    str_0 = "0" + g.ToString();
                }
                else
                {
                    str_0 = g.ToString();
                }
               
              
                  foreach(var  item in customer) 
                    {
                        if ( Convert.ToInt32( item.第几次申请)== g)
                        {
                            str_0 = str_0 + "  已提";

                           break;
                        }

                    }


              

                if (g == 52)
                {
                    ComboBox_num_request.SelectedIndex = 0;
                    return;
                }
                //  string str_projectname = str_0;

                // str_projectname =



                //ComboBox_mechine_number.Items.Add(str_0);
                ComboBox_num_request.Items.Add(new ComboxItem(str_0, str_0));
                g++;
            }
          
            //ComboBox_project_name.Text = "";//项目代号

            //ComboBox_mechine_number.Text = "";//工站号
            //ComboBox_num_request.Text = "";//第几次申请




        }
        /// <summary>
        /// 生成BOM表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton1_Click(object sender, EventArgs e)
        {

            Global.project_name = ComboBox_project_name.Text;
            string str_0 = ""; if (((ComboxItem)ComboBox_mechine_number.SelectedItem).Values != null) { str_0 = ((ComboxItem)ComboBox_mechine_number.SelectedItem).Values.Substring(0, 2); }
            Global.project_ST_name = str_0;
            string str_1 = ""; if (((ComboxItem)ComboBox_num_request.SelectedItem).Values != null) { str_1 = ((ComboxItem)ComboBox_num_request.SelectedItem).Values.Substring(0, 2); }
            Global.project_ST_num_name =str_1;
            Global.project_BOM_SORT_name = ComboBox_bom_sort.Text;
            Form2_procurement_open = false;
            if (Global.project_name == null || Global.project_ST_name == null || Global.project_ST_num_name == null || Global.project_BOM_SORT_name == null)
            { MessageBox.Show("请填写完整的项目信息！"); Form2_procurement_open = true; return; }
            if (Global.project_name.Length < 4 || Global.project_ST_name.Length < 2 || Global.project_ST_num_name.Length < 1 || Global.project_BOM_SORT_name.Length < 1)
            { MessageBox.Show("请填写完整的项目信息！"); Form2_procurement_open = true; return; }

            bool inspect_ = inspect();
            if (inspect_ == true) { MessageBox.Show("数据库已有该BOM配置,为了防止数据不统一请先读取BOM数据,再操作！"); return; }

            //using (OfficeOpenXml.ExcelPackage package = new ExcelPackage(new FileInfo(@"d:\test.xlsx"))) { }
            //Form2_procurement_open = false;
            //if (Global.project_name == null || Global.project_ST_name == null) { MessageBox.Show("请填写项目信息！"); Form2_procurement_open = true; return; }
            //if (Global.project_name.Length < 4 || Global.project_ST_name.Length < 2) { MessageBox.Show("请填写项目信息！"); Form2_procurement_open = true; return; }

            if (Form2_procurement_open == false)
            {
                FolderDialog_file fdialog = new FolderDialog_file();
                string file_path = "";//tbFilePath = dialog.FileName;EXCEL表格文件(*.txt)|*.txt|所有文件(*.*)|*.*”c
                                      //fdialog. file_path_save("EXCEL表格文件(*.xls)|*.xls", out file_path);
                fdialog.file_path_save("EXCEL表格文件(*.xls)|*.xls", ComboBox_project_name.Text + " - " + str_0 + " - " + str_1 + "E", out file_path);
                PrintReporter(file_path); //"d:" + ComboBox_project_name.Text + " - " + str_0 + " - " + str_1 + "E" + ".xls");
                MessageBox.Show("生成成功！");
            }
        }
        public  void PrintReporter(string path)

        {//skinTextBox1.Text
         //MessageBox.Show(skinComboBox11.Text);return;
            string str_0 = "";  if (((ComboxItem)ComboBox_mechine_number.SelectedItem).Values != null) { str_0 = ((ComboxItem)ComboBox_mechine_number.SelectedItem).Values.Substring(0, 2); }
            string str_1 = ""; if (((ComboxItem)ComboBox_num_request.SelectedItem).Values != null) { str_1 = ((ComboxItem)ComboBox_num_request.SelectedItem).Values.Substring(0, 2); }
            var newFile = new FileInfo(path);
            Global.procurement_name = ComboBox_project_name.Text + " - " + str_0 + " - " + str_1;
            if (newFile.Exists)

            {
                newFile.Delete();
            }

            using (var package = new ExcelPackage(newFile))

            {

                CreateWorksheetAbAssets(package.Workbook.Worksheets.Add(kSheetNameAbAssets));

                // CreateWorksheetAbDetail(package.Workbook.Worksheets.Add(kSheetNameAbDetail));

                FillWorksheetAbAssets(package.Workbook.Worksheets[1]);

                package.Save();

            }

        }

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
            string codeB ="."+ comboxcode_B.SelectedItem.ToString();

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
        List<string> list_ID_FIND = new List<string>();
        List<string[]> list0_all = new List<string[]>() { };
        ////
        public void search_datagridview(DataGridView datagridview_1)
        {
            string find_condition_text = Textbox_find.Text.Trim();
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
                    string[] strs = new string[] { "", li.代码, li.名称, li.品牌, li.技术参数, li.价格.ToString(), li.图片, li.规格型号, li.附件, li.全名, li.审核人 };
                    if ((int)strs[1][0] > 127) { continue; }

                    for (int k = 1; k < 10; k++)
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
                    datagridview_1.Rows[n].Cells[1].Value = li[1];
                    datagridview_1.Rows[n].Cells[2].Value = li[2];
                    datagridview_1.Rows[n].Cells[3].Value = li[3];
                    datagridview_1.Rows[n].Cells[4].Value = li[4];
                    datagridview_1.Rows[n].Cells[0].Value = li[10];
                    datagridview_1.Rows[n].Cells[5].Value = li[5];//价格
                    datagridview_1.Rows[n].Cells[6].Value = "添加";


                    n++;

                }
                list0_all = list0;
                return;
            } else { }
            //  if (comboxcode_A.SelectedText == null | comboxcode_B.SelectedText == null) return;
            string codeA = "";
            string codeB = "";
            string codeC = "";

            if (comboxcode_A.SelectedItem != null) { codeA = comboxcode_A.SelectedItem.ToString().Substring(0, 3); }
            if (comboxcode_B.SelectedItem != null) { codeB = "."+comboxcode_B.SelectedItem.ToString().Substring(0, 2); }
            if (comboxcode_C.SelectedItem != null) { codeC = comboxcode_C.SelectedItem.ToString().Substring(0, 1); }



            var q_abc = from a in data_bom.Table_bom_all

                            //  where a.代码.Substring(0,3) == codeA && a.d == codeB
                            //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                            //where B.分类代码A.Contains(codeA)
                        select a;

            List<string[]> list = new List<string[]>() { };


            foreach (var li in q_abc)
            {
                string[] strs = new string[] { li.代码, li.名称, li.品牌, li.技术参数, li.价格.ToString(), li.图片, li.规格型号, li.附件, li.全名, li.审核人, li.ID.ToString() };
                if ((int)strs[0][0] > 127) { continue; }

                if (codeA != "")
                {
                    if (strs[0].Trim().Length < 3) { continue; }

                    if (strs[0].Trim().Substring(0, 3) == codeA)
                    {


                        if (codeB != "")
                        {
                            if (strs[0].Trim().Length < 6) { continue; }
                            if (strs[0].Trim().Substring(3, 3) == codeB)
                            {
                                if (codeC != "")
                                {
                                    if (strs[0].Trim().Length < 8) { continue; }
                                    if (strs[0].Trim().Substring(6, 1) == ".")
                                    {
                                        if (strs[0].Trim().Substring(7, 1) == codeC)
                                        {
                                            list.Add(strs);
                                        }
                                        else { }

                                    }
                                    else { if (strs[0].Trim().Substring(6, 1) == codeC) { list.Add(strs); } }
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
                    DataGridViewRow row = new DataGridViewRow();
                    datagridview_1.Rows.Add(row);
                    if (li[0] != "") { datagridview_1.Rows[i].Cells[1].Value = li[0]; }
                    if (li[1] != "") { datagridview_1.Rows[i].Cells[2].Value = li[1]; }
                    if (li[2] != "") { datagridview_1.Rows[i].Cells[3].Value = li[2]; }
                    if (li[3] != "") { datagridview_1.Rows[i].Cells[4].Value = li[3]; }
                    if (li[4] != "") { datagridview_1.Rows[i].Cells[5].Value = li[3]; }
                    if (li[10] != "") { datagridview_1.Rows[i].Cells[0].Value = li[10]; }
                    datagridview_1.Rows[i].Cells[6].Value = "添加";
                    list_ID_FIND.Add(li[10]);
                    i++;
                }



            }


        }








        /// <summary>
        /// 此函数用来搜索数据
        /// </summary>
        /// <param name="ws"></param>
        public void find_add_datagridview(DataGridView datagridview_1)
        {
            // string strAlbumID = ((DataGridViewTextBoxCell)this.dataGridView1.Rows[e.RowIndex].Cells["txt_A"]).Value.ToString().Trim();

            for (int i = 0; i < 8; i++)
            {


            }

            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //  btn.Name = "colbtn";
            //  btn.HeaderText = "查询明细";
            //  btn.DefaultCellStyle.NullValue = "查询明细";
            DataGridViewTextBoxCell text = new DataGridViewTextBoxCell();


            DataGridViewButtonCell BTN = new DataGridViewButtonCell();
            BTN.Value = "添加2";
            BTN.ToolTipText = "添加2";
            BTN.UseColumnTextForButtonValue = true;

            DataGridViewRow row = new DataGridViewRow();

            datagridview_1.Rows.Add(row);

            row.Cells[3] = text;
            row.Cells[4] = BTN;
            // row.Cells[4] = "添加2";

        }
        /// <summary>
        /// 从BOM1表中去Table_bom_all 表中查询配件的ID   添加到BOM 表2 配件中
        /// </summary>
        /// <param name="datagridview1"></param>
        /// <param name="ID"></param>
        public void find_datagridview_now_bom(DataGridView datagridview1,int Main_ID)
        {
            datagridview1.Rows.Clear();
            var q_ = from a in  bom_sort.Table_BOM_struct_sort_ // bom_hold.Table_BOM_HOLD

                         //  where a.代码.Substring(0,3) == codeA && a.d == codeB
                         //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                         //where B.分类代码A.Contains(codeA)
                     where a.main_BOMID == Main_ID
                     select a;

                
            int i = 0;
            foreach (var id in q_)
            {

                var q_id = from a in data_bom.Table_bom_all // bom_hold.Table_BOM_HOLD

                             //  where a.代码.Substring(0,3) == codeA && a.d == codeB
                             //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                             //where B.分类代码A.Contains(codeA)
                         where a.ID == id.son_ID         
                           select a;
               


                List<string[]> list = new List<string[]>() { };
                foreach (var K in q_id)
                {
                   // MessageBox.Show(K.ID.ToString());
                    string[] strs = new string[] { K.ID.ToString(), K.代码, K.名称, K.品牌, K.技术参数,K.价格.ToString() };
                    list.Add(strs);
                    DataGridViewRow row = new DataGridViewRow();
                    datagridview1.Rows.Add(row);
                    if (strs[0] != "") { datagridview1.Rows[i].Cells[0].Value = strs[0]; }
                    if (strs[1] != "") { datagridview1.Rows[i].Cells[1].Value = strs[1]; }
                  //  if (strs[2] != "") { datagridview1.Rows[i].Cells["规格型号"].Value = strs[2]; }
                   if (strs[2] != "") { datagridview1.Rows[i].Cells[2].Value = strs[2]; }
                    if (strs[3] != "") { datagridview1.Rows[i].Cells[3].Value = strs[3]; }
                    if (strs[4] != "") { datagridview1.Rows[i].Cells[4].Value = strs[4]; }
                    if (strs[5] != "") { datagridview1.Rows[i].Cells[4].Value = strs[5]; }
                  
                    datagridview1.Rows[i].Cells[6].Value = "添加";
                    i++;
                }
            }


        }

        /// <summary>
        /// 此函数用来向BOM暂存区添加数据的  
        /// </summary>
        /// <param name="datagridview_1"></param>
        public void add_datagridview_hold(DataGridView datagridview_1, int ID)
        {

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
                datagridview_1.Rows[i].Cells[10].Value = "是";
                datagridview_1.Rows[i].Cells[11].Value = "未审核";
                datagridview_1.Rows[i].Cells[11].Style.BackColor = Color.Gray;
                datagridview_1.Rows[i].Cells[13].Value = "未提";
                datagridview_1.Rows[i].Cells[13].Style.BackColor = Color.Gray;
                datagridview_1.Rows[i].Cells[14].Value = "未采购";
                datagridview_1.Rows[i].Cells[14].Style.BackColor = Color.Red;
                datagridview_1.Rows[i].Cells[15].Value = "0";
               
                datagridview_1.Rows[i].Cells["删除"].Value = "删除";
                Global.temp_add_supplies_ID.Add(Convert.ToInt32(datagridview_1.Rows[i].Cells["ID"].Value));
                i++;
            }



        }
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
                        return ;

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
      
        private static void CreateWorksheetAbAssets(ExcelWorksheet ws)

        {
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
        private  void FillWorksheetAbAssets(ExcelWorksheet ws)
        {
            

            // 测试数据
            ws.Cells[1, 1].Value = "[G]组别";
            ws.Cells[2, 1].Value = "组别代码";
            ws.Cells[2, 2].Value = "组别名称";
            ws.Cells[3, 1].Value = ComboBox_project_name.Text + ".01";
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


            string str_0 = "";  if (((ComboxItem)ComboBox_mechine_number.SelectedItem).Values != null) { str_0 = ((ComboxItem)ComboBox_mechine_number.SelectedItem).Values.Substring(0, 2); }
            string str_1 = ""; if (((ComboxItem)ComboBox_num_request.SelectedItem).Values != null) { str_1 = ((ComboxItem)ComboBox_num_request.SelectedItem).Values.Substring(0, 2); }
            ws.Cells[6, 1].Value = ComboBox_project_name.Text+"-"+ str_0 + "-" + str_1 +"E" ;//
            ws.Cells[6, 2].Value = "M09." + ComboBox_project_name.Text + "-00-00-00-00E";//
            if (ComboBox_bom_sort != null)
            {

            ws.Cells[6, 3].Value = ComboBox_bom_sort.SelectedText;
            }
            ws.Cells[6, 4].Value = ComboBox_project_name.Text + "-00-00-00-00";//
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
          
            for (int i=0;i<DataGridView_BOM_Hold.Rows.Count;i++)
            {

              

                ws.Cells[k, 1].Value = DataGridView_BOM_Hold.Rows[i].Cells[2].Value ;//代码
                ws.Cells[k, 2].Value = DataGridView_BOM_Hold.Rows[i].Cells[3].Value;//物料名称
                ws.Cells[k, 3].Value = DataGridView_BOM_Hold.Rows[i].Cells[4].Value;//规格型号
                ws.Cells[k, 4].Value = "个";//单位
                ws.Cells[k, 5].Value = DataGridView_BOM_Hold.Rows[i].Cells[6].Value;//数量
                ws.Cells[k, 6].Value = "0";//损耗率
                ws.Cells[k, 13].Value = "否";
                ws.Cells[k, 14].Value = "通用";
                ws.Cells[k, 15].Value = "0";
                ws.Cells[k, 16].Value = "100";
                ws.Cells[k, 17].Value = "1900/1/1";
                ws.Cells[k, 18].Value = "2100/1/1";
                ws.Cells[k, 19].Value = "*";
                ws.Cells[k, 20].Value = "01."+ ComboBox_project_name.Text .Substring(1,5);
                ws.Cells[k, 21].Value = "普通件";
                ws.Cells[k, 26].Value = "否";
                ws.Cells[k, 27].Value = "N";
                k++;
            }


            ws.Cells[3, 1].Hyperlink = new ExcelHyperLink(kSheetNameAbDetail + "!A3", "SubTerrainObjs_1_1.assetbundle");


            ws.Cells[4, 1].Hyperlink = new ExcelHyperLink(kSheetNameAbDetail + "!A300", "Terrain_Data_1_8.assetbundle");



        }

        private static void CreateWorksheetAbDepend(ExcelWorksheet ws)
        { }
        private static void CreateWorksheetAbDetail(ExcelWorksheet ws)

        {

            // 测试数据

            ws.Cells[3, 1].Value = "SubTerrainObjs_1_1.assetbundle";

            ws.Cells[300, 1].Value = "Terrain_Data_1_8.assetbundle";

            ws.Cells[3000, 3].Value = "Terrain_Data_3_3.assetbundle";

        }



        public static void set_datagridview(DataGridView grid, DataSet dataset, string tablename)
        {
            grid.DataSource = dataset.Tables[tablename];

        }
        /// <summary>
        /// 物料审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton2_Click(object sender, EventArgs e)
        {

          //  set_datagridview(DataGridView_BOM_Hold, Global.dataset, "table1");

        }
        DataClasses1DataContext data_bom = new DataClasses1DataContext();
        private void skinButton3_Click(object sender, EventArgs e)
        {


            var q = from c in data_bom.Table_bom_all where c.ID <= 300 select c;
            DataGridView_BOM_Hold.DataSource = q;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void skinButton6_Click(object sender, EventArgs e)
        {
            datagridview_matter.Rows.Clear();
            search_datagridview(datagridview_matter);
        }
        /// <summary>
        /// 物料新增里的模糊搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton7_Click(object sender, EventArgs e)
        {

            Globle_TOOLS_SET_Datagridview TOOL = new Globle_TOOLS_SET_Datagridview();
            skinDataGridView1.Rows.Clear();
            TOOL.search_datagridview (skinDataGridView1, CheckBox2_find_condition, textbox_sort.Text,skinComboBox_A1, skinComboBox_B1, skinComboBox_C1);

            return;
          

        }

        private void skinButton9_Click(object sender, EventArgs e)
        {
            string[] str = { "", "s" };
            //  xmloperate.write(str);
        }

        private void comboxcode_A_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeB( comboxcode_A,  comboxcode_B,  comboxcode_C);
        }

        private void comboxcode_B_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeC(comboxcode_A, comboxcode_B, comboxcode_C);
        }
        public bool inspect()
        {
            string str_0 = ""; if (((ComboxItem)ComboBox_mechine_number.SelectedItem).Values != null) { str_0 = ((ComboxItem)ComboBox_mechine_number.SelectedItem).Values.Substring(0, 2); }
            string str_1 = ""; if (((ComboxItem)ComboBox_num_request.SelectedItem).Values != null) { str_1 = ((ComboxItem)ComboBox_num_request.SelectedItem).Values.Substring(0, 2); }
            Global.open_configuration = checkout();
            bool inspect_bool = false;
            var customer = from cust in bomstruct_classes.Table_BOM_HOLD

                           where cust.类别.Trim() == ComboBox_bom_sort.Text.Trim() && cust.项目代号.Trim() == ComboBox_project_name.Text.Trim()
                           && cust.设备序号.Trim() ==str_0.Trim() && cust.第几次申请.Trim() == str_1.Trim()
                           //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                           //where c.代码.Contains(sort_keywords)
                           //  where A.分类代码A
                           select cust;
            if (customer.Count() == 0)
            {
                //没有该表格

                inspect_bool = false;

            }
            else
            {
                if (Global.open_configuration == true)
                {
                    inspect_bool = false;
                }
                else
                {
                    inspect_bool = true;
                   
                }
              
            }

           
            return inspect_bool;
        }
       
        private void datagridview_matter_CellContentClick(object sender, DataGridViewCellEventArgs  e)
        {
            string str_0 = "";if (((ComboxItem)ComboBox_mechine_number.SelectedItem).Values != null) { str_0 = ((ComboxItem)ComboBox_mechine_number.SelectedItem).Values.Substring(0, 2); }
            string str_1 = ""; if (((ComboxItem)ComboBox_num_request.SelectedItem).Values != null) { str_1 = ((ComboxItem)ComboBox_num_request.SelectedItem).Values.Substring(0, 2); }
            Global.project_name = ComboBox_project_name.Text;
            Global.project_ST_name = str_0;
            Global.project_ST_num_name = str_1;
            Global.project_BOM_SORT_name = ComboBox_bom_sort.Text;
            Form2_procurement_open = false;
            if (Global.project_name == null || Global.project_ST_name == null || Global.project_ST_num_name == null || Global.project_BOM_SORT_name == null)
            { MessageBox.Show("请填写完整的项目信息！"); Form2_procurement_open = true; return; }
            if (Global.project_name.Length < 4 || Global.project_ST_name.Length < 2 || Global.project_ST_num_name.Length < 1 || Global.project_BOM_SORT_name.Length < 1)
            { MessageBox.Show("请填写完整的项目信息！"); Form2_procurement_open = true; return; }

            bool inspect_ = inspect();
            if (inspect_ == true) { MessageBox.Show("数据库已有该BOM配置,为了防止数据不统一请先读取BOM数据,再操作！"); return; }
            // string cell_value_now=  datagridview_matter.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int i = datagridview_matter.Rows.Count;
            if (i <= 0) { return; }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

           
                string nowcellname = datagridview_matter.Columns[e.ColumnIndex].HeaderText;
            string cell_value = datagridview_matter.Rows[e.RowIndex].Cells[0].Value.ToString();

                try
                {
                    int ID1 = Convert.ToInt32(cell_value);

                    find_datagridview_now_bom(DataGridView2_parts, ID1);

                } catch
                {

                }
                try
            {
                if (nowcellname == "添加")
                {
                    int ID = Convert.ToInt32(cell_value);
                    add_datagridview_hold(DataGridView_BOM_Hold, ID);

                }

            }
            catch { }
            }

        }

        /// <summary>
        /// 单击bom_all单元格内容部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void DataGridView_BOM_Hold_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DataGridView_BOM_Hold.Rows.Count;
            if (i <= 0) { return; }
            string cell_value = "";

            string nowcellname = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

           
            try {
                 cell_value = DataGridView_BOM_Hold.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                 nowcellname = DataGridView_BOM_Hold.Columns[e.ColumnIndex].HeaderText;
            } catch { }
            
            try
            {

                int ID = Convert.ToInt32(cell_value);
                if (nowcellname == "删除")
                {
                    for (int i_d_find = 0; i_d_find < i; i_d_find++)
                    {

                        if (DataGridView_BOM_Hold.Rows[i_d_find].Cells["ID"].Value.ToString().Trim() == ID.ToString().Trim())
                        {
                                int SET_ENABLE = 0;
                                CHECK_DeleTE_Or_YES(DataGridView_BOM_Hold, i_d_find, out SET_ENABLE);
                                if (SET_ENABLE == 2)
                                {
                                    MessageBox.Show("无法删除！该物料已提申请！请联系管理员！");
                                    return;
                                }
                                else if(SET_ENABLE == 3)
                                {
                                    MessageBox.Show("无法删除！该物料已采购！请联系管理员！");
                                    return;
                                }
                                DialogResult result = MessageBox.Show("确定要删除？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                if (result == DialogResult.OK)
                                {
                                    DataGridViewRow row = DataGridView_BOM_Hold.Rows[e.RowIndex];
                                    DataGridView_BOM_Hold.Rows.Remove(row);
                                    Global.temp_delete_supplies_ID.Add(Convert.ToInt32(DataGridView_BOM_Hold.Rows[i_d_find].Cells["ID"].Value));
                                    MessageBox.Show("删除成功！");
                                    return;
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
        }
        /// <summary>
        /// 单击bom_all单元格任意部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datagridview_matter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DataGridView_BOM_Hold.Rows.Count;
            if (i <= 0) { return; }
            string cell_value = "";

            string nowcellname = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {


                try
                {
                    cell_value = DataGridView_BOM_Hold.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                    nowcellname = DataGridView_BOM_Hold.Columns[e.ColumnIndex].HeaderText;
                }
                catch { }

            }
        }
        private void DataGridView2_parts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string str_0 = "";if (((ComboxItem)ComboBox_mechine_number.SelectedItem).Values != null) { str_0 = ((ComboxItem)ComboBox_mechine_number.SelectedItem).Values.Substring(0, 2); }
            string str_1 = ""; if (((ComboxItem)ComboBox_num_request.SelectedItem).Values != null) { str_1 = ((ComboxItem)ComboBox_num_request.SelectedItem).Values.Substring(0, 2); }
            Global.project_name = ComboBox_project_name.Text;
            Global.project_ST_name = str_0;
            Global.project_ST_num_name = str_1;
            Global.project_BOM_SORT_name = ComboBox_bom_sort.Text;
            Form2_procurement_open = false;
            if (Global.project_name == null || Global.project_ST_name == null || Global.project_ST_num_name == null || Global.project_BOM_SORT_name == null)
            { MessageBox.Show("请填写完整的项目信息！"); Form2_procurement_open = true; return; }
            if (Global.project_name.Length < 4 || Global.project_ST_name.Length < 2 || Global.project_ST_num_name.Length < 1 || Global.project_BOM_SORT_name.Length < 1)
            { MessageBox.Show("请填写完整的项目信息！"); Form2_procurement_open = true; return; }

            bool inspect_ = inspect();
            if (inspect_ == true) { MessageBox.Show("数据库已有该BOM配置,为了防止数据不统一请先读取BOM数据,再操作！"); return; }

            int i = datagridview_matter.Rows.Count;
            if (i <= 0) { return; }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {


                string nowcellname = datagridview_matter.Columns[e.ColumnIndex].HeaderText;
                string cell_value = datagridview_matter.Rows[e.RowIndex].Cells[0].Value.ToString();

              
                try
                {
                    if (nowcellname == "添加")
                    {
                        int ID = Convert.ToInt32(cell_value);
                        add_datagridview_hold(DataGridView_BOM_Hold, ID);

                    }

                }
                catch { }
            }
        }
        bool Form2_procurement_open = false;
        public void add_list_bom()
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
                string count = " ";
                string label = " ";
                string remarks = " ";

                if (DataGridView_BOM_Hold.Rows[i].Cells[6].Value != null) { try { count = DataGridView_BOM_Hold.Rows[i].Cells[6].Value.ToString();if (count == "") { count = " "; } } catch { } }
                if (DataGridView_BOM_Hold.Rows[i].Cells[6].Value != null) { try { label = DataGridView_BOM_Hold.Rows[i].Cells[5].Value.ToString(); if(label == "") { label = " "; } } catch { } }
                if (DataGridView_BOM_Hold.Rows[i].Cells[6].Value != null) { try { remarks = DataGridView_BOM_Hold.Rows[i].Cells[8].Value.ToString();if(remarks == ""){remarks = " "; } } catch { } }

              
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
        /// 生成采购单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton11_Click(object sender, EventArgs e)
        {
            string str_0 = "";if (((ComboxItem)ComboBox_mechine_number.SelectedItem).Values != null) { str_0 = ((ComboxItem)ComboBox_mechine_number.SelectedItem).Values.Substring(0, 2); }
            string str_1 = ""; if (((ComboxItem)ComboBox_num_request.SelectedItem).Values != null) { str_1 = ((ComboxItem)ComboBox_num_request.SelectedItem).Values.Substring(0, 2); }
            Global.project_name = ComboBox_project_name.Text;
            Global.project_ST_name = str_0;
            Global.project_ST_num_name = str_1;
            Global.project_BOM_SORT_name = ComboBox_bom_sort.Text;
            Form2_procurement_open = false;
            if (Global.project_name == null || Global.project_ST_name==null|| Global.project_ST_num_name == null || Global.project_BOM_SORT_name == null)
            { MessageBox.Show("请填写完整的项目信息！"); Form2_procurement_open = true ;return; }
            if (Global.project_name.Length<4 || Global.project_ST_name.Length<2|| Global.project_ST_num_name.Length < 1 || Global.project_BOM_SORT_name.Length < 1)
            { MessageBox.Show("请填写完整的项目信息！"); Form2_procurement_open = true; return; }

            bool inspect_ = inspect();
            if (inspect_ == true) { MessageBox.Show("数据库已有该BOM配置,为了防止数据不统一请先读取BOM数据,再操作！"); return; }
            add_list_bom();
            if (Form2_procurement_open == false)
            {
                Form2_procurement form2 = new Form2_procurement();
                form2.Show();
            }
          
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        DataClasses_BOM_ALLDataContext bomall_classes = new DataClasses_BOM_ALLDataContext();
        bom_hoidDataContext bomstruct_classes = new bom_hoidDataContext();
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton5_Click(object sender, EventArgs e)
        {
            
            string str_0 = "";  if (((ComboxItem)ComboBox_mechine_number.SelectedItem).Values != null) { str_0 = ((ComboxItem)ComboBox_mechine_number.SelectedItem).Values.Substring(0, 2); }
            string str_1 = ""; if (((ComboxItem)ComboBox_num_request.SelectedItem).Values != null) { str_1 = ((ComboxItem)ComboBox_num_request.SelectedItem).Values.Substring(0, 2); }
            Global.project_name = ComboBox_project_name.Text;
            Global.project_ST_name =str_0;
            Global.project_ST_num_name = str_1;
            Global.project_BOM_SORT_name = ComboBox_bom_sort.Text;
            Form2_procurement_open = false;
            if (Global.project_name == null || Global.project_ST_name == null || Global.project_ST_num_name == null || Global.project_BOM_SORT_name == null)
            { MessageBox.Show("请填写完整的项目信息！"); Form2_procurement_open = true; return; }
            if (Global.project_name.Length < 4 || Global.project_ST_name.Length < 2 || Global.project_ST_num_name.Length < 1 || Global.project_BOM_SORT_name.Length < 1)
            { MessageBox.Show("请填写完整的项目信息！"); Form2_procurement_open = true; return; }
            //checkout();
            bool inspect_ = inspect();
            if (inspect_ == true) { MessageBox.Show("数据库已有该BOM配置,为了防止数据不统一请先读取BOM数据,再操作！"); return; }

            //0类别 1 ID  2 物料代码 3规格型号 4物料名称 5品牌 6数量  7技术参数 8备注 9价格 10是否采购 11审核状态 12审核意见 13采购计划  14采购状态 15已采购数量 16删除
            //1 ID   6数量   8备注 12是否采购
            if (ComboBox_project_name.Text == null) { MessageBox.Show("请填写项目代号!"); return; }
            if (string.IsNullOrEmpty(ComboBox_project_name.Text )) { MessageBox.Show("请填写项目代号!"); return; }
            if (ComboBox_project_name.Text.ToString().Count() == 0) { MessageBox.Show("请填写项目代号!"); return; }
            for (int i=0;i < DataGridView_BOM_Hold.Rows.Count; i++)
            {
                if (DataGridView_BOM_Hold.Rows[i].Cells[6].Value == null) { MessageBox.Show("请填写数量!"); return; }
                if (string.IsNullOrEmpty(DataGridView_BOM_Hold.Rows[i].Cells[6].Value.ToString())) { MessageBox.Show("请填写数量!"); return; }
                if (DataGridView_BOM_Hold.Rows[i].Cells[6].Value.ToString().Count() == 0) { MessageBox.Show("请填写数量!"); return; }
                if (DataGridView_BOM_Hold.Rows[i].Cells[10].Value == null) { MessageBox.Show("请选择是否采购!"); return; }
                if (string.IsNullOrEmpty(DataGridView_BOM_Hold.Rows[i].Cells[10].Value.ToString())) { MessageBox.Show("请选择是否采购!"); return; }
                if (DataGridView_BOM_Hold.Rows[i].Cells[10].Value.ToString().Count() == 0) { MessageBox.Show("请选择是否采购!"); return; }
              
            }
            int  project_ID = 0;
            if (Form2_procurement_open == false)//信息不为空
            {
                //保存项目结构

                //先查询
               // string str_0 = ""; if (ComboBox_mechine_number.Text != null) { str_0 = ComboBox_mechine_number.Text.Substring(0, 2); }
                var customer = from cust in bomstruct_classes.Table_BOM_HOLD

                               where cust.类别.Trim() == ComboBox_bom_sort.Text.Trim() && cust.项目代号.Trim() == ComboBox_project_name.Text.Trim()
                               && cust.设备序号.Trim() == str_0.Trim() && cust.第几次申请.Trim() == str_1.Trim()
                               //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                               //where c.代码.Contains(sort_keywords)
                               //  where A.分类代码A
                               select cust;
                if (customer.Count() == 0)
                {
                    //没有该表格则新增

                    var newCustomer_sort = new Table_BOM_HOLD
                    {
                        项目代号 = ComboBox_project_name.Text.Trim(),
                        类别 = ComboBox_bom_sort.Text.Trim(),
                        设备序号 = str_0.Trim(),
                        第几次申请 = str_1.Trim(),
                        项目负责人ID = LOGIN.ID.login_now_ID
                            
                        //  备注 = remarks,



                    };
                    bomstruct_classes.Table_BOM_HOLD.InsertOnSubmit(newCustomer_sort);


                    bomstruct_classes.SubmitChanges();




                }
                else
                {
                   // MessageBox.Show("数据库已有该BOM配置,为了防止数据不统一请先读取BOM数据");
                }
                //表格新增完后查询分配到的ID


                var customer_new = from cust in bomstruct_classes.Table_BOM_HOLD

                                   where cust.类别.Trim() == ComboBox_bom_sort.Text.Trim() && cust.项目代号.Trim() == ComboBox_project_name.Text.Trim()
                                   && cust.设备序号.Trim() == str_0.Trim() && cust.第几次申请.Trim() == str_1.Trim()
                                   //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                   //where c.代码.Contains(sort_keywords)
                                   //  where A.分类代码A
                                   select cust;

                foreach (var item in customer_new)
                {
                    project_ID = item.ID;
                }
                //foreach (var item in customer)
                //{
                //    if ()
                //}
            }

            //先查询
            var q_find_supplies = from A in bomall_classes.BOM_ALL

                         where A.项目ID == project_ID
                         //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                         //where c.代码.Contains(sort_keywords)
                         //  where A.分类代码A
                         select A;
            if (q_find_supplies.Count() == 0)//新增 一个都没有的情况下
            {
                string remarks = "";
                foreach (DataGridViewRow rowone in DataGridView_BOM_Hold.Rows)
                {
                    if (rowone.Cells[8].Value != null)
                    {

                        remarks = rowone.Cells[8].Value.ToString();
                    }
                    DataGridViewComboBoxCell combox10 = (DataGridViewComboBoxCell)rowone.Cells[10];
                    var newCustomer = new BOM_ALL
                    {
                        项目ID = project_ID,
                        项目代号 = ComboBox_project_name.Text,
                        备注 = remarks,
                        物料ID = Convert.ToInt32(rowone.Cells[1].Value.ToString()),
                        数量 = Convert.ToInt32(rowone.Cells[6].Value.ToString()),
                        是否采购 = combox10.Value.ToString()


                    };

                        bomall_classes.BOM_ALL.InsertOnSubmit(newCustomer);
                }
            }
            else
            {
                 bool find_supplies_bool = false;//以数据库为基准在表格找到物料标识符
                foreach (DataGridViewRow rowone in DataGridView_BOM_Hold.Rows)
                {
                    DataGridViewComboBoxCell combox10 = (DataGridViewComboBoxCell)rowone.Cells[10];
                    string audit_status = ""; if (rowone.Cells[11].Value != null) { audit_status = rowone.Cells[11].Value.ToString().Trim(); }
                    string audit_idea = ""; if (rowone.Cells[12].Value != null) { audit_idea = rowone.Cells[12].Value.ToString().Trim(); }
                    string Is_request_shop = ""; if (rowone.Cells[13].Value != null) { Is_request_shop = rowone.Cells[13].Value.ToString().Trim(); }
                    string shop_status = ""; if (rowone.Cells[14].Value != null) { shop_status = rowone.Cells[14].Value.ToString().Trim(); }
                    string shop_paied_count = ""; if (rowone.Cells[15].Value != null) { shop_paied_count = rowone.Cells[15].Value.ToString().Trim(); }
                    string remarks = "";
                    if (rowone.Cells[8].Value != null)
                    {
                        remarks = rowone.Cells[8].Value.ToString().Trim();
                    }

                    find_supplies_bool = false;
                    foreach (var q_find_one in q_find_supplies)
                    {
                       
                        if (q_find_one.物料ID == Convert.ToInt32(rowone.Cells[1].Value.ToString()))//在表格中找到该物料则更新;
                        {

                            find_supplies_bool = true; //找到该物料  更新既可
                            q_find_one.数量 = Convert.ToInt32(rowone.Cells[6].Value.ToString());
                            q_find_one.是否采购 = combox10.Value.ToString();

                            q_find_one.备注 = remarks;

                            //q_find_one.审核状态 = audit_status;
                            //q_find_one.审核意见 = audit_idea;
                            //q_find_one.是否已提计划 = Is_request_shop;
                            //q_find_one.采购状态 = shop_status;
                            //q_find_one.已采购数量 = Convert.ToInt32(shop_paied_count);
                            continue;

                        }


                    }//当前物料表格查找完毕

                    if (find_supplies_bool == false)//没找到的情况下才新增
                    { 
                                  
                                 
                        var newCustomer = new BOM_ALL
                                    {
                                        项目ID = project_ID,
                                        项目代号 = ComboBox_project_name.Text.Trim(),
                                        备注 = remarks,
                                        物料ID = Convert.ToInt32(rowone.Cells[1].Value.ToString().Trim()),
                                        数量 = Convert.ToInt32(rowone.Cells[6].Value.ToString()),
                                        是否采购 = combox10.Value.ToString().Trim(),
                                      
                                        审核状态= audit_status,
                                        审核意见 = audit_idea,
                                        是否已提计划 = Is_request_shop,
                                        采购状态 = shop_status,
                                        已采购数量 = Convert.ToInt32(shop_paied_count)

                    };
                                    bomall_classes.BOM_ALL.InsertOnSubmit(newCustomer);
                             
                    }


                }
                foreach (var q_find_one in q_find_supplies)
                { 
                 // foreach (int  q_find_one in Global.temp_delete_supplies_ID)
                        // {
                        find_supplies_bool = false;
                        foreach (DataGridViewRow rowone in DataGridView_BOM_Hold.Rows)
                        {
                           
                            if (q_find_one.物料ID == Convert.ToInt32(rowone.Cells[1].Value.ToString()))//在表格中找到该物料则置位
                            {
                                find_supplies_bool = true;
                               continue;

                            }
                   // }
                         }
                        if (find_supplies_bool == false)//数据库有物料，但是表格没有   ?????/
                        {

                            var q_delete = (from A in bomall_classes.BOM_ALL

                                            where A.项目ID == project_ID && A.物料ID == q_find_one.物料ID
                                            //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                            //where c.代码.Contains(sort_keywords)
                                            //  where A.分类代码A
                                            select A).First();

                            bomall_classes.BOM_ALL.DeleteOnSubmit(q_delete);//删除该物料
                        }
                }
             



                
            }
          

            bomall_classes.SubmitChanges();
            if (Global.bom_open == 1|| Global.bom_open == -1)
            {
                Global.bom_open = 2;//保存成功
            }
           
            MessageBox.Show("保存成功！");
        }


        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            
            if (ToolStripMenuItem4.Text == "登录系统")
            {
                LOGIN.Login_form form = new LOGIN.Login_form();
                form.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show("确定要退出登录吗", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning );
               if (result==DialogResult.OK) {
                LOGIN.ID.login_now_Permission = 100;
                }
            }
            timer1.Enabled = true;

        }
        /// <summary>
        /// 登陆窗口监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            set_login();
        }
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LOGIN.账号管理 FROM = new LOGIN.账号管理();
            FROM.Show();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            LOGIN.密码修改 FORM = new LOGIN.密码修改();
            FORM.Show ();
        }
        /// <summary>
        /// 打开配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton4_Click(object sender, EventArgs e)
        {
         
            string str_0 = ""; if (((ComboxItem)ComboBox_mechine_number.SelectedItem).Values != null) { str_0 = ((ComboxItem)ComboBox_mechine_number.SelectedItem).Values.Substring(0, 2); }
            string str_1 = ""; if (((ComboxItem)ComboBox_num_request.SelectedItem).Values != null) { str_1 = ((ComboxItem)ComboBox_num_request.SelectedItem).Values.Substring(0, 2); }
          

            Global.project_name_open1  = ComboBox_project_name.Text;
            Global.project_ST_name_open1 =str_0;
            Global.project_ST_num_name_open1 = str_1;
            Global.project_BOM_SORT_name_open1 = ComboBox_bom_sort.Text;
            Form2_procurement_open = false;
            if (Global.project_name_open1 == null || Global.project_ST_name_open1 == null || Global.project_ST_num_name_open1 == null || Global.project_BOM_SORT_name_open1 == null)
            { MessageBox.Show("请填写完整的项目信息！"); Form2_procurement_open = true; return; }
            if (Global.project_name_open1.Length < 4 || Global.project_ST_name_open1.Length < 2 || Global.project_ST_num_name_open1.Length < 1 || Global.project_BOM_SORT_name_open1.Length < 1)
            { MessageBox.Show("请填写完整的项目信息！"); Form2_procurement_open = true; return; }




            bool inspect_ = checkout_openbom();
            if (inspect_ == true ) { MessageBox.Show("该BOM已打开！"); return; }
            else
            {
                if (Global.bom_open == 1)//打开后还未保存
                {
  
                    DialogResult result = MessageBox.Show("当前打开BOM还未保存，确定关闭吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        Global.bom_open = -1;//还原
                    }
                    else
                    {
                        
                    }
                }
            }


            if (Form2_procurement_open == false)
            {
                int project_ID = 0;

                var customer_new = from cust in bomstruct_classes.Table_BOM_HOLD

                                   where cust.类别.Trim() == ComboBox_bom_sort.Text.Trim() && cust.项目代号.Trim() == ComboBox_project_name.Text.Trim()
                                   && cust.设备序号.Trim() == str_0.Trim() && cust.第几次申请.Trim() == str_1.Trim()
                                   //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                   //where c.代码.Contains(sort_keywords)
                                   //  where A.分类代码A
                                   select cust;

                foreach (var item in customer_new)
                {
                    project_ID = item.ID;
                }
                DataGridView_BOM_Hold.Rows.Clear();
                //先查询
                var q_find_supplies = from A in bomall_classes.BOM_ALL

                                      where A.项目ID == project_ID
                                      //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                                      //where c.代码.Contains(sort_keywords)
                                      //  where A.分类代码A
                                      select A;
                foreach (var q_find_one in q_find_supplies)
                {
                    //0类别 1 ID  2 物料代码 3规格型号 4物料名称 5品牌 6数量  7技术参数 8备注 9价格 10是否采购 11审核状态 12审核意见 13采购计划  14采购状态 15已采购数量 16删除
                    //6数量 8备注  10是否采购 11审核状态 12审核意见 13采购计划  14采购状态 15已采购数量
                    string remarks = "";
                    if (q_find_one.备注 != null)
                    {

                        remarks = q_find_one.备注.ToString().Trim();
                    };
                    int row_now = -1;
                    int ID = Convert.ToInt32(q_find_one.物料ID);
                    add_datagridview_hold_fromdatabase(DataGridView_BOM_Hold, ID,out row_now);

                    string count_use = ""; if (q_find_one.数量 != null) { count_use = q_find_one.数量.ToString().Trim(); }
                    DataGridView_BOM_Hold.Rows[row_now].Cells[6].Value = count_use;//6数量

                   
                    DataGridView_BOM_Hold.Rows[row_now].Cells[8].Value = remarks;//8备注

                    string Is_SHOP = ""; if (q_find_one.是否采购 != null) { Is_SHOP = q_find_one.是否采购.ToString().Trim(); }
                    DataGridView_BOM_Hold.Rows[row_now].Cells[10].Value = Is_SHOP;//10是否采购

                    string audit_status = ""; if (q_find_one.审核状态 != null) { audit_status = q_find_one.审核状态.ToString().Trim(); }
                    DataGridView_BOM_Hold.Rows[row_now].Cells[11].Value = audit_status;//11审核状态
                    if (audit_status == "已审核") { DataGridView_BOM_Hold.Rows[row_now].Cells[11].Style.BackColor = Color.Green; }
                    else { DataGridView_BOM_Hold.Rows[row_now].Cells[11].Style.BackColor = Color.Gray; }

                    string audit_idea = ""; if (q_find_one.审核意见 != null) { audit_idea = q_find_one.审核意见.ToString().Trim(); }
                    DataGridView_BOM_Hold.Rows[row_now].Cells[12].Value = audit_idea;//12审核意见

                    string Is_request_shop = ""; if (q_find_one.是否已提计划 != null) { Is_request_shop = q_find_one.是否已提计划.ToString().Trim(); }
                    DataGridView_BOM_Hold.Rows[row_now].Cells[13].Value = Is_request_shop;//13采购计划
                    if (Is_request_shop == "已提") { DataGridView_BOM_Hold.Rows[row_now].Cells[13].Style.BackColor = Color.Green; }
                    else { DataGridView_BOM_Hold.Rows[row_now].Cells[13].Style.BackColor = Color.Gray; }

                    string shop_status = ""; if (q_find_one.采购状态 != null) { shop_status = q_find_one.采购状态.ToString().Trim(); }
                    DataGridView_BOM_Hold.Rows[row_now].Cells[14].Value = shop_status;//14采购状态
                    if (shop_status == "已采购") { DataGridView_BOM_Hold.Rows[row_now].Cells[14].Style.BackColor = Color.Green; }
                    else { DataGridView_BOM_Hold.Rows[row_now].Cells[14].Style.BackColor = Color.Red; }

                    string shop_paied_count = ""; if (q_find_one.已采购数量 != null) { shop_paied_count = q_find_one.已采购数量.ToString().Trim(); }
                    DataGridView_BOM_Hold.Rows[row_now].Cells[15].Value = shop_paied_count;//15已采购数量

                    DataGridView_BOM_Hold.Rows[row_now].Cells["删除"].Value = "删除";

                    int SET_ENABLE = 0;
                    CHECK_DeleTE_Or_YES(DataGridView_BOM_Hold, row_now,out SET_ENABLE) ;

                    DataGridViewComboBoxCell combox10 = (DataGridViewComboBoxCell)DataGridView_BOM_Hold.Rows[row_now].Cells[10];
                    DataGridViewButtonCell button_delete = (DataGridViewButtonCell)DataGridView_BOM_Hold.Rows[row_now].Cells["删除"];

                    if (SET_ENABLE >= 2)
                    {
                        combox10.ReadOnly = true;
                        // DataGridView_BOM_Hold.Rows[row_now].Cells[10].ReadOnly = true;
                        combox10.Style.BackColor = Color.DarkOrange;

                       button_delete.ReadOnly = true;
                        button_delete.Style.BackColor = Color.Red;
                     //   button_delete.Style.ForeColor = Color.DarkOrange;
                        // DataGridView_BOM_Hold.Rows[row_now].Cells["删除"].ReadOnly = true;
                    }

                  
                   

                }
                if(Global.bom_open == -1)
                {
                  Global.bom_open = 1;//打开成功

                }
                Global.project_name_open = ComboBox_project_name.Text;
                Global.project_ST_name_open = str_0;
                Global.project_ST_num_name_open = str_1;
                Global.project_BOM_SORT_name_open = ComboBox_bom_sort.Text;

            }
        }
        public bool checkout()
        {
            bool check = false;
            if (Global.project_name_open== Global.project_name && Global.project_ST_name_open== Global.project_ST_name&& Global.project_ST_num_name_open== Global.project_ST_num_name&& Global.project_BOM_SORT_name_open== Global.project_BOM_SORT_name)
            {
                check = true ;
            }
            return check;
        }
        public bool checkout_openbom()
        {
            bool check = false;
            if (Global.project_name_open == Global.project_name_open1 && Global.project_ST_name_open == Global.project_ST_name_open1 && Global.project_ST_num_name_open == Global.project_ST_num_name_open1 && Global.project_BOM_SORT_name_open == Global.project_BOM_SORT_name_open1)
            {
                check = true;
            }
            return check;
        }
        /// <summary>
        /// 以下是检查是否可以更改物料的权限函数
        /// </summary>
        /// <param name="datagridview_1"></param>
        /// <param name="row_num"></param>
        /// <param name="INT_enable"></param>
        public void CHECK_DeleTE_Or_YES(DataGridView datagridview_1, int row_num, out int  INT_enable)
        {
            int  _temp = 0;

            //datagridview_1.Rows[row_num].Cells[10].Value = "是";

            //datagridview_1.Rows[row_num].Cells[11].Value = "未审核";


            //datagridview_1.Rows[row_num].Cells[13].Value = "未提";

            //datagridview_1.Rows[row_num].Cells[14].Value = "未采购";

            //datagridview_1.Rows[row_num].Cells[15].Value = "0";
            string audit_status = ""; if (datagridview_1.Rows[row_num].Cells[11].Value != null) { audit_status = datagridview_1.Rows[row_num].Cells[11].Value.ToString().Trim(); }
           
            if (audit_status == "已审核") { _temp = 1; }
            else { }



            string Is_request_shop = ""; if (datagridview_1.Rows[row_num].Cells[13].Value != null) { Is_request_shop = datagridview_1.Rows[row_num].Cells[13].Value.ToString().Trim(); }
          
            if (Is_request_shop == "已提") { _temp = 2; }
            else {  }

            string shop_status = ""; if (datagridview_1.Rows[row_num].Cells[14].Value != null) { shop_status = datagridview_1.Rows[row_num].Cells[14].Value.ToString().Trim(); }
          
            if (shop_status == "已采购") { _temp = 3; }
            else {  }



            INT_enable = _temp;
        }
        /// <summary>
        /// 实验combox改变颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_mechine_number_DrawItem(object sender, DrawItemEventArgs e)
        {
            ////初始化字体和背景色
            //Pen fColor = new Pen(Color.Black);
            //Pen bColor = new Pen(Color.White);

            //switch (e.Index)
            //{

            //    case 0:
            //        {
            //            fColor = new Pen(Color.Green);
            //            break;
            //        }
            //    case 1:
            //        {
            //            fColor = new Pen(Color.Red);
            //            break;
            //        }
            //    case 2:
            //        {
            //            fColor = new Pen(Color.Blue);
            //            break;
            //        }
            //}


            //e.Graphics.FillRectangle(bColor.Brush, e.Bounds);
            //e.Graphics.DrawString((string)ComboBox_mechine_number.Items[e.Index], this.Font, fColor.Brush, e.Bounds);

        }

        private void ComboBox_project_name_SelectedIndexChanged(object sender, EventArgs e)
        {
         
          
            string PROJECT_NAME = "";
            PROJECT_NAME = ComboBox_project_name.Text;
           
            
        }
        private void ComboBox_project_name_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string PROJECT_NAME = ""; if (((ComboxItem)ComboBox_project_name.SelectedItem).Values != null) { PROJECT_NAME = ((ComboxItem)ComboBox_project_name.SelectedItem).Values.ToString().Trim(); }

            //string str_1 = ""; if (ComboBox_num_request.Text != null) { str_0 = ComboBox_num_request.Text.Substring(0, 2); }

            if (PROJECT_NAME != null)
            {
                find_bom_usernoew(PROJECT_NAME);
            }
        }
        private void ComboBox_project_name_TextUpdate(object sender, EventArgs e)
        {//(ComboxItem)ComboBox_project_name.SelectedItem).Values
            string PROJECT_NAME = ""; if (ComboBox_project_name.Text != null) { PROJECT_NAME = ComboBox_project_name.Text.ToString().Trim(); }

            //string str_1 = ""; if (ComboBox_num_request.Text != null) { str_0 = ComboBox_num_request.Text.Substring(0, 2); }

            if (PROJECT_NAME != null)
            {
                find_bom_usernoew(PROJECT_NAME);
            }
        }

        private void ComboBox_mechine_number_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void ComboBox_mechine_number_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string str_0 = ""; if (((ComboxItem)ComboBox_mechine_number.SelectedItem).Values != null) { str_0 = ((ComboxItem)ComboBox_mechine_number.SelectedItem).Values.ToString().Trim().Substring(0,2); }

            //string str_1 = ""; if (ComboBox_num_request.Text != null) { str_0 = ComboBox_num_request.Text.Substring(0, 2); }

            if (str_0 != null)
            {
                find_bom_usernoew_num(str_0);
            }
        }

      
        private void skinComboBox4_B2_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeC(skinComboBox_A2, skinComboBox_B2, skinComboBox_C2);
           
        }

        private void skinComboBox3_A2_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeB(skinComboBox_A2, skinComboBox_B2, skinComboBox_C2);
          
        }

        private void skinComboBox7_A1_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeB(skinComboBox_A1, skinComboBox_B1, skinComboBox_C1);

        }

        private void skinComboBox6_B1_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeC(skinComboBox_A1, skinComboBox_B1, skinComboBox_C1);
        }
        /// <summary>
        /// 资料浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton16_Click(object sender, EventArgs e)
        {
            FolderDialog fDialog = new FolderDialog();
            fDialog.DisplayDialog();
            skinTextBox_datapath1.Text = fDialog.Path;
        }
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton15_Click(object sender, EventArgs e)
        {
            FolderDialog_file fdialog = new FolderDialog_file();
            string file_path = "";//tbFilePath = dialog.FileName;EXCEL表格文件(*.txt)|*.txt|所有文件(*.*)|*.*”c
            //fdialog. file_path_save("EXCEL表格文件(*.xls)|*.xls", out file_path);
            fdialog.file_path_open("图片(*.png)|*.png|所有文件(*.*)|*.*", out file_path);
            skinTextBox_pixturebox_path1 .Text= file_path;
        }
        Globle_add_supplies add = new Globle_add_supplies();
        /// <summary>
        /// 物料新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton3_Click_1(object sender, EventArgs e)
        {
            if (add.duplicate_checking(skinComboBox_A2, skinComboBox_B2, skinComboBox_C2, Textbox_SUPPLIES_model1, skinComboBox_SUPPLIES_NAME1.Text))
            { 


            bool reaslut = false;
            
                add.ADD_supplies(out reaslut, skinComboBox_A2, skinComboBox_B2, skinComboBox_C2, Textbox_SUPPLIES_model1.Text, skinComboBox_SUPPLIES_NAME1.Text, Textbox_brank1.Text,
               Textbox_supples_sort1.Text, Textbox_supples_technical_parameters1.Text, Textbox_supples_spare1.Text, skinTextBox_pixturebox_path1.Text, skinTextBox_datapath1.Text, skinCheckBox_price1, skinTextBox_price1.Text);

            if (reaslut == true)
            {
                
                
                MessageBox.Show("新增成功！");
                add.find_unchecked(skinDataGridView_unchecked);
                add.find_checked(skinDataGridView_checked);
            }
            };
        }
        /// <summary>
        /// 选项卡切换动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)//物料新增页面
            {
               // Globle_add_supplies add = new Globle_add_supplies();
                add.find_unchecked(skinDataGridView_unchecked);
                add.find_checked(skinDataGridView_checked);
            }
        }

        private void skinDataGridView_unchecked_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // Globle_add_supplies add = new Globle_add_supplies();
            add.chech_audit(skinDataGridView_unchecked, e.RowIndex, e.ColumnIndex);
            add.delete(skinDataGridView_unchecked, e.RowIndex,e.ColumnIndex);
            add.find_unchecked(skinDataGridView_unchecked);
            add.find_checked(skinDataGridView_checked);
        }

        private void Textbox_SUPPLIES_model1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Globle_add_supplies add = new Globle_add_supplies();
            skinTextBox4_code_ALL.Text= add. get_code_all(skinComboBox_A2, skinComboBox_B2, skinComboBox_C2, Textbox_SUPPLIES_model1);
           
        }

        private void skinComboBox_C2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
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
