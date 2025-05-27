using System.Net.Mime;
using MysGame.data.resource.control;
using MysGame.data.script;
using MysGame.data.script.text;
using MysGame.data.script.ui;

namespace MysGame.data;

public partial class MainForm : Form
{
    private readonly GameManager _gameManager;
    private readonly Debug _debugForm;
    
    public MainForm(GameManager gameManager, Debug debugForm)
    {
        // 매니저 초기화
        InitializeComponent();
        _gameManager = gameManager;
        _debugForm = debugForm;
        this.KeyPreview = true;
        this.KeyDown += OnKeyDown;
        
        // 유저 컨트롤 이벤트 연결 (버튼 클릭)
        if (_gameManager.GetControl("Home") is Home home)
            home.ButtonClicked += HomeButtonClicked;

        // 기본 폼 사이즈 설정 (홈, 게임 화면 등)
        Size defaultSize = new(1200, 760);
        this.Size = defaultSize;
        
        // 모든 유저 컨트롤 폼에 추가
        foreach (var control in _gameManager.GetAllControls())
        {
            control.Size = defaultSize;
            this.Controls.Add(control);
            _debugForm.LoadControl(control);
        }
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
                _gameManager.PrintText();
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
                _gameManager.StartNewGame();
                break;
            case "exitButton": 
                Application.Exit();
                break;
        }
    }
}