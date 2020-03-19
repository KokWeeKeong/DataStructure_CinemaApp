using ConsoleTables;
using DataStructure_CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CinemaApp
{
    class Program
    {
        private static Data data = new Data();
        static void Main(string[] args)
        {
            bool checktrue = true;
            data.GenerateMovieData();
            data.GenerateUserData();
            data.GenerateMovieTime();
            data.GenerateSeat();

            while (checktrue)
            {
                Console.WriteLine("Welcome to Steve Cinema Ticket App");
                Console.WriteLine("1. View All Movies");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit App");
                Console.WriteLine();
                Console.Write("Enter Your Option : ");
                bool checkOption = int.TryParse(Console.ReadLine(), out int option);
                if (checkOption)
                {
                    switch (option)
                    {
                        case 1:
                            var table = new ConsoleTable("Movie Title", "Release Date", "Status");
                            foreach (var item in data.Movie)
                            {
                                table.AddRow(item.MovieTitle, item.ReleaseDate, item.Status);
                            }
                            table.Write();
                            Console.WriteLine("Login to buy a movie ticket of your favorite movie.");
                            break;

                        case 2:
                            bool checktrue1 = true;
                            Console.Clear();
                            Console.Write("Username : ");
                            string userName = Console.ReadLine();
                            Console.Write("Password : ");
                            string passWord = Console.ReadLine();
                            foreach (var u in data.Users)
                            {
                                if (userName != u.Username || passWord != u.Password)
                                {
                                    Console.WriteLine("Invalid Username or Password");
                                    break;
                                }
                                while (checktrue1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You Login as " + userName);
                                    Console.WriteLine("1. Select a movie");
                                    Console.WriteLine("2. Logout");
                                    Console.WriteLine();
                                    Console.Write("Enter Your Option : ");
                                    bool checkOption2 = int.TryParse(Console.ReadLine(), out int option2);
                                    if (checkOption2)
                                    {
                                        switch (option2)
                                        {
                                            case 1:
                                                Console.Clear();
                                                var movieList = data.Movie.Where(m => m.Status == Model.Status.NowShowing).ToList();

                                                var table1 = new ConsoleTable("Id", "Movie Title", "Release Date");
                                                foreach (var item in movieList)
                                                {
                                                    table1.AddRow(item.MovieId, item.MovieTitle, item.ReleaseDate);
                                                }
                                                table1.Write();
                                                Console.WriteLine();
                                                Console.Write("Enter a movie id : ");
                                                string movieId = Console.ReadLine();

                                                var AvailableMovie = movieList.Where(m => m.MovieId.ToString() == movieId).SingleOrDefault();

                                                if (AvailableMovie != null)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Your movie selection : {0}", AvailableMovie.MovieTitle);
                                                    Console.WriteLine("Select date & time");

                                                    var showTime = data.MovieTime.Where(mt => mt.MovieId == AvailableMovie.MovieId).ToList();

                                                    var table2 = new ConsoleTable("Id", "Date Start Time");

                                                    foreach (var item in showTime)
                                                    {
                                                        table2.AddRow(item.MovieTimeId, item.MovieStartTime);
                                                    }
                                                    table2.Write();
                                                    Console.Write("Enter Id to choose the movie time : ");
                                                    string timeId = Console.ReadLine();

                                                    var AvailableTime = data.MovieTime.Where(mt => mt.MovieId.ToString() == movieId).ToList();

                                                    var seatAvailable = data.MovieSeat.Where(ms => ms.MovieTimeId.ToString() == timeId).ToList();

                                                    if (AvailableTime != null)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Cinema Hall Settings");
                                                        Console.WriteLine("E : Empty" + "\t" + "T : Taken");
                                                        foreach (var item in seatAvailable)
                                                        {
                                                            Console.Write(item.Seat + item.SeatStatus + "\t");
                                                        }
                                                        Console.WriteLine();
                                                        Console.WriteLine("Enter a seat number (row,column). Example 1,2 : ");
                                                        string seatNumber = Console.ReadLine();

                                                        var checkSeatNumber = data.MovieSeat.Where(ms => ms.Seat == seatNumber && ms.MovieTimeId.ToString() == timeId).SingleOrDefault();

                                                        if (checkSeatNumber != null)
                                                        {
                                                            if (checkSeatNumber.SeatStatus == SeatStatus.E)
                                                            {
                                                                checkSeatNumber.SeatStatus = SeatStatus.T;
                                                                Console.WriteLine("Select Seat Success");
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("This seat is already be taken");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Invalid Seat Number");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Invalid Movie Time Id");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Movie Id");
                                                }
                                                break;

                                            case 2:
                                                Console.Clear();
                                                checktrue1 = false;
                                                break;

                                            default:
                                                Console.WriteLine("Invalid Option");
                                                continue;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Option");
                                        break;
                                    }
                                }
                                break;
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                }
            }
        }
    }
}
