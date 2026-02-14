using System;

namespace chapter3;

public class EnumSample
{

    // 列挙型にはアクセス修飾子を設定することもできる。
    // 指定しなかった場合にはpublicとして扱われる。
    enum Day:byte
    {
        Sun, Mon, Tue, Wed, Thu, Fri, Sat
    }

    // 型を省略するとintとして扱われる
    // 列挙型にはアクセス修飾子を設定することもできる。
    private enum Index
    {
        START = 0,
        NEXT,   // STARTに+1した値となる
        END = 10,
    }

    public static void EnumSampleMain()
    {
        // 列挙子を出力するとそのまま列挙子の名前となる。
        Console.WriteLine(Day.Sun);

        // 数値を出力したい場合はキャストが必要となる。
        Console.WriteLine((byte)Day.Sat);

        // 初期値を省略した列挙子の数値は、1つ前の列挙子の数値に1を加えた数値となる
        Console.WriteLine((int)Index.NEXT);
    }
}
