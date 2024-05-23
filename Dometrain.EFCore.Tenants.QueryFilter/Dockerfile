FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Dometrain.EFCore.Tenants.QueryFilter/Dometrain.EFCore.Tenants.QueryFilter.csproj", "Dometrain.EFCore.Tenants.QueryFilter/"]
RUN dotnet restore "Dometrain.EFCore.Tenants.QueryFilter/Dometrain.EFCore.Tenants.QueryFilter.csproj"
COPY . .
WORKDIR "/src/Dometrain.EFCore.Tenants.QueryFilter"
RUN dotnet build "Dometrain.EFCore.Tenants.QueryFilter.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Dometrain.EFCore.Tenants.QueryFilter.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dometrain.EFCore.Tenants.QueryFilter.dll"]
