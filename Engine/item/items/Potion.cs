using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Potion : Item
    {
        public Potion(int id, string name, string namePlural, string description, int amountToHeal) 
            : base(id, name, namePlural, description)
        {
            AmountToHeal = amountToHeal;
        }
        //If the amount is negative the potion will deal damage
        public int AmountToHeal { get; set; }
    }
}
