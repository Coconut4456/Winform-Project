using MysGame.data.script;

namespace MysGame;

public partial class Form1 : Form
{
    // font = Ink Free
    private readonly GameManager _gameManager;

    public Form1()
    {
        InitializeComponent();
        this.KeyPreview = true;
        this.KeyDown += Form1_KeyDown!;

        {
            List<Control> panelList = [homePanel, gamePanel];
            List<Control> labelList = [home_titleLabel];
            List<Control> buttonList = [home_newGameButton, home_loadGameButton, home_settingButton, home_exitButton];
            _gameManager = new GameManager(this, textBox, panelList, labelList, buttonList);
            _gameManager.SetState("Home");
        }
    }
    
    // 폼 키 입력
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
        {
            _gameManager.PrintText();
        }
    }

    // 새 게임 버튼
    private void home_newGameButton_Click(object sender, EventArgs e)
    {
        _gameManager.SetState("Prologue");
    }

    // 게임 종료 버튼
    private void home_exitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}