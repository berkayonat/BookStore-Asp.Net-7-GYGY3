using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Data
{
    public static class DbSeeding
    {
        public static void SeedDatabase(AppDbContext dbContext)
        {
            seedGenreIfNoExists(dbContext);
            seedPublisherIfNoExists(dbContext);
            seedAuthorIfNoExists(dbContext);
            seedBookIfNotExists(dbContext);

        }

        private static void seedBookIfNotExists(AppDbContext dbContext)
        {
            if (!dbContext.Books.Any())
            {
                var books = new List<Book>()
                {
                    new () { Title="Kitap 1", PublisherId=1, GenreId=1, ImageUrl="https://picsum.photos/200/300", Price=55M, Quantity=100,Status=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new () { Title="Kitap 2", PublisherId=1, GenreId=2, ImageUrl="https://picsum.photos/200/300", Price=60M, Quantity=100,Status=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new () { Title="Kitap 3", PublisherId=2, GenreId=3, ImageUrl="https://picsum.photos/200/300", Price=75M, Quantity=100,Status=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now}
                };
                dbContext.Books.AddRange(books);
                dbContext.SaveChanges();
            }
        }

        private static void seedAuthorIfNoExists(AppDbContext dbContext)
        {
            if (!dbContext.Authors.Any())
            {
                var authors = new List<Author>()
                {
                    new () {Name="Yazar 1", Status=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new () {Name="Yazar 2", Status=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new () {Name="Yazar 3", Status=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now}
                };
                dbContext.Authors.AddRange(authors);
                dbContext.SaveChanges();
                
            }
        }

        private static void seedPublisherIfNoExists(AppDbContext dbContext)
        {
            if (!dbContext.Publishers.Any())
            {
                var publishers = new List<Publisher>()
                {
                    new () {Name="A Yayinlari", Status=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new () {Name="B Yayinlari", Status=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new () {Name="C Yayinlari", Status=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now}
                };
                dbContext.Publishers.AddRange(publishers);
                dbContext.SaveChanges();
            }
        }

        private static void seedGenreIfNoExists(AppDbContext dbContext)
        {
            if (!dbContext.Genres.Any())
            {
                var genres = new List<Genre>()
                {
                    new () {Name="Edebiyat", Status=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new () {Name="Tarih", Status=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new () {Name="Bilim", Status=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now}
                };
                dbContext.Genres.AddRange(genres);
                dbContext.SaveChanges();
            }
        }

    }
}
