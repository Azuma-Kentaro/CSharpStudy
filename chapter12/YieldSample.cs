using System;

namespace chapter12;

public class YieldSample
{
    public static void YieldSampleMain()
    {
        YieldReturnBreakSample();
        AsyncStreamSample();
    }

    private static void YieldReturnBreakSample()
    {
        // IEnumerable<T>インタフェースはforeach文などで
        // 要素を列挙するためのインタフェースである。
        // 通常はメソッドを自分で実装する必要があるが、
        // yieldキーワードを使うことでそれらのコードが自動的に生成される。
        IEnumerable<int> factorial(int number)
        {
            if ((number < 1) || (number > 100))
            {
                Console.WriteLine("error");
                // yield return文のある関数で処理を終了したい場合は
                // yield break文を記述する必要がある。
                yield break;
            }
            for (int i = number; i > 0; i--)
            {
                yield return i;
            }
        }

        // foreach文などで値が列挙されるときに
        // 内部でコレクションオブジェクトが生成され、
        // そのコレクションオブジェクトに対して値が追加される。
        // 本には「メソッドは終わらない」と記述されているので、
        // ループごとに値が1つ追加される感じ?
        foreach (int n in factorial(101))
        {
            Console.WriteLine(n);
        }

        foreach (int n in factorial(3))
        {
            Console.WriteLine(n);
        }
    }

    private static void AsyncStreamSample()
    {
        var task = AsyncStreamTask();
        task.Wait();        
    }

    private static async Task AsyncStreamTask()
    {
        // C# 8.0から導入された非同期ストリームによって、非同期メソッドで複数の値を返すことができる。
        // それまでは非同期メソッドでは1つの値のみを返していたため、
        // yieldキーワードを併用できないという制限があった。
        // 非同期ストリームでは、IAsyncEnumerable<T>というオブジェクトを用いてストリームを返す。
        // 非同期ストリームを返すメソッドでは、yieldキーワードを併用できる。
        async IAsyncEnumerable<int> factorial(int number)
        {
            for (int i = number; i > 0; i--)
            {
                await Task.Delay(1000);
                yield return i;
            }            
        }

        // foreachループ内で、IAsyncEnumerable<T>から値を取り出す場合はawaitキーワードが必要である。
        // 取り出せる状態になり次第、ループ毎の処理が実行される。
        // サンプルでは1000ミリ秒の待機によって取り出せる状態としているが、
        // データベースからのデータ取得、ファイルのダウンロード完了など様々な用途で置き換えることができる。
        await foreach (int n in factorial(10))
        {
            Console.WriteLine(n);
        }
    }
}
