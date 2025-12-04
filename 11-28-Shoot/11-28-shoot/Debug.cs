using _11_28_shoot.Entities.Characters.Enemy;
using Timer = System.Windows.Forms.Timer;

namespace _11_28_shoot;

public partial class Debug : Form
{
    private readonly Label _label = new();
    private readonly List<EnemyBase> _spawnedEnemyList;
    private readonly Timer _timer = new();
    
    public Debug(List<EnemyBase> enemyPool)
    {
        InitializeComponent();
        InitializeUI();
        _spawnedEnemyList = enemyPool;
    }

    public void InitializeUI()
    {
        this.ClientSize = new Size(300, 300);
        this.Size = ClientSize;
        this.BackColor = Color.Black;
        _label.Size = this.ClientSize;
        _label.BackColor = Color.Black;
        _label.ForeColor = Color.White;
        this.Controls.Add(_label);
        _timer.Interval = 16;
        _timer.Start();
        _timer.Tick += Timer_Tick!;
    }

    public void Timer_Tick(object sender, EventArgs e)
    {
        _label.Text = null;
        
        foreach (EnemyBase enemy in _spawnedEnemyList)
        {
            if (enemy.Position.X < 0 || enemy.Position.X > 600)
                _label.Text += $"error NAME:{enemy.Name}, ISCOLLISION:{enemy.IsCollision}\n";
            else
            {
                _label.Text += $"NAME:{enemy.Name}, ISCOLLISION:{enemy.IsCollision}\n";
            }
        }
    }
}