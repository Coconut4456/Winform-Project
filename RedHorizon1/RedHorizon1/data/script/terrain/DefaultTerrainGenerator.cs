using RedHorizon1.data.script.entity;

namespace RedHorizon1.data.script.terrain;

public class DefaultTerrainGenerator : ITerrainGenerator
{
    private Random _random;

    public DefaultTerrainGenerator(Random random)
    {
        _random = random;
    }

    public double GetWaterProbability(int x, int y, int mapWidth, int mapHeight)
    {
        // 테두리로부터 떨어진 거리
        int distX = Math.Min(x, mapWidth - 1 - x);
        int distY = Math.Min(y, mapHeight - 1 - y);
        int distToEdge = Math.Min(distX, distY);

        // 거리 0~3일 때 확률 100% → 50% → 30% → 10%
        // 그 이상은 거의 육지
        return distToEdge switch
        {
            <= 1 => 1.0,  // 가장자리 → 무조건 바다
            2 => 0.7,
            3 => 0.5,
            4 => 0.3,
            _ => 0.15  // 중심부에 가까우면 거의 육지
        };
    }

    public TerrainType Generate(int x, int y, int mapWidth, int mapHeight)
    {
        double waterChance = GetWaterProbability(x, y,  mapWidth, mapHeight);
        TerrainType type = (_random.NextDouble() < waterChance) ? TerrainType.Water : TerrainType.Land;
        return type;
    }
}