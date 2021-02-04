#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Forum/CountyRP.Forum.WebAPI/CountyRP.Forum.WebAPI.csproj", "Forum/CountyRP.Forum.WebAPI/"]
COPY ["Forum/CountyRP.Forum.Infrastructure/CountyRP.Forum.Infrastructure.csproj", "Forum/CountyRP.Forum.Infrastructure/"]
COPY ["Forum/CountyRP.Forum.Domain/CountyRP.Forum.Domain.csproj", "Forum/CountyRP.Forum.Domain/"]
RUN dotnet restore "Forum/CountyRP.Forum.WebAPI/CountyRP.Forum.WebAPI.csproj"
COPY . .
WORKDIR "/src/Forum/CountyRP.Forum.WebAPI"
RUN dotnet build "CountyRP.Forum.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CountyRP.Forum.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CountyRP.Forum.WebAPI.dll"]
