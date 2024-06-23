using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The Other Side of Heaven",
                    ReleaseDate = DateTime.Parse("2002-04-12"),
                    Genre = "Drama",
                    Rating = "PG",
                    Image = "https://flxt.tmsimg.com/assets/p74953_p_v10_ac.jpg",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "17 Miracles ",
                    ReleaseDate = DateTime.Parse("2011-06-03"),
                    Genre = "Adventure",
                    Rating = "PG",
                    Image = "https://static.tvtropes.org/pmwiki/pub/images/17_miracles.jpg",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-10-10"),
                    Genre = "Documentry",
                    Rating = "PG",
                    Image = "https://i.ytimg.com/vi/TOwOt-uFMEA/maxresdefault.jpg",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "The Saratov Approach",
                    ReleaseDate = DateTime.Parse("2013-10-15"),
                    Genre = "Action",
                    Rating = "PG-13",
                    Image = "https://d2jc79253juilm.cloudfront.net/product-images/000/682/823/detail/Saratov_Approach.jpeg",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}
