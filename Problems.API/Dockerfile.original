FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Problems.API/Problemas.API.csproj", "Problems.API/"]
RUN dotnet restore "Problems.API/Problemas.API.csproj"
COPY . .
WORKDIR "/src/Problems.API"
RUN dotnet build "Problemas.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Problemas.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Problemas.API.dll"]
