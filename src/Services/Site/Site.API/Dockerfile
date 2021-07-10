#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/Site/Site.API/Site.API.csproj", "Services/Site/Site.API/"]
COPY ["Services/Site/Site.Infrastructure/Site.Infrastructure.csproj", "Services/Site/Site.Infrastructure/"]
RUN dotnet restore "Services/Site/Site.API/Site.API.csproj"
COPY . .
WORKDIR "/src/Services/Site/Site.API"
RUN dotnet build "Site.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Site.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CountyRP.Services.Site.API.API.dll"]