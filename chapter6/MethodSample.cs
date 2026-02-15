using System;

namespace chapter6;

class MethodTest
{
    public int CalcAdd(int a, int b, int c)
    {
        Console.WriteLine($"param a is {a}, param b is {b}, param c is {c}, result is {a + b + c}");
        return a + b + c;
    }

    public void Hello(string name = "John")
    {
        Console.WriteLine($"Hello, {name}");
    }

    public int CalcSum(params int[] intArray)
    {
        int sum = 0;

        if (intArray.Length != 0)
        {
            Console.WriteLine($"Got {intArray.Length} elements");
        }

        foreach (int x in intArray)
        {
            Console.WriteLine($"{x}, ");
            sum += x;
        }

        Console.WriteLine($"Sum is {sum}");
        return sum;
    }
}

public class MethodSample
{
    public static void MethodSampleMain()
    {
        MethodWithNamedParameterSample();
        MethodWithDefaultParameterSample();
        MethodWithVariableLengthArgumentSample();
    }

    private static void MethodWithNamedParameterSample()
    {
        var test = new MethodTest();

        // 通常の呼び出し
        test.CalcAdd(3, 5, 1);

        // 名前付きパラメータを用いた呼び出し
        test.CalcAdd(a: 3, b: 5, c: 1);
        test.CalcAdd(b: 5, c: 1, a: 3);
        test.CalcAdd(c: 1, a: 3, b: 5);

        // 名前付きパラメータと名前付きではないパラメータの混在
        test.CalcAdd(a: 3, 5, 1);
        test.CalcAdd(3, c: 1, b: 5);

        // 名前付きパラメータが先頭に来る場合は、順序を変更できない。
        //test.CalcAdd(b: 5, a: 3, 1);
    }

    private static void MethodWithDefaultParameterSample()
    {
        var test = new MethodTest();

        // パラメータを指定しない場合はデフォルト値のJohnとなる。
        test.Hello();

        // パラメータを指定する場合は指定したTaroとなる。
        test.Hello("Taro");
    }

    private static void MethodWithVariableLengthArgumentSample()
    {
        var test = new MethodTest();

        // 任意の数の引数を取ることができる
        test.CalcSum();
        test.CalcSum(1);
        test.CalcSum(1, 3, 5);
        test.CalcSum(1, 3, 5, 7, 9, 11, 13, 15);
    }

}
