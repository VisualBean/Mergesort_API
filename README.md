# Mergesort_API

## Getting started - Local windows machine edition
### Prerequisites
A windows machine.
###
  1. Please clone or download the project.
  
I highly encourage you to open a terminal in the project location.

### Build
run `.\build.ps1` from the root of the project, either in your terminal of choice or run the powershell script directly (right click -> Run in powershell).  
The script, builds the solution, runs the tests and publishes the release version of the service.  
The release version is published to `Mergesort_API\bin\Release\netcoreapp2.2\win-x64`  

### Run
run ```.\run.ps1``` from the root of the project, either in your terminal of choice or run the powershell script directly (right click -> Run in powershell).  
This will run the service in the console as a selfhosted api.  

## Using it
The API starts a webserver on http://localhost:5000  
The documentation is in the root of the url, so please browse to http://localhost:5000 for the swagger docs  

## Getting started - Docker aka. serious business edition.

### Build & Run
1. Run `docker build -t mergesort .` from the root of the project.  
2. Run `docker run -d -p 5000:5000 --name sorting-api mergesort`

Now you can go to http://localhost:5000 to browse the swagger docs and test it out.

