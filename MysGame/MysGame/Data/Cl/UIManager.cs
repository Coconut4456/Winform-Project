using MysGame.Data.Cl.UI;

namespace MysGame.Data.Cl;

public class UIManager
{
    
    public UIManager() {}

    // 폼 컨트롤 업데이트
    public void ControlUpdate(List<Control> controlList)
    {
        foreach (var control in controlList)
        {
            control.Text = TextLoader.GetScriptList("UI");
            Form1.Instance().Controls.Add(control);
        }
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
    
    // 패널 전환
    public void SwitchControl(List<Control> controlList, Panel switchControl)
    {
        if (switchControl.GetType() == typeof(Panel))
        {
            switchControl.Dock = DockStyle.Fill;
        }
        
        switchControl.Visible = true;
        switchControl.BringToFront();

        foreach (var control in controlList)
        {
            if (control != switchControl)
            {
                control.Visible = false;
            }

            if (control.GetType() == typeof(Panel))
            {
                control.Dock = DockStyle.Fill;
            }
        }
    }
}