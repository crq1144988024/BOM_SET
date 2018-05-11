using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace BOM_SET
{
  public   class Global
    {
        public static string path_exe = Directory.GetCurrentDirectory();
        public static DataSet dataset=new DataSet();
        public static string procurement_name;
        public static string project_name;
        public static string project_ST_name;
        public static List<String[]> BOM_LIST=new List<string[]>();
    }
}
