using Timer = System.Windows.Forms.Timer;

namespace MysGame.data.script.text;

public class TextManager
{
    private Control _textBox = new ();
    private List<string> _textStringList = new ();
    private readonly List<char> _textCharList = new ();
    private readonly Timer _typingTimer;
    private int _currentIndex;
    private bool _isPrinting;
    public string CurrentLanguage { get; set; }

    public TextManager()
    {
        _typingTimer = new Timer();
        _typingTimer.Tick += TypingTimer_Tick!;
        _typingTimer.Interval = 100;
        _currentIndex = 0;
        _isPrinting = false;
        CurrentLanguage = "en";
    }

    public void SetTextBox(Control textBox)
    {
        _textBox = textBox;
    }

    // 언어 설정
    public void SetPath()
    {
        string narrationPath = $@"data/resource/text/{CurrentLanguage}/narration.json";
        string dialoguePath = $@"data/resource/text/{CurrentLanguage}/dialogue.json";
        string uiPath = $@"data/resource/text/{CurrentLanguage}/ui.json";
        TextLoader.LoadTexts(narrationPath, dialoguePath, uiPath);
    }

    // 텍스트 불러오기
    public void LoadScriptTexts(string textTitle)
    {
        _textStringList = TextLoader.GetScriptList(textTitle);
    }

    /// <summary>
    /// 타이핑 애니메이션 타이머 틱
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

    /// <summary>
    /// textBox에 현재 설정된 텍스트 출력
    /// 타이핑 애니메이션 타이머 동작
    /// </summary>
    public void PrintText()
    {
        _textBox.BringToFront();
        _textBox.Visible = true;
        
        if (_textCharList.Count <= 0)
        {
            // 문장 출력 후 상태 전환 추가 필요
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

    /// <summary>
    /// 현재 설정된 언어 반환
    /// </summary>
    /// <returns></returns>
    public string GetCurrentLanguage()
    {
        return CurrentLanguage;
    }
}