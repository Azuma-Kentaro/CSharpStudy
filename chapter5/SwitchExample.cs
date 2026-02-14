using System;

namespace chapter5;

public class SwitchExample
{
    public static void SwitchStatementExample()
    {
        int month = DateTime.Now.Month;

        switch (month)
        {
            case 1:
                Console.WriteLine("睦月");
                break;
            case 2:
                Console.WriteLine("如月");
                break;
            case 3:
                Console.WriteLine("弥生");
                break;
            case 7:
            case 8:
                Console.WriteLine("夏休み");
                break;
            default:
                Console.WriteLine($"{month}月");
                break;
        }
    }

    public static void SwitchStatementWithWhenExample()
    {
        //int month = DateTime.Now.Month;
        int month = 1;
        bool japanese = true;
        //bool japanese = false;

        switch (month)
        {
            case 1 when japanese:
                Console.WriteLine("睦月");
                break;
            default:
                Console.WriteLine($"{month}月");
                break;
        }
    }

    public static void SwitchExpressionWithWhenExample()
    {
        //int month = DateTime.Now.Month;
        int month = 1;
        bool japanese = true;
        //bool japanese = false;

        var str = month switch
        {
            1 when japanese => "睦月",
            2 => "如月",
            3 when japanese => "弥生",
            _ => month + "月"
        };

        Console.WriteLine(str);
    }
}
