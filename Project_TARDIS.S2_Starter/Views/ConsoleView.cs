﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// Console class for the MVC pattern
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS

        //
        // declare a Universe and Traveler object for the ConsoleView object to use
        //
        Universe _gameUniverse;
        Traveler _gameTraveler;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Traveler gameTraveler, Universe gameUniverse)
        {
            _gameTraveler = gameTraveler;
            _gameUniverse = gameUniverse;

            InitializeConsole();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "The Lord of the Rings Quest Game";
            ConsoleUtil.HeaderText = "The Lord of the Rings Quest Game";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.HeaderText = "Exit";
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage("Thank you for playing The Lord Of The Rings Quest Game. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }

        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("The Lord Of The Rings Quest Game");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Written by Connor Hansen");
            ConsoleUtil.DisplayMessage("CIT 195");
            Console.WriteLine();

            //
            // TODO update opening screen
            //

            sb.Clear();
            sb.AppendFormat("Explore the fantasy world of Middle-Earth and uncover legendary treasure!");
            sb.AppendFormat("Defeat enemies of Mordor to gain experience and level up! ");
            sb.AppendFormat("Middle-Earth is evil and full of enemies so take this, it's ");
			sb.AppendFormat("dangerous to go go alone! (aquired short-sword)");
            ConsoleUtil.DisplayMessage(sb.ToString());
            Console.WriteLine();

            sb.Clear();
            sb.AppendFormat("Your first task will be to set up the initial parameters of your mission.");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new Traveler object
        /// </summary>
        public void DisplayMissionSetupIntro()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();

            //
            // display intro
            //
            ConsoleUtil.DisplayMessage("You will now be prompted to enter the starting parameters of your mission.");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a message confirming mission setup
        /// </summary>
        public void DisplayMissionSetupConfirmation()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();

            //
            // display confirmation
            //
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Your mission setup is complete.");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("To view your character information use the Main Menu.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get player's name
        /// </summary>
        /// <returns>name as a string</returns>
        public string DisplayGetTravelersName()
        {
            string travelersName;

            //
            // display header
            //
            ConsoleUtil.HeaderText = "Traveler's Name";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Enter your name: ");
            travelersName = Console.ReadLine();

            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($"You have indicated {travelersName} as your name.");

            DisplayContinuePrompt();

            return travelersName;
        }

        /// <summary>
        /// get and validate the player's race
        /// </summary>
        /// <returns>race as a RaceType</returns>
        public Traveler.RaceType DisplayGetTravelersRace()
        {
            bool validResponse = false;
            Traveler.RaceType travelersRace = Traveler.RaceType.None;

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Traveler's Race";
                ConsoleUtil.DisplayReset();

                //
                // display all race types on a line
                //
                ConsoleUtil.DisplayMessage("Races");
                StringBuilder sb = new StringBuilder();
                foreach (Character.RaceType raceType in Enum.GetValues(typeof(Character.RaceType)))
                {
                    if (raceType != Character.RaceType.None)
                    {
                        sb.Append($" [{raceType}] ");
                    }

                }
                ConsoleUtil.DisplayMessage(sb.ToString());

                ConsoleUtil.DisplayPromptMessage("Enter your race: ");

                //
                // validate user response for race
                //
                if (Enum.TryParse<Character.RaceType>(Console.ReadLine(), out travelersRace))
                {
                    validResponse = true;
                    ConsoleUtil.DisplayReset();
                    ConsoleUtil.DisplayMessage($"You have indicated {travelersRace} as your race type.");
                }
                else
                {
                    ConsoleUtil.DisplayMessage("You must limit your race to the list above.");
                    ConsoleUtil.DisplayMessage("Please reenter your race.");
                }

                DisplayContinuePrompt();
            }

            return travelersRace;
        }

        /// <summary>
        /// get and validate the player's TARDIS destination
        /// </summary>
        /// <returns>space-time location</returns>
        public SpaceTimeLocation DisplayGetTravelersNewDestination()
        {
            bool validResponse = false;
            int locationID;
            SpaceTimeLocation nextSpaceTimeLocation = new SpaceTimeLocation();

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Destination";
                ConsoleUtil.DisplayReset();

                //
                // display a table of space-time locations
                //
                DisplayTARDISDestinationsTable();

                //
                // get and validate user's response for a space-time location
                //
                ConsoleUtil.DisplayPromptMessage("Choose the destination by entering the ID: ");

                //
                // user's response is an integer
                //
                if (int.TryParse(Console.ReadLine(), out locationID))
                {
                    ConsoleUtil.DisplayMessage("");

                    try
                    {
                        nextSpaceTimeLocation = _gameUniverse.GetSpaceTimeLocationByID(locationID);

                        ConsoleUtil.DisplayReset();
                        ConsoleUtil.DisplayMessage($"You have indicated {nextSpaceTimeLocation.Name} as your destination.");
                        ConsoleUtil.DisplayMessage("");

                        if (nextSpaceTimeLocation.Accessable == true)
                        {
                            validResponse = true;
                            ConsoleUtil.DisplayMessage("You will be transported immediately.");
                        }
                        else
                        {
                            ConsoleUtil.DisplayMessage("It appears this destination is not available to you at this time.");
                            ConsoleUtil.DisplayMessage("Please make another choice.");
                        }
                    }
                    //
                    // user's response was not in the correct range
                    //
                    catch (ArgumentOutOfRangeException ex)
                    {
                        ConsoleUtil.DisplayMessage("It appears you entered an invalid location ID.");
                        ConsoleUtil.DisplayMessage(ex.Message);
                        ConsoleUtil.DisplayMessage("Please try again.");
                    }
                }
                //
                // user's response was not an integer
                //
                else
                {
                    ConsoleUtil.DisplayMessage("It appears you did not enter a number for the location ID.");
                    ConsoleUtil.DisplayMessage("Please try again.");
                }

                DisplayContinuePrompt();
            }

            return nextSpaceTimeLocation;
        }

        /// <summary>
        /// generate a table of space-time location names and ids
        /// </summary>
        public void DisplayTARDISDestinationsTable()
        {
            int locationNumber = 1;

            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Name".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

			//
			// location name and id
			//
			foreach (SpaceTimeLocation location in _gameUniverse.SpaceTimeLocations)
            {
				ConsoleUtil.DisplayMessage(location.SpaceTimeLocationID.ToString().PadRight(10) + location.Name.PadRight(20));
                locationNumber++;
            }

        }

        /// <summary>
        /// get the action choice from the user
        /// </summary>
        public TravelerAction DisplayGetTravelerActionChoice()
        {
            TravelerAction travelerActionChoice = TravelerAction.None;
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.HeaderText = "Traveler Action Choice";
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("What would you like to do (Type Letter).");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Traveler Actions" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "A. Look Around" + Environment.NewLine +
                    "\t" + "B. Look At" + Environment.NewLine +
                    "\t" + "C. Pick Up Item" + Environment.NewLine +
                    "\t" + "D. Pick Up Treasure" + Environment.NewLine +
                    "\t" + "E. Put Down Item" + Environment.NewLine +
                    "\t" + "F. Put Down Treasure" + Environment.NewLine +
                    "\t" + "G. Travel" + Environment.NewLine +
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Traveler Information" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "H. Display General Traveler Info" + Environment.NewLine +
                    "\t" + "I. Display Traveler Inventory" + Environment.NewLine +
                    "\t" + "J. Display Traveler Treasure" + Environment.NewLine +
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Game Information" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "K. Display All Destinations" + Environment.NewLine +
                    "\t" + "L. Display All Game Items" + Environment.NewLine +
                    "\t" + "M. Display All Game Treasures" + Environment.NewLine +
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Q. Quit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case 'A':
                    case 'a':
                        travelerActionChoice = TravelerAction.LookAround;
                        usingMenu = false;
                        break;
                    case 'B':
                    case 'b':
                        travelerActionChoice = TravelerAction.LookAt;
                        usingMenu = false;
                        break;
                    case 'C':
                    case 'c':
                        travelerActionChoice = TravelerAction.PickUpItem;
                        usingMenu = false;
                        break;
                    case 'D':
                    case 'd':
                        travelerActionChoice = TravelerAction.PickUpTreasure;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        travelerActionChoice = TravelerAction.PutDownItem;
                        usingMenu = false;
                        break;
                    case 'F':
                    case 'f':
                        travelerActionChoice = TravelerAction.PutDownTreasure;
                        usingMenu = false;
                        break;
                    case 'G':
                    case 'g':
                        travelerActionChoice = TravelerAction.Travel;
                        usingMenu = false;
                        break;
                    case 'H':
                    case 'h':
                        travelerActionChoice = TravelerAction.TravelerInfo;
                        usingMenu = false;
                        break;
                    case 'I':
                    case 'i':
                        travelerActionChoice = TravelerAction.TravelerInventory;
                        usingMenu = false;
                        break;
                    case 'J':
                    case 'j':
                        travelerActionChoice = TravelerAction.TravelerTreasure;
                        usingMenu = false;
                        break;
                    case 'K':
                    case 'k':
                        travelerActionChoice = TravelerAction.ListTARDISDestinations;
                        usingMenu = false;
                        break;
                    case 'L':
                    case 'l':
                        travelerActionChoice = TravelerAction.ListItems;
                        usingMenu = false;
                        break;
                    case 'M':
                    case 'm':
                        travelerActionChoice = TravelerAction.ListTreasures;
                        usingMenu = false;
                        break;
                    case 'Q':
                    case 'q':
                        travelerActionChoice = TravelerAction.Exit;
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to quit the application.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;

            return travelerActionChoice;
        }

        /// <summary>
        /// display information about the current space-time location
        /// </summary>
        public void DisplayLookAround()
        {
            ConsoleUtil.HeaderText = "Current Location Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(_gameUniverse.GetSpaceTimeLocationByID(_gameTraveler.SpaceTimeLocationID).Description);

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in current location.");
            foreach (Item item in _gameUniverse.GetItemtsBySpaceTimeLocationID(_gameTraveler.SpaceTimeLocationID))
            {
                ConsoleUtil.DisplayMessage(item.Name + " - " + item.Description);
            }

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Treasures in current location.");
            foreach (Treasure treasure in _gameUniverse.GetTreasuressBySpaceTimeLocationID(_gameTraveler.SpaceTimeLocationID))
            {
                ConsoleUtil.DisplayMessage(treasure.Name + " - " + treasure.Description);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all TARDIS destinations
        /// <summary>
        public void DisplayListAllTARDISDestinations()
        {
            ConsoleUtil.HeaderText = "Locations";
            ConsoleUtil.DisplayReset();

			foreach (SpaceTimeLocation location in _gameUniverse.SpaceTimeLocations)
            {
				ConsoleUtil.DisplayMessage("ID: " + location.SpaceTimeLocationID);
                ConsoleUtil.DisplayMessage("Name: " + location.Name);
                ConsoleUtil.DisplayMessage("Description: " + location.Description);
                ConsoleUtil.DisplayMessage("Accessible: " + location.Accessable);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all game items
        /// <summary>
        public void DisplayListAllGameItems()
        {
            ConsoleUtil.HeaderText = "Game Items";
            ConsoleUtil.DisplayReset();

            foreach (Item item in _gameUniverse.Items)
            {
                ConsoleUtil.DisplayMessage("ID: " + item.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + item.Name);
                ConsoleUtil.DisplayMessage("Description: " + item.Description);

                //
                // all treasure in the traveler's inventory have a SpaceTimeLocationID of 0
                //
                if (item.SpaceTimeLocationID != 0)
                {
                    ConsoleUtil.DisplayMessage("Location: " + _gameUniverse.GetSpaceTimeLocationByID(item.SpaceTimeLocationID).Name);
                }
                else
                {
                    ConsoleUtil.DisplayMessage("Location: Traveler's Inventory");
                }


                ConsoleUtil.DisplayMessage("Value: " + item.Value);
                ConsoleUtil.DisplayMessage("Can Add to Inventory: " + item.CanAddToInventory.ToString().ToUpper());
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all game treasures
        /// <summary>
        public void DisplayListAllGameTreasures()
        {
            ConsoleUtil.HeaderText = "Game Treasures";
            ConsoleUtil.DisplayReset();

            foreach (Treasure treasure in _gameUniverse.Treasures)
            {
                ConsoleUtil.DisplayMessage("ID: " + treasure.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + treasure.Name);
                ConsoleUtil.DisplayMessage("Description: " + treasure.Description);
                
                //
                // all treasure in the traveler's inventory have a SpaceTimeLocationID of 0
                //
                if (treasure.SpaceTimeLocationID != 0)
                {
                    ConsoleUtil.DisplayMessage("Location: " + _gameUniverse.GetSpaceTimeLocationByID(treasure.SpaceTimeLocationID).Name);
                }
                else
                {
                    ConsoleUtil.DisplayMessage("Location: Traveler's Inventory");
                }

                ConsoleUtil.DisplayMessage("Value: " + treasure.Value);
                ConsoleUtil.DisplayMessage("Can Add to Inventory: " + treasure.CanAddToInventory.ToString().ToUpper());
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler information
        /// </summary>
        public void DisplayTravelerInfo()
        {
            ConsoleUtil.HeaderText = "Traveler Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage($"Traveler's Name: {_gameTraveler.Name}");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage($"Traveler's Race: {_gameTraveler.Race}");
            ConsoleUtil.DisplayMessage("");
            string spaceTimeLocationName = _gameUniverse.GetSpaceTimeLocationByID(_gameTraveler.SpaceTimeLocationID).Name;
            ConsoleUtil.DisplayMessage($"Traveler's Current Location: {spaceTimeLocationName}");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler inventory
        /// </summary>
        public void DisplayTravelerItems()
        {
            ConsoleUtil.HeaderText = "Traveler Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Traveler Items");
            ConsoleUtil.DisplayMessage("");

            foreach (Item item in _gameTraveler.TravelersItems)
            {
                ConsoleUtil.DisplayMessage("ID: " + item.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + item.Name);
                ConsoleUtil.DisplayMessage("Description: " + item.Description);
				Console.WriteLine(item.itemArt);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler's treasure
        /// </summary>
        public void DisplayTravelerTreasure()
        {
            ConsoleUtil.HeaderText = "Traveler Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Traveler Treasure");
            ConsoleUtil.DisplayMessage("");

            foreach (Treasure treasure in _gameTraveler.TravelersTreasures)
            {
                ConsoleUtil.DisplayMessage("ID: " + treasure.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + treasure.Name);
                ConsoleUtil.DisplayMessage("Description: " + treasure.Description);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        public void DisplayLookAt()
        {
            ConsoleUtil.HeaderText = "NPCs in current location";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("NPCs");
            ConsoleUtil.DisplayMessage("");

            int locationID;
            locationID = _gameTraveler.SpaceTimeLocationID;

			foreach (NPC npc in _gameUniverse.NPCs)
			{
				if (npc.SpaceTimeLocationID == locationID)
				{
					Console.WriteLine(npc.Name);
					Console.WriteLine("Talk to? (y/n)");
					Console.WriteLine();
					string userChoice = Console.ReadLine();
					if (userChoice == "y")
					{
						if (npc.SpaceTimeLocationID == locationID)
						{
							Console.WriteLine(npc.Message);
							Console.WriteLine();
						}
						else
						{
							return;
						}
					}
				}
			}

			DisplayContinuePrompt();
        }

        public int DisplayPickUpItem()
        {
            ConsoleUtil.HeaderText = "Pick Up Item";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items");
            ConsoleUtil.DisplayMessage("");

            int itemID = 0;

            int locationID;
            locationID = _gameTraveler.SpaceTimeLocationID;

            foreach (Item item in _gameUniverse.Items)
            {
                if (item.SpaceTimeLocationID == locationID)
                {
					Console.WriteLine("Item: " + item.Name + "\nItem ID: " +item.GameObjectID);
                    Console.WriteLine();
					Console.WriteLine();
                }
            }

			bool valid = false;
			while (!valid)
			{
				itemID = DisplayGetIntegerInRange(0, 1000, "Enter Item ID or press 'esc': ");
				foreach (Item item in _gameUniverse.Items)
				{
					if (item.SpaceTimeLocationID == locationID)
					{
						if (item.GameObjectID == itemID)
						{
							item.SpaceTimeLocationID = 0;
							valid = true;
							DisplayContinuePrompt();
						}
						else if (item.GameObjectID != locationID)
						{
							Console.WriteLine("Please enter a valid Item ID");
						}
					}
				}
			}
			//itemID = int.Parse(Console.ReadLine());
            return itemID;
        }


		public int DisplayPickUpTreasure()
		{
			ConsoleUtil.HeaderText = "Pick Up Treasure";
			ConsoleUtil.DisplayReset();

			ConsoleUtil.DisplayMessage("");
			ConsoleUtil.DisplayMessage("Treasures");
			ConsoleUtil.DisplayMessage("");

			int treasureID = 0;

			int locationID;
			locationID = _gameTraveler.SpaceTimeLocationID;

			foreach (Treasure treasure in _gameUniverse.Treasures)
			{
				if (treasure.SpaceTimeLocationID == locationID)
				{
					Console.WriteLine("Treasure: " + treasure.Name + "\nTreasure ID: " + treasure.GameObjectID);
					Console.WriteLine();
					Console.WriteLine();
				}
			}

			bool valid = false;
			while (!valid)
			{
				treasureID = DisplayGetIntegerInRange(0, 1000, "Enter Item ID or press 'esc': ");
				foreach (Treasure treasure in _gameUniverse.Treasures)
				{
					if (treasure.SpaceTimeLocationID == locationID)
					{
						if (treasure.GameObjectID == treasureID)
						{
							treasure.SpaceTimeLocationID = 0;
							valid = true;
							DisplayContinuePrompt();
						}
						else if (treasure.GameObjectID != locationID)
						{
							Console.WriteLine("Please enter a valid Item ID");
						}
					}
				}
			}
			return treasureID;
		}

		public int DisplayPutDownItem()
		{
			ConsoleUtil.HeaderText = "Drop Item";
			ConsoleUtil.DisplayReset();

			ConsoleUtil.DisplayMessage("");
			ConsoleUtil.DisplayMessage("Items");
			ConsoleUtil.DisplayMessage("");

			int itemIDToDrop = 0;

			int locationID;
			locationID = _gameTraveler.SpaceTimeLocationID;

			foreach (Item item in _gameUniverse.Items)
			{
				if (item.SpaceTimeLocationID == 0)
				{
					Console.WriteLine("Item: " + item.Name + "\nItem ID: " + item.GameObjectID);
					Console.WriteLine();
					Console.WriteLine();
				}
			}

			Console.Write("Enter Item ID To Drop: ");
			itemIDToDrop = int.Parse(Console.ReadLine());

			DisplayContinuePrompt();

			return itemIDToDrop;
		}

		public int DisplayPutDownTreasure()
		{
			ConsoleUtil.HeaderText = "Drop Treasure";
			ConsoleUtil.DisplayReset();

			ConsoleUtil.DisplayMessage("");
			ConsoleUtil.DisplayMessage("Items");
			ConsoleUtil.DisplayMessage("");

			int treasureIDToDrop = 0;

			int locationID;
			locationID = _gameTraveler.SpaceTimeLocationID;

			foreach (Treasure treasure in _gameUniverse.Treasures)
			{
				if (treasure.SpaceTimeLocationID == 0)
				{
					Console.WriteLine("Treasure: " + treasure.Name + "\nTreasure ID: " + treasure.GameObjectID);
					Console.WriteLine();
					Console.WriteLine();
				}
			}

			Console.Write("Enter Treasure ID To Drop: ");
			treasureIDToDrop = int.Parse(Console.ReadLine());

			DisplayContinuePrompt();

			return treasureIDToDrop;
		}

		private int DisplayGetIntegerInRange(int min, int max, string prompt)
		{
			int integer = 0;

			bool validNumber = false;

			while (!validNumber)
			{
				ConsoleUtil.DisplayPromptMessage(prompt);
				if (int.TryParse(Console.ReadLine(), out integer))
				{
					if (integer >= min && integer <= max)
					{
						validNumber = true;
					}
					else
					{
						ConsoleUtil.DisplayMessage($"Input out of range ({min},{max})");
					}
				}
				else
				{
					ConsoleUtil.DisplayMessage("Input need to be entered as integers. (1, 2, 3, etc)");
				}
			}

			return integer;
		}



		#endregion
	}
}
