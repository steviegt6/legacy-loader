using System;
using System.IO;
using LegacyLoader.API;
using Terraria;
using Terraria.ModLoader;

namespace LegacyLoader.TAPI;

// ReSharper disable once InconsistentNaming
public sealed class TApiVersionLoader : LegacyVersionLoader {
    public override string Name => "tAPI";

    public override string BasePath => Path.Combine(Main.SavePath, "LegacyLoader", "tAPI", "Mods");

    public override LegacyModFile[] FindMods(string path) {
        Directory.CreateDirectory(path);
        Logging.PublicLogger.Warn("tAPI is not yet supported by LegacyLoader.");
        return Array.Empty<LegacyModFile>();
    }
}
