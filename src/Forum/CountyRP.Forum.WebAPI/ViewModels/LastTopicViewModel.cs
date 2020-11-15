using System;

namespace CountyRP.Forum.WebAPI.ViewModels
{
    public class LastTopicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlayerViewModel LastPlayer { get; set; }
        public DateTime DateTime { get; set; }
    }
}
