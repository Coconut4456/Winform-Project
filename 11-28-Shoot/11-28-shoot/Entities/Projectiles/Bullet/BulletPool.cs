namespace _11_28_shoot.Entities.Projectiles.Bullet;

public class BulletPool
{
    public List<BulletBase> SpawnedBullets { get; private set; }
    public Queue<BulletBase> ReadyBullets { get; private set; }
    public int PoolSize { get; set; }

    public BulletPool(int poolSize = 30)
    {
        SpawnedBullets = new();
        ReadyBullets = new();
        PoolSize = poolSize;
        SetBullet();
    }

    public void SetBullet(int bulletNum = 0)
    {
        for (int i = 0; i < PoolSize; i++)
        {
            BulletBase bullet;
            
            switch (bulletNum)
            {
                default:
                    bullet = new Bullet1();
                    bullet.Label.Visible = false;
                    break;
            }
            
            ReadyBullets.Enqueue(bullet);
        }
    }
    
    public void Spawn(Point position)
    {
        if (ReadyBullets.Count <= 0)
            return;
        
        BulletBase bullet = ReadyBullets.Dequeue();
        bullet.SetDefault();
        bullet.Position = new Point(position.X - bullet.Label.Width / 2, position.Y - 5);
        bullet.Label.Visible = true;
        SpawnedBullets.Add(bullet);
    }

    public void Destroy(BulletBase bullet)
    {
        bullet.Label.Visible = false;
        bullet.PierceCount = 0;
        SpawnedBullets.Remove(bullet);
        ReadyBullets.Enqueue(bullet);
    }

    public void UpdateAll()
    {
        foreach (BulletBase bullet in SpawnedBullets.ToList())
        {
            bullet.Update();

            if (bullet.Position.Y <= 0)
                Destroy(bullet); // 바닥에 닿았을 때 위치 이동 필요
            
            if (bullet.PierceCount >= bullet.MaxPierceCount)
                Destroy(bullet);
        }
    }
}