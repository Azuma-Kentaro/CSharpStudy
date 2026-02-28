using System;

namespace chapter11;

class DeconstructSample
{
    public int No { get; }
    public string? Name { get; }

    public DeconstructSample(int n, string? s)
    {
        this.No = n;
        this.Name = s;
    }

    public void Deconstruct(out int No, out string? Name)
    {
        No = this.No;
        Name = this.Name;
    }
}

public class PatternMatchSample
{
    public static void PatternMatchSampleMain()
    {
        SwitchExpressionPatternMatchSample();
        DeconstructPatterunMatchSample();
        ListPatternMatchSample();
        PatternCombinationSample();
    }

    private static void SwitchExpressionPatternMatchSample()
    {
        object obj = "test";

        // C# 9以降は型だけのパターンマッチングが可能となった。
        // C# 9より前は int _ => の形で_として受け取る必要があった。
        var str = obj switch
        {
            int => "int",
            long => "long",
            string => "string",
            _ => "none",
        };
        Console.WriteLine(str);
    }

    private static void DeconstructPatterunMatchSample()
    {
        int no = 0;
        string? name = null;

        static int GetInt(DeconstructSample? sample)
        {
            // 型の分解が必要な場所でDeconstructメソッドは自動的に呼び出される。
            return sample switch
            {
                ( 10, "John" ) => 0,                // 位置指定パターン
                { No:6, Name:"Taro" } => sample.No, // プロパティパターン
                ( var x, _ ) when x > 100 => x,     // varパターン
                { } => 1,                           // プロパティパターン(null以外すべてに合致)
                _ => -1                             // 破棄パターン(null含めたすべてに合致)
            };
        }

        static string? GetString(DeconstructSample? sample)
        {
            // タプルを使ったパターンも可能である。
            return (sample?.No, sample?.Name) switch
            {
                (10, "John") => "Doe",
                (6, "Taro") => "Yamada",
                (_, "Ken") => sample.Name,
                _ => "Nothing",
            };
        }

        var sample1 = new DeconstructSample(10, "John");
        no = GetInt(sample1);
        name = GetString(sample1);
        Console.WriteLine($"sample1 no: {no}, name: {name}");

        var sample2 = new DeconstructSample(6, "Taro");
        no = GetInt(sample2);
        name = GetString(sample2);
        Console.WriteLine($"sample2 no: {no}, name: {name}");

        var sample3 = new DeconstructSample(101, null);
        no = GetInt(sample3);
        name = GetString(sample3);
        Console.WriteLine($"sample3 no: {no}, name: {name}");

        var sample4 = new DeconstructSample(50, "Ken");
        no = GetInt(sample4);
        name = GetString(sample4);
        Console.WriteLine($"sample4 no: {no}, name: {name}");

        no = GetInt(null);
        name = GetString(null);
        Console.WriteLine($"sample5 no: {no}, name: {name}");
    }

    private static void ListPatternMatchSample()
    {
        // C# 11から導入されたリストパターンは、
        // コレクションに対するパターンマッチを可能にする。
        int[] numbers = [ 1, 2, 3, 4, 5 ];

        if (numbers is not [])
        {
            Console.WriteLine("numbers is not empty list");
        }

        if (numbers is [ 1, 2, 3, 4, 5 ])
        {
            Console.WriteLine("numbers is [ 1, 2, 3, 4, 5 ]");
        }

        if (numbers is [ var first, .., var last])
        {
            Console.WriteLine($"numbers begins with {first} and ends with {last}");
        }

        if (numbers is [ 1, .. var rest])
        {
            Console.WriteLine($"numbers begins with 1 and rest is {rest}");
            foreach (var elem in rest)
            {
                Console.WriteLine(elem);
            }
        }
    }

    private static void PatternCombinationSample()
    {
        // パターンの組み合わせには論理演算子ではなく、and, or, notを用いる。
        static string CheckValue(int v) => v switch
        {
            // パターンには比較演算子を使うこともできる。
            < 2 => "weak",
            >= 2 and < 10 => "normal",
            >= 10 and < 20 => "strong",
            _ => "hard",
        };

        int value = 0;
        string resultString = CheckValue(value);
        Console.WriteLine($"value: {value}, result: {resultString}");

        value = 9;
        resultString = CheckValue(value);
        Console.WriteLine($"value: {value}, result: {resultString}");

        value = 19;
        resultString = CheckValue(value);
        Console.WriteLine($"value: {value}, result: {resultString}");

        value = 20;
        resultString = CheckValue(value);
        Console.WriteLine($"value: {value}, result: {resultString}");
    }
}
