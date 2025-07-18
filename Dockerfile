FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar sólo el csproj para cache de restore
COPY ["Catalog.API/Catalog.API.csproj", "Catalog.API/"]

RUN dotnet restore "Catalog.API/Catalog.API.csproj"

# Copiar todo el código de la solución
COPY . .

WORKDIR "/src/Catalog.API"
RUN dotnet publish "Catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Catalog.API.dll"]

