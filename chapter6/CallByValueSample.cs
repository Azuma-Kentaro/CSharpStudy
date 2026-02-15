using System;

namespace chapter6;

class CallByValueTest
{
    public int x;
    public int y;
    public string name = "John";
}

public class CallByValueSample
{
    private static void ChangeValue(CallByValueTest test)
    {
        test.x = 1;
        test.y = 2;
        test.name = "Taro";
    }

    public static void CallByValueSampleMain()
    {
        // 値渡しによる呼び出しは、実引数がクラスのような参照型であったとしても
        // メソッド内で仮引数に対して行った変更は呼び出し元の実引数に影響を与えない。
        var testParam = new CallByValueTest();
        Console.WriteLine($"x: {testParam.x}, y:{testParam.y}, name: {testParam.name}");

        // ということだったが、実際には変更されている。
        // 本のサンプルはint型であるからそのまま値渡しがされているだけであって、
        // 上記の説明を証明するコードにはなっていない。
        // でも、実際にはその説明が正しく、このコードがその証明には不適切なだけかもしれない。
        ChangeValue(testParam);
        Console.WriteLine($"x: {testParam.x}, y:{testParam.y}, name: {testParam.name}");
    }
}
