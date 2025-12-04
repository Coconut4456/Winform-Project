namespace _11_28_shoot.Entities.Characters.Player;

public abstract class PlayerBase
{
    public Label Label { get; set; } = new();
    public string Name { get; set; } = "";
    public int Life { get; set; } = 0;
    public int Health { get; set; } = 0;
    public int Damage { get; set; } = 0;
    public int Speed { get; set; } = 0;
    public Point Position
    {
        get => Label.Location;
        set => Label.Location = value;
    }

    public Rectangle Bounds => new (Position, Label.Size);

    public void MoveLeft()
    {
        Position = new Point(Position.X - Speed, Position.Y);
    }

    public void MoveRight()
    {
        Position = new Point(Position.X + Speed, Position.Y);
    }

    public void MoveUp()
    {
        Position = new Point(Position.X, Position.Y - Speed);
    }

    public void MoveDown()
    {
        Position = new Point(Position.X, Position.Y + Speed);
    }

    public void OnHit()
    {
        Health--;
    }

    public abstract void SetDefault();
}