FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Rallyhub.Api/Rallyhub.Api.csproj", "Rallyhub.Api/"]
COPY ["Rallyhub.Repository/Rallyhub.Repository.csproj", "Rallyhub.Repository/"]
COPY ["Rallyhub.Service/Rallyhub.Service.csproj", "Rallyhub.Service/"]

RUN dotnet restore "Rallyhub.Api/Rallyhub.Api.csproj"

COPY . .

WORKDIR "/src/Rallyhub.Api"
RUN dotnet publish "Rallyhub.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Rallyhub.Api.dll"]