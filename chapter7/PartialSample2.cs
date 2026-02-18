using System;

namespace chapter7;

partial class PartialClass
{
    public void NormalMethod()
    {
        Console.WriteLine("This is normal method to call old style partial method");
        OldStylePartialDefinedMethod();
    }

    public partial int NewStylePartialDefinedMethod(out int a)
    {
        a = 100;
        return 500;
    }
}

public class PartialSample2
{

}
