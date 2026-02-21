using System;

namespace chapter9;

public class PropagateExceptionSample
{
    public static void PropagateExceptionSampleMain()
    {
        try
        {
            Console.WriteLine("outer try");

            // tryブロックはネストすることができる。
            try
            {
                Console.WriteLine("inner try");
                int x = 10;
                int y = 0;

                int z = x / y;
            }
            catch (DivideByZeroException e)
            {
                // catchブロックの中でthrowを実行することで
                // 外側のtryに対して例外を再度スローすることができる。
                // 外側のtryに対して行うため、すぐ下のcatchは実行されない。
                Console.WriteLine("inner try catch DivideByZeroException");
                Console.WriteLine(e);

                throw new Exception("created in inner catch DivideByZeroException");
            }
            catch (Exception e)
            {
                Console.WriteLine("inner try catch Exception");
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("inner finally");
            }
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("outer try catch DivideByZeroException");
            Console.WriteLine(e);
        }
        catch (Exception e)
        {
            Console.WriteLine("outer try catch Exception");
            Console.WriteLine(e);
        }
        finally
        {
            Console.WriteLine("outer finally");
        }
    }
}
