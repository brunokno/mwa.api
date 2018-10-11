FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ModernStore.Api/ModernStore.Api.csproj ModernStore.Api/
COPY ModernStore.Domain/ModernStore.Domain.csproj ModernStore.Domain/
COPY ModernStore.Shared/ModernStore.Shared.csproj ModernStore.Shared/
COPY ModernStore.IoC/ModernStore.IoC.csproj ModernStore.IoC/
COPY ModernStore.Infra/ModernStore.Infra.csproj ModernStore.Infra/
COPY ModernStore.Domain.Core/ModernStore.Domain.Core.csproj ModernStore.Domain.Core/
RUN dotnet restore ModernStore.Api/ModernStore.Api.csproj
COPY . .
WORKDIR /src/ModernStore.Api
RUN dotnet build ModernStore.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ModernStore.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ModernStore.Api.dll"]
