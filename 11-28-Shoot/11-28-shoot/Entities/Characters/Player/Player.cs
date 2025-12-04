using _11_28_shoot.Entities.Characters.Enemy;

namespace _11_28_shoot.Entities.Characters.Player;

public class Player : PlayerBase
{
    private DateTime _lastShootTime = DateTime.MinValue;
    private int _shootCooldownMs;

    public Player() {}
    public override void SetDefault()
    {
        Label.Size = new Size(10, 20);
        Label.BackColor = Color.Green;
        Name = "Player";
        Life = 5;
        Health = 10;
        Damage = 0;
        Speed = 5;
        _shootCooldownMs = 400;
    }

    public void UpGrade()
    {
        if (_shootCooldownMs <= 200)
            return;
        
        _shootCooldownMs -= 50;
    }

    public bool Shoot()
    {
        DateTime now = DateTime.Now;
        if ((now - _lastShootTime).TotalMilliseconds < _shootCooldownMs)
            return false;

        _lastShootTime = now;
        return true;
    }
}