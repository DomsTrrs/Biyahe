🚌 Biyahe — Smart Jeepney Queueing and Tracking System

A modern C# WinForms application that simulates a real-world jeepney dispatch, passenger queueing, and live route tracking system for public transportation terminals in the Philippines.

Built using a layered architecture with SQL Server, WinForms, WebView2, and Leaflet.js to practice real-world software engineering concepts such as:

Layered Architecture
Repository Pattern
Authentication Systems
Queue Algorithms
Real-Time Location Tracking
SQL Database Design
Service-Oriented Logic
Event-Driven Programming
📌 Project Overview

Biyahe digitizes the traditional jeepney terminal process by introducing:

Organized digital passenger queues
Senior/PWD priority handling
Driver route assignment
Real-time jeepney tracking
Route-based dispatching
SQL-backed persistent storage

The system is designed to simulate how modern transportation queueing systems work while reinforcing industry-standard development practices.

✨ Core Features
👤 Passenger Features
Register and log in
Join a route queue
View queue position
Refresh queue status
Senior/PWD priority support
🚐 Driver Features
Log in as driver
Select operational route
View live passenger queue
Call next passenger
Board passengers
Open/Close boarding
View available slots
🗺️ Map & Tracking Features
Embedded interactive map using WebView2 + Leaflet.js
Route polyline rendering
Live simulated jeepney movement
Route stop visualization
Real-time location saving to database
🏗️ System Architecture

Biyahe follows a clean 4-Layer Architecture:

[ UI Layer ]
      ↓
[ Services Layer ]
      ↓
[ DataAccess Layer ]
      ↓
[ SQL Server Database ]
🖥️ UI Layer

Responsible only for:

Displaying information
Accepting user input

Contains:

LoginForm
PassengerForm
DriverForm
RegisterForm
🧠 Services Layer

Contains all business logic and application rules.

Examples:

Authentication validation
Queue prioritization
FIFO queue sorting
Route coordinate formatting
🗄️ DataAccess Layer

Responsible only for database communication.

Contains:

SQL queries
INSERT / SELECT / UPDATE operations
Repository classes
🗃️ Database Layer

Stores:

Users
Drivers
Queue entries
Routes
Route stops
Locations
🧱 Technologies Used
Technology	Purpose
C#	Main programming language
WinForms (.NET 6/8)	Desktop UI
SQL Server Express	Database
Microsoft.Data.SqlClient	SQL connectivity
WebView2	Embedded browser
Leaflet.js	Interactive maps
Git & GitHub	Version control
📂 Project Structure
BiyaheApp/
│
├── UI/
│   ├── LoginForm.cs
│   ├── PassengerForm.cs
│   ├── DriverForm.cs
│   └── RegisterForm.cs
│
├── Models/
│   ├── User.cs
│   ├── Driver.cs
│   ├── Route.cs
│   ├── RouteStop.cs
│   ├── QueueEntry.cs
│   └── Location.cs
│
├── DataAccess/
│   ├── UserRepository.cs
│   ├── DriverRepository.cs
│   ├── QueueRepository.cs
│   ├── RouteRepository.cs
│   └── LocationRepository.cs
│
├── Services/
│   ├── AuthService.cs
│   ├── QueueService.cs
│   ├── RouteService.cs
│   └── LocationService.cs
│
├── Map/
│   └── map.html
│
├── Config/
│   └── DatabaseConfig.cs
│
└── Utils/
🧠 Queueing Algorithm

Biyahe uses a Priority + FIFO queue system.

Queue Rules
Senior citizens and PWDs are prioritized first
Within the same priority level:
First Joined → First Served

Implemented using:

.OrderBy(x => x.Priority)
.ThenBy(x => x.JoinedAt)

This mirrors real-world queueing systems used in:

Hospitals
Airports
Banks
Transportation terminals
🗄️ Database Design

Main Tables:

Table	Purpose
Users	Passenger accounts
Drivers	Driver accounts
Routes	Master route list
RouteStops	Ordered stops per route
Queue	Passenger queue records
Location	Driver GPS simulation data
🗺️ Route Tracking System

The map system uses:

WebView2 for browser embedding
Leaflet.js for rendering maps
OpenStreetMap tiles
JavaScript interop via ExecuteScriptAsync()

Features:

Draw full jeepney routes
Show stop markers
Simulate moving jeepney positions
Save live coordinates to SQL Server
🔐 Security Notes

Current version uses:

Parameterized SQL queries
Basic validation

Planned improvements:

BCrypt password hashing
Stronger validation
Authentication hardening
🚀 Getting Started
1. Clone Repository
git clone <your-repository-url>
2. Install Requirements

Required software:

Visual Studio 2022
SQL Server Express
SQL Server Management Studio (SSMS)
.NET 6 or .NET 8 SDK
WebView2 Runtime
3. Configure Database

Create:

BiyaheDB

Run all SQL scripts to create tables.

4. Configure Connection String

Inside:

Config/DatabaseConfig.cs

Example:

public static string ConnectionString =
    @"Server=.\SQLEXPRESS;Database=BiyaheDB;Trusted_Connection=True;";
5. Install NuGet Packages

Required packages:

Microsoft.Data.SqlClient
Microsoft.Web.WebView2
6. Run the Application
Start Debugging (F5)
🧪 Testing Flow

Recommended end-to-end test flow:

Register
   ↓
Login
   ↓
Passenger joins queue
   ↓
Driver views queue
   ↓
Driver boards passenger
   ↓
Map updates location
🎯 Learning Objectives

This project was built to practice:

Object-Oriented Programming
Layered Architecture
SQL Relationships
Repository Pattern
Service Layer Design
Queue Algorithms
Event-Driven Programming
Database Normalization
Git Workflow
Real-World System Design
📈 Future Improvements

Planned enhancements:

BCrypt password hashing
Admin dashboard
Queue cancellation
Passenger notifications
Analytics dashboard
Multi-driver route management
Real GPS integration
REST API backend migration
📖 Developer Notes

This project emphasizes:

Separation of Concerns
Scalable architecture
Clean layering
Maintainability
Incremental feature development

SQL queries are intentionally isolated inside the DataAccess layer, while business rules remain inside Services.

🤝 Acknowledgements

Built as a learning-focused transportation systems project inspired by real-world jeepney dispatch operations in the Philippines.

📜 License

This project is for educational and portfolio purposes.
