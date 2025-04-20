## Comandos:
dotnet aspnet-codegenerator controller -name NomeDoController -namespace NomeDoProjeto.Controllers -outDir Controllers -api

dotnet new class -n User -o Models


## Migrate:

- dotnet ef migrations add create_tables
- dotnet ef database update
