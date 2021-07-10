#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/Logs/Logs.API/Logs.API.csproj", "Services/Logs/Logs.API/"]
COPY ["Services/Logs/Logs.Infrastructure/Logs.Infrastructure.csproj", "Services/Logs/Logs.Infrastructure/"]
RUN dotnet restore "Services/Logs/Logs.API/Logs.API.csproj"
COPY . .
WORKDIR "/src/Services/Logs/Logs.API"
RUN dotnet build "Logs.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Logs.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CountyRP.Services.Logs.API.dll"]