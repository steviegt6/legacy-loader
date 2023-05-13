using System;

namespace LegacyLoader.API.Attributes;

/// <summary>
///     Specifies that a loader should be auto-loaded from an assembly.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class LoaderAttribute : Attribute { }
