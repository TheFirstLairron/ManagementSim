using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSim
{
    class Housing : Building, IPowerable
    {
        public bool IsPowered { get; set; }
        public int NumberOfWorkers { get; set; }

        public Housing() : base()
        {
            IsPowered = false;
            NumberOfWorkers = 0;
        }

        public Housing(string name, BuildingType type) : base(name, type)
        {
            IsPowered = false;
            NumberOfWorkers = 0;
        }
    }
}
