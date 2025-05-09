using MysGame.data.script.text;
using MysGame.data.script.ui;
using Newtonsoft.Json;

namespace MysGame.data.script;

public class GameManager
{
    private StateLine _currentStateLine;
    private readonly TextManager _textManager;
    private readonly UIManager _uiManager;

    public GameManager(Form form, Control textBox)
    {
        _textManager = new TextManager(textBox);
        _uiManager = new UIManager(form);

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
                break;
            case StateLine.Prologue:
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