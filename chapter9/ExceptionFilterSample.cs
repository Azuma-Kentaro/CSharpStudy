using System;

namespace chapter9;

public class ExceptionFilterSample
{
    public static void ExceptionFilterSampleMain()
    {
        ExceptionFilterForAnExcepction();
        ExceptionFilterForExceptions();
    }

    // 例外フィルターの使い方その1
    // ある例外についてさらに細かい条件を指定したい場合
    private static void ExceptionFilterForAnExcepction()
    {
        try
        {
            Console.WriteLine("try");

            // throwキーワードを用いることで例外を意図的に発生させることができる。
            // Exceptionクラスのコンストラクタは複数あり、
            // 以下はMessageプロパティに値を設定する
            throw new Exception("error");
        }
        // catchの後にwhenキーワードを用いることでさらに細かい条件を指定することができる。
        // ちなみにSystem.Exceptionには例外が発生した原因などの情報を保持するプロパティが存在する。
        catch (Exception e) when (e.Message == "error")
        {
            Console.WriteLine(e);
        }
        finally
        {
            Console.WriteLine("finally");
        }
    }

    // 例外フィルターの使い方その2
    // 複数の例外クラスに対して同じ処理を行いたい場合に
    // それらの例外クラスをまとめて捕捉する
    private static void ExceptionFilterForExceptions()
    {
        try
        {
            int x = 10;
            int y = 0;

            int z = x / y;
        }
        catch (Exception e)
            when (e is DivideByZeroException || e is ArithmeticException)
        {
            Console.WriteLine(e);
        }
    }
}
