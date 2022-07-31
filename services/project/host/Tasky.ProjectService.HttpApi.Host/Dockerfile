#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/project/NuGet.Config", "services/project/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/project/host/Tasky.ProjectService.HttpApi.Host/Tasky.ProjectService.HttpApi.Host.csproj", "services/project/host/Tasky.ProjectService.HttpApi.Host/"]
COPY ["shared/Tasky.Shared.Microservice.Hosting/Tasky.Shared.Microservice.Hosting.csproj", "shared/Tasky.Shared.Microservice.Hosting/"]
COPY ["services/administration/src/Tasky.AdministrationService.EntityFrameworkCore/Tasky.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/Tasky.AdministrationService.EntityFrameworkCore/"]
COPY ["services/administration/src/Tasky.AdministrationService.Domain/Tasky.AdministrationService.Domain.csproj", "services/administration/src/Tasky.AdministrationService.Domain/"]
COPY ["services/administration/src/Tasky.AdministrationService.Domain.Shared/Tasky.AdministrationService.Domain.Shared.csproj", "services/administration/src/Tasky.AdministrationService.Domain.Shared/"]
COPY ["services/saas/src/Tasky.SaaSService.EntityFrameworkCore/Tasky.SaaSService.EntityFrameworkCore.csproj", "services/saas/src/Tasky.SaaSService.EntityFrameworkCore/"]
COPY ["services/saas/src/Tasky.SaaSService.Domain/Tasky.SaaSService.Domain.csproj", "services/saas/src/Tasky.SaaSService.Domain/"]
COPY ["services/saas/src/Tasky.SaaSService.Domain.Shared/Tasky.SaaSService.Domain.Shared.csproj", "services/saas/src/Tasky.SaaSService.Domain.Shared/"]
COPY ["shared/Tasky.Shared.Hosting/Tasky.Shared.Hosting.csproj", "shared/Tasky.Shared.Hosting/"]
COPY ["services/project/src/Tasky.ProjectService.HttpApi/Tasky.ProjectService.HttpApi.csproj", "services/project/src/Tasky.ProjectService.HttpApi/"]
COPY ["services/project/src/Tasky.ProjectService.Application.Contracts/Tasky.ProjectService.Application.Contracts.csproj", "services/project/src/Tasky.ProjectService.Application.Contracts/"]
COPY ["services/project/src/Tasky.ProjectService.Domain.Shared/Tasky.ProjectService.Domain.Shared.csproj", "services/project/src/Tasky.ProjectService.Domain.Shared/"]
COPY ["services/project/src/Tasky.ProjectService.Application/Tasky.ProjectService.Application.csproj", "services/project/src/Tasky.ProjectService.Application/"]
COPY ["services/project/src/Tasky.ProjectService.Domain/Tasky.ProjectService.Domain.csproj", "services/project/src/Tasky.ProjectService.Domain/"]
COPY ["services/project/src/Tasky.ProjectService.EntityFrameworkCore/Tasky.ProjectService.EntityFrameworkCore.csproj", "services/project/src/Tasky.ProjectService.EntityFrameworkCore/"]
RUN dotnet restore "services/project/host/Tasky.ProjectService.HttpApi.Host/Tasky.ProjectService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/project/host/Tasky.ProjectService.HttpApi.Host"
RUN dotnet build "Tasky.ProjectService.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tasky.ProjectService.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tasky.ProjectService.HttpApi.Host.dll"]