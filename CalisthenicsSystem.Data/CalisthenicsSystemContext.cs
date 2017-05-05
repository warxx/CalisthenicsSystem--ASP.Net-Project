using System.Data.Entity;
using CalisthenicsSystem.Models.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CalisthenicsSystem.Data
{

    public class CalisthenicsSystemContext : IdentityDbContext<ApplicationUser>
    {
        
        public CalisthenicsSystemContext()
            : base("CalisthenicsSystemContext", throwIfV1Schema: false)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Message> Messages { get; set; }

        public static CalisthenicsSystemContext Create()
        {
            return new CalisthenicsSystemContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(f => f.Followers)
                .WithMany(f => f.Following)
                .Map(f => f.ToTable("Follows")
                    .MapLeftKey("UserId")
                    .MapRightKey("FollowerId"));

            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}