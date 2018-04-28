
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
            codeA();
            find_add_datagridview(datagridview_matter);
            datagridview_matter.Rows.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 生成BOM表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton1_Click(object sender, EventArgs e)
        {
            //using (OfficeOpenXml.ExcelPackage package = new ExcelPackage(new FileInfo(@"d:\test.xlsx"))) { }
            Form2_procurement_open = false;
            if (Global.project_name == null || Global.project_ST_name == null) { MessageBox.Show("请填写项目信息！"); Form2_procurement_open = true; return; }
            if (Global.project_name.Length < 4 || Global.project_ST_name.Length < 2) { MessageBox.Show("请填写项目信息！"); Form2_procurement_open = true; return; }

            if (Form2_procurement_open == false)
            {
                PrintReporter();
                MessageBox.Show("生成成功！");
            }
        }
        public  void PrintReporter()

        {//skinTextBox1.Text
            //MessageBox.Show(skinComboBox11.Text);return;
            var newFile = new FileInfo("d:"+ skinComboBox11.Text + " - "+ skinTextBox2.Text + " - " +skinTextBox3 .Text +"E"+".xls");
            Global.procurement_name = skinComboBox11.Text + " - " + skinTextBox2.Text + " - " + skinTextBox3.Text;
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
        public void codeA()
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
        public void codeB()
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
                list.Add(li.分类代码B);
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
        public void codeC()
        {
            if (comboxcode_A.SelectedText == null | comboxcode_B.SelectedText == null) return;
            comboxcode_C.Items.Clear();
            comboxcode_C.Text = "";
            string codeA = comboxcode_A.SelectedItem.ToString();
            string codeB = comboxcode_B.SelectedItem.ToString();

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
            if (comboxcode_B.SelectedItem != null) { codeB = comboxcode_B.SelectedItem.ToString().Substring(0, 3); }
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
                datagridview_1.Rows[i].Cells["删除"].Value = "删除";
                i++;
            }



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
            ws.Cells[3, 1].Value = skinComboBox11.Text + ".01";
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



            ws.Cells[6, 1].Value = skinComboBox11.Text+"-"+ skinTextBox2.Text + "-" +skinTextBox3 .Text +"E" ;//
            ws.Cells[6, 2].Value = "M09." + skinComboBox11.Text + "-00-00-00-00E";//
            if (skinComboBox1 != null)
            {

            ws.Cells[6, 3].Value = skinComboBox1.SelectedText;
            }
            ws.Cells[6, 4].Value = skinComboBox11.Text + "-00-00-00-00";//
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
                ws.Cells[k, 20].Value = "01."+ skinComboBox11.Text .Substring(1,5);
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

        private void skinButton7_Click(object sender, EventArgs e)
        {

            if (skinDataGridView1.Rows.Count > 0)
            {
                //     dataGridView1.Rows.Clear();
            }

            string sort_keywords = textbox_sort.Text;
            var q = from c in data_bom.Table_bom_all

                    where SqlMethods.Like(c.代码, '%' + sort_keywords + '%')
                    //  where c.代码.Contains(sort_keywords)
                    select c;



            skinDataGridView1.DataSource = q;


        }

        private void skinButton9_Click(object sender, EventArgs e)
        {
            string[] str = { "", "s" };
            //  xmloperate.write(str);
        }

        private void comboxcode_A_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeB();
        }

        private void comboxcode_B_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeC();
        }

        private void datagridview_matter_CellContentClick(object sender, DataGridViewCellEventArgs  e)
        {
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
                            DataGridViewRow row = DataGridView_BOM_Hold.Rows[e.RowIndex];
                            DataGridView_BOM_Hold.Rows.Remove(row);
                            MessageBox.Show("删除成功！");
                            return;

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
            Global.project_name = skinComboBox11.Text;
            Global.project_ST_name = skinTextBox2.Text;
            Form2_procurement_open = false;
            if (Global.project_name == null || Global.project_ST_name==null) { MessageBox.Show("请填写项目信息！"); Form2_procurement_open = true ;return; }
            if (Global.project_name.Length<4 || Global.project_ST_name.Length<2) { MessageBox.Show("请填写项目信息！"); Form2_procurement_open = true; return; }
           
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
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
