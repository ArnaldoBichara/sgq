FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src

COPY scripts scripts/

COPY src/ApiGateways/*/*.csproj /src/csproj-files/
COPY src/Services/*/*/*.csproj /src/csproj-files/
COPY . .
WORKDIR "/src/src/Services/Problemas/Problemas-api"
RUN dotnet build "Problemas-API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Problemas-API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Problemas-API.dll"]