using System.Linq;

namespace ManagementSim
{
    public enum BuildingType
    {
        NONE,
        FACTORY,
        POWERPLANT,
        HOUSING
    }

    public class Building
    {
        public string Name { get; set; }
        public bool On { get; set; }
        public BuildingType Type { get; set; }

        public Building()
        {
            Name = string.Empty;
            On = false;
            Type = BuildingType.NONE;
        }

        public Building(string name, BuildingType type)
        {
            Name = name;
            Type = type;
            On = false;
        }

        public void Toggle()
        {
            On = !On;
        }
    }
}
