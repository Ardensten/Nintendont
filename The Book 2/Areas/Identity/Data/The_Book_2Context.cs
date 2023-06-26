using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using The_Book_2.Areas.Identity.Data;
using The_Book_2.Models;

namespace The_Book_2.Data;

public class The_Book_2Context : IdentityDbContext<The_Book_2User>
{
    public The_Book_2Context(DbContextOptions<The_Book_2Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<The_Book_2.Models.Forum> Forum { get; set; } = default!;

    public DbSet<The_Book_2.Models.Comment> Comment { get; set; } = default!;

    public DbSet<The_Book_2.Models.Message> Message { get; set; } = default!;

    public DbSet<The_Book_2.Models.Post> Post { get; set; } = default!;

    public DbSet<The_Book_2.Models.Topic> Topic { get; set; } = default!;
}
