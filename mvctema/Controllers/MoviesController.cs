using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvctema.Data;
using mvctema.Models;

namespace mvctema.Controllers
{
    public class MoviesController : Controller
    {

        static List<Movies> listamovies = new List<Movies>()
        {
            new Movies() { ID = Guid.NewGuid(), Name = "Movie 1", Year = 2020, Lenght = "2 ore" },
            new Movies() { ID = Guid.NewGuid(), Name = "Movie 1", Year = 2020, Lenght = "2 ore" },
            new Movies() { ID = Guid.NewGuid(), Name = "Movie 1", Year = 2020, Lenght = "2 ore" },
            new Movies() { ID = Guid.NewGuid(), Name = "Movie 1", Year = 2020, Lenght = "2 ore" },
            new Movies() { ID = Guid.NewGuid(), Name = "Movie 1", Year = 2020, Lenght = "2 ore" },
        };
        private readonly mvctemaContext _context;

        public MoviesController(mvctemaContext context)
        {
            _context = context;
        }

        // GET: Movies
        public IActionResult Index()
        {
            return View(listamovies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,Year,Lenght")] Movies movies)
        {
            if (ModelState.IsValid)
            {
                movies.ID = Guid.NewGuid();

                listamovies.Add(movies);

                return RedirectToAction(nameof(Index));
            }
            return View(movies);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = listamovies.FirstOrDefault(x => x.ID == id);
            if (movies == null)
            {
                return NotFound();
            }
            return View(movies);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,Year,Lenght")] Movies movies)
        {
            if (id != movies.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentMovie = listamovies.FirstOrDefault(x => x.ID == id);
                currentMovie.Name = movies.Name;
                currentMovie.Year = movies.Year;
                currentMovie.Lenght = movies.Lenght;
                return RedirectToAction(nameof(Index)); 
            }
            return View(movies);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = listamovies.Find(x => x.ID == id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var movies = listamovies.Find(x => x.ID == id);
            listamovies.Remove(movies);
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesExists(Guid id)
        {
            return _context.Movies.Any(e => e.ID == id);
        }
    }
}
