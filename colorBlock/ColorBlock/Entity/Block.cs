using Timer = System.Windows.Forms.Timer;

namespace ColorBlock.Entity;

public class Block
{
    public Label Label { get; set; }
    public readonly Timer Timer;
    private int _timerCount;
    private Size _defaultSize;
    private Point _defaultPoint;

    public Block()
    {
        Label = new Label();
        Label.TabStop = false;
        Label.Visible = true;
        Timer = new Timer();
        Timer.Tick += Timer_Tick!;
        Timer.Interval = 30;
    }

    // 블럭 파괴 이펙트 타이머
    private void Timer_Tick(object sender, EventArgs e)
    {
        // 시작 크기, 위치 저장
        if (_timerCount == 0)
        {
            _defaultSize = Label.Size;
            _defaultPoint = Label.Location;
        }
        
        // 이펙트 실행 후 크기, 위치 복구
        if (_timerCount >= 5)
        {
            Label.Size = _defaultSize;
            Label.Location = _defaultPoint;
            Label.BackColor = Color.White;
            Timer.Stop();
            return;
        }
        
        _timerCount++;
        Label.Size = new Size(Label.Size.Height - 6, Label.Size.Width - 6);
        Label.Location = new Point(Label.Location.X + 3, Label.Location.Y + 3);
    }
}