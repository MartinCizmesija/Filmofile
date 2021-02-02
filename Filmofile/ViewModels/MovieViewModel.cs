using System;

namespace Filmofile.ViewModels
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public double? CriticsRating { get; set; }
        public int NumberOfCritics { get; set; }
        public double? UserRating { get; set; }
        public int NumberOfUsers { get; set; }


        public DateTime? ReleaseDate { get; set; }
        public int? Budget { get; set; }
        public int? Revenue { get; set; }

    }
}