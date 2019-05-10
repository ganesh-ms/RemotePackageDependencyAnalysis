using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nsTwo;
namespace nsOne
{
    public class classOne
    {
        static void functionOne()
        {
            Console.Write("\n  tOneFunction:\n  ");
            for(int i =0; i <=10; i++)
            {
                Console.Write(" {0}", i);
            }
            classTwo c2 = new classTwo();
        }
    }
}
