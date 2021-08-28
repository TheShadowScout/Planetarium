using PlanetariumData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetariumServices
{
    public class PlanetariumStarSystemServices : IPlanetariumStarSystem
    {
        private PlanetariumContext context;
        public PlanetariumStarSystemServices(PlanetariumContext _context)
        {
            context = _context;
        }
        public IEnumerable<StarSystem> GetAll()
        {
            return context.StarSystems;
        }
        public StarSystem GetById(int id)
        {
            return GetAll().First(solarSystem => solarSystem.Id == id);
        }
        public void Add(StarSystem newStarSystem)
        {
            context.Add(newStarSystem);
            context.SaveChanges();
        }
        public void Edit(StarSystem newStarSystem, int oldStarSystemId)
        {
            StarSystem oldStarSystem = GetById(oldStarSystemId);
            oldStarSystem.Name = newStarSystem.Name;
            context.Update(oldStarSystem);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.Remove(GetById(id));
            context.SaveChanges();
        }
        public string GetStarSystemName(int id)
        {
            return context.StarSystems.First(starSystem => starSystem.Id == id).Name;
        }
    }
}
