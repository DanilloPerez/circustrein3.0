using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class Wagon
    {

        public int spaceAvailable { get; private set; }
        public List<Animal> AnimalsinWagon { get; private set; }
        public enum WagonSize
        {
            Regular = 10,
        }
        private WagonSize wagonSize;

        public Wagon(WagonSize size)
        {
            this.wagonSize = size;
            this.AnimalsinWagon = new List<Animal>();
            this.spaceAvailable = (int)size;
        }

        //place in wagon
        public void PlaceAnimal(Animal animal)
        {
            this.AnimalsinWagon.Add(animal);
            this.spaceAvailable -= (int)animal.animalSize;
        }
        
        //try to place animal in excisting wagon
        public bool TryPlaceAnimal(Animal animal)
        {
            if (this.spaceAvailable >= (int)animal.animalSize)
            {
                Animal tempAnimal = this.AnimalsinWagon.Find(temp => temp.animalType == Animal.AnimalType.Carnivore);
                if (tempAnimal != null)
                {
                    if (animal.animalSize > tempAnimal.animalSize)
                    {
                        PlaceAnimal(animal);
                        return true;
                    }
                }
                else
                {
                    PlaceAnimal(animal);
                    return true;
                }
            }
            return false;
        }


    }
}
