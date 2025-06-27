using RedHorizon1.data.script;
using RedHorizon1.data.script.config;

namespace RedHorizon1;

public partial class Form1 : Form
{
    private readonly GameManager _gameManager = new GameManager(new TileManager(), new UIManager(), new UnitManager());
    
    public Form1()
    {
        InitializeComponent();

        this.ClientSize = new Size(GameConfig.ClientSizeX, GameConfig.ClientSizeY);
        this.StartPosition = FormStartPosition.CenterScreen;

        _gameManager.InitializeGame(GameConfig.TileX, GameConfig.TileY);
        
        foreach (var control in _gameManager.GetScreenList())
        {
            this.Controls.Add(control);
        }
    }

    private int HorizontalAlignment(Control target) // 메인 화면으로 옮겨야댐
    {
        return ClientSize.Width / 2 - target.Size.Width / 2;
    }
}