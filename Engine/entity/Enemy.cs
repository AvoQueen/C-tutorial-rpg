using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Enemy : Entity
    {
        public Enemy(int id, string name, int damage, int rewardExP,
            int rewardGold, int currentHP, int maximumHP) 
            : base(id, name, currentHP, maximumHP)
        {
            Damage = damage;
            RewardExP = rewardExP;
            RewardGold = rewardGold;
            LootTable = new List<LootItem>();
        }
        public int RewardGold { get; set; }
        public int RewardExP { get; set; }
        public List<LootItem> LootTable { get; set; }
    }
}
