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
        private readonly IModeratorRepository _moderatorRepository;
        private Extra.PlayerClient _playerClient;
        private Extra.GroupClient _groupClient;

        public ForumService(IForumRepository forumRepository,
            ITopicRepository topicRepository,
            IPostRepository postRepository,
            IModeratorRepository moderatorRepository,
            Extra.PlayerClient playerClient,
            Extra.GroupClient groupClient)
        {
            _forumRepository = forumRepository;
            _topicRepository = topicRepository;
            _postRepository = postRepository;
            _moderatorRepository = moderatorRepository;
            _playerClient = playerClient;
            _groupClient = groupClient;
        }

        public async Task<ForumModel> CreateForum(ForumViewModel forumViewModel)
        {
            var forum = new ForumModel
            {
                Name = forumViewModel.Name,
                ParentId = forumViewModel.ParentId
            };

            var createdForum = await _forumRepository.CreateForum(forum);

            return createdForum;
        }

        public async Task<IEnumerable<ForumModel>> GetAllForums()
        {
            var forums = await _forumRepository.GetAll();

            return forums;
        }

        public async Task<ForumModel> GetForumById(int id)
        {
            var forum = await _forumRepository.GetForum(id);

            return forum;
        }

        public async Task<ForumModel> Edit(int id, ForumViewModel forumViewModel)
        {
            var forum = new ForumModel
            {
                Name = forumViewModel.Name,
                ParentId = forumViewModel.ParentId
            };

            var editedForum = await _forumRepository.Edit(id, forum);

            return editedForum;
        }

        public async Task Delete(int id)
        {
            await _forumRepository.Delete(id);
        }

        public async Task<IEnumerable<ForumInfoViewModel>> GetForumsInfo()
        {
            var forumAll = new List<ForumInfoViewModel>();
            var forums = await _forumRepository.GetAll();

            foreach (var forum in forums)
            {
                forumAll.Add(await CreateForumInfo(forum));
            }

            return forumAll;
        }

        private async Task<ForumInfoViewModel> CreateForumInfo(ForumModel forum)
        {
            Topic lastTopic = new Topic();
            Post lastPost = new Post();
            var topics = (await _topicRepository.GetByForumId(forum.Id)).ToArray();
            var allPosts = new List<Post>();
            var moderators = new List<ModeratorViewModel>();

            foreach (var topic in topics)
            {
                allPosts.AddRange(await _postRepository.GetPosts(topic.Id));
            }

            lastPost = allPosts?.OrderByDescending(p => p.CreationDateTime).FirstOrDefault();
            lastTopic = topics?.FirstOrDefault(t => t.Id == lastPost.TopicId);
            int postsCount = allPosts.Count();

            var player = await _playerClient.GetByIdAsync(1);
            var moders = await _moderatorRepository.GetAll();

            foreach (var moder in moders)
            {
                if(moder.EntityType.Equals(1))
                    moderators.Add(await CreateModeratorModel(moder));
            }

            return new ForumInfoViewModel
            {
                Id = forum.Id,
                Name = forum.Name,
                LastTopic = new LastTopicViewModel
                {
                    Id = lastTopic.Id,
                    Name = lastTopic.Caption,
                    LastPlayer = new PlayerViewModel
                    {
                        Id = player.Id,
                        Name = player.Login
                    },
                    DateTime = lastPost.CreationDateTime
                },
                MessagesCount = postsCount,
                Moderators = moderators.ToArray()
            };
        }

        private async Task<ModeratorViewModel> CreateModeratorModel(Moderator moderator)
        {
            if (moderator.EntityType.Equals(0))
            {
                var moderGroup = await _groupClient.GetByIdAsync(moderator.EntityId.ToString());

                return new ModeratorViewModel
                {
                    Id = moderator.Id,
                    Name = moderGroup.Name
                };
            }
            if (moderator.EntityType.Equals(1))
            {
                var moderPlayer = await _playerClient.GetByIdAsync(moderator.EntityId);

                return new ModeratorViewModel
                {
                    Id = moderator.Id,
                    Name = moderPlayer.Login
                };
            }

            return null;
        }
    }
}
