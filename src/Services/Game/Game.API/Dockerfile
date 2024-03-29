#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Game/Game.API/Game.API.csproj", "Services/Game/Game.API/"]
COPY ["BuildingBlocks/CommonMiddlewares/ApiKeyMiddleware/ApiKeyAuthenticationMiddleware.csproj", "BuildingBlocks/CommonMiddlewares/ApiKeyMiddleware/"]
COPY ["Services/Game/Game.Infrastructure/Game.Infrastructure.csproj", "Services/Game/Game.Infrastructure/"]
RUN dotnet restore "Services/Game/Game.API/Game.API.csproj"
COPY . .
WORKDIR "/src/Services/Game/Game.API"
RUN dotnet build "Game.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Game.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CountyRP.Services.Game.API.dll"]