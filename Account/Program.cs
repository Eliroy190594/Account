using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Collections;

namespace Account
{
    class Program
    {
        static void Main(string[] args)
        {
            MainProgram m = new MainProgram();
            m.DoQuery();
            
            // from github test
            //Console.Read();
        }
    }
}
