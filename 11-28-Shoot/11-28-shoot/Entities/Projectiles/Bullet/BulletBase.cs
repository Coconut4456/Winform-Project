namespace _11_28_shoot.Entities.Projectiles.Bullet;

public abstract class BulletBase
{
    public Label Label { get; set; } = new();
    public int Speed { get; set; }
    public int Damage { get; set; }
    public int UpGradeCount { get; set; }
    public int MaxUpGradeCount { get; set; }
    public int PierceCount { get; set; } = 0;
    public int MaxPierceCount { get; set; }
    public Point Position
    {
        get => Label.Location;
        set => Label.Location = value;
    }
    public Rectangle Bounds => new (Position, Label.Size);

    public void Update()
    {
        Position = new Point(Position.X, Position.Y - Speed);
    }

    public void Destory(Form form)
    {
        form.Controls.Remove(Label);
        Label.Dispose();
    }
    
    public void UpGrade(int speed, int damage, Size size)
    {
        if (UpGradeCount >= MaxUpGradeCount)
            return;

        Speed += speed;
        Damage += damage;
        Label.Size = size;
        UpGradeCount++;
    }
    
    public void OnHit()
    {
        PierceCount++;
    }

    public abstract void SetDefault();
}