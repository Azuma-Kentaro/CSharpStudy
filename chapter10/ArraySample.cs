using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace chapter10;

public class ArraySample
{
    public static void ArraySampleMain()
    {
        SimpleArraySample();
        MultiDemensionalArraySample();
        JuggedArraySample();
        SystemArrayStaticMethodSample();
        CollectionExpressionSample();
    }

    private static void SimpleArraySample()
    {
        // 配列型の宣言
        int[] intArray1;

        // 配列型は参照型であるため、newでインスタンスを作成する必要がある。
        intArray1 = new int[3];

        // 配列の要素へアクセスする際にはインデックスを使用する。
        intArray1[0] = 1;
        intArray1[1] = 3;
        intArray1[2] = 5;
        Console.WriteLine($"intArray1[0]: {intArray1[0]}, intArray1[1]: {intArray1[1]}, intArray1[2]: {intArray1[2]}");

        // 配列型は宣言時に初期化することもできる。
        // その場合、要素数は省略することができる。
        // 省略した場合、要素数は初期値の数から自動的に決定される。
        // 要素数を明示しておきながら、初期値の数が要素数に一致しない場合はエラーとなる。
        // int[] intArray2 = new int[2] { 1, 3, 5 };

        int[] intArray2 = new int[] { 1, 3, 5 };

        // 配列はSystem.Array型のインスタンスである。
        // 配列の要素数はLengthプロパティで取得できる。
        for (var i = 0; i < intArray2.Length; i++)
        {
            Console.WriteLine($"intArray2[{i}]: {intArray2[i]}");
        }

        // 宣言時に初期化も行う場合、右辺のnew データ型[]の部分は省略することができる。
        int[] intArray3 = { 1, 3, 5 };

        // 配列に対してはforeachを使うこともできる。
        foreach (var elem in intArray3)
        {
            Console.WriteLine(elem);
        }

        // 配列に対して型推論を使用することもできる。
        var array = new [] { 1, 3, 5 };

        // 本には書いてないけど、配列を直接Console.WriteLineに渡すとどうなるか試してみる。
        Console.WriteLine(array);
    }

    private static void MultiDemensionalArraySample()
    {
        // 2次元配列を定義する。
        int[,] intArray2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

        // 多次元配列に対するforeachは全要素に対して行われる。
        foreach (var elem in intArray2D)
        {
            Console.WriteLine(elem);
        }

        // 3次元配列を定義する。
        int[,,] intArray3D = {
                                { { 1, 2, 3 }, { 4, 5, 6 } },
                                { { 7, 8, 9 }, { 10, 11, 12 } }
                             };

        // 多次元配列に対してLengthプロパティから取得できるのはすべての要素数になる。
        Console.WriteLine($"intArray3D.Length: {intArray3D.Length}");

        // 各次元の要素数を取得したい場合、System.ArrayクラスのGetLengthメソッドを使用する。
        // GetLengthメソッドの引数には、要素数を取得したい次元を指定する。
        for (var i = 0; i < intArray3D.GetLength(0); i++)
        {
            for (var j = 0; j < intArray3D.GetLength(1); j++)
            {
                for (var k = 0; k < intArray3D.GetLength(2); k++)
                {
                    Console.WriteLine($"intArray3D[{i}, {j}, {k}]: {intArray3D[i, j, k]}");
                }
            }
        }
    }

    private static void JuggedArraySample()
    {
        // 次元毎に要素数が異なる配列をジャグ配列と呼ぶ。
        // ジャグ配列は、配列の配列として扱う。
        // C#では、多次元配列とジャグ配列は異なるものとして扱われる。
        // CやC++では、そもそも多次元配列もジャグ配列である。
        int[][] juggedArray = new int[3][];

        // 各次元は個別に定義する必要がある。
        juggedArray[0] = new int[] { 1, 3, 5 };
        juggedArray[1] = new int[] { 0 };
        juggedArray[2] = new int[] { 2, 4 };

        foreach (var array in juggedArray)
        {
            // arrayは配列であるため、さらにforeachが必要となる
            foreach (var elem in array)
            {
                Console.WriteLine(elem);
            }
        }

        // ジャグ配列に多次元配列を指定することもできる。
        // ただし、最も外側の配列は1次元配列でなくてはならない。
        int[][,] juggedArray2D = new int[3][,];
        juggedArray2D[0] = new int[,] { { 10, 20 }, { 100, 200 } };
        juggedArray2D[1] = new int[,] { { 30, 40, 50 }, { 300, 400, 500 } };
        juggedArray2D[2] = new int[,] { { 60, 70, 80, 90 }, { 600, 700, 800, 900 } };

        // ジャグ配列のLengthプロパティは、最も外側の配列の要素数となる。
        for (var i = 0; i < juggedArray2D.Length; i++)
        {
            for (var j = 0; j < juggedArray2D[i].GetLength(0); j++)
            {
                for (var k = 0; k < juggedArray2D[i].GetLength(1); k++)
                {
                    Console.WriteLine($"juggedArray2D[{i}][{j}, {k}]: {juggedArray2D[i][j, k]}");
                }
            }
        }
    }

    private static void SystemArrayStaticMethodSample()
    {
        // メソッド内で使用する共通処理を定義することもできる。
        // これはローカル関数と呼ばれる。
        static void PrintArray(int[] a)
        {
            for (var i = 0; i < a.Length; i++)
            {
                Console.Write($"[{i}]: {a[i]}, ");
            }
            Console.WriteLine("");
        }

        int[] intArray = new int[] { 22, 13, 30, 54, -89, 19 };
        PrintArray(intArray);

        // 配列はSystem.Arrayクラスのインスタンスだが、
        // System.Arrayクラスには配列を操作するための静的メソッドが用意されている。
        // Sortはその1つであり、配列を昇順にソートする。
        Array.Sort(intArray);
        PrintArray(intArray);

        // Reverseは配列を逆順に並び替える。
        Array.Reverse(intArray);
        PrintArray(intArray);
    }

    private static void CollectionExpressionSample()
    {
        // C# 12から導入されたコレクション式は、
        // 配列やリストなどのコレクションを初期化する際に
        // []記号を用いて簡潔に記述することを可能にする。
        int[] intArray = [ 1, 2, 3, 4, 5 ];
        List<string> stringList = [ "apple", "banana", "orange" ];

        // コレクション式の中でスプレッド演算子を使用することで、
        // 他の配列やリストの中身を埋め込むことができる。
        int[] intArray2 = [ 0, ..intArray, 6 ];
        foreach (var elem in intArray2)
        {
            Console.WriteLine(elem);
        }
    }
}
