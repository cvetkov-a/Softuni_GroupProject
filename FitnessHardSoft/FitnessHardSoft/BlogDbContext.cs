namespace FitnessHardSoft
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogDbContext : DbContext
    {
        public BlogDbContext()
            : base("name=BlogDbContext")
        {
        }

        public virtual DbSet<ActivityLogs> ActivityLogs { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                 .HasMany(e => e.Posts)
                 .WithOptional(e => e.News)
                 .HasForeignKey(e => e.TitleID);
            
            modelBuilder.Entity<Users>()
                .HasMany(e => e.ActivityLogs)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Posts)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.AuthorID);
        }
    }
}
