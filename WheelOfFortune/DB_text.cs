using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    public class DB_text
    {
        public string Num { get; set; }
        public string Text { get; set; }
        public int Count { get; set; }


        public List<DB_text> texts = new List<DB_text>
        {
           
        };
    }
}
