using MysGame.Data.Cl;
using MysGame.Data.Cl.UI;

namespace MysGame;

public partial class Form1 : Form
{
    // font = Ink Free
    public static Form1 _form1;
    private readonly TextManager _textManager;
    private readonly UIManager _uiManager;
    private readonly List<Control> _panels;
    private readonly Control _textBox;

    public Form1()
    {
        InitializeComponent();
        this.KeyPreview = true;
        this.KeyDown += Form1_KeyDown!;

        List<Control> homeControls =
            [home_newGameButton, home_roadGameButton, home_galleryButton, home_settingButton, home_exitButton];
        List<Control> gameControls = [game_phoneBoxLabel];
        
        {
            _textBox = new Label();
            _textBox.Name = "game_textBox";
            _textBox.BackColor = Color.Black;
            _textBox.Size = new Size(gamePanel.Size.Width, 60);
            _textBox.Font = new Font("Ink Free", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _textBox.ForeColor = Color.White;
            _textBox.Visible = true;
            _textBox.TabStop = false;
            Controls.Add(_textBox);
            _textManager = new TextManager("Data/Js/script_ko.json", _textBox);
            _uiManager = new UIManager();
            _panels = [homePanel, gamePanel];
        }

        _uiManager.UI_Horizontal_Centering(homePanel, homeControls);
        _uiManager.UI_Horizontal_Centering(gamePanel, gameControls);
        _uiManager.SwitchControl(_panels, homePanel);
    }

    public static Form Instance()
    {
        if (_form1 == null)
            _form1 = new Form1();
        
        return _form1;
    }

    // 폼 키 입력
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
        {
            _textManager.PrintText();
        }
    }

    // 새 게임 버튼
    private void home_newGameButton_Click(object sender, EventArgs e)
    {
        game_phoneBoxLabel.Visible = false;
        _uiManager.SwitchControl(_panels, gamePanel);
        _uiManager.MoveControl(targetControl:_textBox, width:400, height:100, x: 0, y:100);
        _uiManager.UI_Horizontal_Centering(standardControl: gamePanel, targetControl:_textBox);
        _textManager.LoadTexts("Prologue");
        _textManager.PrintText();
    }

    // 게임 종료 버튼
    private void home_exitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}