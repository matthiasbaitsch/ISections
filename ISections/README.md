# ISections

A catalog of European steel I-section profiles (HEA, HEAA, HEB, HEM, IPE) with geometric and mechanical properties.

## Usage

```csharp
using ISections;

var profile = ISection.Get("HEA", 200);

Console.WriteLine(profile.Name);   // HE 200 A
Console.WriteLine(profile.G);      // 42.3  kg/m
Console.WriteLine(profile.A);      // 53.8  cm²
Console.WriteLine(profile.Iy);     // 3692  cm⁴
```

`ISection.Get` throws `ArgumentException` when the series/size combination does not exist.

## Available Series

| Series | Description |
|--------|-------------|
| IPE    | European standard I-sections |
| HEA    | Wide flange, series A (light) |
| HEAA   | Wide flange, series AA (extra light) |
| HEB    | Wide flange, series B (medium) |
| HEM    | Wide flange, series M (heavy) |

## Properties

| Property | Description | Unit |
|----------|-------------|------|
| `Series` | Profile series | — |
| `Size`   | Nominal size | mm |
| `Name`   | Full designation (e.g. `HE 200 A`) | — |
| `h`      | Total height | mm |
| `w`      | Total width | mm |
| `tw`     | Web thickness | mm |
| `tf`     | Flange thickness | mm |
| `r`      | Root radius | mm |
| `A`      | Cross-sectional area | cm² |
| `Iy`     | Second moment of area (strong axis) | cm⁴ |
| `Wely`   | Elastic moment of resistance (strong axis) | cm³ |
| `Wply`   | Plastic moment of resistance (strong axis) | cm³ |
| `iy`     | Radius of gyration (strong axis) | cm |
| `Iz`     | Second moment of area (weak axis) | cm⁴ |
| `Welz`   | Elastic moment of resistance (weak axis) | cm³ |
| `Wplz`   | Plastic moment of resistance (weak axis) | cm³ |
| `iz`     | Radius of gyration (weak axis) | cm |
| `G`      | Mass per unit length | kg/m |
