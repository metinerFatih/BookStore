using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Authors.AddRange
                (
                    new Author
                    {
                        Name = "Eric",
                        Surname = "Ries",
                        BirthDate = new DateTime(1978, 09, 22)
                    },
                    new Author
                    {
                        Name = "Charlotte Perkins",
                        Surname = "Gilman",
                        BirthDate = new DateTime(1935, 08, 17)
                    },
                    new Author
                    {
                        Name = "Frank",
                        Surname = "Herbert",
                        BirthDate = new DateTime(1920, 10, 08)
                    }
                );

                context.Genres.AddRange
                (
                    new Genre
                    {
                        Name = "Personel Growth"
                    },
                    new Genre
                    {
                        Name = "Science Finction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                );


                context.Books.AddRange
                (
                    new Book
                    {
                        Id = 1,
                        Title = "Lean Startup",
                        AuthorId = 1,
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Herland",
                        AuthorId = 2,
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Dune",
                        AuthorId = 3,
                        GenreId = 2,
                        PageCount = 540,
                        PublishDate = new DateTime(2005, 12, 21)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}