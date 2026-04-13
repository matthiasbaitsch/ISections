using System.Reflection;
using System.Text.Json;

namespace ISections;

/// <summary>
/// Geometric and mechanical properties of a European steel I-section profile.
/// </summary>
public record ISection
{
    private static readonly Dictionary<(string, int), ISection> Catalog;

    static ISection()
    {
        var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("profiles.json")!;
        var profiles = JsonSerializer.Deserialize<List<ISection>>(stream)!;
        Catalog = profiles.ToDictionary(p => (p.Series, p.Size));
    }

    /// <summary>
    /// Returns the profile for the given series and nominal size.
    /// </summary>
    /// <param name="series">Profile series, e.g. <c>HE-A</c>, <c>HE-B</c>, <c>IPE</c>.</param>
    /// <param name="size">Nominal size in mm, e.g. <c>200</c>.</param>
    /// <returns>The matching <see cref="ISection"/>.</returns>
    /// <exception cref="ArgumentException">No profile exists for the given series and size.</exception>
    public static ISection Get(string series, int size)
    {
        return Catalog.TryGetValue((series, size), out var profile) ? profile
            : throw new ArgumentException($"No profile found for series='{series}', size={size}.");
    }

    /// <summary>Profile series, e.g. <c>HE-A</c>, <c>IPE</c>.</summary>
    public string Series { get; init; } = string.Empty;

    /// <summary>Nominal size in mm.</summary>
    public int Size { get; init; }

    /// <summary>Full designation, e.g. <c>HE 200 A</c>.</summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>Mass per unit length in kg/m.</summary>
    public double G { get; init; }

    /// <summary>Total height in mm.</summary>
    public double h { get; init; }

    /// <summary>Total width in mm.</summary>
    public double w { get; init; }

    /// <summary>Web thickness in mm.</summary>
    public double tw { get; init; }

    /// <summary>Flange thickness in mm.</summary>
    public double tf { get; init; }

    /// <summary>Root radius in mm.</summary>
    public double r { get; init; }

    /// <summary>Cross-sectional area in cm².</summary>
    public double A { get; init; }

    /// <summary>Second moment of area about the strong axis in cm⁴.</summary>
    public double Iy { get; init; }

    /// <summary>Radius of gyration about the strong axis in cm.</summary>
    public double iy { get; init; }

    /// <summary>Second moment of area about the weak axis in cm⁴.</summary>
    public double Iz { get; init; }

    /// <summary>Radius of gyration about the weak axis in cm.</summary>
    public double iz { get; init; }

    /// <summary>Elastic moment of resistance about the strong axis in cm³.</summary>
    public double Wely { get; init; }

    /// <summary>Plastic moment of resistance about the strong axis in cm³.</summary>
    public double Wply { get; init; }

    /// <summary>Elastic moment of resistance about the weak axis in cm³.</summary>
    public double Welz { get; init; }

    /// <summary>Plastic moment of resistance about the weak axis in cm³.</summary>
    public double Wplz { get; init; }
}
