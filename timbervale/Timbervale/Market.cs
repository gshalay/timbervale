using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timbervale
{
    //TODO: Implement the following:
          //Purchase Item from the market
          //Sell item to the market.

    class Market
    {
        private List<Item> stock;
        private string merchantName;
        private string merchantGreeting;
        private string merchantThank;
        private string merchantFarewell;

        public Market(List<Item> stock, string merchantName, string merchantGreeting, string merchantThank, string merchantFarewell)
        {
            this.stock = stock;
            this.merchantName = merchantName;
            this.merchantGreeting = merchantGreeting;
            this.merchantThank = merchantThank;
            this.merchantFarewell = merchantFarewell;
        }

        public string MerchantName { get => merchantName; set => merchantName = value; }
        public string MerchantGreeting { get => merchantGreeting; set => merchantGreeting = value; }
        public string MerchantThank { get => merchantThank; set => merchantThank = value; }
        public string MerchantFarewell { get => merchantFarewell; set => merchantFarewell = value; }
        internal List<Item> Stock { get => stock; set => stock = value; }

        public void load()
        {
            bool exit = false;

            Console.WriteLine("--------------------------");
            Console.WriteLine("----------MARKET----------");
            Console.WriteLine("--------------------------");

            Console.WriteLine(merchantName + ": " + merchantGreeting);
            do
            {
                Console.WriteLine("----------STOCK-----------");

                int count = 1;
                foreach (Item i in stock)
                {
                    Console.WriteLine("------------ " + count + " -------------");
                    Console.WriteLine(count + ".     Name: " + i.Name);
                    Console.WriteLine("     Type: " + i.ItemType);
                    Console.WriteLine("     Description: " + i.Description);
                    Console.WriteLine("     Cost: " + i.PurchasePrice + " Coins");
                    Console.WriteLine("-------------------------");
                    count++;
                }

                displayPlayerCoinBalance();
                
                Console.WriteLine("1. Buy Items\n2. Sell Items\n3. Exit Market");
                int choice = -1;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please enter the corresponding number of the item you wish to purchase (Number in the header):");
                        int position = -1;
                        int.TryParse(Console.ReadLine(), out position);
                        position--; //To get the actual index of the item. (e.g. the display number for index 0 would be 1).
                        buy(stock[position], position);
                        break;
                    case 2:
                        if (Program.isArcherChosen)
                        {
                            Program.archer.Inventory.displayUnequippedItems();
                            Console.WriteLine("Please enter the corresponding number of the item you wish to sell (number beside the item):");
                            Console.WriteLine("***NOTE: Only Unequipped items may be sold.***");
                            int itemPos = -1;
                            int.TryParse(Console.ReadLine(), out itemPos);
                            itemPos--; // Again, to get the actual index.
                            sell(Program.archer.Inventory.UnequippedItems[itemPos], itemPos);
                        }
                        else if (Program.isAssassinChosen)
                        {
                            Program.assassin.Inventory.displayUnequippedItems();
                            Console.WriteLine("Please enter the corresponding number of the item you wish to sell (number beside the item):");
                            Console.WriteLine("***NOTE: Only Unequipped items may be sold.***");
                            int itemPos = -1;
                            int.TryParse(Console.ReadLine(), out itemPos);
                            itemPos--; 
                            sell(Program.assassin.Inventory.UnequippedItems[itemPos], itemPos);
                        }
                        else if (Program.isPaladinChosen)
                        {
                            Program.paladin.Inventory.displayUnequippedItems();
                            Console.WriteLine("Please enter the corresponding number of the item you wish to sell (number beside the item):");
                            Console.WriteLine("***NOTE: Only Unequipped items may be sold.***");
                            int itemPos = -1;
                            int.TryParse(Console.ReadLine(), out itemPos);
                            itemPos--; 
                            sell(Program.paladin.Inventory.UnequippedItems[itemPos], itemPos);
                        }
                        else if (Program.isWizardChosen)
                        {
                            Program.wizard.Inventory.displayUnequippedItems();
                            Console.WriteLine("Please enter the corresponding number of the item you wish to sell (number beside the item):");
                            Console.WriteLine("***NOTE: Only Unequipped items may be sold.***");
                            int itemPos = -1;
                            int.TryParse(Console.ReadLine(), out itemPos);
                            itemPos--; // Again, to get the actual index.
                            sell(Program.wizard.Inventory.UnequippedItems[itemPos], itemPos);
                        }
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        break;
                }
            } while (exit == false);
        }

        private void displayPlayerCoinBalance()
        {
            if (Program.isArcherChosen)
            {
                Console.WriteLine("Coin Balance: " + Program.archer.NumOfCoins);
            }
            else if (Program.isAssassinChosen)
            {
                Console.WriteLine("Coin Balance: " + Program.assassin.NumOfCoins);
            }
            else if (Program.isPaladinChosen)
            {
                Console.WriteLine("Coin Balance: " + Program.paladin.NumOfCoins);
            }
            else if (Program.isWizardChosen)
            {
                Console.WriteLine("Coin Balance: " + Program.wizard.NumOfCoins);
            }
        }

        private bool checkCoinBalance(int purchasePrice, int coinBalance)
        {
            if (purchasePrice > coinBalance)
            {
                Console.WriteLine("Sorry, you don't have enough coins to purchase that.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool confirmPurchase(Item desiredItem)
        {
            Console.WriteLine("You want to purchase " + desiredItem.Name + " for " + desiredItem.PurchasePrice + " coins? Y|N");
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


        private void buy(Item desiredItem, int position)
        {
            if (confirmPurchase(desiredItem))
            {
                if (Program.isArcherChosen)
                {
                    if (checkCoinBalance(desiredItem.PurchasePrice, Program.archer.NumOfCoins))
                    {
                        Program.archer.NumOfCoins -= desiredItem.PurchasePrice;
                        Program.archer.Inventory.UnequippedItems.Add(stock[position]);
                        stock.RemoveAt(position);
                        Console.WriteLine(desiredItem.Name + " was purchased for " + desiredItem.PurchasePrice + " coins. Press any key to continue.");
                        Console.ReadLine();
                    }
                }
                else if (Program.isAssassinChosen)
                {
                    if (checkCoinBalance(desiredItem.PurchasePrice, Program.assassin.NumOfCoins))
                    {
                        Program.assassin.NumOfCoins -= desiredItem.PurchasePrice;
                        Program.assassin.Inventory.UnequippedItems.Add(stock[position]);
                        stock.RemoveAt(position);
                        Console.WriteLine(desiredItem.Name + " was purchased for " + desiredItem.PurchasePrice + " coins. Press any key to continue.");
                        Console.ReadLine();
                    }
                }
                else if (Program.isPaladinChosen)
                {
                    if (checkCoinBalance(desiredItem.PurchasePrice, Program.paladin.NumOfCoins))
                    {
                        Program.paladin.NumOfCoins -= desiredItem.PurchasePrice;
                        Program.paladin.Inventory.UnequippedItems.Add(stock[position]);
                        stock.RemoveAt(position);
                        Console.WriteLine(desiredItem.Name + " was purchased for " + desiredItem.PurchasePrice + " coins. Press any key to continue.");
                        Console.ReadLine();
                    }
                }
                else if (Program.isWizardChosen)
                {
                    if (checkCoinBalance(desiredItem.PurchasePrice, Program.wizard.NumOfCoins))
                    {
                        Program.wizard.NumOfCoins -= desiredItem.PurchasePrice;
                        Program.wizard.Inventory.UnequippedItems.Add(stock[position]);
                        stock.RemoveAt(position);
                        Console.WriteLine(desiredItem.Name + " was purchased for " + desiredItem.PurchasePrice + " coins. Press any key to continue.");
                        Console.ReadLine();
                    }
                }
            }
        }

        private bool confirmSale(Item item)
        {
            Console.WriteLine("Are you sure you want to sell " + item.Name + " for " + item.SellPrice + " coins? Y|N");
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

        private void sell(Item unwantedItem, int itemPosition)
        {
            if (confirmSale(unwantedItem))
            {
                if (Program.isArcherChosen)
                {
                    Program.archer.Inventory.UnequippedItems.RemoveAt(itemPosition);
                    Program.archer.NumOfCoins += unwantedItem.SellPrice;
                    Console.WriteLine(unwantedItem.Name + " sold for " + unwantedItem.SellPrice + " coins. Press any key to continue.");
                    Console.ReadLine();
                }
                else if (Program.isAssassinChosen)
                {
                    Program.assassin.Inventory.UnequippedItems.RemoveAt(itemPosition);
                    Program.assassin.NumOfCoins += unwantedItem.SellPrice;
                    Console.WriteLine(unwantedItem.Name + " sold for " + unwantedItem.SellPrice + " coins. Press any key to continue.");
                    Console.ReadLine();
                }
                else if (Program.isPaladinChosen)
                {
                    Program.paladin.Inventory.UnequippedItems.RemoveAt(itemPosition);
                    Program.paladin.NumOfCoins += unwantedItem.SellPrice;
                    Console.WriteLine(unwantedItem.Name + " sold for " + unwantedItem.SellPrice + " coins. Press any key to continue.");
                    Console.ReadLine();
                }
                else if (Program.isWizardChosen)
                {
                    Program.wizard.Inventory.UnequippedItems.RemoveAt(itemPosition);
                    Program.wizard.NumOfCoins += unwantedItem.SellPrice;
                    Console.WriteLine(unwantedItem.Name + " sold for " + unwantedItem.SellPrice + " coins. Press any key to continue.");
                    Console.ReadLine();
                }
            }

        }
    }
}
