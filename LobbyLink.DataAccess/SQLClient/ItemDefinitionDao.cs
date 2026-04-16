using Dapper;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;

namespace LobbyLink.DataAccess.SQLClient
{
    public class ItemDefinitionDao : BaseDao, IFItemDefinitionDao
    {
        public ItemDefinitionDao(string connectionString) : base(connectionString) { }

        public ItemDefinition? GetItemDefinitionById(int id)
        {
            try
            {
                var query = @"SELECT
                                itemDefinitionId AS ItemDefinitionId,
                                itemName AS ItemName,
                                itemImageUrl AS ItemImageUrl,
                                itemDescription AS ItemDescription,
                                gameId AS GameId
                              FROM ItemDefinition
                              WHERE itemDefinitionId = @Id";
                using var connection = CreateConnection();
                return connection.QuerySingleOrDefault<ItemDefinition>(query, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get item definition with id='{id}'. Error was: '{ex.Message}'", ex);
            }
        }
        public IEnumerable<ItemDefinition> GetAllItemDefinitions()
        {
            try
            {
                var query = @"SELECT
                                itemDefinitionId AS ItemDefinitionId,
                                itemName       AS ItemName,
                                itemImageUrl   AS ItemImageUrl,
                                itemDescription AS ItemDescription,
                                gameId      AS GameId
                              FROM ItemDefinition";

                using var connection = CreateConnection();
                return connection.Query<ItemDefinition>(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to get all item definitions. Error was: '{ex.Message}'", ex);
            }
        }

        public int InsertItemDefinition(ItemDefinition itemDefinition)
        {
            try
            {
                var query = @"INSERT INTO ItemDefinition 
                (itemName, itemImageUrl, itemDescription, itemTags, gameId)
                OUTPUT INSERTED.itemDefinitionId
                VALUES (@ItemName, @ItemImageUrl, @ItemDescription, @ItemTags, @GameId)";

                using var connection = CreateConnection();
                return connection.QuerySingle<int>(query, itemDefinition);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to insert item definition with name='{itemDefinition.ItemName}'. Error was: '{ex.Message}'", ex);
            }
        }

        public bool UpdateItemDefiniton(ItemDefinition itemDefinition)
        {
            try
            {
                var query = @"UPDATE ItemDefinition
                              SET itemName = @ItemName,
                                  itemImageUrl = @ItemImageUrl,
                                  itemDescription = @ItemDescription,
                                  gameId = @GameId
                              WHERE itemDefinitionId = @ItemDefinitionId";

                using var connection = CreateConnection();
                var rowsAffected = connection.Execute(query, itemDefinition);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to update item definition with id='{itemDefinition.ItemDefinitionId}'. Error was: '{ex.Message}'", ex);
            }
        }

        public bool DeleteItemDefinition(int id)
        {
            try
            {
                var query = "DELETE FROM ItemDefinition WHERE itemDefinitionId = @Id";

                using var connection = CreateConnection();
                var rowsAffected = connection.Execute(query, new { Id = id });
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying to delete item definition with id='{id}'. Error was: '{ex.Message}'", ex);
            }
        }
    }
}
