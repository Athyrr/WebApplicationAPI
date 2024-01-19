using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Tests
{
    [TestClass()]
    public class FlowerRepositoryTests
    {
        [TestMethod()]
        public async Task ChangeFlowerAsyncTest()
        {
            //Arrange
            DbContextOptionsBuilder<GardenContext>? builder = new DbContextOptionsBuilder<GardenContext>().UseInMemoryDatabase("GardenContextTest");

            var context = new GardenContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Flowers.Add(new Entities.Flower { Id = 1, Name = "fleur1", NbPetal = 0 });
            context.Flowers.Add(new Entities.Flower { Id = 2, Name = "fleur2", NbPetal = 0 });

            context.SaveChanges();

            var flowerRepository = new FlowerRepository(context);
            var nbPetalExpected = 10;
            //Act

            //var flower = await flowerRepository
            //    .ChangeFlowerAsync(context.Flowers.FirstOrDefault(f => f.Id == 1));
            //var flower = new Flower()
            //{
            //    Id = 1,
            //    NbPetal = 10,
            //    Name = "Changed name"
            //};

            var flower = new Flower()
            {
                Id = 1,
                Name = "truc",
                NbPetal = 10,
            };

            flowerRepository.ChangeFlowerAsync(flower);

            //Assert
            Assert.AreEqual(nbPetalExpected, context.Flowers.Find(1).NbPetal);
        }
    }
}