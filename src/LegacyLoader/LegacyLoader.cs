using JetBrains.Annotations;
using LegacyLoader.Internal;
using LegacyLoader.TAPI;
using LegacyLoader.TConfig;
using LegacyLoader.TModLoader;
using Terraria.ModLoader;

namespace LegacyLoader;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
public sealed class LegacyLoader : Mod {
    public LegacyLoader() {
        ModReorganizer.HookLoad();

        ModReorganizer.RegisterLoader(new TConfigVersionLoader());
        ModReorganizer.RegisterLoader(new TApiVersionLoader());
        ModReorganizer.RegisterLoader(new TModLoaderVersionLoader());
    }

    public override void Unload() {
        base.Unload();

        ModReorganizer.UnhookLoad();
    }
}
