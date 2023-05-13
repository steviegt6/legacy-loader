using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using LegacyLoader.API.Attributes;
using LegacyLoader.API.Loaders;
using MonoMod.RuntimeDetour;
using Terraria.ModLoader;
using Terraria.ModLoader.Core;

namespace LegacyLoader.Internal;

/// <summary>
///     Reorganizes the mod list. Handles loading legacy version loaders' mods.
/// </summary>
internal static class ModReorganizer {
    private static Hook? loadHook;
    private static List<IModLoader> loaders = new();

    public static void HookLoad() {
        loadHook = new Hook(
            typeof(ModContent).GetMethod("Load", BindingFlags.NonPublic | BindingFlags.Static)!,
            typeof(ModReorganizer).GetMethod(nameof(Load), BindingFlags.NonPublic | BindingFlags.Static)!
        );
        loaders = new List<IModLoader>();
    }

    public static void UnhookLoad() {
        loadHook?.Dispose();
        loadHook = null;

        loaders.Clear();
        loaders = null!;
    }

    public static void RegisterLoader(IModLoader loader) {
        loaders.Add(loader);
    }

    public static void LoadFromAssembly(Assembly assembly) {
        var types = AssemblyManager.GetLoadableTypes(assembly);

        foreach (var type in types) {
            var attr = type.GetCustomAttribute<LoaderAttribute>();
            if (attr is null)
                continue;

            if (!typeof(IModLoader).IsAssignableFrom(type))
                continue;

            var loader = (IModLoader) Activator.CreateInstance(type)!;
            RegisterLoader(loader);
        }
    }

    private static void Load(Action<CancellationToken> orig, CancellationToken token) {
        var mods = ModLoader.Mods.ToList();
        var mod = mods.First(x => x.Name == nameof(LegacyLoader));
        mods.Remove(mod);
        mods.Insert(0, mod); // change to 1 if we want to load after ModLoaderMod; don't know if this is necessary
        typeof(ModLoader).GetProperty("Mods", BindingFlags.Public | BindingFlags.Static)!.SetValue(null, mods.ToArray());

        foreach (var loader in loaders) {
            Logging.PublicLogger.Debug($"Loading mods from {loader.Name}...");

            var loaderMods = loader.FindMods(loader.BasePath);

            foreach (var loaderMod in loaderMods) {
                var modInstance = loaderMod.LoadMod();
                Logging.PublicLogger.Debug($"  {modInstance.Name}");
                mods.Add(modInstance);
            }
        }

        Logging.PublicLogger.Debug("Reorganized mod list:");
        foreach (var m in mods)
            Logging.PublicLogger.Debug($"  {m.Name}");

        orig(token);
    }
}
