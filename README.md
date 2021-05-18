# BPS Take Home

## Prerequisites

1. Visual Studio 2019/ VSCode
2. NodeJS 
3. SQL server running instance

## Setup Instructions

1. Launch the project via SLN file for VS 2019 or via Open folder option in VSCode
2. Ensure DB configuration is provided in BPSTakeHome.WebUI -> appsettings.Development.json in the DbConnectionString config.
3. For VS 2019/ VSCode, please ensure the startup project is set to BPSTakeHome.WebUI
4. Launch the project
5. Browser should launch automatically ( http://localhost:30629)

## Technologies

- .Net Core
- Angular 8

## Architecture

This project uses the Angular + .Net Core boilerplate from Microsoft.
Backend follows the Onion architecture with repository pattern for db access.

## Contact Info

Please feel free to reach out to hasnain.shahzeb@gmail.com for any question or queries.

## Personal Note

I have tried to keep this code as simple as possible. There is certainly alot of space for improvement