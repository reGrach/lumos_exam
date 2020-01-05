using Microsoft.EntityFrameworkCore;

namespace LumosService.DAL
{
    public class LumosContext : DbContext
    {
        public LumosContext(DbContextOptions<LumosContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Filename=./App_Data/LumosDb.db");
        //}

        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
