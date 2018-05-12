using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
using System.Xml.Linq;

namespace BOM_SET.LOGIN
{
    public partial class Login_form : Skin_DevExpress 
    {
        public Login_form()
        {
            InitializeComponent();
        }
        DataClasses_LoginDataContext DATACALSSES = new DataClasses_LoginDataContext();
        private void Login_Load(object sender, EventArgs e)
        {
            //将XML文件加载进来
            XDocument document = XDocument.Load(Global .path_exe +"\\login.xml");
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            XElement ele = root.Element("name");
            //获取name标签的值
            // XElement shuxing = ele.Element("name");
            ComboBox1.Text = ele.Value;
           // if (LOGIN.ID.login_now_Permission > 0) { Button2.Visible = true;Button1.Visible = false; }
            //if (LOGIN.ID.login_now_Permission <= 0) { Button2.Visible = false ; Button1.Visible = true ; }
        }
        /// <summary>
        ///登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
           
            if (String .IsNullOrEmpty (ComboBox1 .Text))
            {
                label3.Text = "请填写用户名！";
            }

            var q_A = from A in DATACALSSES.Login 

                          where A .NAME.Trim() == ComboBox1 .Text .Trim ()
                          //  where SqlMethods.Like(c.分类代码A, '%' + sort_keywords + '%')
                          //where c.代码.Contains(sort_keywords)
                          //  where A.分类代码A
                      select A;
            if (q_A .Count() == 0) { label3.Text = "该用户不存在"; }
            if(String.IsNullOrEmpty(TextBox1 .Text))
            {
                label3.Text = "请填写密码！";
            }
            ID convert = new ID();
            foreach (var people in q_A)
            {
                if (people.password.Trim ()==TextBox1.Text.Trim())
                {
                    ID.login_now_Permission = Convert.ToInt32(people.Permission);
                    ID.login_now_ID = people.ID;
                    ID.login_now_Nanme = people.NAME.Trim();
                    ID.login_now_PASSWORD = people.password.Trim();
                    ID.login_now_SORT = Convert.ToInt32(people.SORT);

                    convert.ID_output_Permission(ID.login_now_Permission,out  ID.login_now_Permission_enum, out  ID.login_now_Permission_str);
                    convert.ID_output_SORT(ID.login_now_SORT,out  ID.login_now_SORT_enum,out  ID.login_now_SORT_str);
                   


                    if (File.Exists(Global.path_exe + "\\login.xml"))
                    {
                        File.Delete(Global.path_exe + "\\login.xml");
                    }
                    //获取根节点对象
                    XDocument document = new XDocument();
                    XElement root = new XElement("Login");

                    root.SetElementValue("name", ComboBox1 .Text );

                    document.Add(root);
                   
                    root.Save(Global.path_exe + "\\login.xml");


                    label3.Text = "登陆成功！";
                    this.Close();
                }

                else
                {
                    label3.Text = "密码错误！";
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ID.login_now_Permission = 0;
            this.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ID.login_now_Permission <= 0)
            {

            ID.login_now_Permission = 0;
            }
            
        }
    }
}
