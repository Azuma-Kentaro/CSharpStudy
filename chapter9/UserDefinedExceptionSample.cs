using System;

namespace chapter9;

// System.Exceptionを継承することで
// ユーザ定義の例外クラスを定義することができる。
class UserDefinedExceptionBase : Exception
{
    public UserDefinedExceptionBase(string msg) : base(msg)
    {
    }
}

// ユーザ定義の例外クラスの基本クラスを継承することで
// 個別の例外を表現するユーザ定義の例外クラスを定義する。
class UserDefinedExceptionA : UserDefinedExceptionBase
{
    public UserDefinedExceptionA(string msg) : base(msg)
    {
    }
}

public class UserDefinedExceptionSample
{
    public static void UserDefinedExceptionSampleMain()
    {
        try
        {
            // throw文を使用すると、意図的に例外を発生させることができる。
            throw new UserDefinedExceptionA("UserDefinedExceptionA");
        }
        // 個別に例外処理を行いたいユーザ定義例外クラスに対する処理を記述する。
        catch (UserDefinedExceptionA e)
        {
            Console.WriteLine(e);
        }
        // 特に個別に指定していないユーザ定義例外クラスに対する処理を記述する。
        catch (UserDefinedExceptionBase e)
        {
            Console.WriteLine(e);
        }
        // すべての例外クラスに対する処理を記述する。
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
