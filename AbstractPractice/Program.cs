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

public interface ICollectible
{
    void OnCollect();
}

public interface IUsable
{
    void Use();
    int UsesLeft { get; set; }
}

public class HealingPotion : ICollectible, IUsable
{
    public int UsesLeft { get; set; }

    public HealingPotion(int uses)
    {
        UsesLeft = uses;
    }

    public void OnCollect()
    {
        Console.WriteLine("Healing Potion collected!");
    }

    public void Use()
    {
        if(UsesLeft > 0)
        {
            UsesLeft--;
            Console.WriteLine($"Healing potion used. Uses left: {UsesLeft}");
        }
        else
        {
            Console.WriteLine("No uses left for this healing potion.");
        }
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

        Console.WriteLine("\nCreating and using a Healing potion:");
        HealingPotion potion = new HealingPotion(3);

        potion.OnCollect();
        potion.Use();
        potion.Use();
        potion.Use();
        potion.Use(); //Attempt to use when no uses are left
    }
}
