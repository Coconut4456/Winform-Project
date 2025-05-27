using MysGame.data;
using MysGame.data.script;
using MysGame.data.script.text;
using MysGame.data.script.ui;

namespace MysGame;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm(new GameManager(), new UIManager(), new TextManager()));
    }
}