#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
FROM mcr.microsoft.com/dotnet/aspnet:6.0-jammy-arm64v8 AS base
WORKDIR /app
EXPOSE 80

ENV MonogoServer="mongodb+srv://msb1993:Pokemon%40!32189@msbcluster.8adn2yj.mongodb.net/"
ENV MonogoDB="CapitalPlacementDB"
ENV LoginUserName="admin"
ENV LoginPassword="admin"
ENV JWTSecret="321890MSBCMS321890"
ENV JWTValidAudience="http://localhost"
ENV JWTValidIssuer="http://localhost"


#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy-arm64v8 AS build
WORKDIR /src
COPY ["CapitalPlacementAPI.csproj", "."]
RUN dotnet restore "./CapitalPlacementAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CapitalPlacementAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CapitalPlacementAPI.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .



ENTRYPOINT ["dotnet", "CapitalPlacementAPI.dll"]
