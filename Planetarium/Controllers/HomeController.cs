using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Planetarium.Models;
using PlanetariumData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Planetarium.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlanetariumPlanet _planets;
        private readonly ILogger<HomeController> _logger;
        private readonly IPlanetariumStarSystem _starSystems;

        public HomeController(ILogger<HomeController> logger, IPlanetariumPlanet planets, IPlanetariumStarSystem starSystems)
        {
            _logger = logger;
            _planets = planets;
            _starSystems = starSystems;
        }

        public IActionResult Index()
        {
            List<StarSystem> starSystemsList = _starSystems.GetAll().ToList();
            List<Planet> planets = _planets.GetAllBySolarSystemId(LocalData.SelectedSolarSystem).ToList();
            if (starSystemsList.Count == 0)
            {
                ViewData["Error"] = "Brak układów gwiezdnych! Utwórz nowy!";
                LocalData.SelectedSolarSystem = 0;
                LocalData.SelectedSolarSystemName = "Nie wybrano układu gwiezdnego";
                return View(planets);
            }
            
            if (planets.Count == 0 && starSystemsList.Count > 0)
            {
                ViewData["Error"] = "Brak planet! Dodaj nową!";
            }
            if (LocalData.SelectedSolarSystem == 0)
            {
                ViewData["Error"] = "Wybierz układ gwiezdny!";
            }
            return View(planets);
        }

        public IActionResult StarSystemInfo()
        {
            List<Planet> planets = _planets.GetAllBySolarSystemId(LocalData.SelectedSolarSystem).ToList();
            return View(planets);
        }

        public IActionResult StarSystemChoice()
        {
            List<StarSystem> starSystems = _starSystems.GetAll().ToList();
            return View(starSystems);
        }
        [HttpPost]
        public IActionResult SetNewStarSystem(int starSystemId)
        {
            LocalData.SelectedSolarSystem = starSystemId;
            LocalData.SelectedSolarSystemName = _starSystems.GetById(starSystemId).Name;
            return RedirectToAction("StarSystemChoice");
        }
        [HttpPost]
        public IActionResult AddPlanet(string name, string distanceFromStar, string radius, string cycle, string surfaceColor, string coreColor, bool isReversed)
        {
            Planet newPlanet = new Planet();
            newPlanet.Name = name;
            newPlanet.DistanceFromStar = Convert.ToDouble(distanceFromStar.Replace('.', ','));
            newPlanet.Radius = Convert.ToDouble(radius.Replace('.', ','));
            newPlanet.Cycle = Convert.ToDouble(cycle.Replace('.', ','));
            newPlanet.SurfaceColor = surfaceColor;
            newPlanet.CoreColor = coreColor;
            newPlanet.IsReversed = isReversed;
            newPlanet.StarSystemId = LocalData.SelectedSolarSystem;
            int planetAmount = _planets.GetAllBySolarSystemId(LocalData.SelectedSolarSystem).Count();
            if (planetAmount == 0 || _planets.GetAllBySolarSystemId(LocalData.SelectedSolarSystem).First().Type == "Planeta")
            {
                newPlanet.Type = "Gwiazda";
                newPlanet.Id = 0;
            }
            else
            {
                newPlanet.Type = "Planeta";
                newPlanet.Id = planetAmount;
            }
            _planets.Add(newPlanet);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult EditPlanet(string id, string name, string distanceFromStar, string radius, string cycle, string surfaceColor, string coreColor, bool isReversed)
        {
            Planet newPlanet = _planets.GetById(Convert.ToInt32(id));
            newPlanet.Name = name;
            newPlanet.DistanceFromStar = Convert.ToDouble(distanceFromStar.Replace('.', ','));
            newPlanet.Radius = Convert.ToDouble(radius.Replace('.', ','));
            newPlanet.Cycle = Convert.ToDouble(cycle.Replace('.', ','));
            newPlanet.SurfaceColor = surfaceColor;
            newPlanet.CoreColor = coreColor;
            newPlanet.IsReversed = isReversed;
            newPlanet.StarSystemId = LocalData.SelectedSolarSystem;
            _planets.Edit(newPlanet, Convert.ToInt32(id));
            return RedirectToAction("StarSystemInfo");
        }
        [HttpPost]
        public IActionResult DeletePlanet(int id)
        {
            _planets.Delete(Convert.ToInt32(id), LocalData.SelectedSolarSystem);
            return RedirectToAction("StarSystemInfo");
        }
        [HttpPost]
        public IActionResult AddStarSystem(string name)
        {
            StarSystem newStarSystem = new StarSystem();
            newStarSystem.Name = name;
            _starSystems.Add(newStarSystem);
            LocalData.SelectedSolarSystem = newStarSystem.Id;
            LocalData.SelectedSolarSystemName = newStarSystem.Name;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult EditStarSystem(int id, string name)
        {
            StarSystem oldStarSystem = _starSystems.GetById(id);
            oldStarSystem.Name = name;
            _starSystems.Edit(oldStarSystem, id);
            return RedirectToAction("StarSystemChoice");
        }
        [HttpPost]
        public IActionResult DeleteStarSystem(int id)
        {
            List<Planet> oldStarSystemPlanets = _planets.GetAllBySolarSystemId(id).ToList();
            _starSystems.Delete(id);
            foreach (Planet planet in oldStarSystemPlanets)
            {
                _planets.Delete(planet.Id, id);
            }
            if(LocalData.SelectedSolarSystem == id)
            {
                LocalData.SelectedSolarSystem = 0;
                LocalData.SelectedSolarSystemName = "Nie wybrano układu gwiezdnego";
            }
            return RedirectToAction("StarSystemChoice");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
