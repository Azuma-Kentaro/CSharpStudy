using System;

namespace chapter3;

public class PrimitiveTypeSample
{
    static void Main()
    {
        Console.WriteLine("=== start string literal sample ===");
        StringSample.StringLiteralSample();
        Console.WriteLine("=== end string literal sample ===");

        Console.WriteLine("=== start raw string literal sample ===");
        StringSample.RawStringLiteralSample();
        Console.WriteLine("=== end raw string literal sample ===");

        Console.WriteLine("=== start UTF-8 literal sample ===");
        StringSample.UTF8LiteralSample();
        Console.WriteLine("=== end UTF-8 literal sample ===");
    }
}
