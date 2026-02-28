using System;

namespace chapter12;

public class FileSample
{
    public static void FileSampleMain()
    {
        string sampleFileName = "SampleFile.txt";
        FileOutputSample(sampleFileName);
        FileInputSample(sampleFileName);
    }

    private static void FileOutputSample(string? outputFileName)
    {
        try
        {
            // ファイルのオープン
            // C# 8.0から変数宣言時にusingキーワードを付与することで、
            // スコープ外になるタイミングでDisposeメソッドを呼び出すようにすることができる。
            // DisposeメソッドはIDisposableインタフェースで宣言されている。
            // これはリソースの確実な解放を可能にする。
            // つまり、finallyでファイルのクローズを明示的に記述しなくても自動的にやってくれる構文である。
            using StreamWriter sw = new(outputFileName!, false, System.Text.Encoding.Default);
            sw.WriteLine("1行目");
            sw.WriteLine("2行目");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private static void FileInputSample(string? inputFileName)
    {
        try
        {
            // ファイルのオープン
            // C# 8.0より前では、usingを使うときは対象となるスコープをブロックで囲む必要があった。
            using (StreamReader sr = new(inputFileName!, System.Text.Encoding.Default))
            {
                // defaultキーワードはその型のデフォルトの値を設定する。
                string? line = default;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
