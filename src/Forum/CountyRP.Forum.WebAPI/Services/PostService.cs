using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CountyRP.Extra;
using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.Services.Interfaces;
using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly PlayerClient _playerClient;

        public PostService(IPostRepository postRepository,
            PlayerClient playerClient)
        {
            _postRepository = postRepository;
            _playerClient = playerClient;
        }

        public async Task<Post> Create(PostCreateViewModel postViewModel)
        {
            return await _postRepository.Create(new Post
            {
                TopicId = postViewModel.TopicId,
                Text = postViewModel.Text
            });
        }

        public async Task Delete(int id)
        {
            await _postRepository.Delete(id);
        }

        public async Task<Post> Edit(int id, PostEditViewModel postViewModel)
        {
            return await _postRepository.Edit(id, new Post
            {
                Text = postViewModel.Text
            });
        }

        public async Task<IEnumerable<PostFilterViewModel>> FilterBy(int topicId, int page)
        {
            var posts = await _postRepository.GetPosts(topicId);
            int pageSize = 20;

            var postsForFilter = new List<PostFilterViewModel>();

            foreach (var post in posts)
            {
                var player = await _playerClient.GetByIdAsync(post.Id);

                postsForFilter.Add(new PostFilterViewModel
                {
                    Id = post.Id,
                    DateTime = post.CreationDateTime,
                    Player = new PlayerViewModel
                    {
                        Id = player.Id,
                        Name = player.Login
                    }
                });
            }

            return postsForFilter.OrderByDescending(t => t.DateTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
