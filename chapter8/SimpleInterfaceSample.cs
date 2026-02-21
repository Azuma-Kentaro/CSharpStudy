using System;

namespace chapter8;

// 慣例としてインタフェース名はIから始める。
// インタフェースのアクセスレベルはpublicかinternalの2種類である。
// 明示しない場合のデフォルトはpublicである。
interface IPrintInfo
{
    // インタフェースでは、メソッドの宣言のみを行う。
    // ただし、C# 8以降はデフォルトの定義を持つこともできる。
    void PrintInfo();

    // インタフェースはインスタンスフィールドを持つことはできない。
}

// インタフェースで宣言されたメソッドをクラスで定義することを
// インタフェースの実装と呼ぶ。
// インタフェースの実装はクラスの継承と同じ構文になる。
class ImplementIPrintInfo : IPrintInfo
{
    //
    public void PrintInfo()
    {
        Console.WriteLine("ImplementIPrintInfo implements IPrintInfo");
    }
}

public class SimpleInterfaceSample
{
    public static void SimpleInterfaceSampleMain()
    {
        var x = new ImplementIPrintInfo();
        x.PrintInfo();        
    }
}
