using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
	public class NPC : Character
	{
		public bool _hasMessage;
		public string _message;
		public bool _hasItem;
		public Item _item;

		public bool HasMessage
		{
			get { return _hasMessage; }
			set { _hasMessage = value; }
		}

		public string Message
		{
			get { return _message; }
			set { _message = value; }
		}

		public bool HasItem
		{
			get { return _hasItem; }
			set { _hasItem = value; }
		}

		public Item Item
		{
			get { return _item; }
			set { _item = value; }
		}



		public NPC()
		{
			_hasMessage = false;
			_message = "";
		}

		public NPC(string name, RaceType race, int spaceTimeLocationID, bool HasMessage, string Message, bool HasItem, Item Item) : base(name, race, spaceTimeLocationID)
        {

		}
	}
}

