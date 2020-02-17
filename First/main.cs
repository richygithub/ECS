using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LECS;

namespace First
{
    public class main
    {
        static void Main()
        {
            Action[] actions = new Action[10];
            using( World w = new World() )
            { 
            }

            for (int i = 0; i < 10; i++)
            {
                int j = i;
                actions[i] = () =>
                {
                    Console.WriteLine(j);
                };
            }

            foreach (var action in actions)
            {
                action();
            }

        }
    }

}
