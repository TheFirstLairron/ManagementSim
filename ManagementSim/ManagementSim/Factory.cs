namespace ManagementSim
{
    public class Factory : Building, IPowerable
    {
        public bool IsPowered { get; set; }

        public Factory() : base()
        {
            IsPowered = false;
        }

        public Factory(string name, BuildingType type) : base(name, type)
        {
            IsPowered = false;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nPowered On: {On}\nRecieving Power: {IsPowered}\n";
        }
    }
}
