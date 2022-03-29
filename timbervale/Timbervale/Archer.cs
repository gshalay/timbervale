/****************************************************************
 *  File Name: Archer.cs 
 *  Description: Player type that inherits from the Player superclass.
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
    class Archer : Player
    {
        private int numOfShots;
        private Move arrowStorm;
        private Move singleShot;
        private Move stringShot;
        private ArrayList compatiblePlayers = new ArrayList();

        public Archer(string name)
        {
            compatiblePlayers.Add("Archer");
            arrowStorm = new Move("Arrow Storm", "Rain down arrows on your enemy! Deals 3-6 damage.", 0, 3, 0, compatiblePlayers, false, true, false, false);
            singleShot = new Move("Single Shot", "Fires an arrow at an enemy. Deals 2 Damage.", 2, 0, 0, compatiblePlayers, false, false, false, false);
            stringShot = new Move("String Shot", "Fires a tethered arrow at the enemy. Has a chance to immobilize the enemy for 2 turns.", 3, 4, 0, compatiblePlayers, true, false, false, false);
            this.name = name;
            maxHealth = 7;
            currentHealth = 7;
            damageTaken = 0;
            numOfCoins = 8;
            currentXP = 0;
            remainingXP = 100;
            level = 1;
            attack = 3;
            defense = 2;
            stamina = 3;
            stealth = 2;
            strength = 2;
            intellect = 3;
            speed = 4;
            description = "The Archer is skilled in the art of the bow. This character strives at a distance. The archer suffers in close combat. Avoid close combat with this character at all costs.";
            title = null;
            playerType = "Archer";
            moveSet.Add(singleShot);
            moveSet.Add(stringShot);
            moveSet.Add(arrowStorm);
            inventory.EquippedItems.Add(ItemCollection.beginnerHelm);
            inventory.EquippedItems.Add(ItemCollection.beginnerChest);
            inventory.EquippedItems.Add(ItemCollection.beginnerBow);
            inventory.EquippedItems.Add(null);
            inventory.EquippedItems.Add(ItemCollection.beginnerLeggings);
        }

        public void resetArrowStormPower()
        {
            arrowStorm.Power = 0;
        }

        public void getArrowStormPower()
        {
            Random r = new Random();
            int power = r.Next(3, 7);
            arrowStorm.Power = power;
        }

    }
}
