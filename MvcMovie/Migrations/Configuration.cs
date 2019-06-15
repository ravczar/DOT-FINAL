namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MvcMovie.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcMovie.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcMovie.Models.MovieDBContext context)
        {
            context.Movies.AddOrUpdate(i => i.Title,
                new Movie
                {
                    Title = "Frankenstein",
                    ReleaseDate = DateTime.Parse("1930-1-10"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "CC"
                },

                 new Movie
                 {
                     Title = "Captain Murica",
                     ReleaseDate = DateTime.Parse("2001-8-20"),
                     Genre = "Fantasy",
                     Price = 10.80M,
                     Rating = "BB"
                 },

                 new Movie
                 {
                     Title = "Titanic",
                     ReleaseDate = DateTime.Parse("1995-2-14"),
                     Genre = "Comedy",
                     Price = 20.99M,
                     Rating = "CC"
                 },

               new Movie
               {
                   Title = "Avengers Endgame",
                   ReleaseDate = DateTime.Parse("2019-4-26"),
                   Genre = "Western",
                   Price = 25.00M,
                   Rating = "CC"
               }

           );

        }


    }
}
