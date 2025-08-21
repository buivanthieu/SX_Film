using Microsoft.EntityFrameworkCore;
using WebBackend.Models;

namespace WebBackend.Datas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Define DbSets for your entities here
        // public DbSet<YourEntity> YourEntities { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<FilmActor> FilmActors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<SearchLog> SearchLogs { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<WatchHistory> WatchHistories { get; set; }
        public DbSet<Seri> Series { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<BookmarkActor> BookmarkActors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entity mappings here

            // Film
            modelBuilder.Entity<Film>()
                .HasDiscriminator<string>("FilmType")
                .HasValue<Movie>("Movie")
                .HasValue<Seri>("Series");
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Comments)
                .WithOne(c => c.Film)
                .HasForeignKey(c => c.FilmId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Ratings)
                .WithOne(r => r.Film)
                .HasForeignKey(r => r.FilmId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Reports)
                .WithOne(r => r.Film)
                .HasForeignKey(r => r.FilmId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Bookmarks)
                .WithOne(b => b.Film)
                .HasForeignKey(b => b.FilmId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Genres)
                .WithMany(g => g.Films)
                .UsingEntity(j => j.ToTable("FilmGenres"));
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Tags)
                .WithMany(t => t.Films)
                .UsingEntity(j => j.ToTable("FilmTags"));
            modelBuilder.Entity<Film>()
                .HasMany(f => f.ProductionCompanies)
                .WithMany(pc => pc.Films)
                .UsingEntity(j => j.ToTable("FilmProductionCompanies"));
            modelBuilder.Entity<Film>()
                .HasMany(f => f.FilmActors)
                .WithOne(fa => fa.Film)
                .HasForeignKey(fa => fa.FilmId)
                .OnDelete(DeleteBehavior.Cascade);

            // User

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Ratings)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reports)
                .WithOne(r => r.Reporter)
                .HasForeignKey(r => r.ReporterId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Bookmarks)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.BookmarkActors)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Notifications)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.SearchLogs)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.WatchHistories)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Series
            modelBuilder.Entity<Seri>()
                .HasMany(s => s.Seasons)
                .WithOne(se => se.Series)
                .HasForeignKey(se => se.SeriId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Season>()
                .HasMany(se => se.Episodes)
                .WithOne(e => e.Season)
                .HasForeignKey(e => e.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);
            // WatchHistory
            modelBuilder.Entity<WatchHistory>()
                .HasOne(wh => wh.User)
                .WithMany(u => u.WatchHistories)
                .HasForeignKey(wh => wh.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<WatchHistory>()
                .HasOne(wh => wh.Film)
                .WithMany(f => f.WatchHistories)
                .HasForeignKey(wh => wh.FilmId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FilmActor>()
                .HasKey(fa => new { fa.FilmId, fa.ActorId });

            modelBuilder.Entity<Actor>()
                .HasMany(a => a.FilmActors)
                .WithOne(fa => fa.Actor)
                .HasForeignKey(fa => fa.ActorId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Actor>()
                .HasMany(a => a.BookmarkActors)
                .WithOne(ba => ba.Actor)
                .HasForeignKey(ba => ba.ActorId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
    
}
