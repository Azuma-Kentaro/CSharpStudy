using System;

namespace chapter7;

public class BaseObject
{
    static private int objectIDCount = 0;

    // 学習目的のため、プロパティは意図的に使用していない
    protected int objectID;

    // デフォルトコンストラクタ
    public BaseObject()
    {
        this.objectID = objectIDCount++;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"BaseObject, objectID: {this.objectID}");
    }
}

public class Mob : BaseObject
{
    protected uint HP = 0;
    public override void PrintInfo()
    {
        Console.WriteLine($"Mob, HP: {this.HP}");
        base.PrintInfo();
    }
}

public class Enemy : Mob
{
    public override void PrintInfo()
    {
        Console.WriteLine($"Enemy");
        base.PrintInfo();
    }
}

public class Player : Mob
{
    static private int PlayerIDCount = 0;

    // フィールドの隠蔽
    new protected int objectID = 0;

    // 自動プロパティ
    public int PlayerID { get; } = PlayerIDCount++;

    public Player() : base()
    {
        Console.WriteLine($"this.objectID: {this.objectID}");
        Console.WriteLine($"base.objectID: {base.objectID}");
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Player, Player ID: {PlayerID}");
        base.PrintInfo();
    }
}

public class ClassBaseSuperSample
{
    public static void ClassBaseSuperSampleMain()
    {
        Enemy enemy1 = new Enemy();
        enemy1.PrintInfo();
        
        Player player1 = new Player();
        player1.PrintInfo();

        Enemy enemy2 = new Enemy();
        enemy2.PrintInfo();
        
        Player player2 = new Player();
        player2.PrintInfo();
    }
}
