using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MbmStore.DAL
{
    public class EFMovieRepository : IMovieRepository
    {
        MbmStoreContext context = new MbmStoreContext();

        public IEnumerable<Movie> GetMovieList()
        {
            return context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return context.Movies.Find(id);
        }

        public void SaveMovie(Movie movie)
        {
            if (movie.ProductId == 0)
            {
                movie.CreatedDate = DateTime.Now;
                context.Movies.Add(movie);
                context.SaveChanges();
            }
            else
            {
                context.Entry(movie).State = EntityState.Modified;
                context.Entry(movie).Property(b => b.CreatedDate).IsModified = false;
                context.SaveChanges();
            }
        }
        public Movie DeleteMovie(int id)
        {
            Movie movie = context.Movies.Find(id);
            if (movie != null)
            {
                context.Movies.Remove(movie);
                context.SaveChanges();
            }
            return movie;
        }

    }
}