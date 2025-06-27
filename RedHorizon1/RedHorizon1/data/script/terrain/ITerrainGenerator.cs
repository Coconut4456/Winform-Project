using RedHorizon1.data.script.entity;

namespace RedHorizon1.data.script.terrain;

public interface ITerrainGenerator
{
    TerrainType Generate(int x, int y, int mapWidth, int mapHeight);
}