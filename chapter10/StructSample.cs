using System;

namespace chapter10;

// C# 10より前は、構造体の定義でフィールドの初期化を行うことはできなかった。
struct OldStructSample
{
    public int Number;
    public string Name;
}

// C# 10以降は、構造体の定義でフィールドの初期化を行うことができる。
struct NewStructSample
{
    public int Number = -1;
    public string Name = "John";

    public NewStructSample(int number, string name)
    {
        this.Number = number;
        this.Name = name;
    }

    // C# 10以降はデフォルトコンストラクタを定義できる。
    // C# 11以降は明示的に代入しなかったフィールドや自動プロパティはデフォルト値で初期化されるらしい
    public NewStructSample()
    {
        this.Number = 1;
        this.Name = "Taro";
    }
}

public class StructSample
{
    public static void StructSampleMain()
    {
        // C# 10より前の書き方
        // 構造体は値型であるため、newによるインスタンスの作成は不要である。
        // その場合、メンバが未定義になるので値を明示的に設定する必要がある。
        OldStructSample oldSample;
        oldSample.Number = 0;
        oldSample.Name = "John";
        Console.WriteLine($"oldSample.Number: {oldSample.Number}, oldSample.Name: {oldSample.Name}");

        // C# 10以降の書き方
        // 構造体は値型であるため、newによるインスタンスの作成は不要である。
        // その場合、メンバが未定義になるので値を明示的に設定する必要がある。
        NewStructSample newSample1;
        newSample1.Number = 0;
        newSample1.Name = "John";
        Console.WriteLine($"newSample.Number: {newSample1.Number}, newSample.Name: {newSample1.Name}");

        // default キーワードを用いた場合、各フィールドはデフォルト値で初期化される。
        NewStructSample newSample2 = default;
        Console.WriteLine($"newSample.Number: {newSample2.Number}, newSample.Name: {newSample2.Name}");

        // newによるインスタンスの作成は不要であるが、実行することもできる。
        // newによるインスタンスの作成を実行した場合、コンストラクタが呼び出される。
        NewStructSample newSample3 = new NewStructSample(100, "Ken");
        Console.WriteLine($"newSample.Number: {newSample3.Number}, newSample.Name: {newSample3.Name}");

        // C# 10以降はデフォルトコンストラクタが定義できる
        NewStructSample newSample4 = new NewStructSample();
        Console.WriteLine($"newSample.Number: {newSample4.Number}, newSample.Name: {newSample4.Name}");
    }
}
