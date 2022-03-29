using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timbervale
{
    class Inventory
    {
        const int HEADGEAR_INDEX = 0;
        const int CHESTPIECE_INDEX = 1;
        const int MAIN_HAND_INDEX = 2;
        const int OFF_HAND_INDEX = 3;
        const int LEGGINGS_INDEX = 4;

        private List<Item> equippedItems;
        private List<Item> unequippedItems;

        public Inventory() {
            equippedItems = new List<Item>();
            unequippedItems = new List<Item>();
        }

        public List<Item> EquippedItems { get => equippedItems; set => equippedItems = value; }
        public List<Item> UnequippedItems { get => unequippedItems; set => unequippedItems = value; }

        public void drop()
        {
            Console.WriteLine("Please enter the number of the item to be dropped. (The number beside the item in 'OTHER ITEMS')");
            int choice = -1;
            int.TryParse(Console.ReadLine(), out choice);
            choice--;
            if (unequippedItems[choice] != null)
            {
                if (confirmDrop(unequippedItems[choice].Name))
                {
                    unequippedItems.RemoveAt(choice);

                    Console.WriteLine("The item was successfully dropped.");
                }
                else
                {
                    Console.WriteLine("Item was not dropped.");
                }
            }
        }

        private bool confirmDrop(string itemName)
        {
            Console.WriteLine("Are you sure you want to drop " + itemName + "?");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void open()
        {
            bool valid = true;

            do
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("----------INVENTORY----------");
                Console.WriteLine("------------------------------\n");

                Console.WriteLine("--------EQUIPPED ITEMS--------");
                int loopCount = 0;
                foreach (Item item in equippedItems)
                {
                    loopCount++;
                    switch (loopCount)
                    {
                        case 1:
                            Console.WriteLine("HEADGEAR: " + EquippedItems[HEADGEAR_INDEX].Name);
                            break;
                        case 2:
                            Console.WriteLine("CHESTPIECE: " + EquippedItems[CHESTPIECE_INDEX].Name);
                            break;
                        case 3:
                            Console.WriteLine("MAIN-HAND: " + EquippedItems[MAIN_HAND_INDEX].Name);
                            break;
                        case 4:
                            if (EquippedItems[OFF_HAND_INDEX] != null)
                            {
                                Console.WriteLine("OFF-HAND: " + EquippedItems[OFF_HAND_INDEX].Name);
                            }
                            else
                            {
                                Console.WriteLine("OFF-HAND: None");
                            }
                            break;
                        case 5:
                            Console.WriteLine("LEGGINGS: " + EquippedItems[LEGGINGS_INDEX].Name);
                            break;
                    }

                    if (item != null)
                    {
                        Console.WriteLine("    STATS:");
                        foreach (KeyValuePair<string, int> kv in item)
                        {
                            if (kv.Key != null)
                            {
                                if (kv.Value > 0)
                                {
                                    Console.WriteLine("    " + kv.Key + " +" + kv.Value);
                                }
                                else if (kv.Value < 0)
                                {
                                    Console.WriteLine("    " + kv.Key + " " + kv.Value);
                                }
                            }
                        }
                    }

                }

                displayUnequippedItems();

                Console.WriteLine("1. Swap Gear\n2. Drop Unwanted Gear\n3. Return to Main Menu");
                int selection = -1;
                int.TryParse(Console.ReadLine(), out selection);

                switch (selection)
                {
                    case 1:
                        valid = true;
                        swap();
                        break;
                    case 2:
                        valid = true;
                        drop();
                        break;
                    case 3:
                        valid = true;
                        break;
                    default:
                        valid = false;
                        Console.WriteLine("Invalid Response. Press enter to continue.");
                        Console.ReadLine();
                        break;
                }
            } while(valid == false);
        }

        internal void displayUnequippedItems()
        {
            if (unequippedItems.Count != 0)
            {
                Console.WriteLine("\n--------UNEQUIPPED ITEMS--------");
                int count = 0;
                foreach (Item i in UnequippedItems)
                {
                    count++;
                    Console.WriteLine("---------------------------");
                    Console.WriteLine(count + ". Name: " + i.Name);
                    Console.WriteLine("   Item Type: " + i.ItemType);
                    Console.WriteLine("---------------------------");
                }

            }
            else
            {
                Console.WriteLine("You have no unequipped items.");
            }
        }

        private bool confirmSwap(string unEquippedItemName, string equippedItemName)
        {
            Console.WriteLine("Are you sure you want to replace your equipped " + equippedItemName + " with your " + unEquippedItemName + "? Y|N" );
            string result = Console.ReadLine().ToLower();

            if (result == "y")
            {
                return true;
            }
            else 
            {
                return false;
            }
            
        }

        private void executeSwap(int choice, int position)
        {
            Item temp = equippedItems[position];
            equippedItems[position] = unequippedItems[choice];
            unequippedItems[choice] = temp;
            Console.WriteLine("Items switched successfully.");
        }

        public void swap()
        {
            bool exceptionThrown = false;

            do
            {
                try
                {
                    Console.WriteLine("Please enter the number of the item you wish to swap in. (The number beside the item under 'UNEQUIPPED ITEMS')");
                    int choice = -1;
                    int.TryParse(Console.ReadLine(), out choice);
                    choice--;
                    if (unequippedItems[choice] != null)
                    {
                        if (unequippedItems[choice].ItemType == "Headgear")
                        {
                            if (confirmSwap(unequippedItems[choice].Name, equippedItems[HEADGEAR_INDEX].Name))
                            {
                                executeSwap(choice, HEADGEAR_INDEX);
                            }
                            else
                            {
                                Console.WriteLine("Items were not switched.");
                            }
                        }
                        else if (unequippedItems[choice].ItemType == "Chestpiece")
                        {
                            if (confirmSwap(unequippedItems[choice].Name, equippedItems[CHESTPIECE_INDEX].Name))
                            {
                                executeSwap(choice, CHESTPIECE_INDEX);
                            }
                            else
                            {
                                Console.WriteLine("Items were not switched.");
                            }
                        }

                        else if (unequippedItems[choice].ItemType == "Sword" || unequippedItems[choice].ItemType == "Staff" || unequippedItems[choice].ItemType == "Dagger" || unequippedItems[choice].ItemType == "Bow")
                        {
                            if (confirmSwap(unequippedItems[choice].Name, equippedItems[MAIN_HAND_INDEX].Name))
                            {
                                executeSwap(choice, MAIN_HAND_INDEX);
                            }
                            else
                            {
                                Console.WriteLine("Items were not switched.");
                            }
                        }

                        else if (unequippedItems[choice].ItemType == "Shield" || unequippedItems[choice].ItemType == "Book")
                        {
                            if (confirmSwap(unequippedItems[choice].Name, equippedItems[OFF_HAND_INDEX].Name))
                            {
                                executeSwap(choice, OFF_HAND_INDEX);
                            }
                            else
                            {
                                Console.WriteLine("Items were not switched.");
                            }
                        }

                        else if (unequippedItems[choice].ItemType == "Leggings")
                        {
                            if (confirmSwap(unequippedItems[choice].Name, equippedItems[LEGGINGS_INDEX].Name))
                            {
                                executeSwap(choice, LEGGINGS_INDEX);
                            }
                            else
                            {
                                Console.WriteLine("Items were not switched.");
                            }
                        }

                    }
                    exceptionThrown = false;
                }
                catch (Exception ex)
                {
                    exceptionThrown = true;
                    Console.WriteLine("Invalid Response. Press enter to continue");
                    Console.ReadLine();
                }
            } while(exceptionThrown == true);
        }

    }
}
