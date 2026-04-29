using PluginWorld;
using PluginWorld.wit.Exports.pumpkin.plugin.v0_1_0;
using PluginWorld.wit.Imports.pumpkin.plugin.v0_1_0;

namespace PluginWorld
{
    // wit-bindgen generates calls to a partial class named [WorldName]ExportsImpl 
    // and [InterfaceName]ExportsImpl. We must provide these implementations.

    public partial class PluginWorldExportsImpl : IPluginWorldExports
    {
        public static void InitPlugin() 
        {
        }

        public static void OnLoad(IContextImports.Context context)
        {
        }

        public static void OnUnload(IContextImports.Context context)
        {
        }

        public static IEventImports.Event HandleEvent(uint eventId, IServerImports.Server server, IEventImports.Event @event)
        {
            return @event;
        }

        public static int HandleCommand(uint commandId, ICommandImports.CommandSender sender, IServerImports.Server server, ICommandImports.ConsumedArgs args)
        {
            return 0;
        }

        public static void HandleTask(uint handlerId, IServerImports.Server server)
        {
        }
    }
}

namespace PluginWorld.wit.Exports.pumpkin.plugin.v0_1_0
{
    public partial class MetadataExportsImpl : IMetadataExports
    {
        public static IMetadataExports.PluginMetadata GetMetadata()
        {
            return new IMetadataExports.PluginMetadata(
                "csharp-plugin",
                "0.1.0",
                new List<string> { "Author" },
                "A Pumpkin plugin written in C#",
                new List<string>()
            );
        }
    }
}
