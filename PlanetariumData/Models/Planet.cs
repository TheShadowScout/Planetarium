using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlanetariumData
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DistanceFromStar { get; set; }
        public double Radius { get; set; }
        public double Cycle { get; set; }
        public string SurfaceColor { get; set; }
        public string CoreColor { get; set; }
        public bool IsReversed { get; set; }
        public string Type { get; set; }
        public int StarSystemId { get; set; }
    }
}
