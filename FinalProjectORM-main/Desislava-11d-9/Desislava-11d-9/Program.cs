using Desislava_11d_9.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desislava_11d_9
{
    public class Program
    {
        static void Main(string[] args)
        {
      
            //Application.Run(form);
          
            Console.WriteLine("1 for console, 2 for worm");
            string start = Console.ReadLine();
            if (start == "2")
            {
                Form1 form = new Form1();
                Application.Run(form);
            }
            else
            {
                Display d = new Display();
                d.ShowMenu();
            }

        }
    }
}
