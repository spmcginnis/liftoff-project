# Run the MongoDB Server
/db/bin/mongod --dbpath /db/data

# Run the Project
In HealthDataAPI: $ dotnet run
Data at https://localhost:5001/api/patients and .../api/hospitals

# CORS
CORS allowed on https://localhost:5001 from http://localhost:4200 only.  To change the CORS routing, adjust the URL parameters in Startup.cs.