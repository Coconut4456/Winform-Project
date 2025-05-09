using Timer = System.Windows.Forms.Timer;

namespace MysGame.Data.Cl;

public class TextManager
{
    private List<string> _textStringList;
    private readonly List<char> _textCharList;
    private readonly Timer _typingTimer;
    private readonly Control _textBox;
    private int _currentIndex;
    private bool _isPrinting;

    public TextManager(string path, Control control)
    {
        TextLoader.Load(path);
        _textBox = control;
        _textStringList = new List<string>();
        _textCharList = new List<char>();
        _typingTimer = new Timer();
        _typingTimer.Tick += TypingTimer_Tick!;
        _typingTimer.Interval = 100;
        _currentIndex = 0;
        _isPrinting = false;
    }

    // 텍스트 불러오기
    public void LoadTexts(string textTitle)
    {
        _textStringList = TextLoader.GetScriptList(textTitle);
    }

    // 타이핑 애니메이션 타이머
    private void TypingTimer_Tick(object sender, EventArgs e)
    {
        if (_textCharList.Count <= _currentIndex)
        {
            _currentIndex = 0;
            _isPrinting = false;
            _typingTimer.Stop();
            return;
        }
        
        _textBox.Text += _textCharList[_currentIndex];
        _currentIndex++;
    }

    // control.text에 텍스트 출력
    public void PrintText()
    {
        if (_textCharList.Count <= 0)
        {
            
        }
        
        if (_isPrinting)
        {
            return; // 문장 출력 끝마친 후 중단 // 임시
        }
        
        _textCharList.Clear();
        _textBox.Text = "";
        
        foreach (var c in _textStringList[0])
        {
            _textCharList.Add(c);
        }

        _isPrinting = true;
        _textStringList.RemoveAt(0);
        _typingTimer.Start();
    }
}