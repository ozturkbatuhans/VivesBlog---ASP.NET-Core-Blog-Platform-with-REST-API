using Microsoft.EntityFrameworkCore;
using VivesBlog.Model;

namespace VivesBlog.Repository
{
    public class VivesBlogDbContext(DbContextOptions<VivesBlogDbContext> options) : DbContext(options)
    {
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<Person> People => Set<Person>();

        public void Seed()
        {
            var author = new Person
            {
                FirstName = "Bavo",
                LastName = "Ketels",
                Email = "bavo.ketels@vives.be"
            };

            People.Add(author);

            Articles.AddRange(new List<Article>
            {
                new Article
                {
                    Title = "Introduction to C#",
                    Content = "This article provides an introduction to C# programming language.",
                    CreatedDate = DateTime.Now,
                    Author = author
                },
                new Article
                {
                    Title = "Getting Started with .NET 9",
                    Content = "Learn how to get started with .NET 9 in this comprehensive guide.",
                    CreatedDate = DateTime.Now,
                    Author = author
                },
                new Article
                {
                    Title = "Understanding Razor Pages",
                    Content = "This article explains the basics of Razor Pages in ASP.NET Core.",
                    CreatedDate = DateTime.Now,
                    Author = author

                },
                new Article
                {
                    Title = "Advanced C# Techniques",
                    Content = "Explore advanced techniques in C# programming.",
                    CreatedDate = DateTime.Now,
                    Author = author
                },
                new Article
                {
                    Title = "Building Web APIs with ASP.NET Core",
                    Content = "Learn how to build robust web APIs using ASP.NET Core.",
                    CreatedDate = DateTime.Now,
                    Author = author
                },
                new Article
                {
                    Title = "Entity Framework Core Basics",
                    Content = "An introduction to Entity Framework Core and its features.",
                    CreatedDate = DateTime.Now,
                    Author = author
                },
                new Article
                {
                    Title = "Unit Testing in .NET",
                    Content = "Learn how to write unit tests for your .NET applications.",
                    CreatedDate = DateTime.Now,
                    Author = author
                },
                new Article
                {
                    Title = "Dependency Injection in ASP.NET Core",
                    Content = "Understand the principles of dependency injection in ASP.NET Core.",
                    CreatedDate = DateTime.Now,
                    Author = author
                },
                new Article
                {
                    Title = "Blazor: Building Interactive Web UIs",
                    Content = "Discover how to build interactive web UIs using Blazor.",
                    CreatedDate = DateTime.Now,
                    Author = author
                },
                new Article
                {
                    Title = "Securing ASP.NET Core Applications",
                    Content = "Learn best practices for securing your ASP.NET Core applications.",
                    CreatedDate = DateTime.Now,
                    Author = author
                }
            });

            SaveChanges();
        }
    }
}
