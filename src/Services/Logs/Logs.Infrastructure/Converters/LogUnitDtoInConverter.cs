using CountyRP.Services.Logs.Infrastructure.Entities;
using CountyRP.Services.Logs.Infrastructure.Models;

namespace CountyRP.Services.Logs.Infrastructure.Converters
{
    public static class LogUnitDtoInConverter
    {
        public static LogUnitDao ToDb(
            LogUnitDtoIn source
        )
        {
            return new LogUnitDao(
                dateTime: source.DateTime,
                login: source.Login,
                ip: source.IP,
                actionId: LogActionDtoConverter.ToDb(source.ActionId),
                text: source.Text
            );
        }
    }
}
