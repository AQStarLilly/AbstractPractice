using System;

public abstract class GameEntity
{
    public int Health { get; set; }

    public void Move()
    {
        Console.WriteLine("Entity moves to a new space.");
    }
    public abstract void Attack();
}

public class Player : GameEntity
{
    public override void Attack()
    {
        Console.WriteLine("The player attacks the enemy.");
    }
}

public class Enemy : GameEntity
{
    public override void Attack()
    {
        Console.WriteLine("The enemy attacks the player.");
    }
}

class Program
{
    public static void CallAttack(GameEntity entity)
    {
        entity.Attack();
    }

    static void Main(string[] args)
    {
        Player player = new Player { Health = 100};
        Enemy enemy = new Enemy { Health = 50 };

        Console.WriteLine("Calling attack from Player:");
        CallAttack(player);

        Console.WriteLine("\nCalling attack from Enemy:");
        CallAttack(enemy);

        Console.WriteLine("\nPlayer Movement:");
        player.Move();

        Console.WriteLine("\nEnemy Movement:");
        enemy.Move();
    }
}
