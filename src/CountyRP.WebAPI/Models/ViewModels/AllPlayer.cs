using System.Collections.Generic;

using CountyRP.Entities;

namespace CountyRP.WebAPI.Models.ViewModels
{
    public class AllPlayer
    {
        public Player Player { get; set; }
        public List<Person> Persons { get; set; }
    }
}
