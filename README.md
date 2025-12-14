# Disaster-Relief-Donation-Manager
A web-based logistics system built with ASP.NET and SQL Server to manage humanitarian aid, donations, and collection centers for natural disasters.
## Project Context

This project was developed for the "Desarrollo de Aplicaciones Informáticas" (Computer Application Development) course at ITAM. [cite_start]The goal was to build a robust web system capable of handling distinct user roles, session management, and database operations to solve a specific social need[cite: 4, 5].

The application addresses the chaos that often ensues during disaster relief by centralizing information regarding:
* **Disasters:** Earthquakes, hurricanes, floods, etc.
* **Logistics:** Collection centers and their current inventory levels.
* **Donations:** Tracking inputs from donors to specific distribution points.

## Key Features

[cite_start]The system is divided into two distinct functional profiles as per the project requirements[cite: 7]:

### 1. Administrator Profile
Designed for logistical coordinators, this module includes:
* [cite_start]**CRUD Operations:** Full management (Create, Read, Update, Delete) of Catalogues, including Disasters, Supplies (Insumos), and Collection Centers (Centros de Acopio)[cite: 7].
* **Inventory Management:** Tracking supplies received by centers.
* [cite_start]**Flexible Reporting:** A dynamic reporting module allowing administrators to filter data (e.g., donations by date, specific disaster impact)[cite: 7].
* [cite_start]**Session Security:** Protected access with automatic timeout after 30 minutes of inactivity[cite: 7].

### 2. General User Profile
Designed for donors and affected individuals:
* **Donation Registration:** Users can register donations of specific items (clothes, food, medicine).
* **Center Locator:** Ability to view available collection centers and their needs.
* **Information Access:** View details about current active disasters (Siniestros).

## Technical Implementation

* [cite_start]**Framework:** .NET Framework (ASP.NET Web Forms)[cite: 4].
* [cite_start]**Language:** C#[cite: 4].
* **Database:** SQL Server.
* **Frontend:** ASPX Pages with server-side controls.
* **Architecture:**
    * **Data Layer:** Relational database managing entities such as `Desastre`, `Siniestro`, `CentroAcopio`, and `Donacion`.
    * **Logic Layer:** C# code-behind files handling authentication (`loginAdmin.aspx`), database connections (`conexionBD.cs`), and business logic.
    * **Presentation Layer:** Web forms for user interaction (e.g., `pDonador1.aspx`, `agregarCentro.aspx`).

## Database Structure

The project relies on a relational database designed to ensure data integrity across the relief chain. Key tables include:
* **Siniestro (Disaster Event):** Links a disaster type (e.g., Hurricane) to a specific geographic location (City/State).
* **CentroAcopio (Collection Center):** Stores location and inventory data.
* **TieneCentroAcopio:** Join table tracking inventory levels of specific supplies at specific centers.
* **Donacion & Recibe:** Tracks the flow of goods from a `Persona` to a `CentroAcopio`.

## Installation and Usage

1.  **Clone the repository.**
2.  **Database Setup:**
    * Open SQL Server Management Studio (SSMS).
    * Execute the script `Proyecto1Q1.1.sql` located in the root folder. This will create the database `Proyecto1`, generate the required tables, and populate them with initial seed data (states, cities, and common disaster types).
3.  **Application Setup:**
    * Open the solution file in Visual Studio.
    * Verify the connection string in `src/conexionBD.cs` or `Web.config` matches your local SQL Server instance.
    * Build and Run the project (IIS Express).
4.  **Access:**
    * Navigate to `loginAdmin.aspx` to access administrative features (Default credentials can be found in the SQL seed data).
    * Navigate to `p1.aspx` or `menuAdmin.aspx` for the main dashboard.

## Academic Credits

* [cite_start]**Institution:** Instituto Tecnológico Autónomo de México (ITAM)[cite: 9].
* [cite_start]**Course:** Desarrollo de Aplicaciones Informáticas (Project 1)[cite: 1].
* **Professor:** Dra. [cite_start]Alejandra Flores Mosri[cite: 8].
* **Student:** Bruno Daniel Pérez Vargas.
