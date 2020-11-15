namespace CountyRP.Forum.WebAPI.ViewModels
{
    public class ForumInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LastTopicViewModel LastTopic { get; set; }
        public int MessagesCount { get; set; }
        public ModeratorViewModel[] Moderators { get; set; }
    }
}
