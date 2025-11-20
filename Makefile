

build:
	dotnet build

run:
	dotnet run -lp https

add-migration:
	dotnet ef migrations add $(name)

update-database:
	dotnet ef database update


