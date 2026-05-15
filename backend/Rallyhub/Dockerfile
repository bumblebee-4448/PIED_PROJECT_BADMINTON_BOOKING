FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Rallyhub.Api/Rallyhub.Api.csproj", "Rallyhub.Api/"]
COPY ["Rallyhub.Repository/Rallyhub.Repository.csproj", "Rallyhub.Repository/"]
COPY ["Rallyhub.Service/Rallyhub.Service.csproj", "Rallyhub.Service/"]
RUN dotnet restore "Rallyhub.Api/Rallyhub.Api.csproj"
COPY . .
WORKDIR "/src/Rallyhub.Api"
RUN dotnet build "./Rallyhub.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Rallyhub.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rallyhub.Api.dll"]
