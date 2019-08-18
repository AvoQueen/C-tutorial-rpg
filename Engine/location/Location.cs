using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Location : Identity
    {
        public Location(int id, string name, string description, Item itemRequiredToEnter = null,
            Quest questAvailablehere = null, Enemy enemyLivingHere = null) 
            : base(id, name, description)
        {
            ItemRequiredToEnter = itemRequiredToEnter;
            QuestAvailableHere = questAvailablehere;
            EnemyLivingHere = enemyLivingHere;
        }

        public Item ItemRequiredToEnter { get; set; }
        public Quest QuestAvailableHere { get; set; }
        public Enemy EnemyLivingHere { get; set; }
        public Location LocationToNorth { get; set; }
        public Location LocationToEast { get; set; }
        public Location LocationToSouth { get; set; }
        public Location LocationToWest { get; set; }
    }
}
