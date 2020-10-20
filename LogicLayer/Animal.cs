using System;
using System.Collections.Generic;

namespace LogicLayer
{
    public class Animal
    {
        public enum AnimalType
        {
            Carnivore,
            Herbivore
        }
        public enum AnimalSize
        {
            Small = 1,
            Medium = 3,
            Large = 5
        }

        public AnimalSize animalSize { get; private set; }
        public AnimalType animalType { get; private set; }

        public Animal(AnimalType type, AnimalSize size)
        {
            this.animalSize = size;
            this.animalType = type;
        }


    }
}
