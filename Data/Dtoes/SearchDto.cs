using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtoes
{
    public class SearchDto
    {
        public int SkipCount { get; set; }

        public DateTime DateTime { get; set; }

        public int Size { get; set; }

        public string From { get; set; }

    }
}
