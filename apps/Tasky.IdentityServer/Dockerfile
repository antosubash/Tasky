#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["apps/Tasky.IdentityServer/Tasky.IdentityServer.csproj", "apps/Tasky.IdentityServer/"]
RUN dotnet restore "apps/Tasky.IdentityServer/Tasky.IdentityServer.csproj"
COPY . .
WORKDIR "/src/apps/Tasky.IdentityServer"
RUN dotnet build "Tasky.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tasky.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tasky.IdentityServer.dll"]