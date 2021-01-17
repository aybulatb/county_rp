namespace CountyRP.Forum.WebAPI.ViewModels
{
    public class ModeratorEditViewModel
    {
        public bool CreateTopics { get; set; }
        public bool CreatePosts { get; set; }
        public bool Read { get; set; }
        public bool EditPosts { get; set; }
        public bool DeleteTopics { get; set; }
        public bool DeletePosts { get; set; }
    }
}
