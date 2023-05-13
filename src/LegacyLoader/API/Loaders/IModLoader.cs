using System.Collections.Generic;
using LegacyLoader.API.IO;

namespace LegacyLoader.API.Loaders;

public interface IModLoader {
    /// <summary>
    ///     The internal name.
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     The base path of this loader.
    /// </summary>
    string BasePath { get; }
    
    /// <summary>
    ///     Finds all mods in the given path.
    /// </summary>
    /// <param name="path">The top directory to search for mods at.</param>
    /// <returns>An enumerable collection of found mods.</returns>
    IEnumerable<IModFile> FindMods(string path);
}
