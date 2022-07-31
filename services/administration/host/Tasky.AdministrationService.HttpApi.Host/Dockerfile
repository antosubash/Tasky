#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/project/NuGet.Config", "services/project/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/host/Tasky.AdministrationService.HttpApi.Host/Tasky.AdministrationService.HttpApi.Host.csproj", "services/administration/host/Tasky.AdministrationService.HttpApi.Host/"]
COPY ["shared/Tasky.Shared.Hosting/Tasky.Shared.Hosting.csproj", "shared/Tasky.Shared.Hosting/"]
COPY ["services/identity/src/Tasky.IdentityService.Application.Contracts/Tasky.IdentityService.Application.Contracts.csproj", "services/identity/src/Tasky.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/Tasky.IdentityService.Domain.Shared/Tasky.IdentityService.Domain.Shared.csproj", "services/identity/src/Tasky.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/Tasky.IdentityService.EntityFrameworkCore/Tasky.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Tasky.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/Tasky.IdentityService.Domain/Tasky.IdentityService.Domain.csproj", "services/identity/src/Tasky.IdentityService.Domain/"]
COPY ["services/project/src/Tasky.ProjectService.Application.Contracts/Tasky.ProjectService.Application.Contracts.csproj", "services/project/src/Tasky.ProjectService.Application.Contracts/"]
COPY ["services/project/src/Tasky.ProjectService.Domain.Shared/Tasky.ProjectService.Domain.Shared.csproj", "services/project/src/Tasky.ProjectService.Domain.Shared/"]
COPY ["services/saas/src/Tasky.SaaSService.Application.Contracts/Tasky.SaaSService.Application.Contracts.csproj", "services/saas/src/Tasky.SaaSService.Application.Contracts/"]
COPY ["services/saas/src/Tasky.SaaSService.Domain.Shared/Tasky.SaaSService.Domain.Shared.csproj", "services/saas/src/Tasky.SaaSService.Domain.Shared/"]
COPY ["services/saas/src/Tasky.SaaSService.EntityFrameworkCore/Tasky.SaaSService.EntityFrameworkCore.csproj", "services/saas/src/Tasky.SaaSService.EntityFrameworkCore/"]
COPY ["services/saas/src/Tasky.SaaSService.Domain/Tasky.SaaSService.Domain.csproj", "services/saas/src/Tasky.SaaSService.Domain/"]
COPY ["services/administration/src/Tasky.AdministrationService.HttpApi/Tasky.AdministrationService.HttpApi.csproj", "services/administration/src/Tasky.AdministrationService.HttpApi/"]
COPY ["services/administration/src/Tasky.AdministrationService.Application.Contracts/Tasky.AdministrationService.Application.Contracts.csproj", "services/administration/src/Tasky.AdministrationService.Application.Contracts/"]
COPY ["services/administration/src/Tasky.AdministrationService.Domain.Shared/Tasky.AdministrationService.Domain.Shared.csproj", "services/administration/src/Tasky.AdministrationService.Domain.Shared/"]
COPY ["services/administration/src/Tasky.AdministrationService.Application/Tasky.AdministrationService.Application.csproj", "services/administration/src/Tasky.AdministrationService.Application/"]
COPY ["services/administration/src/Tasky.AdministrationService.Domain/Tasky.AdministrationService.Domain.csproj", "services/administration/src/Tasky.AdministrationService.Domain/"]
COPY ["services/administration/src/Tasky.AdministrationService.EntityFrameworkCore/Tasky.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/Tasky.AdministrationService.EntityFrameworkCore/"]
RUN dotnet restore "services/administration/host/Tasky.AdministrationService.HttpApi.Host/Tasky.AdministrationService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/administration/host/Tasky.AdministrationService.HttpApi.Host"
RUN dotnet build "Tasky.AdministrationService.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tasky.AdministrationService.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tasky.AdministrationService.HttpApi.Host.dll"]