using RedHorizon1.data.script;

namespace RedHorizon1;

public partial class Form1 : Form
{
    private GameManager _gameManager;
    
    public Form1()
    {
        InitializeComponent();

        this.ClientSize = new Size(1400, 860);
        this.StartPosition = FormStartPosition.CenterScreen;

        _gameManager = new GameManager();
    }
}