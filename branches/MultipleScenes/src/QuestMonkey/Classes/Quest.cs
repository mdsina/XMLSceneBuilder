using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace QuestMonkey
{
	public class Quest
	{
		public XmlNode Node;

		public string GetAttribute(string attributeName)
		{
			if (Node.Attributes[attributeName] != null)
			{
				return Node.Attributes[attributeName].Value;
			}

			return string.Empty;
		}

		public void SetAttribute(string attributeName, string value)
		{
			((XmlElement)Node).SetAttribute(attributeName, value);
		}

		public bool IsGeneratedDraft
		{
			get 
			{
				XmlElement element = (XmlElement)Node;

				string a = element.GetAttribute("generated_draft");

				return element.GetAttribute("generated_draft") == "1";
				
			}

			set 
			{
				XmlElement element = (XmlElement)Node;

				element.SetAttribute("generated_draft", value ? "1" : "0");
			}
		}



		public string Name
		{
			get { return Node.Name; }
			
		}

		public Quest(XmlNode node)
		{
			Node = node;

			//IsGeneratedDraft = false;

		}
	}
}
