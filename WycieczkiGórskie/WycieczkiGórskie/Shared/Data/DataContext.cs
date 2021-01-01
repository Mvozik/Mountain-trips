using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WycieczkiGórskie.Shared.Entities;

namespace WycieczkiGórskie.Shared.Data
{
    public class DataContext : IdentityDbContext<User,IdentityRole,string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourPhoto> TourPhotos { get; set; }
        public DbSet<TourVideo> TourVideo { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tour>()
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .IsRequired();

            builder.Entity<TourPhoto>()
                .HasOne(x => x.Tour)
                .WithMany(x=>x.tourPhotos)
                .HasForeignKey(x => x.TourId)
                .IsRequired();
            builder.Entity<TourVideo>()
                .HasOne(x => x.Tour)
                .WithMany(x => x.TourVideos)
                .HasForeignKey(x => x.TourId);

            base.OnModelCreating(builder);
        }

    }
}
