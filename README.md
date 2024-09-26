# Voolt Technical Challenge (Ads List App)

## Purpose

The purpose of this project is to create a simple ads list app that allows users 
to list and create/update Ads.


## Project Structure

The project is structured as follows:


### Backend

The backend is a .NET 8 Web API structured as follows:

- **Api**: Contains the endpoints definitions, middleware and an [Http file](https://learn.microsoft.com/en-us/aspnet/core/test/http-files?view=aspnetcore-8.0) which can be used to test the endpoints.
- **Application**: Contains the models, business logic, repositories and services.
- **Contracts**: Contains the interfaces for the endpoints (requests and responses). These items were moved to a separate project so that, if necessary, they might be distributed to API consumers (e.g. by creating a Nuget package).


### Frontend

The frontend is a .NET 8 Blazor Web App with both the Server and Client projects. 
It follows the Blazor Web App template structure, with a server project serving as the entry point 
of the application and server-side rendered components (both static and interactive) 
and a client project containing the components and pages rendered in the client side (WebAssembly).


### Shared

The shared project contains items shared by both the backend and frontend projects.


## Running the Project

1. Clone this repository or download a ZIP archive of the repository.

1. The default and fallback URLs for the two apps are:

   - `VooltChallenge.Api` app (`BackendUrl`): `https://localhost:7292` (fallback: `https://localhost:5276`)
   - `VooltChallenge.Ui` app (`FrontendUrl`): `https://localhost:7192` (fallback: `https://localhost:5176`)
   
   You can use the existing URLs or update them in the `appsettings.json` files:

   - `appsettings.json` file in the root of the `VooltChallenge.Api` app.
   - `VooltChallenge.Ui/appsettings.json` file in the `VooltChallenge.Ui` app.
   - `VooltChallenge.Ui.Client/wwwroot/appsettings.json` file in the `VooltChallenge.Ui.Client` app.
  
1. If you plan to run the apps using the .NET CLI with `dotnet run`, note that first launch profile in the launch settings file is used to run an app, which is the insecure `http` profile (HTTP protocol). To run the apps securely (HTTPS protocol), take ***either*** of the following approaches:

   - Pass the launch profile option to the command when running the apps: `dotnet run -lp https`.
   - In the launch settings files (`Properties/launchSettings.json`) ***of both projects***, rotate the `https` profiles to the top, placing them above the `http` profiles.
  
   If you use Visual Studio to run the apps, Visual Studio automatically uses the `https` launch profile. No action is required to run the apps securely when using Visual Studio.

1. Run the `VooltChallenge.Api` and `VooltChallenge.Ui` apps.

1. Navigate to the `VooltChallenge.Ui` app at the `FrontendUrl`.


## Technology stack used

- .NET 8 (C# 12)
- [Minimal Apis](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-8.0) with [output caching middleware](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/output?view=aspnetcore-8.0)
- EF Core 8 (In-Memory Database)
- Blazor
- [FluentValidation](https://fluentvalidation.net/)
- [Fluent UI](https://www.fluentui-blazor.net/)
- [Bogus](https://github.com/bchavez/Bogus) (for generating fake data)


## Improvement points

- Add a real database (e.g. SQL Server or PostgreSQL)
- Add authentication and authorization
- Add logging
- Add a delete endpoint
- Add filtering, sorting and pagination for the list endpoint (and implement it in the frontend)
- Add tests (unit, integration, architectural)
- Create a CI/CD pipeline (e.g. GitHub Actions or Azure DevOps)
