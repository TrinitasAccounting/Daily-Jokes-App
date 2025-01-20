

using Microsoft.EntityFrameworkCore;


namespace DailyJokesApp.Models
{
    public partial class SampleDBContext : DbContext
    {
        public SampleDBContext(DbContextOptions
            <SampleDBContext> options) : base(options)
        {
        }
        //The name of the table "Jokes" needs to match the name of our models table
        public virtual DbSet<Jokes> Jokes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jokes>(entity =>
            {
                //We are putting in what column in the table is the key column
                entity.HasKey(k => k.JokeId);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
