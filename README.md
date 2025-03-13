# Learning Path Tracking API

## Project Overview
This repository contains a Learning Path Tracking API developed with C# and ASP.NET Core. It serves as a practical exercise for mastering fundamental concepts of C#, ASP.NET Core, and API development. The application allows users to track learning topics, monitor progress, and manage their learning path.

## Features
- Track learning topics with progress indicators
- Status management for learning items (Not Started, In Progress, Completed)
- RESTful API endpoints for CRUD operations
- Custom response formatting for consistent API responses
- Entity Framework Core with SQLite database integration
- Separation of concerns using repository pattern
- Service-based architecture
- Extension method organization

## Technologies Used
- ASP.NET Core 8.0
- Entity Framework Core
- SQLite Database
- C# 12
- RESTful API design principles

## Prerequisites
- .NET 8.0 SDK or later
- Visual Studio 2022, VS Code, or JetBrains Rider
- Git

## Getting Started

### Installation
1. Clone the repository:
   ```
   git clone https://github.com/ThanhTNV/LearningPathTrackingApi.git
   cd LearningPathTrackingApi
   ```

2. Restore dependencies:
   ```
   dotnet restore
   ```

3. Build the project:
   ```
   dotnet build
   ```

### Database Setup
The project uses SQLite by default. The connection string is configured in `appsettings.json`.

1. To update the database with the initial migration:
   ```
   dotnet ef database update
   ```

2. To modify the connection string, update the `DefaultConnection` in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=your_database_name.db"
   }
   ```

### Running the Application
1. Run the application:
   ```
   dotnet run --project ./LearningPathTracking-V2.API/LearningPathTracking-V2.API.csproj
   ```

2. The API will be available at:
   - https://localhost:7066
   - http://localhost:5287

### API Endpoints
- `GET /api/LearningTopics` - Get all learning topics
- `GET /api/LearningTopics/{id}` - Get a specific learning topic
- `POST /api/LearningTopics` - Create a new learning topic
- `PUT /api/LearningTopics/{id}` - Update an existing learning topic
- `DELETE /api/LearningTopics/{id}` - Delete a learning topic

## Project Structure
- `LearningPathTracking-V2.API` - API controllers and configuration
- `LearningPathTracking-V2.Domain` - Domain entities and models
- `LearningPathTracking-V2.Infrastructure` - Data access layer with repositories
- `LearningPathTracking-V2.Application` - Business logic and services

## Key Concepts Covered
- Custom API response handling
- Dependency injection
- Repository and service patterns
- Entity Framework Core configuration
- .NET extension methods
- RESTful API design

## Contributing
This project is primarily for learning purposes. If you'd like to contribute or suggest improvements:
1. Fork the repository
2. Create a feature branch
3. Submit a pull request

## License
This project is open-source and available for educational purposes.

## Acknowledgements
- Microsoft ASP.NET Core documentation
- Entity Framework Core documentation
