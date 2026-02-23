using System;

namespace chapter11;

delegate void SampleEventHandler();

class EventGenerator
{
    // イベントハンドラの宣言時には
    // delegateキーワードの代わりにeventキーワードを使用する。
    // イベントハンドラは空のハンドラで初期化をすることが望ましい。
    public event SampleEventHandler ThreeEvent = delegate { };
    // ラムダ式を使うこともできる。
    //public event SampleEventHandler ThreeEvent = () => {};

    // 3の倍数のときにイベントを発生させる。
    public void OnThreeEvent()
    {
        for (int i = 0; i < 20; i++)
        {
            if (i % 3 == 0)
            {
                // イベントハンドラを呼び出せるのは、そのイベントをメンバとするクラスの内部からだけである。
                ThreeEvent();
            }
        }
    }
}

public class EventSample
{
    public static void EventSampleMain()
    {
        var eg = new EventGenerator();

        // イベントハンドラの追加
        // イベントハンドラに対してクラスの外部から行うことができるのは
        // ハンドラの登録と登録解除のみである。
        // ハンドラに直接代入することはできない。
        //eg.ThreeEvent = delegate { Console.WriteLine("XX"); };
        eg.ThreeEvent += delegate { Console.WriteLine("XX"); };

        // ラムダ式を使うこともできる。
        //eg.ThreeEvent += () => Console.WriteLine("XX");

        // イベントハンドラを呼び出せるのは、そのイベントをメンバとするクラスの内部からだけである。
        // イベントハンドラはいくつかの制約が与えられたデリゲートであると解釈することができる。
        //eg.ThreeEvent();

        eg.OnThreeEvent();
    }
}
