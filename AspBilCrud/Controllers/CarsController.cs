using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspBilCrud.Models;
using AutofokusContracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspBilCrud.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            // Hent data
            var carsDtos = await _carService.GetCarsAsync().ConfigureAwait(false);
            return View(Mapper.Map(carsDtos));
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var car = await _carService.GetCarAsync(id.Value).ConfigureAwait(false);

            if (car == null) return NotFound();

            return View(Mapper.Map(car));
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View(new CarViewModel
            {
                Model = "Galaxy",
                Brand = "Ford",
                Color = "Sort",
                Billede = " "

            });
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Brand,Model,Color,Billede")] CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                await _carService.AddAsync(Mapper.Map(car)).ConfigureAwait(false);

                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var car = await _carService.GetCarAsync(id.Value).ConfigureAwait(false);
            if (car == null) return NotFound();
            return View(Mapper.Map(car));
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Brand,Model,Color")] CarViewModel car)
        {
            if (id != car.ID) return NotFound();

            if (ModelState.IsValid)
            {
                await _carService.UpdateAsync(id, Mapper.Map(car)).ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }


        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _carService.GetCarAsync(id.Value).ConfigureAwait(false);
            if (movie == null) return NotFound();

            return View(Mapper.Map(movie));
        }

        //POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _carService.RemoveAsync(id).ConfigureAwait(false);

            return RedirectToAction(nameof(Index));

        }


    }
}