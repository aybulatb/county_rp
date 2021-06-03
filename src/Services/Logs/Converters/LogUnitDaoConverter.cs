using CountyRP.Services.Logs.Entities;
using CountyRP.Services.Logs.Models;

namespace CountyRP.Services.Logs.Converters
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
