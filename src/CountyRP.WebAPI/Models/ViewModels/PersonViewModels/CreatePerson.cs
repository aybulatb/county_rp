using System;

namespace CountyRP.WebAPI.Models.ViewModels.PersonViewModels
{
    public class CreatePerson
    {
        public string Name { get; set; }
        public DateTime RegDate { get; set; }
        public int PlayerId { get; set; }
    }
}
