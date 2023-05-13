using System.Collections.Generic;
using System.IO;
using System.Linq;
using LegacyLoader.API.Attributes;
using LegacyLoader.API.Loaders;
using Terraria.ModLoader;

namespace LegacyLoader.Loaders.TConfig;

// ReSharper disable once InconsistentNaming
[Loader]
public sealed class TConfigVersionLoader : GenericModLoader<TConfigModFile> {
    public override string Name => "tConfig";

    public override IEnumerable<TConfigModFile> FindMods(string path) {
        Directory.CreateDirectory(path);
        Logging.PublicLogger.Warn(Name + " is not yet supported by LegacyLoader.");
        return Enumerable.Empty<TConfigModFile>();
    }
}
