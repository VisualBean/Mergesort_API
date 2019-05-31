# Mergesort_API

## Getting started
### Prerequisites
A windows machine.
###
  1. Please clone or download the project.
  
I highly encourage you to open a terminal in the project location.

### Build
run `\.build.ps1` in the project folder.  
The script, builds the solution, runs the tests and publishes the release version of the service.  
The release version is published to `Mergesort_API\bin\Release\netcoreapp2.2\win-x64`

### Run
run ```\.run.ps1``` in your terminal of choice or run the powershell script directly (right click -> Run in powershell).
This will run the service in the console as a selfhosted api.

## Using it
The API starts a webserver on https://localhost:5001 
The documentation is in the root of the url, so please browse to https://localhost:5001 for the swagger docs

### Supported endpoints
Endpoints that are supported are
1. [POST]/api/mergesort
  * Input: a json array of integers
  * Output: A job model
2. [GET] /api/mergesort/executions/{id}
  * Input: a job id
  * Ouput: a job
3. [GET] /api/mergsort/executions
  * Ouput: A list of jobs
