using JetBrains.Annotations;
using LegacyLoader.Internal;
using Terraria.ModLoader;

namespace LegacyLoader;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
public sealed class LegacyLoader : Mod {
    public LegacyLoader() {
        ModReorganizer.HookLoad();

        /*ModReorganizer.RegisterLoader(new TConfigVersionLoader());
        ModReorganizer.RegisterLoader(new TApiVersionLoader());
        ModReorganizer.RegisterLoader(new TModLoaderVersionLoader());*/
        ModReorganizer.LoadFromAssembly(typeof(LegacyLoader).Assembly);
    }

    public override void Unload() {
        base.Unload();

        ModReorganizer.UnhookLoad();
    }
}
