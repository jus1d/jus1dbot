﻿using System.Data;
using ducker.Config;
using MySqlConnector;

namespace ducker;

public class Database
{
    /// <summary>
    /// MySQL Database connection
    /// </summary>
    private MySqlConnection _connection = new (ConfigJson.GetConfigField().MySqlConnectionString);

    /// <summary>
    /// Method for open database connection
    /// </summary>
    public void OpenConnection()
    {
        if (_connection.State == ConnectionState.Closed)
            _connection.Open();
    }

    /// <summary>
    /// Method for close database connection
    /// </summary>
    public void CloseConnection()
    {
        if (_connection.State == ConnectionState.Open)
            _connection.Close();
    }

    /// <summary>
    /// Get database connection
    /// </summary>
    /// <returns>Return database connection</returns>
    public MySqlConnection GetConnection()
    {
        return _connection;
    }

    /// <summary>
    /// Get music channel ID from database
    /// </summary>
    /// <param name="guildId">Guild ID, that contains this needed channel</param>
    /// <returns>Return music channel ID</returns>
    public static ulong GetMusicChannel(ulong guildId)
    {
        Database database = new Database();
        DataTable table = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        MySqlCommand command = new MySqlCommand($"SELECT `musicChannelId` FROM `ducker` WHERE `guildId` = {guildId}", database.GetConnection());
        adapter.SelectCommand = command;
        adapter.Fill(table);
        if (table.Rows.Count > 0)
            return ulong.Parse(table.Rows[0].ItemArray[0].ToString());
        return 0;
    }

    /// <summary>
    /// Get command line channel ID from database
    /// </summary>
    /// <param name="guildId">Guild ID, that contains this needed channel</param>
    /// <returns>Return command line channel ID</returns>
    public static ulong GetLogsChannel(ulong guildId)
    {
        Database database = new Database();
        DataTable table = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        MySqlCommand command = new MySqlCommand($"SELECT `logsChannelId` FROM `ducker` WHERE `guildId` = {guildId}", 
            database.GetConnection());
        adapter.SelectCommand = command;
        adapter.Fill(table);
        if (table.Rows.Count > 0)
            return ulong.Parse(table.Rows[0].ItemArray[0].ToString());
        return 0;
    }
    
    /// <summary>
    /// Get server logs channel ID from database
    /// </summary>
    /// <param name="guildId">Guild ID, that contains this needed channel</param>
    /// <returns>Return server logs channel ID</returns>
    public static ulong GetCmdChannel(ulong guildId)
    {
        Database database = new Database();
        DataTable table = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        MySqlCommand command = new MySqlCommand($"SELECT `cmdChannelId` FROM `ducker` WHERE `guildId` = {guildId}", 
            database.GetConnection());
        adapter.SelectCommand = command;
        adapter.Fill(table);
        if (table.Rows.Count > 0)
            return ulong.Parse(table.Rows[0].ItemArray[0].ToString());
        return 0;
    }

    /// <summary>
    /// Get mute role ID from database
    /// </summary>
    /// <param name="guildId">Guild ID, that contains this needed channel</param>
    /// <returns>Return mute role ID</returns>
    public static ulong GetMuteRoleId(ulong guildId)
    {
        Database database = new Database();
        DataTable table = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        database.OpenConnection();
        MySqlCommand command = new MySqlCommand($"SELECT `muteRoleId` FROM `ducker` WHERE `guildId` = {guildId}", database.GetConnection());
        adapter.SelectCommand = command;
        adapter.Fill(table);
        if (table.Rows.Count > 0)
        {
            try
            {
                return ulong.Parse(table.Rows[0].ItemArray[0].ToString());
            }
            catch
            {
                return 0;
            }
        }
        return 0;
    }
}