#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CountyRP.WebAPI/CountyRP.WebAPI.csproj", "CountyRP.WebAPI/"]
COPY ["CountyRP.Models/CountyRP.Models.csproj", "CountyRP.Models/"]
COPY ["CountyRP.Entities/CountyRP.DAO.csproj", "CountyRP.Entities/"]
RUN dotnet restore "CountyRP.WebAPI/CountyRP.WebAPI.csproj"
COPY . .
WORKDIR "/src/CountyRP.WebAPI"
RUN dotnet build "CountyRP.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CountyRP.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CountyRP.WebAPI.dll"]