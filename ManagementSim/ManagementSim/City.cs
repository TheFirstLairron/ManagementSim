using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSim
{
    class City
    {
        private List<Factory> Factories { get; set; }
        private List<PowerPlant> Plants { get; set; }

        public City()
        {
            Factories = new List<Factory>();
            Plants = new List<PowerPlant>();
        }

        public void Update()
        {
            DeactivateAllPower();
            PowerActiveFactories();
        }

        public void DisplayListOrErrorMessage<T>(List<T> list, string errorMessage)
        {
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine(errorMessage);
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        public void DeactivateAllPower()
        {
            foreach(var fact in Factories)
            {
                fact.Powered = false;
            }
        }

        public void PowerActiveFactories()
        {
            int power = GetAvailablePower();

            List<Factory> activeFactories = GatherActiveBuildings<Factory>(Factories);

            for (int i = 0; i < power && i < activeFactories.Count(); i++)
            {
                activeFactories[i].Powered = true;
            }
        }

        public void ListFactories()
        {
            DisplayListOrErrorMessage<Factory>(Factories, "There are no factories to display.");
        }

        public void CreateFactory()
        {
            string name = "";
            bool isValidName = false;

            do
            {
                Console.Write("What is the name of this factory: ");
                name = Console.ReadLine();

                isValidName = IsNameAvailable<Factory>(Factories, name);

                if (!isValidName)
                {
                    Console.WriteLine("The provided name is not valid.");
                }

            } while (!isValidName);

            Factory factory = new Factory(name);

            Factories.Add(factory);
        }

        public void ListPlants()
        {
            DisplayListOrErrorMessage<PowerPlant>(Plants, "There are no plants to display.");
        }

        public void CreatePlant()
        {
            string name = "";
            bool isValidName = false;

            do
            {
                Console.Write("What is the name of this power plant: ");
                name = Console.ReadLine();

                isValidName = IsNameAvailable<PowerPlant>(Plants, name);

                if (!isValidName)
                {
                    Console.WriteLine("The provided name is not valid.");
                }

            } while (!isValidName);

            PowerPlant plant = new PowerPlant(name);

            Plants.Add(plant);
        }

        public void ToggleFactory()
        {
            string name = "";
            Factory fact = null;

            do
            {
                Console.Clear();
                Console.WriteLine("What is the name of the factory you would like to toggle: ");

                name = Console.ReadLine();

            } while (IsNameAvailable(Factories, name));

            fact = Factories.Where(x => x.Name == name).First();

            ToggleBuilding<Factory>(fact);
        }

        public void TogglePlant()
        {
            string name = "";
            PowerPlant plant = null;

            do
            {
                Console.Clear();
                Console.WriteLine("What is the name of the power plant you would like to toggle: ");

                name = Console.ReadLine();
            } while (IsNameAvailable(Plants, name));

            plant = Plants.Where(x => x.Name == name).First();

            ToggleBuilding<PowerPlant>(plant);
        }

        private void ToggleBuilding<T>(T building) where T : Building
        {
            building.Toggle();
        }

        private bool IsNameAvailable<T>(List<T> list, string name) where T : Building
        {
            bool available = false;

            if (!string.IsNullOrWhiteSpace(name))
            {
                available = list.Where(x => x.Name == name).Count() == 0;
            }

            return available;
        }

        private int GetAvailablePower()
        {
            int power = 0;

            power = Plants.Where(x => x.On).Count();

            return power;
        }

        private List<T> GatherActiveBuildings<T>(List<T> list) where T : Building
        {
            List<T> results = null;

            results = list.Where(x => x.On).ToList();

            return results;
        }
    }
}
