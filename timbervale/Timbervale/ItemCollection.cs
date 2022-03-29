using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timbervale
{
    public static class ItemCollection
    {

        internal static Item beginnerHelm = new Item("Beginner Helm", "The most basic helm.", "Headgear", "Common", "", new KeyValuePair<string, int>("defense", 1), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), 5, 15);
        internal static Item beginnerChest = new Item("Beginner Chestpiece", "The most basic chestpiece.", "Chestpiece", "Common", "", new KeyValuePair<string, int>("defense", 1), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), 5, 15);
        internal static Item beginnerLeggings = new Item("Beginner Leggings", "The most basic leggings.", "Leggings", "Common", "", new KeyValuePair<string, int>("defense", 1), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), 5, 15);
        internal static Item beginnerSword = new Item("Beginner Sword", "The most basic sword.", "Sword", "Common", "", new KeyValuePair<string, int>("attack", 1), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), 5, 15);
        internal static Item beginnerShield = new Item("Beginner Shield", "The most basic shield.", "Shield", "Common", "", new KeyValuePair<string, int>("defense", 1), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), 5, 15);
        internal static Item beginnerBow = new Item("Beginner Bow", "The most basic bow.", "Bow", "Common", "", new KeyValuePair<string, int>("defense", 1), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>("speed", -3), new KeyValuePair<string, int>("attack", -3), new KeyValuePair<string, int>("defense", -2), 5, 15);
        internal static Item beginnerDagger = new Item("Beginner Dagger", "The most basic dagger.", "Dagger", "Common", "", new KeyValuePair<string, int>("defense", 1), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), 5, 15);
        internal static Item beginnerStaff = new Item("Beginner Staff", "The most basic staff.", "Staff", "Common", "", new KeyValuePair<string, int>("defense", 1), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), 5, 15);
        internal static Item worldflame = new Item("Worldflame", "An intimidating-looking sword. Flames engulf the blade.", "Sword", "Common", "This sword was weilded by the God of Ruin. It has lain seige to entire races.", new KeyValuePair<string, int>("defense", 4), new KeyValuePair<string, int>("attack", 30), new KeyValuePair<string, int>("speed", 18), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), new KeyValuePair<string, int>(null, 0), 5, 15);
    }
}
