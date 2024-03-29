﻿using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceForum;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Interfaces;
using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Implementations
{
    public partial class ForumService : IForumService
    {
        private readonly IForumClient _forumClient;
        private readonly IModeratorClient _moderatorClient;
        private readonly IUserClient _userClient;

        public ForumService(
            IForumClient forumClient,
            IModeratorClient moderatorClient,
            IUserClient userClient
        )
        {
            _forumClient = forumClient ?? throw new ArgumentNullException(nameof(forumClient));
            _moderatorClient = moderatorClient ?? throw new ArgumentNullException(nameof(moderatorClient));
            _userClient = userClient ?? throw new ArgumentNullException(nameof(userClient));
        }
    }
}
