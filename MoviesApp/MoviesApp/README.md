## MoviesApp

MoviesApp is a simple ASP.NET Core Web API for managing movies. It follows Clean Architecture principles, separating concerns into Controllers, Services, Repositories, and Domain Models.

### Features

- CRUD operations for movies (Create, Read, Update, Delete)
- Filter movies by Year and Genre
- Validation and error handling using custom exceptions
- Uses Entity Framework Core for database access
- Implements DTOs and Mappers for data transfer
- Dependency Injection for services and repositories
- -Swagger support for easy testing
- Technologies Used

### C#

ASP.NET Core Web API

Entity Framework Core

SQL Server

Swagger

### Project Structure

- Domain: Contains models and enums
  
- DataAccess: Repositories and database context

- Dtos: Data Transfer Objects for API requests/responses

- Mappers: Mapping between DTOs and domain models

- Services: Business logic layer

- Shared: Custom exceptions

- Helpers: Dependency injection and other helpers

- Controllers: API endpoints

### => About This Project

This project was created as a learning exercise to practice building scalable Web APIs using ASP.NET Core, Entity Framework Core, and Clean Architecture principles.
