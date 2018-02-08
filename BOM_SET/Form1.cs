
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
        private const string kSheetNameAbAssets = "Sheet1";

        private const string kSheetNameAbDetail = "Sheet2";
        public Form1()
        {
            InitializeComponent();
            Global.dataset.Tables.Add("table1");
            codeA();
            find_add_datagridview(datagridview_matter);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            //using (OfficeOpenXml.ExcelPackage package = new ExcelPackage(new FileInfo(@"d:\test.xlsx"))) { }
            PrintReporter();
            MessageBox.Show("生成成功！");
        }
        public static void PrintReporter()

        {

            var newFile = new FileInfo("d:/test.xlsx");

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
            if (comboxcode_A.SelectedText == null| comboxcode_B.SelectedText == null) return;
            comboxcode_C.Items.Clear();
            comboxcode_C.Text = "";
            string codeA = comboxcode_A.SelectedItem.ToString();
            string codeB = comboxcode_B.SelectedItem.ToString();
           
            var q_C = from C in Code_ABC.Table_structure_bom

                      where C.分类代码A == codeA && C.分类代码B ==codeB
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
        ////
        public void search_datagridview(DataGridView datagridview_1)
        {
            //  if (comboxcode_A.SelectedText == null | comboxcode_B.SelectedText == null) return;
            string codeA = "";
            string codeB = "";
            string codeC = "";

            if (comboxcode_A.SelectedItem != null) { codeA = comboxcode_A.SelectedItem.ToString().Substring(0,3); }
            if (comboxcode_B.SelectedItem != null) {  codeB = comboxcode_B.SelectedItem.ToString().Substring(0,3); }
            if (comboxcode_C.SelectedItem != null) {  codeC = comboxcode_C.SelectedItem.ToString().Substring(0,1); }

          
           
            var q_abc = from a in data_bom.Table_bom_all

                    //  where a.代码.Substring(0,3) == codeA && a.d == codeB
                      //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                      //where B.分类代码A.Contains(codeA)
                      select a;
           

            List<string[]> list = new List<string[]>() { };

            foreach(var li in q_abc)
            {
                string[] strs = new string[] { li.代码, li.名称, li.品牌, li.技术参数 };
                if ((int)strs[0][0] > 127) { continue; }
                   
                if (codeA != ""  )
                {
                    if(strs[0].Trim().Length < 3) { continue; }

                    if (strs[0].Trim().Substring(0, 3) == codeA)
                    {

                       
                        if (codeB != "" )
                        {
                            if (strs[0].Trim().Length < 6) { continue; }
                            if (strs[0].Trim().Substring(3, 3) == codeB)
                            {
                                if (codeC != "" )
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
            var newlist = list.Distinct();
            foreach (var li in newlist)
            {
                DataGridViewRow row = new DataGridViewRow();
                datagridview_1.Rows.Add(row);
                datagridview_1.Rows[i].Cells[0].Value = li[0];

                i++;
                
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
        private static void FillWorksheetAbAssets(ExcelWorksheet ws)
        {

            // 测试数据
            ws.Cells[1, 1].Value = "[G]组别";
            ws.Cells[2, 1].Value = "组别代码";
            ws.Cells[2, 2].Value = "组别名称";
            ws.Cells[3, 1].Value = "C17506.01";//
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



            ws.Cells[6, 1].Value = "C17201-01-04E";//
            ws.Cells[6, 2].Value = "M09.C17506ZB-00-00-00-00E";//
            ws.Cells[6, 3].Value = "电气";
            ws.Cells[6, 4].Value = "C17506ZB-00-00-00-00";//
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



        public static void set_datagridview(DataGridView grid,DataSet dataset,string tablename)
        {
            grid.DataSource = dataset.Tables[tablename];
           
        }
        
        private void skinButton2_Click(object sender, EventArgs e)
        {
            
            set_datagridview(skinDataGridView1, Global.dataset, "table1");

        }
        DataClasses1DataContext data_bom = new DataClasses1DataContext();
        private void skinButton3_Click(object sender, EventArgs e)
        {
               
              
            var q = from c in data_bom.Table_bom_all where c.ID <= 300  select c;
            skinDataGridView1.DataSource = q;
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

            if (dataGridView1.Rows.Count > 0)
            {
           //     dataGridView1.Rows.Clear();
            }

            string sort_keywords = textbox_sort.Text;
            var q = from c in data_bom.Table_bom_all

                  where SqlMethods.Like(c.代码, '%' + sort_keywords + '%')
                  //  where c.代码.Contains(sort_keywords)
                    select c;

          
           
            dataGridView1.DataSource = q;

          
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
    }
}
