using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace chapter9;

public class ThrowExpressionSample
{
    public static void ThrowExpressionSampleMain()
    {
        ThrowExpressionInLambda();
        ThrowExpressionInCondition(-1);
        ThrowExpressionAfterNullCoalescing();
    }

    // throw式が使える状況その1
    // lambda式の=>演算子の後
    private static void ThrowExpressionInLambda()
    {
        static int Throw() => throw new Exception("Lambda");
        try
        {
            Throw();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    // throw式が使える状況その2
    // 条件演算子の第2オペランドまたは第3オペランド
    private static void ThrowExpressionInCondition(int x)
    {
        int y;

        try
        {
            y = x >= 0 ? x : throw new Exception("x is less than 0");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    // throw式が使える状況その3
    // null合体演算子の後
    private static void ThrowExpressionAfterNullCoalescing()
    {
        object? obj = null;

        try
        {
            var s = obj as string ?? throw new Exception();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
