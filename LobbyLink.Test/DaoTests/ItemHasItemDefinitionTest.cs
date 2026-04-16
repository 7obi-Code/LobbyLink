using LobbyLink.DataAccess.SQLClient;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.Test.DaoTests
{
    public class ItemHasItemDefinitionTest
    {
        ItemInstanceDao _itemInstanceDao;
        ItemDefinitionDao _itemDefinitionDao;
        List<int> _cleanupItemInstanceIds = new List<int>();
        List<int> _cleanupItemDefinitionIds = new List<int>();

        [SetUp]
        public void Setup()
        {
            _itemInstanceDao = new ItemInstanceDao(TestSettings.CONNECTION_STRING);
            _itemDefinitionDao = new ItemDefinitionDao(TestSettings.CONNECTION_STRING);
        }

        [TearDown]
        public void CleanUp()
        {
            // Clean up test blog posts
            foreach (var id in _cleanupItemInstanceIds)
            {
                try
                {
                    _itemInstanceDao.DeleteItemInstanceById(id);
                }
                catch { }
            }
            _cleanupItemInstanceIds.Clear();

            // Clean up test authors
            foreach (var id in _cleanupItemDefinitionIds)
            {
                try
                {
                    _itemDefinitionDao.DeleteItemDefinition(id);
                }
                catch { }
            }
            _cleanupItemDefinitionIds.Clear();
        }

        [Test]
        public void GetItemInstanceById_ShouldReturnItemInstance_WhenItExists()
        {
            // Arrange
            var itemDef = CreateTestItemDefinition();
            var itemInstance = CreateTestItemInstance(itemDef.ItemDefinitionId);

            // Act
            var result = _itemInstanceDao.GetItemInstanceById(itemInstance.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(itemInstance.Id));
            Assert.That(result.ItemDefinitionId_FK, Is.EqualTo(itemDef.ItemDefinitionId));
        }

        #region Helper Methods

        private int GenerateUniqueId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }

        private ItemDefinition CreateTestItemDefinition()
        {
            var testGame = new Game(
                "Test Game",
                "TEst Studio",
                new List<ItemProperty>(),
                new List<ItemInstanceProperty>(),
                new List<ItemDefinition>()
            );

            var itemDef = new ItemDefinition(0, $"Test ItemDefinition + {Guid.NewGuid()}", "test.png", "test", 1, testGame, new List<ItemPropertyLine>());
            

            int newId = _itemDefinitionDao.InsertItemDefinition(itemDef);
            _cleanupItemDefinitionIds.Add(newId);

            itemDef.ItemDefinitionId = newId;
            return itemDef;
        }

        private ItemInstance CreateTestItemInstance(int itemDefinitionId)
        {
            var testUserAccount = new UserAccount(
                0,
                "TestAccount",
                1, // level
                new Wallet(), // adjust if Wallet constructor differs
                new List<Game>(),
                new List<Listing>(),
                new List<ItemInstance>()
            );

            var itemInstance = new ItemInstance(true, testUserAccount, 0, new List<Listing>(), new List<ItemInstancePropertyLine>(), itemDef, 0);

            int newId = _itemInstanceDao.InsertItemInstance(itemInstance);
            _cleanupItemInstanceIds.Add(newId);

            itemInstance.Id = newId;
            return itemInstance;
        }

        #endregion

    }
}
