using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Timbervale
{
    static class DBHelper
    {
        //TODO: Add database manipulation logic, as well as the appropriate Constructors.
        //TODO: Add reader.Close to all methods after the readers have been used.
        static MySqlConnection connection = new MySqlConnection();

        #region Open/Close Database Connection
        public static void OpenConnection()
        {
            connection.ConnectionString = @"server=localhost;user id=root;database=timbervaledb;SslMode=none";
            
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection opened successfully!");
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connection closed unexpectedly.");
                }
                else
                {
                    Console.WriteLine("There was an issue opening the connection.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Database connection attempt failed. Is the MySql server running on port 3306?");
            }
        }

        public static void CloseConnection()
        {
            connection.Close();
            if (connection.State == ConnectionState.Open)
            {
                Console.WriteLine("Connection failed to close.");
            }
            else if (connection.State == ConnectionState.Closed)
            {
                Console.WriteLine("Connection closed successfuly.");
            }
            else
            {
                Console.WriteLine("There was an issue closing the connection.");
            }
        } 
        #endregion

        #region Move CRUD
        public static void insertMove(string moveName, string moveDescription, int movePower, int cooldown, string compatibility, int canBind, int canBleed, int canPoison, int canParalyze)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO MOVE (moveName, description, power, cooldown, compatibility, canBind, canBleed, canPoison, canParalyze) VALUES (@moveName, @description, @power, @cooldown, @compatibility, @canBind, @canBleed, @canPoison, @canParalyze);";
            cmd.Parameters.AddWithValue("@moveName", moveName);
            cmd.Parameters.AddWithValue("@description", moveDescription);
            cmd.Parameters.AddWithValue("@power", movePower);
            cmd.Parameters.AddWithValue("@cooldown", cooldown);
            cmd.Parameters.AddWithValue("@compatibility", compatibility);
            cmd.Parameters.AddWithValue("@canBind", canBind);
            cmd.Parameters.AddWithValue("@canBleed", canBleed);
            cmd.Parameters.AddWithValue("@canPoison", canPoison);
            cmd.Parameters.AddWithValue("@canParalyze", canParalyze);

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Move inserted successfully.");
            }
            catch (Exception e)
            {
                e = e.GetBaseException();
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static void updateMove(int moveID, string moveName, string moveDescription, int movePower, int cooldown, string compatibility, int canBind, int canBleed, int canPoison, int canParalyze)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = "UPDATE MOVE SET moveName = @moveName, description = @description, power = @power, cooldown = @cooldown, compatibility = @compatibility, canBind = @canBind, canBleed = @canBleed, canPoison = @canPoison, canParalyze = @canParalyze WHERE moveID = @moveID;";
            cmd.Parameters.AddWithValue("@moveID", moveID);
            cmd.Parameters.AddWithValue("@moveName", moveName);
            cmd.Parameters.AddWithValue("@description", moveDescription);
            cmd.Parameters.AddWithValue("@power", movePower);
            cmd.Parameters.AddWithValue("@cooldown", cooldown);
            cmd.Parameters.AddWithValue("@compatibility", compatibility);
            cmd.Parameters.AddWithValue("@canBind", canBind);
            cmd.Parameters.AddWithValue("@canBleed", canBleed);
            cmd.Parameters.AddWithValue("@canPoison", canPoison);
            cmd.Parameters.AddWithValue("@canParalyze", canParalyze);

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Battle Move updated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static void deleteMove(int moveID)
        {
            string choice = "";

            Move desiredMove = getMove(moveID);

            while (choice != "y" && choice != "n")
            {
                Console.WriteLine("Are you sure you want to delete '" + desiredMove.Name + "?");
                choice = Console.ReadLine().ToLower();
                if (choice != "y" && choice != "n")
                {
                    Console.WriteLine("Please enter either 'y' or 'n' to continue.");
                }
            }

            if (choice == "y")
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM BATTLE_MOVE WHERE moveID = @moveID;";
                cmd.Parameters.AddWithValue("@moveID", moveID);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("'" + desiredMove.Name + "' deleted successfully.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }

            }

            else
            {
                Console.WriteLine("Delete Aborted.");
            }
        }

        public static Move getMove(int moveID)
        {
            const int NO_CURRENT_COOLDOWN = 0;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            Move move;

            cmd.CommandText = "SELECT * FROM MOVE WHERE moveID = @moveID";
            cmd.Parameters.AddWithValue("@moveID", moveID);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            reader = cmd.ExecuteReader();

            while (reader.Read() && reader != null)
            {
                ArrayList compatibility = new ArrayList();

                compatibility.Add(reader["compatibility"]);
                int movePower = int.Parse(reader["power"].ToString());
                int cooldown = int.Parse(reader["cooldown"].ToString());
                bool canBind = Convert.ToBoolean(reader["canBind"]);
                bool canBleed = Convert.ToBoolean(reader["canBleed"]);
                bool canParalyze = Convert.ToBoolean(reader["canParalyze"]);
                bool canPoison = Convert.ToBoolean(reader["canPoison"]);

                move = new Move(reader["moveName"].ToString(), reader["description"].ToString(), movePower, cooldown, NO_CURRENT_COOLDOWN, compatibility, canBind, canBleed, canParalyze, canPoison);

                return move;
            }

            reader.Close();

            return null;
        }

        public static List<Move> getAllMoves()
        {
            const int NO_CURRENT_COOLDOWN = 0; 
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            List<Move> moves = new List<Move>();

            cmd.CommandText = "SELECT * FROM MOVE;";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            reader = cmd.ExecuteReader();

            while (reader.Read() && reader != null)
            {
                Move move;
                ArrayList compatibility = new ArrayList();

                compatibility.Add(reader["compatibility"]);
                int movePower = int.Parse(reader["power"].ToString());
                int cooldown = int.Parse(reader["cooldown"].ToString());
                bool canBind = Convert.ToBoolean(reader["canBind"]);
                bool canBleed = Convert.ToBoolean(reader["canBleed"]);
                bool canParalyze = Convert.ToBoolean(reader["canParalyze"]);
                bool canPoison = Convert.ToBoolean(reader["canPoison"]);

                move = new Move(reader["moveName"].ToString(), reader["description"].ToString(), movePower, cooldown, NO_CURRENT_COOLDOWN, compatibility, canBind, canBleed, canParalyze, canPoison);

                moves.Add(move);
            }

            reader.Close();

            return moves;
        }
        #endregion

        #region Player CRUD
        public static void insertPlayer(string playerType, string playerName, string title, string description)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO PLAYER (playerType, playerName, title, description) VALUES (@playerType, @playerName, @title, @description);";
            cmd.Parameters.AddWithValue("@playerType", playerType);
            cmd.Parameters.AddWithValue("@playerName", playerName);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@description", description);

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Player created successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        } 

        public static void updatePlayer(string playerType, string playerName, string title, string description, int playerID)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = "UPDATE PLAYER SET playerType = @playerType, playerName = @playerName, title = @title, description = @description WHERE playerID = @playerID;";
            cmd.Parameters.AddWithValue("@playerType", playerType);
            cmd.Parameters.AddWithValue("@playerName", playerName);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@playerID", playerID);

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Player updated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static void deletePlayer(int playerID)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = "DELETE FROM PLAYER WHERE playerID = @playerID";
            cmd.Parameters.AddWithValue("@playerID", playerID);

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Player deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static object getPlayer(int playerID)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            Dictionary<string, string> playerStats;
            string playerType = "";
            string playerName = "";
            string title = "";
            string description = "";


            cmd.CommandText = "SELECT * FROM PLAYER WHERE playerID = @playerID";
            cmd.Parameters.AddWithValue("@playerID", playerID);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            reader = cmd.ExecuteReader();

            while (reader.Read() && reader != null)
            {
                playerType = reader["playerType"].ToString();
                playerName = reader["playerName"].ToString();
                title = reader["title"].ToString();
                description = reader["description"].ToString();
            }

            reader.Close();

            playerStats = getPlayerStats(playerID);

            switch (playerType)
            {
                case "archer":
                    Archer archer = new Archer(playerName);
                    archer.Title = title;
                    archer.Description = description;
                    archer.PlayerID = int.Parse(playerStats["playerID"]);
                    archer.MaxHealth = int.Parse(playerStats["maxHealth"]);
                    archer.CurrentHealth = int.Parse(playerStats["currentHealth"]);
                    archer.DamageTaken = int.Parse(playerStats["damageTaken"]);
                    archer.Level = int.Parse(playerStats["playerLevel"]);
                    archer.NumOfCoins = int.Parse(playerStats["numOfCoins"]);
                    archer.CurrentXP = int.Parse(playerStats["currentXP"]);
                    archer.Attack = int.Parse(playerStats["attack"]);
                    archer.Defense = int.Parse(playerStats["defense"]);
                    archer.Stamina = int.Parse(playerStats["stamina"]);
                    archer.Stealth = int.Parse(playerStats["stealth"]);
                    archer.Strength = int.Parse(playerStats["strength"]);
                    archer.Intellect = int.Parse(playerStats["intellect"]);
                    archer.Speed = int.Parse(playerStats["speed"]);
                    archer.MoveSet = getPlayerMoves(archer.PlayerID);

                    return archer;
                case "assassin":
                    Assassin assassin = new Assassin(playerName);
                    assassin.Title = title;
                    assassin.Description = description;
                    assassin.PlayerID = int.Parse(playerStats["playerID"]);
                    assassin.MaxHealth = int.Parse(playerStats["maxHealth"]);
                    assassin.CurrentHealth = int.Parse(playerStats["currentHealth"]);
                    assassin.DamageTaken = int.Parse(playerStats["damageTaken"]);
                    assassin.Level = int.Parse(playerStats["playerLevel"]);
                    assassin.NumOfCoins = int.Parse(playerStats["numOfCoins"]);
                    assassin.CurrentXP = int.Parse(playerStats["currentXP"]);
                    assassin.Attack = int.Parse(playerStats["attack"]);
                    assassin.Defense = int.Parse(playerStats["defense"]);
                    assassin.Stamina = int.Parse(playerStats["stamina"]);
                    assassin.Stealth = int.Parse(playerStats["stealth"]);
                    assassin.Strength = int.Parse(playerStats["strength"]);
                    assassin.Intellect = int.Parse(playerStats["intellect"]);
                    assassin.Speed = int.Parse(playerStats["speed"]);
                    assassin.MoveSet = getPlayerMoves(assassin.PlayerID);
                    return assassin;
                case "paladin":
                    Paladin paladin= new Paladin(playerName);
                    paladin.Title = title;
                    paladin.Description = description;
                    paladin.PlayerID = int.Parse(playerStats["playerID"]);
                    paladin.MaxHealth = int.Parse(playerStats["maxHealth"]);
                    paladin.CurrentHealth = int.Parse(playerStats["currentHealth"]);
                    paladin.DamageTaken = int.Parse(playerStats["damageTaken"]);
                    paladin.Level = int.Parse(playerStats["playerLevel"]);
                    paladin.NumOfCoins = int.Parse(playerStats["numOfCoins"]);
                    paladin.CurrentXP = int.Parse(playerStats["currentXP"]);
                    paladin.Attack = int.Parse(playerStats["attack"]);
                    paladin.Defense = int.Parse(playerStats["defense"]);
                    paladin.Stamina = int.Parse(playerStats["stamina"]);
                    paladin.Stealth = int.Parse(playerStats["stealth"]);
                    paladin.Strength = int.Parse(playerStats["strength"]);
                    paladin.Intellect = int.Parse(playerStats["intellect"]);
                    paladin.Speed = int.Parse(playerStats["speed"]);
                    paladin.MoveSet = getPlayerMoves(paladin.PlayerID);
                    return paladin;
                case "wizard":
                    Wizard wizard = new Wizard(playerName);
                    wizard.Title = title;
                    wizard.Description = description;
                    wizard.PlayerID = int.Parse(playerStats["playerID"]);
                    wizard.MaxHealth = int.Parse(playerStats["maxHealth"]);
                    wizard.CurrentHealth = int.Parse(playerStats["currentHealth"]);
                    wizard.DamageTaken = int.Parse(playerStats["damageTaken"]);
                    wizard.Level = int.Parse(playerStats["playerLevel"]);
                    wizard.NumOfCoins = int.Parse(playerStats["numOfCoins"]);
                    wizard.CurrentXP = int.Parse(playerStats["currentXP"]);
                    wizard.Attack = int.Parse(playerStats["attack"]);
                    wizard.Defense = int.Parse(playerStats["defense"]);
                    wizard.Stamina = int.Parse(playerStats["stamina"]);
                    wizard.Stealth = int.Parse(playerStats["stealth"]);
                    wizard.Strength = int.Parse(playerStats["strength"]);
                    wizard.Intellect = int.Parse(playerStats["intellect"]);
                    wizard.Speed = int.Parse(playerStats["speed"]);
                    wizard.MoveSet = getPlayerMoves(wizard.PlayerID);
                    return wizard;
                default:
                    return null;
            }

        }

        public static List<object> getAllPlayers()
        {
            List<object> players = new List<object>();
            List<string> playerData = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;

            cmd.CommandText = "SELECT * FROM player";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                playerData.Add(reader["playerID"].ToString());
            }

            reader.Close();

            foreach (string id in playerData)
            {
                players.Add(getPlayer(int.Parse(id)));
            }

            return players;
        }

        #endregion

        public static Dictionary<string, string> getPlayerStats(int playerID)
        {
            Dictionary<string, string> playerStats = new Dictionary<string, string>();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;

            cmd.CommandText = "SELECT * FROM PLAYER_STATS WHERE playerID = @playerID";
            cmd.Parameters.AddWithValue("@playerID", playerID);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                playerStats.Add("playerID", reader["playerID"].ToString());
                playerStats.Add("maxHealth", reader["maxHealth"].ToString());
                playerStats.Add("currentHealth", reader["currentHealth"].ToString());
                playerStats.Add("damageTaken", reader["damageTaken"].ToString());
                playerStats.Add("numOfCoins", reader["coins"].ToString());
                playerStats.Add("currentXP", reader["currentXP"].ToString());
                playerStats.Add("playerLevel", reader["playerLevel"].ToString());
                playerStats.Add("attack", reader["attack"].ToString());
                playerStats.Add("defense", reader["defense"].ToString());
                playerStats.Add("stamina", reader["stamina"].ToString());
                playerStats.Add("stealth", reader["stealth"].ToString());
                playerStats.Add("strength", reader["strength"].ToString());
                playerStats.Add("intellect", reader["intellect"].ToString());
                playerStats.Add("speed", reader["speed"].ToString());
            }

            reader.Close();

            return playerStats;
        }
        
        public static List<Move> getPlayerMoves(int playerID)
        {
            List<string> playerMoves = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;

            cmd.CommandText = "SELECT moveID FROM PLAYER_MOVES WHERE playerID = @playerID";
            cmd.Parameters.AddWithValue("@playerID", playerID);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    playerMoves.Add(reader["moveID"].ToString());
                }
            }

            List<Move> moveSet = new List<Move>();

            foreach (string moveID in playerMoves)
            {
                cmd.CommandText = "SELECT * FROM MOVE WHERE moveID = @moveID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@moveID", moveID);
                Move temp = new Move();

                using (reader = cmd.ExecuteReader())
                {
                    //grab all other values except compatibility. don't add the move to the moveset until after the compatibility has been retreived.
                    while (reader.Read())
                    {
                        temp.Name = reader["moveName"].ToString();
                        temp.Name = reader["description"].ToString();
                        temp.Power = int.Parse(reader["power"].ToString());
                        temp.Cooldown = int.Parse(reader["cooldown"].ToString());
                        temp.CurrentCooldown = 0;
                        if (reader["canBind"].ToString() == "true")
                        {
                            temp.CanBind = true;
                        }
                        else
                        {
                            temp.CanBind = false;
                        }

                        if (reader["canBleed"].ToString() == "true")
                        {
                            temp.CanBleed = true;
                        }
                        else
                        {
                            temp.CanBleed = false;
                        }

                        if (reader["canPoison"].ToString() == "true")
                        {
                            temp.CanPoison = true;
                        }
                        else
                        {
                            temp.CanPoison = false;
                        }

                        if (reader["canParalyze"].ToString() == "true")
                        {
                            temp.CanParalyze = true;
                        }
                        else
                        {
                            temp.CanParalyze = false;
                        } 
                    }

                }

                //Grab compatibilities from move_compatibility here after all other move values have been populated.

                cmd.CommandText = "SELECT compatibleType FROM MOVE_COMPATIBILITY WHERE moveID = @moveID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@moveID", moveID);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp.CompatiblePlayers.Add(reader["compatibleType"].ToString());
                    }
                }

                moveSet.Add(temp);

            }

            return moveSet;
        }
    }
}
