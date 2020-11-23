using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.WebAPI.Services.Interfaces;
using CountyRP.Forum.WebAPI.ViewModels;
using CountyRP.Extra;

namespace CountyRP.Forum.WebAPI.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IPostRepository _postRepository;
        private readonly PlayerClient _playerClient;

        public TopicService(ITopicRepository topicRepository, 
            IPostRepository postRepository,
            PlayerClient playerClient)
        {
            _topicRepository = topicRepository;
            _postRepository = postRepository;
            _playerClient = playerClient;
        }

        public async Task<IEnumerable<Topic>> GetTopicsByForumId(int id)
        {
            return await _topicRepository.GetByForumId(id);
        }

        public async Task<IEnumerable<TopicFilterViewModel>> FilterByPage(int forumId, int page)
        {
            var allTopics = await _topicRepository.GetByForumId(forumId);
            int pageSize = 20;

            var topicsForFilter = new List<TopicFilterViewModel>();

            foreach (var topic in allTopics)
            {
                var lastPost = await _postRepository.GetLastPostInTopic(topic.Id);
                var player = await _playerClient.GetByIdAsync(lastPost.UserId);

                topicsForFilter.Add(
                    CreateTopicFilterViewModel(topic, lastPost, player));
            }

            var filteredTopics = topicsForFilter.OrderByDescending(t => t.LastPost.DateTime) // отсортировать по последнему сообщению в темах
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return filteredTopics;
        }

        private TopicFilterViewModel CreateTopicFilterViewModel(Topic topic, Post lastPost, Player player)
        {
            return new TopicFilterViewModel
            {
                Id = topic.Id,
                Name = topic.Caption,
                LastPost = new PostFilterViewModel
                {
                    Id = lastPost.Id,
                    DateTime = lastPost.CreationDateTime,
                    Player = new PlayerViewModel
                    {
                        Id = player.Id,
                        Name = player.Login
                    }
                }
            };
        }

        public async Task<Topic> CreateTopicAndMessage(TopicCreateViewModel topicModel)
        {
            var createdTopic = await _topicRepository.CreateTopic(new Topic 
            {
                Caption = topicModel.Name, 
                ForumId = topicModel.ForumId 
            });

            await _postRepository.Create(new Post 
            { 
                TopicId = createdTopic.Id, 
                Text = topicModel.Text 
            });

            return createdTopic;
        }

        public async Task Delete(int id)
        {
            await _topicRepository.Delete(id);
        }

        public async Task<Topic> Edit(int id, Topic topic)
        {
            return await _topicRepository.Edit(id, topic);
        }
    }
}
