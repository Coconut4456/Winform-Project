using Timer = System.Windows.Forms.Timer;

namespace KnightsJourney.resource;

public partial class GameScreen : UserControl
{
    public event Action<string>? OnButtonClick;
    private readonly int _buttonWidth;
    private readonly int _buttonHeight;
    private readonly int _labelWidth;
    private readonly int _labelHeight;
    private readonly Color _labelColor;
    private readonly Stack<Control> _redoStack;
    private readonly Stack<Control> _undoStack;
    private readonly Timer _gameTimer;
    private int _playTime;
    private int _currentNum;
    private int _blockNum;
    private int _totalX;
    private int _totalY;
    private Size _totalSize;
    private bool _moveFailed;
    
    public GameScreen()
    {
        InitializeComponent();
        this.Name = "GameScreen";
        this.BackColor = Color.Black;
        this.Dock = DockStyle.Fill;
        _redoStack = new Stack<Control>();
        _undoStack = new Stack<Control>();
        _gameTimer = new Timer();
        
        _buttonWidth = 100;
        _buttonHeight = 100;
        _labelWidth = 100;
        _labelHeight = 100;
        _labelColor = Color.White;

        _gameTimer.Interval = 1000;
        _gameTimer.Tick += GameTimer_Tick!;
        _currentNum = 1;
    }

    /// <summary>
    /// 게임 시작
    /// </summary>
    public void GameStart()
    {
        _gameTimer.Stop();
        this.Visible = true;

        while (_redoStack.Count != 0)
        {
            Redo();
        }

        _currentNum = 0;
        _redoStack.Clear();
        _undoStack.Clear();
        this.Controls["RedoButton"]!.Visible = false;
        this.Controls["UndoButton"]!.Visible = false;
    }

    /// <summary>
    /// 게임 중단
    /// </summary>
    public void GameStop()
    {
        _gameTimer.Stop();
        this.Visible = false;
        _redoStack.Clear();
        _undoStack.Clear();
        _currentNum = 0;
    }

    /// <summary>
    /// 타임어택 활성화 여부 확인
    /// </summary>
    /// <param name="checkTimeAttack"></param>
    public void CheckTimeAttack(bool checkTimeAttack)
    {
        if (!checkTimeAttack)
            return;
        
        _gameTimer.Start();
        _playTime = 1200;
    }
    
    public Size GetTotalSize() => _totalSize;

    /// <summary>
    /// 블럭 개수 초기화
    /// </summary>
    /// <param name="blockNum"></param>
    public void SetBlockNum(int blockNum)
    {
        _blockNum = blockNum;
        _totalX = (_blockNum * _labelWidth) + (_blockNum * 5) + 5; 
        _totalY = (_blockNum * _labelHeight) + (_blockNum * 5) + 5;
    }

    /// <summary>
    /// 게임 시간 타이머
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void GameTimer_Tick(object sender, EventArgs e)
    {
        if (_playTime <= 0)
        {
            _gameTimer.Stop();
            MessageBox.Show("GAME OVER\n시간이 모두 소요되었습니다.");
            OnButtonClick?.Invoke("Return");
            return;
        }
        
        _playTime--;
        this.Controls["TimeLabel"]!.Text = _playTime.ToString();

        if (!_moveFailed) 
            return;

        this.Controls["TimeLabel"]!.Text = _playTime + "\n-10";
        _moveFailed = false;
    }

    /// <summary>
    /// 버튼 클릭 되돌리기
    /// </summary>
    public void Redo()
    {
        Control currentLabel = _redoStack.Pop();
        currentLabel.BackgroundImage = null;
        currentLabel.BackColor = _labelColor;
        currentLabel.Text = "";
        currentLabel.Tag = 0;
        _undoStack.Push(currentLabel);
        _currentNum--;

        if (_undoStack.Count > 0)
        {
            this.Controls["UndoButton"]!.Visible = true;
        }
        
        if (_redoStack.Count != 0)
        {
            Control control = _redoStack.Peek();
            control.BackColor = Color.LimeGreen;
            control.BackgroundImage = Image.FromFile(@"Resources\Knight1.png");
        }
        
        if (_redoStack.Count <= 0)
        {
            this.Controls["RedoButton"]!.Visible = false;
        }
    }

    /// <summary>
    /// 되돌린 클릭 복구
    /// 겁나게 헷갈리네 여기
    /// </summary>
    public void Undo()
    {
        if (_redoStack.Count != 0)
        {
            Control control = _redoStack.Peek();
            control.BackColor = Color.LimeGreen;
            control.BackgroundImage = null;
        }
        
        Control currentLabel = _undoStack.Pop();
        currentLabel.BackgroundImage = Image.FromFile(@"Resources\Knight1.png");
        currentLabel.BackColor = Color.LimeGreen;
        currentLabel.Text = _currentNum.ToString();
        currentLabel.Tag = 1;
        _redoStack.Push(currentLabel);
        _currentNum++;
        
        if (_undoStack.Count <= 0)
        {
            this.Controls["UndoButton"]!.Visible = false;
        }
    }

    /// <summary>
    /// 나이트 이동 가능 확인
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private bool CheckValidMove(int index)
    {
        // index = 말을 이동시킬 위치
        // currentIndex = 현재 말 위치
        string name = _redoStack.Peek().Name;
        int currentIndex = int.Parse(name);
        
        List<List<int>> gameIndex = [
            [3, 7, 9, 11], [4, 8, 11, 13], [5, 9, 13, 15], [6, 10, 15, 17], [7, 11, 17, 19]];

        foreach (var i in gameIndex[_blockNum - 5])
        {
            if (index == currentIndex - i || index == currentIndex + i)
            {
                return true;
            }
        }

        _moveFailed = true;
        _playTime -= 10;
        return false;
    }
    
    /// <summary>
    /// 게임 라벨 생성
    /// </summary>
    public void AddLabel()
    {
        int labelCount = 0;
        
        for (int i = 0; i < _blockNum; i++) // y
        {
            for (int j = 0; j < _blockNum; j++) // x
            {
                Label label = new Label();
                label.Name = $"{labelCount}";
                label.Size = new Size(_labelWidth, _labelHeight);
                label.Location = new Point((j * label.Size.Width) + (j * 5) + 5, (i * label.Size.Height) + (i * 5) + 5);
                label.BackColor = _labelColor;
                label.BorderStyle = BorderStyle.FixedSingle;
                label.Font = new Font(FontFamily.GenericSansSerif, 14);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Tag = 0;
                label.Click += Label_Click!;
                this.Controls.Add(label);
                labelCount++;
            }
        }
    }
    
    /// <summary>
    /// 버튼 및 타이머용 라벨 생성
    /// </summary>
    public void AddUI()
    {
        Button button1 = new Button();
        button1.Name = "RedoButton";
        button1.Size = new Size(_buttonWidth, _buttonHeight);
        button1.Location = new Point(_totalX, _totalY - (button1.Height * 2) - 10);
        button1.ForeColor = Color.White;
        button1.Text = @"←";
        button1.Click += (s, e) => OnButtonClick?.Invoke("Redo");
        button1.Tag = "Redo";
        button1.Visible = false;
        this.Controls.Add(button1);
        
        Button button2 = new Button();
        button2.Name = "UndoButton";
        button2.Size = button1.Size;
        button2.Location = new Point(button1.Location.X + button1.Width + 5, _totalY - (button2.Height * 2) - 10);
        button2.ForeColor = Color.White;
        button2.Text = @"→";
        button2.Click += (s, e) => OnButtonClick?.Invoke("Undo");
        button2.Tag = "Undo";
        button2.Visible = false;
        this.Controls.Add(button2);
        
        Button button3 = new Button();
        button3.Size = new Size(button1.Width, button1.Height);
        button3.Location = new Point(_totalX, _totalY - button1.Height - 5);
        button3.ForeColor = Color.White;
        button3.Text = @"초기화";
        button3.Click += (s, e) => OnButtonClick?.Invoke("Reset");
        button3.Tag = "Reset";
        this.Controls.Add(button3);
        
        Button button4 = new Button();
        button4.Size = new Size(button1.Width, button1.Height);
        button4.Location = new Point(button1.Location.X + button1.Width + 5, _totalY - button1.Height - 5);
        button4.ForeColor = Color.White;
        button4.Text = @"처음으로";
        button4.Click += (s, e) => OnButtonClick?.Invoke("Return");
        button4.Tag = "Return";
        this.Controls.Add(button4);
        
        Label label1 = new Label();
        label1.Name = "TimeLabel";
        label1.BackColor = Color.Black;
        label1.ForeColor = Color.White;
        label1.BorderStyle = BorderStyle.FixedSingle;
        label1.Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold);
        label1.TextAlign = ContentAlignment.MiddleCenter;
        label1.Size = new Size(button1.Width + button2.Width + 5, button1.Height);
        label1.Location = new Point(_totalX, 5);
        label1.Text = "";
        label1.Tag = "TimeLabel";
        this.Controls.Add(label1);

        _totalSize = new Size(_totalX + (button1.Width + button2.Width + 25), _totalY + 40);
    }
    
    /// <summary>
    /// 라벨 클릭시 표시
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Label_Click(object sender, EventArgs e)
    {
        if (sender is not Control label)
            return;

        if (_redoStack.Count > 0 && !CheckValidMove(int.Parse(label.Name)))
        {
            return;
        }
        
        switch (label.Tag)
        {
            case 0:
                if (_redoStack.Count != 0)
                {
                    Control control = _redoStack.Peek();
                    control.BackColor = Color.LimeGreen;
                    control.BackgroundImage = null;
                }

                _currentNum++;
                label.BackgroundImage = Image.FromFile(@"Resources\Knight1.png");
                label.BackColor = Color.Green;
                label.Text = _currentNum.ToString();
                label.Tag = 1;

                // 모든 말을 놓았다면 게임 종료
                if (_currentNum >= _blockNum * _blockNum)
                {
                    MessageBox.Show(@"여행이 끝났습니다!");
                    OnButtonClick!.Invoke("Return");
                    return;
                }
                
                _redoStack.Push(label);
                
                if (_redoStack.Count > 0)
                {
                    this.Controls["RedoButton"]!.Visible = true;
                }
                
                break;
            case 1:
                if (label.Text != (_currentNum - 1).ToString()) 
                    return;
                
                Redo();
                break;
        }
    }
}