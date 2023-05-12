namespace LegacyLoader.API;

/// <summary>
///     A legacy version.
/// </summary>
public abstract class LegacyVersionLoader {
    /// <summary>
    ///     The internal name of this version loader.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    ///     The default base path.
    /// </summary>
    public abstract string BasePath { get; }

    /// <summary>
    ///     Finds all mods in the given path.
    /// </summary>
    /// <param name="path">The path (directory) to search in.</param>
    /// <returns>An array of resolved files.</returns>
    public abstract LegacyModFile[] FindMods(string path);
}
