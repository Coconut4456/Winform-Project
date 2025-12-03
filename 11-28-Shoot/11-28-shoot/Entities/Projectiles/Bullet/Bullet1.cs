namespace _11_28_shoot.Entities.Projectiles.Bullet;

public class Bullet1 : BulletBase
{
    public Bullet1() {}

    public override void SetDefault()
    {
        Label.Size = new Size(5, 5);
        Label.BackColor = Color.Yellow;
        Speed = 15;
        Damage = 1;
        UpGradeCount = 0;
        PierceCount = 0;
        MaxUpGradeCount = 3;
        MaxPierceCount = 1;
    }
}