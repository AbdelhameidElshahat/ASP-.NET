# GameStore API Project

A .NET Core Web API project for managing video games, built with Entity Framework Core and SQLite.

## 📋 Project Overview

This project implements a RESTful API for a game store with the following features:

- CRUD operations for games
- SQLite database integration
- Entity Framework Core
- Clean architecture

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 SDK
- Visual Studio Code or Visual Studio 2022
- SQLite browser (optional)

### Installation

1. Clone the repository
    ```bash
    git clone [repository-url]
    cd GameStore
    ```

2. Install dependencies
    ```bash
    dotnet restore
    ```

3. Set up the database
    ```bash
    dotnet ef database update
    ```

4. Run the application
    ```bash
    dotnet run
    ```

## 🔌 API Endpoints

### Games

- **Get all games**
    ```http
    GET https://localhost:7170/games
    ```

- **Get a specific game**
    ```http
    GET https://localhost:7170/games/{id}
    ```

- **Create a new game**
    ```http
    POST https://localhost:7170/games
    Content-Type: application/json

    {
        "title": "Game Title",
        "genre": "Action",
        "price": 59.99,
        "releaseDate": "2024-01-01"
    }
    ```

- **Update a game**
    ```http
    PUT https://localhost:7170/games/{id}
    Content-Type: application/json

    {
        "title": "Updated Title",
        "genre": "Adventure",
        "price": 49.99,
        "releaseDate": "2024-01-01"
    }
    ```

- **Delete a game**
    ```http
    DELETE https://localhost:7170/games/{id}
    ```

## 🗄️ Project Structure

GameStore/ ├── Data/ │ ├── DBContext.cs │ └── Migrations/ ├── DTOs/ │ ├── GameDto.cs │ ├── CreateGameDto.cs │ └── UpdateGameDto.cs ├── Entities/ │ ├── Game.cs │ └── Genre.cs ├── EndPoints/ │ └── GamesEndPoints.cs └── Program.cs


## 🛠️ Development

To run the project in development mode:

```bash
dotnet watch run
Database Migrations
Create a new migration:

dotnet ef migrations add [MigrationName]
Apply migrations:

dotnet ef database update
📚 Technologies Used
ASP.NET Core 9.0
Entity Framework Core
SQLite
C# 12
🌟 Features
Full CRUD operations for games
Database persistence
Error handling
DTOs for data transfer
Clean architecture principles
Entity Framework Core integration
