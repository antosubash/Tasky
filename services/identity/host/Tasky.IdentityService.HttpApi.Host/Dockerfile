#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/identity/host/Tasky.IdentityService.HttpApi.Host/Tasky.IdentityService.HttpApi.Host.csproj", "services/identity/host/Tasky.IdentityService.HttpApi.Host/"]
COPY ["services/identity/src/Tasky.IdentityService.HttpApi/Tasky.IdentityService.HttpApi.csproj", "services/identity/src/Tasky.IdentityService.HttpApi/"]
COPY ["services/identity/src/Tasky.IdentityService.Application.Contracts/Tasky.IdentityService.Application.Contracts.csproj", "services/identity/src/Tasky.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/Tasky.IdentityService.Domain.Shared/Tasky.IdentityService.Domain.Shared.csproj", "services/identity/src/Tasky.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/Tasky.IdentityService.Application/Tasky.IdentityService.Application.csproj", "services/identity/src/Tasky.IdentityService.Application/"]
COPY ["services/identity/src/Tasky.IdentityService.Domain/Tasky.IdentityService.Domain.csproj", "services/identity/src/Tasky.IdentityService.Domain/"]
COPY ["services/identity/src/Tasky.IdentityService.EntityFrameworkCore/Tasky.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Tasky.IdentityService.EntityFrameworkCore/"]
COPY ["services/administration/src/Tasky.AdministrationService.EntityFrameworkCore/Tasky.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/Tasky.AdministrationService.EntityFrameworkCore/"]
COPY ["services/administration/src/Tasky.AdministrationService.Domain/Tasky.AdministrationService.Domain.csproj", "services/administration/src/Tasky.AdministrationService.Domain/"]
COPY ["services/administration/src/Tasky.AdministrationService.Domain.Shared/Tasky.AdministrationService.Domain.Shared.csproj", "services/administration/src/Tasky.AdministrationService.Domain.Shared/"]
COPY ["shared/Tasky.Shared.Hosting/Tasky.Shared.Hosting.csproj", "shared/Tasky.Shared.Hosting/"]
COPY ["services/saas/src/Tasky.SaaSService.EntityFrameworkCore/Tasky.SaaSService.EntityFrameworkCore.csproj", "services/saas/src/Tasky.SaaSService.EntityFrameworkCore/"]
COPY ["services/saas/src/Tasky.SaaSService.Domain/Tasky.SaaSService.Domain.csproj", "services/saas/src/Tasky.SaaSService.Domain/"]
COPY ["services/saas/src/Tasky.SaaSService.Domain.Shared/Tasky.SaaSService.Domain.Shared.csproj", "services/saas/src/Tasky.SaaSService.Domain.Shared/"]
RUN dotnet restore "services/identity/host/Tasky.IdentityService.HttpApi.Host/Tasky.IdentityService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/identity/host/Tasky.IdentityService.HttpApi.Host"
RUN dotnet build "Tasky.IdentityService.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tasky.IdentityService.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tasky.IdentityService.HttpApi.Host.dll"]