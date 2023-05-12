using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using MonoMod.RuntimeDetour;
using Terraria.ModLoader;

namespace LegacyLoader.Internal;

/// <summary>
///     Reorganizes the mod list.
/// </summary>
internal static class ModReorganizer {
    private static Hook? loadHook;

    public static void HookLoad() {
        loadHook = new Hook(
            typeof(ModContent).GetMethod("Load", BindingFlags.NonPublic | BindingFlags.Static)!,
            typeof(ModReorganizer).GetMethod(nameof(Load), BindingFlags.NonPublic | BindingFlags.Static)!
        );
    }

    public static void UnhookLoad() {
        loadHook?.Dispose();
        loadHook = null;
    }

    private static void Load(Action<CancellationToken> orig, CancellationToken token) {
        var mods = ModLoader.Mods.ToList();
        var mod = mods.First(x => x.Name == nameof(LegacyLoader));
        mods.Remove(mod);
        mods.Insert(0, mod); // change to 1 if we want to load after ModLoaderMod; don't know if this is necessary
        typeof(ModLoader).GetProperty("Mods", BindingFlags.Public | BindingFlags.Static)!.SetValue(null, mods.ToArray());

        Logging.PublicLogger.Debug("Reorganized mod list:");
        foreach (var m in mods)
            Logging.PublicLogger.Debug($"  {m.Name}");

        orig(token);
    }
}
