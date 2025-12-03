using System.Runtime.InteropServices;
using _11_28_shoot.Entities.Characters;
using _11_28_shoot.Entities.Projectiles.Bullet;
using Timer = System.Windows.Forms.Timer;

namespace _11_28_shoot;

public partial class Form1 : Form
{
    private readonly Player _player;
    private readonly BulletPool _bulletPool;
    private readonly EnemyPool _enemyPool;
    private readonly Timer _gameTimer;
    private readonly Timer _enemyTimer;
    private readonly Random _random;

    [DllImport("user32.dll")]
    static extern short GetAsyncKeyState(int vKey);

    public Form1()
    {
        InitializeComponent();
        InitializeUI();
        _player = new Player();
        _bulletPool = new BulletPool();
        _enemyPool = new EnemyPool();
        _gameTimer = new Timer();
        _enemyTimer = new Timer();
        _random = new Random();

        this.Controls.Add(_player.Label);
        GameStart();
    }

    /// <summary>
    /// UI 초기 설정
    /// </summary>
    public void InitializeUI()
    {
        this.ClientSize = new Size(600, 800);
        this.Size = ClientSize;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.Black;
    }

    /// <summary>
    /// 게임 시작시 초기 설정
    /// </summary>
    public void GameStart()
    {
        _player.SetDefault();
        _player.Position = new Point(this.ClientSize.Width / 2 - _player.Label.Width / 2, this.ClientSize.Height - _player.Label.Height - 10);
        _gameTimer.Interval = 16; // 16 = 60 FPS
        _gameTimer.Tick += GameTimer_Tick!;
        _gameTimer.Start();
        _enemyTimer.Interval = 1000;
        _enemyTimer.Tick += EnemySpawnTimer_Tick!;
        _enemyTimer.Start();

        foreach (BulletBase bullet in _bulletPool.ReadyBullets)
        {
            this.Controls.Add(bullet.Label);
        }

        foreach (UnitBase enemy in _enemyPool.ReadyEnemys)
        {
            this.Controls.Add(enemy.Label);
        }
    }

    /// <summary>
    /// 총알 발사 로직
    /// </summary>
    public void FireBullet()
    {
        // 플레이어 발사 쿨타임 확인
        if (!_player.Shoot())
            return;

        // 플레이어의 앞 부분으로 위치 지정 후 발사
        Point point = new Point(_player.Position.X + _player.Label.Width / 2, _player.Position.Y);
        _bulletPool.Spawn(point);
    }

    /// <summary>
    /// 플레이어 행동 업데이트
    /// </summary>
    public void UpdatePlayer()
    {
        if (GetAsyncKeyState((int)Keys.Space) < 0)
            FireBullet();

        if (GetAsyncKeyState((int)Keys.Left) < 0)
        {
            if ((_player.Position.X - _player.Speed) <= 0)
                _player.Position = new Point(0, _player.Position.Y);
            else
                _player.MoveLeft();
        }

        if (GetAsyncKeyState((int)Keys.Right) < 0)
            if ((_player.Position.X + _player.Label.Size.Width + _player.Speed) >= this.ClientSize.Width)
                _player.Position = new Point(this.ClientSize.Width - _player.Label.Size.Width, _player.Position.Y);
            else
                _player.MoveRight();

        if (GetAsyncKeyState((int)Keys.Up) < 0)
            if ((_player.Position.Y - _player.Speed) <= 0)
                _player.Position = new Point(_player.Position.X, 0);
            else
                _player.MoveUp();

        if (GetAsyncKeyState((int)Keys.Down) < 0)
            if ((_player.Position.Y + _player.Label.Size.Height + _player.Speed) >= this.ClientSize.Height)
                _player.Position = new Point(_player.Position.X, this.ClientSize.Height - _player.Label.Size.Height);
            else
                _player.MoveDown();

        _bulletPool.UpdateAll();

        if (GetAsyncKeyState((int)Keys.M) < 0)
            _enemyPool.Spawn(new Point(100, 0));
    }

    /// <summary>
    /// 적 행동 업데이트
    /// </summary>
    public void UpdateEnemy()
    {
        _enemyPool.UpdateAll(_random, this.ClientSize);
    }

    /// <summary>
    /// 총알과 적 충돌 판정
    /// </summary>
    public void CheckCollision()
    {
        foreach (BulletBase bullet in _bulletPool.SpawnedBullets)
        {
            foreach (UnitBase enemy in _enemyPool.SpawnedEnemys)
            {
                if (!bullet.Bounds.IntersectsWith(enemy.Bounds))
                    continue;
                
                bullet.OnHit();
                enemy.OnHit();
            }
        }
    }

    /// <summary>
    /// 플레이어 행동 타이머
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void GameTimer_Tick(object sender, EventArgs e)
    {
        CheckCollision();
        UpdatePlayer();
        UpdateEnemy();
    }

    /// <summary>
    /// 적 스폰 타이머
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void EnemySpawnTimer_Tick(object sender, EventArgs e)
    {
        _enemyPool.Spawn(new Point(_random.Next(10, this.ClientSize.Width), 0));
    }
}