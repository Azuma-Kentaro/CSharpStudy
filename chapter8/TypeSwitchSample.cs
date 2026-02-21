using System;

namespace chapter8;

class BaseClassSample
{

}

class DerivedClassSample : BaseClassSample
{
    
}

public class TypeSwitchSample
{
    public static void TypeSwitchSampleMain()
    {
        DownCastWithTypeSwitch();
        DownCastWithIs();
        DownCastWithAs();
    }

    public static void DownCastWithTypeSwitch()
    {
        BaseClassSample b = new DerivedClassSample();

        // 型スイッチは、ダウンキャストと変数の定義を同時に行うことができる。
        // ダウンキャストが可能な場合にのみ変数を定義することができる。
        if (b is DerivedClassSample d)
        {
            Console.WriteLine("""b could downcast to DerivedClassSample with "type switch" feature""");
        }
        
    }

    public static void DownCastWithIs()
    {
        BaseClassSample b = new DerivedClassSample();

        if (b is DerivedClassSample)
        {
            Console.WriteLine("""b could downcast to DerivedClassSample with "is" statement""");
        }
        
    }

    public static void DownCastWithAs()
    {
        BaseClassSample b = new DerivedClassSample();
        DerivedClassSample? d = b as DerivedClassSample;
        if (d != null)
        {
            Console.WriteLine("""b could downcast to DerivedClassSample with "as" statement""");
        }
    }
}
