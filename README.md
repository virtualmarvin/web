# Marvin Web

## Getting Started

## Adding the user secretes

To use Google and Facebook login you need to ensure the secrets are added

### Facebook Secrets

dotnet user-secrets set "Authentication:Facebook:AppId" "appid"
dotnet user-secrets set "Authentication:Facebook:AppSecret" "secret"

### Google Secrets

dotnet user-secrets set "Authentication:Google:ClientId" "<client-id>"
dotnet user-secrets set "Authentication:Google:ClientSecret" "<client-secret>"