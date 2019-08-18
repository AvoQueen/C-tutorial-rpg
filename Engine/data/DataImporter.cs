using System;
using System.Collections.Generic;

enum CurrentlyReadObject
{
    ITEM,
    WEAPON,
    POTION,
    NONE
}

namespace Engine
{
    public static class DataImporter
    {
        private static string[] LoadKaiFile(string filename)
        {
            // Get the file's text.
            string whole_file = System.IO.File.ReadAllText(filename);

            // Split into lines.
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            return lines;
        }

        public static void populateItemList(List<Item> itemList, string filename)
        {
            string[] lines = LoadKaiFile(filename);

            CurrentlyReadObject currentlyReadObject = CurrentlyReadObject.NONE;

            foreach(string line in lines)
            {
                switch (currentlyReadObject)
                {
                    case CurrentlyReadObject.ITEM:
                        break;
                    case CurrentlyReadObject.WEAPON:
                        break;
                    case CurrentlyReadObject.POTION:
                        break;
                    case CurrentlyReadObject.NONE:
                        currentlyReadObject = getNewObjectIdentifier(line);
                        break;
                }
            }
            
        }

        private static CurrentlyReadObject getNewObjectIdentifier(string line)
        {
            switch(line)
            {
                case "WEAPON:START":
                    return CurrentlyReadObject.WEAPON;
                case "ITEM:START":
                    return CurrentlyReadObject.ITEM;
                case "POTION:START":
                    return CurrentlyReadObject.POTION;
                default:
                    return CurrentlyReadObject.NONE;
            }
        }

        public static List<Enemy> LoadEnemiesFromKaiFile(string filename)
        {
            string[] lines = LoadKaiFile(filename);
            List<Enemy> enemies = new List<Enemy>();

            bool enemy_begin = false;
            bool loottable_begin = false;
            Enemy currentEnemy = null;

            foreach(string line in lines)
            {
                //Check if a new Enemy-Object begins
                if(!enemy_begin)
                {
                    if (line.Equals("ENEMY:START"))
                    {
                        enemy_begin = true;
                        currentEnemy = new Enemy(-1, "Unknown", 0, 0, 0, 0, 0);
                        continue;
                    }
                }
                else
                {
                    if (!loottable_begin)
                    {
                        if (line.Equals("LOOTTABLE:START"))
                        {
                            loottable_begin = true;
                            continue;
                        }
                    }
                    else
                    {
                        if (line.Equals("LOOTTABLE:END"))
                        {
                            loottable_begin = false;
                            continue;
                        }
                    }

                    if (line.Equals("ENEMY:END"))
                    {
                        enemy_begin = false;
                        enemies.Add(currentEnemy);
                        continue;
                    }
                }

                //Check if the current Enemy-Object ends
                

            }

            return enemies;

        }
    }
}
