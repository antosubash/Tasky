#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/host/Tasky.SaaSService.HttpApi.Host/Tasky.SaaSService.HttpApi.Host.csproj", "services/saas/host/Tasky.SaaSService.HttpApi.Host/"]
COPY ["shared/Tasky.Shared.Hosting/Tasky.Shared.Hosting.csproj", "shared/Tasky.Shared.Hosting/"]
COPY ["services/administration/src/Tasky.AdministrationService.EntityFrameworkCore/Tasky.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/Tasky.AdministrationService.EntityFrameworkCore/"]
COPY ["services/administration/src/Tasky.AdministrationService.Domain/Tasky.AdministrationService.Domain.csproj", "services/administration/src/Tasky.AdministrationService.Domain/"]
COPY ["services/administration/src/Tasky.AdministrationService.Domain.Shared/Tasky.AdministrationService.Domain.Shared.csproj", "services/administration/src/Tasky.AdministrationService.Domain.Shared/"]
COPY ["services/saas/src/Tasky.SaaSService.HttpApi/Tasky.SaaSService.HttpApi.csproj", "services/saas/src/Tasky.SaaSService.HttpApi/"]
COPY ["services/saas/src/Tasky.SaaSService.Application.Contracts/Tasky.SaaSService.Application.Contracts.csproj", "services/saas/src/Tasky.SaaSService.Application.Contracts/"]
COPY ["services/saas/src/Tasky.SaaSService.Domain.Shared/Tasky.SaaSService.Domain.Shared.csproj", "services/saas/src/Tasky.SaaSService.Domain.Shared/"]
COPY ["services/saas/src/Tasky.SaaSService.Application/Tasky.SaaSService.Application.csproj", "services/saas/src/Tasky.SaaSService.Application/"]
COPY ["services/saas/src/Tasky.SaaSService.Domain/Tasky.SaaSService.Domain.csproj", "services/saas/src/Tasky.SaaSService.Domain/"]
COPY ["services/saas/src/Tasky.SaaSService.EntityFrameworkCore/Tasky.SaaSService.EntityFrameworkCore.csproj", "services/saas/src/Tasky.SaaSService.EntityFrameworkCore/"]
RUN dotnet restore "services/saas/host/Tasky.SaaSService.HttpApi.Host/Tasky.SaaSService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/saas/host/Tasky.SaaSService.HttpApi.Host"
RUN dotnet build "Tasky.SaaSService.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tasky.SaaSService.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tasky.SaaSService.HttpApi.Host.dll"]