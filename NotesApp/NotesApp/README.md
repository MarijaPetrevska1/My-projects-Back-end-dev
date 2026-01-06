📝 NotesApp – ASP.NET Web API

📌 Description
NotesApp is a Web API application built with ASP.NET Core that allows managing notes and users.
The project is created for practicing and reviewing C#, ASP.NET Web API, Repository Pattern, Dependency Injection, DTOs, and data mapping.

🛠️ Technologies

ASP.NET Core Web API, C#, Entity Framework Core, SQL Server, ADO.NET, Dapper, LINQ

🧱 Architecture (Layered Architecture)

The project follows a clean layered architecture:

1️⃣ Domain

Models (Note, User)

Enums (Priority, Tag)

Represents the business domain

2️⃣ DataAccess

DbContext (EF Core)

IRepository<T>

Repository implementations:

Entity Framework Core

ADO.NET

Dapper

3️⃣ DTOs

NoteDto

AddNoteDto

UpdateNoteDto

Used for data transfer through the API

4️⃣ Mappers

Extension methods for mapping:

Domain → DTO

DTO → Domain

5️⃣ Helpers / Shared

Custom exceptions

Validation and helper utilities

6️⃣ Services

INoteService

NoteService

Contains business logic and validations

7️⃣ Web API

Controllers

Dependency Injection

HTTP endpoints (CRUD operations)

🔄 Application Flow

Controller → Service → Repository → Database
