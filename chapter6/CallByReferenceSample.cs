using System;

namespace chapter6;

class CallByReferenceTest
{
    public void NotUseRefParam(int a)
    {
        a += 1;
    }

    public void UseRefParam(ref int a)
    {
        a += 1;
    }

    public void UseInParam(in int a)
    {
        // in キーワードを指定したパラメータは読み取り専用となり、
        // メソッド内で変更することができない。
        //a += 1;
        Console.WriteLine($"a: {a}");
    }

    // C# 12以降は仮パラメータにもref readonlyキーワードを使用することができる。
    public void UseRefReadonlyParam(ref readonly int a)
    {
        // inキーワード同様に読み取り専用であり、メソッド内で変更することはできない。
        //a += 1;
        Console.WriteLine($"a: {a}");
    }

    public void UseScopedRefParam(scoped ref int a)
    {
        a++;

        // scoped refキーワードを指定したパラメータはメソッドの戻り値には使用できない。
        // return ref a;
    }

    public void UseOutParam(out int a)
    {
        a = 100;
    }

    public ref int UseRefAsReturnValue(ref int x)
    {
        x++;
        return ref x;
    }

}

public class CallByReferenceSample
{
    public static void CallByReferenceSampleMain()
    {
        UseRefParamSample();
        UseInParamSample();
        UseRefReadonlyParamSample();
        ScopedRefParamSample();
        OutParamSample();
        RefAsReturnValueSample();
    }

    private static void UseRefParamSample()
    {
        int x = 10;
        Console.WriteLine($"x: {x}");

        var test = new CallByReferenceTest();

        // refがついていない値渡しによる呼び出しでは、
        // 仮パラメータに対する変更は実パラメータに影響を与えない
        test.NotUseRefParam(x);
        Console.WriteLine($"x: {x}");

        // refキーワードを使用した参照渡しによる呼び出しでは
        // 仮パラメータに対する変更が実パラメータに影響を与える。
        test.UseRefParam(ref x);
        Console.WriteLine($"x: {x}");
    }

    private static void UseInParamSample()
    {
        int x = 10;
        var test = new CallByReferenceTest();

        // 呼び出し時のinは省略できる。
        test.UseInParam(x);
        test.UseInParam(in x);
        // refキーワードの説明では、
        // 参照渡しはリテラルや式に対しては使用できないとのことだが、
        // inにはまた別の規則が適用される?
        test.UseInParam(5);
        test.UseInParam(x + 5);
    }

    private static void UseRefReadonlyParamSample()
    {
        int x = 10;
        var test = new CallByReferenceTest();

        // ref readonlyキーワードのパラメータに対する参照渡しに対しては
        // 呼び出し元で定義済みの変数に対する参照のみが使用可能であり
        // リテラルや式を使用すると警告が表示される。
        test.UseRefReadonlyParam(ref x);
        test.UseRefReadonlyParam(x + 5);
    }

    private static void ScopedRefParamSample()
    {
        int x = 10;
        Console.WriteLine($"x: {x}");

        var test = new CallByReferenceTest();
        test.UseScopedRefParam(ref x);
        Console.WriteLine($"x: {x}");
    }

    private static void OutParamSample()
    {
        int x;

        var test = new CallByReferenceTest();
        test.UseOutParam(out x);
        Console.WriteLine($"x: {x}");

        // C# 7以降ではoutに使用する変数を呼び出し時に定義することもできる。
        test.UseOutParam(out int y);
        Console.WriteLine($"y: {y}");
    }

    private static void RefAsReturnValueSample()
    {
        int x = 10;

        var test = new CallByReferenceTest();
        ref int y = ref test.UseRefAsReturnValue(ref x);
        Console.WriteLine($"x: {x}, y: {y}, x == y: {x == y}");

        // yはxを指すので、yに代入した値はxにも反映される。
        // ref readonly yとした場合はyは読み取り専用なので下記コードはエラーとなる。
        y = 100;
        Console.WriteLine($"x: {x}, y: {y}, x == y: {x == y}");
    }
}
