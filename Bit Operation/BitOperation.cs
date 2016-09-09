using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_Operation
{
    class BitOperation
    {
        static void Main(string[] args)
        {
            int x = 0x00000F01;

            //二进制数在C#中无法直接表示，所以所有二进制数都用一个字符串来表示
            //十进制转二进制字符串: 111100000001

            
            //The shift operators move all the binary digits left or right
            //by one position. A left shift sets the bottom digit to 0. Right shifts of unsigned integers
            //set the top digit with 0, and right shifts of signed integers leave the top digit as it is (i.e.,
            //negative numbers remain negative because they keep their top bit set, while positive
            //numbers keep their top bit as 0, so they also retain their sign).

            shiftLeftPositive(x);

            shiftRightPositive(x);

            shiftRightNegative();

            Console.ReadKey();

            // -30.5 * 10 = -305 -> 111111111111111111111111111111111111111111111111 11111110 11001111
            Console.WriteLine("-30.5° 验证，Press any key to continue...");
            Console.ReadKey();
            string strX = "11111110";
            string strY = "11001111";
            exercise(strX, strY);

            Console.ReadKey();
            //30.5 * 10 = 305 -> 1 00110001
            Console.WriteLine("30.5° 验证，Press any key to continue...");
            exercise("00000001", "00110001");
            Console.ReadKey();
        }

        private static void shiftRightNegative()
        {
            int y = -15;

            int shiftRight = y >> 1;

            Console.WriteLine("y二进制表示 : " + Convert.ToString(y, 2));
            Console.WriteLine("负数右移1位 : {0}", Convert.ToString(shiftRight, 2));
        }

        private static void shiftRightPositive(int x)
        {
            int shiftRight = x >> 1;

            int shiftRight12 = x >> 12;

            Console.WriteLine("正数右移1位 : {0}", Convert.ToString(shiftRight, 2).PadLeft(32, '0'));
            Console.WriteLine("右移12位    : {0}", Convert.ToString(shiftRight12, 2).PadLeft(32, '0'));

            Console.WriteLine();
            
        }

        private static void shiftLeftPositive(int x)
        {
            int shiftLeft = x << 1;

            string strShiftleft = Convert.ToString(shiftLeft, 2);

            int shiftLeft20 = x << 20;
            string strShiftLeft20 = Convert.ToString(shiftLeft20, 2);

            Console.WriteLine("x 二进制表示：" + Convert.ToString(x, 2).PadLeft(32, '0'));//32位，位数不够用'0'在左侧填充字符串);
            Console.WriteLine("左移1 位    : {0}", strShiftleft.PadLeft(32, '0'));
            Console.WriteLine("左移20位    : {0}", strShiftLeft20.PadLeft(32, '0'));
            Console.WriteLine();
        }

        private static void exercise(string strX, string strY)
        {
            // -30.5 * 10 = -305 -> 111111111111111111111111111111111111111111111111 11111110 11001111
            //string strX = "11111110";
            //string strY = "11001111";
            int x = Convert.ToInt32(strX,2);
            int y = Convert.ToInt32(strY, 2);

            int m = x << 25 >> 17 | y;
            Console.WriteLine("当前温度表示：{0}", m);

            Console.WriteLine("x 二进制表示：" + Convert.ToString(x, 2).PadLeft(32, '0'));
            Console.WriteLine("y 二进制表示：" + Convert.ToString(y, 2).PadLeft(32, '0'));

            int tempX = x << 25;
            Console.WriteLine("左移25位表示：" + Convert.ToString(tempX, 2).PadLeft(32, '0'));

            tempX = tempX >> 17;
            Console.WriteLine("右移17位表示：" + Convert.ToString(tempX, 2).PadLeft(32, '0'));

            int tempReal = tempX | y;

            Console.WriteLine("当前温度表示：{0} 十进制：{1}", Convert.ToString(tempReal, 2).PadLeft(32, '0'), tempReal);

            
        }

    }
}
