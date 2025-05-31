using System.Reflection.Metadata.Ecma335;
using Timer = System.Windows.Forms.Timer;

namespace KnightsJourney;

public partial class Form1 : Form
{
    private List<Control> _mainControls;
    private List<Control> _gamelabels;
    private int _blockNum;
    private readonly int _formWidth;
    private readonly int _formHeight;
    private readonly int _buttonWidth;
    private readonly int _buttonHeight;
    private int _buttonCount;
    private int _spacePerButton;
    private int _margin;
    private readonly int _labelWidth;
    private readonly int _labelHeight;
    private int _currentNum;
    private readonly Stack<Control> _redoStack;
    private readonly Stack<Control> _undoStack;
    private int _formTotalX;
    private int _formTotalY;
    private Timer _gameTimer;
    private Label _playTimeLabel;
    private float _playTime;
    private int _timeCount;
    private Color _labelColor;
    
    public Form1()
    {
        InitializeComponent();
        _mainControls = new List<Control>();
        _gamelabels = new List<Control>();
        _redoStack = new Stack<Control>();
        _undoStack = new Stack<Control>();
        _gameTimer = new Timer();
        _playTimeLabel = new Label();
        
        this.Text = "KnightsJourney";
        this.ClientSize = new Size(800, 800);
        this.AutoScaleMode = AutoScaleMode.Dpi;
        this.BackColor = Color.Black;
        this.KeyPreview = true;
        
        _formWidth = this.ClientSize.Width;
        _formHeight = this.ClientSize.Height;
        _buttonWidth = 100;
        _buttonHeight = 100;
        _labelWidth = 100;
        _labelHeight = 100;
        _currentNum = 1;
        _gameTimer.Interval = 100;
        _gameTimer.Tick += Timer_Tick!;
        _playTime = 30.00f;
        _labelColor = Color.White;

        AddButton(5, 9);
    }

    private void GameStart()
    {
        _formTotalX = (_blockNum * _labelWidth) + (_blockNum * 5) + 5;
        _formTotalY = (_blockNum * _labelHeight) + (_blockNum * 5) + 5;
        HideMain();
        AddLabel();
        AddUI();
        this.ClientSize = new Size(_formTotalX, _formTotalY);
        _playTime = 30.00f;
        _timeCount = 0;
        _gameTimer.Start();
    }

    private void AddUI()
    {
        Button button1 = new Button();
        button1.Size = new Size(_buttonWidth, _buttonHeight);
        button1.Location = new Point(_formTotalX, _formTotalY - (button1.Height * 2) - 10);
        button1.ForeColor = Color.White;
        button1.Text = @"←";
        button1.Click += Button_Click!;
        button1.Tag = "Redo";
        this.Controls.Add(button1);
        
        Button button2 = new Button();
        button2.Size = button1.Size;
        button2.Location = new Point(button1.Location.X + button1.Width + 5, _formTotalY - (button2.Height * 2) - 10);
        button2.ForeColor = Color.White;
        button2.Text = @"→";
        button2.Click += Button_Click!;
        button2.Tag = "Undo";
        this.Controls.Add(button2);
        
        Button button3 = new Button();
        button3.Size = new Size(button1.Width, button1.Height);
        button3.Location = new Point(_formTotalX, _formTotalY - button1.Height - 5);
        button3.ForeColor = Color.White;
        button3.Text = @"초기화";
        button3.Click += Button_Click!;
        button3.Tag = "Reset";
        this.Controls.Add(button3);
        
        Button button4 = new Button();
        button4.Size = new Size(button1.Width, button1.Height);
        button4.Location = new Point(button1.Location.X + button1.Width + 5, _formTotalY + button1.Height - 5);
        button4.ForeColor = Color.White;
        button4.Text = @"처음으로";
        button4.Click += Button_Click!;
        button4.Tag = "Return";
        this.Controls.Add(button4);

        _playTimeLabel.BackColor = Color.Black;
        _playTimeLabel.ForeColor = Color.White;
        _playTimeLabel.BorderStyle = BorderStyle.FixedSingle;
        _playTimeLabel.Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold);
        _playTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
        _playTimeLabel.Size = new Size(button1.Width + button2.Width + 5, button1.Height);
        _playTimeLabel.Location = new Point(_formTotalX, 5);
        _playTimeLabel.Text = "";
        this.Controls.Add(_playTimeLabel);
        
        _formTotalX += button1.Width + 5;
        _formTotalX += button2.Width + 5;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        if (Math.Abs(_playTime) < 0.001f)
        {
            _playTime = 0f;
        }
        
        if (Math.Abs(_playTime % 1f) < 0.001f)
        {
            _playTime -= 0.40f;
        }

        if (_timeCount >= 60)
        {
            _playTime -= 1f;
            _timeCount = 0;
        }
        
        _playTime -= 0.01f;
        _timeCount++;
        _playTimeLabel.Text = _playTime.ToString("0.00");
    }

    /// <summary>
    /// 버튼 클릭 되돌리기
    /// </summary>
    private void Redo()
    {
        if (_redoStack.Count <= 0)
            return;
                    
        Control currentLabel = _redoStack.Pop();
        currentLabel.BackgroundImage = null;
        currentLabel.BackColor = _labelColor;
        currentLabel.Text = "";
        currentLabel.Tag = 0;
        _undoStack.Push(currentLabel);
        _currentNum--;
        
        if (_redoStack.Count != 0)
        {
            Control control = _redoStack.Peek();
            control.BackColor = Color.LimeGreen;
            control.BackgroundImage = Image.FromFile(@"Resources\Knight1.png");
        }
    }

    /// <summary>
    /// 되돌린 클릭 복구
    /// 겁나게 헷갈리네 여기
    /// </summary>
    private void Undo()
    {
        if (_undoStack.Count <= 0)
            return;
        
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
    }

    /// <summary>
    /// 나이트 이동 가능 확인
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private bool CheckValidMove(int index)
    {
        // index = 말을 이동시킬 위치
        int currentIndex = _gamelabels.IndexOf(_redoStack.Peek()); // 현재 말 위치
        List<List<int>> gameIndex = [
            [3, 7, 9, 11], [4, 8, 11, 13], [5, 9, 13, 15], [6, 10, 15, 17], [7, 12, 17, 19]];

        foreach (var i in gameIndex[_blockNum - 5])
        {
            if (index == currentIndex - i || index == currentIndex + i)
            {
                return true;
            }
        }

        return false;
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

        if (_redoStack.Count > 0 && !CheckValidMove(_gamelabels.IndexOf(label)))
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
                
                label.BackgroundImage = Image.FromFile(@"Resources\Knight1.png");
                label.BackColor = Color.Green;
                label.Text = _currentNum.ToString();
                label.Tag = 1;
                _currentNum++;
                _redoStack.Push(label);
                break;
            case 1:
                if (label.Text != (_currentNum - 1).ToString()) 
                    return;
                
                Redo();
                break;
        }
    }

    /// <summary>
    /// 게임 설정 버튼 생성
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    private void AddButton(int min, int max)
    {
        _buttonCount = max - min + 1;
        _spacePerButton = _formWidth / _buttonCount;
        _margin = (_spacePerButton - _buttonWidth) / 2;
        
        for (int i = 0; i < _buttonCount; i++)
        {
            Button button = new Button();
            button.Name = "button" + i;
            button.Text = $"{min + i} X {min + i}\n선택";
            button.Tag = $"Start{i + 1}";
            button.Size = new Size(_buttonWidth, _buttonHeight);
            button.BackColor = Color.White;
            int x = (i * _spacePerButton) + _margin;
            int y = (_formHeight / 2) + _buttonHeight;
            button.Location = new Point(x, y);
            button.Click += Button_Click!;
            this.Controls.Add(button);
            button.BringToFront();
        }
    }
    
    /// <summary>
    /// 버튼 클릭 동작
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click(object sender, EventArgs e)
    {
        switch ((sender as Button)!.Tag)
        {
            case "Start1":
                _blockNum = 5;
                GameStart();
                break;
            case "Start2":
                _blockNum = 6;
                GameStart();
                break;
            case "Start3":
                _blockNum = 7;
                GameStart();
                break;
            case "Start4":
                _blockNum = 8;
                GameStart();
                break;
            case "Start5":
                _blockNum = 9;
                GameStart();
                break;
            case "Redo":
                Redo();
                break;
            case "Undo":
                Undo();
                break;
            case "Reset":
                _gameTimer.Stop();
                ShowMain();
                break;
        }
    }

    private void ShowMain()
    {
        foreach (Control control in Controls)
        {
            control.Visible = true;
        }

        foreach (var control in _gamelabels)
        {
            this.Controls.Remove(control);
        }
        
        _mainControls.Clear();
    }

    /// <summary>
    /// 현재 모든 컨트롤 숨김
    /// </summary>
    private void HideMain()
    {
        foreach (Control control in Controls)
        {
            _mainControls.Add(control);
            control.Visible = false;
        }
    }
    
    /// <summary>
    /// 게임 라벨 생성
    /// </summary>
    private void AddLabel()
    {
        for (int i = 0; i < _blockNum; i++) // y
        {
            for (int j = 0; j < _blockNum; j++) // x
            {
                Label label = new Label();
                label.Size = new Size(_labelWidth, _labelHeight);
                label.Location = new Point((j * label.Size.Width) + (j * 5) + 5, (i * label.Size.Height) + (i * 5) + 5);
                label.BackColor = _labelColor;
                label.BorderStyle = BorderStyle.FixedSingle;
                label.Font = new Font(FontFamily.GenericSansSerif, 14);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Tag = 0;
                label.Click += Label_Click!;
                _gamelabels.Add(label);
                this.Controls.Add(label);
            }
        }
    }
}