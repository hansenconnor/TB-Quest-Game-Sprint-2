using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// the Universe class manages all of the game elements
    /// </summary>
    public class Universe
    {
        #region ***** define all lists to be maintained by the Universe object *****

        //
        // list of all space-time locations
        //
		public List<SpaceTimeLocation> SpaceTimeLocations { get; set; }

        //
        // list of all items
        //
        public List<Item> Items { get; set; }


        //
        // list of all treasure
        //
        public List<Treasure> Treasures { get; set; }

		//
		// list of all NPCs
		//
		public List<NPC> NPCs { get; set; }

        #endregion

        #region ***** constructor *****

        //
        // default Universe constructor
        //
        public Universe()
        {
            //
            // instantiate the lists of space-time locations and game objects
            //
			this.SpaceTimeLocations = new List<SpaceTimeLocation>();
            this.Items = new List<Item>();
            this.Treasures = new List<Treasure>();
			this.NPCs = new List<NPC>();

            //
            // add all of the space-time locations and game objects to their lists
            // 
            IntializeUniverseSpaceTimeLocations();
            IntializeUniverseItems();
            IntializeUniverseTreasures();
			IntializeUniverseNPCs();
        }

        #endregion

        #region ***** define methods to get the next available ID for game elements *****

        /// <summary>
        /// return the next available ID for a SpaceTimeLocation object
        /// </summary>
        /// <returns>next SpaceTimeLocationObjectID </returns>
        private int GetNextSpaceTimeLocationID()
        {
            int MaxID = 0;

            foreach (SpaceTimeLocation STLocation in SpaceTimeLocations)
            {
                if (STLocation.SpaceTimeLocationID > MaxID)
                {
                    MaxID = STLocation.SpaceTimeLocationID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for an item
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextItemID()
        {
            int MaxID = 0;

            foreach (Item item in Items)
            {
                if (item.GameObjectID > MaxID)
                {
                    MaxID = item.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for a treasure
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextTreasureID()
        {
            int MaxID = 0;

            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID > MaxID)
                {
                    MaxID = treasure.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        #endregion

        #region ***** define methods to return game element objects *****

        /// <summary>
        /// get a SpaceTimeLocation object using an ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>requested space-time location</returns>
        public SpaceTimeLocation GetSpaceTimeLocationByID(int ID)
        {
            SpaceTimeLocation spt = null;

            //
            // run through the space-time location list and grab the correct one
            //
            foreach (SpaceTimeLocation location in SpaceTimeLocations)
            {
                if (location.SpaceTimeLocationID == ID)
                {
                    spt = location;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (spt == null)
            {
                string feedbackMessage = $"The Space-Time Location ID {ID} does not exist in the current Universe.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return spt;
        }

        /// <summary>
        /// get an item using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested item object</returns>
        public Item GetItemtByID(int ID)
        {
            Item requestedItem = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Item item in Items)
            {
                if (item.GameObjectID == ID)
                {
                    requestedItem = item;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (requestedItem == null)
            {
                string feedbackMessage = $"The item ID {ID} does not exist in the current Universe.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedItem;
        }

        /// <summary>
        /// get a treasure using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested treasure object</returns>
        public Treasure GetTreasuretByID(int ID)
        {
            Treasure requestedTreasure = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID == ID)
                {
                    requestedTreasure = treasure;
                };
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (requestedTreasure == null)
            {
                string feedbackMessage = $"The treasure ID {ID} does not exist in the current Universe.";

				throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedTreasure;
        }

        #endregion

        #region ***** define methods to get lists of game elements by location *****


        /// get a list of items using a space-time location ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>list of items in the specified location</returns>
        public List<Item> GetItemtsBySpaceTimeLocationID(int ID)
        {
            // TODO validate SpaceTimeLocationID

            List<Item> itemsInSpaceTimeLocation = new List<Item>();

            //
            // run through the item list and put all items in the current location
            // into a list
            //
            foreach (Item item in Items)
            {
                if (item.SpaceTimeLocationID == ID)
                {
                    itemsInSpaceTimeLocation.Add(item);
                }
            }

            return itemsInSpaceTimeLocation;
        }

        /// get a list of treasures using a space-time location ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>list of treasures in the specified location</returns>
        public List<Treasure> GetTreasuressBySpaceTimeLocationID(int ID)
        {
            // TODO validate SpaceTimeLocationID

            List<Treasure> treasuresInSpaceTimeLocation = new List<Treasure>();

            //
            // run through the treasure list and put all items in the current location
            // into a list
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.SpaceTimeLocationID == ID)
                {
                    treasuresInSpaceTimeLocation.Add(treasure);
                }
            }

            return treasuresInSpaceTimeLocation;
        }

		/// get a list of NPCs using a space-time location ID
		/// </summary>
		/// <param name="ID">space-time location ID</param>
		/// <returns>list of NPCs in the specified location</returns>
		public List<NPC> GetNPCsBySpaceTimeLocationID(int ID)
		{
			// TODO validate SpaceTimeLocationID

			List<NPC> NPCsInSpaceTimeLocation = new List<NPC>();

			//
			// run through the NPC list and put all items in the current location
			// into a list
			//
			foreach (NPC npc in NPCs)
			{
				if (npc.SpaceTimeLocationID == ID)
				{
					NPCsInSpaceTimeLocation.Add(npc);
				}
			}

			return NPCsInSpaceTimeLocation;
		}

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the universe with all of the space-time locations
        /// </summary>
        private void IntializeUniverseSpaceTimeLocations()
        {
			SpaceTimeLocations.Add(new SpaceTimeLocation
			{
				Name = "Rivendell",
				SpaceTimeLocationID = 1,
				Description = "An Elven town in the Misty Mountains on the eastern edge of Eriabor.",
				Accessable = true
			});

			SpaceTimeLocations.Add(new SpaceTimeLocation
			{
				Name = "The Shire",
				SpaceTimeLocationID = 2,
				Description = "Located in the large region of Eriador and the Kingdom of Arnor, " +
					"the shire is inhabited by Hobbits and largely removed from the goings-on in the rest " +
					"of  Middle-earth.",
				Accessable = true
			});

			SpaceTimeLocations.Add(new SpaceTimeLocation
			{
				Name = "Moria",
				SpaceTimeLocationID = 3,
				Description = "An enormous and by then very ancient underground complex in north-western Middle-earth, " +
					"comprising a vast network of tunnels, chambers, mines and huge halls or mansions, that ran under, " +
					"and ultimately through the Misty Mountains.",
				Accessable = true
			});

			SpaceTimeLocations.Add(new SpaceTimeLocation
			{
				Name = "Minas Tirath",
				SpaceTimeLocationID = 4,
				Description = "Heavily fortified capital of Gondor, this city was built " +
					"to guard the former capital, Osgiliath, from the attack from the west. ",
				Accessable = true
			});
        }

        /// <summary>
        /// initialize the universe with all of the items
        /// </summary>
        private void IntializeUniverseItems()
        {
			Items.Add(new Item
			{
				Name = "Scroll of Lothlórien",
				GameObjectID = 1,
				Description = "A rare and ancient relic of the great and secretive tree-city of the elves. " +
					"This item is used by Artisan Scholars.",
				SpaceTimeLocationID = 1,
				HasValue = true,
				Value = 10,
				CanAddToInventory = true
			});

			Items.Add(new Item
			{
				Name = "Elvish Sword",
				GameObjectID = 2,
				Description = "A rusted sword, broken halfway. Probably from a battle long ago.",
				SpaceTimeLocationID = 3,
				HasValue = false,
				Value = 0,
				CanAddToInventory = true,
				itemArt = "      /| _____________\nO|===|* >____________\n      \\|"
			});

			Items.Add(new Item
			{
				Name = "Tattered Map",
				GameObjectID = 3,
				Description = "A dusty and worn map. Faint markings cover the surface but the" +
					"locations are unreadable",
				SpaceTimeLocationID = 2,
				HasValue = false,
				Value = 0,
				CanAddToInventory = true,
				itemArt = "      " +
					"______ ______\n    _/      Y      \\_\n   // ~~ ~~ | ~~ ~  \\\\\n  // ~ ~ ~~ | ~~~ ~~ \\\\      \n //________.|.________\\\\     \n`----------`-'----------'"
			});

			Items.Add(new Item
			{
				Name = "Dwarvish Axe",
				GameObjectID = 4,
				Description = "A sharp battle-axe with dwarvish markings. " +
					"This could prove useful.",
				SpaceTimeLocationID = 3,
				HasValue = true,
				Value = 75,
				CanAddToInventory = true,
				itemArt = 
					" _________________.---.______\n" +
					"(_(______________(_o o_(____()\n" +
					"             .___.'. .'.___.\n" +
					"             \\ o    Y    o /\n" +
					"              \\ \\__   __/ /\n" +
					"               '.__'-'__.'\n" +
					"                   '''\n"
			});

			Items.Add(new Item
			{
				Name = "Short-Sword",
				GameObjectID = 5,
				Description = "A short-sword with a sharp edge. " +
					"This could prove useful.",
				SpaceTimeLocationID = 3,
				HasValue = true,
				Value = 75,
				CanAddToInventory = true,
				itemArt = "    /\nO===[====================-\n    \\"
			});
        }

        /// <summary>
        /// initialize the universe with all of the treasures
        /// </summary>
        private void IntializeUniverseTreasures()
        {
            Treasures.Add(new Treasure
            {
                Name = "Star of Elendil",
                TreasureType = Treasure.Type.Ruby,
                GameObjectID = 1,
                Description = "A jewel made of \"elvish crystal\" and " +
					"the chief symbol of the royal line of Arnor",
                SpaceTimeLocationID = 2,
                HasValue = true,
                Value = 150,
                CanAddToInventory = true
            });

            Treasures.Add(new Treasure
            {
                Name = "Star of the Dúnedain",
                TreasureType = Treasure.Type.Lodestone,
                GameObjectID = 2,
                Description = "A silver brooch, shaped like a many-rayed star, worn by the Arnor-descended Rangers of the North.",
                SpaceTimeLocationID = 1,
                HasValue = true,
                Value = 75,
                CanAddToInventory = true
            });

			Treasures.Add(new Treasure
			{
				Name = "Horn of Gondor",
				TreasureType = Treasure.Type.Lodestone,
				GameObjectID = 3,
				Description = "A large war-horn tipped with silver written in ancient characters. " +
					"Belonging to the kings son, someone would certainly be glad reward its return. ",
				SpaceTimeLocationID = 4,
				HasValue = true,
				Value = 150,
				CanAddToInventory = true
			});
        }

		private void IntializeUniverseNPCs()
		{
			NPCs.Add(new NPC
			{
				Name = "Gandalf",
				SpaceTimeLocationID = 2,
				HasMessage = true,
				Message = "Fly you fools!"
			});

			NPCs.Add(new NPC
			{
				Name = "Elrond",
				SpaceTimeLocationID = 1,
				HasMessage = true,
				Message = "Good luck on your journey, traveler."
			});

			NPCs.Add(new NPC
			{
				Name = "Unknown",
				SpaceTimeLocationID = 3,
				HasMessage = true,
				Message = "The dwarf says nothing and avoids your gaze."
			});
		}

        #endregion

    }
}

