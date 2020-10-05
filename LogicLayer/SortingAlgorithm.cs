using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
            Animal[] oldAnimalsArray = oldAnimals.ToArray();
            List<Animal> returnList = new List<Animal>();
            for (int j = 0; j < oldAnimalsArray.Length; j++)
            {
                Animal tempAnimal = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Large);
                int index = 0;
                for (int i = 0; i < oldAnimalsArray.Length; i++)
                {
                    if(oldAnimalsArray[i] != null)
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

        public List<Wagon> AvailableWagon(List<Animal> animalList)
        {
            foreach (Animal animal in animalList)
            {
                if (animal.animalType == Animal.AnimalType.Carnivore)
                {
                    Wagon wagon = new Wagon(Wagon.WagonSize.Regular);
                    trainList.Add(wagon);
                    wagon.AnimalsinWagon.Add(animal);
                    wagon.spaceAvailable -= (int)animal.animalSize;
                }
                else if (animal.animalType == Animal.AnimalType.Herbivore)
                {
                    bool isanimalPlaced = false;
                    foreach (Wagon wagon in trainList)
                    {
                        
                        if(wagon.spaceAvailable >= (int)animal.animalSize)
                        {
                            Animal tempAnimal = wagon.AnimalsinWagon.Find(temp => temp.animalType == Animal.AnimalType.Carnivore);
                            if (tempAnimal != null)
                            {
                                if(animal.animalSize > tempAnimal.animalSize)
                                {
                                    wagon.AnimalsinWagon.Add(animal);
                                    wagon.spaceAvailable -= (int)animal.animalSize;
                                    isanimalPlaced = true;
                                }                               
                            }
                            else
                            {
                                wagon.AnimalsinWagon.Add(animal);
                                wagon.spaceAvailable -= (int)animal.animalSize;
                                isanimalPlaced = true;
                            }
                        }
                        if  (isanimalPlaced == true)
                            break;
                    }
                    
                    if (isanimalPlaced == false)
                    {
                        Wagon wagon = new Wagon(Wagon.WagonSize.Regular);
                        trainList.Add(wagon);
                        wagon.AnimalsinWagon.Add(animal);
                        wagon.spaceAvailable -= (int)animal.animalSize;
                    }
                }
            }
            return trainList;
        }
        public string DisplayAnimals(List<Wagon>trainlist)
        {
            string output = "";
            foreach (Wagon wagon in trainList)
            {
                output += "wagon" + '\n'; 
                foreach(Animal animal in wagon.AnimalsinWagon)
                {
                    output += animal.animalType.ToString() + animal.animalSize.ToString() + '\n';
                }
                output += '\n';
            }
            return output;
        }


    }
}
