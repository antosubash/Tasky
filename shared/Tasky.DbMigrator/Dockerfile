#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/project/NuGet.Config", "services/project/"]
COPY ["shared/Tasky.DbMigrator/Tasky.DbMigrator.csproj", "shared/Tasky.DbMigrator/"]
COPY ["services/saas/src/Tasky.SaaSService.EntityFrameworkCore/Tasky.SaaSService.EntityFrameworkCore.csproj", "services/saas/src/Tasky.SaaSService.EntityFrameworkCore/"]
COPY ["services/saas/src/Tasky.SaaSService.Domain/Tasky.SaaSService.Domain.csproj", "services/saas/src/Tasky.SaaSService.Domain/"]
COPY ["services/saas/src/Tasky.SaaSService.Domain.Shared/Tasky.SaaSService.Domain.Shared.csproj", "services/saas/src/Tasky.SaaSService.Domain.Shared/"]
COPY ["services/administration/src/Tasky.AdministrationService.Application.Contracts/Tasky.AdministrationService.Application.Contracts.csproj", "services/administration/src/Tasky.AdministrationService.Application.Contracts/"]
COPY ["services/administration/src/Tasky.AdministrationService.Domain.Shared/Tasky.AdministrationService.Domain.Shared.csproj", "services/administration/src/Tasky.AdministrationService.Domain.Shared/"]
COPY ["services/saas/src/Tasky.SaaSService.Application.Contracts/Tasky.SaaSService.Application.Contracts.csproj", "services/saas/src/Tasky.SaaSService.Application.Contracts/"]
COPY ["services/identity/src/Tasky.IdentityService.Application.Contracts/Tasky.IdentityService.Application.Contracts.csproj", "services/identity/src/Tasky.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/Tasky.IdentityService.Domain.Shared/Tasky.IdentityService.Domain.Shared.csproj", "services/identity/src/Tasky.IdentityService.Domain.Shared/"]
COPY ["services/project/src/Tasky.ProjectService.EntityFrameworkCore/Tasky.ProjectService.EntityFrameworkCore.csproj", "services/project/src/Tasky.ProjectService.EntityFrameworkCore/"]
COPY ["services/project/src/Tasky.ProjectService.Domain/Tasky.ProjectService.Domain.csproj", "services/project/src/Tasky.ProjectService.Domain/"]
COPY ["services/project/src/Tasky.ProjectService.Domain.Shared/Tasky.ProjectService.Domain.Shared.csproj", "services/project/src/Tasky.ProjectService.Domain.Shared/"]
COPY ["services/identity/src/Tasky.IdentityService.EntityFrameworkCore/Tasky.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Tasky.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/Tasky.IdentityService.Domain/Tasky.IdentityService.Domain.csproj", "services/identity/src/Tasky.IdentityService.Domain/"]
COPY ["services/project/src/Tasky.ProjectService.Application.Contracts/Tasky.ProjectService.Application.Contracts.csproj", "services/project/src/Tasky.ProjectService.Application.Contracts/"]
COPY ["services/administration/src/Tasky.AdministrationService.EntityFrameworkCore/Tasky.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/Tasky.AdministrationService.EntityFrameworkCore/"]
COPY ["services/administration/src/Tasky.AdministrationService.Domain/Tasky.AdministrationService.Domain.csproj", "services/administration/src/Tasky.AdministrationService.Domain/"]
RUN dotnet restore "shared/Tasky.DbMigrator/Tasky.DbMigrator.csproj"
COPY . .
WORKDIR "/src/shared/Tasky.DbMigrator"
RUN dotnet build "Tasky.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tasky.DbMigrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tasky.DbMigrator.dll"]