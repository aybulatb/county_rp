using CountyRP.Services.Logs.Entities;
using CountyRP.Services.Logs.Models;

namespace CountyRP.Services.Logs.Converters
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
