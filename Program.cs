using Apache.Ignite.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testIgnite
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CacheUtils.startCache();

            Console.ReadKey();
        }
    }
}
