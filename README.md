# Job Application Tracker

A simple Job Application Tracker built using ASP.NET Core MVC, ASP.NET Core Web API, Entity Framework Core, and SQL Server.

I created this project to practice building an MVC application that communicates with a separate Web API and performs CRUD operations using a SQL Server database.

## Features

- View all job applications
- Add a new job application
- Edit existing application details
- Delete a job application
- Track company name, job role, application date, and application status

## Technologies Used

- ASP.NET Core MVC
- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- HTML, CSS, Bootstrap
- HTTP Client for MVC and API integration

## Project Structure

The solution contains two separate projects:

- **JobTracker.API** — Handles API requests and database operations.
- **JobTracker.MVC** — Provides the user interface and communicates with the Web API.

## How It Works

The MVC application sends HTTP requests to the Web API. The API uses Entity Framework Core to interact with SQL Server and returns the requested data to the MVC application.

## How to Run

1. Clone this repository.
2. Open `JobTracker.sln` in Visual Studio.
3. Configure the SQL Server connection string in `appsettings.json` for the API project.
4. Apply the Entity Framework Core migrations if the database has not been created.
5. Configure Visual Studio to start both `JobTracker.API` and `JobTracker.MVC`.
6. Run the solution and open the MVC application in your browser.

## What I Learned

Through this project, I practised creating REST API endpoints, using Entity Framework Core with SQL Server, implementing CRUD operations, and connecting an ASP.NET Core MVC application with a separate Web API.

## Future Improvements

- Add search and filtering for job applications.
- Improve form validation and error handling.
- Add user authentication.
- Improve the user interface.

---

**Developed by Shreyash Katiyar**
