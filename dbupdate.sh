#!/bin/bash

# Set the working directory to your solution root where your .sln file is located
# Replace "/path/to/your/solution" with the actual path to your solution

# Define the name of the infrastructure project
infrastructure_project='SUKiiServer.Infrastructure'
startup_project="../SUKiiServer"

# Run Entity Framework migrations for the infrastructure project

dotnet ef migrations add --startup-project $startup_project --default-project $infrastructure_project
# Check the exit code of the 'dotnet ef' command
if [ $? -eq 0 ]; then
  echo "Database migration completed successfully."
else
  echo "Database migration failed."
fi
