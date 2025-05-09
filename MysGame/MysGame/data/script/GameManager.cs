using MysGame.data.script.text;
using MysGame.data.script.ui;
using Newtonsoft.Json;

namespace MysGame.data.script;

public class GameManager
{
    private StateLine _currentStateLine;
    private readonly UIManager _uiManager;
    private readonly TextManager _textManager;

    public GameManager(Form form, Control textBox, List<Control> panels, List<Control> labels, List<Control> buttons)
    {
        _uiManager = new UIManager(panels, labels, buttons);
        _textManager = new TextManager(textBox);

        ApplyUIText();
    }

    // 게임 상태 설정
    public void SetState(string state)
    {
        if (Enum.TryParse(state, out StateLine stateLine))
        {
            _currentStateLine = stateLine;
        }
        else
        {
            Console.WriteLine(@"Invalid state");
        }

        switch (_currentStateLine)
        {
            case StateLine.Home:
                _uiManager.SwitchPanel("homePanel");
                break;
            case StateLine.Prologue:
                _uiManager.SwitchPanel("gamePanel");
                _uiManager.MoveControl(targetControl: _textManager.GetTextBox(), width: 400, height: 100, x: 0, y: 100);
                _uiManager.UI_Horizontal_Centering(_uiManager.GetPanel("gamePanel"), targetControl: _textManager.GetTextBox());
                _textManager.LoadTexts("Prologue");
                _textManager.PrintText();
                break;
        }
    }

    // 컨트롤 텍스트에 ui.json 텍스트 할당
    private void ApplyUIText()
    {
        foreach (Control control in _uiManager.LabelList)
        {
            if (TextLoader.GetUIText(control.Name) == "") continue;
            control.Text = TextLoader.GetUIText(control.Name);
        }
        foreach (Control control in _uiManager.ButtonList)
        {
            if (TextLoader.GetUIText(control.Name) == "") continue;
            control.Text = TextLoader.GetUIText(control.Name);
        }
    }

    // TextBox 출력
    public void PrintText()
    {
        _textManager.PrintText();
    }
}