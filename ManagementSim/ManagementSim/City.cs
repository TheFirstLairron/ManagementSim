using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSim
{
    public class City
    {
        private const string NEGATIVE_NAME_PROMPT = "The provided name is not valid or is already in use.";

        private List<Factory> Factories { get; set; }
        private List<PowerPlant> Plants { get; set; }
        private List<Housing> Houses { get; set; }

        public City()
        {
            Factories = new List<Factory>();
            Plants = new List<PowerPlant>();
            Houses = new List<Housing>();
        }

        public void Update()
        {
            DeactivateAllPower();
            PowerActiveFactories();
        }

        public void DisplayAllLists()
        {
            string errorMessage = "There are none to display.";

            Console.WriteLine("Factories: ");
            DisplayListOrErrorMessage<Factory>(Factories, errorMessage, false);

            Console.WriteLine("Power Plants: ");
            DisplayListOrErrorMessage<PowerPlant>(Plants, errorMessage, false);

            // Dont disable the key prompt on the last list
            Console.WriteLine("Housing: ");
            DisplayListOrErrorMessage<Housing>(Houses, errorMessage);
        }

        public void DisplayListOrErrorMessage<T>(List<T> list, string errorMessage, bool promptForKey = true)
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
                Console.WriteLine();
            }

            if (promptForKey)
            {
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        public void DeactivateAllPower()
        {
            foreach(var fact in Factories)
            {
                fact.IsPowered = false;
            }
        }

        public void PowerActiveFactories()
        {
            int power = GetAvailablePower();

            List<Factory> activeFactories = GatherActiveBuildings<Factory>(Factories);

            for (int i = 0; i < power && i < activeFactories.Count(); i++)
            {
                activeFactories[i].IsPowered = true;
            }
        }

        public void ListFactories()
        {
            DisplayListOrErrorMessage<Factory>(Factories, "There are no factories to display.");
        }

        public void CreateFactory()
        {
            string name = PromptForValidName<Factory>(Factories, "What is the name of the factory: ");

            Factory factory = new Factory(name, BuildingType.FACTORY);

            Factories.Add(factory);
        }

        public void ListPlants()
        {
            DisplayListOrErrorMessage<PowerPlant>(Plants, "There are no plants to display.");
        }

        public void CreatePlant()
        {
            string name = PromptForValidName<PowerPlant>(Plants, "What is the name of this power plant: ");

            PowerPlant plant = new PowerPlant(name, BuildingType.POWERPLANT);

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

        public string PromptForValidName<T>(List<T> list, string prompt, string negative = NEGATIVE_NAME_PROMPT) where T : Building
        {
            string name = "";
            bool isValidName = false;

            do
            {
                Console.Write(prompt);
                name = Console.ReadLine();

                isValidName = IsNameAvailable<T>(list, name);

                if (!isValidName)
                {
                    Console.Clear();
                    Console.WriteLine(negative);
                }

            } while (!isValidName);

            return name;
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
