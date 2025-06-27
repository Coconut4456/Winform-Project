using RedHorizon1.data.script.entity;

namespace RedHorizon1.data.script;

public class TileManager
{
    public List<Tile> TileList { get; private set; }

    public TileManager()
    {
        TileList = new List<Tile>();
    }

    public void GenerateTiles(int x, int y)
    {
        for (int i = 0; i < x; i++)
        {
            Tile tile = new Tile();
        }
    }
}