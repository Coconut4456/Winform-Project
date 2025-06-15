using System.Reflection.Metadata.Ecma335;
using KnightsJourney.resource;
using Timer = System.Windows.Forms.Timer;

namespace KnightsJourney;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        
        this.SizeChanged += Form_SizeChanged!;
        this.Text = "KnightsJourney";
        this.AutoScaleMode = AutoScaleMode.Dpi;
        
        Home home = new Home();
        home.OnButtonClick += Button_Click;
        this.Controls.Add(home);
        
        GameScreen gameScreen = new GameScreen();
        gameScreen.OnButtonClick += Button_Click;
        this.Controls.Add(gameScreen);
        
        ReSize();
        home.AddGameButton(5, 9);
    }

    /// <summary>
    /// 폼 크기 설정
    /// </summary>
    private void ReSize()
    {
        this.ClientSize = new Size(800, 500);
    }

    /// <summary>
    /// 게임 시작
    /// </summary>
    private void GameStart()
    {
        Home? home = Controls["Home"] as Home;
        GameScreen? gameScreen = Controls["GameScreen"] as GameScreen;

        if (home == null)
            return;

        if (gameScreen == null)
            return;
        
        home.SetVisible();
        gameScreen.Controls.Clear();
        gameScreen.AddLabel();
        gameScreen.AddUI();
        this.Size = gameScreen.GetTotalSize();
        this.StartPosition = FormStartPosition.CenterScreen;
        gameScreen.GameStart();
        gameScreen.CheckTimeAttack(home.TimeAttackChecked);
    }
    
    /// <summary>
    /// 폼 사이즈 변경시 위치 이동 (화면 중앙으로)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form_SizeChanged(object sender, EventArgs e)
    {
        int screenWidth = Screen.PrimaryScreen!.WorkingArea.Width;
        int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

        int x = (screenWidth - this.Width) / 2;
        int y = (screenHeight - this.Height) / 2;

        this.Location = new Point(x, y);
    }
    
    /// <summary>
    /// 버튼 클릭 동작
    /// </summary>
    private void Button_Click(string tag)
    {
        Home? home = Controls["Home"] as Home;
        GameScreen? gameScreen = Controls["GameScreen"] as GameScreen;

        if (home == null)
            return;

        if (gameScreen == null)
            return;
        
        switch (tag)
        {
            case "Start1":
                gameScreen.SetBlockNum(5);
                GameStart();
                break;
            case "Start2":
                gameScreen.SetBlockNum(6);
                GameStart();
                break;
            case "Start3":
                gameScreen.SetBlockNum(7);
                GameStart();
                break;
            case "Start4":
                gameScreen.SetBlockNum(8);
                GameStart();
                break;
            case "Start5":
                gameScreen.SetBlockNum(9);
                GameStart();
                break;
            case "Redo":
                gameScreen.Redo();
                break;
            case "Undo":
                gameScreen.Undo();
                break;
            case "Reset":
                gameScreen.GameStart();
                break;
            case "Return":
                gameScreen.GameStop();
                ReSize();
                home.Visible = true;
                break;
        }
    }
}