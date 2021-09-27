using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Movie
    {
        public Int64 Movie_ID { get; set; }
        public string Movie_Title { get; set; }
        public int Movie_Year { get; set; }
    }
}
