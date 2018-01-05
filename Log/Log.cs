using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
     public class Logger
    {
         public  Logger(){
         }
        static public void Debug(object message) { 
            Console.WriteLine("[debug] = "+ message.ToString());
        }
    }
}
