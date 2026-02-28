using System;

namespace chapter12;

public class LinqSample
{
    public static void LinqSampleMain()
    {
        LinqExpressionSample();
        LinqMethodSample();
    }

    private static void LinqExpressionSample()
    {
        // LINQの対象となるデータをデータソースと呼ぶ
        int[] num = { 1, 2, 9, 28, 30, 31, 15, 42, };

        // LINQの構文にはクエリ式とメソッド構文がある。
        // 下記はクエリ式の例である。
        var numsQuery = from n in num
                        where n < 30
                        select n;

        foreach (var x in numsQuery)
        {
            Console.WriteLine(x);
        }

        // クエリ式の結果が確定するのは実際にデータが参照されるときである。
        // 従って、numsQueryに代入した後にデータソースが変更された場合、
        // numsQueryからデータを取り出すタイミングのデータソースの状態が反映される。
        // この機能は遅延実行と呼ばれる。

        // 本のサンプルだとこのようにしてデータソースの並び順を入れ替えていたが、
        // タプルを使ったより簡単な方法があるので、そちらの方法で入れ替える。
        //var tmp = num[0];
        //num[0] = num[1];
        //num[1] = tmp;
        (num[0], num[1]) = (num[1], num[0]);

        foreach (var x in numsQuery)
        {
            Console.WriteLine(x);
        }
    }

    private static void LinqMethodSample()
    {
        // LINQの対象となるデータをデータソースと呼ぶ
        int[] num = { 1, 2, 9, 28, 30, 31, 15, 42, };

        // LINQの構文にはクエリ式とメソッド構文がある。
        // 下記はメソッド構文の例である。
        var numsQuery = num.Where(n => (n < 30));

        foreach (var x in numsQuery)
        {
            Console.WriteLine(x);
        }
    }
}
