using System;

namespace chapter8;

abstract class AbstractClass
{
    // 派生クラスでのみ実装を行うメソッドは抽象メソッドと呼ばれる。
    // 抽象メソッドを作成するにはvirtualキーワードの代わりに
    // abstractキーワードを指定する。
    // 抽象メソッドを宣言する場合、そのクラスにもabstractキーワードを指定する必要がある。
    // abstractキーワードを指定されたクラスは抽象クラスと呼ばれる。
    // 抽象クラスのインスタンスを作成することできない。
    public abstract void GetInfo();

    //抽象クラスには、抽象メソッドではない普通のメソッドを含めることができる。
    public void Hello()
    {
        Console.WriteLine("AbstractClass");
    }
}

class DerivedAbstractClass : AbstractClass
{
    public override void GetInfo()
    {
        Console.WriteLine("DerivedAbstractClass");
    }
}

public class AbstractClassSample
{
    public static void AbstractClassSampleMain()
    {
        AbstractClass a = new DerivedAbstractClass();
        a.Hello();
        a.GetInfo();
    }
}
