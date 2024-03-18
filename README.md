# PLACE MY ORDER

> Progetto per esame di Programmazione Enterprise

## 🚩 Table of Contents
- [Requirements](#requirements)
- [Setup](#setup)
- [Project Specifications](#project-specifications)


## Requirements
To run the code locally you need:
 - [.Net 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed on your machine
 - optional [.net Entity Framework Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) if you use VSCode or another editor other than the VISUAL STUDIO ide
 - optional [SQL Server](https://www.microsoft.com/it-it/sql-server/sql-server-downloads) if you do not have access to a remote instance or on a [docker container](https://learn.microsoft.com/it-it/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&tabs=cli&pivots=cs1-bash)

## Setup
<p>Clone the project.</p>
<p>Open the PlaceMyOrder.Api/appsettings.json file and replace the connection string contained in "PlaceMyOrderConnectionString" with your database(local, docker, remote)</p>
<p>After installing .NET Core CLI run from the command line</p>
```console
	dotnet ef database update
```
<p>This will create the table structure inside the database and will populate the table with data</p>
<p>Execute the command below inside PlaceMyOrder.Api to start the application</p>
```console
	dotnet run --launch-profile "https"
```
<p>"now listening on" will appear in the console, copy the address and paste it into your browser bar by adding "swagger/index.html" (ex. https://localhost:7002/swagger/index.html)</p>

## Project Specifications

   Traccia n.05