using RedHorizon1.data.script.controls;
using RedHorizon1.data.script.entity;

namespace RedHorizon1.data.script;

public class UIManager
{
    private readonly Dictionary<string, UserControl> _screenDic = new();
    
    public UIManager()
    {
        // _screens["MainMenu"] = new MainMenuScreen();
        _screenDic["Game"] = new GameScreen();
        // _screens["Settings"] = new SettingsScreen();
    }
    
    /// <summary>
    /// 스크린 반환
    /// </summary>
    /// <param name="screenName"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Control GetScreen(string screenName)
    {
        if (_screenDic.TryGetValue(screenName, out var screen))
        {
            return screen;
        }
        
        throw new Exception("Could not find screen: " + screenName);
    }
    
    /// <summary>
    /// 스크린 리스트 반환
    /// </summary>
    /// <returns></returns>
    public List<Control> GetScreenList()
    {
        List<Control> controls = new List<Control>();
        
        foreach (var userControl in _screenDic)
        {
            controls.Add(userControl.Value);
        }

        return controls;
    }

    /// <summary>
    /// UI 초기 설정
    /// </summary>
    /// <param name="tiles"></param>
    /// <param name="tileSize"></param>
    /// <param name="tileCount"></param>
    public void UpDataGameScreen(List<Tile> tiles, int tileSize, int tileCount)
    {
        if (_screenDic["Game"] is GameScreen gameScreen)
        {
            gameScreen.SetTileData(tiles, tileSize, tileCount); // 게임 화면에 필요 저장
            gameScreen.Invalidate(); // 게임 화면 갱신
        }
    }
}