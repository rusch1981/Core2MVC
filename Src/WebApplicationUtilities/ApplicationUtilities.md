# ApplicationUtilities

### Email Utility
The **IEmail** Interface is used for _Simple Mail Transfer Protocol_.  
The current implementation **Email** requires the calling assembly to have
an **appsetting.json** file with the below information:  

* Required:  all 

```json
{
"EmailConfig": {
    "EmailAccount": EmailAccount:string,
    "Credentials": Credentials:string,
    "ErrorEmailAddress": ErrorEmailAddress:string,
    "ToEmail": ToEmail:string,
    "SmtpHost": smtpHost:string,
    "EnableSsl": EnableSsl:boolean,
    "SmtpPort": smtpPort:int
  }
}
```