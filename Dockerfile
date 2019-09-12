FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY dotnet-api/*.csproj ./dotnet-api/
RUN dotnet restore

# copy everything else and build app
COPY dotnet-api/. ./dotnet-api/
WORKDIR /app/dotnet-api
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/dotnet-api/out ./
ENTRYPOINT ["dotnet", "aspnetapp.dll"]
