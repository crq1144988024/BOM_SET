using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace BOM_SET.Tools
{
    class FolderDialog_OPEN
    {
    }
    /// <summary>
    /// 文件
    /// </summary>
    public class FolderDialog : FolderNameEditor
    {
        FolderBrowser fDialog = new FolderBrowser();
        public FolderDialog() { }
        public DialogResult DisplayDialog()
        {
            return DisplayDialog("请选择一个文件夹");
        }
        public DialogResult DisplayDialog(string description)
        {
            fDialog.Description = description;
        
            return fDialog.ShowDialog();
        }
        public string Path
        {
            get
            {
                return fDialog.DirectoryPath;
            }
        }
        ~FolderDialog()
        {
            fDialog.Dispose();
        }
    }
    //
    public class FolderDialog_file
    {
        public void file_path_open(string DefaultExt, out string tbFilePath)
        {
            tbFilePath = "";
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                dialog.DefaultExt = DefaultExt;
                dialog.CheckPathExists = true;
                dialog.Filter = DefaultExt;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        tbFilePath = dialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }


            }
          
        }

        public void file_path_save(string DefaultExt, out string tbFilePath)
        {
            tbFilePath = "";
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
               
                dialog.DefaultExt = DefaultExt;
                dialog.AddExtension = true;
                dialog.Filter = DefaultExt;
                dialog.CheckPathExists = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        tbFilePath = dialog.FileName;
                      
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }


            }

        }
        public void file_path_save(string DefaultExt,string filename, out string tbFilePath)
        {
            tbFilePath = "";
            using (SaveFileDialog dialog = new SaveFileDialog())
            {

                dialog.DefaultExt = DefaultExt;
                dialog.AddExtension = true;
                dialog.Filter = DefaultExt;
                dialog.CheckPathExists = true;
                dialog.FileName = filename;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        tbFilePath = dialog.FileName;

                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }


            }

        }



    }
}