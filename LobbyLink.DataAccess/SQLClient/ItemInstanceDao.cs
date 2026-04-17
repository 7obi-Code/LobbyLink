using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.SQLClient;
public class ItemInstanceDao : BaseDao, IFItemInstanceDao
{
    public IFUserAccountDao userAccountDao { get; set; }
    public IFItemDefinitionDao itemDefinitionDao { get; set; }

    public ItemInstanceDao(string connectionString) : base(connectionString) 
    {
        userAccountDao = new UserAccountDao(connectionString);
        itemDefinitionDao = new ItemDefinitionDao(connectionString);
    }
 
    public bool DeleteItemInstanceById(int id)
    {
        try
        {
            var query = "DELETE FROM ItemInstance WHERE ItemInstanceId=@Id";
            using var connection = CreateConnection();
            var rowsAffected = connection.Execute(query, new { id });
            return rowsAffected > 0;
        }

        catch (Exception ex)
        {
            throw new Exception($"Error while trying to delete ItemInstance with id='{id}'. Error was: '{ex.Message}'", ex);
        }
    }

    public IEnumerable<ItemInstance> GetAllItemInstances()
<<<<<<< Updated upstream
    {
        try
        {
            var query = "SELECT * FROM ItemInstance";
            using var connection = CreateConnection();
            return connection.Query<ItemInstance>(query);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while trying to get all ItemInstances. Error was: '{ex.Message}'", ex);
        }
    }

    public ItemInstance? GetItemInstanceById(int id)
=======
>>>>>>> Stashed changes
    {
        try
        {
            var query = @"
            SELECT
                ii.itemInstanceId,
                ii.accountId_fk,
                ii.itemDefinitionId_fk
                a.accountId,
                a.userName,
                a.firstName,
                a.surName,
                a.email,
                a.phoneNo,
                a.level,
                a.type,
                a.walletId_fk,
                idf.itemDefinitionId,
                idf.itemName,
                idf.itemImageUrl,
                idf.itemDescription,
                idf.gameId_fk
            FROM ItemInstance ii
            INNER JOIN Account a
                ON a.accountId = ii.accountId_fk
            INNER JOIN ItemDefinition idf
                ON idf.itemDefinitionId = ii.itemDefinitionId_fk
            WHERE ii.accountId_fk = @accountId;";

            using var connection = CreateConnection();

            List<ItemInstance> itemInstances = connection.Query<ItemInstance, Account, ItemDefinition, ItemInstance>
                (query, (instance, account, definition) =>
                {
                    instance.Account = account;
                    instance.ItemDefinition = definition;
                    return instance;
                },
                new { accountId },
                splitOn: "accountId,itemDefinitionId"
                ).ToList();

            return itemInstances;
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"Error while trying to get all ItemInstances for accountId='{accountId}'. Error was: '{ex.Message}'", ex);
        }
        new Exception($"Error while trying to get all ItemInstances. Error was: '{ex.Message}'", ex);
        }
    }

    public IEnumerable<ItemInstance> GetAllItemInstancesByAccountId(int accountId)
    {
        try
        {
            var query = @"
            SELECT
                ii.itemInstanceId,
                ii.accountId_fk,
                ii.itemDefinitionId_fk
                af.accountId,
                af.userName,
                af.firstName,
                af.surName,
                af.email,
                af.phoneNo,
                af.level,
                af.type,
                af.walletId_fk,
                idf.itemDefinitionId,
                idf.itemName,
                idf.itemImageUrl,
                idf.itemDescription,
                idf.gameId_fk
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

    public IEnumerable<ItemInstance> GetAllItemInstancesByUserId()
    {
        throw new NotImplementedException();
    }
}
