using Microsoft.EntityFrameworkCore;
using MyPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Infrastructure.Persistence
{
    public class AppDbContext :DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemTemplate> ItemTemplates { get; set; }
        public DbSet<UserItemMapper> UserItemMappers { get; set; }
        public DbSet<ItemCompletion> ItemCompletions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ItemTag> ItemTags { get; set; }
        public DbSet<HabitStat> HabitStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // BU SATIR ÇOK ÖNEMLİ:
            // "Bu projenin (Assembly) içindeki tüm IEntityTypeConfiguration'ları bul ve yükle."
            //Yani Tam  olarak  bütün configurationları uyqular 
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }
}
