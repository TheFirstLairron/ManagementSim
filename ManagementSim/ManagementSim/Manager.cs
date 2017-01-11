using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSim
{
    public class Manager
    {
        public const string LIST_PLANTS = "LIST PLANTS";
        public const string LIST_FACTORIES = "LIST FACTORIES";
        public const string ADD_PLANT = "ADD PLANT";
        public const string ADD_FACTORY = "ADD FACTORY";
        public const string TOGGLE_FACTORY = "TOGGLE FACTORY";
        public const string TOGGLE_PLANT = "TOGGLE PLANT";
        public const string DISPLAY_ALL = "DISPLAY ALL";

        public const string INVALID_ACTION = "That is not a valid action, press any key to try again.";

        public const string EXIT_PHRASES = "QUIT EXIT DONE";

        private City City { get; set; }

        public Manager()
        {
            City = new City();
        }

        public void ProcessCommand(string command)
        {
            switch (command.ToUpper())
            {
                case LIST_PLANTS:
                    City.ListPlants();
                    break;

                case ADD_PLANT:
                    City.CreatePlant();
                    break;

                case LIST_FACTORIES:
                    City.ListFactories();
                    break;

                case ADD_FACTORY:
                    City.CreateFactory();
                    break;

                case TOGGLE_FACTORY:
                    City.ToggleFactory();
                    break;

                case TOGGLE_PLANT:
                    City.TogglePlant();
                    break;

                case DISPLAY_ALL:
                    City.DisplayAllLists();
                    break;
                default:
                    Console.WriteLine(INVALID_ACTION);
                    Console.ReadKey();
                    break;
            }
        }

        public void Activate()
        {
            string command = "";

            Console.WriteLine("Welcome to Power Manager 3000.");

            do
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                command = Console.ReadLine();

                if (EXIT_PHRASES.Contains(command.ToUpper()))
                {
                    break;
                }

                ProcessCommand(command);
                Update();

            } while (!EXIT_PHRASES.Contains(command.ToUpper()));

            Console.WriteLine("Exiting...");
        }

        private void Update()
        {
            City.Update();
        }

        
    }
}
