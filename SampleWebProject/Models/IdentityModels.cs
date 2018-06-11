using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SampleWebProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<AuthorPublishers> AuthorPublishers { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithRequired(b => b.Author);
            modelBuilder.Entity<Author>()
                .HasMany(a => a.AuthorPublishers)
                .WithRequired(ap => ap.Author);

            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.AuthorPublishers)
                .WithRequired(ap => ap.Publisher);
            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.BooksPublished)
                .WithRequired(b => b.Publisher);

            base.OnModelCreating(modelBuilder);
        }
    }
}