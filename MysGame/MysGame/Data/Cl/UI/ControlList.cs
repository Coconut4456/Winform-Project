namespace MysGame.Data.Cl.UI;

public class ControlList
{
    public List<Control> _controls;
    
    public ControlList()
    {
        _controls = new List<Control>();
        AddControl(new Panel(), "homePanel", Color.Black, 800, 600);
        AddControl(new Label(), "home_titleLabel", Color.Black, 800, 600);
        AddControl(new Button(), "home_newGameButton", Color.Black, 800, 600);
        AddControl(new Panel(), "gamePanel", Color.Black, 800, 600);
    }
    
    private void AddControl(Control type, string name, Color backColor, int width, int height)
    {
        Control control = type;
        control.Name = name;
        control.BackColor = backColor;
        control.Size = new Size(width, height);
        control.Font = new Font("Ink Free", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        control.Visible = true;
        control.TabStop = false;
        _controls.Add(control);
    }
}