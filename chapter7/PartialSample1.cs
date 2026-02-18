using System;

namespace chapter7;

partial class PartialClass
{
    private int partialDefinedX = 5;

    // C# 9より前のPartialメソッド
    // 宣言だけでもエラーにならない
    // おそらく戻り値がvoidだけという制約なのは、
    // 定義がない場合に何もしないメソッドを自動生成しているからだと予想する
    partial void OldStylePartialDefinedMethod();

    // C# 9以降に使えるPartialMethod
    // 戻り値にvoid以外も使用でき、outキーワードをパラメータに指定できる
    // 実装が必須
    public partial int NewStylePartialDefinedMethod(out int a);
}

partial class PartialClass
{
    public void PrintX()
    {
        Console.WriteLine($"partialDefinedX: {partialDefinedX}");
    }
}

public class PartialSample1
{
    public static void PartialSampleMain()
    {
        var partialSample = new PartialClass();
        partialSample.PrintX();

        partialSample.NormalMethod();

        int a = 0;
        int b = 0;
        Console.WriteLine($"a: {a}");
        b = partialSample.NewStylePartialDefinedMethod(out a);
        Console.WriteLine($"a: {a}, b: {b}");
    }
}
