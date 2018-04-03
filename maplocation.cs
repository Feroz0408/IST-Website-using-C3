using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client3
{
    class mloc
    {
        public string city { get; set; }
        public string state { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    class maplocation
    {
        public List<mloc> maplo { get; set; }
    }
}
