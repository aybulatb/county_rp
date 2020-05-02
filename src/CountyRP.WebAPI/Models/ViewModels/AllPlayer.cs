using System.Collections.Generic;

using CountyRP.Models;

namespace CountyRP.WebAPI.Models.ViewModels
{
    public class AllPlayer
    {
        public Player Player { get; set; }
        public List<AllPerson> Persons { get; set; }
    }

    public class AllPerson
    {
        public Person Person { get; set; }
        public Faction Faction { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
