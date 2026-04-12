using System.Reflection;
using System.Text.Json;

namespace ISections;

public record ISection
{
    private static readonly Dictionary<(string, int), ISection> Catalog;

    static ISection()
    {
        var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("profiles.json")!;
        var profiles = JsonSerializer.Deserialize<List<ISection>>(stream)!;
        Catalog = profiles.ToDictionary(p => (p.Series, p.Size));
    }

    public static ISection Get(string series, int size)
    {
        return Catalog.TryGetValue((series, size), out var profile) ? profile
            : throw new ArgumentException($"No profile found for series='{series}', size={size}.");
    }

    public string Series { get; init; } = string.Empty;
    public int Size { get; init; }
    public string Name { get; init; } = string.Empty;
    public double G { get; init; }
    public double h { get; init; }
    public double w { get; init; }
    public double tw { get; init; }
    public double tf { get; init; }
    public double r { get; init; }
    public double A { get; init; }
    public double Iy { get; init; }
    public double iy { get; init; }
    public double Iz { get; init; }
    public double iz { get; init; }
    public double Wely { get; init; }
    public double Wply { get; init; }
    public double Welz { get; init; }
    public double Wplz { get; init; }
}
