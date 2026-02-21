using System;
using System.Runtime.CompilerServices;

namespace chapter8;

interface IBaseInterface1
{
    void Method1(int a);
}

interface IBaseInterface2
{
    void Method2(string s);
}

// あるインタフェースを継承したインタフェースも定義することができる。
// クラスとは異なり、インタフェースの継承においては多重継承が許される。
interface ISampleInterface : IBaseInterface1, IBaseInterface2
{
    void Method3();    
}

class ImplementISampleInterface : ISampleInterface
{
    public void Method1(int a)
    {
        Console.WriteLine($"Method1: a: {a}");
    }

    public void Method2(string s)
    {
        Console.WriteLine($"Method2: s: {s}");
    }

    public void Method3()
    {
        Console.WriteLine("Method3");
    }
}

// クラスの継承とインタフェースの実装を同時に行うためだけに定義した基本クラス。
abstract class DirectImplementISampleInterfaceBase
{
    public abstract void Method3();
}

// クラスの継承とインタフェースの実装を同時に記述することができる。
// ただし、クラスの多重継承はできないので、クラスは1つだけ記述することができる。
class DirectImplementISampleInterface : DirectImplementISampleInterfaceBase, IBaseInterface1, IBaseInterface2
{
    public void Method1(int a)
    {
        Console.WriteLine($"Method1: a: {a}");
    }

    public void Method2(string s)
    {
        Console.WriteLine($"Method2: s: {s}");
    }

    public override void Method3()
    {
        Console.WriteLine("Method3");
    }
}


public class InheritInterfaceSample
{
    public static void InheritInterfaceSampleMain()
    {
        ImplementISampleInterfaceMain();
        DirectImplementISampleInterfaceMain();
    }

    public static void ImplementISampleInterfaceMain()
    {
        var x = new ImplementISampleInterface();
        x.Method1(123);
        x.Method2("abc");
        x.Method3();        
    }

    public static void DirectImplementISampleInterfaceMain()
    {
        var x = new DirectImplementISampleInterface();
        x.Method1(123);
        x.Method2("abc");
        x.Method3();
    }
}
