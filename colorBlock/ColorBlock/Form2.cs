namespace ColorBlock;

public partial class Form2 : Form
{
    
    public Form2()
    {
        InitializeComponent();

        SetPlayTimeLabel.Text = @"SetPlayTime";
        playtimeLabel.Text = @$"{Form1.GetPlayTime()}";
    }

    private void minusPlayTime_Click(object sender, EventArgs e)
    {
        if (Form1.GetPlayTime() == 10)
        {
            return;
        }
        
        // playTime - 10
        Form1.SetPlayTime(0);
        playtimeLabel.Text = @$"{Form1.GetPlayTime()}";
    }

    private void plusPlayTime_Click(object sender, EventArgs e)
    {
        // playTime + 10
        Form1.SetPlayTime(1);
        playtimeLabel.Text = @$"{Form1.GetPlayTime()}";
    }
}