using ExamMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;

namespace ExamMVC.Context
{
    public class ExamContext : IdentityDbContext
    {
        public ExamContext(DbContextOptions<ExamContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Setting>().HasData(
    new Setting
    {
        Id=1,
        Adress="Ayna Sultanova 34",
        Email="Azmiu@gmail.com",
        Mobile="+9940511112233",
        Web="Azmiu.edu.az"


    });
            base.OnModelCreating(builder);
        }
    }
}
