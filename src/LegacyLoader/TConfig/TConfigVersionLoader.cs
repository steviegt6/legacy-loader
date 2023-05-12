﻿using System;
using System.IO;
using LegacyLoader.API;
using Terraria;
using Terraria.ModLoader;

namespace LegacyLoader.TConfig;

// ReSharper disable once InconsistentNaming
public sealed class TConfigVersionLoader : LegacyVersionLoader {
    public override string Name => "tConfig";

    public override string BasePath => Path.Combine(Main.SavePath, "LegacyLoader", Name, "Mods");

    public override LegacyModFile[] FindMods(string path) {
        Directory.CreateDirectory(path);
        Logging.PublicLogger.Warn("tAPI is not yet supported by LegacyLoader.");
        return Array.Empty<LegacyModFile>();
    }
}
