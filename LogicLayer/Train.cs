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
    }
}
