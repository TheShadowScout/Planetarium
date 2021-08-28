using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetariumData
{
    public interface IPlanetariumPlanet
    {
        IEnumerable<Planet> GetAll();
        IEnumerable<Planet> GetAllBySolarSystemId(int solarSystemId);
        Planet GetById(int id);
        void Add(Planet newPlanet);
        void Edit(Planet newPlanet, int oldPlanetId);
        void Delete(int id, int starSystemId);
        string GetPlanetName(int id);
    }
}
