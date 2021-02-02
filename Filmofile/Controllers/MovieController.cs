using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmofile.Extensions;
using Filmofile.Models;
using Filmofile.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Rotativa.AspNetCore;

namespace Filmofile.Controllers
{
    public class MovieController : Controller {

        private readonly MovieDBContext context;
        private readonly AppSettings appData;

        public MovieController (MovieDBContext ctx, IOptionsSnapshot<AppSettings> options) {
            context = ctx;
            appData = options.Value;
        }

        //GET: Movie
        public IActionResult Index(string searchString, int page = 1, int sort = 1, bool ascending = true)
        {
            int pagesize = appData.PageSize;

            var query = context.Movie
                        .AsNoTracking();

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.MovieName.Contains(searchString));
            }

            int count = query.Count();
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                Sort = sort,
                Ascending = ascending,
                ItemsPerPage = pagesize,
                TotalItems = count
            };
            if (page > pagingInfo.TotalPages)
            {
                return RedirectToAction(nameof(Index), new { page = pagingInfo.TotalPages, sort = sort, ascending = ascending });
            }

            System.Linq.Expressions.Expression<Func<Movie, object>> orderSelector = null;
            switch (sort)
            {
                case 1:
                    orderSelector = m => m.MovieName;
                    break;
                case 2:
                    orderSelector = m => m.CriticsRating;
                    break;
                case 3:
                    orderSelector = m => m.NumberOfCritics;
                    break;
                case 4:
                    orderSelector = m => m.UserRating;
                    break;
                case 5:
                    orderSelector = m => m.NumberOfUsers;
                    break;
            }
            if (orderSelector != null)
            {
                query = ascending ?
                       query.OrderBy(orderSelector) :
                       query.OrderByDescending(orderSelector);
            }

            var movies = new List<MovieViewModel>();

            if (page != 0)
            {
                movies = query
                    .Select(m => new MovieViewModel
                    {
                        MovieId = m.MovieId,
                        MovieName = m.MovieName,
                        CriticsRating = Math.Round(m.CriticsRating.GetValueOrDefault(), 2),
                        NumberOfCritics = m.NumberOfCritics,
                        UserRating = Math.Round(m.UserRating.GetValueOrDefault(), 2),
                        NumberOfUsers = m.NumberOfUsers
                    })
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize)
                    .ToList();
            }


            var model = new MoviesViewModel
            {
                Movies = movies,
                PagingInfo = pagingInfo
            };

            return View(model);
        }


        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           if (id == null)
            {
                return NotFound();
            }

            var movie = await context.Movie
                .FirstOrDefaultAsync(a => a.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            RatingDropdownList();
            MovieDetailsViewModel movieDetailsViewModel = fillMovieDetailsViewModel(movie, id);
            
            return View(movieDetailsViewModel);
        }

        // GET: Movie/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    movie.NumberOfCritics = 0;
                    movie.NumberOfUsers = 0;

                    context.Add(movie);
                    context.SaveChanges();

                    TempData[Constants.Message] = $"Movie added.";
                    TempData[Constants.ErrorOccurred] = false;
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception exc)
                {
                    ModelState.AddModelError(string.Empty, exc.CompleteExceptionMessage());
                    return View(movie);
                }
            }
            else
            {
                return View(movie);
            }
        }

        // GET: Movie/Edit
        [HttpGet]
        public IActionResult Edit(int id, int page = 1, int sort = 1, bool ascending = true)
        {
            var movie = context.Movie.AsNoTracking().Where(d => d.MovieId == id).SingleOrDefault();
            if (movie == null)
            {
                return NotFound("There is no movie with id " + id);
            }
            else
            {
                ViewBag.Page = page;
                ViewBag.Sort = sort;
                ViewBag.Ascending = ascending;
                return View(movie);
            }
        }

        // POST: Movie/Edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, int page = 1, int sort = 1, bool ascending = true)
        {

            try
            {
                Movie movie = await context.Movie
                                  .Where(d => d.MovieId == id)
                                  .FirstOrDefaultAsync();
                if (movie == null)
                {
                    return NotFound("Wrong Id: " + id);
                }

                if (await TryUpdateModelAsync(movie, "",
                    d => d.MovieId, d => d.MovieName, d => d.ReleaseDate, d => d.Budget, d => d.Revenue
                ))
                {
                    ViewBag.Page = page;
                    ViewBag.Sort = sort;
                    ViewBag.Ascending = ascending;
                    try
                    {
                        await context.SaveChangesAsync();
                        TempData[Constants.Message] = "Movie edited.";
                        TempData[Constants.ErrorOccurred] = false;
                        return RedirectToAction(nameof(Index), new { page, sort, ascending });
                    }
                    catch (Exception exc)
                    {
                        ModelState.AddModelError(string.Empty, exc.CompleteExceptionMessage());
                        return View(movie);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Unable to edit");
                    return View(movie);
                }
            }
            catch (Exception exc)
            {
                TempData[Constants.Message] = exc.CompleteExceptionMessage();
                TempData[Constants.ErrorOccurred] = true;
                return RedirectToAction(nameof(Edit), id);
            }
        }

        //Movie/EditDetailsNav
        [HttpGet]
        public IActionResult EditDetailsNav(int id)
        {
            var movie = context.Movie.AsNoTracking().Where(d => d.MovieId == id).SingleOrDefault();
            if (movie == null)
            {
                return NotFound("There is no movie with id " + id);
            }
            else
            {
                return View(movie);
            }
        }

        // GET: Movie/EditDescription
        [HttpGet]
        public IActionResult EditDescription(int id, int page = 1, int sort = 1, bool ascending = true) {
            var movie = context.Movie.AsNoTracking().Where(d => d.MovieId == id).SingleOrDefault();
            if (movie == null)
            {
                return NotFound("There is no movie with id " + id);
            }
            else
            {
                EditDescriptionViewModel editDescriptionViewModel = fillEditDescpritionViewModel(movie, id);

                PrepareDropDownLists(id);
                ViewBag.Page = page;
                ViewBag.Sort = sort;
                ViewBag.Ascending = ascending;
                return View(editDescriptionViewModel);
            }
        }

        // Post: Movie/EditDescription
        [HttpPost, ActionName("EditDescription")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDescpription(Movie movie, int? genreId, int? keywordId, int? languageId, int? countryId)
        {
            if (movie == null)
            {
                return NotFound("Unable to update Id " + movie.MovieId);
            }
            else
            {
                EditDescriptionViewModel editDescriptionViewModel = new EditDescriptionViewModel();
                editDescriptionViewModel.Movie = movie;

                if (genreId.HasValue) {
                    Genre_movie genre_movie = new Genre_movie();
                    genre_movie.GenreId = genreId.Value;
                    genre_movie.MovieId = movie.MovieId;
                    context.Add(genre_movie);
                }

                if (keywordId.HasValue)
                {
                    Keyword_movie keyword_movie = new Keyword_movie();
                    keyword_movie.KeywordId = keywordId.Value;
                    keyword_movie.MovieId = movie.MovieId;
                    context.Add(keyword_movie);
                }

                if (languageId.HasValue)
                {
                    Language_movie language_movie = new Language_movie();
                    language_movie.LanguageId = languageId.Value;
                    language_movie.MovieId = movie.MovieId;
                    context.Add(language_movie);
                }

                if (countryId.HasValue)
                {
                    Country_movie country_movie = new Country_movie();
                    country_movie.CountryId = countryId.Value;
                    country_movie.MovieId = movie.MovieId;
                    context.Add(country_movie);
                }

                try
                {
                    await context.SaveChangesAsync();
                    TempData[Constants.Message] = "Data updated.";
                    TempData[Constants.ErrorOccurred] = false;
                    return RedirectToAction("Details", "Movie", new { id = movie.MovieId });
                }
                catch (Exception exc)
                {
                    ModelState.AddModelError(string.Empty, exc.CompleteExceptionMessage());
                    return View(editDescriptionViewModel);
                }
            }
        }

        // Post: Movie/EditDescription
        public IActionResult RateMovie(int id, int userRating) {
            Movie movie = context.Movie.Where(i => i.MovieId == id).FirstOrDefault();

            int numberOfUsers = movie.NumberOfUsers;
            if (numberOfUsers == 0)
            {
                movie.NumberOfUsers = 1;
                movie.UserRating = userRating;
            }
            else {
                double totalCount = movie.UserRating.GetValueOrDefault() * movie.NumberOfUsers;
                movie.NumberOfUsers += 1;
                movie.UserRating = (totalCount + userRating) / movie.NumberOfUsers;
            }

            context.Update(movie);
            context.SaveChanges();

            return RedirectToAction("Details", "Movie", new { id });
        }

        public ActionResult DetailsPDF(int id)
        {
            Movie movie = context.Movie.FirstOrDefault(i => i.MovieId == id);
            MovieDetailsViewModel model = fillMovieDetailsViewModel(movie, id);
            return new ViewAsPdf(model);
        }

        private EditDescriptionViewModel fillEditDescpritionViewModel(Movie movie, int? id)
        {
            EditDescriptionViewModel editDescriptionViewModel = new EditDescriptionViewModel();
            editDescriptionViewModel.Movie = movie;


            return editDescriptionViewModel;
        }
        
        private MovieDetailsViewModel fillMovieDetailsViewModel(Movie movie, int? id)
        {
            MovieDetailsViewModel movieDetailsViewModel = new MovieDetailsViewModel();
            movieDetailsViewModel.Movie = movie;
            //rounding double numbers so only 2 decimaly will show
            movieDetailsViewModel.Movie.UserRating = Math.Round(movieDetailsViewModel.Movie.UserRating.GetValueOrDefault(), 2);
            movieDetailsViewModel.Movie.CriticsRating = Math.Round(movieDetailsViewModel.Movie.CriticsRating.GetValueOrDefault(), 2);

            movieDetailsViewModel.Comments = context.Comment
                .Select(m => new CommentViewModel
                {
                    CommentId = m.CommentId,
                    MovieId = m.MovieId,
                    UserName = m.UserIdNavigation.Username,
                    Text = m.Text
                })
                .Where(c => c.MovieId == id).ToList();

            movieDetailsViewModel.Genres = context.Genre
                .Where(c => c.Genre_Movie.Any(i => i.MovieId == id))
                .ToList();

            movieDetailsViewModel.Keywords = context.Keyword
                .Where(c => c.Keyword_Movie.Any(i => i.MovieId == id))
                .ToList();

            movieDetailsViewModel.Language = context.Language
                .Where(c => c.Language_Movie.Any(i => i.MovieId == id))
                .ToList();

            movieDetailsViewModel.Country = context.Country
                .Where(c => c.Country_Movie.Any(i => i.MovieId == id))
                .ToList();

            movieDetailsViewModel.Roles = context.Role
                .Where(c => c.Role_Movie.Any(i => i.MovieId == id))
                .Select(m => new RoleViewModel
                {
                    RoleId = m.RoleId,
                    CharacterName = m.CharacterName,
                    CharacterSurname = m.CharacterSurname,
                    PersonName = m.PersonIdNavigation.PersonName,
                    PersonSurname = m.PersonIdNavigation.PersonSurname,
                    RoleDescription = m.RoleDescription
                })
                .ToList();

            movieDetailsViewModel.Technicians = context.Technician
                .Where(c => c.Technician_Movie.Any(i => i.MovieId == id))
                .Select(m => new TechnitianViewModel
                {
                    TechnicianId = m.TechnicianId,
                    JobBehindSet = m.JobBehindSet,
                    PersonName = m.PersonIdNavigation.PersonName,
                    PersonSurname = m.PersonIdNavigation.PersonSurname
                })
                .ToList();

            movieDetailsViewModel.Multimedia = context.Multimedia
                .Select(m => new MultimediaViewModel {
                    MultimediaId= m.MultimediaId,
                    MovieId= m.MovieId,
                    MultimediaLink= m.MultimediaLink
                })
                .Where(c => c.MovieId == id).ToList();

            return movieDetailsViewModel;
        }

        private void RatingDropdownList() {
            var rating = new List<int> { 1, 2, 3, 4, 5 };

            ViewBag.Rating = new SelectList(rating);
        }

        private void PrepareDropDownLists(int id)
        {
            var genres = context.Genre
                .Where(c => c.Genre_Movie.All(i => i.MovieId != id))
                .OrderBy(g => g.GenreId)
                .Select(g => new { g.GenreId, g.GenreName})
                .ToList();

            ViewBag.Genres = new SelectList(genres, nameof(Genre.GenreId), nameof(Genre.GenreName));

            var keyword = context.Keyword
                .Where(c => c.Keyword_Movie.All(i => i.MovieId != id))
                .OrderBy(g => g.KeywordId)
                .Select(g => new { g.KeywordId, g.KeywordName })
                .ToList();

            ViewBag.Keywords = new SelectList(keyword, nameof(Keyword.KeywordId), nameof(Keyword.KeywordName));

            var language = context.Language
                .Where(c => c.Language_Movie.All(i => i.MovieId != id))
                .OrderBy(g => g.LanguageId)
                .Select(g => new { g.LanguageId, g.LanguageName })
                .ToList();

            ViewBag.Languages = new SelectList(language, nameof(Language.LanguageId), nameof(Language.LanguageName));

            var country = context.Country
                .Where(c => c.Country_Movie.All(i => i.MovieId != id))
                .OrderBy(g => g.CountryId)
                .Select(g => new { g.CountryId, g.CountryName })
                .ToList();

            ViewBag.Countries = new SelectList(country, nameof(Country.CountryId), nameof(Country.CountryName));
        }

    }
}
