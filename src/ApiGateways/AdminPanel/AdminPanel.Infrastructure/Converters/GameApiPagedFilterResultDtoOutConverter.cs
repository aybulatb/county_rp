using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Converters
{
    internal static class GameApiPagedFilterResultDtoOutConverter
    {
        public static GamePagedFilterResultDtoOut<GamePlayerDtoOut> ToService(
            ApiPagedFilterResultDtoOutOfApiPlayerDtoOut source
        )
        {
            return new GamePagedFilterResultDtoOut<GamePlayerDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(GameApiPlayerDtoOutConverter.ToService)
                );
        }

        public static GamePagedFilterResultDtoOut<GamePersonDtoOut> ToService(
            ApiPagedFilterResultDtoOutOfApiPersonDtoOut source
        )
        {
            return new GamePagedFilterResultDtoOut<GamePersonDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(GameApiPersonDtoOutConverter.ToService)
                );
        }
    }
}
