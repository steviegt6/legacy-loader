using System.Collections.Generic;
using System.IO;
using System.Linq;
using LegacyLoader.API.Loaders;
using Terraria.ModLoader;

namespace LegacyLoader.Loaders.TAPI;

// ReSharper disable once InconsistentNaming
public sealed class TApiVersionLoader : GenericModLoader<TApiModFile> {
    public override string Name => "tAPI";

    public override IEnumerable<TApiModFile> FindMods(string path) {
        Directory.CreateDirectory(path);
        Logging.PublicLogger.Warn("tAPI is not yet supported by LegacyLoader.");
        return Enumerable.Empty<TApiModFile>();
    }
}
