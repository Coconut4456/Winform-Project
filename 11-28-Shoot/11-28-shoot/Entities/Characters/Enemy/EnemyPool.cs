namespace _11_28_shoot.Entities.Characters.Enemy;

public class EnemyPool
{
    public List<EnemyBase> SpawnedEnemyList { get; private set; }
    public Queue<EnemyBase> ReadyEnemyQueue { get; private set; }
    public int PoolSize { get; set; }
    public int MoveCount { get; private set; }

    public EnemyPool(int poolSize = 10)
    {
        SpawnedEnemyList = new();
        ReadyEnemyQueue = new();
        PoolSize = poolSize;
        SetEnemy();
    }

    public void SetEnemy(int enemyNum = 0)
    {
        for (int i = 0; i < PoolSize; i++)
        {
            EnemyBase enemy;

            switch (enemyNum)
            {
                default:
                    enemy = new EnemyA();
                    enemy.Name = $"EnemyA_{i}";
                    enemy.Label.Visible = false;
                    break;
            }

            ReadyEnemyQueue.Enqueue(enemy);
        }
    }

    public void Spawn(int minX, int maxX)
    {
        if (ReadyEnemyQueue.Count <= 0)
            return;

        EnemyBase enemy = ReadyEnemyQueue.Dequeue();
        enemy.SetDefault();
        enemy.Position = new Point(Random.Shared.Next(minX, maxX), 0 - enemy.Label.Height);
        enemy.Label.Visible = true;
        SpawnedEnemyList.Add(enemy);
    }

    public void Destroy(EnemyBase enemy)
    {
        enemy.Label.Visible = false;
        SpawnedEnemyList.Remove(enemy);
        ReadyEnemyQueue.Enqueue(enemy);
    }

    public void UpdateAll(Size clientSize)
    {
        foreach (EnemyBase enemy in SpawnedEnemyList.ToList())
        {
            enemy.Update();
            
            if (enemy.Health <= 0)
                enemy.Life -= 1;
            
            if (enemy.Position.Y >= clientSize.Height)
                Destroy(enemy);
            
            if (enemy.Life <= 0)
                Destroy(enemy);
        }
    }
}