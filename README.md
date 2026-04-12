# ISections

A .NET library providing a catalog of European steel I-section profiles (HEA, HEAA, HEB, HEM, IPE) with their geometric and mechanical properties, embedded directly in the assembly.

## Overview

ISections exposes a simple, strongly-typed API to look up cross-section properties by series and nominal size. All 113 profiles are bundled as an embedded JSON resource — no external files or database required at runtime.

### Supported Series

| Series | Description |
|--------|-------------|
| HEA    | Wide flange I-sections, series A (light) |
| HEAA   | Wide flange I-sections, series AA (extra light) |
| HEB    | Wide flange I-sections, series B (medium) |
| HEM    | Wide flange I-sections, series M (heavy) |
| IPE    | European standard I-sections |

### Properties per Profile

| Property | Description | Unit |
|----------|-------------|------|
| `Name`   | Full designation (e.g. `HE 200 A`) | — |
| `Series` | Profile series (`HEA`, `IPE`, …) | — |
| `Size`   | Nominal size | mm |
| `G`      | Mass per unit length | kg/m |
| `h`      | Total height | mm |
| `w`      | Flange width | mm |
| `tw`     | Web thickness | mm |
| `tf`     | Flange thickness | mm |
| `r`      | Root radius | mm |
| `A`      | Cross-sectional area | cm² |
| `Iy`     | Second moment of area (strong axis) | cm⁴ |
| `iy`     | Radius of gyration (strong axis) | cm |
| `Iz`     | Second moment of area (weak axis) | cm⁴ |
| `iz`     | Radius of gyration (weak axis) | cm |
| `Wely`   | Elastic section modulus (strong axis) | cm³ |
| `Wply`   | Plastic section modulus (strong axis) | cm³ |
| `Welz`   | Elastic section modulus (weak axis) | cm³ |
| `Wplz`   | Plastic section modulus (weak axis) | cm³ |

## Usage

```csharp
using ISections;

var profile = ISection.Get("HEA", 200);

Console.WriteLine(profile.Name);   // HE 200 A
Console.WriteLine(profile.A);      // cross-sectional area in cm²
Console.WriteLine(profile.Iy);     // second moment of area in cm⁴
```

`ISection.Get` throws `ArgumentException` when no matching profile exists.

## Project Structure

```
ISections/
├── ISections/              # Class library (NuGet-ready)
│   └── ISection.cs         # Record type + static catalog
├── ISections.Demo/         # Minimal console demo
│   └── Program.cs
├── ISections.Tests/        # xUnit test suite
│   └── ISectionTests.cs
└── assets/
    ├── profiles.json       # Embedded profile data (113 profiles)
    └── raw/                # Source spreadsheets + R extraction script
        ├── profiles/       # Per-series XLSX files (source data)
        └── extract-json.R  # R script that produced profiles.json
```

## Building and Running

Requires [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
# Build the library
dotnet build ISections/ISections.csproj

# Run the demo
dotnet run --project ISections.Demo

# Run the tests
dotnet test ISections.Tests
```

## Data

Profile data was extracted from manufacturer tables using the R script at [assets/raw/extract-json.R](assets/raw/extract-json.R) and serialised to [assets/profiles.json](assets/profiles.json). The raw source spreadsheets are in [assets/raw/profiles/](assets/raw/profiles/).
