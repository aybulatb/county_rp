using CountyRP.Services.Forum.Infrastructure.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CountyRP.Services.Forum.API.Comparers
{
    public class ForumDtoOutComparer : IEqualityComparer<ForumDtoOut>
    {
        public bool Equals(ForumDtoOut x, ForumDtoOut y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }

            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] ForumDtoOut forum)
        {
            var hashForumId = forum.Id.GetHashCode();

            return hashForumId;
        }
    }
}
