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

            try
            {
                var car = await _carService.GetCarAsync(id.Value).ConfigureAwait(false);

                if (car == null) return NotFound();

                return View(Mapper.Map(car));
            }
            catch (Exception)
            { //Laver fejlmeddelse
                TempData["CarCantBeFound"] = "Bilen findes ikke længere.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View(new CarViewModel
            {
                Model = " ",
                Brand = " ",
                Color = " ",
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

            try
            {
                var car = await _carService.GetCarAsync(id.Value).ConfigureAwait(false);
                if (car == null) return NotFound();

                return View(Mapper.Map(car));
            }
            catch (Exception)
            { //Laver fejlmeddelse
                TempData["CarCantBeFound"] = "Bilen findes ikke længere.";
                return RedirectToAction(nameof(Index));
            }

        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, Brand, Model, Color, Billede, RowVersion")] CarViewModel car)
        {
            if (id != car.ID) return NotFound();
            var oldCar = await _carService.GetCarAsync(id).ConfigureAwait(false); //Henter den nyeste opdateret bil fra databasen.

            if (ModelState.IsValid && Mapper.Map(oldCar).RowVersion == car.RowVersion) //Der sammenlignes om den nyeste bil og den nuværende bil har samme rowversion.
            { //Hvis rowversion er ens, så der ikke andre brugere som har været inde og ændre i bilen. 

                await _carService.UpdateAsync(id, Mapper.Map(car)).ConfigureAwait(false);

                return RedirectToAction(nameof(Index));
            }
            else
            {//Laver en fejlmeddelse 
                TempData["CarAlreadyUpdated"] = "Bilen er allerede blevet opdateret af en anden bruger. Opdater siden, hvis du stadig ønsker at ændre i bilen.";
                return View(car);
            }

        }


        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            try
            {
                var car = await _carService.GetCarAsync(id.Value).ConfigureAwait(false);
                if (car == null) return NotFound();
                return View(Mapper.Map(car));
            }
            catch (Exception)
            { //Laver fejlmeddelse
                TempData["CarCantBeFound"] = "Bilen findes ikke længere.";
                return RedirectToAction(nameof(Index));
            }

        }

        //POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _carService.RemoveAsync(id.Value).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
            
        }




    }
}