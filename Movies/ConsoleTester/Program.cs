using BusinessLogic.Solid;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //OldCode();
            NewBL();
            NewCode();
        }

        private static void NewBL()
        {
            string connStr = ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString;
            MovieDal dal = new MovieDal(connStr);


            FilmManager manager = new FilmManager(dal);
            MovieDTO m = new MovieDTO
            {
                Title = "Test from BL",
                Year = 2019,
                GenreID = 1
            };
            m = manager.AddMovie(m);
        }

        private static void NewCode()
        {
            MovieDal dal = new MovieDal(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);

            MovieDTO m = new MovieDTO 
            {
                Title = "Test",
                Year = 2020,
                GenreID = 1
            };
            m = dal.CreateMovie(m);
            Console.WriteLine($"New movie ID: {m.MovieID}");

            foreach (var movie in dal.GetAllMovies())
            {
                Console.WriteLine($"{movie.MovieID}\t{movie.Title}\t{movie.Year}");
            }

            Console.WriteLine($"Deleting movie ID: {m.MovieID}");
            dal.DeleteMovie(m.MovieID);
            foreach (var movie in dal.GetAllMovies())
            {
                Console.WriteLine($"{movie.MovieID}\t{movie.Title}\t{movie.Year}");
            }
        }

        private static void OldCode()
        {
            string connStr = ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Movie";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["MovieID"]}\t{reader["Title"]}\t{reader["Year"]}");
                }
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                comm.CommandText = "update Movie set Year = @newYear where MovieID = 1";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@newYear", 2020);
                int affected = comm.ExecuteNonQuery();

                Console.WriteLine($"Affected rows: {affected}");
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                comm.CommandText = "select max(Year) from Movie";
                int year = (int)comm.ExecuteScalar();

                Console.WriteLine($"Max year: {year}");
            }
        }
    }
}
