namespace _11_28_shoot.Entities.Characters;

public class EnemyPool
{
    public List<UnitBase> SpawnedEnemys { get; private set; }
    public Queue<UnitBase> ReadyEnemys { get; private set; }
    public int PoolSize { get; set; }
    public int MoveCount { get; private set; }

    public EnemyPool(int poolSize = 30)
    {
        SpawnedEnemys = new();
        ReadyEnemys = new();
        PoolSize = poolSize;
        SetEnemy();
    }

    public void SetEnemy(int enemyNum = 0)
    {
        for (int i = 0; i < PoolSize; i++)
        {
            UnitBase enemy;

            switch (enemyNum)
            {
                default:
                    enemy = new Enemy1();
                    enemy.Label.Visible = false;
                    break;
            }

            ReadyEnemys.Enqueue(enemy);
        }
    }

    public void Spawn(Point position)
    {
        if (ReadyEnemys.Count <= 0)
            return;

        UnitBase enemy = ReadyEnemys.Dequeue();
        enemy.SetDefault();
        enemy.Position = new Point(position.X - enemy.Label.Width, position.Y - enemy.Label.Height);
        enemy.Label.Visible = true;
        SpawnedEnemys.Add(enemy);
    }

    public void Destroy(UnitBase enemy)
    {
        enemy.Label.Visible = false;
        SpawnedEnemys.Remove(enemy);
        ReadyEnemys.Enqueue(enemy);
    }

    public void MoveEnemy()
    {
        
    }

    public void UpdateAll(Random random, Size clientSize)
    {
        foreach (UnitBase enemy in SpawnedEnemys.ToList())
        {
            
            
            if (enemy.Health <= 0)
                enemy.Life -= 1;

            if (enemy.Position.Y >= clientSize.Height)
                Destroy(enemy);
            
            if (enemy.Life <= 0)
                Destroy(enemy);
        }
    }
}