using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CinemaApp.Model
{
    public class MovieSeat
    {
        public int MovieSeatId { get; set; }
        public int MovieTimeId { get; set; } //FK
        public string Seat { get; set; }
        public SeatStatus SeatStatus { get; set; }
    }
    public enum SeatStatus
    {
        T, E
    }
}
