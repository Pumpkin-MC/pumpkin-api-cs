# Pumpkin Plugin API for C# (.NET)

This package provides everything needed to write a Pumpkin server plugin compiled to WebAssembly using C# (.NET 10+).

## Quick start

1. Create a new C# Class Library project for your plugin:
   ```bash
   dotnet new classlib -n MyPumpkinPlugin
   cd MyPumpkinPlugin
   ```

2. Add a `NuGet.Config` to your project to include the .NET experimental feed:
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <configuration>
     <packageSources>
       <add key="dotnet-experimental" value="https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-experimental/nuget/v3/index.json" />
     </packageSources>
   </configuration>
   ```

3. Add the required packages:
   ```bash
   dotnet add package PumpkinMC.PumpkinApi
   dotnet add package ByteCodeAlliance.Componentize.DotNet.Wasm.SDK --prerelease
   ```

4. Configure your `.csproj` to target `wasi-wasm`:
   ```xml
   <PropertyGroup>
     <TargetFramework>net10.0</TargetFramework>
     <RuntimeIdentifier>wasi-wasm</RuntimeIdentifier>
   </PropertyGroup>
   ```

5. Implement your plugin by implementing the interfaces from the package (e.g., `PluginWorld.IPluginWorldExports` and `PluginWorld.wit.Exports.pumpkin.plugin.v0_1_0.IMetadataExports`).

```csharp
using PluginWorld;
using PluginWorld.wit.Exports.pumpkin.plugin.v0_1_0;
using PluginWorld.wit.Imports.pumpkin.plugin.v0_1_0;

namespace MyPumpkinPlugin;

public class MyPlugin : IPluginWorldExports, IMetadataExports
{
    public static void InitPlugin() { }

    public static void OnLoad(IContextImports.Context context)
    {
        ILoggingImports.Log(ILoggingImports.Level.Info, "C# plugin loaded!");
    }

    public static void OnUnload(IContextImports.Context context) { }

    public static IEventImports.Event HandleEvent(uint eventId, IServerImports.Server server, IEventImports.Event @event)
    {
        return @event;
    }

    public static int HandleCommand(uint commandId, ICommandImports.CommandSender sender, IServerImports.Server server, ICommandImports.ConsumedArgs args)
    {
        return 0;
    }

    public static void HandleTask(uint handlerId, IServerImports.Server server) { }

    public static IMetadataExports.PluginMetadata Metadata()
    {
        return new IMetadataExports.PluginMetadata(
            "my-csharp-plugin",
            "0.1.0",
            "An example C# plugin.",
            ["you"],
            []
        );
    }
}
```

5. Build your plugin into a WebAssembly component:

```bash
dotnet build -c Release
```

The output will contain a `.wasm` file that you can use in your Pumpkin server.
