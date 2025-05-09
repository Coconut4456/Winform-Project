namespace MysGame.data.script.ui;

public class ControlRepository
{
    public readonly List<Control> Panels;
    public readonly List<Control> Labels;
    public readonly List<Control> Buttons;
    
    public ControlRepository()
    {
        Panels = new List<Control>();
        Labels = new List<Control>();
        Buttons = new List<Control>();
        
        AddControl(new Panel(), "homePanel", Color.Blue, Color.Black, new Size(800, 600), new Point(0, 0), 0);
        AddControl(new Panel(), "gamePanel", Color.Black, Color.Black, new Size(800, 600), new Point(0, 0), 0);
        
        AddControl(new Label(), "game_textBox", Color.Black, Color.White, new Size(500, 300), new Point(50, 50), 15.75f);
        AddControl(new Label(), "home_titleLabel", Color.Black, Color.White, new Size(400, 600), new Point(50, 50),25f);
        AddControl(new Button(), "home_newGameButton", Color.White, Color.Black, new Size(30, 20), new Point(50, 50),
            15.75f);
        AddControlToPanel(Labels);
        AddControlToPanel(Buttons);
    }

    // 해당 컨트롤 반환
    public void GetControl(Control type, string name, out Control targetControl)
    {
        List<Control> controlList;
        
        switch (type)
        {
            case Panel:
                controlList = Panels;
                break;
            case Label:
                controlList = Labels;
                break;
            case Button:
                controlList = Buttons;
                break;
            default:
                controlList = new List<Control>();
                break;
        }
        
        foreach (var searchControl in controlList)
        {
            if (searchControl.Name != name) continue;
            targetControl = searchControl;
            return;
        }
        
        throw new Exception("control not found");
    }

    // 패널에 컨트롤 추가
    private void AddControlToPanel(List<Control> controlList)
    {
        foreach (var control in controlList)
        {
            if (control.Name.Contains("home"))
            {
                GetControl(new Panel(), "homePanel", out var homePanel);
                homePanel.Controls.Add(control);
            }
            
            if (control.Name.Contains("game"))
            {
                GetControl(new Panel(), "gamePanel", out var gamePanel);
                gamePanel.Controls.Add(control);
            }
        }
    }
    
    // 새 컨트롤 추가
    private void AddControl(Control type, string name, Color backColor, Color foreColor, Size size, Point point, float fontSize)
    {
        if (fontSize == 0)
        {
            fontSize = 15.75f;
        }

        Control control = type;
        control.Name = name;
        control.BackColor = backColor;
        control.ForeColor = foreColor;
        control.Size = size;
        control.Location = point;
        control.Font = new Font("Ink Free", fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
        control.Visible = true;
        control.TabIndex = 0;
        control.TabStop = false;

        switch (type)
        {
            case Panel:
                control.Dock = DockStyle.Fill;
                Panels.Add(control);
                break;
            case Label:
                Labels.Add(control);
                break;
            case Button:
                Buttons.Add(control);
                break;
            default:
                throw new Exception("control not found");
        }
    }
}