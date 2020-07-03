using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireBuilderAssistant
{
    public class Cargo
    {
        public Cargo(string name, List<string> cityList)
        {
            Name = name;
            Pickup = cityList;
        }
        public string Name { get; set; }
        public List<string> Pickup { get; set; }
    }
}
