using EFCore311_Issue19984Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore311_Issue19984Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adding authors");
            AddAuthors();

            Console.WriteLine("EFC Add Test");
            AddToEFCTest();

            Console.WriteLine("End");
            Console.Read();
        }

        public static void AddAuthors()
        {
            var author1 = new Author
            {
                FirstName = "Charles",
                LastName = "Dickens"
            };

            var author2 = new Author
            {
                FirstName = "Ernest",
                LastName = "Hemingway"
            };

            var author3 = new Author
            {
                FirstName = "José",
                LastName = "Saramago"
            };

            var authors = new List<Author>();
            authors.Add(author1);
            authors.Add(author2);
            authors.Add(author3);

            using (var ctx = new EFC.BooksDbContext())
            {
                if (ctx.Authors.Count() == 0)
                {
                    ctx.Authors.AddRange(authors);
                    ctx.SaveChanges();
                }
            }
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
                ctx.Shelfs.Add(shelf);      // throws error

                //  Error:
                // System.InvalidOperationException: 
                // 'The instance of entity type 'Author' cannot be tracked because another instance 
                // with the key value '{AuthorId: 2}' is already being tracked. 
                // When attaching existing entities, ensure that only one entity instance 
                // with a given key value is attached.'
            }
        }
    }
}
