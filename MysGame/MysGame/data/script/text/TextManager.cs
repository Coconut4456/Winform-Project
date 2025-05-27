using Timer = System.Windows.Forms.Timer;

namespace MysGame.data.script.text;

public class TextManager
{
    public string CurrentLanguage { get; set; }
    private List<string> _currentScriptList;

    public TextManager()
    {
        CurrentLanguage = "en";
        _currentScriptList = new List<string>();
    }
    
    /// <summary>
    /// string 리스트를 char 리스트로 쪼개고 저장해서 반환
    /// </summary>
    public List<Char> GetSplitText()
    {
        List<Char> textCharList = new();
        
        foreach (var c in _currentScriptList[0])
        {
            textCharList.Add(c);
        }

        _currentScriptList.RemoveAt(0);
        return textCharList;
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