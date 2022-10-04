# Marvin Web

## Getting Started

- Create a new SQL Server database and call it `Marvin`
- Then run the CreateDb.txt script file
  - This will create and populate several Thing tables

Now run the application!

## Authentication

Enable secret storage. 

```cmd
dotnet user-secrets init
```

Store the sensitive strings using the following

```cmd
dotnet user-secrets set "Authentication:Google:ClientId" "<client-id>"
dotnet user-secrets set "Authentication:Google:ClientSecret" "<secret>"
```