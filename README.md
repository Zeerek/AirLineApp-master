FlightSearchApp
FlightSearchApp is a .NET-based application designed to search for flights and hotels using the Sabre API. The application consists of multiple projects including a console application for user interaction, an infrastructure project for API communication, domain models for handling flight and hotel data, and unit tests for ensuring code quality.

.NET 8 SDK or later
Visual Studio 2022 or later / Visual Studio Code
Sabre API credentials
Setup
Clone the repository:

sh
Copy code
git clone https://github.com/ibneajmal77/SabreDevApi.git
cd FlightSearchApp
Restore NuGet packages:

sh
Copy code
dotnet restore
Build the solution:

sh
Copy code
dotnet build
Configuration
Create an appsettings.json file in the FlightSearchApp.ConsoleApp project directory with the following content:
json
Copy code
{
  "SabreApi": {
    "ClientId": "your_client_id",
    "ClientSecret": "your_client_secret",
    "AuthTokenUrl": "https://api-crt.cert.havail.sabre.com/v2/auth/token",
    "FlightSearchUrl": "https://api-crt.cert.havail.sabre.com/v1/shop/flights",
    "HotelSearchUrl": "https://api-crt.cert.havail.sabre.com/v1/shop/hotels"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
