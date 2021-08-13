using System;
using System.Collections.Generic;
using System.Text;

namespace Oven
{
    /// <summary>
    /// This is a slot in slot group that holds item to be cooked.
    /// </summary>
    public class Slot
    {

        public Item Item { get; private set; }

        public void AddItem(Item item)
        {
            Item = item;
        }

        public bool CanAddItem()
        {
            return !HasItem();
        }

        public bool HasItem()
        {
            return Item != null && !string.IsNullOrEmpty(Item.Name);
        }
    }
}
