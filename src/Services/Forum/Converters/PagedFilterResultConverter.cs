using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;
using System.Linq;

namespace CountyRP.Services.Forum.Converters
{
    internal static class PagedFilterResultConverter
    {
        public static ApiPagedFilterResult<ApiUserDtoOut> ToApi(
            PagedFilterResult<UserDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiUserDtoOut>()
            {
                AllCount = source.AllCount,
                Page = source.Page,
                MaxPages = source.MaxPages,
                Items = source.Items.Select(UserDtoOutConverter.ToApi)
            };
        }

        public static ApiPagedFilterResult<ApiForumDtoOut> ToApi(
            PagedFilterResult<ForumDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiForumDtoOut>()
            {
                AllCount = source.AllCount,
                Page = source.Page,
                MaxPages = source.MaxPages,
                Items = source.Items.Select(ForumDtoOutConverter.ToApi)
            };
        }

        public static ApiPagedFilterResult<ApiTopicDtoOut> ToApi(
            PagedFilterResult<TopicDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiTopicDtoOut>() 
            { 
                AllCount = source.AllCount, 
                Page = source.Page, 
                MaxPages = source.MaxPages, 
                Items = source.Items.Select(TopicDtoOutConverter.ToApi) 
            };
        }
    }
}
