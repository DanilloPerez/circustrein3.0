using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class SortingAlgorithm
    {
        public List<Wagon> trainList;

        public SortingAlgorithm()
        {
            this.trainList = new List<Wagon>();
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
            List<Animal> returnList = new List<Animal>();
            foreach (Animal loop in oldAnimals)
            {
                Animal tempAnimal = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Large);
                foreach (Animal animal in oldAnimals)
                {
                    if ((int)animal.animalSize <= (int)tempAnimal.animalSize)
                    {
                        returnList.Add(animal);
                    }
                }
            }
            return returnList;
        }

        public List<Wagon> AvailableWagon(List<Animal> animalList)
        {
            foreach (Animal animal in animalList)
            {
                if (animal.animalType == Animal.AnimalType.Carnivore)
                {
                    Wagon wagon = new Wagon(Wagon.WagonSize.Regular);
                    wagon.AnimalsinWagon.Add(animal);
                }
                else if (animal.animalType == Animal.AnimalType.Herbivore)
                {
                   foreach(Wagon wagon in trainList)
                    {
                        if(wagon.spaceAvailable >= (int)animal.animalSize)
                        {

                            if (wagon.AnimalsinWagon.Exists(placedanimal => placedanimal.animalType == Animal.AnimalType.Carnivore))
                            {
                                if(animal.animalSize=> )
                                
                            }
                        }
                    }
                }
            }
        }


    }
}
