# Planetarium
ASP.NET Core app to simulate planetarium. Written for portfolio. Polish language.

# How to use it?
- clone this repositorium
- open solution
- find appsettings.json and add your own connectionString as below:
	
	- "PlanetariumConnection": "Server=localhost;port=;user=;password=;database=planetarium;
	
- after connecting to your MySQL server, in NuGet command prompt use commands:

	- enable-migrations
	- add-migration "Initial migration"
	- update-database

- if those 3 commands won't cause any problem, your app is ready for usage. Enjoy!