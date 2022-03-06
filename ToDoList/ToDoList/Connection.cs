using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Connection
    {
        public string Adress = System.IO.File.ReadAllText(@"C:\ToDoList.txt");
    }
}
