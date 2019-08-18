using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    

    public class Item : Identity
    {
        public static readonly string GENERIC_ITEM_DESCRIPTION = "An item.";

        public Item(int id, string name, string namePlural, string description) 
            : base(id, name, namePlural, description)
        {
            DealsDamage = false;
        }

        public Item(int id, string name, string namePlural) 
            : base(id, name, namePlural, GENERIC_ITEM_DESCRIPTION)
        {
            DealsDamage = false;
        }

        public Item(int id, string name) 
            : base(id, name, GENERIC_ITEM_DESCRIPTION)
        {
            DealsDamage = false;
        }

        public bool DealsDamage { get; set; }
    }
}
