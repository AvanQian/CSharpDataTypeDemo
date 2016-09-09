using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct_vs_Class
{
    struct myStruct
    {
       public int x;
       public int y;

      //  int z = 10; //Error	: cannot have instance field initializers in structs

      //  public myStruct() //Field 'Struct_vs_Class.myStruct.x' must be fully assigned before control is returned to the caller
      //  { }

       //public myStruct(int aInt) //Error	13	Field 'Struct_vs_Class.myStruct.y' must be fully assigned before control is returned to the caller
       //{    
       //     x = aInt; 
       //}

       // ~myStruct() //Error	12	Only class types can contain destructors
       // {
       //     Console.WriteLine("~myStruct is called");
       // }
    }

    class myClass
    {
        public int x;
        int y;

        public myClass()
        { }

         public myClass( int aInt ) 
         {    
            x = aInt; 
         }

        ~myClass()
        {
            Console.WriteLine("~myClass is called");
        }
    }

    class StructAndClass
    {
        static void Main(string[] args)
        {
            myClass classInstance = null; // No error.

         //   myStruct structInstance = null; // Error [ Cannot convert null because it is a value type ].

            classInstance = new myClass();
            classInstance.x = 100;
             
            myStruct structInstance;
            structInstance.x = 100;
            structInstance.y = 200;

            myStruct structInstance2 = structInstance;
            structInstance2.x = 0;

            Console.WriteLine("structInstance.x = {0} ", structInstance.x);
            //Output: structInstance.x = 100

            structInstance2 = new myStruct();
            Console.WriteLine("structInstance2.x = {0} structInstance2.y = {1}", structInstance2.x, structInstance2.y);
            //Output: structInstance2.x = 0 structInstance2.y = 0

            IList<myClass> listClass = new List<myClass>();
            listClass.Add(new myClass());

            listClass[0].x = 10;

            IList<myStruct> listStruct = new List<myStruct>();
            listStruct.Add(new myStruct());

           // listStruct[0].x = 10; //Error	14	Cannot modify the return value of 'System.Collections.Generic.IList<Struct_vs_Class.myStruct>.this[int]' because it is not a variable

            
            Console.ReadKey();
        }
    }
}
