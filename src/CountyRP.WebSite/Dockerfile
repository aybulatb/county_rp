#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CountyRP.WebSite/CountyRP.WebSite.csproj", "CountyRP.WebSite/"]
COPY ["CountyRP.Models/CountyRP.Models.csproj", "CountyRP.Models/"]
RUN dotnet restore "CountyRP.WebSite/CountyRP.WebSite.csproj"
COPY . .
WORKDIR "/src/CountyRP.WebSite"
RUN dotnet build "CountyRP.WebSite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CountyRP.WebSite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CountyRP.WebSite.dll"]