using DataStructure_CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructure_CinemaApp
{
    public class Data
    {
        public ICollection<Users> Users { get; set; }
        public ICollection<Movie> Movie { get; set; }
        public ICollection<MovieTime> MovieTime { get; set; }
        public ICollection<MovieSeat> MovieSeat { get; set; }

        public Data()
        {
            Users = new List<Users>();
            Movie = new List<Movie>();
            MovieTime = new List<MovieTime>();
            MovieSeat = new List<MovieSeat>();
        }

        public void GenerateUserData()
        {
            Users.Add(new Users() { Id = Guid.NewGuid(), Username = "john", Password = "john123" });
            Users.Add(new Users() { Id = Guid.NewGuid(), Username = "mike", Password = "mike123" });
        }

        public void GenerateMovieData()
        {
            Movie.Add(new Movie() { MovieId = 101, MovieTitle = "The Justice League", ReleaseDate = new DateTime(2020, 03, 01), Status = Status.NowShowing });
            Movie.Add(new Movie() { MovieId = 102, MovieTitle = "The Matrix", ReleaseDate = new DateTime(2020, 03, 02), Status = Status.NowShowing });
            Movie.Add(new Movie() { MovieId = 103, MovieTitle = "The Avengers", ReleaseDate = new DateTime(2020, 03, 06), Status = Status.ComingSoon });
            Movie.Add(new Movie() { MovieId = 104, MovieTitle = "Lord of the Ring", ReleaseDate = new DateTime(2020, 03, 10), Status = Status.ComingSoon });
        }

        public void GenerateMovieTime()
        {
            MovieTime.Add(new MovieTime() { MovieTimeId = 201, MovieId = 101, MovieStartTime = new DateTime(2020, 03, 01, 10, 0, 0) });
            MovieTime.Add(new MovieTime() { MovieTimeId = 202, MovieId = 101, MovieStartTime = new DateTime(2020, 03, 01, 14, 30, 0) });
            MovieTime.Add(new MovieTime() { MovieTimeId = 203, MovieId = 101, MovieStartTime = new DateTime(2020, 03, 01, 18, 10, 0) });

            MovieTime.Add(new MovieTime() { MovieTimeId = 204, MovieId = 102, MovieStartTime = new DateTime(2020, 03, 02, 11, 0, 0) });
            MovieTime.Add(new MovieTime() { MovieTimeId = 205, MovieId = 102, MovieStartTime = new DateTime(2020, 03, 02, 15, 30, 0) });
            MovieTime.Add(new MovieTime() { MovieTimeId = 206, MovieId = 102, MovieStartTime = new DateTime(2020, 03, 02, 20, 10, 0) });
        }

        public void GenerateSeat()
        {
            SeatStatus seatStatus;

            foreach (var item in MovieTime)
            {
                for (int i = 1; i <= 3; i++)
                {
                    for (int x = 1; x <= 10; x++)
                    {
                        Random random = new Random();
                        Thread.Sleep(1);
                        int s = random.Next(0, 2);

                        if (s == 0)
                        {
                            seatStatus = SeatStatus.E;
                        }
                        else
                        {
                            seatStatus = SeatStatus.T;
                        }
                        Thread.Sleep(1);
                        MovieSeat.Add(new MovieSeat()
                        {
                            Seat = i + "," + x,
                            SeatStatus = seatStatus,
                            MovieTimeId = item.MovieTimeId
                        });
                    }
                }
            }
        }
    }
}
