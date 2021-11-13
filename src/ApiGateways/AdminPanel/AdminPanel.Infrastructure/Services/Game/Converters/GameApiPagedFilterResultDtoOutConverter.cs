using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Converters
{
    internal static class GameApiPagedFilterResultDtoOutConverter
    {
        public static GamePagedFilterResultDtoOut<GamePlayerDtoOut> ToService(
            ApiPagedFilterResultDtoOutOfApiPlayerDtoOut source
        )
        {
            return new GamePagedFilterResultDtoOut<GamePlayerDtoOut>(
                AllCount: source.AllCount,
                Page: source.Page,
                MaxPages: source.MaxPages,
                Items: source.Items
                    .Select(GameApiPlayerDtoOutConverter.ToService)
            );
        }

        public static GamePagedFilterResultDtoOut<GamePersonDtoOut> ToService(
            ApiPagedFilterResultDtoOutOfApiPersonDtoOut source
        )
        {
            return new GamePagedFilterResultDtoOut<GamePersonDtoOut>(
                AllCount: source.AllCount,
                Page: source.Page,
                MaxPages: source.MaxPages,
                Items: source.Items
                    .Select(GameApiPersonDtoOutConverter.ToService)
            );
        }

        public static GamePagedFilterResultDtoOut<GamePlayerWithPersonsDtoOut> ToService(
            ApiPagedFilterResultDtoOutOfApiPlayerWithPersonsDtoOut source
        )
        {
            return new GamePagedFilterResultDtoOut<GamePlayerWithPersonsDtoOut>(
                AllCount: source.AllCount,
                Page: source.Page,
                MaxPages: source.MaxPages,
                Items: source.Items
                    .Select(ApiPlayerWithPersonsDtoOutConverter.ToService)
            );
        }
    }
}
