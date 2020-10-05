using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Circustrein_3._0.Models;
using LogicLayer;

namespace Circustrein_3._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
      [HttpGet]
        public IActionResult Index(forminputmodel model, string x)
        {
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(forminputmodel model)
        {
            List<Animal> animalList = new List<Animal>();
            for (int i = 0; i < model.bigHerbivore; i++)
            {
                Animal animal = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Large);
                animalList.Add(animal);
            }
            for (int i = 0; i < model.mediumHerbivore; i++)
            {
                Animal animal = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Medium);
                animalList.Add(animal);
            }
            for (int i = 0; i < model.smallHerbivore; i++)
            {
                Animal animal = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Small);
                animalList.Add(animal);
            }
            for (int i = 0; i < model.bigCarnivore; i++)
            {
                Animal animal = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Large);
                animalList.Add(animal);
            }
            for (int i = 0; i < model.mediumCarnivore; i++)
            {
                Animal animal = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Medium);
                animalList.Add(animal);
            }
            for (int i = 0; i < model.smallCarnivore; i++)
            {
                Animal animal = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Small);
                animalList.Add(animal);
            }
            SortingAlgorithm sort = new SortingAlgorithm();
            animalList = sort.SortAnimals(animalList);
            List<Wagon>WagonList = sort.AvailableWagon(animalList);
            model.output = sort.DisplayAnimals(WagonList);
            return View(model);
            

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
