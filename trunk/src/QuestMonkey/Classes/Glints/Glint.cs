using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace QuestMonkey
{
	public class Glint
	{
		private XmlNode _node;

		public string Name
		{
			get
			{
				return _node.Name;
			}
		}

		public string LayerName
		{
			get
			{
				if (_node.Attributes["layer"] != null)
				{
					return _node.Attributes["layer"].Value;
				}
				else
				{
					return string.Empty;
				}
			}
		}

		public Glint(XmlNode node)
		{
			_node	= node;
		}
	}
}
