using BOM_SET.sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace BOM_SET
{
   public  class Globle_TOOLS_SET_Datagridview
    {
        DataClasses1DataContext data_bom = new DataClasses1DataContext();
        List<string> list_ID_FIND = new List<string>();
        List<string[]> list0_all = new List<string[]>() { };
        ////
        public void search_datagridview(DataGridView datagridview_1,CheckBox CheckBox1_find_condition, string Textbox_find, ComboBox comboxcode_A,ComboBox comboxcode_B, ComboBox comboxcode_C)
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
                string[] strs = new string[] { li.代码, li.名称, li.品牌, li.技术参数, li.价格.ToString(), li.图片, li.规格型号, li.附件, li.全名, li.审核人, li.ID.ToString(),li.备注 };
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
                    if (li[10] != "") { datagridview_1.Rows[i].Cells[1].Value = li[10]; }//ID
                    if (li[0] != "") { datagridview_1.Rows[i].Cells[2].Value = li[0]; }//物料代码
                    if (li[6] != "") { datagridview_1.Rows[i].Cells[3].Value = li[6]; }//规格型号
                    if (li[1] != "") { datagridview_1.Rows[i].Cells[4].Value = li[1]; }//物料名称
                    if (li[2] != "") { datagridview_1.Rows[i].Cells[5].Value = li[2]; }//品牌
                    if (li[3] != "") { datagridview_1.Rows[i].Cells[6].Value = li[3]; }//技术参数
                    if (li[11] != "") { datagridview_1.Rows[i].Cells[6].Value = li[11]; }//备注
                    if (li[4] != "") { datagridview_1.Rows[i].Cells[6].Value = li[4]; }//价格

                 
                    list_ID_FIND.Add(li[10]);
                    i++;
                }



            }


        }


    }
}
