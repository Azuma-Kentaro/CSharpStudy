using System;
using IronPython.Hosting;

namespace chapter11_DLRSample;

public class DLRSample
{
    public static void DLRSampleMain()
    {
        var py = Python.CreateRuntime();
        dynamic sample = py.UseFile("sample.py");

        // Pythonで定義したクラスのインスタンス作成
        var p = sample.PythonSample();

        Console.WriteLine(p.getMessage("C#"));
    }
}
