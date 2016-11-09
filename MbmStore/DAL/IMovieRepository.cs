using MbmStore.Models;
using System.Collections.Generic;

namespace MbmStore.DAL
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovieList();
        Movie GetMovieById(int id);
        void SaveMovie(Movie movie);
        Movie DeleteMovie(int id);
    }
}
