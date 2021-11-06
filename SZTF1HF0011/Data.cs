using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF1HF0011
{
    class Data
    {
        public string S { get; set; }
        public string P { get; set; }
        public int N { get; set; }
        public int MIN { get; set; }
        public int MAX { get; set; }
        public string Output { get; set; }
        public string expectedOutput { get; set; }
        public string Name { get; set; }
        
        public Data()
        {
            Output = " ";
        }
        public Data(string s, string p, int n, int min, int max)
        {
            this.S = s;
            this.P = p;
            this.N = n;
            this.MIN = min;
            this.MAX = max;
        }
        public static int Count()
        {
            return 1;
        }
    }
}
