#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 9200
EXPOSE 9201

# Prevent 'Warning: apt-key output should not be parsed (stdout is not a terminal)'
ENV APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=1

# install NodeJS 13.x
# see https://github.com/nodesource/distributions/blob/master/README.md#deb
RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_13.x | bash -
RUN apt-get install -y nodejs

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