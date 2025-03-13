# Use the official .NET SDK image as the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution file and all project files
COPY *.sln .
COPY LearningPathTracking_V2/*.csproj ./LearningPathTracking_V2/
COPY LearningPathTracking_V2.Domain/*.csproj ./LearningPathTracking_V2.Domain/
COPY LearningPathTracking_V2.Infrastructure/*.csproj ./LearningPathTracking_V2.Infrastructure/
COPY LearningPathTracking_V2.Application/*.csproj ./LearningPathTracking_V2.Application/

# Restore NuGet packages for all projects
RUN dotnet restore

# Copy the source code for all projects
COPY LearningPathTracking_V2/. ./LearningPathTracking_V2/
COPY LearningPathTracking_V2.Domain/. ./LearningPathTracking_V2.Domain/
COPY LearningPathTracking_V2.Infrastructure/. ./LearningPathTracking_V2.Infrastructure/
COPY LearningPathTracking_V2.Application/. ./LearningPathTracking_V2.Application/

# Build and publish the application
WORKDIR /app
RUN dotnet publish -c Release -o out

# Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Set the environment variable to production
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80

# Make sure the app creates/updates the database on startup
# You might need to add code in Program.cs to support this

# Expose port 80
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "LearningPathTracking_V2.dll"]