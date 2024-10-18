# Ticket Manager App

## Overview

This repository contains a Ticket Manager Application built using the Domain-Driven Design (DDD) architecture in ASP.NET for the backend, and Angular for the frontend. 
The application allows users to manage hotel-related entities such as users, rooms, and reservations.

## Features

- **Domain-Driven Design (DDD):** The application is structured using DDD principles to organize code around the business domain, promoting better maintainability and scalability.

- **ASP.NET Core Web API:** The backend is developed using ASP.NET Core, providing a robust and scalable RESTful API.

- **JWT Authentication:** JSON Web Token (JWT) is implemented for secure user authentication, ensuring a reliable and stateless authentication mechanism.

- **Entity Framework Core (EF Core) In-Memory Database:** The application utilizes EF Core for data persistence, using an in-memory database for easy testing and development.

- **Repository Pattern:** The repository pattern is implemented to abstract data access logic, providing a clean separation between the application's business logic and data access code.

- **CQRS (Command Query Responsibility Segregation):** The CQRS pattern is employed to separate the read and write operations, improving scalability and simplifying code.

- **Mediator Pattern:** Mediator pattern is used to decouple components and handle communication between different parts of the application.

- **AutoMapping:** MapsterMapping is utilized for mapping between Data Transfer Objects (DTOs) and domain models, simplifying data transformation.

- **Global Error Handling:** Error handling is implemented globally to ensure consistent and meaningful error messages are returned to clients.

- **Fluent Validation:** Fluent Validation is integrated for robust input validation, providing a clean and customizable way to validate requests.

- **Xunit:** For writing unit test.

- **Moq:** For Mocking the services in Unit test.

- **Shouldy:** For Writing flunt Assertions in the unit test.


## Frontend

The frontend of the application is built using Angular, with Angular Bootstrap components for a sleek and responsive user interface.