@echo off

dotnet build --configuration Release

dotnet test --configuration Release --no-build

dotnet pack --configuration Release --no-build -o nupkg

