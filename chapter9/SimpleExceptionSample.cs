using System;

namespace chapter9;

public class SimpleExceptionSample
{
    public static void SimpleExceptionSampleMain()
    {
        int x = 10;
        int y = 0;

        // tryブロックの中には、例外が発生する可能性のある処理を記述する。
        try
        {
            Console.WriteLine("try");
            int z = x / y;

            //例外が発生すると、以降の処理は行われない。
            Console.WriteLine("this will be never called");
        }
        // 複数のcatchブロックを定義した場合、定義した順番に一致するか判定する。
        // そして、最初に一致したブロックの処理のみが実行される。
        // DivideByZeroExceptionはArithmeticExceptionに含まれるため
        // catchを定義する順番が逆になるとDivideByZeroExceptionは捕捉できなくなる
        // ただし、そのような場合はコンパイルエラーになるので実行前に気づくことができる。
        // エラーになる理由は、より広範囲の例外のcatchを先に定義してしまうと
        // より狭い範囲の例外のcatchを定義しても決して捕捉されないからである。
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e);
        }
        // ArithmeticExceptionは算術演算に関する例外を扱う。
        // その中にはゼロ除算であるDivideByZeroExceptionも含まれる。
        // これをクラスで表した場合、DivideByZeroExceptionはArithmeticExceptionの派生クラスとなる。
        catch (ArithmeticException e)
        {
            Console.WriteLine(e);
        }
        // System.Exceptionはすべての例外の基本クラスである
        // つまり、System.Exceptionのcatchを定義する場合は最後になる。
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        // finallyブロックは、例外が発生してもしなくても実行される。
        // ファイルのクローズやDBとのコネクション切断など
        // 必ず実行する必要がある処理を記述することが多い。
        finally
        {
            Console.WriteLine("finally");
        }
    }
}
