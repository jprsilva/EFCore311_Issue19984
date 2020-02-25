using EFCore311_Issue19984Test.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore311_Issue19984Test.EFC
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Shelf> Shelfs { get; set; }
        public DbSet<ShelfBook> ShelfBooks { get; set; }

        public BooksDbContext()
            : base()
        {
            //  Detaching an entity results in related entities being deleted
            //  https://github.com/dotnet/efcore/issues/18982
            base.ChangeTracker.CascadeDeleteTiming = CascadeTiming.OnSaveChanges;
            base.ChangeTracker.DeleteOrphansTiming = CascadeTiming.OnSaveChanges;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  Connection
            optionsBuilder.UseSqlServer("server=.;database=BooksDb;trusted_connection=true;");

            //  Logging
            optionsBuilder.UseLoggerFactory(LoggingFactory.LoggerFactory)
                .EnableSensitiveDataLogging();
        }
    }
}
