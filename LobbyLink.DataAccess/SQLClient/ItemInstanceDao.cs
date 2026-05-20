using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.SQLClient;
public class ItemInstanceDao : BaseDao, IFItemInstanceDao
{
    public ItemInstanceDao(string connectionString) : base(connectionString) {}

    //DAO metode til at oprette en ItemInstance ud fra et itemInstance objekt
    public int CreateItemInstance(ItemInstance itemInstance)
    {
        try
        {
            var query = @"
            INSERT INTO ItemInstance (accountId_fk, itemDefinitionId_fk)
            OUTPUT INSERTED.itemInstanceId
            VALUES (@AccountId, @ItemDefinitionId);";

            using var connection = CreateConnection();

            int newId = connection.ExecuteScalar<int>(query, new
            {
                itemInstance.AccountId,
                itemInstance.ItemDefinitionId
            });

            return newId;
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"Error while creating ItemInstance. Error was: '{ex.Message}'", ex);
        }
    }

    //DAO metode til at finde alle iteminstances, inklusiv oprettelse af de typer objekter som en ItemInstance indeholder
    public IEnumerable<ItemInstance> GetAllItemInstances() 
    {
        try {
            var query = @"SELECT
                ii.itemInstanceId,
                ii.accountId_fk,
                ii.itemDefinitionId_fk,
                af.accountId,
                af.userName,
                af.firstName,
                af.surName,
                af.email,
                af.phoneNo,
                af.level,
                af.type,
                idf.itemDefinitionId,
                idf.itemName,
                idf.itemImageUrl,
                idf.itemDescription,
                idf.gameId_fk,
                gf.gameId,
                gf.gameTitle,
                gf.gameStudio

            FROM ItemInstance ii

            INNER JOIN Account af ON af.accountId = ii.accountId_fk
            INNER JOIN ItemDefinition idf ON idf.itemDefinitionId = ii.itemDefinitionId_fk
            INNER JOIN Game gf ON gf.gameId = idf.gameId_fk";

            using var connection = CreateConnection();

            List<ItemInstance> itemInstances = connection.Query<ItemInstance, Account, ItemDefinition, Game, ItemInstance>
                (query, 
                
                (instance, account, definition, game) =>
                {
                    instance.Account = account;
                    instance.ItemDefinition = definition;
                    instance.ItemDefinition.Game = game;
                    return instance;
                },

                splitOn: "accountId, itemDefinitionId, gameId").ToList();
            
            return itemInstances;
        }
        catch (Exception ex) {
            throw new Exception($"Error while trying to get all ItemInstances. Error was: '{ex.Message}'", ex);
        }
    }

    //DAO metode til at finde en ItemInstance ud fra et bruger Id
    public IEnumerable<ItemInstance> GetAllItemInstancesByAccountId(int accountId)
    {
        try
        {
            var query = @"
            SELECT
                ii.itemInstanceId,
                ii.accountId_fk,
                ii.itemDefinitionId_fk,
                af.accountId,
                af.userName,
                af.firstName,
                af.surName,
                af.email,
                af.phoneNo,
                af.level,
                af.type,
                idf.itemDefinitionId,
                idf.itemName,
                idf.itemImageUrl,
                idf.itemDescription,
                idf.gameId_fk,
                gf.gameId,
                gf.gameTitle,
                gf.gameStudio

            FROM ItemInstance ii
            INNER JOIN Account af ON af.accountId = ii.accountId_fk
            INNER JOIN ItemDefinition idf ON idf.itemDefinitionId = ii.itemDefinitionId_fk
            INNER JOIN Game gf ON gf.gameId = idf.gameId_fk

            WHERE ii.accountId_fk = @accountId;";

            using var connection = CreateConnection();

            List<ItemInstance> itemInstances = connection.Query<ItemInstance, Account, ItemDefinition, Game, ItemInstance>
                (query, (instance, account, definition, game) =>
                {
                    instance.Account = account;
                    instance.ItemDefinition = definition;
                    instance.ItemDefinition.Game = game;
                    return instance;
                },
                new { accountId },
                splitOn: "accountId, itemDefinitionId, gameId"
                ).ToList();

            return itemInstances;
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"Error while trying to get all ItemInstances for accountId='{accountId}'. Error was: '{ex.Message}'", ex);
        }
    }

    //DAO metode til at finde en ItemInstance ud fra et iteminstance id
    public ItemInstance GetItemInstanceById(int itemInstanceId)
    {
        try
        {
            var query = @"
            SELECT
                ii.itemInstanceId,
                ii.accountId_fk AS AccountId, 
                ii.itemDefinitionId_fk AS ItemDefinitionId,
                af.accountId,
                af.userName,
                af.firstName,
                af.surName,
                af.email,
                af.phoneNo,
                af.level,
                af.type,
                idf.itemDefinitionId,
                idf.itemName,
                idf.itemImageUrl,
                idf.itemDescription,
                idf.gameId_fk,
                gf.gameId,
                gf.gameTitle,
                gf.gameStudio

            FROM ItemInstance ii
            INNER JOIN Account af ON af.accountId = ii.accountId_fk
            INNER JOIN ItemDefinition idf ON idf.itemDefinitionId = ii.itemDefinitionId_fk
            INNER JOIN Game gf ON gf.gameId = idf.gameId_fk

            WHERE ii.itemInstanceId = @itemInstanceId;";

            using var connection = CreateConnection();

            ItemInstance? itemInstance = connection.Query<ItemInstance, Account, ItemDefinition, Game, ItemInstance>
                (query, (instance, account, definition, game) =>
                {
                    instance.Account = account;
                    instance.ItemDefinition = definition;
                    instance.ItemDefinition.Game = game;
                    return instance;
                },
                new { itemInstanceId },
                splitOn: "accountId, itemDefinitionId, gameId"
                ).SingleOrDefault();

            return itemInstance;
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"Error while trying to get Item Instance with Id='{itemInstanceId}'. Error was: '{ex.Message}'", ex);
        }
    }

    //DAO metode til at slette en ItemInstance ud fra et Id
    public bool DeleteItemInstance(int id)
    {
        try
        {
            var query = "DELETE FROM ItemInstance WHERE itemInstanceId = @Id";

            using var connection = CreateConnection();
            var rowsAffected = connection.Execute(query, new { Id = id });

            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"Error deleting ItemInstance with id='{id}'. Error: '{ex.Message}'", ex);
        }
    }
}
