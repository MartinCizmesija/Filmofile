using Microsoft.EntityFrameworkCore;

namespace Filmofile.Models
{
    public partial class MovieDBContext : DbContext
    {

        public MovieDBContext () { 
        }

        public MovieDBContext (DbContextOptions<MovieDBContext> options) : base (options) {
        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Country_movie> Country_Movie { get; set; }
        public virtual DbSet<Favourite> Favourite { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Genre_movie> Genre_Movie { get; set; }
        public virtual DbSet<Keyword> Keyword { get; set; }
        public virtual DbSet<Keyword_movie> Keyword_Movie { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Language_movie> Language_Movie { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Multimedia> Multimedia { get; set; }
        public virtual DbSet<Nomination> Nomination { get; set; }
        public virtual DbSet<Person> person { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Role_movie> Role_Movie { get; set; }
        public virtual DbSet<Similar> Similar { get; set; }
        public virtual DbSet<Technician> Technician { get; set; }
        public virtual DbSet<Technician_movie> Technician_Movie { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<User_rating> User_Rating { get; set; }
        public virtual DbSet<Watchlist> Watchlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=MovieDB;Trusted_Connection=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.HasOne(a => a.MovieIdNavigation)
                    .WithMany(b => b.Comment)
                    .HasForeignKey(c => c.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Movie");

                entity.HasOne(a => a.UserIdNavigation)
                    .WithMany(b => b.Comment)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");

                entity.Property(e => e.Text)
                    .IsRequired();
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__CountryId");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Country_movie>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.HasKey(e => e.MovieId);

                entity.HasOne(a => a.CountryIdNavigation)
                    .WithMany(b => b.Country_Movie)
                    .HasForeignKey(c => c.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_movie_Country");

                entity.HasOne(a => a.MovieIdNavigation)
                    .WithMany(b => b.Country_Movie)
                    .HasForeignKey(c => c.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_movie_Movie");
            });

            modelBuilder.Entity<Favourite>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasKey(e => e.MovieId);

                entity.HasOne(a => a.MovieIdNavigation)
                    .WithMany(b => b.Favourite)
                    .HasForeignKey(c => c.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favourite_Movie");

                entity.HasOne(a => a.UserIdNavigation)
                    .WithMany(b => b.Favourite)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favourite_User");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                    .HasName("PK_GenreId");

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Genre_movie>(entity =>
            {
                entity.HasKey(e => e.GenreId);

                entity.HasKey(e => e.MovieId);

                entity.HasOne(a => a.GenreIdNavigation)
                    .WithMany(b => b.Genre_Movie)
                    .HasForeignKey(c => c.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genre_movie_Genre");

                entity.HasOne(a => a.MovieIdNavigation)
                    .WithMany(b => b.Genre_Movie)
                    .HasForeignKey(c => c.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_movie_Movie");
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasKey(e => e.KeywordId)
                    .HasName("PK_KeywordId");

                entity.Property(e => e.KeywordName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Keyword_movie>(entity =>
            {
                entity.HasKey(e => e.KeywordId);

                entity.HasKey(e => e.MovieId);

                entity.HasOne(a => a.KeywordIdNavigation)
                    .WithMany(b => b.Keyword_Movie)
                    .HasForeignKey(c => c.KeywordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Keyword_movie_Keyword");

                entity.HasOne(a => a.MovieIdNavigation)
                    .WithMany(b => b.Keyword_Movie)
                    .HasForeignKey(c => c.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Keyword_movie_Movie");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.LanguageId)
                    .HasName("PK_LanguageId");

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Language_movie>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.HasKey(e => e.MovieId);

                entity.HasOne(a => a.LanguageIdNavigation)
                    .WithMany(b => b.Language_Movie)
                    .HasForeignKey(c => c.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Language_movie_Language");

                entity.HasOne(a => a.MovieIdNavigation)
                    .WithMany(b => b.Language_Movie)
                    .HasForeignKey(c => c.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Language_movie_Movie");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CriticsRating);

                entity.Property(e => e.NumberOfCritics)
                    .IsRequired();

                entity.Property(e => e.UserRating);

                entity.Property(e => e.NumberOfUsers)
                    .IsRequired();

                entity.Property(e => e.ReleaseDate);

                entity.Property(e => e.Budget);

                entity.Property(e => e.Revenue);
            });

            modelBuilder.Entity<Multimedia>(entity =>
            {
                entity.HasKey(e => e.MultimediaId);

                entity.Property(e => e.MultimediaLink)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.HasOne(a => a.MovieIdNavigation)
                    .WithMany(b => b.Multimedia)
                    .HasForeignKey(c => c.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Multimedia_Movie");
            });

            modelBuilder.Entity<Nomination>(entity =>
            {
                entity.HasKey(e => e.NominationId);

                entity.Property(e => e.NominationName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);


                entity.Property(e => e.NominationCategory)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.NominationYear)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DidItWin)
                    .HasColumnName("Did it Win");

                entity.HasOne(a => a.MovieIdNavigation)
                    .WithMany(b => b.Nomination)
                    .HasForeignKey(c => c.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nomination_Movie");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.PersonName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PersonSurname)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Birth)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Biography);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.CharacterName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CharacterSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(a => a.PersonIdNavigation)
                    .WithMany(b => b.Role)
                    .HasForeignKey(c => c.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Person");

                entity.Property(e => e.RoleDescription);
            });

            modelBuilder.Entity<Role_movie>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.HasKey(e => e.MovieId);

                entity.HasOne(a => a.RoleIdNavigation)
                    .WithMany(b => b.Role_Movie)
                    .HasForeignKey(c => c.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_movie_Role");

                entity.HasOne(a => a.MovieIdNavigation)
                    .WithMany(b => b.Role_Movie)
                    .HasForeignKey(c => c.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_movie_Movie");
            });

            modelBuilder.Entity<Similar>(entity =>
            {
                entity.HasKey(e => e.RootMovie);

                entity.HasKey(e => e.RefrencedMovie);

                entity.HasOne(a => a.RootIdNavigation)
                    .WithMany(b => b.SimilarRootMovie)
                    .HasForeignKey(c => c.RootMovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Similar_RootMovie");

                entity.HasOne(a => a.RefrencedIdNavigation)
                    .WithMany(b => b.SimilarRefrencedMovie)
                    .HasForeignKey(c => c.RefrencedMovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Similar_RefrencedMovie");
            });

            modelBuilder.Entity<Technician>(entity =>
            {
                entity.HasKey(e => e.TechnicianId)
                    .HasName("PK_TechnicianId");

                entity.Property(e => e.JobBehindSet)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(a => a.PersonIdNavigation)
                    .WithMany(b => b.Technician)
                    .HasForeignKey(c => c.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Technician_Person");
            });

            modelBuilder.Entity<Technician_movie>(entity =>
            {
                entity.HasKey(e => e.TechnicianId);

                entity.HasKey(e => e.MovieId);

                entity.HasOne(a => a.TechnicianIdNavigation)
                    .WithMany(b => b.Technician_Movie)
                    .HasForeignKey(c => c.TechnicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Technician_movie_Technician");

                entity.HasOne(a => a.MovieIdNavigation)
                    .WithMany(b => b.Technician_Movie)
                    .HasForeignKey(c => c.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Technician_movie_Movie");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Username)
                    .HasColumnName("Username")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasColumnName("Password")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mail)
                    .HasColumnName("Mail")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserRole)
                    .HasColumnName("User role")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User_rating>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasKey(e => e.MovieId);

                entity.HasOne(a => a.UserIdNavigation)
                    .WithMany(b => b.UserRating)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_rating_User");

                entity.HasOne(a => a.MovieIdNavigation)
                    .WithMany(b => b.User_Rating)
                    .HasForeignKey(c => c.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_rating_Movie");
            });

            modelBuilder.Entity<Watchlist>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasKey(e => e.MovieId);

                entity.HasOne(a => a.MovieIdNavigation)
                    .WithMany(b => b.Watchlist)
                    .HasForeignKey(c => c.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Watchlist_Movie");

                entity.HasOne(a => a.UserIdNavigation)
                    .WithMany(b => b.Watchlist)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Watchlist_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
