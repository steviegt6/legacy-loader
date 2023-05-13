using Terraria.ModLoader;

namespace LegacyLoader.API.IO;

/// <summary>
///     Represents a mod file.
/// </summary>
public interface IModFile {
    /// <summary>
    ///     Loads this mod file as a tModLoader mod.
    /// </summary>
    /// <returns>A <see cref="Mod"/> instance.</returns>
    Mod LoadMod();
}
