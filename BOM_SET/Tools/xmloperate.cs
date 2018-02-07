using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BOM_SET.Tools
{
    public class xmloperate
    {
        public  struct xml_structure_data
        {
            string[] name1;
            List<string[]> list2;
            List<string[]> list3;

        }
       public static void write(xml_structure_data[] xml_structure_dataS)
        {
            if (File.Exists("d:\\123.xml"))
            {
                File.Delete("d:\\123.xml");
            }
            //获取根节点对象
            XDocument document = new XDocument();
            XElement root = new XElement("School");
            XElement book = new XElement("BOOK");
            XElement book1 = new XElement("高等数学");
            book.SetElementValue("name", "高等数学");
            book.SetElementValue("name1", "大学英语");
            book1.SetElementValue("name", "代数");
            root.Add(book);
            book.Add(book1);
            root.Save("d:\\123.xml");
          
        }
        public static void read(string[] args)
        {
            //将XML文件加载进来
            XDocument document = XDocument.Load("D:\\123.xml");
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            XElement ele = root.Element("BOOK");
            //获取name标签的值
            XElement shuxing = ele.Element("name");
            Console.WriteLine(shuxing.Value);
            //获取根元素下的所有子元素
            IEnumerable<XElement> enumerable = root.Elements();
            foreach (XElement item in enumerable)
            {
                foreach (XElement item1 in item.Elements())
                {
                    Console.WriteLine(item1.Name);   //输出 name  name1            
                }
                Console.WriteLine(item.Attribute("id").Value);  //输出20
            }
            Console.ReadKey();
        }
    }
}
