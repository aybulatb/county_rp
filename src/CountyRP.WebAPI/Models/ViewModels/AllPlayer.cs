using System.Collections.Generic;

using CountyRP.Entities;
using CountyRP.WebAPI.Models.ViewModels.FactionViewModels;

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
        public FactionViewModels.Faction Faction { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
