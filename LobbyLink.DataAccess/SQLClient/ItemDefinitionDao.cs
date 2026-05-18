using Dapper;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;

namespace LobbyLink.DataAccess.SQLClient
{
    public class ItemDefinitionDao : BaseDao, IFItemDefinitionDao
    {
        public ItemDefinitionDao(string connectionString) : base(connectionString) { }

        //DAO metode til at finde en ItemDefinition ud fra et Id
        public ItemDefinition? GetItemDefinitionById(int id)
        {
            try
            {
                var query = @"SELECT
                                itemDefinitionId AS ItemDefinitionId,
                                itemName         AS ItemName,
                                itemImageUrl     AS ItemImageUrl,
                                itemDescription  AS ItemDescription,
                                gameId_fk        AS GameId
                              FROM ItemDefinition
                              WHERE itemDefinitionId = @Id";

                using var connection = CreateConnection();
                return connection.QuerySingleOrDefault<ItemDefinition>(query, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error getting item definition with id='{id}'. Error: '{ex.Message}'", ex);
            }
        }

        //DAO metode til at finde alle ItemDefinitions
        public IEnumerable<ItemDefinition> GetAllItemDefinitions()
        {
            try
            {
                var query = @"SELECT
                                itemDefinitionId AS ItemDefinitionId,
                                itemName         AS ItemName,
                                itemImageUrl     AS ItemImageUrl,
                                itemDescription  AS ItemDescription,
                                gameId_fk        AS GameId
                              FROM ItemDefinition";

                using var connection = CreateConnection();
                return connection.Query<ItemDefinition>(query);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error getting all item definitions. Error: '{ex.Message}'", ex);
            }
        }

        //DAO metode til at indsætte en ItemDefinition i databasen
        public int InsertItemDefinition(ItemDefinition itemDefinition)
        {
            try
            {
                var query = @"INSERT INTO ItemDefinition 
                              (itemName, itemImageUrl, itemDescription, gameId_fk)
                              OUTPUT INSERTED.itemDefinitionId
                              VALUES (@ItemName, @ItemImageUrl, @ItemDescription, @GameId)";

                using var connection = CreateConnection();
                return connection.QuerySingle<int>(query, itemDefinition);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error inserting item definition with name='{itemDefinition.ItemName}'. Error: '{ex.Message}'", ex);
            }
        }

        //DAO metode til at fjerne en ItemDefinition ud fra et Id
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
                throw new Exception(
                    $"Error deleting item definition with id='{id}'. Error: '{ex.Message}'", ex);
            }
        }

        //DAO metode til at opdatere en ItemDefinition
        public bool UpdateItemDefinition(ItemDefinition itemDefinition)
        {
            try
            {
                var query = @"UPDATE ItemDefinition
                              SET itemName        = @ItemName,
                                  itemImageUrl    = @ItemImageUrl,
                                  itemDescription = @ItemDescription,
                                  gameId_fk       = @GameId
                              WHERE itemDefinitionId = @ItemDefinitionId";

                using var connection = CreateConnection();
                var rowsAffected = connection.Execute(query, itemDefinition);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error updating item definition with id='{itemDefinition.ItemDefinitionId}'. Error: '{ex.Message}'", ex);
            }
        }
    }
}