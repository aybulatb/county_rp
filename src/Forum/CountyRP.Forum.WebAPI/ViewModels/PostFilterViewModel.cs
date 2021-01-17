using System;

namespace CountyRP.Forum.WebAPI.ViewModels
{
    public class PostFilterViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public PlayerViewModel Player { get; set; }
    }
}
