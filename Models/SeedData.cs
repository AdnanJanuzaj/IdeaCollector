using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IdeaCollector.Data;
using System;
using System.Linq;

namespace IdeaCollector.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Idea.Any())
                {
                    return;   // DB has been seeded
                }

                context.Idea.AddRange(
                    new Idea
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = "kh"
                    },

                    new Idea
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = "kjh"
                    },

                    new Idea
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = "mhjb"
                    },

                    new Idea
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = "kjh"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}