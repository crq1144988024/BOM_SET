using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOM_SET.Tools
{
   public class datagridview_set
    {
        /// <summary>  
        /// 获取或设置该控件下显示字体的大小.  
        /// </summary>  
        [Browsable(true)]
        [DefaultValue(typeof(Font), "宋体,9"), Description("获取或设置该控件下显示字体的大小.")]
        public  Font font
        {
            get { return this.font; }
            set { this.font = value; }
        }
        /// <summary>  
        /// 获取或设置当前字体颜色.  
        /// </summary>  
        [Description("获取或设置当前字体颜色.")]
        public Color FontColor
        {
            get { return this.FontColor; }
            set { this.FontColor = value; }
        }
        /// <summary>  
        /// 获取或设置当前控件的背景图片.  
        /// </summary>  
        [DefaultValue(typeof(Image), ""), Description("获取或设置当前控件的背景图片.")]
        public Image BackImage
        {
            get { return this.BackImage; }
            set { this.BackImage = value; }
        }

        protected  void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
           // base.OnCellPainting(e);
            if (e.Value != null)
            {
                string cellWord = e.Value.ToString();//单元格原本内容  
                string keyWord = e.Value.ToString();//要改变的单元格关键字内容  

                Rectangle cellRect = e.CellBounds;//默认单元格  
                Rectangle keyRect = e.CellBounds;//单元格内容区域，默认定义为单元格大小  
                float fontSizeWeight = 96 / (72 / e.CellStyle.Font.Size); // 字体实际像素宽度  
                float fontSizeHeight = 96 / (72 / e.CellStyle.Font.Size); // 字体实际像素高度  
                                                                          //关键字的坐标  
                keyRect.X += cellWord.Substring(0, cellWord.IndexOf(keyWord)).Length * (int)(fontSizeWeight / 2);
                keyRect.Y += (e.CellBounds.Height - (int)fontSizeHeight) / 2;
                //原文本的Y坐标  
                cellRect.Y = keyRect.Y;

                using (Brush foreColor = new SolidBrush(e.CellStyle.ForeColor), fontColor = new SolidBrush(this.FontColor))
                {
                    //绘制背景色  
                    e.PaintBackground(e.ClipBounds, false);
                    //绘制背景色(被选中状态下)  
                    if (e.State == (DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible))
                        e.PaintBackground(e.ClipBounds, true);
                    //分别绘制原文本和现在改变颜色的文本  
                    e.Graphics.DrawString(cellWord, this.font, foreColor, cellRect, StringFormat.GenericDefault);
                    e.Graphics.DrawString(keyWord, this.font, fontColor, keyRect, StringFormat.GenericDefault);
                    //提交事务  
                    e.Handled = true;
                }
            }
        }

    }
}
