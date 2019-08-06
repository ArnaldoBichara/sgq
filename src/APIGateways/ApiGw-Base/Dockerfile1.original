FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/APIGateways/ApiGw-Base/ApiGw-Base.csproj", "src/APIGateways/ApiGw-Base/"]
RUN dotnet restore "src/APIGateways/ApiGw-Base/ApiGw-Base.csproj"
COPY . .
WORKDIR "/src/src/APIGateways/ApiGw-Base"
RUN dotnet build "ApiGw-Base.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ApiGw-Base.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiGw-Base.dll"]