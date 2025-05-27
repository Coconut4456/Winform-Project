using System.Net.Mime;
using Microsoft.VisualBasic.ApplicationServices;
using MysGame.data.resource.control;
using Timer = System.Windows.Forms.Timer;

namespace MysGame.data.script.ui;

public class UIManager
{
    private readonly Dictionary<string, UserControl> _controlMap = new();
    
    public UIManager()
    {
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
    /// TextArea 크기 조정
    /// </summary>
    public void SetTextAreaSize(int width, int height)
    {
        _controlMap["TextArea"].Size = new Size(width, height);
    }

    /// <summary>
    /// TextArea 보이기
    /// </summary>
    public void TextAreaShow()
    {
        Control textArea = _controlMap["TextArea"];
        textArea.BringToFront();
        textArea.Visible = true;
    }

    /// <summary>
    /// TextArea 숨기기
    /// </summary>
    public void TextAreaHide()
    {
        _controlMap["TextArea"].Visible = false;
    }

    /// <summary>
    /// 모든 컨트롤 숨김, 해당 컨트롤 보이기
    /// </summary>
    /// <param name="key"></param>
    public void SwitchUI(string key)
    {
        foreach (var userControl in _controlMap)
        {
            userControl.Value.Visible = false;
        }
        
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
    public void HorizontalAlignment(Control baseControl, Control targetControl)
    {
        int currentX = baseControl.Size.Width / 2 - targetControl.Size.Width / 2;
        targetControl.Location = new Point(currentX, targetControl.Location.Y);
    }

    /// <summary>
    /// 컨트롤 수직 정렬
    /// </summary>
    public void VerticalAlignment(Control baseControl, Control targetControl)
    {
        int currentY = baseControl.Size.Height / 2 - targetControl.Size.Height / 2;
        targetControl.Location = new Point(targetControl.Location.X, currentY);
    }
}