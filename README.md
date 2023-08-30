# CleanupApp

This is a super simple, open source tool intended to help with school or business PC cleanup procedures on Win32 systems. It is designed to help with tasks such as clearing browsing data, clearing up leftover user files, clearing recent files lists, and more.

It is developed in C# under .NET 6. It is also extensible: Cleanup tasks are just C# classes. Pop more in and add functions as you may like.

## Usage

This tool doesn't need to be installed. Simply download the release executable (if available) or build and run with any modifications you may want to make.

Add an int as an argument to automatically run that number's associated task, if you want to automate the process. Example: `cleanupapp.exe 1`

## Building

To build you must have either the .NET SDK (6) installed, or (preferrably) Microsoft® Visual Studio with .NET desktop workload. After that, load up the project solution (if using Visual Studio) or the project file in CleanupApp/CleanupApp.csproj (if using the .NET SDK), then build and run.

## Contributing

Contributions are welcome! If you have ideas for what to add, feel free to leave some PRs or open some issues as you may like.

## Licensing

This software is open source, licensed under the MIT license. Check the LICENSE.md file for details.