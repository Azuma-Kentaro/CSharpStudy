using System;
using X;

namespace X
{
    public static class StringExtender
    {
        // 既存の型に対する拡張メソッド
        public static int Hex2Int(this string s)
        {
            return Convert.ToInt32(s, 16);
        }
    }    
}

namespace chapter11
{

class BMICalculator
{
    public double Weight { get; }
    public double Height { get; set; }

    public BMICalculator(double w, double h)
    {
        this.Weight = w;
        this.Height = h / 100;
    }

    public double BMI()
    {
        return this.Weight / (this.Height * this.Height);
    }
}

static class BMICalculatorExtender
{
    // 拡張メソッドは静的クラスの静的メソッドとして定義する必要がある。
    // 拡張メソッドの最初のパラメータはthis 拡張するクラス名である必要がある。
    // ちなみにこのメソッドは肥満度を判定する。
    public static void CheckJ(this BMICalculator bc)
    {
        if (25 <= bc.BMI())
        {
            Console.WriteLine("肥満");
        }
        else if (bc.BMI() < 18)
        {
            Console.WriteLine("やせすぎ");
        }
        else
        {
            Console.WriteLine("標準");
        }
    }
}

public class ExtendMethodSample
{
    public static void ExtendMethodSampleMain()
    {
        ExtendMethodForUserDefinedClassSample();
        ExtendMethodForPreDefinedClassSample();
    }

    private static void ExtendMethodForUserDefinedClassSample()
    {
        var bmic = new BMICalculator(80, 170);

        // 拡張メソッドの呼び出し
        // 拡張メソッドは元のクラスに始めからあったかのように扱うことができる。
        bmic.CheckJ();
    }

    private static void ExtendMethodForPreDefinedClassSample()
    {
        var s = "D3";

        // 拡張メソッドの呼び出し
        // string型に始めからあったかのように扱うことができる。
        Console.WriteLine(s.Hex2Int());
    }
}

}
