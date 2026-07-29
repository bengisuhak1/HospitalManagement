 # Hospital Management System

A full-stack patient registration and management application developed with ASP.NET Core, ABP Framework, Entity Framework Core, and PostgreSQL.

## Features

- List registered patients
- Create new patient records
- Edit existing patient information
- Delete patient records
- Unique identity number validation
- REST API endpoints for patient operations
- PostgreSQL database integration
- Responsive web interface

## Technologies

- .NET 10
- ASP.NET Core
- ABP Framework
- Entity Framework Core
- PostgreSQL
- MVC / Razor Pages
- LeptonX Lite
- Docker
- Swagger / OpenAPI

## Project Structure

- `Domain`: Core entities and business rules
- `Application.Contracts`: DTOs and service interfaces
- `Application`: Application services and mapping
- `EntityFrameworkCore`: Database configuration and migrations
- `HttpApi`: API layer
- `Web`: User interface
- `DbMigrator`: Database migration and initial data tool

## Patient Module

The Patient module supports CRUD operations:

- Create a patient
- Read and list patient records
- Update patient information
- Delete a patient

Each patient contains:

- Identity number
- First name
- Last name
- Birth date
- Phone number

## Configuration

Sensitive configuration values are excluded from Git.

Create an `appsettings.secrets.json` file inside both:

```text
src/HospitalManagement.DbMigrator/
src/HospitalManagement.Web/