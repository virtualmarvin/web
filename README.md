# Marvin Web

## Getting Started

1. Build `Ctrl+F5` 🏗
2. Migrate `update-database` 📅
3. Hit F5 🚀

## Adding the user secrets

To use Google and Facebook login you need to ensure the secrets are added

### Facebook Secrets

```
dotnet user-secrets set "Authentication:Facebook:AppId" "appid"
dotnet user-secrets set "Authentication:Facebook:AppSecret" "secret"
```

### Google Secrets

```
dotnet user-secrets set "Authentication:Google:ClientId" "<client-id>"
dotnet user-secrets set "Authentication:Google:ClientSecret" "<client-secret>"
```

## Data

You can choose between *MSSQL* or *PostgreSQL* databases and both connection strings have entries in the `appsettings.json` file.   
You can switch between the two by setting the `ActiveConnectionString` value to the name of the connection string that you want to use.

Select `MssqlConnection` | `PostgresConnection` depending on which one you want to use.


## Postgres

> Tested with Postgres version for windows 14.5.1

You'll have to remove any existing migration you did for MSSQL and then you can do this in the package manager:

```powershell
Add-Migration InitialPersistedGrantDbMigration -c ApplicationDbContext -o Data/Migrations

update-database
```

Now run project and it will use postgres
