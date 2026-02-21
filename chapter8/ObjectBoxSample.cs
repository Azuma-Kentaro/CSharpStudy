
namespace chapter8;

public class ObjectBoxSample
{
    public static void ObjectBoxSampleMain()
    {
        int a = 10;

        // C#における任意のクラスは、System.Objectクラスを基本クラスに持つ
        // C#においては、object型はSystem.Objectクラスのエイリアスである。
        object obj;

        // object型へのアップキャストはボックス化と呼ばれる。
        // ヒープ上に10を格納するためのメモリ領域が確保され、
        // objにはそのアドレスが代入される。
        obj = (object)a;

        // object型からのダウンキャストはボックス化解除と呼ばれる。
        var b = (int)obj;
        Console.WriteLine($"b: {b}");

        // 元々はint型なので、エラーになる。
        //var d = (double)obj;
    }
}
