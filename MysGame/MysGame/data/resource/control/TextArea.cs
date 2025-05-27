namespace MysGame.data.resource.control;

public partial class TextArea : UserControl
{
    public TextArea()
    {
        InitializeComponent();
        this.Visible = false;
        this.Location = new Point(0, 0);
        textLabel.Visible = true;
        textLabel.Dock = DockStyle.Fill;
        textLabel.Text = string.Empty;
        textLabel.TextAlign = ContentAlignment.TopLeft;
        textLabel.BackColor = Color.Black;
        textLabel.ForeColor = Color.White;
        textLabel.Font = new Font("Ink Free", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
    }
}