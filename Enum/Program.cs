using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    //枚举类型的基类型是除 Char 外的任何整型，所以枚举类型的值是整型值
    enum Colors
    {
        Unknown,
        Red,
        Green,
        Blue
    }


    class Program
    {
        static void Main(string[] args)
        {
            EnumToStringTest(Colors.Red);

            Colors color = StringToEnum("Green");

            color = StringToEnum("Invalid");
            Console.WriteLine(color.ToString());

            IntToEnumTest(2);

            IntToEnumTest(4);

            Styles style = BitEnumClass.SetStyles();
            BitEnumClass.ShowWindowsStyle(style);

            Console.ReadKey();
        }

        public static void EnumToStringTest(Colors c)
        {
            switch (c)
            {
                case Colors.Red:
                    Console.WriteLine("输入为red");
                    break;
                case Colors.Green:
                    break;
                case Colors.Blue:
                    break;
                default:
                    break;
            }

            Console.WriteLine(c.ToString());
        }

        /*String-->Enum
 
        (1)利用Enum的静态方法Parse：
         * */
        public static Colors StringToEnum(string value)
        {
            if (Enum.IsDefined(typeof(Colors),value))
            return (Colors)Enum.Parse(typeof(Colors), value);

            return Colors.Unknown;
        }

        /*(1)可以强制转换将整型转换成枚举类型。

        例如：Colors color = (Colors)2 ，那么color即为Colors.Blue

        (2)利用Enum的静态方法ToObject。

        public static Object ToObject(Type enumType,int value)

        例如：Colors color = (Colors)Enum.ToObject(typeof(Colors), 2)，那么color即为Colors.Blue

        判断某个整型是否定义在枚举中的方法：Enum.IsDefined

        public static bool IsDefined(Type enumType,Object value)

        例如：Enum.IsDefined(typeof(Colors), n))
         * */
        /// <summary>
        /// Int-->Enum
        /// </summary>
        /// <param name="c"></param>
        public static void IntToEnumTest(int c)
        {

            if (Enum.IsDefined(typeof(Colors), c))
            {
                Colors color = (Colors)Enum.ToObject(typeof(Colors), c);
                Console.WriteLine(color.ToString());
            }
            else
            {
                Console.WriteLine("无效的参数 {0}", c);
            }
        }
    }

    #region Bit Enum
    [Flags]
    enum Styles
    {
        // Explicitly assign values.
        ShowBorder = 1,         //是否显示边框
        ShowCaption = 2,        //是否显示标题
        ShowToolbox = 4         //是否显示工具箱
    }

    class BitEnumClass
    {
        public static Styles SetStyles()//显示边框和标题
        {
            return Styles.ShowBorder | Styles.ShowCaption;
        }
        public static void ShowWindowsStyle(Styles s)
        {
            if ((s & Styles.ShowBorder) != 0)
            {
                Console.WriteLine("ShowBorder");
            }
            if ((s & Styles.ShowCaption) != 0)
            {
                Console.WriteLine("ShowCaption");
            }
        }
    }
    #endregion

}
