using Microsoft.EntityFrameworkCore;
using Week12AssignmentsBlazorRepetition;

public class ItemDb: DbContext
{
    public DbSet<Item> Items { get; set; }

    public ItemDb(DbContextOptions<ItemDb> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed the database with three items
        modelBuilder.Entity<Item>().HasData(
            new Item { Id = 1, Name = "Seeded Item 1" },
            new Item { Id = 2, Name = "Seeded Item 2" },
            new Item { Id = 3, Name = "Seeded Item 3" }
        );
    }

}