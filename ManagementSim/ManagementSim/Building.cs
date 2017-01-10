using System.Linq;

namespace ManagementSim
{
    public class Building
    {
        public string Name { get; set; }
        public bool On { get; set; }

        public Building()
        {
            Name = string.Empty;
            On = false;
        }

        public Building(string name)
        {
            Name = name;
            On = false;
        }

        public void Toggle()
        {
            On = !On;
        }
    }
}
