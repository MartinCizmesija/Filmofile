using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmofile.Models {
    public partial class Movie {
        public Movie() {
            Nomination = new HashSet<Nomination>();
            Language_Movie = new HashSet<Language_movie>();
            Genre_Movie = new HashSet<Genre_movie>();
            SimilarRefrencedMovie = new HashSet<Similar>();
            SimilarRootMovie = new HashSet<Similar>();
            Comment = new HashSet<Comment>();
            User_Rating = new HashSet<User_rating>();
            Watchlist = new HashSet<Watchlist>();
            Favourite = new HashSet<Favourite>();
            Country_Movie = new HashSet<Country_movie>();
            Role_Movie = new HashSet<Role_movie>();
            Technician_Movie = new HashSet<Technician_movie>();
            Keyword_Movie = new HashSet<Keyword_movie>();
            Multimedia = new HashSet<Multimedia>();

        }

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public double? CriticsRating { get; set; }
        public int NumberOfCritics { get; set; }
        public double? UserRating { get; set; }
        public int NumberOfUsers { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Budget { get; set; }
        public int? Revenue { get; set; }

        public virtual ICollection<Nomination> Nomination { get; set; }
        public virtual ICollection<Language_movie> Language_Movie { get; set; }
        public virtual ICollection<Genre_movie> Genre_Movie { get; set; }
        public virtual ICollection<Similar> SimilarRefrencedMovie { get; set; }
        public virtual ICollection<Similar> SimilarRootMovie { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<User_rating> User_Rating { get; set; }
        public virtual ICollection<Watchlist> Watchlist { get; set; }
        public virtual ICollection<Favourite> Favourite { get; set; }
        public virtual ICollection<Country_movie> Country_Movie { get; set; }
        public virtual ICollection<Role_movie> Role_Movie { get; set; }
        public virtual ICollection<Technician_movie> Technician_Movie { get; set; }
        public virtual ICollection<Keyword_movie> Keyword_Movie { get; set; }
        public virtual ICollection<Multimedia> Multimedia { get; set; }

    }

    public enum UserRole
    {
        admin,
        User,
        critic
    }
}
