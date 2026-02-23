using System;

namespace chapter10;


// C# 10でレコード構造体が導入された。
// record structという形式で定義する。
// レコード構造体は内部的には構造体としてコンパイルされる。
// プロパティはミュータブルである。
// readonlyキーワードを付加するか、initアクセサを定義することでイミュータブルにできる。
record struct Rstruct(int X, int Y);

// 参照型レコード
// C# 10でレコード構造体が導入されるまでは
// レコードと言えば参照型レコードのことだった。
// 参照型レコードは内部的にはクラスとしてコンパイルされる。
// そのため、単にrecordとだけ記述した場合はrecord classとして解釈される。
// プロパティはイミュータブルである。
// レコードの特徴として、プライマリーコンストラクタに記述したパラメータと
// 同じ名前を持つプロパティが自動的に作成される。
// アクセサはgetとinitである。
record class Rclass(int X, int Y);

public class RecordSample
{
    public static void RecordSampleMain()
    {
        // レコード構造体
        var rs1 = new Rstruct { X = 2 };
        // プロパティはミュータブルである。
        rs1.Y = 10;
        Console.WriteLine(rs1);

        // 参照型レコード
        var rc1 = new Rclass(0, 0);
        // プロパティはイミュータブルである。
        // rc.Y = 10;
        Console.WriteLine(rc1);

        // 既存のレコードをベースに、一部だけ値を変更したレコードを作成することができる。
        // その際はwithキーワードを用いる。
        var rc2 = rc1 with { Y = 10 };
        Console.WriteLine(rc2);

        // withブロックの中身がない場合はレコードの複製となる。
        var rc3 = rc2 with { };
        Console.WriteLine(rc3);

        // 参照型レコードの比較はアドレスではなくフィールドの値を用いて行われる。
        Console.WriteLine(rc2 == rc3);
    }
}
