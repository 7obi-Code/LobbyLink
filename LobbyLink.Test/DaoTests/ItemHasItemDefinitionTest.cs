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
        public void GetItemInstanceById_ShouldReturnNull_WhenItDoesNotExist()
        {
            // Arrange
            int nonExistentId = 999999;

            // Act
            var result = _itemInstanceDao.GetItemInstanceById(nonExistentId);

            // Assert
            Assert.That(result, Is.Null, "ItemInstance should not be found");
        }

        [Test]
        public void DeleteItemInstance_ShouldReturnFalse_WhenItemInstanceDoesNotExist()
        {
            // Arrange
            int nonExistentId = 999999;

            // Act
            bool result = _itemInstanceDao.DeleteItemInstanceById(nonExistentId);

            // Assert
            Assert.That(result, Is.False, "Delete should return false for non-existent item");
        }

        [Test]
        public void GetAllItemInstances_ShouldReturnItems_WhenTheyExist()
        {
            // Arrange
            var itemDef = CreateTestItemDefinition();
            CreateTestItemInstance(itemDef.ItemDefinitionId);
            CreateTestItemInstance(itemDef.ItemDefinitionId);

            // Act
            var result = _itemInstanceDao.GetAllItemInstance();

            // Assert
            Assert.That(result, Is.Not.Null, "Collection should not be null");
            Assert.That(result.Count(), Is.GreaterThanOrEqualTo(2));
        }

        [Test]
        public void UpdateItemInstance_ShouldReturnTrue_WhenUpdated()
        {
            // Arrange
            var itemDef = CreateTestItemDefinition();
            var itemInstance = CreateTestItemInstance(itemDef.ItemDefinitionId);

            var newItemDef = CreateTestItemDefinition();
            itemInstance.ItemDefinitionId_FK = newItemDef.ItemDefinitionId;

            // Act
            bool result = _itemInstanceDao.UpdateItemInstance(itemInstance);

            // Assert
            Assert.That(result, Is.True, "Update should return true");

            var updated = _itemInstanceDao.GetItemInstanceById(itemInstance.ItemInstanceId);
            Assert.That(updated, Is.Not.Null, "Updated item should exist");
            Assert.That(updated.ItemDefinitionId_FK, Is.EqualTo(newItemDef.ItemDefinitionId));
        }

        [Test]
        public void GetItemInstanceById_ShouldReturnItemInstance_WhenItExists()
        {
            // Arrange
            var itemDef = CreateTestItemDefinition();
            var itemInstance = CreateTestItemInstance(itemDef.ItemDefinitionId);

            // Act
            var result = _itemInstanceDao.GetItemInstanceById(itemInstance.ItemInstanceId);

            // Assert
            Assert.That(result, Is.Not.Null, "ItemInstance was not found");
            Assert.That(result.ItemInstanceId, Is.EqualTo(itemInstance.ItemInstanceId));
            Assert.That(result.ItemDefinitionId_FK, Is.EqualTo(itemDef.ItemDefinitionId));
        }

        [Test]
        public void InsertItemInstance_ShouldReturnId_WhenInserted()
        {
            // Arrange
            var itemDef = CreateTestItemDefinition();

            var itemInstance = new ItemInstance
            {
                ItemDefinitionId_FK = itemDef.ItemDefinitionId
            };

            // Act
            int newId = _itemInstanceDao.InsertItemInstance(itemInstance);
            _cleanupItemInstanceIds.Add(newId);

            var inserted = _itemInstanceDao.GetItemInstanceById(newId);

            // Assert
            Assert.That(newId, Is.GreaterThan(0), "Insert did not return a valid ID");
            Assert.That(inserted, Is.Not.Null, "Inserted ItemInstance was not found");
            Assert.That(inserted.ItemDefinitionId_FK, Is.EqualTo(itemDef.ItemDefinitionId));
        }

        [Test]
        public void DeleteItemInstance_ShouldReturnTrue_WhenDeleted()
        {
            // Arrange
            var itemDef = CreateTestItemDefinition();
            var itemInstance = CreateTestItemInstance(itemDef.ItemDefinitionId);

            _cleanupItemInstanceIds.Remove(itemInstance.ItemInstanceId);

            // Act
            bool result = _itemInstanceDao.DeleteItemInstanceById(itemInstance.ItemInstanceId);
            var deleted = _itemInstanceDao.GetItemInstanceById(itemInstance.ItemInstanceId);

            // Assert
            Assert.That(result, Is.True, "Delete should return true");
            Assert.That(deleted, Is.Null, "Deleted ItemInstance should not be found");
        }



        #region Helper Methods

        private int GenerateUniqueId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }

        private ItemDefinition CreateTestItemDefinition()
        {
            var itemDef = new ItemDefinition
            {
                ItemName = $"Test ItemDefinition {Guid.NewGuid()}",
                ItemImageUrl = "test.png",
                ItemDescription = "test",
                ItemTags = "test",
                GameId = 1  
            };

            int newId = _itemDefinitionDao.InsertItemDefinition(itemDef);
            _cleanupItemDefinitionIds.Add(newId);

            itemDef.ItemDefinitionId = newId;
            return itemDef;
        }

        private ItemInstance CreateTestItemInstance(int itemDefinitionId)
        {
            var itemInstance = new ItemInstance
            {
                ItemDefinitionId_FK = itemDefinitionId,
                AccountId_FK = 1
            };

            int newId = _itemInstanceDao.InsertItemInstance(itemInstance);
            _cleanupItemInstanceIds.Add(newId);

            itemInstance.ItemInstanceId = newId;
            return itemInstance;
        }

        #endregion

    }
}
