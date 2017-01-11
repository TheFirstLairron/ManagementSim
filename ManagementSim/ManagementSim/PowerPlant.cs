namespace ManagementSim
{
    public class PowerPlant : Building
    {
        public PowerPlant(): base()
        {
        }

        public PowerPlant(string name, BuildingType type) : base(name, type)
        {
        }

        public override string ToString()
        {
            return $"Name: {Name} \nPowered On: {On} \n";
        }
    }
}
