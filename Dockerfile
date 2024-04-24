# Use Microsoft's official build .NET image.
# https://hub.docker.com/_/microsoft-dotnet-core-sdk/
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy csproj and restore dependencies
COPY HelloWorld/HelloWorld.csproj HelloWorld/
RUN dotnet restore HelloWorld/HelloWorld.csproj

# Copy everything else and build the app
COPY HelloWorld/. HelloWorld/
RUN dotnet publish -c Release -o out HelloWorld/HelloWorld.csproj

# Use Microsoft's official runtime .NET image.
# https://hub.docker.com/_/microsoft-dotnet-core-aspnet/
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app
COPY --from=build /app/out ./

# Make sure the app runs on startup
ENTRYPOINT ["dotnet", "HelloWorld.dll"]