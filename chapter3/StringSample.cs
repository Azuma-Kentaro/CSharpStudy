using System;

namespace chapter3;

public class StringSample
{
    static void Main()
    {
        Console.WriteLine("=== start string literal sample ===");
        StringLiteralSample();
        Console.WriteLine("=== end string literal sample ===");

        Console.WriteLine("=== start raw string literal sample ===");
        RawStringLiteralSample();
        Console.WriteLine("=== end raw string literal sample ===");

        Console.WriteLine("=== start UTF-8 literal sample ===");
        UTF8LiteralSample();
        Console.WriteLine("=== end UTF-8 literal sample ===");
    }

    static void StringLiteralSample()
    {
        string path1 = "c:\\user\\test\\sample.cs";
        Console.WriteLine(path1);

        // C# 逐語的文字列リテラル(verbatim string literal)
        string path2 = @"c:\user\test\sample.cs";
        Console.WriteLine(path2);

        // C# 11から利用可能になった生文字列リテラル(raw string literal)
        string path3 = """c:\user\test\sample.cs""";
        Console.WriteLine(path3);
    }

    static void RawStringLiteralSample()
    {
        var oldHTML = @"
<html>
    <body>
        <h1 class=""title"">通知<h1>
        <p class=""important"">
            これは""重要""な文書です。
        </p>
    </body>
</html>
";
        Console.WriteLine(oldHTML);

        var newHTML = """
<html>
    <body>
        <h1 class="title">通知</h1>
        <p class="important">
            これは"重要"な文書です。
        </p>
    </body>
</html>
""";
        Console.WriteLine(newHTML);
    }

    static void UTF8LiteralSample()
    {
        var oldUTF8String = System.Text.Encoding.UTF8.GetBytes("Hello, C#!");
        Console.WriteLine(BitConverter.ToString(oldUTF8String));

        // C# 11から利用可能になったUTF-8リテラル
        var newUTF8String = "Hello, C#!"u8;
        Console.WriteLine(BitConverter.ToString(newUTF8String.ToArray()));
    }
}
