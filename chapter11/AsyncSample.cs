using System;
using System.Diagnostics;
using System.Formats.Asn1;

namespace chapter11;

public class AsyncSample
{
    static void ThreadMethod()
    {
        Thread.Sleep(3000);
        Console.WriteLine("finished");
    }

    public static void AsyncSampleMain()
    {
        TaskSample();
        ParallelSample();
        AsyncAwaitSample();
        AsyncAwaitWithReturnValueSample();
    }

    private static void TaskSample()
    {
        Console.WriteLine("TaskSample start");
        // TaskクラスのRunメソッドにActionデリゲートを渡すことで、
        // タスクの作成から実行までを行うことができる。
        // 内部ではThreadPoolクラスを利用している。
        var task = Task.Run(new Action(ThreadMethod));
        task.Wait();
    }

    private static void ParallelSample()
    {
        Console.WriteLine("ParallelSample start");

        // ParallelクラスのInvokeメソッドにActionデリゲートを渡す。
        // Invokeメソッドには任意の数のActionデリゲートを渡すことができる。
        // ラムダ式でもよい。
        Parallel.Invoke(new Action(ThreadMethod),
        () =>
        {
            Thread.Sleep(5000);
            Console.WriteLine("ParallelSample second arg finished");
        });
    }

    private static void AsyncAwaitSample()
    {
        // async修飾子をつけた非同期メソッドは、最後にAsyncをつけるのが慣例である。
        static async Task ThreadMethodAsync()
        {
            // await演算子によって、非同期メソッド内で完了まで待つ。
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("ThreadMethodAsync finish");
            });
        }

        Console.WriteLine("AsyncAwaitSample start");
        // async修飾子とawait演算子によって、同期処理のような書き方ができる。
        var t = ThreadMethodAsync();
        // タスク完了までアプリケーションを終了しないようにする。
        t.Wait();
    }

    private static void AsyncAwaitWithReturnValueSample()
    {
        static async Task<long> ThreadMethodWithReturnValueAsyncSample()
        {
            long val = 0;

            return await Task.Run(() =>
            {
                for (long i = 0; i < 1000000000; i++)
                {
                    val += i;
                }

                // 戻り値を返す非同期メソッドにはreturn文が存在する。
                return val;
            });
        }

        Console.WriteLine("ThreadMethodWithReturnValueAsyncSample start");

        // 戻り値を返す非同期メソッドの場合は、ジェネリックを用いたTask型となる。
        Task<long> t = ThreadMethodWithReturnValueAsyncSample();

        // タスク完了までアプリケーションを終了しないようにする。
        t.Wait();

        // 戻り値を返す非同期メソッドは、Task型のResultプロパティでその戻り値を取得できる。
        Console.WriteLine($"ThreadMethodWithReturnValueAsyncSample result: {t.Result}");
    }
}
