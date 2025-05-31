namespace KnightsJourney.resource;

public partial class Home : UserControl
{
    public event Action<string>? OnButtonClick;
    private int _buttonCount;
    private int _spacePerButton;
    private int _margin;
    private readonly int _buttonWidth;
    private readonly int _buttonHeight;
    
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
    public void AddButton(int min, int max)
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