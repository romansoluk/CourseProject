using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMovieDal
    {
        MovieDTO GetMovieById(int id);
        List<MovieDTO> GetAllMovies();
        MovieDTO UpdateMovie(MovieDTO movie);
        MovieDTO CreateMovie(MovieDTO movie);
        void DeleteMovie(int id);
    }
}
