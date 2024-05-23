FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Dometrain.EFCoreTenants.Databases/Dometrain.EFCoreTenants.Databases.csproj", "Dometrain.EFCoreTenants.Databases/"]
RUN dotnet restore "Dometrain.EFCoreTenants.Databases/Dometrain.EFCoreTenants.Databases.csproj"
COPY . .
WORKDIR "/src/Dometrain.EFCoreTenants.Databases"
RUN dotnet build "Dometrain.EFCoreTenants.Databases.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Dometrain.EFCoreTenants.Databases.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dometrain.EFCoreTenants.Databases.dll"]
