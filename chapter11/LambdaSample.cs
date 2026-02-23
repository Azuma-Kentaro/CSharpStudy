using System;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;

namespace chapter11;

// クラスの定義にラムダ式を用いたサンプル
class ClassWithLambda
{
    private int num;
    private string[] string_array = new string[5];

    // ラムダ式によるプロパティ(getアクセサ)
    public string Name => "Nothing";

    // ラムダ式によるプロパティ(インデクサ)
    // valueは宣言不要で使用できるパラメータ
    public string this[int key]
    {
        get => string_array[key];
        set => string_array[key] = value;
    }

    // ラムダ式によるコンストラクタ
    public ClassWithLambda() => num = 3;

    // ラムダ式によるメソッド
    public int Multi(int a) => a * this.num;
    // 以下と同じ
    // public int Multi(int a)
    // {
    //     return a * this.num;
    // }

}

public class LambdaSample
{
    public static void LambdaSampleMain()
    {
        SimpleLambdaSample();
        LambdaParameterSample();
        CaptureLambdaSample();
        StaticLambdaSample();
        ClassWithLambdaSample();
    }

    private static void SimpleLambdaSample()
    {
        // 式形式のラムダ式
        // Actionは戻り値なし、パラメータ1つのメソッドに対するデリゲートである。
        Action<int> lambda1 = (x) => Console.WriteLine($"lambda1 x: {x}");
        lambda1(10);

        // ステートメント形式のラムダ式
        Action<int> lambda2 = (x) =>
        {
            Console.WriteLine($"lambda2 x: {x}");
            Console.WriteLine("multiple statements are allowed");
        };
        lambda2(10);
    }

    private static void LambdaParameterSample()
    {
        int ret = 0;
        // int型のパラメータを2つ受け取ってint型の戻り値を返すデリゲート
        // _が1つの場合は、パラメータとして扱われる。
        Func<int, int, int> func1 = (_, p) => _ * p;
        ret = func1(10, 40);
        Console.WriteLine($"func1(10, 40) result: {ret}");

        // C# 9以降からは_が2つ以上の場合は、_に渡された値を破棄できる。
        // 使う予定のないパラメータを明示する目的で使用する。
        Func<int, int, int> func2 = (_, _) => 0;
        ret = func2(10, 40);
        Console.WriteLine($"func2(10, 40) result: {ret}");

        // C# 12以降はデフォルトパラメータを指定することができる。
        var greet = (string name = "John", string message = "Hello") => Console.WriteLine($"{message}, {name}");
        greet();
        greet("Ken");
        greet("Ken", "Hi");
    }

    private static void CaptureLambdaSample()
    {
        Action CreateLambda(int n)
        {
            // 一見するとCreateLambdaメソッドの終了とともにbは無効になりそうであるが、
            // ラムダ式の外側で定義されているローカル変数をラムダ式の内側で参照することができる。
            // この機能を変数のキャプチャと呼ぶ。(他の言語で言うクロージャと同じ?)
            int b = 2;
            return () => { Console.WriteLine( n * b); };
        }
        Action action = CreateLambda(3);
        action();
    }

    private static void StaticLambdaSample()
    {
        // staticキーワードを指定したラムダ式は外部の変数をキャプチャしないことを明示する。
        // C# 9以降で使用できる。
        Action<int, int> action = static (x, y) => Console.WriteLine(x * y);
        action(2, 10);
    }

    private static void ClassWithLambdaSample()
    {
        var c = new ClassWithLambda();
        Console.WriteLine(c.Name);
        Console.WriteLine(c.Multi(5));

        c[1] = "test";
        Console.WriteLine(c[1]);
    }
}
