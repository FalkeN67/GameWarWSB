using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWarWSB
{
    public class Potion : IItem
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public Potion(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
