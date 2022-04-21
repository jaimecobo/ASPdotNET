#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L08HandsOn.Models;

namespace L08HandsOn.Controllers
{
    public class WatchedMoviesController : Controller
    {
        private readonly WatchedMoviesContext _context;

        public WatchedMoviesController(WatchedMoviesContext context)
        {
            _context = context;
        }

        // GET: WatchedMovies
        public async Task<IActionResult> Index()
        {
            return View(await _context.WatchedMovies.ToListAsync());
        }

        // GET: WatchedMovies/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchedMovie = await _context.WatchedMovies
                .FirstOrDefaultAsync(m => m.WatchedMovieId == id);
            if (watchedMovie == null)
            {
                return NotFound();
            }

            return View(watchedMovie);
        }

        // GET: WatchedMovies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WatchedMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WatchedMovieId,userId,MovieId,StartTime")] WatchedMovie watchedMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(watchedMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(watchedMovie);
        }

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
                return NotFound();
            }
            return View(watchedMovie);
        }

        // POST: WatchedMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("WatchedMovieId,userId,MovieId,StartTime")] WatchedMovie watchedMovie)
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
            return View(watchedMovie);
        }

        // GET: WatchedMovies/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchedMovie = await _context.WatchedMovies
                .FirstOrDefaultAsync(m => m.WatchedMovieId == id);
            if (watchedMovie == null)
            {
                return NotFound();
            }

            return View(watchedMovie);
        }

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
