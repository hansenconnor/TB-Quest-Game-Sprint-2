using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Controller
    {
        #region FIELDS

        private bool _usingGame;

        //
        // declare all objects required for the game
        // Note - these field objects do not require properties since they
        //        are not accessed outside of the controller
        //
        private ConsoleView _gameConsoleView;
        private Traveler _gameTraveler;
        private Universe _gameUniverse;

        #endregion

        #region PROPERTIES


        #endregion
        
        #region CONSTRUCTORS

        public Controller()
        {
            InitializeGame();

            //
            // instantiate a Salesperson object
            //
            _gameTraveler = new Traveler();

            //
            // instantiate a ConsoleView object
            //
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameUniverse);

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion
        
        #region METHODS

        /// <summary>
        /// initialize the game 
        /// </summary>
        private void InitializeGame()
        {
            _usingGame = true;
            _gameUniverse = new Universe();
            _gameTraveler = new Traveler();
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameUniverse);

        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageGameLoop()
        {
            TravelerAction travelerActionChoice;

            //_gameConsoleView.DisplayWelcomeScreen();

            InitializeMission();

            //
            // game loop
            //
            while (_usingGame)
            {

                //
                // get a menu choice from the ConsoleView object
                //
                travelerActionChoice = _gameConsoleView.DisplayGetTravelerActionChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case TravelerAction.None:
                        break;
						
                    case TravelerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;
						
                    case TravelerAction.LookAt:
                        _gameConsoleView.DisplayLookAt();
                        break;
						
                    case TravelerAction.PickUpItem:
                        int itemID;
                        itemID = _gameConsoleView.DisplayPickUpItem();

						if (itemID == 0)
						{
							break;
						}

                        Item PickedUpItem = new Item();
                        PickedUpItem = _gameUniverse.GetItemtByID(itemID);

                        _gameTraveler.TravelersItems.Add(PickedUpItem);

                        PickedUpItem.SpaceTimeLocationID = 0;
                        break;
						
                    case TravelerAction.PickUpTreasure:
						int treasureID;
						treasureID = _gameConsoleView.DisplayPickUpTreasure();

						Treasure PickedUpTreasure = new Treasure();
						PickedUpTreasure = _gameUniverse.GetTreasuretByID(treasureID);

						_gameTraveler.TravelersTreasures.Add(PickedUpTreasure);

						PickedUpTreasure.SpaceTimeLocationID = 0;
                        break;
						
                    case TravelerAction.PutDownItem:
						int itemIDToDrop;
						itemIDToDrop = _gameConsoleView.DisplayPutDownItem();

						Item ItemToDrop = new Item();
						ItemToDrop = _gameUniverse.GetItemtByID(itemIDToDrop);

						_gameTraveler.TravelersItems.Remove(ItemToDrop);

						ItemToDrop.SpaceTimeLocationID = _gameTraveler.SpaceTimeLocationID;
                        break;
						
                    case TravelerAction.PutDownTreasure:
						int treasureIDToDrop;
						treasureIDToDrop = _gameConsoleView.DisplayPutDownTreasure();

						Treasure TreasureToDrop = new Treasure();
						TreasureToDrop = _gameUniverse.GetTreasuretByID(treasureIDToDrop);

						_gameTraveler.TravelersTreasures.Remove(TreasureToDrop);

						TreasureToDrop.SpaceTimeLocationID = _gameTraveler.SpaceTimeLocationID;
						break;
						
                    case TravelerAction.Travel:
                        _gameTraveler.SpaceTimeLocationID = _gameConsoleView.DisplayGetTravelersNewDestination().SpaceTimeLocationID;
                        break;
                    case TravelerAction.TravelerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;
                    case TravelerAction.TravelerInventory:
                        _gameConsoleView.DisplayTravelerItems();
                        break;
                    case TravelerAction.TravelerTreasure:
                        _gameConsoleView.DisplayTravelerTreasure();
                        break;
                    case TravelerAction.ListTARDISDestinations:
                        _gameConsoleView.DisplayListAllTARDISDestinations();
                        break;
                    case TravelerAction.ListItems:
                        _gameConsoleView.DisplayListAllGameItems();
                        break;
                    case TravelerAction.ListTreasures:
                        _gameConsoleView.DisplayListAllGameTreasures();
                        break;
                    case TravelerAction.Exit:
                        _usingGame = false;
                        break;
                    default:
                        break;
                }
            }

            _gameConsoleView.DisplayExitPrompt();

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the traveler's starting mission  parameters
        /// </summary>
        private void InitializeMission()
        {
            _gameConsoleView.DisplayMissionSetupIntro();
			_gameConsoleView.DisplayGetTravelersName();
			_gameConsoleView.DisplayGetTravelersRace();
			_gameTraveler.SpaceTimeLocationID = 1;

            // 
            // add initial items to the traveler's inventory
            //
            
			AddItemToTravelersInventory(5);
        }

        /// <summary>
        /// add a game item to the traveler's inventory
        /// </summary>
        /// <param name="itemID">game item ID</param>
        private void AddItemToTravelersInventory(int itemID)
        {
            Item item;

            item = _gameUniverse.GetItemtByID(itemID);
            item.SpaceTimeLocationID = 0;

            _gameTraveler.TravelersItems.Add(item);
        }

        /// <summary>
        /// add a game treasure to the traveler's inventory
        /// </summary>
        /// <param name="itemID">game item ID</param>
        private void AddItemToTravelersTreasure(int itemID)
        {
            Treasure item;

            item = _gameUniverse.GetTreasuretByID(itemID);
            item.SpaceTimeLocationID = 0;

            _gameTraveler.TravelersTreasures.Add(item);
        }

        #endregion
    }
}
