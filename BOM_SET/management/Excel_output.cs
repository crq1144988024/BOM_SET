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

namespace BOM_SET.management
{
    public class Excel_output
    {
        int nowrows = 0;
        bool sheets_add_do = false;
        public void PrintReporter(string path,string name,DataGridView datagridview1, int check_num)

        {//skinTextBox1.Text
         //MessageBox.Show(skinComboBox11.Text);return;
            string file_path = "";
            if (path == null)
            {

                FolderDialog_file fdialog = new FolderDialog_file();
              //tbFilePath = dialog.FileName;EXCEL表格文件(*.txt)|*.txt|所有文件(*.*)|*.*”c
                                      //fdialog. file_path_save("EXCEL表格文件(*.xls)|*.xls", out file_path);
                fdialog.file_path_save("EXCEL表格文件(*.xlsx)|*.xlsx", name, out file_path);
                path = file_path;
            }
           
           

            string destinationFile = path;
            string sourceFile = System.AppDomain.CurrentDomain.BaseDirectory + "excel\\新增物料模板.xlsx";
            FileInfo file = new FileInfo(sourceFile);
            if (file.Exists)
            {
                file.CopyTo(destinationFile, true);
            }


            var newFile = new FileInfo(destinationFile);


            using (var package = new ExcelPackage(newFile))

            {

                // CreateWorksheetAbAssets(package.Workbook.Worksheets.Add(kSheetNameAbAssets));

                // CreateWorksheetAbDetail(package.Workbook.Worksheets.Add(kSheetNameAbDetail));



                //   var package = new ExcelPackage(newFile);


                {
                    //sheets_add_do = false;
                    //nowrows = 0;
                    int worksheet_now = 1;
                    //do
                    //{
                    //    //ExcelWorksheet sheet = package.Workbook.Worksheets[1];


                    //    string kSheetNameAbAssets = "Sheet" + worksheet_now.ToString();
                    //ExcelWorksheet sheet =  package.Workbook.Worksheets.Add(kSheetNameAbAssets);

                    CreateWorksheetAbAssets(package.Workbook.Worksheets.Copy("Sheet0", kSheetNameAbAssets));

                    //FillWorksheetAbAssets(package.Workbook.Worksheets[worksheet_now + 1]);
                    FillWorksheetAbAssets(package.Workbook.Worksheets[worksheet_now + 1], datagridview1, check_num);
                  //  worksheet_now++;

                    //  MessageBox.Show("SAS");

                    //} while (sheets_add_do == false);
                    package.Workbook.Worksheets.Delete("Sheet0");
                    package.Save();

                    MessageBox.Show("导出成功！");
                }
            }

        }
        public static void CreateWorksheetAbAssets(ExcelWorksheet ws)

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
        private const string kSheetNameAbAssets = "Sheet1";

        private const string kSheetNameAbDetail = "Sheet2";
        public void FillWorksheetAbAssets(ExcelWorksheet ws,DataGridView DataGridView_BOM_Hold,int check_num)
        {


       

            int k = 2;
            int r = 0;
            for (int i = 0; i < DataGridView_BOM_Hold.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell chkBoxCell = (DataGridViewCheckBoxCell)DataGridView_BOM_Hold.Rows[i].Cells[check_num];
                bool temp = false;

                if (chkBoxCell != null && ((bool)chkBoxCell.EditingCellFormattedValue == true || (bool)chkBoxCell.FormattedValue == true))
                {
                    temp = true;
                }
              
                if(temp==true)
                {
                    ws.Cells[k, 1].Value = r.ToString();//序号
                    ws.Cells[k, 2].Value = DataGridView_BOM_Hold.Rows[i].Cells[2].Value;//代码
                    ws.Cells[k, 3].Value = DataGridView_BOM_Hold.Rows[i].Cells[3].Value;///规格型号
                    ws.Cells[k, 4].Value = DataGridView_BOM_Hold.Rows[i].Cells[4].Value;// 物料名称
                    ws.Cells[k, 5].Value = DataGridView_BOM_Hold.Rows[i].Cells[5].Value;// 品牌
                    ws.Cells[k, 6].Value = "个";//单位
                    if (check_num == 14)
                    {

                      ws.Cells[k, 7].Value = DataGridView_BOM_Hold.Rows[i].Cells[12].Value;//审核日期
                    }
                    r++;
                    k++;
                }
              
                
            }


         //   ws.Cells[3, 1].Hyperlink = new ExcelHyperLink(kSheetNameAbDetail + "!A3", "SubTerrainObjs_1_1.assetbundle");


           // ws.Cells[4, 1].Hyperlink = new ExcelHyperLink(kSheetNameAbDetail + "!A300", "Terrain_Data_1_8.assetbundle");



        }

    }
}
