using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client3
{
    public class Mincourse
    {

        public string courseID { get; set; }
        public string title { get; set; }
        public string description { get; set; }

    }

    class MinorCourse
    {
        public List<Mincourse> courses { get; set; }
    }
}
