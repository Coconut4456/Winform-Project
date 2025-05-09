namespace MysGame.data.resource.control;

public partial class Home : UserControl
{
    public Label TitleLabel => titleLabel;
    public Button NewGameButton => newGameButton;
    public Button LoadButton => loadButton;
    public Button SettingButton => settingButton;
    public Button ExitButton => exitButton;

    private IEnumerable<Control> GetAllControls(Control control)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.SelectMany(c => GetAllControls(c)).Concat(controls);
    }
    
    public Home()
    {
        InitializeComponent();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        
    }
}