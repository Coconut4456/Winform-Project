using RedHorizon1.data.script.config;
using RedHorizon1.data.script.entity;
using RedHorizon1.data.script.terrain;

namespace RedHorizon1.data.script;

public class TileManager
{
    public List<Tile> TileList { get; private set; } // 타일 객체 리스트
    public bool SelectionLocked { get; set; }
    private DefaultTerrainGenerator? _terrainGenerator; // 지형 생성기

    public TileManager()
    {
        TileList = new List<Tile>();
        SelectionLocked = false;
    }

    /// <summary>
    /// 타일 객체 반환
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Tile? GetTileAt(int x, int y)
    {
        if (x < 0 || y < 0 || x >= GameConfig.TileX || y >= GameConfig.TileY)
            return null;

        return TileList[y * GameConfig.TileX + x];
    }
    
    /// <summary>
    /// 육지 타일 리스트 반환
    /// </summary>
    /// <returns></returns>
    public List<Tile> GetLandTiles()
    {
        return TileList.Where(t => t.TerrainType == TerrainType.Land && t.PlayerId == null).ToList();
    }

    /// <summary>
    /// 가로x, 세로y 만큼의 타일 객체 생성 및 리스트 추가
    /// </summary>
    /// <param name="lineX"></param>
    /// <param name="lineY"></param>
    /// <param name="defaultTerrainGenerator"></param>
    public void GenerateTiles(int lineX, int lineY, DefaultTerrainGenerator defaultTerrainGenerator)
    {
        _terrainGenerator = defaultTerrainGenerator;
        int mapWidth = GameConfig.TileX;
        int mapHeight = GameConfig.TileY;
        
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                TileList.Add(new Tile
                {
                    X = x,
                    Y = y,
                    TerrainType = _terrainGenerator.Generate(x,y, mapWidth, mapHeight)
                });
            }
        }
    }
}