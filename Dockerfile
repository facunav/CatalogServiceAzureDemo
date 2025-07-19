# Imagen base para tiempo de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Imagen para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos solo los archivos del proyecto principal y sus dependencias para aprovechar cache
COPY ["Catalog.API/Catalog.API.csproj", "Catalog.API/"]
COPY ["Catalog.Application/Catalog.Application.csproj", "Catalog.Application/"]
COPY ["Catalog.Domain/Catalog.Domain.csproj", "Catalog.Domain/"]
COPY ["Catalog.Infrastructure/Catalog.Infrastructure.csproj", "Catalog.Infrastructure/"]

# Restauramos las dependencias
RUN dotnet restore "Catalog.API/Catalog.API.csproj"

# Copiamos el resto del código
COPY . .

# Publicamos la app
WORKDIR "/src/Catalog.API"
RUN dotnet publish "Catalog.API.csproj" -c Release -o /app/publish

# Imagen final para producción
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Catalog.API.dll"]
