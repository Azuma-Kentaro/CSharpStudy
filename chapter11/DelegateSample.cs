using System;

namespace chapter11;

delegate int SampleDelegate(int x);

public class DelegateSample
{
    public static void DelegateSampleMain()
    {
        SimpleDelegateSample();
        CallbackSample();
        AnonymousDelegateSample();
    }

    private static void SimpleDelegateSample()
    {
        int ret = 0;

        static int TestMethod1(int x)
        {
            Console.WriteLine($"TestMethod1 x: {x}");
            return x + 1;
        }

        static int TestMethod2(int x)
        {
            Console.WriteLine($"TestMethod2 x: {x}");
            return x + 10;
        }

        SampleDelegate sampleDelegate1;
        sampleDelegate1 = new SampleDelegate(TestMethod1);
        ret = sampleDelegate1(5);
        Console.WriteLine($"sampleDelegate1(5) result: {ret}");

        // 本には載ってないがConsole.WriteLineに渡してみる。
        Console.WriteLine(sampleDelegate1);

        // 宣言と初期化を同時に行うこともできる。
        var sampleDelegate2 = new SampleDelegate(TestMethod2);
        ret = sampleDelegate2(10);
        Console.WriteLine($"sampleDelegate2(10) result: {ret}");

        // newを省略して記述することもできる。
        SampleDelegate? sampleDelegate3 = TestMethod2;

        // +演算子を使用することで複数のメソッドを登録することもできる。
        sampleDelegate3 += TestMethod1;
        // 複数メソッドが登録されている場合、戻り値は最後に実行したメソッドのものが適用される。
        ret = sampleDelegate3(15);
        Console.WriteLine($"sampleDelegate3(15) result: {ret}");

        // -演算子を使用することでメソッドの登録を解除することができる。
        sampleDelegate3 -= TestMethod1;
        ret = sampleDelegate3(15);
        Console.WriteLine($"sampleDelegate3(15) result: {ret}");
    }

    private static void CallbackSample()
    {
        static int TestMethodForCallback(int x)
        {
            Console.WriteLine($"TestMethodForCallback x: {x}");
            return x;
        }

        // デリゲートはCの関数ポインタに近いものであるため、
        // コールバック関数としての使用用途がある。
        static void CallbackMethod(SampleDelegate d, int x)
        {
            d(x);
        }

        var sampleDelegate = new SampleDelegate(TestMethodForCallback);
        CallbackMethod(sampleDelegate, 100);
    }

    private static void AnonymousDelegateSample()
    {
        // デリゲート内に直接定義されたメソッドは名前を持たないため、匿名メソッドと呼ばれる。
        // C#では、メソッドはクラスに所属しなければならないため、
        // 内部的には匿名メソッドを所属させるための匿名クラスが自動的に作成される。
        // ラムダ式があるから匿名メソッドの出番はあまりないと思われる。
        var anonymounsDelegate = delegate(int x)
        {
            Console.WriteLine($"anonymousDelegate x: {x}");            
        };
        anonymounsDelegate(1);
    }
}
