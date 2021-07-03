#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Gateways/AdminPanel/AdminPanel.API/AdminPanel.API.csproj", "Gateways/AdminPanel/AdminPanel.API/"]
COPY ["Gateways/AdminPanel/AdminPanel.Infrastructure/AdminPanel.Infrastructure.csproj", "Gateways/AdminPanel/AdminPanel.Infrastructure/"]
RUN dotnet restore "Gateways/AdminPanel/AdminPanel.API/AdminPanel.API.csproj"
COPY . .
WORKDIR "/src/Gateways/AdminPanel/AdminPanel.API"
RUN dotnet build "AdminPanel.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdminPanel.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CountyRP.Gateways.AdminPanel.API.dll"]