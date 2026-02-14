using System;

namespace chapter3;

public class CharSample
{
    public static void CharLiteralSample()
    {
        // charは1文字のデータを表しており、System.Charに対するエイリアスである。
        // C#では、文字データはUTF-16にエンコードされる。そのため、サイズは16ビットである。
        // 文字リテラルの先頭に\uまたは\xを使用することで、文字コードを直接指定することもできる。
        char a = '漢';
        Char b = '\u6F22';
        char c = '\x6F22';
        Console.WriteLine($"charcter a is {a}, character b is {b}, character c is {c}");
    }
}
