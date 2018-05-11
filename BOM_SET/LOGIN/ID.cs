using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOM_SET.LOGIN
{
    public  class ID
    {
        public static  int   login_now_ID;
        public static int  login_now_Permission;
        public static string login_now_Nanme;
        public static int  login_now_SORT;
        public static string login_now_PASSWORD;


        public   struct Login_Information
        {
            int ID;
            int  Permission;
            String Nanme;
            int SORT;
            string login_now_PASSWORD;
        }
    }
}
