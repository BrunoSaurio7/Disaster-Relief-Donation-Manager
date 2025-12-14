# Disaster-Relief-Donation-Manager
A web-based logistics system built with ASP.NET and SQL Server to manage humanitarian aid, donations, and collection centers for natural disasters.
## Project Context

This project was developed for the "Desarrollo de Aplicaciones Informáticas" course at ITAM. The objective was to create a web application using .NET Framework (C#) that satisfies specific architectural requirements, including role-based security, session management, and dynamic reporting.

While the course allowed for flexible topics, this solution specifically addresses the logistical challenges of disaster relief, tracking events (Siniestros), donations, and inventory across multiple collection centers.

## Key Features

The application is divided into two security profiles based on the project requirements:

### 1. Administrator Profile
Accessed via `loginAdmin.aspx`, this module allows authorized personnel to manage the system's core data:
* **Disaster Management:** Register and remove disaster types (e.g., Earthquakes, Hurricanes) and specific events linked to geographic locations.
* **Collection Center Management:** Add or delete collection centers (`agregarCentro.aspx`, `borrarCentro.aspx`) and monitor their inventories.
* **Supply Catalog:** Manage the list of acceptable donation items (`agregarInsumo.aspx`).
* **Flexible Reporting:** A dedicated module (`reportes.aspx`) that allows administrators to generate dynamic reports based on specific criteria, such as inventory levels or affected areas.

### 2. Public User Profile
Designed for the general public, accessible via the main portal:
* **Donor Interface:** Allows users to register donations (`pDonador1.aspx`), specifying the type and quantity of supplies (`TieneDonacion`).
* **Affected User Interface:** Provides a view for individuals in affected areas (`pAfectado.aspx`) to consult available aid or register their status linked to a specific disaster event (`Afecta` table).

## Technical Architecture

* **Framework:** ASP.NET Web Forms (.NET Framework).
* **Language:** C#.
* **Database:** SQL Server.
* **Session Management:** Implements secure session handling with a 30-minute inactivity timeout, ensuring isolation between Administrator and General User sessions.

## Database Structure

The system uses a relational database to maintain data integrity:
* **Entities:** `Persona` (Users), `Administrador` (Admins), `CentroAcopio` (Logistics Hubs).
* **Events:** `Desastre` (Category) and `Siniestro` (Specific Event linked to `Ciudad`).
* **Logistics:** * `Donacion`: Tracks the date and donor.
    * `TieneDonacion`: Detail table linking donations to specific supplies (`Insumo`).
    * `TieneCentroAcopio`: Inventory table tracking current stock at each center.
    * `Recibe`: Tracks the reception of donations at specific centers.

## Installation and Setup

1.  **Database Configuration:**
    * Open SQL Server Management Studio.
    * Execute the `Proyecto1Q1.1.sql` script included in the repository. This will create the `Proyecto1` database, all required tables, and populate catalogs (States, Cities, Disaster Types).
2.  **Project Initialization:**
    * Open the solution file in Visual Studio.
    * Verify the connection string in `conexionBD.cs` or `Web.config` matches your SQL Server instance.
    * Build the solution to restore NuGet packages.
3.  **Execution:**
    * Run the project using IIS Express.
    * To test the Administrator features, navigate to `loginAdmin.aspx` (Use credentials from the `Administrador` table in the SQL script).
    * To test User features, start at `p1.aspx`.

## Academic Credits

* **Institution:** Instituto Tecnológico Autónomo de México (ITAM)
* **Course:** Desarrollo de Aplicaciones Informáticas
* **Professor:** Dra. Alejandra Flores Mosri
* **Student:** Bruno Daniel Pérez Vargas
