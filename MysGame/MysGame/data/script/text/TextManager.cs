using Timer = System.Windows.Forms.Timer;

namespace MysGame.data.script.text;

public class TextManager
{
    private Control _textLabel;
    private readonly Timer _typingTimer;
    public string CurrentLanguage { get; set; }
    private List<string> _currentScriptList;
    private readonly List<char> _currentCharList;
    private int _printIndex;
    
    public TextManager()
    {
        _textLabel = new Label();
        _typingTimer = new Timer();
        _typingTimer.Tick += TypingTimer_Tick!;
        _typingTimer.Interval = 100;
        CurrentLanguage = "";
        _currentScriptList = new List<string>();
        _currentCharList = new List<char>();
        _printIndex = 0;
    }

    /// <summary>
    /// Text 출력할 컨트롤 참조
    /// </summary>
    /// <param name="textLabel"></param>
    public void SetTextLabel(Control textLabel)
    {
        _textLabel = textLabel;
    }

    /// <summary>
    ///  텍스트 출력
    /// </summary>
    public void PrintText()
    {
        if (_typingTimer.Enabled)
            return;
        
        if (_currentScriptList.Count == 0)
            return; // 출력 다 끝나면 이벤트 호출
        
        SplitText();
        _printIndex = 0;
        _textLabel.Text = "";
        _typingTimer.Start();
    }
    
    /// <summary>
    /// string 리스트를 char 리스트로 쪼개고 저장
    /// </summary>
    private void SplitText()
    {
        _currentCharList.Clear();
        
        if (_currentScriptList.Count == 0)
            return;
        
        foreach (var c in _currentScriptList[0])
        {
            _currentCharList.Add(c);
        }

        _currentScriptList.RemoveAt(0);
    }
    
    /// <summary>
    /// 타이핑 애니메이션 타이머
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TypingTimer_Tick(object sender, EventArgs e)
    {
        if (_currentCharList.Count <= _printIndex)
        {
            _printIndex = 0;
            _typingTimer.Stop();
            return;
        }
        
        _textLabel.Text += _currentCharList[_printIndex];
        _printIndex++;
    }

    /// <summary>
    /// 언어 설정
    /// </summary>
    public void SetPath()
    {
        string narrationPath = $@"data/resource/text/{CurrentLanguage}/narration.json";
        string dialoguePath = $@"data/resource/text/{CurrentLanguage}/dialogue.json";
        string uiPath = $@"data/resource/text/{CurrentLanguage}/ui.json";
        TextLoader.LoadTexts(narrationPath, dialoguePath, uiPath);
    }

    /// <summary>
    /// 텍스트 불러오기
    /// </summary>
    /// <param name="textTitle"></param>
    /// <returns></returns>
    public void LoadScriptTexts(string textTitle)
    {
        _currentScriptList = TextLoader.GetScriptList(textTitle);
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