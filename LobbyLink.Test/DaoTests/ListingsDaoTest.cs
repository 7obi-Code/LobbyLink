using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.Interfaces;
using LobbyLink.DataAccess.SQLClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.Test.DaoTests;
public class ListingsDaoTest
{
    IFListingDao _listingsDao = new ListingDao(TestSettings.CONNECTION_STRING);

    [Test]
    public void GetAllActiveListings_ShouldReturnListings_ForEachListing()
    {

        //Arrange
        //Vi henter alle listing i vores test data,
        //og opretter derfor ikke en arrange,
        //fordi der derfor ikke er brug for en test dao.

        //Act
        IEnumerable<Listing> listings = _listingsDao.GetFilteredListings();

        //Assert
        Assert.That(listings, Is.Not.Null, "Listing collection should not be empty");
        Assert.That(listings.Count(), Is.GreaterThanOrEqualTo(1), "Should return atleast 1 listing");

    }

    [Test]
    public void GetAllActiveListings_ShouldIncludePrice_ForEachListing()
    {

        //Arrange
        //Vi henter alle listing i vores test data,
        //og opretter derfor ikke en arrange,
        //fordi der derfor ikke er brug for en test dao.

        //Act
        IEnumerable<Listing> listings = _listingsDao.GetFilteredListings();

        //Assert
        Assert.That(listings, Is.Not.Null, "Listing collectionshould not be empty");
        foreach (var listing in listings) {
            Assert.That(listing.Price > 0, "Item should include a price");
        }
    }

    [Test]
    public void GetAllActiveListings_ShouldIncludeItemInstance_ForEachListing()
    {

        //Arrange
        //Vi henter alle listing i vores test data,
        //og opretter derfor ikke en arrange,
        //fordi der derfor ikke er brug for en test dao.


        //Act
        IEnumerable<Listing> listings = _listingsDao.GetFilteredListings();

        //Assert
        Assert.That(listings, Is.Not.Null, "Listing collection should not be empty");
        foreach (var listing in listings)
        {
            Assert.That(listing.ItemInstance, Is.Not.Null, "Item should include an iteminstance");
        }
    }

    [Test]
    public void GetAllActiveListings_ShouldIncludeAccount_ForEachListing()
    {

        //Arrange
        //Vi henter alle listing i vores test data,
        //og opretter derfor ikke en arrange,
        //fordi der derfor ikke er brug for en test dao.


        //Act
        IEnumerable<Listing> listings = _listingsDao.GetFilteredListings();

        //Assert
        Assert.That(listings, Is.Not.Null, "Listing collection should not be empty");
        foreach (var listing in listings)
        {
            Assert.That(listing.SellerAccount, Is.Not.Null, "Item should include a seller account");
        }
    }

    [Test]
    public void HasActiveListingForItemInstance_ShouldReturnTrue_WhenItemAlreadyHasAnActiveListing()
    {
        //Arrange
        //Vi benytter os af vores testdata der er oprettet i databasen.
        //Og derfor ikke brug for en arrange. 
        //Vi bruger ItemInstanceId 1, som allerede har en ACTIVE listing

        //Act
        /*
        bool result = _listingsDao.HasActiveListingForItemInstance(1);

        //Assert
        Assert.That(result, Is.True, "Should return true when item instance already has an active listing");
        */
    }

    public void HasActiveListingForItemInstance_ShouldReturnFalse_WhenItemAlreadyHasNoActiveListing()
    {
        //Arrange
        //Vi benytter os af vores testdata der er oprettet i databasen
        //Og derfor ikke brug for en arrange
        //Vi bruger ItemInstanceId 2, som ikke har en ACTIVE listing. 

        //Act
        /*
        bool result = _listingsDao.HasActiveListingForItemInstance(2);

        //Assert
        Assert.That(result, Is.False, "Should return false when item instance does not have an active listing");
        */
    }

    [Test]
    public void CreateListing_ShouldCreateListing_WhenItemInstanceIsNotAlreadyListed()
    {
        //Arrange
        //Vi benytter os af vores testdata der er oprettet i databasen.
        //Vi bruger ItemInstanceId 2, som ikke har en ACTIVE listing
        //Vi bruger AccountId 4, som findes i testdata

        Listing listing = new Listing
        {
            Price = 150,
            CreationTimeStamp = DateTime.Now,
            StatusId = 1,
            ItemInstance = new ItemInstance { ItemInstanceId = 2 },
            SellerAccount = new Account { AccountId = 4 }
        };

        //Act
        int createdListingId = _listingsDao.ValidateAndInsertListing(listing);

        //Assert
        /* FIX THIS
        Assert.That(createdListingId, Is.Not.Null, "Created listing should not be null");
        Assert.That(createdListingId.ListingId, Is.GreaterThan(0), "Created listing should have an id");
        Assert.That(createdListing.Status, Is.EqualTo("ACTIVE"), "Created listing should have ACTIVE status");
        */
    }
}
