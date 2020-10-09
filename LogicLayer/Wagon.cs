using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class Wagon
    {
        public int spaceAvailable { get; set; }
        public List<Animal> AnimalsinWagon;
        public enum WagonSize
        {
            Regular = 10,
        }
        public WagonSize wagonSize { get; private set; }

        public Wagon(WagonSize size)
        {
            this.wagonSize = size;
            this.AnimalsinWagon = new List<Animal>();
            this.spaceAvailable = (int)size;
        }
       
    }
}
