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

        public static ApiPagedFilterResult<ApiPostDtoOut> ToApi(
            PagedFilterResult<PostDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiPostDtoOut>()
            {
                AllCount = source.AllCount,
                Page = source.Page,
                MaxPages = source.MaxPages,
                Items = source.Items.Select(PostDtoOutConverter.ToApi)
            };
        }

        public static ApiPagedFilterResult<ApiModeratorDtoOut> ToApi(
            PagedFilterResult<ModeratorDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiModeratorDtoOut>()
            {
                AllCount = source.AllCount,
                Page = source.Page,
                MaxPages = source.MaxPages,
                Items = source.Items.Select(ModeratorDtoOutConverter.ToApi)
            };
        }

        public static ApiPagedFilterResult<ApiReputationDtoOut> ToApi(
            PagedFilterResult<ReputationDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiReputationDtoOut>()
            {
                AllCount = source.AllCount,
                Page = source.Page,
                MaxPages = source.MaxPages,
                Items = source.Items.Select(ReputationDtoOutConverter.ToApi)
            };
        }

        public static ApiPagedFilterResult<ApiWarningDtoOut> ToApi(
            PagedFilterResult<WarningDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiWarningDtoOut>()
            {
                AllCount = source.AllCount,
                Page = source.Page,
                MaxPages = source.MaxPages,
                Items = source.Items.Select(WarningDtoOutConverter.ToApi)
            };
        }
    }
}
