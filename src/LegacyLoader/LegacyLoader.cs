using JetBrains.Annotations;
using Terraria.ModLoader;

namespace LegacyLoader;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
public sealed class LegacyLoader : Mod {
    public LegacyLoader() {
        Internal.ModReorganizer.HookLoad();
    }

    public override void Unload() {
        base.Unload();

        Internal.ModReorganizer.UnhookLoad();
    }
}
