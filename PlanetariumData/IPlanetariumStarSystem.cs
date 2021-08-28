using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetariumData
{
    public interface IPlanetariumStarSystem
    {
        IEnumerable<StarSystem> GetAll();
        StarSystem GetById(int id);
        void Add(StarSystem newPlanet);
        void Edit(StarSystem newPlanet, int oldPlanetId);
        void Delete(int id);
        string GetStarSystemName(int id);
    }
}
