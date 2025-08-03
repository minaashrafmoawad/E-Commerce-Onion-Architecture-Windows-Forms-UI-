# E-Commerce Application

## Overview
This is a Windows Forms-based E-Commerce application built using .NET and following Clean Architecture (Onion Architecture) principles. The application provides a complete shopping experience with separate interfaces for users and administrators.

## Architecture
The project follows Onion Architecture with clear separation of concerns:

### Layers
- **Models** - Core domain entities (User, Product, Order, Category, etc.)
- **Application** - Application business logic and interfaces
- **Infrastructure** - Data access and repository implementations
- **Presentation** - Windows Forms UI components

## Features

### User Features
- User Registration and Login
- Product Browsing and Search
- Shopping Cart Management
- Order Placement and History
- Profile Management
- Password Management

### Admin Features
- Product Management
- Category Management
- User Management
- Order Management
- Admin Dashboard

## Technical Stack
- **.NET Framework**
- **Entity Framework Core** - For data access and ORM
- **Windows Forms** - For the desktop UI
- **Mapster** - For object mapping
- **Clean Architecture** - For maintainable and testable code structure

## Project Structure

```
├── Application/
│   ├── Contracts/         # Repository interfaces
│   ├── DTOs/              # Data Transfer Objects
│   ├── Services/          # Business logic services
│   └── Mapping/           # Object mapping configurations
├── Context/
│   └── AppDbContext      # Entity Framework context
├── Infrastructure/
│   └── Repositories/     # Repository implementations
├── Models/
│   ├── Entities/         # Domain entities
│   └── Configurations/   # Entity configurations
└── E-commerce.Presentation/
    └── Forms/            # Windows Forms UI components
```

## Getting Started
1. Clone the repository
2. Ensure you have .NET Framework installed
3. Update the connection string in AppDbContext
4. Run the application

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
