using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class MovieDal : IMovieDal
    {
        private string connectionString;

        public MovieDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public MovieDTO CreateMovie(MovieDTO movie)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Movie (Title, Year, GenreID) output INSERTED.MovieID values (@title, @year, @genre)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@title", movie.Title);
                comm.Parameters.AddWithValue("@year", movie.Year);
                comm.Parameters.AddWithValue("@genre", movie.GenreID);
                conn.Open();

                movie.MovieID = Convert.ToInt32(comm.ExecuteScalar());
                return movie;
            }
        }

        public void DeleteMovie(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Movie where MovieID = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<MovieDTO> GetAllMovies()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Movie";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<MovieDTO> movies = new List<MovieDTO>();
                while (reader.Read())
                {
                    movies.Add(new MovieDTO
                    {
                        MovieID = (int)reader["MovieID"],
                        Title = reader["Title"].ToString(),
                        Year = (int)reader["Year"]
                    });
                }

                return movies;
            }
        }

        public MovieDTO GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public MovieDTO UpdateMovie(MovieDTO movie)
        {
            throw new NotImplementedException();
        }
    }
}
