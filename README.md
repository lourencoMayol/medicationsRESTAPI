# Medications REST API

This project is a simple REST API built with **.NET 8**, **Entity Framework Core**, and **SQL Server Local DB**, developed using **Visual Studio 2022**. 

It follows a **three-layer architecture** (Presentation, Business, Data) for better separation of concerns and maintainability. 
This structure was inspired by [this blog post](https://enlabsoftware.com/development/how-to-build-and-deploy-a-three-layer-architecture-application-with-c-sharp-net-in-practice.html).

---

## Technology Stack

- **.NET 8**
- **Entity Framework Core (EF Core)**
- **SQL Server Local DB**
- **Visual Studio 2022**

---

## Project Architecture

The project uses a **three-layer architecture**:

1. **Presentation Layer**  
   - Contains the controllers and API endpoints.
   - Handles HTTP requests and responses.
   
2. **Business Layer**  
   - Contains services and business logic.
   - Validates data and orchestrates operations between the presentation and data layers.
   
3. **Data Layer**  
   - Handles database access using EF Core.
   - Implements repositories for CRUD operations on entities.

---

## Features

The API base URL is: https://localhost:7102/api/medications

This REST API allows you to:

1. **Get a list of medications**  
   - Retrieve all medications stored in the database.
   - API Endpoint: https://localhost:7102/api/medications

2. **Get a specific medication by its id**  
   - Retrieve a medication by its ID.
   - API Endpoint: https://localhost:7102/api/medications/id

3. **Create a new medication**  
   - Each medication must have:
     - **Name** (string, required, cannot be empty)
     - **Quantity** (integer, must be greater than 0)
     - **Creation Date** (day, month, year)
   - API Endpoint: https://localhost:7102/api/medications
     
4. **Delete a medication**  
   - Delete a medication by its ID.
   - API Endpoint: https://localhost:7102/api/medications/id

---


## Running the Application

1. Open the project in **Visual Studio 2022**.
2. Ensure that **SQL Server Local DB** is installed and running.
3. Build the project.
4. Run the API (the default URL is `https://localhost:7102`).
5. Test endpoints using **Swagger**, Postman, or any HTTP client.

---

## Database Setup

Two SQL scripts are included in the `sqlScripts` folder:

1. `CreateDatabaseAndTable.sql` — Creates the database and `Medications` table.
2. `InsertSampleMedications.sql` — Inserts 10 sample medications for testing.

You can run these scripts in SQL Server Object Explorer or any SQL client connected to your Local DB instance.







