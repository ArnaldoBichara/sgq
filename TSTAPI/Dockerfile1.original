FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TSTAPI/TSTAPI.csproj", "TSTAPI/"]
RUN dotnet restore "TSTAPI/TSTAPI.csproj"
COPY . .
WORKDIR "/src/TSTAPI"
RUN dotnet build "TSTAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TSTAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TSTAPI.dll"]
