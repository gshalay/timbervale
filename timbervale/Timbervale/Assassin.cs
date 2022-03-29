/****************************************************************
 *  File Name: Assassin.cs 
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
    class Assassin : Player
    {
        ArrayList compatiblePlayers = new ArrayList();
        Move backstab;
        Move throwingStar;
        Move throwingKnife;
        public Assassin(string name)
        {
            compatiblePlayers.Add("Assassin");
            backstab = new Move("Backstab", "Deals 4 damage.\nHas a 5% chance to kill an enemy instantly. (1% on bosses)", 5 * level, 4, 0, compatiblePlayers, false, true, false, false);
            throwingStar = new Move("Throwing Star", "Deals 2 damage. Has a chance to hit up to 3 times.", 2 * level, 3, 0, compatiblePlayers, false, false, false, false);
            throwingKnife = new Move("Throwing Knife", "Deals 3 Damage. Has a chance to make enemies bleed for up to 3 turns.", 3 * level, 1, 0, compatiblePlayers, false, true, false, false);
            this.name = name;
            maxHealth = 10;
            currentHealth = 10;
            damageTaken = 0;
            numOfCoins = 50;
            currentXP = 0;
            remainingXP = 100;
            level = 1;
            attack = 3;
            defense = 1;
            stamina = 4;
            stealth = 5;
            strength = 1;
            intellect = 4;
            speed = 4;
            description = "The assassin is the master of stealth, sneaking up on prey for the silent kill.";
            title = null;
            playerType = "Assassin";
            moveSet.Add(throwingKnife);
            moveSet.Add(throwingStar);
            moveSet.Add(backstab);

            inventory.EquippedItems.Add(ItemCollection.beginnerHelm);
            inventory.EquippedItems.Add(ItemCollection.beginnerChest);
            inventory.EquippedItems.Add(ItemCollection.beginnerDagger);
            inventory.EquippedItems.Add(ItemCollection.beginnerShield);
            inventory.EquippedItems.Add(ItemCollection.beginnerLeggings);
        }

        public int getNumberOfStars(Enemy enemy)
        {
            const int UPPER_BOUND = 22;
            Random r = new Random();
            int chance = r.Next(1, UPPER_BOUND);
            Move m = (Move)moveSet[1];

            if (chance <= 7)
            {
                m.Power = 2;
                Console.WriteLine("One star is thrown!");
                Console.WriteLine("It deals " + m.Power + " damage!");
                enemy.DamageTaken += m.Power;
                enemy.takeDamage();
            }
            else if (chance >= 8 && chance <= 14)
            {
                m.Power = 4;
                Console.WriteLine("Two stars are thrown!");
                Console.WriteLine("They deal " + m.Power + " damage!");
                enemy.DamageTaken += m.Power;
                enemy.takeDamage();
            }
            else
            {
                m.Power = 6;
                Console.WriteLine("Three stars are thrown! Wow!");
                Console.WriteLine("They deal " + m.Power + " damage!");
                enemy.DamageTaken += m.Power;
                enemy.takeDamage();
            }
            return m.Power;
        }

        public bool isInstantKill(bool isBoss)
        {
            Random r = new Random();

            if (isBoss == false)
            {
                int chance = r.Next(1, 21);
                if (chance == 17)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                int chance = r.Next(1, 101);
                if (chance == 89)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool determineLethalBackstab(Enemy enemy)
        {
            const int BOSS_INSTANT_KILL = 50;
            const int ENEMY_INSTANT_KILL_LOWER_BOUND = 0;
            const int ENEMY_INSTANT_KILL_UPPER_BOUND = 5;
            Random random = new Random();
            int rand = random.Next(1, 101);
            if (enemy.IsBoss)
            {
                if (rand == BOSS_INSTANT_KILL)
                {
                    enemy.DamageTaken = enemy.CurrentHealth;
                    enemy.takeDamage();
                    Console.WriteLine("The backstab kills " + enemy.Name + " instantly!");
                    return true;
                }
            }
            else
            {
                if (rand > ENEMY_INSTANT_KILL_LOWER_BOUND && rand <= ENEMY_INSTANT_KILL_UPPER_BOUND)
                {
                    enemy.DamageTaken = enemy.CurrentHealth;
                    enemy.takeDamage();
                    Console.WriteLine("The backstab kills " + enemy.Name + " instantly!");
                    return true;
                }
            }

            return false;
        }
    }
}
