using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UlteriusFileSearch;

namespace TestFileSearch
{
    class Program
    {
        private static SearchService test;
        static void Main(string[] args)
        {
             test = new SearchService("test.bin");
           
                test.Configure();
            foreach (var file in test.Search("ulterius"))
            {
                Console.WriteLine(file);
            }
           
         
            Console.Read();
        }

       
    }
}
