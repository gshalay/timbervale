/****************************************************************
 *  File Name: Move.cs 
 *  Description: Contains logic for the enemy and player moves to be used in combat.
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
    class Move
    {
        private string name;
        private string description;
        private int power;
        private int cooldown;
        private int currentCooldown;
        private bool canBleed = false;
        private bool canBind = false;
        private bool canParalyze = false;
        private bool canPoison = false;
        private ArrayList compatiblePlayers = new ArrayList();

        public Move()
        {

        }

        public Move(string name, string description, int power, int cooldown, int currentCooldown, ArrayList compatiblePlayers, bool canBind, bool canBleed, bool canParalyze, bool canPoison)
        {
            this.name = name;
            this.description = description;
            this.power = power;
            this.cooldown = cooldown;
            this.currentCooldown = currentCooldown;
            if (compatiblePlayers == null)
            {
                compatiblePlayers.Add("Any");
            }
            //this.compatiblePlayers = compatiblePlayers;
            this.canBind = canBind;
            this.canBleed = canBleed;
            this.canParalyze = canParalyze;
            this.canPoison = canPoison;
        }


        #region Mutators
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

        public int Power
        {
            get
            {
                return power;
            }

            set
            {
                power = value;
            }
        }

        public ArrayList CompatiblePlayers
        {
            get
            {
                return compatiblePlayers;
            }

            set
            {
                compatiblePlayers = value;
            }
        }

        public int Cooldown
        {
            get
            {
                return cooldown;
            }

            set
            {
                cooldown = value;
            }
        }

        public int CurrentCooldown
        {
            get
            {
                return currentCooldown;
            }

            set
            {
                currentCooldown = value;
            }
        }

        public bool CanBind
        {
            get
            {
                return canBind;
            }
            set
            {
                canBind = value;
            }
        }

        public bool CanBleed
        {
            get
            {
                return canBleed;
            }
            set
            {
                canBleed = value;
            }
        }

        public bool CanParalyze
        {
            get
            {
                return canParalyze;
            }
            set
            {
                canParalyze = value;
            }
        }

        public bool CanPoison
        {
            get
            {
                return canPoison;
            }
            set
            {
                canPoison = value;
            }
        }
        #endregion


    }
}
