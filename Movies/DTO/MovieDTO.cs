using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MovieDTO
    {
        public int MovieID { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public int GenreID { get; set; }
    }
}
