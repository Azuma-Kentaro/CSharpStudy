using System;

namespace chapter3.UserDefinedType;

public class AnonymousTypeSample
{
    public static void AnonymousTypeSampleMain()
    {
        // ローカル変数にvarキーワードを用いると、コンパイラが自動的にデータ型を判断する。
        // 判断には初期値が必要となる。
        // 匿名型は、名前を持たない複合的な型である。
        // そのため、変数の宣言時にはvarキーワードを使う必要がある。
        var a = new { Number = 1, Name = "John" };

        // 匿名型は読み取りだけ可能である。
        Console.WriteLine(a.Number);
        Console.WriteLine(a.Name);
        // 値を変更することはできない。
        // a.Number = 20;
    }
}
