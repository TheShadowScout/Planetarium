using PlanetariumData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetariumServices
{
    public class PlanetariumPlanetServices : IPlanetariumPlanet
    {
        private PlanetariumContext context;
        public PlanetariumPlanetServices(PlanetariumContext _context)
        {
            context = _context;
        }
        public void Add(Planet newPlanet)
        {
            context.Add(newPlanet);
            context.SaveChanges();
        }
        public IEnumerable<Planet> GetAll()
        {
            return context.Planets;
        }
        public IEnumerable<Planet> GetAllBySolarSystemId(int solarSystemId)
        {
            return context.Planets.Where(planet => planet.StarSystemId == solarSystemId);
        }
        public Planet GetById(int id)
        {
            return GetAll().FirstOrDefault(planet => planet.Id == id);
        }
        public void Edit(Planet newPlanet, int oldPlanetId)
        {
            Planet oldPlanet = GetById(oldPlanetId);
            newPlanet.Id = oldPlanet.Id;
            newPlanet.StarSystemId = oldPlanet.StarSystemId;
            Delete(oldPlanetId, oldPlanet.StarSystemId);
            context.Add(newPlanet);
            context.SaveChanges();
        }
        public void Delete(int id, int starSystemId)
        {
            context.Remove(GetAll().FirstOrDefault(planet => planet.Id == id && planet.StarSystemId == starSystemId));
            context.SaveChanges();
        }
        public string GetPlanetName(int id)
        {
            return GetById(id).Name;
        }
    }
}
