# godot-persistent-data
 Godot persistent data management learning project.


## SQLite

If you have a lot of data that needs to be queried or updated frequently, SQLite is a good choice.


### 1. Add the SQLite NuGet package

#### Option 1: Use the dotnet CLI

Run the following command in the terminal at the root of your C# project:

```bash
dotnet add package sqlite-net-pcl --version 1.9.172
```

This command will add the following lines to your .csproj file (you can add them manually if you prefer, but make sure to replace the version number with the latest version available):

```xml
<ItemGroup>
  <PackageReference Include="sqlite-net-pcl" Version="1.9.172"/>
</ItemGroup>
```

The .csproj file should look like this:

```xml
<Project Sdk="Godot.NET.Sdk/4.3.0">
  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <TargetFramework Condition=" '$(GodotTargetPlatform)' == 'android' ">net7.0</TargetFramework>
    <TargetFramework Condition=" '$(GodotTargetPlatform)' == 'ios' ">net8.0</TargetFramework>
    <EnableDynamicLoading>true</EnableDynamicLoading>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="sqlite-net-pcl" Version="1.9.172"/>
  </ItemGroup>
</Project>
```

#### Option 2: Use the [NuGet Package Manager] or [NuGet Gallery] in Visual Studio Code and search for `sqlite-net-pcl` to install the package.



### 2. Add the SQLite.cs file to your project


[NuGet Package Manager]: https://marketplace.visualstudio.com/items?itemName=jmrog.vscode-nuget-package-manager
[NuGet Gallery]: https://marketplace.visualstudio.com/items?itemName=patcx.vscode-nuget-gallery

