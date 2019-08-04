FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["APIGateways/ApiGw-Base/OcelotAPIGw.csproj", "APIGateways/ApiGw-Base/"]
RUN dotnet restore "APIGateways/ApiGw-Base/OcelotAPIGw.csproj"
COPY . .
WORKDIR "/src/APIGateways/ApiGw-Base"
RUN dotnet build "OcelotAPIGw.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OcelotAPIGw.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OcelotAPIGw.dll"]