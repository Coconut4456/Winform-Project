namespace KnightsJourney.resource;

public partial class Home : UserControl
{
    public event Action<string>? OnButtonClick;
    private int _buttonCount;
    private int _spacePerButton;
    private int _margin;
    private readonly int _buttonWidth;
    private readonly int _buttonHeight;
    public bool TimeAttackChecked;
    
    public Home()
    {
        InitializeComponent();
        this.Name = "Home";
        this.BackColor = Color.Black;
        this.Location = new Point(0, 0);
        this.BorderStyle = BorderStyle.FixedSingle;
        this.Dock = DockStyle.Fill;
        this.Visible = true;
        _buttonWidth = 100;
        _buttonHeight = 100;
        TimeAttackChecked = false;
        
        CheckBox checkBox = new CheckBox();
        checkBox.Size = new Size(this.Width, 40);
        checkBox.Location = new Point(0, 0);
        checkBox.Text = @"타임어택 활성화";
        checkBox.ForeColor = Color.White;
        checkBox.BackColor = Color.Black;
        checkBox.Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold);
        checkBox.TextAlign = ContentAlignment.MiddleCenter;
        checkBox.CheckAlign = ContentAlignment.BottomCenter;
        checkBox.Dock = DockStyle.Top;
        checkBox.CheckedChanged += (sender, args) => { TimeAttackChecked = !TimeAttackChecked; };
        this.Controls.Add(checkBox);
        
        Label label = new Label();
        label.Size = new Size(this.Width, 100);
        label.Location = new Point(0, 0);
        label.Text = "기사의 여행\n원하시는 게임을 선택하세요!";
        label.ForeColor = Color.White;
        label.BackColor = Color.Black;
        label.Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold);
        label.TextAlign = ContentAlignment.MiddleCenter;
        label.Dock = DockStyle.Top;
        this.Controls.Add(label);
    }

    /// <summary>
    /// 상태 전환
    /// </summary>
    public void SetVisible()
    {
        this.Visible = !this.Visible;
    }
    
    /// <summary>
    /// 게임 설정 버튼 생성
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    public void AddGameButton(int min, int max)
    {
        _buttonCount = max - min + 1;
        _spacePerButton = this.Width / _buttonCount;
        _margin = (_spacePerButton - _buttonWidth) / 2;
        
        for (int i = 0; i < _buttonCount; i++)
        {
            Button button = new Button();
            button.Name = "button" + i;
            button.Text = $@"{min + i} X {min + i}선택";
            button.Tag = $"Start{i + 1}";
            button.Size = new Size(_buttonWidth, _buttonHeight);
            button.BackColor = Color.White;
            int x = (i * _spacePerButton) + _margin;
            int y = (this.Height / 2);
            button.Location = new Point(x, y);
            button.Click += (s, e) => OnButtonClick?.Invoke($@"{button.Tag}");
            this.Controls.Add(button);
        }
    }
}