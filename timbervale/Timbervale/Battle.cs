/****************************************************************
 *  File Name: Battle.cs 
 *  Description: Handles the turn based move selection for combat between enemies and players.
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
    class Battle
    {
        private Archer archer = null;
        private Assassin assassin = null;
        private Paladin paladin = null; 
        private Wizard wizard = null;
        private Enemy enemy = new Enemy(9, 9, 0, 2, 6, 1, 2, 2, 2, 1, 3, 1, 1, "Test enemy.", "Ooga Booga", "simpleton", "", null, false, false, false, false, false);

        List<Move> moveSet = new List<Move>();

        public Battle()
        {
            ArrayList arr = new ArrayList();
            arr.Add("Any");
            Move move1 = new Move("Searing Spit", "The user spits a flaming substance at the foe.", 2, 0, 0, arr, false, false, false, false);
            Move move2 = new Move("Acid Spray", "The user spits a corrosive mist at the foe.", 2, 0, 0, arr, false, false, false, true);
            Move move3 = new Move("Poison Wave", "The foe is drenched in a poison wave", 2, 0, 0, arr, false, false, false, true);
            moveSet.Add(move1);
            moveSet.Add(move2);
            moveSet.Add(move3);
            enemy.MoveSet = moveSet;
        }

        public void startBattle()
        {
            if (Program.isArcherChosen)
            {
                determineWhoMovesFirst(archer, enemy);
            }
            if (Program.isAssassinChosen)
            {
                determineWhoMovesFirst(assassin, enemy);
            }
            if (Program.isPaladinChosen)
            {
                determineWhoMovesFirst(paladin, enemy);
            }
            if (Program.isWizardChosen)
            {
                determineWhoMovesFirst(wizard, enemy);
            }
            if (Program.isArcherChosen && Program.isAssassinChosen && Program.isPaladinChosen && Program.isWizardChosen)
            {

                Console.WriteLine("A player was not specified. Cannot preform battle.");
            }
        }

        public string getObjectType(Object obj)
        {
            string[] splicedString = (obj.GetType().ToString().Split('.'));
            string playerType = splicedString[1];
            Console.WriteLine(playerType);
            return playerType;
        }


        //TODO: Add other three overloads for the other characters
        public void determineWhoMovesFirst(Archer archer, Enemy enemy)
        {
            if (archer.Speed > enemy.Speed)
            {
                Console.WriteLine("Your speed gives you the edge! You move first!");
                while (enemy.checkDeath() == false && archer.checkDeath() == false)
                {
                    doArcherTurn(archer, enemy);
                    if(enemy.CurrentHealth > 0)
                    {
                        doEnemyTurn(enemy, archer);
                    }
                }
                if (enemy.CurrentHealth <= 0)
                {
                    archer.earnCoin(enemy.CoinsYielded);
                    archer.earnXP(enemy.XpYielded);
                }
            }

            else if (enemy.Speed > archer.Speed)
            {
                Console.WriteLine("The enemy's speed gives gives it the edge! You move second!");
                while (enemy.checkDeath() == false && archer.checkDeath() == false)
                {
                    doEnemyTurn(enemy, archer);
                    if (archer.CurrentHealth > 0)
                    {
                        doArcherTurn(archer, enemy);
                    }
                }
                if (enemy.CurrentHealth <= 0)
                {
                    archer.earnCoin(enemy.CoinsYielded);
                    archer.earnXP(enemy.XpYielded);
                }
            }
            else
            {
                Console.WriteLine("Your speed value and the enemy's are equal!\nThe enemy attacks first!");
                while (enemy.checkDeath() == false && archer.checkDeath() == false)
                {
                    doEnemyTurn(enemy, archer);
                    if (archer.CurrentHealth > 0)
                    {
                        doArcherTurn(archer, enemy);
                    }
                    
                }
                if (enemy.CurrentHealth <= 0)
                {
                    archer.earnCoin(enemy.CoinsYielded);
                    archer.earnXP(enemy.XpYielded);
                }
            }
        }

        public void determineWhoMovesFirst(Assassin assassin, Enemy enemy)
        {
            if (assassin.Speed > enemy.Speed)
            {
                Console.WriteLine("Your speed gives you the edge! You move first!");
                while (enemy.checkDeath() == false && assassin.checkDeath() == false)
                {
                    doAssassinTurn(assassin, enemy);
                    if (enemy.CurrentHealth > 0)
                    {
                        doEnemyTurn(enemy, assassin);
                    }
                }
                if (enemy.CurrentHealth <= 0)
                {
                    assassin.earnCoin(enemy.CoinsYielded);
                    assassin.earnXP(enemy.XpYielded);
                }
            }

            else if (enemy.Speed > assassin.Speed)
            {
                Console.WriteLine("The enemy's speed gives gives it the edge! You move second!");
                while (enemy.checkDeath() == false && assassin.checkDeath() == false)
                {
                    doEnemyTurn(enemy, assassin);
                    if (assassin.CurrentHealth > 0)
                    {
                        doAssassinTurn(assassin, enemy);
                    }
                }
                if (enemy.CurrentHealth <= 0)
                {
                    assassin.earnCoin(enemy.CoinsYielded);
                    assassin.earnXP(enemy.XpYielded);
                }
            }
            else
            {
                Console.WriteLine("Your speed value and the enemy's are equal!\nThe enemy attacks first!");
                while (enemy.checkDeath() == false && assassin.checkDeath() == false)
                {
                    doEnemyTurn(enemy, assassin);
                    if (assassin.CurrentHealth > 0) {
                        doAssassinTurn(assassin, enemy);
                    }
                }
                if (enemy.CurrentHealth <= 0)
                {
                    assassin.earnCoin(enemy.CoinsYielded);
                    assassin.earnXP(enemy.XpYielded);
                }
            }

        }

        public void determineWhoMovesFirst(Paladin paladin, Enemy enemy)
        {
            if (paladin.Speed > enemy.Speed)
            {
                Console.WriteLine("Your speed gives you the edge! You move first!");
                while (enemy.checkDeath() == false && paladin.checkDeath() == false)
                {
                    doPaladinTurn(paladin, enemy);
                    if (enemy.CurrentHealth > 0)
                    {
                        doEnemyTurn(enemy, paladin);
                    }  
                }
                if (enemy.CurrentHealth <= 0)
                {
                    paladin.earnCoin(enemy.CoinsYielded);
                    paladin.earnXP(enemy.XpYielded);
                }
            }

            else if (enemy.Speed > paladin.Speed)
            {
                Console.WriteLine("The enemy's speed gives gives it the edge! You move second!");
                while (enemy.checkDeath() == false && paladin.checkDeath() == false)
                {
                    doEnemyTurn(enemy, paladin);
                    if (paladin.CurrentHealth > 0)
                    {
                        doPaladinTurn(paladin, enemy);
                    }
                }
                if (enemy.CurrentHealth <= 0)
                {
                    paladin.earnCoin(enemy.CoinsYielded);
                    paladin.earnXP(enemy.XpYielded);
                }
            }
            else
            {
                Console.WriteLine("Your speed value and the enemy's are equal!\nThe enemy attacks first!");
                while (enemy.checkDeath() == false && paladin.checkDeath() == false)
                {
                    doEnemyTurn(enemy, paladin);
                    if (paladin.CurrentHealth > 0)
                    {
                        doPaladinTurn(paladin, enemy);
                    }
                }
                if (enemy.CurrentHealth <= 0)
                {
                    paladin.earnCoin(enemy.CoinsYielded);
                    paladin.earnXP(enemy.XpYielded);
                }
            }

        }

        public void determineWhoMovesFirst(Wizard wizard, Enemy enemy)
        {
            if (wizard.Speed > enemy.Speed)
            {
                Console.WriteLine("Your speed gives you the edge! You move first!");
                while (enemy.checkDeath() == false && wizard.checkDeath() == false)
                {
                    doWizardTurn(wizard, enemy);
                    if (enemy.CurrentHealth > 0)
                    {
                        doEnemyTurn(enemy, wizard);
                    }
                }
                if (enemy.CurrentHealth <= 0)
                {
                    wizard.earnCoin(enemy.CoinsYielded);
                    wizard.earnXP(enemy.XpYielded);
                }
            }

            else if (enemy.Speed > wizard.Speed)
            {
                Console.WriteLine("The enemy's speed gives gives it the edge! You move second!");
                while (enemy.checkDeath() == false && wizard.checkDeath() == false)
                {
                    doEnemyTurn(enemy, wizard);
                    if (wizard.CurrentHealth > 0)
                    {
                        doWizardTurn(wizard, enemy);
                    }
                }
                if (enemy.CurrentHealth <= 0)
                {
                    wizard.earnCoin(enemy.CoinsYielded);
                    wizard.earnXP(enemy.XpYielded);
                }
            }
            else
            {
                Console.WriteLine("Your speed value and the enemy's are equal!\nThe enemy attacks first!");
                while (enemy.checkDeath() == false && wizard.checkDeath() == false)
                {
                    doEnemyTurn(enemy, wizard);
                    if (wizard.CurrentHealth > 0)
                    {
                        doWizardTurn(wizard, enemy);
                    }
                }
                if (enemy.CurrentHealth <= 0)
                {
                    wizard.earnCoin(enemy.CoinsYielded);
                    wizard.earnXP(enemy.XpYielded);
                }
            }
        }

        //Player Turn Methods.
        public void doArcherTurn(Archer archer, Enemy enemy)
        {
            if (archer.IsBleeding == true || archer.IsBound == true || archer.IsParalyzed == true || archer.IsPoisoned == true)
            {
                archer.executeStatusEffects();
            }

            archer.decrementCooldowns();
            archer.displayCurrentHealth();
            enemy.displayCurrentHealth();
            Console.WriteLine("---------------------------------------------------");
            if (!archer.IsBound)
            {
                Console.WriteLine("What will you do?\n1. " + archer.MoveSet[1].Name);
                if (archer.MoveSet[1].CurrentCooldown > 0)
                {
                    Console.WriteLine("2. " + archer.MoveSet[1].Name + " (Ready in " + archer.MoveSet[1].CurrentCooldown + " turn(s))");
                }
                else
                {
                    Console.WriteLine("2. " + archer.MoveSet[1].Name + " (Ready)");
                }

                if (archer.MoveSet[2].CurrentCooldown > 0)
                {
                    Console.WriteLine("3. " + archer.MoveSet[2].Name + " (Ready in " + archer.MoveSet[2].CurrentCooldown + " turn(s))");
                }
                else
                {
                    Console.WriteLine("3. " + archer.MoveSet[2].Name + " (Ready)");
                }

                int choice = -1;
                int.TryParse(Console.ReadLine(), out choice);

                if (choice == 1)
                {
                    if (archer.CurrentHealth > 0)
                    {
                        if (archer.MoveSet[0].CurrentCooldown > 0)
                        {
                            Console.WriteLine("That move is not yet ready. Please wait " + archer.MoveSet[0].CurrentCooldown + " turn(s) to use it. You have lost a turn.");
                        }
                        else
                        {
                            Console.WriteLine(archer.Name + " uses " + archer.MoveSet[0].Name + "! It deals " + archer.MoveSet[0].Power + " damage!");
                            enemy.determineStatusEffects(archer.MoveSet[0]);
                            enemy.DamageTaken += archer.MoveSet[0].Power;
                            enemy.takeDamage();
                        }
                    }
                }

                else if (choice == 2)
                {
                    if (archer.CurrentHealth > 0)
                    {
                        if (archer.MoveSet[1].CurrentCooldown > 0)
                        {
                            Console.WriteLine("That move is not yet ready. Please wait " + archer.MoveSet[1].CurrentCooldown + " turn(s) to use it. You have lost a turn.");
                        }
                        else
                        {
                            Console.WriteLine(archer.Name + " uses " + archer.MoveSet[1].Name + "! It deals " + archer.MoveSet[1].Power + " damage!");
                            enemy.determineStatusEffects(archer.MoveSet[1]);
                            archer.MoveSet[1].CurrentCooldown = archer.MoveSet[1].Cooldown;
                            enemy.DamageTaken += archer.MoveSet[1].Power;
                            enemy.takeDamage();
                        }
                    }
                }

                else if (choice == 3)
                {
                    if (archer.CurrentHealth > 0)
                    {
                        if (archer.MoveSet[2].CurrentCooldown > 0)
                        {
                            Console.WriteLine("That move is not yet ready. Please wait " + archer.MoveSet[2].CurrentCooldown + " turn(s) to use it. You have lost a turn.");
                        }
                        else
                        {
                            archer.getArrowStormPower();
                            Console.WriteLine(archer.Name + " uses " + archer.MoveSet[2].Name + "! It deals " + archer.MoveSet[2].Power + " damage!");
                            enemy.determineStatusEffects(archer.MoveSet[2]);
                            enemy.DamageTaken += archer.MoveSet[2].Power;
                            archer.MoveSet[2].CurrentCooldown = archer.MoveSet[2].Cooldown;
                            enemy.takeDamage();
                            archer.resetArrowStormPower();
                        }
                    }
                }

                else
                {
                    Console.WriteLine("The input entered is invalid.");
                }

                Console.WriteLine("Press any key to proceed to the enemy's turn.");
                Console.ReadLine();
            }
        }

        public void doAssassinTurn(Assassin assassin, Enemy enemy)
        {
            if (assassin.IsBleeding == true || assassin.IsBound == true || assassin.IsParalyzed == true || assassin.IsPoisoned == true)
            {
                assassin.executeStatusEffects();
            }

            assassin.decrementCooldowns();
            assassin.displayCurrentHealth();
            enemy.displayCurrentHealth();
            Console.WriteLine("---------------------------------------------------");
            if (!assassin.IsBound)
            {
                Console.WriteLine("What will you do?\n1. " + assassin.MoveSet[0].Name);
                if (assassin.MoveSet[1].CurrentCooldown > 0)
                {
                    Console.WriteLine("2. " + assassin.MoveSet[1].Name + " (Ready in " + assassin.MoveSet[1].CurrentCooldown + " turn(s))");
                }
                else
                {
                    Console.WriteLine("2. " + assassin.MoveSet[1].Name + " (Ready)");
                }

                if (assassin.MoveSet[2].CurrentCooldown > 0)
                {
                    Console.WriteLine("3. " + assassin.MoveSet[2].Name + " (Ready in " + assassin.MoveSet[2].CurrentCooldown + " turn(s))");
                }
                else
                {
                    Console.WriteLine("3. " + assassin.MoveSet[2].Name + " (Ready)");
                }

                int choice = -1;
                int.TryParse(Console.ReadLine(), out choice);

                if (choice == 1)
                {
                    if (assassin.CurrentHealth > 0)
                    {
                        if (assassin.MoveSet[0].CurrentCooldown > 0)
                        {
                            Console.WriteLine("That move is not yet ready. Please wait " + assassin.MoveSet[0].CurrentCooldown + " turn(s) to use it. You have lost a turn.");
                        }
                        else
                        {
                            Console.WriteLine(assassin.Name + " uses " + assassin.MoveSet[0].Name + "! It deals " + assassin.MoveSet[0].Power + " damage!");
                            enemy.determineStatusEffects(assassin.MoveSet[0]);
                            enemy.DamageTaken += assassin.MoveSet[0].Power;
                            enemy.takeDamage();
                        }
                    }
                }

                else if (choice == 2)
                {
                    if (assassin.CurrentHealth > 0)
                    {
                        if (assassin.MoveSet[1].CurrentCooldown > 0)
                        {
                            Console.WriteLine("That move is not yet ready. Please wait " + assassin.MoveSet[1].CurrentCooldown + " turn(s) to use it. You have lost a turn.");
                        }
                        else
                        {
                            assassin.getNumberOfStars(enemy);
                            //Console.WriteLine(assassin.Name + " uses " + assassin.MoveSet[1].Name + "! It deals " + assassin.getNumberOfStars(enemy) + " damage!");
                            enemy.determineStatusEffects(assassin.MoveSet[1]);
                            assassin.MoveSet[1].CurrentCooldown = assassin.MoveSet[1].Cooldown;
                        }
                    }
                }

                else if (choice == 3)
                {
                    if (assassin.CurrentHealth > 0)
                    {
                        if (assassin.MoveSet[2].CurrentCooldown > 0)
                        {
                            Console.WriteLine("That move is not yet ready. Please wait " + assassin.MoveSet[2].CurrentCooldown + " turn(s) to use it. You have lost a turn.");
                        }
                        else
                        {
                            Console.WriteLine(assassin.Name + " uses " + assassin.MoveSet[2].Name + "! It deals " + assassin.MoveSet[2].Power + " damage!");
                            enemy.determineStatusEffects(assassin.MoveSet[2]);
                            enemy.DamageTaken += assassin.MoveSet[2].Power;
                            enemy.takeDamage();
                            assassin.MoveSet[2].CurrentCooldown = assassin.MoveSet[2].Cooldown;
                            assassin.determineLethalBackstab(enemy);
                        }
                    }
                }

                else
                {
                    Console.WriteLine("The input entered is invalid.");
                }

                Console.WriteLine("Press any key to proceed to the enemy's turn.");
                Console.ReadLine();
            }
        }

        public void doPaladinTurn(Paladin paladin, Enemy enemy)
        {
            if (paladin.IsBleeding == true || paladin.IsBound == true || paladin.IsParalyzed == true || paladin.IsPoisoned == true)
            {
                paladin.executeStatusEffects();
            }

            paladin.decrementCooldowns();
            paladin.displayCurrentHealth();
            enemy.displayCurrentHealth();
            Console.WriteLine("---------------------------------------------------");
            
            if (!paladin.IsBound)
            {
                Console.WriteLine("What will you do?\n1. " + paladin.MoveSet[0].Name);
                if (paladin.MoveSet[1].CurrentCooldown > 0)
                {
                    Console.WriteLine("2. " + paladin.MoveSet[1].Name + " (Ready in " + paladin.MoveSet[1].CurrentCooldown + " turn(s))");
                }
                else
                {
                    Console.WriteLine("2. " + paladin.MoveSet[1].Name + " (Ready)");
                }

                if (paladin.MoveSet[2].CurrentCooldown > 0)
                {
                    Console.WriteLine("3. " + paladin.MoveSet[2].Name + " (Ready in " + paladin.MoveSet[2].CurrentCooldown + " turn(s))");
                }
                else
                {
                    Console.WriteLine("3. " + paladin.MoveSet[2].Name + " (Ready)");
                }

                int choice = -1;
                int.TryParse(Console.ReadLine(), out choice);

                if (choice == 1)
                {
                    if (paladin.CurrentHealth > 0)
                    {
                        if (paladin.MoveSet[0].CurrentCooldown > 0)
                        {
                            Console.WriteLine("That move is not yet ready. Please wait " + paladin.MoveSet[0].CurrentCooldown + " turn(s) to use it. You have lost a turn.");
                        }
                        else
                        {
                            Console.WriteLine(paladin.Name + " uses " + paladin.MoveSet[0].Name + "! It deals " + paladin.MoveSet[0].Power + " damage!");
                            enemy.determineStatusEffects(paladin.MoveSet[0]);
                            enemy.DamageTaken += paladin.MoveSet[0].Power;
                            enemy.takeDamage();
                        }
                    }
                }

                else if (choice == 2)
                {
                    if (paladin.CurrentHealth > 0)
                    {
                        if (paladin.MoveSet[1].CurrentCooldown > 0)
                        {
                            Console.WriteLine("That move is not yet ready. Please wait " + paladin.MoveSet[1].CurrentCooldown + " turn(s) to use it. You have lost a turn.");
                        }
                        else
                        {
                            Console.WriteLine(paladin.Name + " uses " + paladin.MoveSet[1].Name + "! It deals " + paladin.MoveSet[1].Power + " damage!");
                            //enemy.determineStatusEffects(paladin.MoveSet[1]);
                            paladin.determineDivineShieldBleed(enemy);
                            paladin.MoveSet[1].CurrentCooldown = paladin.MoveSet[1].Cooldown;
                            enemy.DamageTaken += paladin.MoveSet[1].Power;
                            enemy.takeDamage();
                        }
                    }
                }

                else if (choice == 3)
                {
                    if (paladin.CurrentHealth > 0)
                    {
                        if (paladin.MoveSet[2].CurrentCooldown > 0)
                        {
                            Console.WriteLine("That move is not yet ready. Please wait " + paladin.MoveSet[2].CurrentCooldown + " turn(s) to use it. You have lost a turn.");
                        }
                        else
                        {
                            Console.WriteLine(paladin.Name + " uses " + paladin.MoveSet[2].Name + "! It deals " + paladin.MoveSet[2].Power + " damage!");
                            paladin.appeal();
                            //enemy.determineStatusEffects(paladin.MoveSet[2]);
                            enemy.DamageTaken += paladin.MoveSet[2].Power;
                            paladin.MoveSet[2].CurrentCooldown = paladin.MoveSet[2].Cooldown;
                            enemy.takeDamage();
                        }
                    }
                }

                else
                {
                    Console.WriteLine("The input entered is invalid.");
                }
            }

            Console.WriteLine("Press 'Enter' to proceed to your turn.");
            Console.ReadLine();
        }

        public void doWizardTurn(Wizard wizard, Enemy enemy)
        {
            //TODO: Add Logic. (Refer to Archer example.)
            if (wizard.IsBleeding == true || wizard.IsBound == true || wizard.IsParalyzed == true || wizard.IsPoisoned == true)
            {
                wizard.executeStatusEffects();
            }

            wizard.decrementCooldowns();
            wizard.displayCurrentHealth();
            enemy.displayCurrentHealth();
            Console.WriteLine("---------------------------------------------------");
            if (!wizard.IsBound) {
                Console.WriteLine("What will you do?\n1. " + wizard.MoveSet[0].Name);
                if (wizard.MoveSet[1].CurrentCooldown > 0)
                {
                    Console.WriteLine("2. " + wizard.MoveSet[1].Name + " (Ready in " + wizard.MoveSet[1].CurrentCooldown + " turn(s))");
                }
                else
                {
                    Console.WriteLine("2. " + wizard.MoveSet[1].Name + "(Ready)");
                }

                if (wizard.MoveSet[2].CurrentCooldown > 0)
                {
                    Console.WriteLine("3. " + wizard.MoveSet[2].Name + " (Ready in " + wizard.MoveSet[2].CurrentCooldown + " turn(s))");
                }
                else
                {
                    Console.WriteLine("3. " + wizard.MoveSet[2].Name + " (Ready)");
                }

                int choice = -1;
                int.TryParse(Console.ReadLine(), out choice);

                if (choice == 1)
                {
                    if (wizard.CurrentHealth > 0)
                    {
                        if (wizard.MoveSet[0].CurrentCooldown > 0)
                        {
                            Console.WriteLine("That move is not yet ready. Please wait " + wizard.MoveSet[0].CurrentCooldown + " turn(s) to use it. You have lost a turn.");
                        }
                        else
                        {
                            Console.WriteLine(wizard.Name + " uses " + wizard.MoveSet[0].Name + "! It deals " + wizard.MoveSet[0].Power + " damage!");
                            enemy.determineStatusEffects(wizard.MoveSet[0]);
                            enemy.DamageTaken += wizard.MoveSet[0].Power;
                            enemy.takeDamage();
                        }
                    }
                }

                else if (choice == 2)
                {
                    if (wizard.CurrentHealth > 0)
                    {
                        if (wizard.MoveSet[1].CurrentCooldown > 0)
                        {
                            Console.WriteLine("That move is not yet ready. Please wait " + wizard.MoveSet[1].CurrentCooldown + " turn(s) to use it. You have lost a turn.");
                        }
                        else
                        {
                            Console.WriteLine(wizard.Name + " uses " + wizard.MoveSet[1].Name + "! It deals " + wizard.MoveSet[1].Power + " damage!");
                            if (wizard.MoveSet[1].Name == "Poison Ward")
                            {
                                wizard.determineWardPoisoning(enemy);
                                wizard.determineWardSelfPoison();
                            }
                            else // More options can be added here for Moves that have a different status hit chance than the default.
                            {
                                enemy.determineStatusEffects(wizard.MoveSet[1]);
                            }
                            
                            wizard.MoveSet[1].CurrentCooldown = wizard.MoveSet[1].Cooldown;
                            enemy.DamageTaken += wizard.MoveSet[1].Power;
                            enemy.takeDamage();
                        }
                    }
                }

                else if (choice == 3)
                {
                    if (wizard.CurrentHealth > 0)
                    {
                        if (wizard.MoveSet[2].CurrentCooldown > 0)
                        {
                            Console.WriteLine("That move is not yet ready. Please wait " + wizard.MoveSet[2].CurrentCooldown + " turn(s) to use it. You have lost a turn.");
                        }
                        else
                        {
                            Console.WriteLine(wizard.Name + " uses " + wizard.MoveSet[2].Name + "! It deals " + wizard.MoveSet[2].Power + " damage!");
                            //enemy.determineStatusEffects(wizard.MoveSet[2]);
                            wizard.snareEnemy(enemy);
                            enemy.DamageTaken += wizard.MoveSet[2].Power;
                            wizard.MoveSet[2].CurrentCooldown = wizard.MoveSet[2].Cooldown;
                            enemy.takeDamage();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("The input entered is invalid.");
            }

            Console.WriteLine("Press 'Enter' to proceed to your turn.");
            Console.ReadLine();
        }

        private int randomEnemyMove()
        {
            Random random = new Random();
            bool valid = false;
            int rand = -1;

            while (valid == false)
            {
                rand = random.Next(0, enemy.MoveSet.Count);

                if (enemy.MoveSet[rand].CurrentCooldown == 0)
                {
                    valid = true;
                }
            }

            return rand;

        }

        //Enemy Turn Overloads
        public void doEnemyTurn(Enemy enemy, Archer archer)
        {
            if (enemy.IsBleeding == true || enemy.IsBound == true || enemy.IsParalyzed == true || enemy.IsPoisoned == true)
            {
                enemy.executeStatusEffects();
            }
            enemy.decrementCooldowns();
            archer.displayCurrentHealth();
            enemy.displayCurrentHealth();
            Console.WriteLine("---------------------------------------------------");
            if (!enemy.IsBound)
            {
                if (enemy.CurrentHealth > 0)
                {
                    int moveIndex = randomEnemyMove();
                    Console.WriteLine(enemy.Name + " uses " + enemy.MoveSet[moveIndex].Name + "! It does " + enemy.MoveSet[moveIndex].Power + " damage!");
                    archer.determineStatusEffects(enemy.MoveSet[moveIndex]);
                    archer.DamageTaken += enemy.MoveSet[moveIndex].Power;
                    archer.CurrentHealth -= archer.DamageTaken;
                    archer.DamageTaken = 0;
                }
            }

            Console.WriteLine("Press 'Enter' to proceed to your turn.");
            Console.ReadLine();
        }

        public void doEnemyTurn(Enemy enemy, Assassin assassin)
        {
            if (enemy.IsBleeding == true || enemy.IsBound == true || enemy.IsParalyzed == true || enemy.IsPoisoned == true)
            {
                enemy.executeStatusEffects();
            }
            enemy.decrementCooldowns();
            assassin.displayCurrentHealth();
            enemy.displayCurrentHealth();
            Console.WriteLine("---------------------------------------------------");
            if (!enemy.IsBound)
            {
                if (enemy.CurrentHealth > 0)
                {
                    int moveIndex = randomEnemyMove();
                    Console.WriteLine(enemy.Name + " uses " + enemy.MoveSet[moveIndex].Name + "! It does " + enemy.MoveSet[moveIndex].Power + " damage!");
                    assassin.determineStatusEffects(enemy.MoveSet[moveIndex]);
                    assassin.DamageTaken += enemy.MoveSet[moveIndex].Power;
                    assassin.CurrentHealth -= assassin.DamageTaken;
                    assassin.DamageTaken = 0;
                }
            }

            Console.WriteLine("Press 'Enter' to proceed to your turn.");
            Console.ReadLine();
        }

        public void doEnemyTurn(Enemy enemy, Paladin paladin)
        {
            if (enemy.IsBleeding == true || enemy.IsBound == true || enemy.IsParalyzed == true || enemy.IsPoisoned == true)
            {
                enemy.executeStatusEffects();
            }
            enemy.decrementCooldowns();
            paladin.displayCurrentHealth();
            enemy.displayCurrentHealth();
            Console.WriteLine("---------------------------------------------------");
            if (!enemy.IsBound)
            {
                if (enemy.CurrentHealth > 0)
                {
                    int moveIndex = randomEnemyMove();
                    if (paladin.IsDivineShieldActive)
                    {
                        paladin.IsDivineShieldActive = false;
                        Console.WriteLine(enemy.Name + " uses " + enemy.MoveSet[moveIndex].Name + "! The attack deals no damage due to Divine Shield!");
                    }
                    else
                    {
                        Console.WriteLine(enemy.Name + " uses " + enemy.MoveSet[moveIndex].Name + "! It does " + enemy.MoveSet[moveIndex].Power + " damage!");
                        paladin.determineStatusEffects(enemy.MoveSet[moveIndex]);
                        paladin.DamageTaken += enemy.MoveSet[moveIndex].Power;
                        paladin.CurrentHealth -= paladin.DamageTaken;
                        paladin.DamageTaken = 0;
                    }
                }
            }

            Console.WriteLine("Press 'Enter' to proceed to your turn.");
            Console.ReadLine();
        }

        public void doEnemyTurn(Enemy enemy, Wizard wizard)
        {            
            if (enemy.IsBleeding == true || enemy.IsBound == true || enemy.IsParalyzed == true || enemy.IsPoisoned == true)
            {
                enemy.executeStatusEffects();
            }

            enemy.decrementCooldowns();
            wizard.displayCurrentHealth();
            enemy.displayCurrentHealth();
            Console.WriteLine("---------------------------------------------------");

            if (!enemy.IsBound) { 
                if (enemy.CurrentHealth > 0)
                {
                    int moveIndex = randomEnemyMove();
                    if (wizard.IsPoisonWardActive)
                    {
                        wizard.IsPoisonWardActive = false;
                        Console.WriteLine(enemy.Name + " uses " + enemy.MoveSet[moveIndex].Name + "! But it deals no damage due to the Poison Ward!");
                    }
                    else
                    {
                        Console.WriteLine(enemy.Name + " uses " + enemy.MoveSet[moveIndex].Name + "! It does " + enemy.MoveSet[moveIndex].Power + " damage!");
                        wizard.determineStatusEffects(enemy.MoveSet[moveIndex]);
                        wizard.DamageTaken += enemy.MoveSet[moveIndex].Power;
                        wizard.CurrentHealth -= wizard.DamageTaken;
                        wizard.DamageTaken = 0;
                    }
                }
            }

            Console.WriteLine("Press 'Enter' to proceed to your turn.");
            Console.ReadLine();
        }

        #region Mutators
        public void setArcher(Archer archer)
        {
            this.archer = archer;
        }
        public Archer getArcher()
        {
            return archer;
        }

        public void setAssassin(Assassin assassin)
        {
            this.assassin = assassin;
        }
        public Assassin getAssassin()
        {
            return assassin;
        }

        public void setPaladin(Paladin paladin)
        {
            this.paladin = paladin;
        }
        public Paladin getPaladin()
        {
            return paladin;
        }

        public void setWizard(Wizard wizard)
        {
            this.wizard = wizard;
        }
        public Wizard getWizard()
        {
            return wizard;
        }

        public void setEnemy(Enemy enemy)
        {
            this.enemy = enemy;
        }
        public Enemy getEnemy()
        {
            return enemy;
        }

        #endregion

    }
}
