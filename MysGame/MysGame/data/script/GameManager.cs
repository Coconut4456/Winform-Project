using System.Diagnostics.CodeAnalysis;
using MysGame.data.resource.control;
using MysGame.data.script.text;
using MysGame.data.script.ui;
using Newtonsoft.Json;

namespace MysGame.data.script;

public class GameManager
{
    private readonly UIManager _uiManager;
    private readonly TextManager _textManager;
    private StateLine _currentStateLine;

    public GameManager(UIManager uiManager, TextManager textManager)
    {
        _uiManager = uiManager;
        _textManager = textManager;
        
        // 유저컨트롤 매핑
        _uiManager.Register("TextArea", new TextArea());
        _uiManager.Register("Home", new Home());
        _uiManager.Register("GameScreen", new GameScreen());
        
        // 초기 언어 설정
        ApplyUIText("ko");
        
        _textManager.SetTextLabel(_uiManager.GetControl<TextArea>("TextArea").Controls["TextLabel"]!);
        
        // 초기 홈 화면 전환
        _uiManager.SwitchUI("Home");
    }
    
    public void PrintText() => _textManager.PrintText();

    /// <summary>
    /// 새 게임
    /// </summary>
    public void StartNewGame()
    {
        Control home = _uiManager.GetControl<Home>("Home");
        Control textArea = _uiManager.GetControl<TextArea>("TextArea");
        _currentStateLine = StateLine.Prologue;
        _uiManager.SwitchUI("GameScreen");
        _uiManager.SetTextAreaSize(500, 100);
        _uiManager.HorizontalAlignment(home, textArea);;
        _uiManager.VerticalAlignment(home, textArea);;
        _uiManager.TextAreaShow();
        _textManager.LoadScriptTexts("Prologue");
        _textManager.PrintText();
    }

    /// <summary>
    /// 컨트롤 반환
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Control GetControl(string name)
    {
        return _uiManager.GetControl<Home>($@"{name}");
    }

    /// <summary>
    /// 모든 유저 컨트롤 반환
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Control> GetAllControls()
    {
        return _uiManager.GetAllControls();
    }
    
    /// <summary>
    /// control.Text에 언어 초기화
    /// </summary>
    /// <param name="lang"></param>
    private void ApplyUIText(string lang)
    {
        _textManager.CurrentLanguage = lang;
        _textManager.SetPath();
        
        foreach (var userControl in _uiManager.GetAllControls())
        {
            foreach (Control control in userControl.Controls)
            {
                if (TextLoader.GetUIText(control.Name) == "") continue;
                control.Text = TextLoader.GetUIText(control.Name);
            }
        }
    }
}