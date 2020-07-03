using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireBuilderAssistant
{
    public class City
    {
        public City(string name, double posX, double posY)
        {
            Name = name;
            PosX = posX;
            PosY = posY;
        }

        public string Name { get; }
        public double PosX { get; }
        public double PosY { get; }
    }
}
