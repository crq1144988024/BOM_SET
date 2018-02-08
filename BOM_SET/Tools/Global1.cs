using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOM_SET.Tools
{
   public class Global1
    {
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
