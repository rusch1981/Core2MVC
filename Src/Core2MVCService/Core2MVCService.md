# Core2MVCService

Essential CRUD and I/O service for the Core2WebApplication.  

### ApplicantServices 
**ISaveApplicant** and **IProcessApplicants** are the public 
interfaces for this services.  The current implementations require the below
configurations.  Although, IoC/StructureMap is not technical requirement it
is recommended.

#### AppSettings Configuration
* Required:  all 

```json
{
  "UploadPath": "/Uploads/UploadFiles/",
  "ConnectionString": "[YourConnectionString]"
}
```

##### IoC Configuration
StructureMap is utilized to inject implementation of the public api for this service. 
Simply, include the registry.  
Example: `IncludeRegistry<Core2MVCServiceRegistry>();`