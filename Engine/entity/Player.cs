using System;
using System.Collections.Generic;
using System.Text;


namespace Engine
{

    public class Player : Entity
    {
        public static readonly int PLAYER_ID = 0;
        public static readonly string PLAYER_NAME = "AvoLord";
        public static readonly string PLAYER_DESCRIPTION = "The bravest of all the heroes!";

        public Player(int currentHP, int maximumHP, int gold, int exP, int level) 
            : base(PLAYER_ID, PLAYER_NAME, PLAYER_DESCRIPTION, currentHP, maximumHP)
        {
            Gold = gold;
            ExP = exP;
            Level = level;

            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }
        public int Gold { get; set; }
        public int ExP { get; set; }
        public int Level { get; set; }

        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
        public Location CurrentLocation { get; set; }







        public bool HasRequiredItemToEnterLocation(Location location)
        {
            if(location.ItemRequiredToEnter != null)
            {
                foreach(InventoryItem ii in Inventory)
                {
                    if(ii.Details.ID == location.ItemRequiredToEnter.ID)
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }

        public bool HasThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsCompleted;
                }
            }

            return false;
        }

        public bool HasAllItemsToCompleteQuest(Quest quest)
        {

            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                bool foundItemInPlayersInventory = false;
                // Check each item in the player's inventory, to see if they have it, and enough of it
                foreach (InventoryItem ii in Inventory)
                {
                    // The player has this item in their inventory
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        foundItemInPlayersInventory = true;
                        if (ii.Quantity < qci.Quantity)
                        {
                            return false;
                        }
                    }
                }
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }
            return true;
        }

        public void removeQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        // Subtract the quantity from the player's inventory that was needed to complete the quest
                        ii.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }

        public void RemoveQuest(Quest quest)
        {
            foreach(PlayerQuest pq in Quests)
            {
                if(pq.Details.ID == quest.ID)
                {
                    Quests.Remove(pq);
                    break;
                }
            }
        }

        public void AddItemToInventory(Item item)
        {
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == item.ID)
                {
                    // They have the item in their inventory, so increase the quantity by one
                    ii.Quantity++;

                    return; // We added the item, and are done, so get out of this function
                }
            }

            // They didn't have the item, so add it to their inventory, with a quantity of 1
            Inventory.Add(new InventoryItem(item, 1));
        }

        public void MarkQuestCompleted(Quest quest)
        {
            foreach (PlayerQuest pq in Quests)
            {
                if (pq.Details.ID == quest.ID)
                {
                    // Mark it as completed
                    pq.IsCompleted = true;

                    return; // We found the quest, and marked it complete, so get out of this function
                }
            }
        }
    }
}
