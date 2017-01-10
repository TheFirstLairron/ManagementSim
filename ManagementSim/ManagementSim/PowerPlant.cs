namespace ManagementSim
{
    public class PowerPlant : Building
    {
        public PowerPlant(): base()
        {
        }

        public PowerPlant(string name) : base(name)
        {
        }

        public override string ToString()
        {
            return $"Name: {Name} \nPowered On: {On} \n";
        }
    }
}
