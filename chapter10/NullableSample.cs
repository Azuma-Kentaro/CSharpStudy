using System;

namespace chapter10;

class Person
{
    public int Number = 0;
    public string Name = "";
}

class Team
{
    public Person? Member;
}

public class NullableSample
{
    public static void NullableSampleMain()
    {
        NullableTypeSample();
        NullableCoalescingSample();
        NullableConditionalSample();
    }

    private static void NullableTypeSample()
    {
        // 値型のデータ型名の直後に?をつけることでnull許容型となり、
        // 値型に対してnullを適用できるようになる。
        int? x = null;

        // null許容型はHasValueプロパティを持っている。
        // このプロパティは、値が割り当てられていればtrueを返し、nullの場合にfalseを返す。
        if (!x.HasValue)
        {
            Console.WriteLine("x is null");            
        }

        x = 10;
        if (x.HasValue)
        {
            // Valueプロパティは値が割り当てられていればその値を返し、
            // nullの場合にはSystem.InvalidOperationExceptionをthrowする。
            Console.WriteLine($"x is {x.Value}");
        }

        // null許容型と値型に対する演算を行った場合、暗黙的にValueプロパティが参照される。
        Console.WriteLine(x + 10);
    }

    static private void NullableReferenceSample()
    {
        // 参照はもともとnullがデフォルト値であったが、
        // 参照がnullであるかを確かめて処理を行うことに起因するトラブルが多いため、
        // C# 8.0以降ではnullを許容しないようになった。
        // 過去のバージョンの動作を知る必要がある場合には重要な概念だが、
        // 過去のバージョンを気にする必要がないならば
        // そもそもnull非許容型だけを前提にC#を使用すれば良いだけのため、省略する。
    }

    static private void NullableCoalescingSample()
    {
        int? a = null;

        // ??演算子はnull合体演算子と呼ばれ、
        // 左側のオペランドがnullではない場合にはそのオペランドを返し、
        // 左側のオペランドがnullの場合には右側のオペランドを返す。
        Console.WriteLine(a ?? 10);

        a = 5;
        Console.WriteLine(a ?? 10);

        // 参照型でも使える。
        string s = null;
        Console.WriteLine(s ?? "null is assigned");

        //複合代入演算子もある
        s ??= "default string";
        Console.WriteLine(s);
    }

    private static void NullableConditionalSample()
    {
        var t = new Team();

        // 初期化されていないフィールドを参照しようとすると、
        // System.NullReferenceExceptionがthrowされるため、例外処理が必要となる。
        try
        {
            string? s1 = t.Member.Name;
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            // Do Nothing
        }

        // null条件演算子は左側のオペランドがnullではない場合にはそのオペランドのメンバを呼び出し、
        // 左側のオペランドがnullの場合にはnullをそのまま返す。(構造体の場合はnull許容型を返す)
        // System.NullReferenceExceptionは発生しない。
        string? s2 = t.Member?.Name;
        Console.WriteLine(s2);

        // null条件演算子はnull合体演算子と組み合わせて使われることが多い
        string? s3 = t.Member?.Name ?? "nothing";
        Console.WriteLine(s3);
    }
}
