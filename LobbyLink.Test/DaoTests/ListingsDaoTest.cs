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
        IEnumerable<Listing> listings = _listingsDao.GetAllActiveListings();

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
        IEnumerable<Listing> listings = _listingsDao.GetAllActiveListings();

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
        IEnumerable<Listing> listings = _listingsDao.GetAllActiveListings();

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
        IEnumerable<Listing> listings = _listingsDao.GetAllActiveListings();

        //Assert
        Assert.That(listings, Is.Not.Null, "Listing collection should not be empty");
        foreach (var listing in listings)
        {
            Assert.That(listing.Account, Is.Not.Null, "Item should include a seller account");
        }
    }
}
