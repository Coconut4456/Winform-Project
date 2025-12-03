namespace _11_28_shoot.Entities.Characters;

public class Enemy1 : UnitBase
{
    public Enemy1() {}
    public override void SetDefault()
    {
        Label.Size = new Size(20, 30);
        Label.BackColor = Color.Red;
        Life = 1;
        Health = 1;
        Damage = 1;
        Speed = 1;
    }
}