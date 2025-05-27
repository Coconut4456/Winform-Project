using System.Diagnostics.CodeAnalysis;
using MysGame.data.resource.control;
using MysGame.data.script.text;
using MysGame.data.script.ui;
using Newtonsoft.Json;

namespace MysGame.data.script;

public class GameManager
{
    private StateLine _currentStateLine;

    public GameManager()
    {
    }

    /// <summary>
    /// 현재 게임 상태 변경
    /// </summary>
    /// <param name="state"></param>
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
    }

    /// <summary>
    /// 현재 게임 상태값 반환
    /// </summary>
    /// <returns></returns>
    public StateLine GetState()
    {
        return _currentStateLine;
    }
}