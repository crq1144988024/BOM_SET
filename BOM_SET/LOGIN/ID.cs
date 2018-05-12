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
        public static 权限 login_now_Permission_enum;
        public static string login_now_Permission_str;
        public static string login_now_Nanme;
        public static int  login_now_SORT;
        public static 类别 login_now_SORT_enum;
        public static string login_now_SORT_str;
        public static string login_now_PASSWORD;
        public static int login_now_status;
        public static string login_now_status_str;
        public enum 权限
        {
           操作者 =  1 ,
           管理员 = 2,
           数据库管理员 = 3

        }
        public enum 类别
        {
          
            电气设计 = 1,
            机械设计 = 2,
            物料管理员 = 3,
            采购=4,
            电气审核=5,
            机械审核=6

        }
        public   struct Login_Information
        {
            int ID;
            int  Permission;
            String Nanme;
            int SORT;
            string login_now_PASSWORD;
        }
        public void  ID_output_Permission( int permission,out ID .权限 OUT_permission ,out string OUT_string )
        {
            ID.权限 out1=ID .权限 .操作者 ;
            string OUT2 = "操作者";
            switch (permission)
            {
                case 1:
                    out1 = ID.权限.操作者;
                    OUT2 = "操作者";
                    break;
                case 2:
                    out1 = ID.权限.管理员;
                    OUT2 = "管理员";
                    break;
                case 3:
                    out1 = ID.权限.数据库管理员;
                    OUT2 = "数据库管理员";
                    break;
                default:
                    break;
            }

            OUT_permission = out1;
            OUT_string = OUT2;

        }
        public void ID_output_Permission(int permission, out string OUT_string)
        {
           
            string OUT2 = "操作者";
            switch (permission)
            {
                case 1:
                  
                    OUT2 = "操作者";
                    break;
                case 2:
                    
                    OUT2 = "管理员";
                    break;
                case 3:
                    
                    OUT2 = "数据库管理员";
                    break;
                default:
                    break;
            }

            
            OUT_string = OUT2;

        }
        public void ID_output_Permission(string string_per,out int OUT_permission)
        {

            int  OUT2 = 1;
            switch (string_per)
            {
                case "操作者":

                    OUT2 = 1;
                    break;
                case "管理员" :

                    OUT2 = 2;
                    break;
                case "数据库管理员":

                    OUT2 = 3;
                    break;
                default:
                    break;
            }


            OUT_permission = OUT2;

        }
        public void ID_output_SORT(int SORT, out ID.类别 OUT_SORT, out string OUT_string)
        {
            ID.类别 out1 = ID.类别.电气设计 ;
            string OUT2 = "电气设计";
            switch (SORT)
            {
                case 1:
                    OUT_SORT = ID.类别.电气设计;
                    OUT2 = "电气设计";
                    break;
                case 2:
                    OUT_SORT = ID.类别.机械设计;
                    OUT2 = "机械设计";
                    break;
                case 3:
                    OUT_SORT = ID.类别.物料管理员;
                    OUT2 = "物料管理员";
                    break;
                case 4:
                    OUT_SORT = ID.类别.采购;
                    OUT2 = "采购";
                    break;
                case 5:
                    OUT_SORT = ID.类别.电气审核;
                    OUT2 = "电气审核";
                    break;
                case 6:
                    OUT_SORT = ID.类别.机械审核;
                    OUT2 = "机械审核";
                    break;
                default:
                    break;
            }

            OUT_SORT = out1;
            OUT_string = OUT2;

        }
        public void ID_output_SORT(int SORT, out string OUT_string)
        {
         
            string OUT2 = "电气设计";
            switch (SORT)
            {
                case 1:
                  
                    OUT2 = "电气设计";
                    break;
                case 2:
                    
                    OUT2 = "机械设计";
                    break;
                case 3:
                   
                    OUT2 = "物料管理员";
                    break;
                case 4:
                 
                    OUT2 = "采购";
                    break;
                case 5:
                   
                    OUT2 = "电气审核";
                    break;
                case 6:
                   
                    OUT2 = "机械审核";
                    break;
                default:
                    break;
            }

           
            OUT_string = OUT2;

        }
        public void ID_output_SORT(string string_sort, out int OUT_SORT)
        {

            int OUT2 =1;
            switch (string_sort)
            {
                case "电气设计":

                    OUT2 = 1;
                    break;
                case "机械设计":

                    OUT2 = 2;
                    break;
                case "物料管理员":

                    OUT2 = 3;
                    break;
                case "采购":

                    OUT2 = 4;
                    break;
                case "电气审核":

                    OUT2 = 5;
                    break;
                case "机械审核":

                    OUT2 = 6;
                    break;
                default:
                    break;
            }


            OUT_SORT = OUT2;

        }
    }
}
