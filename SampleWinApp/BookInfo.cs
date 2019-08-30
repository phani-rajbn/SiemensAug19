using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWinApp
{
    [Serializable]
    class BookInfo
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public double BookPrice { get; set; }
    }
}
