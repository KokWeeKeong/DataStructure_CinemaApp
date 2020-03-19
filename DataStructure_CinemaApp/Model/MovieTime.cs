using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CinemaApp.Model
{
    public class MovieTime
    {
        public int MovieTimeId { get; set; }
        public int MovieId { get; set; } //FK
        public DateTime MovieStartTime { get; set; }
    }
}
