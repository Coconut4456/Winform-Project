namespace _11_28_shoot.Entities.Characters.Enemy;

public class EnemyA : EnemyBase
{
    public EnemyA() {}
    public override void SetDefault()
    {
        Label.Size = new Size(40, 15);
        Label.BackColor = Color.Red;
        Life = 1;
        Health = 1;
        Damage = 1;
        VelocityX = 0;
        CurrentSpeed = 0;
        TargetSpeed = 3;
        MoveCount = 0;
        DropSpeed = 1;
    }
}