/****************************************************************
 *  File Name: Item.cs 
 *  Description: Class that defines an object that can be equipped by a Player or an Enemy.
 *    History:
 *     Date: 5/3/2017 - Created
 *     ---------- ---------- ----------------------------
 *  Author: Greg Shalay 5/3/2017 - Created
 *
 * Copyright (c) Greg Shalay, 2017
 *
 * This unpublished material  along with it's Intellectual Property belongs to Greg Shalay.
 * All rights reserved. The methods and
 * techniques described herein are considered trade secrets
 * and/or confidential. Reproduction or distribution, in whole
 * or in part, is forbidden except by express written permission
 * of Greg Shalay.
 ****************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timbervale
{
    class Item : IEnumerable
    {
        private string name;
        private string description;
        private string itemType;
        private string title;
        private int requiredLevel = 1;
        private string rarity;
        private string flavour;
        private KeyValuePair<string, int> buff1;
        private KeyValuePair<string, int> buff2;
        private KeyValuePair<string, int> buff3;
        private KeyValuePair<string, int> debuff1;
        private KeyValuePair<string, int> debuff2;
        private KeyValuePair<string, int> debuff3;
        private int sellPrice;
        private int purchasePrice;
        private List<KeyValuePair<string, int>> statEffects;

        #region Properties
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string ItemType { get => itemType; set => itemType = value; }
        public string Title { get => title; set => title = value; }
        public int RequiredLevel { get => requiredLevel; set => requiredLevel = value; }
        public string Rarity { get => rarity; set => rarity = value; }
        public string Flavour { get => flavour; set => flavour = value; }
        public KeyValuePair<string, int> Buff1 { get => buff1; set => buff1 = value; }
        public KeyValuePair<string, int> Buff2 { get => buff2; set => buff2 = value; }
        public KeyValuePair<string, int> Buff3 { get => buff3; set => buff3 = value; }
        public KeyValuePair<string, int> Debuff1 { get => debuff1; set => debuff1 = value; }
        public KeyValuePair<string, int> Debuff2 { get => debuff2; set => debuff2 = value; }
        public KeyValuePair<string, int> Debuff3 { get => debuff3; set => debuff3 = value; }
        public int SellPrice { get => sellPrice; set => sellPrice = value; }
        public int PurchasePrice { get => purchasePrice; set => purchasePrice = value; } 
        #endregion

        public Item()
        {
            this.name = "Test";
            this.description = "A test item.";
            this.itemType = "Weapon";
            this.rarity = "Uncommon";
            this.flavour = "Only the truest can wield 'test'.";
            this.buff1 = new KeyValuePair<string, int>("attack", 1);
            this.buff2 = new KeyValuePair<string, int>("speed", 2);
            this.buff3 = new KeyValuePair<string, int>("intellect", 1);
            this.debuff1 = new KeyValuePair<string, int>("defense", -4);
            this.debuff2 = new KeyValuePair<string, int>("attack", -2);
            this.debuff3 = new KeyValuePair<string, int>("stamina", -3);
            this.sellPrice = 3;
            this.purchasePrice = 1111;
        }

        public Item(string name, string description, string itemType, string rarity, string flavour, KeyValuePair<string, int> buff1, KeyValuePair<string, int> buff2, KeyValuePair<string, int> buff3,
            KeyValuePair<string, int> debuff1, KeyValuePair<string, int> debuff2, KeyValuePair<string, int> debuff3, int sellPrice, int purchasePrice)
        {
            this.name = name;
            this.description = description;
            this.itemType = itemType;
            this.rarity = rarity;
            this.flavour = flavour;
            this.buff1 = buff1;
            this.buff2 = buff2;
            this.buff3 = buff3;
            this.debuff1 = debuff1;
            this.debuff2 = debuff2;
            this.debuff3 = debuff3;
            this.sellPrice = sellPrice;
            this.purchasePrice = purchasePrice;
            statEffects = new List<KeyValuePair<string, int>>();

            statEffects.Add(buff1);
            statEffects.Add(buff2);
            statEffects.Add(buff3);
            statEffects.Add(debuff1);
            statEffects.Add(debuff2);
            statEffects.Add(debuff3);
        }

        public IEnumerator GetEnumerator()
        {
            return statEffects.GetEnumerator();
        }
    }
}
