using System;

namespace chapter8;

interface IConflictMethod1
{
    void ConflictMethod();
}

interface IConflictMethod2
{
    void ConflictMethod();
}

class ConflictInterfaceMethod : IConflictMethod1, IConflictMethod2
{
    // インタフェース名とメソッド名をドットでつなぐことで、
    // どのインタフェースのメソッドを定義するかを明示することができる
    void IConflictMethod1.ConflictMethod()
    {
        Console.WriteLine("IconflictMethod1 ConflictMethod");
    }

    // インタフェース名とメソッド名をドットでつなぐことで、
    // どのインタフェースのメソッドを定義するかを明示することができる
    void IConflictMethod2.ConflictMethod()
    {
        Console.WriteLine("IconflictMethod2 ConflictMethod");
    }
}

public class ConflictInterfaceMethodSample
{
    public static void ConflictInterfaceMethodSampleMain()
    {
        var x = new ConflictInterfaceMethod();

        // メソッド名が衝突したときに別々の定義を使用したい場合、
        // 呼び出したい方のメソッドを持つインタフェースにキャストする必要がある。
        // ちなみに、インタフェースを実装したクラスは、そのインタフェースにアップキャストできる。
        IConflictMethod1 icm1 = (IConflictMethod1)x;
        icm1.ConflictMethod();

        IConflictMethod2 icm2 = (IConflictMethod2)x;
        icm2.ConflictMethod();
    }
}
