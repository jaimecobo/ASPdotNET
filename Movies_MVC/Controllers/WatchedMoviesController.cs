#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L08HandsOnASPNetDB.Models;
using Microsoft.AspNetCore.Authorization;

namespace L08HandsOnASPNetDB.Controllers
{
    [Authorize]
    public class WatchedMoviesController : Controller
    {
        private readonly MoviesContext _context;

        public WatchedMoviesController(MoviesContext context)
        {
            _context = context;
        }

        // GET: WatchedMovies
        public async Task<IActionResult> Index()
        {
            //var moviesContext = _context.WatchedMovies.Include(w => w.Movie);
            //return View(await moviesContext.ToListAsync());
            List<WatchedMovie> Data;
            if (User.Identity.Name == "admin@cobo.live")
            {
                Data = await _context.WatchedMovies.Include("Movie").ToListAsync();
            }
            else
            {
                Data = await _context.WatchedMovies.Where(m => m.UserId == User.Identity.Name).Include("Movie").ToListAsync();
            }
            return View(Data);
        }


        [Authorize(Policy = "RequireAdmin")]
        // GET: WatchedMovies/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchedMovie = await _context.WatchedMovies
                .Include(w => w.Movie)
                .FirstOrDefaultAsync(m => m.WatchedMovieId == id);
            if (watchedMovie == null)
            {
                return NotFound();
            }

            return View(watchedMovie);
        }


        [Authorize(Policy = "RequireAdmin")]
        // GET: WatchedMovies/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId");
            return View();
        }


        [Authorize(Policy = "RequireAdmin")]
        // POST: WatchedMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WatchedMovieId,UserId,MovieId,StartTime")] WatchedMovie watchedMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(watchedMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId", watchedMovie.MovieId);
            return View(watchedMovie);
        }


        [Authorize(Policy = "RequireAdmin")]
        // GET: WatchedMovies/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchedMovie = await _context.WatchedMovies.FindAsync(id);
            if (watchedMovie == null)
            {
                return NotFound($"Movie number {id} Not Found");
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId", watchedMovie.MovieId);
            return View(watchedMovie);
        }


        [Authorize(Policy = "RequireAdmin")]
        // POST: WatchedMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("WatchedMovieId,UserId,MovieId,StartTime")] WatchedMovie watchedMovie)
        {
            if (id != watchedMovie.WatchedMovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(watchedMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WatchedMovieExists(watchedMovie.WatchedMovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId", watchedMovie.MovieId);
            return View(watchedMovie);
        }


        [Authorize(Policy = "RequireAdmin")]
        // GET: WatchedMovies/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchedMovie = await _context.WatchedMovies
                .Include(w => w.Movie)
                .FirstOrDefaultAsync(m => m.WatchedMovieId == id);
            if (watchedMovie == null)
            {
                return NotFound();
            }

            return View(watchedMovie);
        }


        [Authorize(Policy = "RequireAdmin")]
        // POST: WatchedMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var watchedMovie = await _context.WatchedMovies.FindAsync(id);
            _context.WatchedMovies.Remove(watchedMovie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WatchedMovieExists(long id)
        {
            return _context.WatchedMovies.Any(e => e.WatchedMovieId == id);
        }
    }
}
