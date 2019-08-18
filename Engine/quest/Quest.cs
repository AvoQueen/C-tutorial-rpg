using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Quest : Identity
    {
        public Quest(int id, string name, string description, int rewardExP, int rewardGold, Item rewardItem = null) 
            : base(id, name, description)
        {
            RewardExP = rewardExP;
            RewardGold = rewardGold;
            QuestCompletionItems = new List<QuestCompletionItem>();
        }

        public int RewardExP { get; set; }
        public int RewardGold { get; set; }
        public Item RewardItem { get; set; }
        public List<QuestCompletionItem> QuestCompletionItems { get; set; }
    }
}
