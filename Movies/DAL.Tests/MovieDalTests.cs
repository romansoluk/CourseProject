using DAL.Concrete;
using NUnit.Framework;
using System.EnterpriseServices;
using System.Linq;
using System.Configuration;
using DTO;
using System.Runtime.InteropServices;

namespace DAL.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class MovieDalTests: ServicedComponent
    {
        public MovieDalTests()
        { }

        [Test]
        public void CreateTest()
        {
            MovieDal dal = new MovieDal(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
            var result = dal.CreateMovie(new MovieDTO 
            { 
                Title = "Movie from test",
                Year = 2000,
                GenreID = 1
            });
            Assert.IsTrue(result.MovieID != 0, "returned ID should be more than zero");
        }

        [Test]
        public void GetAllTest()
        {
            MovieDal dal = new MovieDal(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);
            var result = dal.CreateMovie(new MovieDTO
            {
                Title = "Movie for get all",
                Year = 2000,
                GenreID = 1
            });
            var movies = dal.GetAllMovies();
            Assert.AreEqual(1, movies.Count(x => x.Title == "Movie for get all"));
        }

        [TearDown]
        public void Teardown()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }

    }
}
