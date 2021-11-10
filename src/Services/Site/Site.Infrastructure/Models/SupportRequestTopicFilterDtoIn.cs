namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record SupportRequestTopicFilterDtoIn(
        int? Count,
        int? Page,
        SupportRequestTopicTypeDto? Type,
        SupportRequestTopicStatusDto? Status,
        int? CreatorUserId,
        int? RefUserId
    ) : PagedFilter(Count, Page);
}
