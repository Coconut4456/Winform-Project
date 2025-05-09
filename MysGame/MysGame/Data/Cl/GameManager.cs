using MysGame.Data.Cl;
using MysGame.Data.Cl.UI;

namespace MysGame.Data.Cl;

public class GameManager
{
    public StateLine CurrentStateLine;
    private readonly UIManager _uiManager;
    private readonly TextManager _textManager;

    public GameManager(UIManager uiManager, TextManager textManager)
    {
        _uiManager = uiManager;
        _textManager = textManager;
    }

    public void SetState(string state)
    {
        if (Enum.TryParse(state, out StateLine stateLine))
        {
            CurrentStateLine = stateLine;
        }
        else
        {
            Console.WriteLine(@"Invalid state");
        }

        switch (CurrentStateLine)
        {
            case StateLine.Prologue:
                _uiManager.SwitchControl(_panels, gamePanel);
                _uiManager.MoveControl(targetControl:_textBox, width:400, height:100, x: 0, y:100);
                _uiManager.UI_Horizontal_Centering(standardControl: gamePanel, targetControl:_textBox);
                _textManager.LoadTexts("Prologue");
                _textManager.PrintText(_textBox);
        }
    }
}