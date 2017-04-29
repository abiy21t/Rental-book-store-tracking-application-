using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    class OLBook
    {
            //this class gets data from the open library json API
            public string title { get; set; }
            public string edition_name { get; set; }
            public Author[] authors { get; set; }     
    }
}
