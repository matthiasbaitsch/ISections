using ISections;

namespace ISections.Tests;

public class ISectionTests
{
    [Fact]
    public void HEA200_HasCorrectProperties()
    {
        var p = ISection.Get("HE-A", 200);

        Assert.Equal("HE 200 A", p.Name);
        Assert.Equal(42.3, p.G);
        Assert.Equal(190, p.h);
        Assert.Equal(200, p.w);
        Assert.Equal(3692, p.Iy);
    }
}
