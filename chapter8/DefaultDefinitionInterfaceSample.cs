using System;

namespace chapter8;

interface IDefaultDefinition
{
    // 宣言のみを持つメソッド
    void MethodA();

    // デフォルトの定義を持つメソッド
    void MethodB()
    {
        Console.WriteLine("IDefaultDefinition MethodB");
    }
}

// デフォルトの定義を持つメソッドはそのままにして
// 宣言だけされているメソッドの定義を実装したクラス
class IDefaultDefinitionSample1 : IDefaultDefinition
{
    public void MethodA()
    {
        Console.WriteLine("IDefaultDefinitionSample1 MethodA");
    }
}

// デフォルトの定義を持つメソッドも改めて定義したクラス
class IDefaultDefinitionSample2 : IDefaultDefinition
{
    public void MethodA()
    {
        Console.WriteLine("IDefaultDefinitionSample2 MethodA");
    }

    // デフォルトの定義を持っているが、それとは別にこのクラスでも定義する
    public void MethodB()
    {
        Console.WriteLine("IDefaultDefinitionSample2 MethodB");
    }
}

public class DefaultDefinitionInterfaceSample
{
    public static void DefaultDefinitionInterfaceSampleMain()
    {
        var x = new IDefaultDefinitionSample1();
        x.MethodA();

        // デフォルトの定義を持つメソッドを呼び出す場合は
        // そのインタフェースへのキャストが必要となる。
        IDefaultDefinition idd = (IDefaultDefinition)x;
        idd.MethodB();


        var y = new IDefaultDefinitionSample2();
        y.MethodA();

        // 改めて定義したのでインタフェースへのキャストは不要
        y.MethodB();

        // デフォルトの定義を呼び出そうとしても呼び出せない
        // デフォルトの定義を持てない過去のC#バージョンでは
        // クラスで定義されたメソッドを呼び出すため、
        // クラスで定義されたメソッドを呼び出さないと互換性がなくなるからである。
        ((IDefaultDefinition)y).MethodB();
    }
}
