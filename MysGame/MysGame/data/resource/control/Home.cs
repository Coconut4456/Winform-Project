namespace MysGame.data.resource.control;

public partial class Home : UserControl
{
    // public event Action NewGameClicked;
    public event Action<string>? ButtonClicked;
    
    public Home()
    {
        InitializeComponent();
        this.Visible = false;
        this.Location = new Point(0, 0);

        foreach (Control control in Controls)
        {
            if (control is Button button)
            {
                button.Click += (s, e) => ButtonClicked?.Invoke(@$"{control.Name}");
            }
        }
    }
}