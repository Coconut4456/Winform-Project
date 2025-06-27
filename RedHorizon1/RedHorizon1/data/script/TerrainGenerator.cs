using RedHorizon1.data.script.entity;

namespace RedHorizon1.data.script;

public class TerrainGenerator
{
    private Random _random;

    public TerrainGenerator()
    {
        _random = new Random();
    }

    public TerrainType DefaultGenerate()
    {
        return _random.NextDouble() < 0.3 ? TerrainType.Water : TerrainType.Land;
    }
}