namespace CountyRP.Forum.WebAPI.ViewModels
{
    public class TopicFilterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PostFilterViewModel LastPost { get; set; }
    }
}
