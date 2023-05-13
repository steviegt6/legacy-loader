using System.Collections.Generic;
using System.IO;
using System.Linq;
using LegacyLoader.API.IO;
using Terraria;

namespace LegacyLoader.API.Loaders;

/// <summary>
///     An abstracted, generic mod loader.
/// </summary>
public abstract class GenericModLoader<TModFile> : IModLoader where TModFile : IModFile {
    public abstract string Name { get; }

    public virtual string BasePath => Path.Combine(Main.SavePath, "LegacyLoader", Name);

    /// <summary>
    ///     Finds all mods in the given path.
    /// </summary>
    /// <param name="path">The top directory to search for mods at.</param>
    /// <returns>An enumerable collection of found mods.</returns>
    public abstract IEnumerable<TModFile> FindMods(string path);

    IEnumerable<IModFile> IModLoader.FindMods(string path) {
        return FindMods(path).Cast<IModFile>();
    }
}
