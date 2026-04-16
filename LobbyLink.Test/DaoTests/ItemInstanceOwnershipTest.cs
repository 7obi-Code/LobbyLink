using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.SQLClient;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

namespace LinkLobby.Test.DaoTests;
public class ItemInstanceOwnershipTest
{
    const string CONNECTION_STRING = "Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-V252_10666018;User ID=DMA-CSD-V252_10666018;Password=Password1!;Trust Server Certificate=True";
    
    IFItemInstanceDao itemInstanceDao;
    IFUserAccountDao userAccountDao;
    List<int> _cleanupTestItemInstancesById = new List<int>();

    [SetUp]
    public void Setup()
    {
        itemInstanceDao = new ItemInstanceDao(CONNECTION_STRING);
        userAccountDao = new UserAccountDao(CONNECTION_STRING);
    }

    [TearDown]
    public void CleanUp()
    {
    // Clean up test items
        foreach (var id in _cleanupTestItemInstancesById)
        {
            try
            {
                itemInstanceDao.DeleteItemInstanceById(id);
            }
            catch { }
        }
        _cleanupTestItemInstancesById.Clear();
    }

    [Test]
    public void GetItemInstanceByIdAndCheckUserAccount_ShouldReturnUserAccount()
    {
        // Arrange
        ItemInstance testItemInstance = CreateTestItemInstance();
        var id = itemInstanceDao.InsertItemInstance(testItemInstance);
        _cleanupTestItemInstancesById.Add(id);

        // Act

        ItemInstance itemInstance = itemInstanceDao.GetItemInstanceById(id);

        // Assert
        Assert.That(itemInstance, Is.Not.Null, "Item Instance was not found");
        Assert.That(itemInstance.UserAccount, Is.Not.Null, "A User was not connected to the ItemInstance");
        Assert.That(itemInstance.UserAccount.AccountId, Is.EqualTo(testItemInstance.AccountId_FK));
    }

    private ItemInstance CreateTestItemInstance()
    {
        var itemInstance = new ItemInstance
        {
            AccountId_FK = 1,
            ItemDefinitionId_FK = 1,
        };

        return itemInstance;
    }
}