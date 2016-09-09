using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDemo
{
    class Program
    {
        static void StrChange(string str)
        {
            str = "hello";
        }

        static void Main(string[] args)
        {
            ////隐式转换：系统默认的，不需声明就能进行的转换
            //short x = 5;
            //int y = x;//隐式转换

            //// 显示转换：也称强制类型转换，需要在代码中明确要转换的类型，可能会导致信息丢失。  
            //short m = 0;
            //int n = 500;
            //m = n;//不能编译 该为m = (short)n可以编译


            string str3 = "123";//申明一个字符串    
            StrChange(str3);//调用方法  
            Console.WriteLine(str3);//输出字符串


            string str = "aaa";
            string str1 = str;
            str = "bbb";//注释掉此名就"yes",否则"no".这就说明str重新赋值的时候,             
            //其实是重新创建了一个名为str的字符串(内存中指向的位置是不同的),先前             
            //的那个str你就再也看不到了. 

            string str2 = str;
            if (object.ReferenceEquals(str1, str2))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }



            Console.ReadKey();
        }

    }
}
