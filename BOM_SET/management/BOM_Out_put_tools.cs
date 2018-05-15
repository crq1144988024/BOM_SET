using System;
using System.Collections.Generic;
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
        public void find_bom_project(DataGridView datagridview_1)
        {
            var q_abc_text = from t in BOM_project_hold.Table_BOM_HOLD

                                  where t.是否已提计划=="否"&& t.是否提交申请 == "是"

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

                                 where t.ID== Convert.ToInt32( check_value(li.项目负责人ID))

                             select t;
                string nametemp = "";
                foreach(var name in q_name)
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
                DataGridViewComboBoxCell combox8 = (DataGridViewComboBoxCell)datagridview_1.Rows[i].Cells[9];

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


        public string check_value(object str)
        {
            string str0 = " ";

            if (str != null) { str0 = str.ToString().Trim(); }
            str = str0;
            return str0;
        }

    }
}
