using System;

namespace chapter4;

public class BitShiftSample
{
    public static void BitShiftSampleMain()
    {
        LightShiftPositiveInteger();
        UnsignedLightShiftPositiveInteger();
        LightShiftNegativeInteger();
        UnsignedLightShiftNegativeInteger();
    }

    private static void LightShiftPositiveInteger()
    {
        int a = 127;
        Console.WriteLine(a.ToString("B32"));

        a = a >> 1;
        Console.WriteLine(a.ToString("B32"));

        a = a >> 1;
        Console.WriteLine(a.ToString("B32"));
    }

    private static void UnsignedLightShiftPositiveInteger()
    {
        int a = 127;
        Console.WriteLine(a.ToString("B32"));

        a = a >>> 1;
        Console.WriteLine(a.ToString("B32"));

        a = a >>> 1;
        Console.WriteLine(a.ToString("B32"));
    }
    private static void LightShiftNegativeInteger()
    {
        int a = -128;
        Console.WriteLine(a.ToString("B32"));

        a = a >> 1;
        Console.WriteLine(a.ToString("B32"));

        a = a >> 1;
        Console.WriteLine(a.ToString("B32"));
    }

    private static void UnsignedLightShiftNegativeInteger()
    {
        int a = -128;
        Console.WriteLine(a.ToString("B32"));

        a = a >>> 1;
        Console.WriteLine(a.ToString("B32"));

        a = a >>> 1;
        Console.WriteLine(a.ToString("B32"));
    }
}
