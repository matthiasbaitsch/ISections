using ISections;

var p = ISection.Get("HE-A", 200);

Console.WriteLine(p.Name);
Console.WriteLine($" A: {p.A}");
Console.WriteLine($"Iy: {p.Iy}");


