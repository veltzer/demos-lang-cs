## demos-cs

version: 0.0.1

description: Demos for the C# language

website: https://veltzer.github.io/demos-cs

## Build

![build](https://github.com/veltzer/demos-cs/workflows/build/badge.svg)


## Contact

chat with me at [![gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/veltzer/mark.veltzer)

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

Mark Veltzer, Copyright © 2024, 2025
