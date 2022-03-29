/****************************************************************
 *  File Name: Enemy.cs 
 *  Description: Works similarly to the Player class. Comprises all enemy information.
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
    class Enemy
    {
        private const int MAX_TURNS_BLEEDING = 3;
        private const int MAX_TURNS_BOUND = 2;
        private const int MAX_TURNS_POISONED = 4;
        private const int MAX_TURNS_PARALYZED = 5;

        private int maxHealth;
        private int currentHealth;
        private int damageTaken;
        private int coinsYielded;
        private int xpYielded;
        private int level;
        private int attack;
        private int defense;
        private int stamina;
        private int stealth;
        private int strength;
        private int intellect;
        private int speed;
        private string description;
        private string name;
        private string enemyType;
        private string title;
        private bool isBleeding = false;
        private int elapsedTurnsBleeding = -1;
        private bool isPoisoned = false;
        private int elapsedTurnsPoisoned = -1;
        private bool isBound = false;
        private int elapsedTurnsBound = -1;
        private bool isParalyzed = false;
        private int elapsedTurnsParalyzed = -1;
        private bool isBoss;

        private List<Move> moveSet;

        #region Mutators
        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }

            set
            {
                maxHealth = value;
            }
        }

        public int CurrentHealth
        {
            get
            {
                return currentHealth;
            }

            set
            {
                currentHealth = value;
            }
        }

        public int CoinsYielded
        {
            get
            {
                return coinsYielded;
            }

            set
            {
                coinsYielded = value;
            }
        }

        public int XpYielded
        {
            get
            {
                return xpYielded;
            }

            set
            {
                xpYielded = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public int Attack
        {
            get
            {
                return attack;
            }

            set
            {
                attack = value;
            }
        }

        public int Defense
        {
            get
            {
                return defense;
            }

            set
            {
                defense = value;
            }
        }

        public int Stamina
        {
            get
            {
                return stamina;
            }

            set
            {
                stamina = value;
            }
        }

        public int Stealth
        {
            get
            {
                return stealth;
            }

            set
            {
                stealth = value;
            }
        }

        public int Strength
        {
            get
            {
                return strength;
            }

            set
            {
                strength = value;
            }
        }

        public int Intellect
        {
            get
            {
                return intellect;
            }

            set
            {
                intellect = value;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string EnemyType
        {
            get
            {
                return enemyType;
            }

            set
            {
                enemyType = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public bool IsBleeding
        {
            get
            {
                return isBleeding;
            }

            set
            {
                isBleeding = value;
            }
        }

        public bool IsPoisoned
        {
            get
            {
                return isPoisoned;
            }

            set
            {
                isPoisoned = value;
            }
        }

        public bool IsBound
        {
            get
            {
                return isBound;
            }

            set
            {
                isBound = value;
            }
        }

        public bool IsParalyzed
        {
            get
            {
                return isParalyzed;
            }

            set
            {
                isParalyzed = value;
            }
        }

        public bool IsBoss
        {
            get
            {
                return isBoss;
            }

            set
            {
                isBoss = value;
            }
        }

        public int DamageTaken
        {
            get
            {
                return damageTaken;
            }

            set
            {
                damageTaken = value;
            }
        }

        public List<Move> MoveSet
        {
            get
            {
                return moveSet;
            }

            set
            {
                moveSet = value;
            }
        }



        #endregion

        public Enemy()
        {
            this.maxHealth = 5;
            this.currentHealth = 5;
            this.DamageTaken = 0;
            this.coinsYielded = 10;
            this.xpYielded = 5;
            this.level = 1;
            this.attack = 1;
            this.defense = 1;
            this.stamina = 1;
            this.stealth = 1;
            this.strength = 1;
            this.intellect = 1;
            this.speed = 1;
            this.description = "The default enemy loadout. Should not be used other than for testing.";
            this.name = "Ono";
            this.enemyType = "God";
            this.title = ", God of War";
            this.MoveSet = new List<Move>();
            this.isBleeding = false;
            this.isPoisoned = false;
            this.isBound = false;
            this.isParalyzed = false;
        }

        public Enemy(int maxHealth, int currentHealth, int damageTaken, int coinsYielded, int xpYielded,
            int level, int attack, int defense, int stamina, int stealth, int strength, int intellect, int speed,
            string description, string name, string enemyType, string title, List<Move> moveSet, bool isBleeding, bool isPoisoned,
            bool isBound, bool isParalyzed, bool isBoss)
        {
            this.maxHealth = maxHealth;
            this.currentHealth = currentHealth;
            this.DamageTaken = damageTaken;
            this.coinsYielded = coinsYielded;
            this.xpYielded = xpYielded;
            this.level = level;
            this.attack = attack;
            this.defense = defense;
            this.stamina = stamina;
            this.stealth = stealth;
            this.strength = strength;
            this.intellect = intellect;
            this.speed = speed;
            this.description = description;
            this.name = name;
            this.enemyType = enemyType;
            this.title = title;
            this.moveSet = moveSet;
            this.isBleeding = isBleeding;
            this.isPoisoned = isPoisoned;
            this.isBound = isBound;
            this.isParalyzed = isParalyzed;
            this.isBoss = isBoss;
        }

        public bool checkDeath()
        {
            if (currentHealth <= 0)
            {
                Console.WriteLine(name + " has died!");
                return true;
            }
            return false;
        }

        public void takeDamage()
        {
            if (damageTaken > 0) {
                currentHealth -= damageTaken;
                if (currentHealth < 0)
                {
                    currentHealth = 0;
                }
                damageTaken = 0;
            }
        }

        public void decrementCooldowns()
        {
            foreach (Move move in moveSet)
            {
                if (move.CurrentCooldown > 0)
                {
                    move.CurrentCooldown -= 1;
                }
            }
        }

        public bool determineBleedingHit()
        {
            Random r = new Random();
            int chance = r.Next(1, 21);
            if (chance == 6)
            {
                isBleeding = true;
                Console.WriteLine("The hit causes bleeding!");
                executeStatusEffects();
            }
            else
            {
                Console.WriteLine("The hit failed to cause bleeding.");
            }
            return isBleeding;
        }

        public bool determinePoisonHit()
        {
            Random r = new Random();
            int chance = r.Next(1, 21);
            if (chance == 2)
            {
                isPoisoned = true;
                Console.WriteLine("The hit causes poisoning!");
                executeStatusEffects();
            }
            else
            {
                Console.WriteLine("The hit failed to cause poisoning.");
            }
            return isPoisoned;
        }

        public bool determineBindingHit()
        {
            Random r = new Random();
            int chance = r.Next(1, 21);
            if (chance == 19)
            {
                isBound = true;
                Console.WriteLine("The hit binds!");
            }
            else
            {
                Console.WriteLine("The hit failed to bind the enemy.");
            }

            return isBound;
        }

        public bool determineParalyzingHit()
        {
            Random r = new Random();
            int chance = r.Next(1, 51);
            if (chance == 23)
            {
                isParalyzed = true;
                Console.WriteLine("The hit causes paralysis!");
                executeStatusEffects();
            }
            else
            {
                Console.WriteLine("The hit failed to paralyze the enemy.");
            }

            return isParalyzed;
        }

        public void displayCurrentHealth()
        {
            Console.WriteLine(name + " HP: " + currentHealth + " / " + maxHealth);
        }

        public void determineStatusEffects(Move move)
        {
            if (move.CanBind)
            {
                determineBindingHit();
            }
            if (move.CanBleed)
            {
                determineBleedingHit();
            }
            if (move.CanParalyze)
            {
                determineParalyzingHit();
            }
            if (move.CanPoison)
            {
                determinePoisonHit();
            }
        }

        public void executeStatusEffects()
        {
            if (isBleeding)
            {
                elapsedTurnsBleeding += 1;
                if (elapsedTurnsBleeding == MAX_TURNS_BLEEDING)
                {
                    Console.WriteLine(name + " has stopped bleeding!");
                    isBleeding = false;
                    elapsedTurnsBleeding = 0;
                }
                else
                {
                    Console.WriteLine(name + " is bleeding! It takes " + 2 * level + " damage!");
                    damageTaken += 2;
                    takeDamage();
                }
            }

            if (isBound)
            {
                elapsedTurnsBound += 1;
                if (elapsedTurnsBound == MAX_TURNS_BOUND)
                {
                    Console.WriteLine(name + " breaks free from the bind!");
                    isBound = false;
                    elapsedTurnsBound = 0;
                }
                else
                {
                    Console.WriteLine(name + " is bound! It cannot move!");
                }
            }

            if (isParalyzed)
            {
                elapsedTurnsParalyzed += 1;
                if (elapsedTurnsParalyzed == MAX_TURNS_PARALYZED)
                {
                    Console.WriteLine(name + " is no longer paralyzed!");
                    isParalyzed = false;
                    elapsedTurnsParalyzed = 0;
                }
                else
                {
                    Console.WriteLine(name + " is paralyzed! It takes 1 damage and cannot move for the turn!");
                    damageTaken += 1;
                    takeDamage();
                }
            }

            if (isPoisoned)
            {
                elapsedTurnsPoisoned += 1;
                if (elapsedTurnsPoisoned == MAX_TURNS_POISONED)
                {
                    Console.WriteLine(name + "'s poison wears off!");
                    isPoisoned = false;
                    elapsedTurnsPoisoned = 0;
                }
                else
                {
                    damageTaken += level;
                    Console.WriteLine(name + " is poisoned! It takes " + level + " damage!");
                    takeDamage();
                }
            }
        }
    }
}
