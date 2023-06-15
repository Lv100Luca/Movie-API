# Use the .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project file and restore the dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the source code
COPY . ./

# Build the project
RUN dotnet build -c Release

# Publish the project
RUN dotnet publish -c Release -o out

# Use the .NET runtime image as the base image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copy the published application from the build image
COPY --from=build /app/out .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "SOFTW2_Uebungen.dll"]