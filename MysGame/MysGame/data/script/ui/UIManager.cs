using System.Net.Mime;
using Microsoft.VisualBasic.ApplicationServices;
using MysGame.data.resource.control;
using Timer = System.Windows.Forms.Timer;

namespace MysGame.data.script.ui;

public class UIManager
{
    private readonly Dictionary<string, UserControl> _controlMap = new();
    private readonly Timer _typingTimer;
    private List<char> _textCharList;
    private int _printIndex;
    
    public UIManager()
    {
        _typingTimer = new Timer();
        _typingTimer.Tick += TypingTimer_Tick!;
        _typingTimer.Interval = 100;
        _textCharList = new List<char>();
        _printIndex = 0;
    }
    
    public bool IsTyping => _typingTimer.Enabled;

    /// <summary>
    ///  Char 리스트 초기화
    /// </summary>
    /// <param name="textCharList"></param>
    public void SetCharList(List<Char> textCharList)
    {
        if (_typingTimer.Enabled)
            return;
        
        _textCharList = textCharList;
    }

    /// <summary>
    ///  텍스트 출력
    /// </summary>
    public void TypingTimerStart()
    {
        _printIndex = 0;
        _controlMap["TextArea"].Controls["TextLabel"].Text = "";
        _typingTimer.Start();
    }
    
    
    /// <summary>
    /// 타이핑 애니메이션 타이머
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TypingTimer_Tick(object sender, EventArgs e)
    {
        if (_textCharList.Count <= _printIndex)
        {
            _printIndex = 0;
            _typingTimer.Stop();
            return;
        }
        
        _controlMap["TextArea"].Controls["TextLabel"].Text += _textCharList[_printIndex];
        _printIndex++;
    }

    /// <summary>
    /// 맵에 key와 컨트롤을 매핑
    /// </summary>
    /// <param name="key"></param>
    /// <param name="control"></param>
    public void Register(string key, UserControl control)
    {
        _controlMap[key] = control;
    }

    /// <summary>
    /// name에 해당하는 컨트롤 반환
    /// </summary>
    /// <param name="name"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public T GetControl<T>(string name) where T : UserControl
    {
        if (_controlMap[name] is T)
        {
            return (_controlMap[name] as T)!;
        }
        
        throw new NullReferenceException("control is not of type " + typeof(T));
    }

    /// <summary>
    /// 모든 유저 컨트롤 반환
    /// </summary>
    /// <returns></returns>
    public IEnumerable<UserControl> GetAllControls()
    {
        return _controlMap.Values;
    }

    /// <summary>
    /// TextArea 보이기
    /// </summary>
    public void TextBoxShow()
    {
        Control textArea = _controlMap["TextArea"];
        textArea.BringToFront();
        textArea.Visible = true;
    }

    /// <summary>
    /// TextArea 숨기기
    /// </summary>
    public void TextBoxHide()
    {
        _controlMap["TextArea"].Visible = false;
    }

    /// <summary>
    /// key에 해당하는 컨트롤 탐색
    /// 해당 컨트롤 DockStyle.Fill, BringtoFront, Visible = true
    /// </summary>
    /// <param name="key"></param>
    public void SwitchUI(string key)
    {
        // 컨트롤 찾아서 control 변수에 할당
        if (!_controlMap.TryGetValue(key, out var control))
            return;
        
        control.Dock = DockStyle.Fill;
        control.BringToFront();
        control.Visible = true;
    }

    /// <summary>
    /// 컨트롤 위치 이동
    /// </summary>
    /// <param name="control"></param>
    /// <param name="point"></param>
    public void MoveControl(string control, Point point)
    {
        _controlMap[control].Location = point;
    }

    /// <summary>
    /// 컨트롤 수평 정렬
    /// </summary>
    public void HorizontalAlignment(string baseControl, string targetControl)
    {
        Control control;
        Control userControl = _controlMap[baseControl];

        if (targetControl == "TextBox")
        {
            control = _controlMap["TextArea"].Controls["TextLabel"]!;
        }
        else if (_controlMap[baseControl].Controls[targetControl] != null)
        {
            control = _controlMap[baseControl].Controls[targetControl]!;
        }
        else
        {
            throw new NullReferenceException("control is not found");
        }

        int currentX = userControl.Size.Width / 2 - control.Size.Width / 2;
        control.Location = new Point(currentX, control.Location.Y);
    }

    /// <summary>
    /// 컨트롤 수직 정렬
    /// </summary>
    public void VerticalAlignment(string baseControl, string targetControl)
    {
        Control control;
        Control userControl = _controlMap[baseControl];

        if (targetControl == "TextBox")
        {
            control = _controlMap["TextArea"].Controls["TextLabel"]!;
        }
        else if (_controlMap[baseControl].Controls[targetControl] != null)
        {
            control = _controlMap[baseControl].Controls[targetControl]!;
        }
        else
        {
            throw new NullReferenceException("control is not found");
        }
        
        int currentY = userControl.Size.Height / 2 - control.Size.Height / 2;
        control.Location = new Point(control.Location.X, currentY);
    }
}