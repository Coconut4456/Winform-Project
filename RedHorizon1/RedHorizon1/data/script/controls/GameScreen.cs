using RedHorizon1.data.script.config;
using RedHorizon1.data.script.entity;
using RedHorizon1.data.script.terrain;

namespace RedHorizon1.data.script.controls;

public partial class GameScreen : UserControl
{
    private List<Tile>? _tiles;
    private int _tileSize;
    private int _tileCount;
    public event Action<int, int>? OnTileClicked;

    public GameScreen()
    {
        this.ClientSize = new Size(GameConfig.ClientSizeX, GameConfig.ClientSizeY);
        this.DoubleBuffered = true;  // 깜빡임 방지용
        this.ResizeRedraw = true;    // 크기 변경 시 다시 그리기
        this.MouseClick += GameScreen_MouseClick!;
    }

    private void GameScreen_MouseClick(object sender, MouseEventArgs e)
    {
        int tileX = e.X / GameConfig.TileSize;
        int tileY = e.Y / GameConfig.TileSize;
        
        OnTileClicked?.Invoke(tileX, tileY);
    }

    /// <summary>
    /// 타일 정보 불러온 뒤 저장
    /// </summary>
    /// <param name="tiles"></param>
    /// <param name="tileSize"></param>
    /// <param name="tileCount"></param>
    public void SetTileData(List<Tile> tiles, int tileSize, int tileCount)
    {
        _tiles = tiles;
        _tileSize = tileSize;
        _tileCount = tileCount;
    }

    /// <summary>
    /// 게임 화면 UI 그리기 (타일)
    /// </summary>
    /// <param name="e"></param>
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Tile? selectedTile = null;
        
        if (_tiles == null)
        {
            throw new NullReferenceException("_tiles");
        }
        
        foreach (var tile in _tiles) // 타일 리스트 순회
        {
            Color tileColor;
            
            switch (tile.TerrainType) // 타일 지형 타입 확인
            {
                default:
                    tileColor = Color.DodgerBlue;
                    break;
                case TerrainType.Land:
                    tileColor = Color.DimGray;
                    break;
                case TerrainType.Water:
                    tileColor = Color.DodgerBlue;
                    break;
            }
            
            if (tile.IsSelected) // 선택되어 있는 타일이 있으면 지역 변수로 초기화
            {
                selectedTile = tile;
            }
            
            using Brush brush = new SolidBrush(tileColor);
            Rectangle rect = new Rectangle(tile.X * _tileSize, tile.Y * _tileSize, _tileSize, _tileSize); // 사각형 위치 및 크기 계산
            e.Graphics.FillRectangle(brush, rect); // 채우기
            e.Graphics.DrawRectangle(Pens.MidnightBlue, rect); // 경계선 그리기
        }

        if (selectedTile != null) // 선택된 타일 테두리 변경
        {
            Rectangle rect2 = new Rectangle(
                selectedTile.X * _tileSize,
                selectedTile.Y * _tileSize,
                _tileSize, _tileSize);

            using Pen pen = new Pen(Color.WhiteSmoke, 2);
            e.Graphics.DrawRectangle(pen, rect2);
        }
    }
}