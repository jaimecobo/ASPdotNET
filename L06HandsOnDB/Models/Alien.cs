using L06HandsOnDB.Models;
using System.ComponentModel.DataAnnotations;

namespace L06HandsOnDB{
    public class Alien{
        public long Id { get; set; }
        [Range(0, 20)] public int Arms { get; set; }
        [Range(0, 7)] public int Heads { get; set; }
        [Range(0, 1000)] public int Legs { get; set; }
        public DateTime BirthDate {get; set;}
        public PlanetsEnum.PlanetOfOrigin PlanetOfOrigin { get; set; }
    }

}
    

    