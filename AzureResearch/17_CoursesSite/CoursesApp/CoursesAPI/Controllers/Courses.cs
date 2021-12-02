using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class Courses : ControllerBase
{


    [HttpGet]
    public ActionResult Get()
    {
        using (var context = new LibraryContext())
        {
            // Creates the database if not exists
            context.Database.EnsureCreated();

            // Adds a publisher
            var publisher = new Publisher
            {
                Name = "Mariner Books"
            };
            context.Publisher.Add(publisher);

            // Adds some books
            context.Book.Add(new Book
            {
                ISBN = "978-0544003415",
                Title = "The Lord of the Rings",
                Author = "J.R.R. Tolkien",
                Language = "English",
                Pages = 1216,
                Publisher = publisher
            });
            context.Book.Add(new Book
            {
                ISBN = "978-0547247762",
                Title = "The Sealed Letter",
                Author = "Emma Donoghue",
                Language = "English",
                Pages = 416,
                Publisher = publisher
            });

            // Saves changes
            context.SaveChanges();
        }
        return Ok();
    }
}

public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Language { get; set; }
    public int Pages { get; set; }
    public virtual Publisher Publisher { get; set; }
}

public class Publisher
{
    public int ID { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}

public class LibraryContext : DbContext
{
    public DbSet<Book> Book { get; set; }

    public DbSet<Publisher> Publisher { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.ISBN);
            entity.Property(e => e.Title).IsRequired();
            entity.HasOne(d => d.Publisher)
              .WithMany(p => p.Books);
        });
    }
}