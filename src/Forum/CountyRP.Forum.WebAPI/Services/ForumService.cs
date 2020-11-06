using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.Services.Interfaces;
using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Services
{
    public class ForumService : IForumService
    {
        private readonly IForumRepository _forumRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IPostRepository _postRepository;
        private Extra.PlayerClient _playerClient;

        public ForumService(IForumRepository forumRepository,
            ITopicRepository topicRepository,
            IPostRepository postRepository,
            Extra.PlayerClient playerClient)
        {
            _forumRepository = forumRepository;
            _topicRepository = topicRepository;
            _postRepository = postRepository;
            _playerClient = playerClient;
        }

        public async Task<ForumModel> CreateForum(ForumModel forum)
        {
            var createdForum = await _forumRepository.CreateForum(forum);

            return createdForum;
        }

        public async Task<IEnumerable<ForumModel>> GetAllForums()
        {
            var forums = await _forumRepository.GetAll();

            return forums;
        }

        public async Task<IEnumerable<ForumInfoViewModel>> GetForumsInfo()
        {
            Topic lastTopic = new Topic();
            Post lastPost = new Post();
            var forumInfos = new List<ForumInfoViewModel>();
            var allPosts = new List<Post>();

            var forums = await _forumRepository.GetAll();

            foreach (var forum in forums)
            {
                var topics = (await _topicRepository.GetByForumId(forum.Id)).ToArray();
                
                foreach (var topic in topics)
                {
                    allPosts.AddRange(await _postRepository.GetPosts(topic.Id));
                }

                lastPost = allPosts?.OrderByDescending(p => p.CreationDateTime).FirstOrDefault();
                lastTopic = topics?.FirstOrDefault(t => t.Id == lastPost.TopicId);
                int postsCount = allPosts.Count();

                var player = await _playerClient.GetByIdAsync(lastPost.UserId);

                forumInfos.Add(new ForumInfoViewModel
                {
                    Id = forum.Id,
                    Name = forum.Name,
                    LastTopic = new LastTopicViewModel
                    {
                        Id = lastTopic.Id,
                        Name = lastTopic.Caption,
                        Player = new PlayerViewModel
                        {
                            Id = player.Id,
                            Login = player.Login
                        }
                    },
                    PostsCount = postsCount,
                    DateTime = lastPost.CreationDateTime
                });
            }

            return forumInfos;
        }

    }
}
