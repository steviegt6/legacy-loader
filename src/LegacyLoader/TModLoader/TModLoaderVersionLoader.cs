using System;
using System.IO;
using LegacyLoader.API;
using Terraria;
using Terraria.ModLoader;

namespace LegacyLoader.TModLoader;

// ReSharper disable once InconsistentNaming
public sealed class TModLoaderVersionLoader : LegacyVersionLoader {
    public override string Name => "tModLoader";

    public override string BasePath => Path.Combine(Main.SavePath, "LegacyLoader", Name, "Mods");

    public override LegacyModFile[] FindMods(string path) {
        Directory.CreateDirectory(path);
        Logging.PublicLogger.Warn("tAPI is not yet supported by LegacyLoader.");
        return Array.Empty<LegacyModFile>();
    }
}
