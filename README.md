# *demos-cs* project by Mark Veltzer

description: Demos for the C# language

project website: https://veltzer.github.io/demos-cs

author: Mark Veltzer

version: 0.0.1

![Code style: black](https://img.shields.io/badge/code%20style-black-000000.svg)

## github

![License](https://img.shields.io/github/license/veltzer/demos-cs)

## build

![build](https://github.com/veltzer/demos-cs/workflows/build/badge.svg)
## To run a specific project:

```bash
dotnet run --project src/Hello/Hello.csproj
```

## To run a specific project with different entry point, this has to be done after clean:

```bash
dotnet run --project src/MultiEntryPoint/MultiEntryPoint.csproj /p:StartupObject=Program3
dotnet run --project src/MultiEntryPoint/MultiEntryPoint.csproj --property StartupObject=Program3
```

## To build everything

```bash
dotnet build
dotnet build -v=q
dotnet build --nologo -v=q
dotnet build --nologo --verbosity quiet
```

## To clean everything

```bash
dotnet clean
dotnet clean -v=q
dotnet clean --nologo -v=q
dotnet clean --nologo --verbosity quiet
```

## To create a new project

```bash
cd src
dotnet new console -n [NameCamelCase]
```

## contact me

[mailto](mailto:mark.veltzer@gmail.com)
![gitter](https://img.shields.io/gitter/room/veltzer/mark.veltzer)
![discord](https://img.shields.io/discord/719336281624281119)
![discord](https://img.shields.io/discord/719336282194444302)

Mark Veltzer, Copyright © 2024, 2025, 2026
