using System;
using System.Collections.Generic;
using System.Text;

namespace Oven
{
    /// <summary>
    /// This represents Food Item (bread, beagle etc..)
    /// </summary>
    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }
}
