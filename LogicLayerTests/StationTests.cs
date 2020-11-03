using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Tests
{
    [TestClass()]
    public class StationTests
    {
        [TestMethod()]
        public void StartLoadingTrainTest()
        {
            //arrange 
            Animal animal = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Large);
            Wagon wagon = new Wagon(Wagon.WagonSize.Regular);
            //act 
            wagon.PlaceAnimal(animal);
            //assert
            Assert.IsTrue(wagon.AnimalsinWagon.Contains(animal));
            Assert.AreEqual(wagon.spaceAvailable, 5);
        }


    }
}