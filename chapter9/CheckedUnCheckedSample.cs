using System;
using System.Net;

namespace chapter9;

public class CheckedUnCheckedSample
{
    public static void CheckedUnCheckedSampleMain()
    {
        CheckedSample();
        UncheckedSample();
        CheckedFloatingPointSample();
    }

    private static void CheckedSample()
    {
        short a = short.MaxValue;

        try
        {
            // オーバーフローに関する例外を検出したい場合はcheckedキーワードで囲む必要がある。
            // また、オーバーフローに関する例外を検出したくない場合はuncheckedキーワードで囲む必要がある。
            // デフォルトではオーバーフローに関する例外は検出されない。
            checked
            {
                a++;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private static void UncheckedSample()
    {
        try
        {
            // デフォルトではオーバーフローに関する例外は検出されない。
            // そのため、uncheckedブロックだけを書いても効果があるのかわからない。
            // checkedとuncheckedはネストが可能なので、
            // checkedで囲んだブロック内にuncheckedブロックを記述することで
            // オーバーフローに関する例外を検出しないことを確認する。
            checked
            {
                // オーバーフローに関する例外を検出したくない場合はuncheckedキーワードで囲む必要がある。
                unchecked
                {
                    short a = short.MaxValue;
                    a++;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    // 浮動小数点数の場合、オーバーフローが発生すると値は無限大となるが、
    // checkedブロック内であったとしてもオーバーフローに関する例外を検出することはできない。
    private static void CheckedFloatingPointSample()
    {
        checked
        {
            float x = 1e35f;
            Console.WriteLine(x * x);
        }
    }

}
