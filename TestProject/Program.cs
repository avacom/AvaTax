using AvaTax.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration c = new Configuration();
            c.Load("1.xml");
            c.Name = "Andriy";
            NACE n1 = new NACE("61.1", "Comp prog");
            NACE n2 = new NACE("61.2", "WEB");
            c.NACEs.Add(n1);
            c.NACEs.Add(n2);
            c.Save("1.xml");
        }
    }
}
