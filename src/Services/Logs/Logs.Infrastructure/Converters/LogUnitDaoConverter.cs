using CountyRP.Services.Logs.Infrastructure.Entities;
using CountyRP.Services.Logs.Infrastructure.Models;

namespace CountyRP.Services.Logs.Infrastructure.Converters
{
    public static class LogUnitDaoConverter
    {
        public static LogUnitDtoOut ToRepository(
            LogUnitDao source
        )
        {
            return new LogUnitDtoOut(
                id: source.Id,
                dateTime: source.DateTime,
                login: source.Login,
                ip: source.IP,
                actionId: LogActionDaoConverter.ToRepository(source.ActionId),
                text: source.Text
            );
        }
    }
}
