using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SceneEditor
{

	class EventsCollection
	{
		private List<Event> _events;

		public EventsCollection()
		{
			_events = new List<Event>();
		}

		public Event this[string name]
		{
			get 
			{
				foreach (Event myEvent in _events)
				{
					if (myEvent.Name == name)
						return myEvent; 
				}

				return null;
			}
		}

		public void Add(Event newEvent)
		{
			if (newEvent == null) return;

			_events.Add(newEvent);
		}

		public XmlElement SaveToXml(XmlDocument xmlDoc)
		{
			XmlElement eventsNode = xmlDoc.CreateElement("events");
			foreach (Event myEvent in _events)
			{
				eventsNode.AppendChild(myEvent.SaveToXml(eventsNode));
			}

			return eventsNode;
		}

		public void LoadFromXml(XmlNode node)
		{
			foreach (XmlNode eventNode in node.ChildNodes)
			{
				Event newEvent = new Event();
				newEvent.LoadFromXml(eventNode);
				Add(newEvent);
			}

		}
	}
}
