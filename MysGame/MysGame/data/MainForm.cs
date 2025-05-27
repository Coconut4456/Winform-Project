using System.Net.Mime;
using MysGame.data.resource.control;
using MysGame.data.script;
using MysGame.data.script.text;
using MysGame.data.script.ui;

namespace MysGame.data;

public partial class MainForm : Form
{
    private readonly GameManager _gameManager;
    private readonly UIManager _uiManager;
    private readonly TextManager _textManager;
    private readonly Debug _debugForm;
    
    public MainForm(GameManager gameManager, UIManager uiManager, TextManager textManager)
    {
        // 매니저 초기화
        InitializeComponent();
        _gameManager = gameManager;
        _uiManager = uiManager;
        _textManager = textManager;
        _debugForm = new Debug();
        
        // 유저컨트롤 매핑
        _uiManager.Register("TextArea", new TextArea());
        _uiManager.Register("Home", new Home());
        _uiManager.Register("GameScreen", new GameScreen());
        
        // 초기 언어 설정
        ApplyUIText("ko");
        
        // 유저 컨트롤 이벤트 연결 (버튼 클릭)
        var home = _uiManager.GetControl<Home>("Home");
        home.ButtonClicked += HomeButtonClicked;

        this.KeyPreview = true;
        this.KeyDown += OnKeyDown;

        // 기본 폼 사이즈 설정 (홈, 게임 화면 등)
        Size defaultSize = new(1200, 760);
        this.Size = defaultSize;
        
        // 모든 유저 컨트롤 폼에 추가
        foreach (var control in _uiManager.GetAllControls())
        {
            control.Size = defaultSize;
            this.Controls.Add(control);
            _debugForm.LoadControl(control);
        }
        
        // 초기 홈 화면 전환
        _uiManager.SwitchUI("Home");
        // _debugForm.SetClientSize();
        _debugForm.Show();
    }

    /// <summary>
    /// 폼 키 입력 메서드
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Space:
                PrintText();
                break;
            case Keys.PageUp:
                _debugForm.Visible = !_debugForm.Visible;
                break;
        }
    }

    /// <summary>
    /// 홈 버튼 클릭 이벤트
    /// </summary>
    /// <param name="buttonName"></param>
    private void HomeButtonClicked(string buttonName)
    {
        switch (buttonName)
        {
            case "newGameButton":
                _gameManager.SetState("Prologue");
                _uiManager.SwitchUI("GameScreen");
                _uiManager.GetControl<Home>("Home").Visible = false;
                _uiManager.GetControl<TextArea>("TextArea").Visible = true;
                _uiManager.HorizontalAlignment("GameScreen", "TextBox");
                _uiManager.VerticalAlignment("GameScreen", "TextBox");
                _uiManager.TextBoxShow();
                _textManager.LoadScriptTexts("Prologue");
                PrintText();
                break;
            case "exitButton": 
                Application.Exit();
                break;
        }
    }

    /// <summary>
    /// 현재 메시지 출력
    /// </summary>
    private void PrintText()
    {
        if (_uiManager.IsTyping)
            return;
        
        List<char> charList = _textManager.GetSplitText();
        _uiManager.SetCharList(charList);
        _uiManager.TypingTimerStart();
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