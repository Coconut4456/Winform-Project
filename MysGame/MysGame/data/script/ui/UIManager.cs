namespace MysGame.data.script.ui;

public class UIManager
{
    public readonly List<Control> PanelList;
    public readonly List<Control> LabelList;
    public readonly List<Control> ButtonList;
    
    public UIManager(List<Control> panels, List<Control> labels, List<Control> buttons)
    {
        PanelList = panels;
        LabelList = labels;
        ButtonList = buttons;
    }
    
    // 컨트롤 크기 및 위치 재설정
    public void MoveControl(Control targetControl, int width, int height, int x, int y)
    {
        targetControl.Size = new Size(width, height);
        targetControl.Location = new Point(x, y);
        targetControl.BringToFront();
        targetControl.Visible = true;
    }
    
    // Controls(List) 수평 중앙 정렬
    public void UI_Horizontal_Centering(Control standardControl, List<Control> targetControls)
    {
        foreach (var targetControl in targetControls)
        {
            targetControl.Location = new Point(standardControl.Size.Width / 2 - targetControl.Size.Width / 2,
                targetControl.Location.Y);
        }
    }

    // Control 수평 중앙 정렬
    public void UI_Horizontal_Centering(Control standardControl, Control targetControl)
    {
        targetControl.Location = new Point(standardControl.Size.Width / 2 - targetControl.Size.Width / 2,
            targetControl.Location.Y);
    }

    // 패널 반환
    public Control GetPanel(string name)
    {
        foreach (var panel in PanelList)
        {
            if (panel.Name == name)
            {
                return panel;
            }
        }
        
        throw new Exception("Panel not found");
    }
    
    // 패널 전환
    public void SwitchPanel(string name)
    {
        foreach (var panel in PanelList)
        {
            if (panel.Name != name)
            {
                panel.Enabled = false;
                panel.Visible = false;
                continue;
            }

            panel.Enabled = true;
            panel.Visible = true;
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
        }
    }
}