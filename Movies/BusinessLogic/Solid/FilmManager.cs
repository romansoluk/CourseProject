using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Solid
{
    public class FilmManager : IFilmManager
    {
        private readonly IMovieDal _movieDal;

        public FilmManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public MovieDTO AddMovie(MovieDTO movie)
        {
            return _movieDal.CreateMovie(movie);
        }
    }
}
