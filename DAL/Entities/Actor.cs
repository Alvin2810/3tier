using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Actor
    {
        public Int64 Actor_ID { get; set; }
        public string Actor_fname { get; set; }
        public string Actor_lname { get; set; }
        public string Actor_gender { get; set; }
    }
}
