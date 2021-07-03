using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;
using System.Linq;

namespace CountyRP.Services.Site.Converters
{
    internal static class PagedFilterResultConverter
    {
        public static ApiPagedFilterResult<ApiUserDtoOut> ToApi(
            PagedFilterResult<UserDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiUserDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items.Select(UserDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResult<ApiGroupDtoOut> ToApi(
            PagedFilterResult<GroupDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiGroupDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items.Select(GroupDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResult<ApiBanDtoOut> ToApi(
            PagedFilterResult<BanDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiBanDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items.Select(BanDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResult<ApiSupportRequestTopicWithFirstAndLastMessagesDtoOut> ToApi(
            PagedFilterResult<SupportRequestTopicWithFirstAndLastMessagesDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiSupportRequestTopicWithFirstAndLastMessagesDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items.Select(SupportRequestTopicWithFirstAndLastMessagesDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResult<ApiSupportRequestMessageDtoOut> ToApi(
           PagedFilterResult<SupportRequestMessageDtoOut> source
       )
        {
            return new ApiPagedFilterResult<ApiSupportRequestMessageDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items.Select(SupportRequestMessageDtoOutConverter.ToApi)
            );
        }
    }
}
