# 🛒 Catalog Service API (Deploy en Azure Container Apps)

Este proyecto es una API REST construida con .NET 8 y arquitectura limpia (Clean Architecture), que sirve como backend para un sistema de catálogo de productos.
El objetivo fue desplegar la aplicación usando contenedores Docker y automatizar el pipeline CI/CD con GitHub Actions, publicando en Azure Container Apps a través 
de GitHub Container Registry (GHCR).

## 🚀 Tech Stack

- **.NET 8** (ASP.NET Core Web API)
- **Clean Architecture** (con proyectos separados: API, Application, Domain, Infrastructure)
- **Entity Framework Core**
- **Docker**
- **GitHub Actions** (CI/CD)
- **GitHub Container Registry (GHCR)**
- **Azure Container Apps** (Despliegue serverless)

## 📁 Estructura del Proyecto
Catalog.API/ -> API REST principal
Catalog.Application/ -> Casos de uso / lógica de aplicación
Catalog.Domain/ -> Entidades y contratos de dominio
Catalog.Infrastructure/ -> Persistencia y servicios externos


## ⚙️ CI/CD con GitHub Actions

El workflow `build-and-deploy.yaml` unifica todo:

1. 🔧 **Build Docker Image**
2. 🚀 **Push a GitHub Container Registry (GHCR)**
3. ☁️ **Deploy automático a Azure Container Apps**

## 🌐 URL en producción

[https://catalogservicecontainer.delightfuldesert-1760922d.brazilsouth.azurecontainerapps.io/swagger](https://catalogservicecontainer.delightfuldesert-1760922d.brazilsouth.azurecontainerapps.io/swagger)

---

## 🧪 Probar localmente

```bash
docker build -t catalogservice .
docker run -p 8080:80 catalogservice
