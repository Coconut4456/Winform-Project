namespace _11_28_shoot.Entities.Characters.Enemy;

public abstract class EnemyBase
{
    public Label Label { get; set; } = new();
    public string Name { get; set; } = "";
    public int Life { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Direction { get; set; } = 1;
    public float VelocityX { get; set; }
    public float CurrentSpeed { get; set; }
    public float TargetSpeed { get; set; }
    public int MoveCount { get; set; }
    public int DropSpeed { get; set; }
    public bool IsCollision { get; set; }
    public bool WasColliding { get; set; }
    private const int CollisionCooldown = 120;
    public float NextPosition => Position.X + (int)(VelocityX + (CurrentSpeed - VelocityX)) * 0.1f;

    public Point Position
    {
        get => Label.Location;
        set => Label.Location = value;
    }

    public Rectangle Bounds => new (Position, Label.Size);

    public abstract void SetDefault();

    public void OnHit()
    {
        Health--;
    }

    public void RandomChangeDirection()
    {
        if (Random.Shared.Next(100) < 1 && !IsCollision)
            Direction *= -1;
    }

    public void SmoothMove()
    {
        CurrentSpeed = Direction * TargetSpeed;
        VelocityX += (CurrentSpeed - VelocityX) * 0.1f;
        Position = new Point(Position.X + (int)VelocityX, Position.Y + DropSpeed);
    }

    public void Update()
    {
        if (IsCollision && !WasColliding)
        {
            Direction *= -1;
            MoveCount = 0;
        }

        if (IsCollision)
        {
            MoveCount++;

            if (MoveCount >= CollisionCooldown)
            {
                IsCollision = false;
                MoveCount = 0;
            }
        }

        RandomChangeDirection();
        SmoothMove();
        WasColliding = IsCollision;
    }
}