namespace StudyCardsApi
{
    using Microsoft.EntityFrameworkCore;
    using StudyCardsApi.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }
    }

}
