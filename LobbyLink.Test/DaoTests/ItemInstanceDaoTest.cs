using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.SQLClient;
using System.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.Test.DaoTests;

public class ItemInstanceDaoTest
{

    IFItemInstanceDao _itemInstanceDao;

    [SetUp]
    public void Setup()
    {
        _itemInstanceDao = new ItemInstanceDao(TestSettings.CONNECTION_STRING);
    }

    [Test]
    public void GetItemInstancesByAccount_ShouldReturnItemInstances_WhenAccountHasItemInstances()
    {
        //Arrange
        //Vi benytter os af vores testdata der er oprettet i databasen,
        //da der mangler daoklasser for nogle af elementerne i testen.
        // --- Vi bruger Accounten med navnet NoahPlayz og account id 4, som ejer 6 Item Instances ---

        //Act
        IEnumerable<ItemInstance> testItemInstances = _itemInstanceDao.GetAllItemInstancesByAccountId(4);

        //Assert
        Assert.That(testItemInstances.Count(), Is.EqualTo(6), "Should return exactly 6 Item Instances for this User");
    }

    public void GetItemInstanceDefinitionNameByItemInstance_ShouldReturnDefinitionName()
    {
        //Arrange
        //Vi benytter os af vores testdata der er oprettet i databasen,
        //da der mangler daoklasser for nogle af elementerne i testen.
        // --- Vi bruger Item Instance med ItemDefinition navnet Karambit Fade og iteminstanceId 24 ---

        //Act
        ItemInstance testItemInstance = _itemInstanceDao.GetItemInstanceById(24);

        //Assert
        Assert.That(testItemInstance.ItemDefinition.ItemName, Is.EqualTo("Karambit Fade"), "The ItemDefinition name should be Karambit Fade");
    }
}
