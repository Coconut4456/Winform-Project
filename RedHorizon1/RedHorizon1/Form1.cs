using RedHorizon1.data.script;

namespace RedHorizon1;

public partial class Form1 : Form
{
    private GameManager _gameManager;
    private TileManager _tileManager;
    
    public Form1()
    {
        InitializeComponent();

        this.ClientSize = new Size(1400, 860);
        this.StartPosition = FormStartPosition.CenterScreen;

        _gameManager = new GameManager();
        _tileManager = new TileManager();
    }

    /// <summary>
    /// 수평 중앙 정렬 메서드 (메인 폼 기준)
    /// </summary>
    /// <param name="targetX"></param>
    /// <returns></returns>
    private int HorizontalAlignment(Control target)
    {
        return ClientSize.Width / 2 - target.Size.Width / 2;
    }
}