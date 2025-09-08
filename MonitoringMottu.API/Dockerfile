FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MonitoringMottu.API/MonitoringMottu.API.csproj", "MonitoringMottu.API/"]
RUN dotnet restore "MonitoringMottu.API/MonitoringMottu.API.csproj"
COPY . .
WORKDIR "/src/MonitoringMottu.API"
RUN dotnet build "./MonitoringMottu.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MonitoringMottu.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MonitoringMottu.API.dll"]
