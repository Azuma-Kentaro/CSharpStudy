using System;

namespace chapter10;

public class TupleSample
{
    public static void TupleSampleMain()
    {
        SimpleTupleSample();
        OmitMemberNameTupleSample();
        EstimateMemberNameTupleSample();
        DeconstructTupleSample();
        ConvertTupleSample();
        CompareTupleSample();
    }

    private static void SimpleTupleSample()
    {
        // 戻り値の型としてタプルを定義
        (string name, int age) GetTuple()
        {
            return ("John", 18);
        }

        var m = GetTuple();
        Console.WriteLine($"m.name: {m.name}, m.age: {m.age}");
    }

    private static void OmitMemberNameTupleSample()
    {
        // 戻り値の型としてタプルを定義
        // タプルの定義に要素名は必ずしも必要ではない。
        (string, int) GetTuple()
        {
            return ("John", 18);
        }

        var m = GetTuple();
        // 内部的にはItem1, Item2と順番に名前が割り当てられているため、
        // 要素名を省略した場合でもアクセスすることができる。
        // 省略しなかった場合でもItem1, Item2は有効な名前である。
        Console.WriteLine($"m.Item1: {m.Item1}, m.age: {m.Item2}");
    }

    private static void EstimateMemberNameTupleSample()
    {
        var name = "John";
        var age = 18;

        var m = (name, age);

        // タプルの要素名は自動で推論することができる。
        // 推論できなかった場合はItem1, Item2となる
        Console.WriteLine($"m.name: {m.name}, m.age: {m.age}");
    }

    private static void DeconstructTupleSample()
    {
        // 戻り値の型としてタプルを定義
        (string name, int age) GetTuple()
        {
            return ("John", 18);
        }

        // 戻り値のタプルを分解して、別々の変数に代入する。
        (string s1, int n1) = GetTuple();
        Console.WriteLine($"s1: {s1}, n1: {n1}");

        // 不要な要素は_に代入することで捨てることができる。
        (_, int age) = GetTuple();
        Console.WriteLine($"age: {age}");
        // _の内容は表示できない。
        //Console.WriteLine($"_: {_}, age: {age}");

        // 型推論を使うこともできる。
        (var s2, var n2) = GetTuple();
        Console.WriteLine($"s2: {s2}, n2: {n2}");

        // 型推論は、次のようにすることもできる。
        var (s3, n3) = GetTuple();
        Console.WriteLine($"s3: {s3}, n3: {n3}");
    }

    private static void ConvertTupleSample()
    {
        // 要素の型の順番が同じまたは暗黙的変換が可能な場合にタプル同士の代入ができる。
        // int型はlong型に暗黙的変換が可能である。
        (int number, string memo) t1 = (1, "test");
        (long number, string memo) t2 = t1;
        Console.WriteLine($"t2.number: {t2.number}, t2.memo: {t2.memo}");
    }

    private static void CompareTupleSample()
    {
        (int number, string s) t1 = (1, "sample");
        (int n, string str) t2 = (1, "テスト");

        // タプル同士の==演算については、各要素に==演算を適用した結果を&&で結合した値となる。
        // つまり、すべての要素が一致した場合にのみtrueとなる。
        Console.WriteLine(t1 == t2);

        // タプル同士の!=演算については、各要素に!=演算を適用した結果を||で結合した値となる。
        // つまり、いずれかの要素が一致しなかった場合にtrueとなる。
        Console.WriteLine(t1 != t2);
    }
}
