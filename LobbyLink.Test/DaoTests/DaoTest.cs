using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;

namespace LobbyLink.Test.DaoTests;

public class DaoTest
{
    private IFItemInstanceDao _itemInstanceDao;
    private IFAccountDao _accountDao;
    private IFGameDao _gameDao;
    private IFItemDefinitionDao _itemDefinitionDao;

    private List<int> _tempItemInstanceIds;
    private List<int> _tempAccountIds;
    private List<int> _tempGameIds;
    private List<int> _tempItemDefinitionIds;

    [SetUp]
    public void Setup()
    {
        _itemInstanceDao = new ItemInstanceDao(TestSettings.CONNECTION_STRING);
        _gameDao = new GameDao(TestSettings.CONNECTION_STRING);
        _itemDefinitionDao = new ItemDefinitionDao(TestSettings.CONNECTION_STRING);
        _accountDao = new AccountDao(TestSettings.CONNECTION_STRING);

        _tempItemInstanceIds = new List<int>();
        _tempAccountIds = new List<int>();
        _tempGameIds = new List<int>();
        _tempItemDefinitionIds = new List<int>();
    }

    [TearDown]
    public void CleanUp()
    {
        foreach (var itemInstanceId in _tempItemInstanceIds)
        {
            _itemInstanceDao.DeleteItemInstance(itemInstanceId);
        }

        foreach (var itemDefinitionId in _tempItemDefinitionIds)
        {
            _itemDefinitionDao.DeleteItemDefinition(itemDefinitionId);
        }

        foreach (var gameId in _tempGameIds)
        {
            _gameDao.DeleteGame(gameId);
        }

        foreach (var accountId in _tempAccountIds)
        {
            _accountDao.DeleteAccount(accountId);
        }
    }
     
    [Test]
    public void GetItemInstanceById_ShouldReturnItemInstanceObjectWithAttributes()
    {
        //Arrange
        var account = new Account
        {
            UserName = "TestUser",
            FirstName = "Test",
            SurName = "User",
            Email = "test@test.com",
            PhoneNo = "12345678",
            Level = 1,
            Type = "User"
        };

        int tempAccountId = _accountDao.InsertAccount(account);
        _tempAccountIds.Add(tempAccountId);

        var game = new Game
        {
            GameTitle = "TestGame",
            GameStudio = "TestStudio"
        };

        int tempGameId = _gameDao.InsertGame(game);
        _tempGameIds.Add(tempGameId);

        var itemDefinition = new ItemDefinition
        {
            ItemName = "TestItem",
            ItemDescription = "TestDescription",
            ItemImageUrl = "",
            GameId = tempGameId
        };

        int tempItemDefinitionId = _itemDefinitionDao.InsertItemDefinition(itemDefinition);
        _tempItemDefinitionIds.Add(tempItemDefinitionId);

        var itemInstance = new ItemInstance
        {
            ItemDefinitionId = tempItemDefinitionId,
            AccountId = tempAccountId
        };

        int tempItemInstanceId = _itemInstanceDao.CreateItemInstance(itemInstance);
        _tempItemInstanceIds.Add(tempItemInstanceId);

        //Act
        ItemInstance? result = _itemInstanceDao.GetItemInstanceById(tempItemInstanceId);

        //Assert
        Assert.That(result, Is.Not.Null, "Expected an ItemInstance object to be returned");
        Assert.That(result.Account, Is.Not.Null, "Expected Account to be loaded");
        Assert.That(result.ItemDefinition, Is.Not.Null, "Expected ItemDefinition to be loaded");
        Assert.That(result.ItemDefinition.Game, Is.Not.Null, "Expected Game to be loaded");
    }

    [Test]
    public void GetItemInstancesByAccount_ShouldReturnItemInstances_WhenAccountHasItemInstances()
    {
        //Arrange
        var account = new Account
        {
            UserName = "TestUser2",
            FirstName = "Test",
            SurName = "User2",
            Email = "test2@test.com",
            PhoneNo = "87654321",
            Level = 1,
            Type = "User"
        };
        int tempAccountId = _accountDao.InsertAccount(account);
        _tempAccountIds.Add(tempAccountId);

        var game = new Game
        {
            GameTitle = "TestGame2",
            GameStudio = "TestStudio2"
        };
        int tempGameId = _gameDao.InsertGame(game);
        _tempGameIds.Add(tempGameId);

        var itemDefinition = new ItemDefinition
        {
            ItemName = "TestItem2",
            ItemDescription = "TestDescription",
            ItemImageUrl = "",
            GameId = tempGameId
        };
        int tempItemDefinitionId = _itemDefinitionDao.InsertItemDefinition(itemDefinition);
        _tempItemDefinitionIds.Add(tempItemDefinitionId);

        // Laver 3 ItemInstances for denne Account
        for (int i = 0; i < 3; i++)
        {
            var itemInstance = new ItemInstance
            {
                ItemDefinitionId = tempItemDefinitionId,
                AccountId = tempAccountId
            };
            int itemInstanceId = _itemInstanceDao.CreateItemInstance(itemInstance);
            _tempItemInstanceIds.Add(itemInstanceId);
        }

        //Act
        IEnumerable<ItemInstance> testItemInstances = _itemInstanceDao.GetAllItemInstancesByAccountId(tempAccountId);

        //Assert
        Assert.That(testItemInstances.Count(), Is.EqualTo(3), "Should return exactly 3 Item Instances for this User");
    }
}
