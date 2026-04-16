using LobbyLink.DataAccess.SQLClient;
using LobbyLink.DataAccess.Model;
using LobbyLink.DataAccess.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.Test.DaoTests
{
    public class ItemHasItemDefinition
    {
        ItemInstanceDao _itemInstanceDao;
        ItemDefinitionDao _ItemDefinitionDao;
        List<int> _cleanupItemInstanceIds = new List<int>();
        List<int> _cleanupItemDefinitionIds = new List<int>();

        [SetUp]
        public void Setup()
        {
            _itemInstanceDao = new ItemInstanceDao(TestSettings.CONNECTION_STRING);
            _ItemDefinitionDao = new ItemDefinitionDao(TestSettings.CONNECTION_STRING);
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
                    //_itemDefinitionDao.DeleteItemDefinition(id);
                }
                catch { }
            }
            _cleanupItemDefinitionIds.Clear();
        }

        [Test]
        public void Test1()
        {
        }
    }
}
