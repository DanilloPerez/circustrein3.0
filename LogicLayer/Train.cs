using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class Train
    {
        public List<Wagon> trainList { get; private set; }
        public Train()
        {
            trainList = new List<Wagon>();
        }
        public List<Animal> SortAnimals(List<Animal> animalList)
        {
            animalList = SortBySize(animalList);
            animalList = SortByType(animalList);
            return animalList;
        }
        public List<Animal> SortByType(List<Animal> oldAnimals)
        {
            List<Animal> carnivoreList = new List<Animal>();
            List<Animal> herbivoreList = new List<Animal>();
            foreach (Animal animal in oldAnimals)
            {
                if (animal.animalType == Animal.AnimalType.Carnivore)
                    carnivoreList.Add(animal);
                else if (animal.animalType == Animal.AnimalType.Herbivore)
                    herbivoreList.Add(animal);
            }
            carnivoreList.AddRange(herbivoreList);
            return carnivoreList;
        }
        public List<Animal> SortBySize(List<Animal> oldAnimals)
        {
            Animal[] oldAnimalsArray = oldAnimals.ToArray();
            List<Animal> returnList = new List<Animal>();
            for (int j = 0; j < oldAnimalsArray.Length; j++)
            {
                Animal tempAnimal = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Large);
                int index = 0;
                for (int i = 0; i < oldAnimalsArray.Length; i++)
                {
                    if (oldAnimalsArray[i] != null)
                    {
                        if ((int)oldAnimalsArray[i].animalSize <= (int)tempAnimal.animalSize)
                        {
                            tempAnimal = oldAnimalsArray[i];
                            index = i;
                        }
                    }
                }
                oldAnimalsArray[index] = null;
                returnList.Add(tempAnimal);
            }
            return returnList;
        }
        public List<Wagon> AssignWagon(List<Animal> animalList)
        {
            foreach (Animal animal in animalList)
            {
                if (animal.animalType == Animal.AnimalType.Carnivore)
                {
                    Wagon wagon = new Wagon(Wagon.WagonSize.Regular);
                    wagon.PlaceAnimal(animal);
                    trainList.Add(wagon);

                }
                else if (animal.animalType == Animal.AnimalType.Herbivore)
                {
                    bool isAnimalPlaced = false;
                    foreach (Wagon wagon in trainList)
                    {

                        if (!isAnimalPlaced)
                        {
                            isAnimalPlaced = wagon.TryPlaceAnimal(animal);
                        }
                    }

                    if (!isAnimalPlaced)
                    {
                        Wagon wagon = new Wagon(Wagon.WagonSize.Regular);
                        wagon.PlaceAnimal(animal);
                        trainList.Add(wagon);
                    }
                }
            }
            return trainList;
        }
    }
}
