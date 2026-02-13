using System;

namespace chapter3;

public class IntegerSample
{
    public static void IntegerTypeSample()
    {
        // sbyteは符号付き8ビットの整数であり、System.SByteに対するエイリアスである。
        sbyte int8_value1 = sbyte.MinValue;
        SByte int8_value2 = SByte.MaxValue;
        Console.WriteLine($"sbyte is between {int8_value1} and {int8_value2}");

        // byteは符号なし8ビットの整数であり、System.Byteに対するエイリアスである。
        byte uint8_value1 = byte.MinValue;
        Byte uint8_value2 = Byte.MaxValue;
        Console.WriteLine($"byte is between {uint8_value1} and {uint8_value2}");

        // shortは符号付き16ビットの整数であり、System.Int16に対するエイリアスである。
        short int16_value1 = short.MinValue;
        Int16 int16_value2 = Int16.MaxValue;
        Console.WriteLine($"short is between {int16_value1} and {int16_value2}");

        // ushortは符号なし16ビットの整数であり、System.UInt16に対するエイリアスである。
        ushort uint16_value1 = ushort.MinValue;
        UInt16 uint16_value2 = UInt16.MaxValue;
        Console.WriteLine($"ushort is between {uint16_value1} and {uint16_value2}");

        // intは符号付き32ビットの整数であり、System.Int32に対するエイリアスである。
        int int32_value1 = int.MinValue;
        Int32 int32_value2 = Int32.MaxValue;
        Console.WriteLine($"int is between {int32_value1} and {int32_value2}");

        // uintは符号なし32ビットの整数であり、System.UInt32に対するエイリアスである。
        uint uint32_value1 = uint.MinValue;
        UInt32 uint32_value2 = UInt32.MaxValue;
        Console.WriteLine($"uint is between {uint32_value1} and {uint32_value2}");

        // longは符号付き64ビットの整数であり、System.Int64に対するエイリアスである。
        long int64_value1 = long.MinValue;
        Int64 int64_value2 = Int64.MaxValue;
        Console.WriteLine($"long is between {int64_value1} and {int64_value2}");

        // ulongは符号なし64ビットの整数であり、System.UInt64に対するエイリアスである。
        ulong uint64_value1 = ulong.MinValue;
        UInt64 uint64_value2 = UInt64.MaxValue;
        Console.WriteLine($"ulong is between {uint64_value1} and {uint64_value2}");
    }

    public static void IntegerLiteralSample()
    {
        // リテラルにサフィックスがない場合、int, uint, long, ulongから順番に
        // その値を表すことができる最初の型が割り当てられる。
        var decimal_literal_value = 65535;

        // プレフィックスの0bは2進数であることを表す。
        // リテラルは_で区切ることができる。これは視認性に役立つ。
        var binary_literal_value = 0b_1111_1111;

        // プレフィックスの0xは16進数であることを表す。
        // リテラルは_で区切ることができる。これは視認性に役立つ。
        var hexdecimal_literal_value = 0x_FF_FF_FF_FF;

        uint uint_value = 123U;

        long long_value = -1L;

        ulong ulong_value = 123UL;
    }
}
