using EFCore226.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore226
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EFC Add Test");
            AddToEFCTest();

            Console.WriteLine("End");
            Console.Read();
        }

        public static void AddToEFCTest()
        {
            var shelf = new Shelf();
            shelf.ShelfId = 0;
            shelf.Description = "New Shelf";

            shelf.ShelfBooks = new List<ShelfBook>();
            var sb1 = new ShelfBook
            {
                ShelfId = 0,
                Book = new Book
                {
                    BookId = 100,
                    Author = new Author
                    {
                        AuthorId = 2,
                        FirstName = "Existing Author",
                        LastName = "2"
                    },
                    Title = "Existing Book1"
                }
            };

            shelf.ShelfBooks.Add(sb1);

            var sb2 = new ShelfBook
            {
                ShelfId = 0,
                Book = new Book
                {
                    BookId = 200,
                    Author = new Author
                    {
                        AuthorId = 2,
                        FirstName = "Existing Author",
                        LastName = "2"
                    },
                    Title = "Existing Book2"
                }
            };

            shelf.ShelfBooks.Add(sb2);

            using (var ctx = new EFC.BooksDbContext())
            {
                ctx.Shelfs.Add(shelf);      // Does not throw any error

                var addedEntities = ctx.ChangeTracker.Entries()
                    .Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                    .Count();
                var updatedEntities = ctx.ChangeTracker.Entries()
                    .Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
                    .Count();
                var unchagedEntities = ctx.ChangeTracker.Entries()
                    .Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Unchanged)
                    .Count();
                var detachedEntities = ctx.ChangeTracker.Entries()
                    .Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                    .Count();

                Console.WriteLine($"Added entities: {addedEntities}");
                Console.WriteLine($"Updated entities: {updatedEntities}");
                Console.WriteLine($"Unchaged entities: {unchagedEntities}");
                Console.WriteLine($"Detached entities: {detachedEntities}");
            }
        }
    }
}
