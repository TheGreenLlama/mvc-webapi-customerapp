I have included the SQL script for creating the SQL Server database. I have been using 2022 but I've exported as 2019 just in case ;-)

To test the project - modify the CustomerDB connection string in:

ARP.CustomerApp.API > appsettings.Development.json

Set both ARP.CustomerApp.API and ARP.CustomerApp.WebUI as startup projects - or simply start API /then/ WebUI (or the other way around if you want to test the error handling!)
