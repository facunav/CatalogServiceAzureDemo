FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solo el proyecto para cachear restore
COPY ["Catalog.API/Catalog.API.csproj", "Catalog.API/"]

RUN dotnet restore "Catalog.API/Catalog.API.csproj"

# Copiar el resto del código
COPY . .

WORKDIR "/src/Catalog.API"
RUN dotnet publish "Catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Catalog.API.dll"]
