
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
    public partial class Form2_procurement : Skin_Metro
    {
        int nowrows = 0;
        bool sheets_add_do = false;
        public Form2_procurement()
        {
            InitializeComponent();
        }
        DataClasses1DataContext data_bom = new DataClasses1DataContext();
        private void Form2_procurement_Load(object sender, EventArgs e)
        {
            skinTextBox2.Text = Global.project_name + "-" + Global.project_ST_name;//
            dateTimePicker1.Value= DateTime.Now.ToLocalTime();

            skinTextBox1.Text = LOGIN.ID.login_now_Nanme.Trim();


                datagridview_matter.Rows.Clear();
            for(int i=0;i< Global.BOM_LIST.Count; i++)
            {
                
                datagridview_matter.Rows.Add();
                datagridview_matter.Rows[i].Cells[0].Value = Global.BOM_LIST[i][0];
                datagridview_matter.Rows[i].Cells[1].Value = Global.BOM_LIST[i][1];
                datagridview_matter.Rows[i].Cells[2].Value = Global.BOM_LIST[i][2];
                datagridview_matter.Rows[i].Cells[3].Value = Global.BOM_LIST[i][3];
                datagridview_matter.Rows[i].Cells[4].Value = Global.BOM_LIST[i][4];
                datagridview_matter.Rows[i].Cells[5].Value = Global.BOM_LIST[i][5];
                datagridview_matter.Rows[i].Cells[6].Value = Global.BOM_LIST[i][6];
                datagridview_matter.Rows[i].Cells[7].Value = Global.BOM_LIST[i][7];
                datagridview_matter.Rows[i].Cells[8].Value = DateTime.Now.ToString("yyyy-MM-dd");
                datagridview_matter.Rows[i].Cells[9].Value = Global.BOM_LIST[i][8];
            }
           


                // datagridview_matter.DataSource = q;
                // var newFile = new FileInfo("d:" + skinTextBox1.Text + " - " + skinTextBox2.Text + " - " + skinTextBox3.Text + "E" + ".xls");
           
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Global.BOM_LIST.Count; i++)
            {
                datagridview_matter.Rows[i].Cells[8].Value = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        /// 生成表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton2_Click(object sender, EventArgs e)
        {
            FolderDialog_file fdialog = new FolderDialog_file();
            string file_path = "";//tbFilePath = dialog.FileName;EXCEL表格文件(*.txt)|*.txt|所有文件(*.*)|*.*”c
                                  //fdialog. file_path_save("EXCEL表格文件(*.xls)|*.xls", out file_path);
            fdialog.file_path_save("EXCEL表格文件(*.xlsx)|*.xlsx", Global.project_name, out file_path);

           

            string destinationFile = file_path;// @"d:\" + Global.project_name + ".xlsx";
            try
            {

            File.Delete(destinationFile);
            }
            catch
            {

            }

            string sourceFile = System.AppDomain.CurrentDomain.BaseDirectory + "excel\\采购申请模板.xlsx";
            FileInfo file = new FileInfo(sourceFile);
            if (file.Exists)
            {
                file.CopyTo(destinationFile, true);
            }


            var newFile = new FileInfo(destinationFile);

           

         //   var package = new ExcelPackage(newFile);
            
            using (var package = new ExcelPackage(newFile))

            {
                sheets_add_do = false;
                nowrows = 0;
                int worksheet_now =1;
                do
                {
                    //ExcelWorksheet sheet = package.Workbook.Worksheets[1];
                  

                    string kSheetNameAbAssets = "Sheet" + worksheet_now.ToString();
                    //ExcelWorksheet sheet =  package.Workbook.Worksheets.Add(kSheetNameAbAssets);
                    
                    CreateWorksheetAbAssets(package.Workbook.Worksheets.Copy("Sheet0", kSheetNameAbAssets));

                    FillWorksheetAbAssets(package.Workbook.Worksheets[worksheet_now+1]);
                        worksheet_now ++;

                  //  MessageBox.Show("SAS");

                } while (sheets_add_do==false);
                package.Workbook.Worksheets.Delete("Sheet0");
                package.Save();

                MessageBox.Show("导出成功！");
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
        private void FillWorksheetAbAssets(ExcelWorksheet ws)
        {


            
            ws.Cells[4, 1].Value = Global.project_name+"-"+ Global.project_ST_name;//
         

            int k = 7;
            int eve_row = nowrows+26 ;
            if(eve_row>= datagridview_matter.Rows.Count) { eve_row = datagridview_matter.Rows.Count; sheets_add_do = true; } else { sheets_add_do = false; }
            if (eve_row < 26) { eve_row = datagridview_matter.Rows.Count; sheets_add_do = true; }
            if (nowrows <= 26)
            { }
                for (int i = nowrows; i < eve_row; i++)
                {


                    ws.Cells[k, 1].Value = datagridview_matter.Rows[i].Cells[1].Value;//序号
                    ws.Cells[k, 2].Value = datagridview_matter.Rows[i].Cells[2].Value;//代码
                    ws.Cells[k, 3].Value = datagridview_matter.Rows[i].Cells[3].Value;//物料名称
                    ws.Cells[k, 4].Value = datagridview_matter.Rows[i].Cells[4].Value;//规格型号
                    ws.Cells[k, 5].Value = datagridview_matter.Rows[i].Cells[5].Value; ;//单位
                    ws.Cells[k, 6].Value = datagridview_matter.Rows[i].Cells[6].Value;//数量
                    ws.Cells[k, 7].Value = datagridview_matter.Rows[i].Cells[7].Value;//供应商
                    ws.Cells[k, 8].Value = datagridview_matter.Rows[i].Cells[8].Value;//要求供货日
                    ws.Cells[k, 9].Value = datagridview_matter.Rows[i].Cells[9].Value;//备注

                    k++;
                    nowrows++;
                }
            ws.Cells[33, 3].Value = skinTextBox1.Text;//备注



            //ws.Cells[3, 1].Hyperlink = new ExcelHyperLink(kSheetNameAbDetail + "!A3", "SubTerrainObjs_1_1.assetbundle");


            //ws.Cells[4, 1].Hyperlink = new ExcelHyperLink(kSheetNameAbDetail + "!A300", "Terrain_Data_1_8.assetbundle");



        }
    }
}
