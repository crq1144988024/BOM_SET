using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOM_SET.Tools
{
   public class Globle_add_supplies
    {/// <summary>
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
        public void ADD_supplies(ComboBox comboxcode_A , ComboBox comboxcode_B, ComboBox comboxcode_C, string Textbox_SUPPLIES_model1, string skinComboBox_SUPPLIES_NAME1,
            string Textbox_brank1,string Textbox_supples_sort1, string Textbox_supples_technical_parameters1,string Textbox_supples_spare1,string skinTextBox_pixturebox_path1
           , string skinTextBox_datapath1,CheckBox skinCheckBox_price1, string skinTextBox_price1)
        {
            sql.DataClasses_ADD_BOM_TEMPDataContext ADD_TEMP = new sql.DataClasses_ADD_BOM_TEMPDataContext();
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
            int  TextBox_price1 = 0;



            if (comboxcode_A.SelectedItem != null) { codeA = comboxcode_A.SelectedItem.ToString().Substring(0, 3); }
            if (comboxcode_B.SelectedItem != null) { codeB = comboxcode_B.SelectedItem.ToString().Substring(0, 3); }
            if (comboxcode_C.SelectedItem != null) { codeC = comboxcode_C.SelectedItem.ToString().Substring(0, 1); }

            if (Textbox_SUPPLIES_model1 != null) { SUPPLIES_model1= Textbox_SUPPLIES_model1.ToString().Trim(); }
            if (skinComboBox_SUPPLIES_NAME1 != null) { SUPPLIES_NAME1= skinComboBox_SUPPLIES_NAME1.ToString().Trim(); }
            if (Textbox_brank1 != null) { brank1 = Textbox_brank1.ToString().Trim(); MessageBox.Show("请填写品牌"); return; }

            if (Textbox_supples_sort1 != null) { supples_sort1 = Textbox_supples_sort1.ToString().Trim(); }
            if (Textbox_supples_technical_parameters1 != null) { supples_technical_parameters1 = Textbox_supples_technical_parameters1.ToString().Trim(); }
            if (Textbox_supples_spare1 != null) { supples_spare1 = Textbox_supples_spare1.ToString().Trim(); }
            if (skinTextBox_pixturebox_path1 != null) { pixturebox_path1 = skinTextBox_pixturebox_path1.ToString().Trim(); }

            if (skinTextBox_datapath1 != null) { datapath = skinTextBox_datapath1.ToString().Trim(); }
            if (skinCheckBox_price1 != null) { price1 = skinCheckBox_price1.ToString().Trim(); }
           
            if (skinTextBox_price1 != null) { TextBox_price1 = Convert.ToInt32( skinTextBox_price1.ToString().Trim()); }
            if (price1 == "否")
            {
                TextBox_price1 = 0;
            }

            string codeD = codeA + "." + codeB + "." + codeC;
            string code_ALL = codeD + SUPPLIES_model1;

            var table0 = new sql.Table_bom_all_add_temp
            {
                代码 =code_ALL,
                名称 = SUPPLIES_NAME1,
                品牌 = brank1,
                类别 = supples_sort1,
                技术参数 = supples_technical_parameters1,
                备注 = supples_spare1,
                图片 = pixturebox_path1,
                资料路径 = datapath,
                价格 = TextBox_price1,
               
            };

            ADD_TEMP.Table_bom_all_add_temp.InsertOnSubmit(table0);
            ADD_TEMP.SubmitChanges();


        }
    }
}
