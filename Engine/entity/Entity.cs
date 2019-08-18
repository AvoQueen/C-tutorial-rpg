using System;

namespace Engine
{
    public class Entity : Identity
    {
        public static readonly string GENERIC_ENTITY_DESCRIPTION = "A 'living' creature.";

        public Entity(int id, string name, string description, int currentHP, int maximumHP) 
            : base(id, name, description)
        {
            Damage = 0;
            CurrentHP = currentHP;
            MaximumHP = maximumHP;
        }

        public Entity(int id, string name, int currentHP, int maximumHP)
            : base(id, name, GENERIC_ENTITY_DESCRIPTION)
        {
            Damage = 0;
            CurrentHP = currentHP;
            MaximumHP = maximumHP;
        }

        public int CurrentHP { get; set; }
        public int MaximumHP { get; set; }
        public int Damage { get; set; }
  
    }
}
