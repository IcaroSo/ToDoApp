# ToDo Application

A simple and intuitive task management application built with ASP.NET Core 8.0 and PostgreSQL.

## Features

- Create, read, update and delete tasks
- Organize tasks into categories/lists 
- User authentication and authorization
- Clean and responsive user interface
- RESTful API endpoints
- Real-time updates

## Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core 9.0
- PostgreSQL Database
- BCrypt for password hashing
- Bootstrap 5 for UI
- jQuery for dynamic interactions

## Prerequisites

- .NET 8.0 SDK
- PostgreSQL Server
- Visual Studio 2022 or VS Code

## Getting Started

1. Clone the repository:
```bash
git clone https://github.com/yourusername/ToDoApp.git
```

2. Update database connection string in appsettings.json:
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=todo_db;Username=your_user;Password=your_password"
  }
}
```

3. Apply database migrations:
```bash
dotnet ef database update
```

4. Run the application:
```bash
dotnet run
```

## Project Structure
TodoApp/
- Controllers/ # API and MVC controllers
- Models/ # Data models and DTOs
- Services/ # Business logic layer
- Views/ # Razor views
- wwwroot/ # Static files (CSS, JS, images)
- Data/ # Database context and migrations


## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | /api/todos | Get all todos |
| GET    | /api/todos/{id} | Get specific todo |
| POST   | /api/todos | Create new todo |
| PUT    | /api/todos/{id} | Update todo |
| DELETE | /api/todos/{id} | Delete todo |

## Testing

Run the tests using:

```bash
dotnet test
```
