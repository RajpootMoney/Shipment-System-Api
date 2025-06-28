# 🔨 Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and project files
COPY *.sln .
COPY ShipmentSystem.API/*.csproj ./ShipmentSystem.API/
COPY ShipmentSystem.Application/*.csproj ./ShipmentSystem.Application/
COPY ShipmentSystem.Infrastructure/*.csproj ./ShipmentSystem.Infrastructure/
COPY ShipmentSystem.Domain/*.csproj ./ShipmentSystem.Domain/

# Restore packages
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /app/ShipmentSystem.API
RUN dotnet publish -c Release -o out

# 🚀 Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/ShipmentSystem.API/out .

# Expose the HTTP port
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "ShipmentSystem.API.dll"]
