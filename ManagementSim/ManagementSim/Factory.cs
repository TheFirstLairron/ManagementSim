namespace ManagementSim
{
    public class Factory : Building
    {
        public bool Powered { get; set; }

        public Factory() : base()
        {
            Powered = false;
        }

        public Factory(string name) : base(name)
        {
            Powered = false;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nPowered On: {On}\nRecieving Power: {Powered}\n";
        }
    }
}
