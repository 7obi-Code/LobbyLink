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

        // Act
        ItemInstance itemInstance = itemInstanceDao.GetItemInstanceById(testItemInstance.ItemInstanceId);

        // Assert
        Assert.That(itemInstance, Is.Not.Null, "Item Instance was not found");
        Assert.That(itemInstance.UserAccount, Is.Not.Null, "A User was not connected to the ItemInstance");
        Assert.That(itemInstance.UserAccount, Is.EqualTo(testItemInstance.UserAccount));
    }

    private ItemInstance CreateTestItemInstance()
    {
        var itemInstance = new ItemInstance
        {
            ItemInstanceId = 35,
            Status = true,
            UserAccount = userAccountDao.GetUserAccountById(1),
            Listings = new List<Listing>(),
            ItemInstancePropertyLines = new List<ItemInstancePropertyLine>(),
            ItemDefinition = null
        };

        var id = itemInstanceDao.InsertItemInstance(itemInstance);
        _cleanupTestItemInstancesById.Add(id);

        return itemInstance;
    }
}