using System;

namespace chapter8;

class Mob
{
    public virtual void PrintInfo()
    {
        Console.WriteLine("Mob");
    }    
}

class Enemy : Mob
{
    public override void PrintInfo()
    {
        Console.WriteLine("Enemy");
    }
}

class Player : Mob
{
    new public void PrintInfo()
    {
        Console.WriteLine("Player");
    }
}

public class ClassCastSample
{
    public static void ClassCastSampleMain()
    {
        // 派生クラスのインスタンスは基本クラスのインスタンスとしても利用できる。
        // この変換はアップキャストと呼ばれ、暗黙的に行うことができる。
        Mob mob = new Enemy();

        // 基本クラスを派生クラスに変換することはダウンキャストと呼ばれる。
        // ダウンキャストは明示的に行う必要がある。
        Enemy enemy = (Enemy)mob;

        // 元がEnemyクラスなのでPlayerクラスになれないのは人間にとっては自明だが、
        // コンピュータはそのことを判断できないため、コンパイルは通る。
        // ただし、実行時にはエラーとなる。
        //Player player = (Player)mob;

        // is演算子をダウンキャストに使う場合、
        // ダウンキャストが可能な場合にtrueを返す。不可能な場合はfalseを返す。
        // is演算子はダウンキャスト以外にも使うことができる。
        if (mob is Player)
        {
            Player player1 = (Player)mob;
        }

        // as演算子はダウンキャストが可能な場合にはダウンキャストを行い、できない場合にはnullを返す。
        // ?はnullがありうることを意味する。
        Player? player2 = mob as Player;
        if (player2 == null)
        {
            Console.WriteLine("player is null");
        }
    }
}
