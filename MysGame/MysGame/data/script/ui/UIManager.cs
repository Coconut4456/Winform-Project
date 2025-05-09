using MysGame.data.resource.control;

namespace MysGame.data.script.ui;

public class UIManager
{
    private readonly Home _home;
    public List<Control> LabelList;
    public List<Control> ButtonList;
    
    public UIManager(Form form)
    {
        _home = new Home();
        LabelList.Add(_home.TitleLabel);
        AddControl(form, _home);;
    }

    public void AddControl(Form form, UserControl control)
    {
        form.Controls.Add(control);
    }
}