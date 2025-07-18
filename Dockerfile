# Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CatalogService/CatalogService.csproj", "CatalogService/"]
RUN dotnet restore "CatalogService/CatalogService.csproj"
COPY . .
WORKDIR "/src/CatalogService"
RUN dotnet publish "CatalogService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CatalogService.dll"]
