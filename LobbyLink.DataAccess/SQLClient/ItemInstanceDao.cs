using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.SQLClient;
public class ItemInstanceDao : BaseDao, IFItemInstanceDao
{
    public ItemInstanceDao(string connectionString) : base(connectionString) { }
 
    public bool DeleteItemInstanceById(int id)
    {
        try
        {
            var query = "DELETE FROM ItemInstance WHERE Id=@Id";
            using var connection = CreateConnection();
            var rowsAffected = connection.Execute(query, new { id });
            return rowsAffected > 0;
        }

        catch (Exception ex)
        {
            throw new Exception($"Error while trying to delete ItemInstance with id='{id}'. Error was: '{ex.Message}'", ex);
        }
    }

    public IEnumerable<ItemInstance> GetAllItemInstance()
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
    {
        try
        {
            var query = "SELECT * FROM ItemInstance WHERE Id=@Id";
            using var connection = CreateConnection();
            return connection.QuerySingleOrDefault<ItemInstance>(query, new { id });
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while trying to get ItemInstance with id='{id}'. Error was: '{ex.Message}'", ex);
        }
    }

    public int InsertItemInstance(ItemInstance itemInstance)
    {
        //INSERT INTO Author (Email, BlogTitle, PasswordHash) OUTPUT INSERTED.Id  VALUES (@Email, @BlogTitle, @PasswordHash)
        try
        {
            var query = "INSERT INTO ItemInstance (itemDefinitonId, accountId) OUTPUT INSERTED.Id  VALUES (@ItemDefinitionId_FK, @AccountId_FK); ";
            using var connection = CreateConnection();
            var newId = connection.QuerySingle<int>(query, itemInstance);
            return newId;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while trying to insert Item Instance with id='{itemInstance.ItemInstanceId}'. Error was: '{ex.Message}'", ex);
        }
    }

    public bool UpdateItemInstance(ItemInstance itemInstance)
    {
        try
        {
            var query = "UPDATE ItemInstance SET attributes WHERE Id=@Id";
            using var connection = CreateConnection();
            var rowsAffected = connection.Execute(query, itemInstance);
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while trying to insert Item Instance with id='{itemInstance.ItemInstanceId}'. Error was: '{ex.Message}'", ex);
        }
    }
}
