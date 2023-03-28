using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopLib.Models;
using ShoppingAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Repositories.Tests
{
    [TestClass()]
    public class ShoppingItemsRepositoryTests
    {
        // reference til listen
        private ShoppingItemsRepository repository;

        // Ny liste for hver test
        [TestInitialize]
        public void BeforeEachTest()
        {
            repository = new ShoppingItemsRepository();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var actual = repository.GetAll();

            Assert.IsNotNull(actual);
            Assert.AreEqual(typeof(List<ShoppingItem>), actual.GetType());
            Assert.AreEqual(3, actual.Count());
        }

        [TestMethod()]
        public void AddTest()
        {
            ShoppingItem item = new() { Name = "test", Price = 10, Quantity = 9};
            repository.Add(item);
            var actual = repository.GetAll();

            Assert.AreEqual(4, actual.Count());
            // Svær at teste uden GetById
        }

        [TestMethod()]
        public void DeleteTest()
        {
            repository.Delete(3);
            var actual = repository.GetAll();

            Assert.AreEqual(2, actual.Count());
            Assert.ThrowsException<ArgumentException>(() => repository.Delete(4));
        }

        [TestMethod()]
        public void TotalPriceTest()
        {
            var actual = repository.TotalPrice();

            Assert.IsNotNull(actual);
            Assert.AreEqual(typeof(double), actual.GetType());
            Assert.AreEqual(46, actual);
        }
    }
}