using System;
using System.Linq;
using Filmofile.Extensions;
using Filmofile.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace Filmofile.Controllers
{
    public class CommentController : Controller
    {
        private readonly MovieDBContext context;
        //private readonly AppSettings appData;

        public CommentController(MovieDBContext ctx, IOptionsSnapshot<AppSettings> options)
        {
            context = ctx;
        }


        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PrepareDropDownLists(id);
            Comment comment = new Comment
            {
                MovieId = id
            };

            return View(comment);
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            try
            {

                context.Add(comment);
                context.SaveChanges();

                TempData[Constants.Message] = $"Sucessfuly commented.";
                TempData[Constants.ErrorOccurred] = false;
                return RedirectToAction("Details", "Movie", new { id= comment.MovieId});
            }
            catch (Exception exc)
            {
                ModelState.AddModelError(string.Empty, exc.CompleteExceptionMessage());
                return View(comment);
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private void PrepareDropDownLists(int id)
        {
            var movie = context.Movie.FirstOrDefault(i => i.MovieId == id);

            var users = context.User
                .Where(c => c.Comment.All(i => i.MovieId != id))
                .OrderBy(g => g.UserId)
                .Select(g => new { g.UserId, g.Username })
                .ToList();

            ViewBag.Username = new SelectList(users, nameof(Models.User.UserId), nameof(Models.User.Username));

            ViewBag.MovieName = movie.MovieName;
        }



    }
}