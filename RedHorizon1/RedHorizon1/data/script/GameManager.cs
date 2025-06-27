using RedHorizon1.data.script.config;
using RedHorizon1.data.script.controls;
using RedHorizon1.data.script.entity;
using RedHorizon1.data.script.terrain;

namespace RedHorizon1.data.script;

public class GameManager
{
    private readonly TileManager _tileManager;
    private readonly UIManager _uiManager;
    private readonly UnitManager _unitManager;

    public GameManager(TileManager tileManager, UIManager uiManager,  UnitManager unitManager)
    {
        _tileManager = tileManager;
        _uiManager = uiManager;
        _unitManager = unitManager;

        if (_uiManager.GetScreen("Game") is GameScreen gameScreen)
        {
            gameScreen.OnTileClicked += HandleTileClick;
        }
    }

    /// <summary>
    /// 타일 선택 업데이트
    /// </summary>
    /// <param name="tileX"></param>
    /// <param name="tileY"></param>
    private void HandleTileClick(int tileX, int tileY)
    {
        Tile? clickedTile = _tileManager.GetTileAt(tileX, tileY);
        
        if (clickedTile == null) 
            return;

        Console.WriteLine($"[{tileX}, {tileY}] 타일 클릭됨 - 지형: {clickedTile.TerrainType}"); // debug

        if (!_tileManager.SelectionLocked)
        {
            clickedTile.IsSelected = true;
            _tileManager.SelectionLocked = true;
            _uiManager.UpDataGameScreen(_tileManager.TileList, GameConfig.TileSize, GameConfig.TileX * GameConfig.TileY);
        }
        else if (_tileManager.SelectionLocked && clickedTile.IsSelected)
        {
            clickedTile.IsSelected = false;
            _tileManager.SelectionLocked = false;
            _uiManager.UpDataGameScreen(_tileManager.TileList, GameConfig.TileSize, GameConfig.TileX * GameConfig.TileY);
        }
    }

    /// <summary>
    /// 초기 설정
    /// </summary>
    /// <param name="lineX"></param>
    /// <param name="lineY"></param>
    public void InitializeGame(int lineX, int lineY)
    {
        _tileManager.GenerateTiles(lineX, lineY, new DefaultTerrainGenerator(new Random())); // 타일 생성 및 초기화
        var tiles = _tileManager.TileList; // 타일 리스트
        var tileSize = GameConfig.TileSize; // 타일 크기
        var tileCount = GameConfig.TileX * GameConfig.TileY; // 타일 개수
        _uiManager.UpDataGameScreen(tiles, tileSize, tileCount); // 게임화면 UI 업데이트
        
        // 랜덤 육지 선택
        // 플레이어 시작 지점 설정
        // 해당 타일 UI 업데이트
    }

    /// <summary>
    /// 스크린 리스트 반환
    /// </summary>
    /// <returns></returns>
    public List<Control> GetScreenList()
    {
        return _uiManager.GetScreenList();
    }
}