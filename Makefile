

build:
	dotnet build

add-migration:
	dotnet ef migrations add $(name)

update-database:
	dotnet ef database update

