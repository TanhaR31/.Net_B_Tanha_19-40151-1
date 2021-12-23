using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = ProductService.GetNames();
            Console.WriteLine("3 Tier Project");
        }
    }
}
