using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSim
{
    public class Citizen
    {
        public static int NextID = 0;
        public int ID { get; set; }
        public string NameOfHome { get; set; }
        public string NameOfAssignedBuilding { get; set; }
        public BuildingType Type { get; set; }

        public Citizen()
        {
            ID = -1;
            Type = BuildingType.NONE;
            NameOfAssignedBuilding = string.Empty;
            NameOfHome = string.Empty;
            NextID++;
        }

        public void SeedID(int id)
        {
            NextID = id;
        }
    }
}
