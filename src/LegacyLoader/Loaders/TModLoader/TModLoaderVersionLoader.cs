using System.Collections.Generic;
using System.IO;
using System.Linq;
using LegacyLoader.API.Attributes;
using LegacyLoader.API.Loaders;
using Terraria.ModLoader;

namespace LegacyLoader.Loaders.TModLoader;

// ReSharper disable once InconsistentNaming
[Loader]
public sealed class TModLoaderVersionLoader : GenericModLoader<TModLoaderModFile> {
    public override string Name => "tModLoader";

    public override IEnumerable<TModLoaderModFile> FindMods(string path) {
        Directory.CreateDirectory(path);
        Logging.PublicLogger.Warn(Name + " is not yet supported by LegacyLoader.");
        return Enumerable.Empty<TModLoaderModFile>();
    }
}
